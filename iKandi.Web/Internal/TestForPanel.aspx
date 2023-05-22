<%@ Page Title="" Language="C#" MasterPageFile="~/layout/Secure.Master" AutoEventWireup="true" CodeBehind="TestForPanel.aspx.cs" Inherits="iKandi.Web.Internal.TestForPanel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">

<a href="QC.aspx?OrderId=5698&OrderDetailID=10921&InspectionQId=1"> INLINE Task</a><br />
<a href="QC.aspx?OrderId=5319&OrderDetailID=11001&InspectionQId=2"> MID Task New</a> <br />
<a href="QC.aspx?OrderId=5718&OrderDetailID=10849&InspectionQId=3"> Final Task</a> <br />
<a href="QC.aspx?OrderId=5403&OrderDetailid=10901&InspectionQId=4"> Online Task</a><br />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_main_content" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
           <ContentTemplate>
               <asp:FileUpload ID="fileUploadImage" runat="server"></asp:FileUpload>
               <asp:Button ID="btnUpload" runat="server" Text="Upload Image" OnClick="btnUpload_Click" />
               <br />
               <asp:Button ID="btnProcessData" runat="server" Text="Process Data" OnClick="btnProcessData_Click" /><br />
               <asp:Label ID="lblMessage" runat="server" Text="Image uploaded successfully." Visible="false"></asp:Label><br />
               <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                   <ProgressTemplate>
                       Please wait image is getting uploaded....
                   </ProgressTemplate>
               </asp:UpdateProgress>
               <br />
               <b>Please view the below image uploaded</b><br />
               <asp:Image ID="img" runat="server" Width="100" Height="100" ImageAlign="Middle" />
           </ContentTemplate>
           <Triggers>
               <asp:PostBackTrigger ControlID="btnUpload"  />
               <asp:AsyncPostBackTrigger ControlID="btnProcessData" />
           </Triggers>
</asp:UpdatePanel>
</asp:Content>
