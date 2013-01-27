﻿'Imports Google.Apis.Calendar.v3
Imports Google.GData.Client
Imports Google.GData.Calendar

Partial Class oauth2callback_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If String.IsNullOrEmpty(Request.QueryString("code")) Then
            Response.Redirect("~/Employee/MyTasks.aspx")
        Else
            Session("ACCESS_CODE") = Uri.UnescapeDataString(Request.QueryString("code"))

            
            Dim parameters As New OAuth2Parameters()
            parameters.AccessCode = Session("ACCESS_CODE").ToString()
            parameters.RedirectUri = "http://greenrssreader.com/oauth2callback/default.aspx"
            parameters.ClientId = "755260777773.apps.googleusercontent.com"
            parameters.ClientSecret = "u0jqn7WLyd3zWQzQ2VQKB7BN"

            OAuthUtil.GetAccessToken(parameters)

            Session("ACCESS_TOKEN") = parameters.AccessToken
            Session("REFRESH_TOKEN") = parameters.RefreshToken


                Response.Redirect("~/Employee/SyncTasks.aspx")
            End If
    End Sub
End Class