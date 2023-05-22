<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsLetterLinePlanC45_46.ascx.cs" Inherits="iKandi.Web.UserControls.Lists.NewsLetterLinePlanC45_46" %>

<style type="text/css">
     body{
	background:#f9f9fa;
	font-family: Verdana,Arial,sans-serif;
	margin:0px;
	padding:0px;
	font-size:10px;	
}
    
.item_list {
    text-transform: capitalize;
	
	border-collapse:collapse;
	text-align:center;
}
.item_list th {
    color: #575759 !important;
    font-family: Verdana,Arial,sans-serif;
    font-size: 10px;
    background-color: #dddfe4;
    text-transform: capitalize !important;
    border: 1px solid #b7b4b4;
    text-align: center;
    font-weight: normal;
    padding:0px;
}
.item_list th table th {
    border: none !important;
        border-right-width: medium;
        border-right-style: none;
        border-right-color: currentcolor;
    border-right:1px solid #c2b9b9 !important
	
}
.item_list td table td {
    border: 1px solid #ddd;
        border-right-width: 0px;
        border-right-style: none;
        border-right-color: currentcolor;
		border-bottom-style: none;
		color:Gray;
		text-align:left;
	
}

.item_list td {
    overflow: hidden;
    padding: 0px !important;
    border: 1px solid #b7b4b4;
    color:Gray;
    height:20px;
    width:46px;    
}  
   .empty-msg 
    {
     font-family: Helvetica;
    font-size: 12px !important;
    line-height:24px;    

    text-transform: capitalize;
    border:1px solid #ccc;
    padding:0px 10px;
   
    }   


.evenrow td
{
    background-color:#efefda;
}
.date
{
    color:Black !important; 
    background-color:#d4c9c9 !important;    
}
.IsHoliday
{
    color:Black !important; 
    background-color:#e66e68 !important; 
}
 #preview
        {
            position: absolute;
            border: 3px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
            box-shadow: 4px 4px 3px rgba(103, 115, 130, 1);
        }
        
        
</style>
<script src="../../js/jquery-1.5.2-jquery.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    //-------------------edit by prabhaker------------------//

    $(document).ready(function () {
        ShowImagePreview();
    });
    // Configuration of the x and y offsets
    function ShowImagePreview() {

        // xOffset = 350;
        // yOffset = -350;
        $("a.preview").hover(function (e) {

            this.t = this.title;
            this.title = "";
            var c = (this.t != "") ? "<br/>" + this.t : "";
            $("body").append("<p id='preview'><img src='" + this.t + "' alt='Image preview' style='height:200px !important; width:200px !important;'/>&nbsp;</p>");
            $("#preview")
            .css("top", (e.pageY) + "px")
            .css("left", (e.pageX) + "px")
            .fadeIn("slow");
        },

function () {
    this.title = this.t;
    $("#preview").remove();
});

        $("a.preview").mousemove(function (e) {
            $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
        });
    };
    //-------------------end-of-code----------------------//
    </script>
    

 <div style="text-align: center; padding:5px 0px; background-color: #405D99; 
                                color: #FFFFFF; font-weight: bold; font-size:14px; text-transform:capitalize;
                                font-family:Verdana; width:1460px; margin:0px auto;">
                                <span style="font-weight: bold;">Line Plan (C 45-46)</span>
                                </div>

    <asp:GridView ID="gvNewsLetterLinePlan" Width="1460px" 
      ShowFooter="true" ShowHeader="false" AutoGenerateColumns="false" 
        CssClass="item_list" runat="server" style="margin:0px auto; table-layout:fixed;" 
    onrowdatabound="gvNewsLetterLinePlan_RowDataBound">
    <AlternatingRowStyle CssClass="evenrow"   />
    <Columns>
    <asp:TemplateField ItemStyle-Width="50px">    
    <ItemTemplate>
        <asp:HiddenField ID="hdnLineNo" Value='<%# Eval("LineNo") %>' runat="server" />
        <asp:Label ID="lblLineNo" runat="server" Text=""></asp:Label>   
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    </asp:TemplateField>
   <%-- Day1--%>
     <asp:TemplateField>    
    <ItemTemplate>     
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day2--%>
     <asp:TemplateField>    
    <ItemTemplate>     
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />    
    </asp:TemplateField>
     <%-- Day3--%>
     <asp:TemplateField>    
    <ItemTemplate>       
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    </asp:TemplateField>
     <%-- Day4--%>
     <asp:TemplateField>    
    <ItemTemplate>       
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day5--%>
     <asp:TemplateField>    
    <ItemTemplate>       
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day6--%>
     <asp:TemplateField>    
    <ItemTemplate>       
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day7--%>
     <asp:TemplateField>    
    <ItemTemplate>      
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day8--%>
     <asp:TemplateField>    
    <ItemTemplate>
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />    
    </asp:TemplateField>
     <%-- Day9--%>
     <asp:TemplateField>    
    <ItemTemplate>       
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day10--%>
     <asp:TemplateField>    
    <ItemTemplate>      
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day11--%>
     <asp:TemplateField>    
    <ItemTemplate>        
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day12--%>
     <asp:TemplateField>    
    <ItemTemplate>         
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />  
    </asp:TemplateField>
     <%-- Day13--%>
     <asp:TemplateField>    
    <ItemTemplate>
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />    
    </asp:TemplateField>
     <%-- Day14--%>
     <asp:TemplateField>    
    <ItemTemplate>        
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>
     <%-- Day15--%>
     <asp:TemplateField>    
    <ItemTemplate>        
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    
    </asp:TemplateField>
     <%-- Day16--%>
     <asp:TemplateField>    
    <ItemTemplate>         
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day17--%>
     <asp:TemplateField>    
    <ItemTemplate>         
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day18--%>
     <asp:TemplateField>    
    <ItemTemplate>       
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    
    </asp:TemplateField>
     <%-- Day19--%>
     <asp:TemplateField>    
    <ItemTemplate>        
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day20--%>
     <asp:TemplateField>    
    <ItemTemplate>          
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
    
    </asp:TemplateField>
     <%-- Day21--%>
     <asp:TemplateField>    
    <ItemTemplate>         
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day22--%>
     <asp:TemplateField>    
    <ItemTemplate>          
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day23--%>
     <asp:TemplateField>    
    <ItemTemplate>       
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
  
    </asp:TemplateField>
     <%-- Day24--%>
     <asp:TemplateField>    
    <ItemTemplate>      
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day25--%>
     <asp:TemplateField>    
    <ItemTemplate>         
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
  
    </asp:TemplateField>
     <%-- Day26--%>
     <asp:TemplateField>    
    <ItemTemplate>       
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day27--%>
     <asp:TemplateField>    
    <ItemTemplate>        
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day28--%>
     <asp:TemplateField>    
    <ItemTemplate>         
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
   
    </asp:TemplateField>
     <%-- Day29--%>
     <asp:TemplateField>    
    <ItemTemplate>          
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />
  
    </asp:TemplateField>
     <%-- Day30--%>
     <asp:TemplateField>    
    <ItemTemplate>          
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" />   
    </asp:TemplateField>  
   
    </Columns>
    </asp:GridView>  
  <div>
      <asp:Label ID="lblStringQuery" runat="server" Text=""></asp:Label>
  </div>
   <br />
    <br />
