<%@ page language="VB" masterpagefile="~/Masters/MasterPageemployee.master" autoeventwireup="false" inherits="AccountAdmin_AccountEMailNotificationPreferences, App_Web_yaqbagu1" title="TimeLive - Email Notification Preferences" enableviewstatemac="false" enableEventValidation="false" theme="SkinFile" viewStateEncryptionMode="Never" %>

<%@ Register Src="Controls/ctlAccountEMailNotificationPreferenceList.ascx" TagName="ctlAccountEMailNotificationPreferenceList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEMailNotificationPreferenceList id="CtlAccountEMailNotificationPreferenceList1"
        runat="server">
    </uc1:ctlAccountEMailNotificationPreferenceList>
</asp:Content>

