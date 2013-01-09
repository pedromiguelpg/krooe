<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountPartyDepartmentList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountPartyDepartmentList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountPartyDepartmentId"
            DataSourceID="dsAccountpartyDepartmentGridViewObject" SkinID="xgridviewSkinEmployee" Caption='<%# ResourceHelper.GetFromResource("Client Department List") %>' Width="98%">
            <Columns>
                <asp:BoundField DataField="AccountPartyDepartmentId" HeaderText="<%$ Resources:TimeLive.Web, Id %>"
                    InsertVisible="False" ReadOnly="True" SortExpression="AccountPartyDepartmentId" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                </asp:BoundField>
                <asp:TemplateField SortExpression="PartyDepartmentCode">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("PartyDepartmentCode") %>' __designer:wfdid="w28"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton1" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Code") %>' CommandArgument="DepartmentCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("PartyDepartmentCode") %>' __designer:wfdid="w27"></asp:Label>
</itemtemplate>
                    <itemstyle width="28.66%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="PartyDepartmentName">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("PartyDepartmentName") %>' __designer:wfdid="w31"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton2" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Name") %>' CommandArgument="DepartmentName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("PartyDepartmentName") %>' __designer:wfdid="w30"></asp:Label>
</itemtemplate>
                    <itemstyle width="28.66%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="PartyDepartmentLocation">
                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("PartyDepartmentLocation") %>' __designer:wfdid="w34"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Location") %>' CommandArgument="Location" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("PartyDepartmentLocation") %>' __designer:wfdid="w33"></asp:Label>
</itemtemplate>
                    <itemstyle width="28.66%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Web, Edit_text %>" SelectText="Edit" ShowSelectButton="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" cssclass="edit_button" />
                </asp:CommandField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Web, Delete_text %>" ShowDeleteButton="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" cssclass="delete_button" />
                </asp:CommandField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountpartyDepartmentGridViewObject" runat="server"
            DeleteMethod="DeleteAccountPartyDepartment" InsertMethod="AddAccountPartyDepartment"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueDataByAccountPartyId"
            TypeName="AccountPartyDepartmentBLL" UpdateMethod="UpdateAccountPartyDepartment">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPartyDepartmentId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountPartyId" Type="Int32" />
                <asp:Parameter Name="PartyDepartmentCode" Type="String" />
                <asp:Parameter Name="PartyDepartmentName" Type="String" />
                <asp:Parameter Name="PartyDepartmentLocation" Type="String" />
                <asp:Parameter Name="Original_AccountPartyDepartmentId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountPartyId" QueryStringField="AccountPartyId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountPartyId" Type="Int32" />
                <asp:Parameter Name="PartyDepartmentCode" Type="String" />
                <asp:Parameter Name="PartyDepartmentName" Type="String" />
                <asp:Parameter Name="PartyDepartmentLocation" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountPartyDepartmentFormViewObject" runat="server"
            DeleteMethod="DeleteAccountPartyDepartment" InsertMethod="AddAccountPartyDepartment"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByAccountPartyDepartmentId"
            TypeName="AccountPartyDepartmentBLL" UpdateMethod="UpdateAccountPartyDepartment">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPartyDepartmentId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:QueryStringParameter DefaultValue="" Name="AccountPartyId" QueryStringField="AccountPartyId"
                    Type="Int32" />
                <asp:Parameter Name="PartyDepartmentCode" Type="String" />
                <asp:Parameter Name="PartyDepartmentName" Type="String" />
                <asp:Parameter Name="PartyDepartmentLocation" Type="String" />
                <asp:Parameter Name="Original_AccountPartyDepartmentId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountPartyDepartmentId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="AccountPartyId" QueryStringField="AccountPartyId"
                    Type="Int32" />
                <asp:Parameter Name="PartyDepartmentCode" Type="String" />
                <asp:Parameter Name="PartyDepartmentName" Type="String" />
                <asp:Parameter Name="PartyDepartmentLocation" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountPartyDepartmentId"
            DataSourceID="dsAccountPartyDepartmentFormViewObject" DefaultMode="Insert" SkinID="formviewSkinEmployee"
            Width="450px">
            <EditItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <td class="caption" colspan="2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Department Information") %>' /></td>
                    </tr>
                    <tr>
                        <td class="formviewsubheader" colspan="2">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Department") %>' /></td>
                    </tr>
                    <tr>
                        <td class="formviewlabelcell" style="width: 40%" align="right">
                            <span class="reqasterisk">*</span> 
                            
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="PartyDepartmentCodeTextBox">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Code:") %>' /></asp:Label></td>
                        <td style="width: 60%">
                            <asp:TextBox ID="PartyDepartmentCodeTextBox" runat="server" Text='<%# Bind("PartyDepartmentCode") %>' Width="120px" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PartyDepartmentCodeTextBox"
                                CssClass="ErrorMessage" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="formviewlabelcell" style="width: 40%" align="right">
                            <span class="reqasterisk">*</span> 
                            
<asp:Label ID="Label5" runat="server" AssociatedControlID="PartyDepartmentNameTextBox">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Name:") %>' /></asp:Label></td>
                        <td style="width: 60%">
                            <asp:TextBox ID="PartyDepartmentNameTextBox" runat="server" Text='<%# Bind("PartyDepartmentName") %>' Width="250px" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PartyDepartmentNameTextBox"
                                CssClass="ErrorMessage" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="formviewlabelcell" style="width: 40%" align="right" valign="top">
                            
<asp:Label ID="Label6" runat="server" AssociatedControlID="PartyDepartmentLocationTextBox">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Location:") %>' /></asp:Label></td>
                        <td style="width: 60%;">
                            <asp:TextBox ID="PartyDepartmentLocationTextBox" runat="server" Text='<%# Bind("PartyDepartmentLocation") %>' Height="22px" Width="250px" MaxLength="200"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formviewlabelcell" style="width: 40%" align="right">
                        </td>
                        <td style="width: 60%;">
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Web, Update_text%> " Width="68px" />&nbsp;<asp:Button
                                ID="btnCancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Web, Cancel_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <td class="caption" colspan="2">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Department Information") %>' /></td>
                    </tr>
                    <tr>
                        <td class="formviewsubheader" colspan="2">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Department") %>' /></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 40%">
                            <span class="reqasterisk">*</span> 
                            
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="PartyDepartmentCodeTextBox">
                            <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Code:") %>' /></asp:Label></td>
                        <td style="width: 60%">
                            <asp:TextBox ID="PartyDepartmentCodeTextBox" runat="server" Text='<%# Bind("PartyDepartmentCode") %>' Width="120px" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PartyDepartmentCodeTextBox"
                                CssClass="ErrorMessage" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 40%">
                            <span class="reqasterisk">*</span> 
                            
<asp:Label ID="Label4" runat="server" AssociatedControlID="PartyDepartmentNameTextBox">
                            <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Name:") %>' /></asp:Label></td>
                        <td style="width: 60%">
                            <asp:TextBox ID="PartyDepartmentNameTextBox" runat="server" Text='<%# Bind("PartyDepartmentName") %>' Width="250px" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PartyDepartmentNameTextBox"
                                CssClass="ErrorMessage" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 40%">
                            
<asp:Label ID="Label7" runat="server" AssociatedControlID="PartyDepartmentLocationTextBox">
                            <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Location:") %>' /></asp:Label></td>
                        <td style="width: 60%">
                            <asp:TextBox ID="PartyDepartmentLocationTextBox" runat="server" Text='<%# Bind("PartyDepartmentLocation") %>' Height="22px" Width="250px" MaxLength="200"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 40%">
                        </td>
                        <td style="width: 60%">
                            <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Web, Add_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountPartyDepartmentId:
                <asp:Label ID="AccountPartyDepartmentIdLabel" runat="server" Text='<%# Eval("AccountPartyDepartmentId") %>'>
                </asp:Label><br />
                AccountPartyId:
                <asp:Label ID="AccountPartyIdLabel" runat="server" Text='<%# Bind("AccountPartyId") %>'>
                </asp:Label><br />
                PartyDepartmentCode:
                <asp:Label ID="PartyDepartmentCodeLabel" runat="server" Text='<%# Bind("PartyDepartmentCode") %>'>
                </asp:Label><br />
                PartyDepartmentName:
                <asp:Label ID="PartyDepartmentNameLabel" runat="server" Text='<%# Bind("PartyDepartmentName") %>'>
                </asp:Label><br />
                PartyDepartmentLocation:
                <asp:Label ID="PartyDepartmentLocationLabel" runat="server" Text='<%# Bind("PartyDepartmentLocation") %>'>
                </asp:Label><br />
            </ItemTemplate>
        </asp:FormView>
        &nbsp;
    </ContentTemplate>
</asp:UpdatePanel>
