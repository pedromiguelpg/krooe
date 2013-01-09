
Partial Class AccountAdmin_frmAccountProjectTemplates
    Inherits System.Web.UI.Page

    Protected Sub CtlAccountProjectList1_GridViewRowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles CtlAccountProjectList1.GridViewRowCommand
        If e.CommandName = "Select" Then
            Me.CtlAccountProjectList1.FindControl("GridView1").Visible = False
            Me.CtlAccountProjectForm1.FindControl("FormView1").Visible = True
            Me.CtlAccountProjectList1.FindControl("btnAddProject").Visible = False
            Me.CtlAccountProjectList1.FindControl("btnDeleteSelectedItem").Visible = False
            Me.CtlAccountProjectForm1.EditRecord(CType(sender, GridView).Rows(e.CommandArgument).Cells(0).Text)
        End If
    End Sub

    Protected Sub CtlAccountProjectForm1_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles CtlAccountProjectForm1.Inserted
        Me.CtlAccountProjectList1.DoRefresh()
    End Sub

    Protected Sub CtlAccountProjectForm1_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles CtlAccountProjectForm1.Updated
        Me.CtlAccountProjectList1.DoRefresh()
    End Sub

    Protected Sub CtlAccountProjectList1_GridViewRowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles CtlAccountProjectList1.GridViewRowDeleted
        UIUtilities.AfterGridViewRowDelete(CtlAccountProjectForm1.FindControl("FormView1"))
        UIUtilities.OnDeleteException(e)
        Me.CtlAccountProjectForm1.FindControl("FormView1").DataBind()
    End Sub
    Protected Sub CtlAccountProjectList1_btnAddProjectClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectList1.btnAddProjectClick
        Me.CtlAccountProjectForm1.FindControl("FormView1").Visible = True
        Me.CtlAccountProjectList1.FindControl("GridView1").Visible = False
        Me.CtlAccountProjectList1.FindControl("btnDeleteSelectedItem").Visible = False
        Me.CtlAccountProjectList1.FindControl("btnAddProject").Visible = False
    End Sub
    Protected Sub CtlAccountProjectForm1_btnCancelClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectForm1.btnCancelClick
        Me.CtlAccountProjectList1.FindControl("btnAddProject").Visible = True
        Me.CtlAccountProjectList1.FindControl("btnDeleteSelectedItem").Visible = True
    End Sub
    Protected Sub CtlAccountProjectForm1_btnUpdateClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectForm1.btnUpdateClick
        Me.CtlAccountProjectList1.FindControl("btnAddProject").Visible = True
        Me.CtlAccountProjectList1.FindControl("btnDeleteSelectedItem").Visible = True
    End Sub
End Class
