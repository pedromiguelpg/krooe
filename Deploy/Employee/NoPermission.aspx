<%@ page language="VB" masterpagefile="~/Masters/MasterPageEmployee.master" autoeventwireup="false" inherits="Employee_NoPermission, App_Web_pv0uxbk0" title="TimeLive - Page Access Denied" enableviewstatemac="false" enableEventValidation="false" theme="SkinFile" viewStateEncryptionMode="Never" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <div style="text-align: center">
        <table width="458">
            <tr>
                <td style="width: 458px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text='"You do not have access to this page"'></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>

