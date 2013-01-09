<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTimeBillingWorksheet.ascx.vb" Inherits="ProjectAdmin_Controls_ctlTimeBillingWorksheet" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table  style="width: 550px" class="xFormView">
            <tr>
                <td class="caption" colspan="2">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Web, Time Billing Worksheet%> " /></td>
            </tr>
            <tr>
                <td class="FormViewSubHeader" colspan="2" style="height: 21px;">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Web, Search Parameters%> " /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%;">
                    <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Web, Client Name%> " />:</td>
                <td style="width: 60%;">
                    &nbsp;<asp:DropDownList ID="ddlClients" runat="server" AppendDataBoundItems="True" DataSourceID="dsClientsObject"
                        DataTextField="PartyName" DataValueField="AccountPartyId" Width="186px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Web, Alls%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%;">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Web, Project%> " />:</td>
                <td style="width: 60%;">
                    &nbsp;<asp:DropDownList ID="ddlProjects" runat="server" AppendDataBoundItems="True"
                        DataTextField="ProjectName" DataValueField="AccountProjectId" Width="186px" DataSourceID="dsProjectsObject">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Web, Alls%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%;">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Web, Project Tasks%> " />:</td>
                <td style="width: 60%;">
                    &nbsp;<asp:DropDownList ID="ddlProjectTasks" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsProjectTaskObject" DataTextField="TaskName" DataValueField="AccountProjectTaskId" Width="186px">
                        <asp:ListItem Selected="True" Value="0"></asp:ListItem>
                    </asp:DropDownList><br />
                    <aspToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="ProjectTasks"
                        LoadingText="Loading" ParentControlID="ddlProjects" PromptText="<%$ Resources:TimeLive.Web, Select Project Tasks%> "
                        ServiceMethod="GetAccountProjectTasksForInvoice" ServicePath="~/Services/ProjectService.asmx"
                        TargetControlID="ddlProjectTasks">
                    </aspToolkit:CascadingDropDown>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Web, Billed%> " />:</td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlBilled" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label3" runat="server" Text="<%$ Resources:TimeLive.Web, Both%> "></asp:ListItem>
                        <asp:ListItem Value="1" Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Web, Billed%> "></asp:ListItem>
                        <asp:ListItem Value="0" Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Web, Not Billed%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%;">
                    <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Web, Include Date Range%> " />:</td>
                <td style="width: 60%;">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Web, Start Date%> " />:</td>
                <td style="width: 60%">
                    &nbsp;<ew:CalendarPopup ID="StartDate" runat="server" SkinId="DatePicker">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Web, End Date%> " />:</td>
                <td style="width: 60%">
                    &nbsp;<ew:CalendarPopup ID="EndDate" runat="server" SkinId="DatePicker">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%;">
                </td>
                <td style="width: 60%;">
                    &nbsp;<asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="<%$ Resources:TimeLive.Web, Show_text%> " Width="68px" /></td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsProjectsObject" runat="server" DeleteMethod="DeleteAccountProject" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsForGridView" TypeName="AccountProjectBLL"
            UpdateMethod="UpdateProjectDescription" InsertMethod="AddAccountProject">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="False" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="IsTemplate" Type="Boolean" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTypeId" Type="Int32" />
                <asp:Parameter Name="AccountClientId" Type="Int32" />
                <asp:Parameter Name="AccountPartyContactId" Type="Int32" />
                <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
                <asp:Parameter Name="ProjectBillingTypeId" Type="Int32" />
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="Deadline" Type="DateTime" />
                <asp:Parameter Name="ProjectStatusId" Type="Int32" />
                <asp:Parameter Name="LeaderEmployeeId" Type="Int32" />
                <asp:Parameter Name="ProjectManagerEmployeeId" Type="Int32" />
                <asp:Parameter Name="TimeSheetApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="ExpenseApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="EstimatedDuration" Type="Int32" />
                <asp:Parameter Name="EstimatedDurationUnit" Type="String" />
                <asp:Parameter Name="ProjectCode" Type="String" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" />
                <asp:Parameter Name="IsTemplate" Type="Boolean" />
                <asp:Parameter Name="IsProject" Type="Boolean" />
                <asp:Parameter Name="AccountProjectTemplateId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsProjectTaskObject" runat="server" DeleteMethod="DeleteAccountProjectType" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAssignedProjectTasksFromvueAccountProjectTask" TypeName="AccountProjectTaskBLL"
            UpdateMethod="UpdateAccountProjectTaskUpdateInformation">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="TaskName" Type="String" />
                <asp:Parameter Name="TaskDescription" Type="String" />
                <asp:Parameter Name="AccountTaskTypeId" Type="Int32" />
                <asp:Parameter Name="Duration" Type="Int32" />
                <asp:Parameter Name="DurationUnit" Type="String" />
                <asp:Parameter Name="CompletedPercent" Type="Int32" />
                <asp:Parameter Name="Completed" Type="Boolean" />
                <asp:Parameter Name="DeadlineDate" Type="DateTime" />
                <asp:Parameter Name="TaskStatusId" Type="Int32" />
                <asp:Parameter Name="AccountPriorityId" Type="Int32" />
                <asp:Parameter Name="IsForAllEmployees" Type="Boolean" />
                <asp:Parameter Name="IsParentTask" Type="Boolean" />
                <asp:Parameter Name="IsReOpen" Type="Boolean" />
                <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="EstimatedCost" Type="Double" />
                <asp:Parameter Name="EstimatedTimeSpent" Type="Double" />
                <asp:Parameter Name="EstimatedTimeSpentUnit" Type="String" />
                <asp:Parameter Name="IsBillable" Type="Boolean" />
                <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="TaskCode" Type="String" />
                <asp:Parameter Name="IsForAllProjectTask" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlProjects" DefaultValue="0" Name="AccountProjectId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Completed" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsClientsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountPartiesByAccountId" TypeName="AccountPartyBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="xgridviewSkinEmployee" DataSourceID="dsTimeBillingWorksheetObject" Caption='<%# ResourceHelper.GetFromResource("Time Billing Worksheet") %>' Width="98%" DataKeyNames="AccountEmployeeTimeEntryId" AllowSorting="True" ShowFooter="True" OnDataBound="GridView1_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Web, Date %>" SortExpression="TimeEntryDate">
                    <edititemtemplate>
<asp:Label id="Label15" runat="server" Text='<%# Eval("TimeEntryDate", "{0:d}") %>' __designer:wfdid="w54"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Date") %>' CommandArgument="TimeEntryDate" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("TimeEntryDate", "{0:d}") %>' __designer:wfdid="w55"></asp:Label> 
</itemtemplate>
                    <itemstyle width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="EmployeeName">
                    <edititemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Eval("EmployeeName") %>' __designer:wfdid="w33"></asp:Label>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Name") %>' CommandArgument="EmployeeName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label11" runat="server" Text='<%# Bind("EmployeeName") %>' __designer:wfdid="w32"></asp:Label>
</itemtemplate>
                    <itemstyle width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Web, Task / Project %>" SortExpression="ProjectName">
                    <edititemtemplate>
<asp:Label id="Label58" runat="server" Text='<%# Eval("TaskName") %>' __designer:wfdid="w37"></asp:Label><BR /><asp:Label id="Label2" runat="server" Text='<%# Eval("ProjectName") %>' __designer:wfdid="w38"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblTaskProject" runat="server" Text='<%# ResourceHelper.GetFromResource("Task / Project") %>' __designer:wfdid="w39"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("TaskName") %>' __designer:wfdid="w35"></asp:Label> <BR /><asp:Label id="Label2" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w36"></asp:Label> 
</itemtemplate>
                    <itemstyle width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Web, Invoice Details %>">
                    <edititemtemplate>
<asp:Label id="Label6" runat="server" Text="Invoice No:" __designer:wfdid="w46"></asp:Label> <asp:Label id="Label1" runat="server" Text='<%# Eval("InvoiceNumber") %>' ReadOnly="True" __designer:wfdid="w47"></asp:Label><BR /><asp:Label id="Label7" runat="server" Text="Invoice Date:" __designer:wfdid="w48"></asp:Label> <asp:Label id="Label11" runat="server" Text='<%# Eval("InvoiceDate", "{0:d}") %>' ReadOnly="True" __designer:wfdid="w49"></asp:Label><BR /><asp:Label id="Label8" runat="server" Text="PO Number:" __designer:wfdid="w50"></asp:Label> <asp:Label id="Label13" runat="server" Text='<%# Eval("PONumber") %>' ReadOnly="True" __designer:wfdid="w51"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblInvoiceDetail" runat="server" Text='<%# ResourceHelper.GetFromResource("Invoice Detail") %>' __designer:wfdid="w52"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label6" runat="server" Text="Invoice No:" __designer:wfdid="w40"></asp:Label> <asp:Label id="Label1" runat="server" Text='<%# Bind("InvoiceNumber") %>' ReadOnly="True" __designer:wfdid="w41"></asp:Label><BR /><asp:Label id="Label7" runat="server" Text="Invoice Date:" __designer:wfdid="w42"></asp:Label> <asp:Label id="Label9" runat="server" Text='<%# Bind("InvoiceDate", "{0:d}") %>' ReadOnly="True" __designer:wfdid="w43"></asp:Label><BR /><asp:Label id="Label8" runat="server" Text="PO Number:" __designer:wfdid="w44"></asp:Label> <asp:Label id="Label10" runat="server" Text='<%# Bind("PONumber") %>' ReadOnly="True" __designer:wfdid="w45"></asp:Label> 
</itemtemplate>
                    <itemstyle width="25%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <edititemtemplate>
<asp:Label id="Label9" runat="server" Text='<%# Eval("BillingRate") %>' __designer:wfdid="w54"></asp:Label>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate") %>' CommandArgument="BillingRate" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label12" runat="server" Text='<%# Bind("BillingRate") %>' __designer:wfdid="w53"></asp:Label>
</itemtemplate>
                    <itemstyle width="5%" />
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Web, Total Time %>">
                    <EditItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Eval("TotalTime", "{0:HH:mm}") %>' __designer:wfdid="w57"></asp:Label> 
</EditItemTemplate>
                    <FooterTemplate>
<asp:Label id="SumTime" runat="server" Text='<%# Bind("TotalTime") %>' __designer:wfdid="w58"></asp:Label> 
</FooterTemplate>
                        <headertemplate>
<asp:LinkButton id="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Total Time") %>' CommandArgument="TotalTime" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("TotalTime", "{0:HH:mm}") %>' __designer:wfdid="w56"></asp:Label> 
</ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" width="5%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <edititemtemplate>
<asp:CheckBox id="CheckBox1" runat="server" __designer:wfdid="w61" Checked='<%# Bind("Billed") %>'></asp:CheckBox>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblBilled" runat="server" Text='<%# ResourceHelper.GetFromResource("Billed") %>' __designer:wfdid="w62"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:CheckBox id="CheckBox1" runat="server" __designer:wfdid="w60" Checked='<%# Bind("Billed") %>' Enabled="false"></asp:CheckBox>
</itemtemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="5%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Web, Edit_text %>" ShowEditButton="True" EditImageUrl="~/Images/edit.gif" CancelImageUrl="~/Images/Cancel.gif" UpdateImageUrl="~/Images/Update.gif" >
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="5%" />
                </asp:CommandField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsTimeBillingWorksheetObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByAccountIdAndEmployeesForTimeBillingWorksheet"
            TypeName="AccountTimeExpenseBillingBLL" UpdateMethod="UpdateTimeBillingWorksheet" DeleteMethod="DeleteAccountEmployeeTimeEntry">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="55" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountClientId" Type="Int32" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter Name="TimeEntryEndDate" Type="DateTime" />
                <asp:Parameter Name="Billed" Type="String" />
                <asp:Parameter Name="IncludeDateRange" Type="Boolean" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountEmployeeTimeEntryId" Type="Int32" />
                <asp:Parameter Name="Billed" Type="Boolean" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountEmployeeTimeEntryId" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
        &nbsp;
    </ContentTemplate>
</asp:UpdatePanel>
