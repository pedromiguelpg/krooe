Imports Microsoft.VisualBasic
Imports AccountEmployeeTimeOffRequestTableAdapters
Imports AccountTimeOffTypeTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeTimeOffRequestBLL
    Private _AccountEmployeeTimeOffRequestTableAdapter As AccountEmployeeTimeOffRequestTableAdapter = Nothing
    Private _AccountEmployeeTimeOffRequestApprovalTableAdapter As AccountEmployeeTimeOffRequestApprovalTableAdapter = Nothing
    Private _AccountTimeOffTypeTableAdapter As AccountTimeOffTypeTableAdapter = Nothing
    Dim AccountEmployeeTimeEntryPeriodIdTS As Guid
    Dim TimesheetPeriodTypeTS As String
    Dim PeriodStartDateTS As Date
    Dim PeriodEndDateTS As Date
    Protected ReadOnly Property Adapter() As AccountEmployeeTimeOffRequestTableAdapter
        Get
            If _AccountEmployeeTimeOffRequestTableAdapter Is Nothing Then
                _AccountEmployeeTimeOffRequestTableAdapter = New AccountEmployeeTimeOffRequestTableAdapter()
            End If

            Return _AccountEmployeeTimeOffRequestTableAdapter
        End Get
    End Property
    Protected ReadOnly Property ApprovalAdapter() As AccountEmployeeTimeOffRequestApprovalTableAdapter
        Get
            If _AccountEmployeeTimeOffRequestApprovalTableAdapter Is Nothing Then
                _AccountEmployeeTimeOffRequestApprovalTableAdapter = New AccountEmployeeTimeOffRequestApprovalTableAdapter()
            End If

            Return _AccountEmployeeTimeOffRequestApprovalTableAdapter
        End Get
    End Property
    Protected ReadOnly Property TimeOffTypeAdapter() As AccountTimeOffTypeTableAdapter
        Get
            If _AccountTimeOffTypeTableAdapter Is Nothing Then
                _AccountTimeOffTypeTableAdapter = New AccountTimeOffTypeTableAdapter()
            End If

            Return _AccountTimeOffTypeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffRequestByAccountId(ByVal AccountId As Integer) As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffByEmployeeIdAndTimeOffTypeId(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestDataTable
        Dim vueEmployee As New vueAccountEmployeeTimeOffRequestTableAdapter
        Return vueEmployee.GetDataByAccountEmployeeIdandAccountTimeOffTypeId(DBUtilities.GetSessionAccountId, AccountEmployeeId, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffRequestByEmployeeRequestId(ByVal AccountEmployeeTimeOffRequestId As Guid) As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable
        Return Adapter.GetDataByAccountEmployeeTimeOffRequestId(AccountEmployeeTimeOffRequestId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeOffRequestByAccountId(ByVal AccountId As Integer) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestDataTable
        Dim vueEmployee As New vueAccountEmployeeTimeOffRequestTableAdapter
        GetvueAccountEmployeeTimeOffRequestByAccountId = vueEmployee.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeOffRequestByAccountIdAndAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestDataTable
        Dim vueEmployee As New vueAccountEmployeeTimeOffRequestTableAdapter
        GetvueAccountEmployeeTimeOffRequestByAccountIdAndAccountEmployeeId = vueEmployee.GetDataByAccountIdAndAccountEmployeeId(AccountId, AccountEmployeeId)
        UIUtilities.FixTableForNoRecords(GetvueAccountEmployeeTimeOffRequestByAccountIdAndAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeOffRequestApprovalForSpecificEmployee(ByVal AccountTimeOffTypeId As Guid, ByVal TimeOffAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
        Dim _vueAccountEmployeeTimeOffRequestApprovalPendingTableAdapter As New vueAccountEmployeeTimeOffRequestApprovalPendingTableAdapter
        Return _vueAccountEmployeeTimeOffRequestApprovalPendingTableAdapter.GetApprovalEntriesForSpecificEmployee(AccountTimeOffTypeId, TimeOffAccountEmployeeId, IncludeDateRange, StartDate, EndDate, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
 Public Function GetvueAccountEmployeeTimeOffRequestApprovalForEmployeeManager(ByVal AccountTimeOffTypeId As Guid, ByVal TimeOffAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
        Dim _vueAccountEmployeeTimeOffRequestApprovalPendingTableAdapter As New vueAccountEmployeeTimeOffRequestApprovalPendingTableAdapter
        Return _vueAccountEmployeeTimeOffRequestApprovalPendingTableAdapter.GetApprovalEntriesForEmployeeManager(AccountTimeOffTypeId, TimeOffAccountEmployeeId, IncludeDateRange, StartDate, EndDate, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedTimeOffForEmail(ByVal AccountEmployeeTimeOffRequestId As Guid) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovedEmailDataTable
        Dim _vueAccountEmployeeTimeOffRequestApprovedEmailTableAdapter As New vueAccountEmployeeTimeOffRequestApprovedEmailTableAdapter
        Return _vueAccountEmployeeTimeOffRequestApprovedEmailTableAdapter.GetDataByAccountEmployeeTimeOffRequestId(AccountEmployeeTimeOffRequestId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetRejectedTimeOffForEmail(ByVal AccountEmployeeTimeOffRequestId As Guid) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRejectedEmailDataTable
        Dim _vueAccountEmployeeTimeOffRequestRejectedEmailTableAdapter As New vueAccountEmployeeTimeOffRequestRejectedEmailTableAdapter
        Return _vueAccountEmployeeTimeOffRequestRejectedEmailTableAdapter.GetDataByAccountEmployeeTimeOffRequestId(AccountEmployeeTimeOffRequestId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryApprovalsWithPreferenceTimeEntryForTimeOffGroupByApproverEmployeeId() As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffGroupByApproverEmployeeIdDataTable
        Dim _vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffGroupByApproverEmployeeIdTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffGroupByApproverEmployeeIdTableAdapter
        '_vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffGroupByApproverEmployeeIdTableAdapter.SetCommandTimeOut(1000)
        Return _vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffGroupByApproverEmployeeIdTableAdapter.GetData()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeOffRequestApprovalsWithPreferenceForGroupByApproverEmployeeId() As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdDataTable
        Dim _vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter As New vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter
        '_vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffGroupByApproverEmployeeIdTableAdapter.SetCommandTimeOut(1000)
        Return _vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter.GetData()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeEntryForTimeOffApprovalsWithPreferenceByApproverEmployeeIdForEmail(ByVal ApproverEmployeeId As Integer) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffDataTable
        LoggingBLL.WriteToLog("GetPendingTimeEntryForTimeOffApprovalsWithPreferenceByApproverEmployeeIdForEmail" & " " & ApproverEmployeeId)
        Dim _vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffTableAdapter As New vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffTableAdapter
        Return _vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffTableAdapter.GetDataByApproverEmployeeId(ApproverEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetPendingTimeOffRequestApprovalsWithPreferenceByApproverEmployeeIdForEmail(ByVal ApproverEmployeeId As Integer) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceDataTable
        LoggingBLL.WriteToLog("GetPendingTimeEntryForTimeOffApprovalsWithPreferenceByApproverEmployeeIdForEmail" & " " & ApproverEmployeeId)
        Dim _vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceTableAdapter As New vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceTableAdapter
        Return _vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceTableAdapter.GetDataByApproverEmployeeId(ApproverEmployeeId)
    End Function
    Public Sub SendTimeEntryForTimeOffPendingEMail(ByVal AccountEmployeeId As Integer)

        SendPendingTimeEntryForTimeOff(AccountEmployeeId)

    End Sub
    Public Sub SendTimeOffPendingEMail(ByVal AccountEmployeeId As Integer)

        SendPendingTimeOffRequest(AccountEmployeeId)

    End Sub
    Public Shared Function GetDefaultScheduleEmailSendTime(ByVal dr As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffGroupByApproverEmployeeIdRow) As DateTime
        If Not IsDBNull(dr.Item("ScheduledEmailSendTime")) Then
            Return dr.ScheduledEmailSendTime
        Else
            Return "11:00:00 PM"
        End If
    End Function
    Public Shared Function GetDefaultScheduleEmailSendTimeForTimeOff(ByVal dr As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdRow) As DateTime
        If Not IsDBNull(dr.Item("ScheduledEmailSendTime")) Then
            Return dr.ScheduledEmailSendTime
        Else
            Return "11:00:00 PM"
        End If
    End Function
    Public Sub SendPendingTimeEntryForTimeOff(ByVal AccountEmployeeId As Integer)

        Dim BLL As New AccountEmployeeTimeOffRequestBLL

        Dim dtPendingApprovals As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffDataTable = BLL.GetPendingTimeEntryForTimeOffApprovalsWithPreferenceByApproverEmployeeIdForEmail(AccountEmployeeId)
        If dtPendingApprovals.Rows.Count > 0 Then
            Dim drPendingApprovals As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffRow = dtPendingApprovals.Rows(0)

            Dim strHeader As String = ""
            Dim strBody As String = ""
            Dim CultureName As String
            If IsDBNull(drPendingApprovals.Item("CultureInfoName")) Or drPendingApprovals.Item("CultureInfoName").ToString = "auto" Then
                CultureName = "en-us"
            Else
                CultureName = drPendingApprovals.Item("CultureInfoName")
            End If
            strHeader = strHeader & IIf(strHeader = "", "", "") & "<td align=" & "center" & ">" & ("Employee Name" & "</td>" & "<td align=" & "center" & ">" & "Time Off Date" & "</td>" & "<td align=" & "center" & ">" & "Time Off Type" & "</td>" & "<td align=" & "center" & ">" & "Total Minutes" & "</td>" & "<td align=" & "center" & ">" & "Submitted Date" & "</td>")

            For Each drPendingApprovals In dtPendingApprovals.Rows
                Dim StartDate As Date = drPendingApprovals.TimeEntryDate
                Dim EndDate As Date = drPendingApprovals.TimeEntryDate

                ''Pending
                'Dim SubmittedDate As Date = Me.GetSubmittedDateForTimesheetEmail(drPendingApprovals.AccountEmployeeTimeEntryPeriodId, StartDate)
                Dim SubmittedDate As Date = New AccountEmployeeTimeEntryBLL().GetSubmittedDateForTimesheetEmail(drPendingApprovals.AccountEmployeeTimeEntryPeriodId, drPendingApprovals.TimeEntryDate)

                strBody = strBody & IIf(strBody = "", "", "<br/>") & "<tr>" & "<td>" & (drPendingApprovals.EmployeeName & "</td>" & "<td>" & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(StartDate, CultureName) & "</td>" & "<td align=" & "center" & ">" & drPendingApprovals.AccountTimeOffType & "</td>" & "<td align=" & "center" & ">" & drPendingApprovals.TotalMinutes & "</td>" & "<td align=" & "center" & ">" & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(SubmittedDate, CultureName) & "</td>" & "</tr>")

            Next
            EMailUtilities.SendEMail("TimeOff approvals are due", "TimeOffPendingTemplate", GetPreparedEMailMessageForPendingTimeEntryForTimeOff(strBody, strHeader), drPendingApprovals.ApproverEmailAddress, , , EMailUtilities.TIMEOFF_APPROVAL_PENDING_NOTIFICATION_INFORMATION_FROM)
        End If
    End Sub
    Public Sub SendPendingTimeOffRequest(ByVal AccountEmployeeId As Integer)

        Dim BLL As New AccountEmployeeTimeOffRequestBLL

        Dim dtPendingApprovals As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceDataTable = BLL.GetPendingTimeOffRequestApprovalsWithPreferenceByApproverEmployeeIdForEmail(AccountEmployeeId)
        If dtPendingApprovals.Rows.Count > 0 Then
            Dim drPendingApprovals As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreferenceRow = dtPendingApprovals.Rows(0)

            Dim strHeader As String = ""
            Dim strBody As String = ""
            Dim CultureName As String
            If IsDBNull(drPendingApprovals.Item("CultureInfoName")) Or drPendingApprovals.Item("CultureInfoName").ToString = "auto" Then
                CultureName = "en-us"
            Else
                CultureName = drPendingApprovals.Item("CultureInfoName")
            End If
            strHeader = strHeader & IIf(strHeader = "", "", "") & "<td align=" & "center" & ">" & ("Employee Name" & "</td>" & "<td align=" & "center" & ">" & "Time Off Period" & "</td>" & "<td align=" & "center" & ">" & "Time Off Type" & "</td>" & "<td align=" & "center" & ">" & "Day Off" & "</td>" & "<td align=" & "center" & ">" & "Day Hours" & "</td>" & "<td align=" & "center" & ">" & "Submitted Date" & "</td>")

            For Each drPendingApprovals In dtPendingApprovals.Rows
                Dim StartDate As Date = drPendingApprovals.StartDate
                Dim EndDate As Date = drPendingApprovals.EndDate

                ''Pending
                Dim SubmittedDate As Date = drPendingApprovals.RequestSubmitDate

                strBody = strBody & IIf(strBody = "", "", "<br/>") & "<tr>" & "<td>" & (drPendingApprovals.FullName & "</td>" & "<td>" & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(StartDate, CultureName) & " - " & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(EndDate, CultureName) & "</td>" & "<td align=" & "center" & ">" & drPendingApprovals.AccountTimeOffType & "</td>" & "<td align=" & "center" & ">" & drPendingApprovals.DayOff & "</td>" & "<td align=" & "center" & " ; " & "valign=" & "middle" & ">" & drPendingApprovals.HoursOff & "</td>" & "<td align=" & "center" & ">" & LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(SubmittedDate, CultureName) & "</td>" & "</tr>")

            Next
            EMailUtilities.SendEMail("TimeOff Request approvals are due", "TimeOffRequestPendingTemplate", GetPreparedEMailMessageForPendingTimeOff(strBody, strHeader), drPendingApprovals.ApproverEmailAddress, , , EMailUtilities.TIME_OFF_REQUEST_APPROVAL_PENDING_NOTIFICATION_INFORMATION_FROM)
        End If
    End Sub
    Public Function GetPreparedEMailMessageForPendingTimeEntryForTimeOff(ByVal strBody As String, ByVal strHeader As String) As StringDictionary

        Dim dict As New StringDictionary

        dict.Add("[strBody]", strBody)
        dict.Add("[strHeader]", strHeader)
        dict.Add("[url]", System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "ProjectAdmin/TimesheetApproval.aspx")
        'dict.Add("[timeentrydate]", drvueAccountEmployeeTimeEntryApprovalPending.TimeEntryDate)
        'dict.Add("[projectname]", drvueAccountEmployeeTimeEntryApprovalPending.ProjectName)
        'dict.Add("[taskname]", drvueAccountEmployeeTimeEntryApprovalPending.TaskName)

        'Dim TTime As String
        'TTime = Format(drvueAccountEmployeeTimeEntryApprovalPending.TotalTime, "HH:mm")
        'dict.Add("[totaltime]", TTime)

        Return dict

    End Function
    Public Function GetPreparedEMailMessageForPendingTimeOff(ByVal strBody As String, ByVal strHeader As String) As StringDictionary

        Dim dict As New StringDictionary

        dict.Add("[strBody]", strBody)
        dict.Add("[strHeader]", strHeader)
        dict.Add("[url]", System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "ProjectAdmin/TimeOffApproval.aspx")
        'dict.Add("[timeentrydate]", drvueAccountEmployeeTimeEntryApprovalPending.TimeEntryDate)
        'dict.Add("[projectname]", drvueAccountEmployeeTimeEntryApprovalPending.ProjectName)
        'dict.Add("[taskname]", drvueAccountEmployeeTimeEntryApprovalPending.TaskName)

        'Dim TTime As String
        'TTime = Format(drvueAccountEmployeeTimeEntryApprovalPending.TotalTime, "HH:mm")
        'dict.Add("[totaltime]", TTime)

        Return dict

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeOffRequest( _
                ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal HoursOff As Double, ByVal StartDate As DateTime, _
                ByVal EndDate As DateTime, ByVal Description As String, ByVal DayOff As Double, ByVal AccountProjectId As Integer) As Boolean
        _AccountEmployeeTimeOffRequestTableAdapter = New AccountEmployeeTimeOffRequestTableAdapter
        Dim dtTimeOff As New AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable
        Dim drTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestRow = dtTimeOff.NewAccountEmployeeTimeOffRequestRow
        Dim Approved As Boolean
        Dim TimeOffBLL As New AccountEmployeeTimeOffBLL
        Dim IsTimeOffConsumed As Boolean
        Dim Employee As AccountEmployee.AccountEmployeeRow = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId).Rows(0)
        Dim AccountEmployeeTimeOffRequestId As Guid = System.Guid.NewGuid
        With drTimeOff
            .AccountEmployeeTimeOffRequestId = AccountEmployeeTimeOffRequestId
            .AccountTimeOffTypeId = AccountTimeOffTypeId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .RequestSubmitDate = Now.Date
            .HoursOff = HoursOff
            .StartDate = StartDate
            .EndDate = EndDate
            If Description <> "" Then
                .Description = Description
            End If
            .DayOff = DayOff
            .CreatedByEmployee = DBUtilities.GetSessionAccountEmployeeId
            .CreatedOn = Now.Date
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now.Date
            If IsDBNull(Employee.Item("TimeOffApprovalTypeId")) OrElse Employee.Item("TimeOffApprovalTypeId") = 0 Then
                .Approved = True
                Approved = True
                If TimeOffBLL.SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, AccountTimeOffTypeId, HoursOff) Then
                    IsTimeOffConsumed = True
                End If
            Else
                .Approved = False
                Approved = False
            End If
            .Rejected = False
            If AccountProjectId <> 0 Then
                .AccountProjectId = AccountProjectId
            End If
        End With
        dtTimeOff.AddAccountEmployeeTimeOffRequestRow(drTimeOff)
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        Me.AfterTimeOffRequestTimeEntryProcedure(AccountEmployeeId, AccountTimeOffTypeId, HoursOff, StartDate, EndDate, Description, DayOff, AccountEmployeeTimeOffRequestId, False, Approved, AccountProjectId, IsTimeOffConsumed)
        Return rowsAffected = 1
    End Function
    Public Sub InsertDefaultTimeEntryTimeOff(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal HoursOff As Double, ByVal StartDate As DateTime, _
    ByVal EndDate As DateTime, ByVal Description As String, ByVal AccountEmployeeTimeOffRequestId As Guid, ByVal Approved As Boolean, ByVal AccountProjectId As Integer, ByVal DaysOff As Double)
        Dim dtHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable = New AccountHolidayTypeBLL().GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
        Dim dt As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable = New AccountWorkingDayBLL().GetWorkingDaysByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim TotalDaysOff As Integer = DateDiff("d", StartDate, EndDate.AddDays(1))
        Dim HoursPerDay As String = DBUtilities.GetHoursPerDay.ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo)
        Dim TH As String()
        Dim count As Integer
        Dim TotalHours As String
        Dim Hours As String
        Dim Day As String() = DaysOff.ToString.Split(".")
        Dim daysoffcount As Integer = Day(0)
        For n As Integer = 0 To TotalDaysOff - 1
            If DaysOff < 1 Then
                TH = (HoursOff).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Split(".")
            Else
                TH = HoursPerDay.Split(".")
            End If
            '  TotalHours = IIf(HoursOff = 0, (HoursOff).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo), (HoursOff / DaysOff).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo))
            If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                If DaysOff < 1 Then
                    TotalHours = HoursOff
                Else
                    TotalHours = HoursPerDay
                End If                
            Else
                TotalHours = LocaleUtilitiesBLL.ConvertHoursToTimeFormat(TH(0), TH(1))
            End If

            Dim TimeEntryDate As Date = StartDate.AddDays(n)
            If Me.IsCurrentDateEntryAllow(TimeEntryDate, dt, dtHoliday) Then
                SetPeriodDataByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate)
                TimeEntryBLL.AddAccountEmployeeTimeEntry(AccountEmployeeId, TimeEntryDate, Nothing, Nothing, TotalHours, AccountProjectId, 0, Description, Approved, Now, Now, 0, True, 0, 0, TimesheetPeriodTypeTS, PeriodStartDateTS, PeriodEndDateTS, AccountEmployeeTimeEntryPeriodIdTS, True, AccountTimeOffTypeId, AccountEmployeeTimeOffRequestId, System.Guid.Empty, 0)
                count += 1
                Hours += Single.Parse(HoursPerDay, System.Globalization.NumberFormatInfo.InvariantInfo)
                If daysoffcount = count Then
                    HoursPerDay = (HoursOff - Hours).ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo)
                End If
            End If
        Next
    End Sub
    Public Function SetPeriodDataByAccountEmployeeIdAndTimeEntryDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, Optional ByVal Submitted As Boolean = False, Optional ByVal Approved As Boolean = False) As Guid
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim dtPeriodStartDate As Date = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, DBUtilities.GetEmployeeTimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        Dim dtPeriodEndDate As Date = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, DBUtilities.GetEmployeeTimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        Dim TimesheetPeriodType As String = New AccountEmployeeTimeEntryBLL().CheckAndGetTimesheetPeriodType(AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, DBUtilities.GetEmployeeTimesheetPeriodType)
        If TimesheetPeriodType <> DBUtilities.GetEmployeeTimesheetPeriodType Then
            dtPeriodStartDate = GetPeriodStartDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
            dtPeriodEndDate = GetPeriodEndDateByTimesheetPeriodType(TimeEntryDate, TimesheetPeriodType, DBUtilities.GetSessionEmployeeWeekStartDay, DBUtilities.GetSystemInitialDayOfFirstPeriod, DBUtilities.GetSystemInitialDayOfLastPeriod, DBUtilities.GetInitialDayOfTheMonth)
        End If
        Dim dtAccountEmployeeTimeEntryPeriodId As Guid = TimeEntryBLL.GetTimeEntryPeriodIdForTimeEntry(DBUtilities.GetSessionAccountId, AccountEmployeeId, dtPeriodStartDate, dtPeriodEndDate, TimesheetPeriodType, Submitted, Approved, False, False, True)
        TimesheetPeriodTypeTS = TimesheetPeriodType
        PeriodStartDateTS = dtPeriodStartDate
        PeriodEndDateTS = dtPeriodEndDate
        AccountEmployeeTimeEntryPeriodIdTS = dtAccountEmployeeTimeEntryPeriodId
    End Function
    Public Function IsCurrentDateEntryAllow(ByVal TimeEntryDate As Date, ByVal dt As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable, ByVal dtHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable) As Boolean
        Dim dr As TimeLiveDataSet.vueAccountEmployeeWorkingDaysRow
        Dim Holidaydr() As DataRow = dtHoliday.Select("HolidayDate = '" & TimeEntryDate & "'")
        Dim chkDay As Boolean
        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                If Left(dr.WorkingDay, 3) = LocaleUtilitiesBLL.GetDayInCurrentLocale(TimeEntryDate) Then
                    chkDay = True
                End If
            Next
        End If
        If Holidaydr.Length > 0 Then
            Return False
        End If
        If chkDay And Holidaydr.Length = 0 Then
            Return True
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function AddAccountEmployeeTimeOffRequestApproval( _
                     ByVal AccountEmployeeTimeOffRequestId As Guid, ByVal TimeOffApprovalTypeId As Integer, ByVal TimeOffApprovalPathId As Integer, _
                    ByVal ApprovedByEmployeeId As Integer, ByVal IsRejected As Boolean, ByVal IsApproved As Boolean, ByVal Comments As String) As Boolean

        _AccountEmployeeTimeOffRequestApprovalTableAdapter = New AccountEmployeeTimeOffRequestApprovalTableAdapter

        Dim dtTimeOff As New AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestApprovalDataTable
        Dim drTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestApprovalRow = dtTimeOff.NewAccountEmployeeTimeOffRequestApprovalRow

        With drTimeOff
            .AccountEmployeeTimeOffRequestApprovalId = System.Guid.NewGuid
            .AccountEmployeeTimeOffRequestId = AccountEmployeeTimeOffRequestId
            .TimeOffApprovalTypeId = TimeOffApprovalTypeId
            .TimeOffApprovalPathId = TimeOffApprovalPathId
            .ApprovedByEmployeeId = ApprovedByEmployeeId
            .ApprovedOn = Now.Date
            .IsRejected = IsRejected
            .IsApproved = IsApproved
            .Comments = Comments
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .CreatedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
        End With

        dtTimeOff.AddAccountEmployeeTimeOffRequestApprovalRow(drTimeOff)

        Dim rowsAffected As Integer = ApprovalAdapter.Update(dtTimeOff)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTimeOffRequest( _
            ByVal AccountTimeOffTypeId As Guid, ByVal HoursOff As Double, ByVal StartDate As DateTime, _
            ByVal EndDate As DateTime, ByVal Description As String, ByVal DayOff As Double, ByVal Original_AccountEmployeeTimeOffRequestId As Guid, ByVal AccountProjectId As Integer) As Boolean

        _AccountEmployeeTimeOffRequestTableAdapter = New AccountEmployeeTimeOffRequestTableAdapter
        Dim Approved As Boolean
        Dim ConsumedHoursOff As Double
        Dim OldHours As Double
        Dim TimeOffBLL As New AccountEmployeeTimeOffBLL
        Dim IsTimeOffConsumed As Boolean
        Dim dtTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable = Adapter.GetDataByAccountEmployeeTimeOffRequestId(Original_AccountEmployeeTimeOffRequestId)
        Dim drTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestRow = dtTimeOff.Rows(0)
        Dim Employee As AccountEmployee.AccountEmployeeRow = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(drTimeOff.AccountEmployeeId).Rows(0)
        With drTimeOff
            ConsumedHoursOff = HoursOff - .HoursOff
            OldHours = .HoursOff
            .HoursOff = HoursOff
            .StartDate = StartDate
            .EndDate = EndDate
            If Description <> "" Then
                .Description = Description
            End If
            .DayOff = DayOff
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now.Date
            If Not IsDBNull(.Item("Approved")) And .Item("Approved").ToString = "True" Then
                .Approved = True
                Approved = True
            Else
                If IsDBNull(Employee.Item("TimeOffApprovalTypeId")) OrElse Employee.Item("TimeOffApprovalTypeId") = 0 Then
                    .Approved = True
                    Approved = True
                Else
                    .Approved = False
                    Approved = False
                End If
            End If
            If .AccountTimeOffTypeId <> AccountTimeOffTypeId And Approved = True Then
                If TimeOffBLL.SetEmployeeTimeOffHoursFromTimeOffRequest(drTimeOff.AccountEmployeeId, AccountTimeOffTypeId, HoursOff) Then
                    IsTimeOffConsumed = True
                End If
                If TimeOffBLL.SetEmployeeTimeOffHoursFromTimeOffRequest(drTimeOff.AccountEmployeeId, drTimeOff.AccountTimeOffTypeId, -OldHours) Then
                    IsTimeOffConsumed = True
                End If
                ConsumedHoursOff = 0
            End If
            .AccountTimeOffTypeId = AccountTimeOffTypeId
            .Rejected = False
            If AccountProjectId <> 0 Then
                .AccountProjectId = AccountProjectId
            End If
        End With
        If ConsumedHoursOff <> 0 And Approved = True Then
            If TimeOffBLL.SetEmployeeTimeOffHoursFromTimeOffRequest(drTimeOff.AccountEmployeeId, AccountTimeOffTypeId, ConsumedHoursOff) Then
                IsTimeOffConsumed = True
            End If
        End If
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        Me.AfterTimeOffRequestTimeEntryProcedure(drTimeOff.AccountEmployeeId, AccountTimeOffTypeId, HoursOff, StartDate, EndDate, Description, DayOff, Original_AccountEmployeeTimeOffRequestId, True, Approved, AccountProjectId, IsTimeOffConsumed)
        Return rowsAffected = 1
    End Function
    Public Sub AfterTimeOffRequestTimeEntryProcedure(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal HoursOff As Double, ByVal StartDate As DateTime, _
            ByVal EndDate As DateTime, ByVal Description As String, ByVal DayOff As Double, ByVal Original_AccountEmployeeTimeOffRequestId As Guid, ByVal IsUpdate As Boolean, ByVal Approved As Boolean, ByVal AccountProjectId As Integer, ByVal IsTimeOffConsumed As Boolean)
        If IsUpdate Then
            Call New AccountEmployeeTimeEntryBLL().DeleteAccountEmployeeTimeEntryByAccountEmployeeTimeOffRequestId(Original_AccountEmployeeTimeOffRequestId)
        End If
        Me.InsertDefaultTimeEntryTimeOff(AccountEmployeeId, AccountTimeOffTypeId, HoursOff, StartDate, EndDate, Description, Original_AccountEmployeeTimeOffRequestId, Approved, AccountProjectId, DayOff)
        Call New AccountEmployeeTimeEntryBLL().UpdateSubmittedByAccountEmployeeTimeOffRequestId(True, Original_AccountEmployeeTimeOffRequestId)
        Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(Approved, Original_AccountEmployeeTimeOffRequestId)
        If Approved And IsTimeOffConsumed Then
            Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Original_AccountEmployeeTimeOffRequestId, True)
        End If
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeTimeOffRequest(ByVal Original_AccountEmployeeTimeOffRequestId As Guid) As Boolean
        Try
            Dim HoursOff As Double
            Dim AccountEmployeeId As Integer
            Dim AccountTimeOffTypeId As Guid
            Dim BLL As New AccountEmployeeTimeEntryBLL
            Dim Approved As Boolean
            Dim RequestDate As Date
            Dim vueEmployee As New vueAccountEmployeeTimeOffRequestTableAdapter
            Dim dtTimeOff As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestDataTable = vueEmployee.GetDataByAccountEmployeeTimeOffRequestId(Original_AccountEmployeeTimeOffRequestId)
            Dim drTimeOff As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRow = dtTimeOff.Rows(0)
            If dtTimeOff.Rows.Count > 0 Then
                If CheckTimeOffDeduction(drTimeOff) Then
                    HoursOff = -drTimeOff.HoursOff
                    AccountEmployeeId = drTimeOff.AccountEmployeeId
                    AccountTimeOffTypeId = drTimeOff.AccountTimeOffTypeId
                    Approved = drTimeOff.Approved
                    RequestDate = drTimeOff.StartDate
                End If
            End If
            Dim rowsAffected As Integer = Adapter.Delete(Original_AccountEmployeeTimeOffRequestId)
            If Approved Then
                Call New AccountEmployeeTimeOffBLL().SetEmployeeTimeOffHoursFromTimeOffRequest(AccountEmployeeId, AccountTimeOffTypeId, HoursOff)
            End If
            BLL.AfterUpdate(RequestDate)
            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception("Can�t delete. Dependent data is exist with this record.")
        End Try
    End Function
    Public Function CheckTimeOffDeduction(ByVal drTimeOff As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRow)
        Dim BLL As New AccountEmployeeTimeEntryBLL
        Dim IsTimeOffConsumed As Boolean = BLL.GetIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(drTimeOff.AccountEmployeeTimeOffRequestId)
        If IsDBNull(drTimeOff.Item("LastResetDate")) Then
            Return IsTimeOffConsumed
        End If
        If drTimeOff.LastResetDate <= drTimeOff.EndDate Then
            Return IsTimeOffConsumed
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockSpecificEmployeeTimeOff(ByVal Original_AccountEmployeeTimeOffRequestId As Guid, _
            ByVal Approved As Boolean _
            ) As Boolean
        ' Update the product record
        Dim dtTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable = Adapter.GetDataByAccountEmployeeTimeOffRequestId(Original_AccountEmployeeTimeOffRequestId)
        Dim drTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestRow = dtTimeOff.Rows(0)
        With drTimeOff
            .ModifiedOn = Now
            .Approved = Approved
            .InApproval = Approved
            .ApprovedOn = Now.Date
            .ApprovedBy = DBUtilities.GetSessionAccountEmployeeId
            .Rejected = False
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockEmployeeManagerTimeOff(ByVal Original_AccountEmployeeTimeOffRequestId As Guid, _
        ByVal Approved As Boolean _
        ) As Boolean

        ' Update the product record

        Dim dtTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable = Adapter.GetDataByAccountEmployeeTimeOffRequestId(Original_AccountEmployeeTimeOffRequestId)
        Dim drTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestRow = dtTimeOff.Rows(0)

        With drTimeOff
            .ModifiedOn = Now
            .Approved = Approved
            .InApproval = Approved
            .ApprovedOn = Now.Date
            .ApprovedBy = DBUtilities.GetSessionAccountEmployeeId
            .Rejected = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
Public Function LockSpecificEmployeeTimeOffRejected(ByVal Original_AccountEmployeeTimeOffRequestId As Guid, _
        ByVal Rejected As Boolean _
        ) As Boolean

        ' Update the product record

        Dim dtTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable = Adapter.GetDataByAccountEmployeeTimeOffRequestId(Original_AccountEmployeeTimeOffRequestId)
        Dim drTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestRow = dtTimeOff.Rows(0)

        With drTimeOff
            .ModifiedOn = Now
            .Rejected = Rejected
        End With


        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function LockEmployeeManagerTimeOffRejected(ByVal Original_AccountEmployeeTimeOffRequestId As Guid, _
        ByVal Rejected As Boolean _
        ) As Boolean

        ' Update the product record

        Dim dtTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestDataTable = Adapter.GetDataByAccountEmployeeTimeOffRequestId(Original_AccountEmployeeTimeOffRequestId)
        Dim drTimeOff As AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestRow = dtTimeOff.Rows(0)

        With drTimeOff
            .ModifiedOn = Now
            .Rejected = Rejected
        End With


        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function GetPreparedEMailMessageForApprovedTimeOff(ByVal dr As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovedEmailRow) As StringDictionary
        Dim drAccountEmployee As AccountEmployee.AccountEmployeeRow
        Dim objAccountEmployee As New AccountEmployeeBLL
        drAccountEmployee = objAccountEmployee.GetAccountEmployeesByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId).Rows(0)
        Dim dict As New StringDictionary
        dict.Add("[employeename]", dr.EmployeeName)
        dict.Add("[startdate]", dr.StartDate)
        dict.Add("[enddate]", dr.EndDate)
        dict.Add("[timeofftype]", dr.AccountTimeOffType)
        dict.Add("[daysoff]", dr.DayOff)
        dict.Add("[hoursoff]", dr.HoursOff)
        dict.Add("[status]", "Approved")
        dict.Add("[comments]", dr.Comments)
        dict.Add("[approvedby]", drAccountEmployee.FirstName + " " + drAccountEmployee.LastName)
        Return dict
    End Function
    Public Sub SendApprovedTimeOff(ByVal AccountEmployeeTimeOffRequestId As Guid)
        Try
            Dim dt As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovedEmailDataTable = Me.GetApprovedTimeOffForEmail(AccountEmployeeTimeOffRequestId)
            Dim dr As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovedEmailRow

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                EMailUtilities.SendEMail("Your time off has been approved", "TimeOffApprovedTemplate", GetPreparedEMailMessageForApprovedTimeOff(dr), dr.EMailAddress, dr.EmployeeName, , EMailUtilities.TIME_OFF_APPROVED_NOTIFICATION_INFORMATION_FROM)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SendTimeOffApprovedEMail(ByVal AccountEmployeeTimeOffRequestId As Guid)
        SendApprovedTimeOff(AccountEmployeeTimeOffRequestId)
        EMailUtilities.DequeueEmail()
    End Sub
    Public Function GetPreparedEMailMessageForRejectedTimeOff(ByVal dr As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRejectedEmailRow) As StringDictionary
        Dim drAccountEmployee As AccountEmployee.AccountEmployeeRow
        Dim objAccountEmployee As New AccountEmployeeBLL
        drAccountEmployee = objAccountEmployee.GetAccountEmployeesByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId).Rows(0)
        Dim dict As New StringDictionary
        dict.Add("[employeename]", dr.EmployeeName)
        dict.Add("[startdate]", dr.StartDate)
        dict.Add("[enddate]", dr.EndDate)
        dict.Add("[timeofftype]", dr.AccountTimeOffType)
        dict.Add("[daysoff]", dr.DayOff)
        dict.Add("[hoursoff]", dr.HoursOff)
        dict.Add("[status]", "Rejected")
        dict.Add("[comments]", dr.Comments)
        dict.Add("[rejectedby]", drAccountEmployee.FirstName + " " + drAccountEmployee.LastName)
        Return dict
    End Function
    Public Sub SendRejectedTimeOff(ByVal AccountEmployeeTimeOffRequestId As Guid)
        Try
            Dim dt As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRejectedEmailDataTable = Me.GetRejectedTimeOffForEmail(AccountEmployeeTimeOffRequestId)
            Dim dr As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRejectedEmailRow

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                EMailUtilities.SendEMail("Your time off has been rejected", "TimeOffRejectedTemplate", GetPreparedEMailMessageForRejectedTimeOff(dr), dr.EMailAddress, dr.EmployeeName, , EMailUtilities.TIME_OFF_REJECTED_NOTIFICATION_INFORMATION_FROM)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SendTimeOffRejectedEMail(ByVal AccountEmployeeTimeOffRequestId As Guid)
        SendRejectedTimeOff(AccountEmployeeTimeOffRequestId)
        EMailUtilities.DequeueEmail()
    End Sub
    Public Function ImportTimeOff(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal HoursOff As Double, ByVal StartDate As DateTime, _
                ByVal EndDate As DateTime, ByVal Description As String, ByVal DayOff As Double, ByVal AccountProjectId As Integer, _
                ByVal AccountEmployeeTimeOffRequestId As Guid, ByVal Approved As Boolean, ByVal TimeEntryDate As Date, ByVal TotalTime As Double, ByVal Submitted As Boolean) As Boolean

        Dim dtTimeOffType As AccountTimeOffType.AccountTimeOffTypeDataTable = TimeOffTypeAdapter.GetDataByAccountTimeOffTypeId(AccountTimeOffTypeId)
        Dim drTimeOffType As AccountTimeOffType.AccountTimeOffTypeRow = dtTimeOffType.Rows(0)

        If dtTimeOffType.Rows.Count > 0 Then
            drTimeOffType = dtTimeOffType.Rows(0)
            If drTimeOffType.IsTimeOffRequestRequired = True Then
                AddAccountEmployeeTimeOffRequest(AccountId, AccountEmployeeId, AccountTimeOffTypeId, HoursOff, StartDate, EndDate, Description, DayOff, AccountProjectId)
            Else
                ''Dim HoursPerDay = DBUtilities.GetHoursPerDay
                ''Me.InsertDefaultTimeEntryTimeOff(AccountEmployeeId, AccountTimeOffTypeId, TotalTime, TimeEntryDate, TimeEntryDate, Description, System.Guid.Empty, Approved, AccountProjectId, TotalTime)
                Dim TimeEntryBll As New AccountEmployeeTimeEntryBLL
                'TimeEntryBll.AddAccountEmployeeTimeEntryForImportExport(AccountEmployeeId, TimeEntryDate, "", "", TotalTime, AccountProjectId, 0, Description, Approved, Now.Date, Now.Date, 0, True, 0, 0, "", TimeEntryDate, TimeEntryDate, System.Guid.Empty, False, False)
                SetPeriodDataByAccountEmployeeIdAndTimeEntryDate(AccountEmployeeId, TimeEntryDate)
                Dim Time As Double = TotalTime
                TimeEntryBll.AddAccountEmployeeTimeEntry(AccountEmployeeId, TimeEntryDate, Nothing, Nothing, Time, AccountProjectId, 0, Description, Approved, Now, Now, 0, Submitted, 0, 0, TimesheetPeriodTypeTS, PeriodStartDateTS, PeriodEndDateTS, AccountEmployeeTimeEntryPeriodIdTS, True, AccountTimeOffTypeId, AccountEmployeeTimeOffRequestId, System.Guid.Empty, 0)
                'TimeEntryBLL.AddAccountEmployeeTimeEntry(AccountEmployeeId, TimeEntryDate, Nothing, Nothing, TotalHours, AccountProjectId, 0, Description, Approved, Now, Now, 0, True, 0, 0, TimesheetPeriodTypeTS, PeriodStartDateTS, PeriodEndDateTS, AccountEmployeeTimeEntryPeriodIdTS, True, AccountTimeOffTypeId, AccountEmployeeTimeOffRequestId, System.Guid.Empty)
            End If
        End If
    End Function
End Class
