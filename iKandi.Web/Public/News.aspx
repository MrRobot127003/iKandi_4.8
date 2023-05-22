<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="iKandi.Web.News"
    MasterPageFile="~/layout/Public.Master" %>

<asp:Content ContentPlaceHolderID="cph_main_content" runat="server">
    <div id="banner_cor">
        <div id="holder4">
        </div>
        <div id="lnk_title">
            news archive</div>
        <div id="text">
            <h2>
                Proposed factory at Noida Phase II</h2>
            <a href="../App_Themes/ikandi/images/factory_m.jpg" title="New Factories 3D Layout" class="thickbox">
                <img src="../App_Themes/ikandi/images/factory_s.jpg" alt="New Factory" width="340"
                    height="158" /></a><br />
            <span class="caption">New Factories 3D Layout</span><br />
            <br />
            As a part of our business growth and to provide a larger manufacturing capacity,
            the company has recently bought 6,000 sq meters of land in the prime industrial
            estate in Noida, India. The total built up area will be 120,000 sq ft housing over
            1800 machines. This will give an additional capacity of over 500,000 fashion garments
            to our clientele.</div>
        <div id="subtext">
            <a class="activate" href="#" onclick="changeActiveStates(this); sp2.showPanel('ex2_p1'); return false;"
                id="a1">Sep '09</a><br>
            <a href="#" id="a2">Aug '09</a><br>
            <a href="#" id="a3">Jul '09</a><br>
            <a href="#" id="a4">Jan '09</a><br>
        </div>
    </div>
</asp:Content>
