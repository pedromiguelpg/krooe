Imports System.IO.File
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim LDAP As New LDAPUtilitiesBLL
        If Not Me.IsPostBack Then
            Me.RunUpdatedScript()
            Me.CheckInstalled()
            If Not Me.Request.QueryString("AutoLogin") Is Nothing Then
                Dim BLL As New AuthenticateBLL
                BLL.AuthenticateLogin(Me.Request.QueryString("Username"), Me.Request.QueryString("Password"), False)
                BLL.LoggedIn(Me.Request.QueryString("Username"), Me.Request.QueryString("Password"))
            ElseIf UIUtilities.GetIntegratedAuthentication = "Yes" And LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                Dim Username As String
                LoggingBLL.WriteToLog("Integrated Authentication Logon_User " & Request.ServerVariables("LOGON_USER"))
                Dim UsernameArray() As String = Request.ServerVariables("LOGON_USER").Split("\")
                If UsernameArray.Length < 2 Then
                    Dim Login As Login
                    Login = CType(Me.CtlLogin1.FindControl("Login1"), Login)
                    CType(Login.FindControl("Username"), TextBox).Text = Me.Request.QueryString("Username")
                    CType(Login.FindControl("Password"), TextBox).Attributes.Add("value", Me.Request.QueryString("Password"))
                Else
                    Username = UsernameArray(1)
                    AuthenticateLogin(Username)
                End If
            Else
                Dim Login As Login
                Login = CType(Me.CtlLogin1.FindControl("Login1"), Login)
                CType(Login.FindControl("Username"), TextBox).Text = Me.Request.QueryString("Username")
                CType(Login.FindControl("Password"), TextBox).Attributes.Add("value", Me.Request.QueryString("Password"))
            End If
        End If

    End Sub
    Public Sub RunUpdatedScript()
        If Exists(Server.MapPath(DBUtilities.SQL_SCRIPT_PATH)) Then
            DBUtilities.CreateDefaultDatabase()
            Response.Redirect("~\Home\ExecuteScript.aspx")
        End If
    End Sub

    Public Sub CheckInstalled()
        Dim IsRedirectedFromSystemSettings As Boolean

        If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
            Dim dtAccount As TimeLiveDataSet.AccountDataTable
            dtAccount = New AccountBLL().GetAccounts()
            If dtAccount.Rows.Count = 0 Then
                If System.Configuration.ConfigurationManager.AppSettings("SHOW_LOGIN_WITH_ACCOUNT_PAGE") = "Yes" Then
                    Exit Sub
                Else
                    UIUtilities.RedirectToAccountAddForInstalled()
                End If
            ElseIf Me.Request.QueryString("Username") = "systemadmin" And IsRedirectedFromSystemSettings = False Then
                IsRedirectedFromSystemSettings = True
            ElseIf Me.Request.QueryString("Username") <> "systemadmin" And System.Web.HttpContext.Current.User.Identity.Name = "systemadmin" Then
                System.Web.HttpContext.Current.Session.Abandon()
                System.Web.Security.FormsAuthentication.SignOut()
            End If
        End If
    End Sub
    Public Sub AuthenticateLogin(Username As String)
        Dim BLL As New AuthenticateBLL
        If BLL.AuthenticateLogin(Username, "", False) = True Then
            BLL.LoggedIn(Username, "")
            If DBUtilities.IsTimeLiveMobileLogin Then
                Response.Redirect(UIUtilities.RedirectToMobileHomePage())
            Else
                Response.Redirect(UIUtilities.RedirectToHomePage())
            End If
        Else
            Dim Login As Login
            Login = CType(Me.CtlLogin1.FindControl("Login1"), Login)
            CType(Login.FindControl("ErrorText"), Label).Visible = True
            CType(Login.FindControl("ErrorText"), Label).Font.Size = 12
            CType(Login.FindControl("ErrorText"), Label).Text = "Your login attempt was not successful. Please try again."
        End If
    End Sub
End Class
