<%@ control language="VB" autoeventwireup="false" inherits="Menus_Controls_ctlAccountAdminSiteMenu, App_Web_wnfztccx" enableviewstate="False" %>
             <br /><div id="navigation" style="position: static;">
                <ul><li><asp:HyperLink runat="server" ID="H" NavigateUrl="~/Employee/Default.aspx"><asp:Literal ID="L1" runat="server" Text="<%$ Resources:TimeLive.Web, Home%> " /></asp:HyperLink></li>
                    <asp:Repeater runat="server" ID="R" DataSourceID="SiteMapDataSource1" EnableViewState="False">
                        <ItemTemplate>
                            <li><asp:HyperLink ID="H" runat="server" NavigateUrl='<%# Eval("Url") %>'><%#EncodeMenuTitle(Eval("Title"))%></asp:HyperLink>                                <asp:Repeater ID="R" runat="server" DataSource='<%# CType(Container.DataItem, SiteMapNode).ChildNodes %>'>
                                    <HeaderTemplate><ul></HeaderTemplate>
                                    
                                    <ItemTemplate><li><asp:HyperLink ID="H" runat="server" NavigateUrl='<%# EncodeMenuURL(Eval("Url"), Eval("Title")) %>'><%# EncodeMenuTitle(Eval("Title")) %></asp:HyperLink></li></ItemTemplate>
                                    
                                    <FooterTemplate></ul></FooterTemplate>
                                </asp:Repeater>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false" />
            </div>