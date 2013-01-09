
Partial Class Employee_Controls_ctlTimeOffRequestApproval
    Inherits System.Web.UI.UserControl
    Public Sub RefreshGridApprovalEntries()
        If Me.ddlTimeOffTypeId.SelectedValue.ToString <> "0" Then
            Dim AccountTimeOffTypeId As New Guid(Me.ddlTimeOffTypeId.SelectedValue)
            Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("AccountTimeOffTypeId").DefaultValue = AccountTimeOffTypeId.ToString
        Else
            Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("AccountTimeOffTypeId").DefaultValue = System.Guid.Empty.ToString
        End If
        Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("TimeOffAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("StartDate").DefaultValue = Me.txtStartDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("EndDate").DefaultValue = Me.txtEndDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        If Me.ddlTimeOffTypeId.SelectedValue.ToString <> "0" Then
            Dim AccountTimeOffTypeId As New Guid(Me.ddlTimeOffTypeId.SelectedValue)
            Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("AccountTimeOffTypeId").DefaultValue = AccountTimeOffTypeId.ToString
        Else
            Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("AccountTimeOffTypeId").DefaultValue = System.Guid.Empty.ToString
        End If
        Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("TimeOffAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("StartDate").DefaultValue = Me.txtStartDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("EndDate").DefaultValue = Me.txtEndDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        Me.SpecificEmployeeGridView.DataBind()
        Me.EmployeeManagerGridView.DataBind()
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        RefreshGridApprovalEntries()
    End Sub
    Public Sub ForApproved()
        Dim row As GridViewRow
        Dim objTimeOff As New AccountEmployeeTimeOffRequestBLL
        Dim objEmployeeTimeOff As New AccountEmployeeTimeOffBLL
        For Each row In Me.SpecificEmployeeGridView.Rows
            If CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = True And IsDBNull(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved")) Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("TimeOffAccountEmployeeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountTimeOffTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("HoursOff")) Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = False And IsDBNull(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved")) Then
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = True And Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved") = False Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("TimeOffAccountEmployeeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountTimeOffTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("HoursOff")) Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = False And Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved") = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("TimeOffAccountEmployeeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountTimeOffTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("HoursOff")) Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            End If
            Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("StartDate"))
        Next
        Dim row2 As GridViewRow
        For Each row2 In Me.EmployeeManagerGridView.Rows
            If CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = True And IsDBNull(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved")) Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("TimeOffAccountEmployeeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountTimeOffTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("HoursOff")) Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = False And IsDBNull(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved")) Then
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = True And Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved") = False Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("TimeOffAccountEmployeeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountTimeOffTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("HoursOff")) Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = False And Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved") = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("TimeOffAccountEmployeeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountTimeOffTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("HoursOff")) Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            End If
            Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("StartDate"))
        Next
    End Sub
    Public Sub ForRejected()
        Dim row As GridViewRow
        Dim objTimeOff As New AccountEmployeeTimeOffRequestBLL
        For Each row In Me.SpecificEmployeeGridView.Rows
            If CType(row.FindControl("rdSpecificEmployeeRejected"), CheckBox).Checked = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), True, False, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                objTimeOff.LockSpecificEmployeeTimeOffRejected(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                Call New AccountEmployeeTimeEntryBLL().UpdateSubmittedByAccountEmployeeTimeOffRequestId(False, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().UpdateRejectedByAccountEmployeeTimeOffRequestId(True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("StartDate"))
                objTimeOff.SendTimeOffRejectedEMail(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
            End If
        Next
        Dim row2 As GridViewRow
        For Each row2 In Me.EmployeeManagerGridView.Rows
            If CType(row2.FindControl("rdEmployeeManagerRejected"), CheckBox).Checked = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), True, False, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                objTimeOff.LockSpecificEmployeeTimeOffRejected(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                Call New AccountEmployeeTimeEntryBLL().UpdateSubmittedByAccountEmployeeTimeOffRequestId(False, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().UpdateRejectedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("StartDate"))
                objTimeOff.SendTimeOffRejectedEMail(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
            End If

        Next
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ForApproved()
        ForRejected()
        RefreshGridApprovalEntries()
    End Sub
End Class
