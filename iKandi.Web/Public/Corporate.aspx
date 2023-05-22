<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Corporate.aspx.cs" Inherits="iKandi.Web.Corporate"  MasterPageFile="~/layout/Public.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main_content" runat="Server">
<script type="text/javascript" src="../js/panelslide.js"></script>

<div id="banner_cor">
            	<div id="holder1"/>
            	<div id="lnk_title">Corporate</div>
				<div tabindex="0" class="SlidingPanels" id="text" style="overflow: hidden;">
					<div class="SlidingPanelsContentGroup" style="left: 0px; top: 0px;">
						<div class="SlidingPanelsContent p1 SlidingPanelsCurrentPanel" id="ex2_p1">“i kandi is a young dynamic fashion company based in London. The company has over 30 years of experience in manufacturing and designing Womenswear. Our clientele include high street retailers in the UK and Europe”</div>
						<div class="SlidingPanelsContent p2" id="ex2_p2"> 
						  <h1>Design / Sampling</h1>
						  We have a strong and experienced team of designers based in our London showroom. Our designers are in constant contact with the retailers, thus ensuring the latest fashion trends and must haves being presented to our clients on a weekly basis. This being one of the reasons why IKANDI has been so successful supplying “Best Sellers” for the past years to their clients. 
						  <p>The design team works closely with Print studios in the UK. Guarantying our clients the latest print artwork and thus giving them the complete copyright for that particular print or design.						    </p>
						  <p>Working closely with our design team are 7 pattern masters and 35 tailors at our overseas office in India. Thus ensuring quick turnaround from sketch to sample. We currently have a capacity of more than 150 samples a week.</p>
					  </div>
						<div class="SlidingPanelsContent p3" id="ex2_p3"><h1>Sales / Technical</h1>
i kandi has a large in-house sales and technical team, based in the factories and in the UK, liaising on a daily basis with the retailer’s technical team to ensure the highest standards of quality and durability are consistently maintained.					      
<p>Our technical team based in London works very closely with the client’s buying and technical department ensuring the factory standards are improved constantly. </p>
					  </div>
						<div class="SlidingPanelsContent p4" id="ex2_p4"><h1>Production</h1>
All our manufacturing is currently done in India, with few accessories manufactured in China. We owning the factories ensure we have a quick leadtime for our customers. We are currently averaging 8-10 weeks landed deliveries into the UK from the date of order.						    
<p>We manufacture both woven and knits, for Womenswear and Kids wear. Our factories are approved by the leading retailers on the UK high street, ITS and Bureau Veritas. Our production capacity is over 500,000 garments per month, which will be increased to 1,200,000 garments per month by October 2010 due to the purchase of land and construction of 3 high tech modern factories.</p>
					  </div>		
						<div class="SlidingPanelsContent p5" id="ex2_p5"><h1>Logistics / Processing</h1>
Over 30 years of working with one of the biggest freight forwarding companies ensures priority deliveries from the factory to the client’s warehouse. Our logistics department based at our head office liaises with the freight companies on a daily basis thus guarantying quick turnaround in custom clearance, priority flights and vessels for our product. If required, we can deliver goods into our client’s warehouse within 36 hours of leaving the factory.		    
<p>We also provide processing facilities for our client’s in the UK, which is based in Northampton and processes over 8,000 garments a day. This facility has been approved and used by the top retailers in the UK.</p>
					  </div>
						<div class="SlidingPanelsContent p5" id="ex2_p6"><h1>Outsourcing Office</h1>i kandi has their own outsourcing office for fabric, trims, and accessories in Shanghai and are constantly developing product from the Far East. We are currently importing 30% of the total printed / dyed fabric from China and manufacturing in our factories in India. This gives our clients the added benefits of embellishment options on Chinese fabrics.</div>
					  <div class="SlidingPanelsContent p5" id="ex2_p7"><h1>Customer Service</h1>
“Customer is always right”... is the quote we believe in and always look forward to getting feedback from our clients. This helps us improve our service to be better than our competition.</div>
						<div class="SlidingPanelsContent p5" id="ex2_p8"><h1>Finance</h1>ikandi because of its partnership with the factories and banks has the versatility of doubling its turnover over a very short time. Because of our strong financial position as a company, our clients can rest assured after they place an order with us.</div>																		
					</div>
				</div>
				<div id="subtext">We as a company believe in fast fashion turnaround, therefore we supply our customers with the latest catwalk trends.
				  <p>
				<a id="a1" onclick="changeActiveStates(this); sp2.showPanel('ex2_p1'); return false;" href="#" class="activate">Overview</a><br/>   
                <a id="a2" onclick="changeActiveStates(this); sp2.showPanel('ex2_p2'); return false;" href="#">Design / Sampling</a><br/>
				<a id="a3" onclick="changeActiveStates(this); sp2.showPanel('ex2_p3'); return false;" href="#">Sales / Technical</a><br/>
				<a id="a4" onclick="changeActiveStates(this); sp2.showPanel('ex2_p4'); return false;" href="#">Production</a><br/>
				<a id="a5" onclick="changeActiveStates(this); sp2.showPanel('ex2_p5'); return false;" href="#">Logistics / Processing</a><br/>
				<a id="a6" onclick="changeActiveStates(this); sp2.showPanel('ex2_p6'); return false;" href="#">Outsourcing Office</a><br/>
				<a id="a7" onclick="changeActiveStates(this); sp2.showPanel('ex2_p7'); return false;" href="#">Customer Service</a><br/>
				<a id="a8" onclick="changeActiveStates(this); sp2.showPanel('ex2_p8'); return false;" href="#">Finance</a>																
				</p>
		    	</div>
	  	  </div>
</asp:Content>
