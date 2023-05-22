<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FabricQualities.ascx.cs" Inherits="iKandi.Web.FabricQualities" %>
 
 <div class="form_box">
 <div class="form_heading">
        Registered Fabric Qualities
 </div>
 <br />
 <div>
        <asp:HiddenField ID="hdnPagesize" runat="server" />
        <asp:HiddenField ID="hdnPageIndex" runat="server" />
        <input type="hidden" id="hdnpageindex" name="hdnpageindex" />
        <input type="hidden" id="hdnpagesize" name="hdnpagesize" />
    <asp:GridView ID="grdRegistered" runat="server" AutoGenerateColumns="false" CssClass="item_list fixed-header" AllowPaging="true" OnPageIndexChanging="grdRegistered_OnPageIndexChanging" OnRowDataBound="grdRegistered_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Trade Name">
                <ItemTemplate>
                   <asp:HyperLink ID="hlkFabric" runat="server" title="CLICK TO VIEW FABRIC QUALITIES FORM" target="FabricQuality" >
                   <asp:Label runat="server" ID="lblFabric" Text='<%# (Eval("fabric") == DBNull.Value) ? "" : (Eval("fabric")).ToString()%>'></asp:Label></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Identification">
                <ItemTemplate>
                     <%# (Eval("Identification") == DBNull.Value) ? "" : (Eval("Identification")).ToString()%>
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Supplier Name">
                <ItemTemplate>
                     <%# (Eval("Suppliername") == DBNull.Value) ? "" : (Eval("Suppliername")).ToString()%>
                </ItemTemplate>
            </asp:TemplateField>                           
        </Columns>
        <EmptyDataTemplate>
            <label>
                NO RECORD FOUND
            </label>
        </EmptyDataTemplate>
    </asp:GridView>
</div>
</div>

<br />
 
 <div class="form_box">
 <div class="form_heading">
        Unregistered Fabric Qualities
 </div>
 <br />
 <div>
        <asp:HiddenField ID="hdnPagesize1" runat="server" />
        <asp:HiddenField ID="hdnPageIndex2" runat="server" />
        <input type="hidden" id="hdnpageindex1" name="hdnpageindex" />
        <input type="hidden" id="hdnpagesize2" name="hdnpagesize" />   
    <asp:GridView ID="grdUnRegistered" runat="server" AutoGenerateColumns="false" CssClass="item_list fixed-header" AllowPaging="true" OnPageIndexChanging="grdUnRegistered_OnPageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Trade Name">
                <ItemTemplate>
                    <%# (Eval("fabric") == DBNull.Value) ? "" : (Eval("fabric")).ToString()%>
                </ItemTemplate>
            </asp:TemplateField>                
        </Columns>
        <EmptyDataTemplate>
            <label>
                NO RECORD FOUND
            </label>
        </EmptyDataTemplate>
    </asp:GridView>
</div>
</div>