using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using System.Data;
using System.Data.SqlClient;


namespace iKandi.BLL
{
    public class StyleController : BaseController
    {
        #region

        public StyleController()
        {
        }

        public StyleController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<Style> GetStyles()
        {
            Style s = new Style();

            List<Style> styles = new List<Style>();
            styles.Add(s);

            return styles;
        }

        public List<SamplingStatus> GetAllStyleSamplingStatus(int UserId, int ClientID, int SortBy, string Search)
        {
            List<SamplingStatus> samplingStatus = this.StyleDataProviderInstance.GetAllStyleSamplingStatus(UserId, ClientID, SortBy, Search);

            return samplingStatus;
        }

        public List<SamplingStatus> GetAllStyleSamplingStatusWithSeasonFilterBAL(int UserId, int ClientID, int SortBy, string Search, string SeasonName,string IsOwnerLoggedIn)
        {
            List<SamplingStatus> samplingStatus = this.StyleDataProviderInstance.GetAllStyleSamplingStatusDAL(UserId, ClientID, SortBy, Search, SeasonName,IsOwnerLoggedIn);

            return samplingStatus;
        }


        public Style SaveStyle(Style style, string DesignerCode, int ParentStyleid)
        {
            if (style.StyleID == -1)
            {
                // Added by Yadvendra on 06/1/2020
                int styleID = this.StyleDataProviderInstance.CreateStyle(style, DesignerCode, false, ParentStyleid, false);

                if (styleID > 0)
                {
                    style.StyleID = styleID;
                    int i = 1;
                    foreach (StyleFabric StyleFab in style.Fabrics)
                    {
                        if (StyleFab.Id == -1 && StyleFab.IsDeleted == 0)
                        {
                            StyleFab.StyleID = style.StyleID;
                            this.StyleDataProviderInstance.CreateStyleFabric(StyleFab, false, i);
                        }
                        i++;
                    }
                    this.StyleDataProviderInstance.CreateStyleRefs(style);
                }

                try
                {
                    // Initiate Workflow
                    WorkflowInstance instance = this.WorkflowControllerInstance.CreateWorkflow(-1, -1, styleID, StatusMode.SAMPLEPENDING);
                    ////WorkflowInstanceDetail task = this.WorkflowControllerInstance.CreateTask(StatusMode.SAMPLEPENDING, instance.WorkflowInstanceID, DateTime.Today);

                    //// TODO: Hardcoded
                    //task.ActionID = 1;

                    //this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);


                    //this.WorkflowControllerInstance.CreateTask(StatusMode.SAMPLESENT, instance.WorkflowInstanceID, style.ETA);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                   // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                }

                ////Send Email ASynchronously
                //if (styleID > 0)
                //{
                //    this.NotificationControllerInstance.SendCreateDesignEmail(style, true);
                //}
            }
            else
            {
                //Yaten to Delete.
              //  this.StyleControllerInstance.DeleteStyle(style.StyleID);
                this.StyleDataProviderInstance.DeleteStyleFabric2(style.StyleID);
                int i = 1;
                foreach (StyleFabric StyleFab in style.Fabrics)
                {
                    StyleFab.StyleID = style.StyleID;
                    if (StyleFab.Id == -1 && StyleFab.IsDeleted == 0)
                    {
                        this.StyleDataProviderInstance.CreateStyleFabric(StyleFab, false, i);

                    }
                    if (StyleFab.IsDeleted == 1)
                    {
                        this.StyleDataProviderInstance.DeleteStyleFabric(StyleFab);
                    }
                    if (StyleFab.Id > 0 && StyleFab.IsDeleted == 0)
                    {
                        this.StyleDataProviderInstance.UpdateStyleFabrics(StyleFab);
                    }
                    i++;
                }
                this.StyleDataProviderInstance.UpdateStyle(style);

            }

            return style;
        }

        // Added by Yadvendra on 06/01/2020
        public int SaveStyleNew(Style style, string DesignerCode, bool SaveStyleAs, int ParentStyleid, bool VisibleInMarketing)
        {          
            int bit=0;
            if (style.StyleID == -1)
            {
                // Added by Yadvendra on 06/01/2020
                int styleID = this.StyleDataProviderInstance.CreateStyle(style, DesignerCode, SaveStyleAs, ParentStyleid, VisibleInMarketing);
                if (styleID > 0)
                {
                    style.StyleID = styleID;
                    int i = 1;
                    foreach (StyleFabric StyleFab in style.Fabrics)
                    {
                        
                        if (StyleFab.Id == -1 && StyleFab.IsDeleted == 0)
                        {
                            StyleFab.StyleID = style.StyleID;
                            this.StyleDataProviderInstance.CreateStyleFabric(StyleFab, SaveStyleAs,i);
                        }
                        i++;
                    }
                    this.StyleDataProviderInstance.CreateStyleRefs(style);
                    bit = styleID;
                }
                try
                {                    
                    this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(styleID, TaskMode.STYLE_CREATED, this.LoggedInUser.UserData.UserID);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                }
               
            }
            else
            {
                // Added by Yadvendra on 06/01/2020
                style.IsMarketingVisible = VisibleInMarketing;
                this.StyleDataProviderInstance.DeleteStyleFabric2(style.StyleID);
                int i = 1;
                foreach (StyleFabric StyleFab in style.Fabrics)
                {
                    StyleFab.StyleID = style.StyleID;
                    if (StyleFab.Id == -1 && StyleFab.IsDeleted == 0)
                    {
                        this.StyleDataProviderInstance.CreateStyleFabric(StyleFab, false,i);
                    }
                    if (StyleFab.IsDeleted == 1)
                    {
                        this.StyleDataProviderInstance.DeleteStyleFabric(StyleFab);
                    }
                    if (StyleFab.Id > 0 && StyleFab.IsDeleted == 0)
                    {
                        this.StyleDataProviderInstance.UpdateStyleFabrics(StyleFab);
                    }
                    i++;
                }
                this.StyleDataProviderInstance.UpdateStyle(style);
                bit = 1;
            }
            return bit;
        }

        public Style GetStyleByStyleId(int StyleID)
        {
            Style style = new Style();
            style = this.StyleDataProviderInstance.GetStyleByStyleId(StyleID);
            style.ReferenceBlocks = this.StyleDataProviderInstance.GetStyleReferenceByStyleId(StyleID);
            style.Fabrics = this.StyleDataProviderInstance.GetStyleFabricsByStyleId(StyleID);  // Uncommnet for server                     
            return style;
        }

        public Style GetStyleByStyleId_New(int StyleID)
        {
            Style style = new Style();
            style = this.StyleDataProviderInstance.GetStyleByStyleId(StyleID);
            style.ReferenceBlocks = this.StyleDataProviderInstance.GetStyleReferenceByStyleId(StyleID);
            style.Fabrics = this.StyleDataProviderInstance.GetStyleFabricsByStyleId_New(StyleID);  // Uncommnet for server                     
            return style;
        }
        public string GetStyleByCode(int StyleID)
        {

            return this.StyleDataProviderInstance.GetStyleByCode(StyleID);
            
        }
        //Yatendra 16 March
        public DataTable GetStyleByStyleId2(string StyleID)
        {
            DataTable dt = this.StyleDataProviderInstance.GetStyleFabricsPrints(StyleID);
            return dt;
        }

        public List<StyleFabric> GetStyleByStyleId_Multiple(string StyleID)
        {
             Style style = new Style();
                style.Fabrics = new List<StyleFabric>();
                style.Fabrics = this.StyleDataProviderInstance.GetStyleFabricsMultiplePrints(StyleID);
             return style.Fabrics;
        }

        public string GetStyleNumberById(int StyleID2)
        {
            string stringStyle = this.StyleDataProviderInstance.GetStyleNumberById(StyleID2);
            return stringStyle;
        }



        public List<StyleFabric> GetStyleFabricsByStyleId(int styleId)
        {
            return this.StyleDataProviderInstance.GetStyleFabricsByStyleId(styleId);
        }

        public Style UpdateUrls(Style style)
        {
            this.StyleDataProviderInstance.UpdateUrls(style);


            //Gajendra Workflow
            this.WorkflowControllerInstance.UpdateWorkflowInstancePreOrder(style.StyleID, TaskMode.DIGITAL_UPLOADED, this.LoggedInUser.UserData.UserID);
            this.WorkflowControllerInstance.UpdateWorkflow_PatternReady(style.StyleID, TaskMode.DIGITAL_UPLOADED, this.LoggedInUser.UserData.UserID);
            // Update workflow
            //WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(style.StyleID, -1, -1);

            //if (instance != null && instance.WorkflowInstanceID > 0)
            //{
            //    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

            //    foreach (WorkflowInstanceDetail task in tasks)
            //    {
            //        if (task.StatusModeID == (int)StatusMode.SAMPLERECEIVED
            //            && task.ApplicationModule.ApplicationModuleID == (int)AppModule.STYLE_IMAGE_UPLOAD
            //            && task.AssignedToDesignation == this.LoggedInUser.UserData.Designation)
            //        {
            //            // if (tasks.Count == 1)
            //            // {
            //            this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

            //            this.WorkflowControllerInstance.CreateTask(StatusMode.COSTEDBIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(5));
            //            //}
            //            //else
            //            //{
            //            //    WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
            //            //    newTask.ActionDate = DateTime.Today;
            //            //    newTask.AssignedTo = new User();
            //            //    newTask.AssignedTo.UserID = this.LoggedInUser.UserData.UserID;
            //            //    newTask.ETA = task.ETA;
            //            //    newTask.ActionID = task.ActionID;
            //            //    newTask.StatusModeID = task.StatusModeID;
            //            //    newTask.WorkflowInstance = new WorkflowInstance();
            //            //    newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
            //            //    this.WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
            //            //}
            //        }

            //    }
            //}


            return style;
        }

        public void DeleteStyle(int StyleID)
        {
            Style objStyle = this.StyleDataProviderInstance.GetStyleByStyleId(StyleID);

            bool success = this.StyleDataProviderInstance.DeleteStyle(StyleID);

            if (success)
                this.NotificationControllerInstance.SendStyleDeletedEmail(objStyle, true);
        }

        public bool DeleteStyleRefBlock(StyleReferenceBlock StyleRef)
        {
            return this.StyleDataProviderInstance.DeleteStyleRefBlock(StyleRef);


        }
        public bool UpdateStyleRefBlock(StyleReferenceBlock StyleRef)
        {
            return this.StyleDataProviderInstance.UpdateStyleRefBlock(StyleRef);
        }
        //Yatendar 
        public void InsertFabricPrints(string fabXml)
        {
            this.StyleDataProviderInstance.InsertFabricPrints(fabXml);
        }

        //public bool UpdateStyleSampleTrackingDate(Style objStyle)
        //{
        //    return this.StyleDataProviderInstance.UpdateStyleSampleTrackingDate(objStyle);
        //}

        public Style GetStyleByStyleNumber(string StyleNumber)
        {
            return this.StyleDataProviderInstance.GetStyleByStyleNumber(StyleNumber);
        }
        public Style GetStyleByNumber_Courier(string StyleNumber)
        {
            return this.StyleDataProviderInstance.GetStyleByNumber_Courier(StyleNumber);
        }

        public Style GetStyleByStyleNumberUserSpacific(string StyleNumber, int userid)
        {
            return this.StyleDataProviderInstance.GetStyleByStyleNumberUserSpacific(StyleNumber.Trim(),userid); 
        }        

        public bool CreateStyleRefBlock(StyleReferenceBlock ReferenceBlock)
        {
            return this.StyleDataProviderInstance.CreateStyleRef(ReferenceBlock);
        }

        public bool UpdateStylesCourierReceivedOnById(int StyleID)
        {
            bool success = this.StyleDataProviderInstance.UpdateStylesCourierReceivedOnById(StyleID);

            /*
            try
            {
             

                // Update workflow
                if (StyleID != 0 && StyleID != -1)
                {
                    // Update workflow
                    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(StyleID, -1, -1);
                    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks( instance.WorkflowInstanceID);

                    foreach (WorkflowInstanceDetail task in tasks)
                    {
                        if (task.StatusModeID == (int)StatusMode.SAMPLERECEIVED
                            && task.ApplicationModule.ApplicationModuleID == (int)AppModule.DESIGN_LIST
                            && (task.AssignedToDesignation == this.LoggedInUser.UserData.Designation || this.LoggedInUser.UserData.Designation == Designation.iKandi_Design_Manager))
                        {
                            if (tasks.Count == 1)
                            {
                                this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                                this.WorkflowControllerInstance.CreateTask(StatusMode.COSTEDBIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(5));
                            }
                            else
                            {
                                WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
                                newTask.ActionDate = DateTime.Today;
                                newTask.AssignedTo = new User();
                                newTask.AssignedTo.UserID = this.LoggedInUser.UserData.UserID;
                                newTask.ETA = task.ETA;
                                newTask.ActionID = task.ActionID;
                                newTask.StatusModeID = task.StatusModeID;
                                newTask.WorkflowInstance = new WorkflowInstance();
                                newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
                                this.WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
                            }
                        }

                    }

                    //if (tasks.Count > 0 && tasks[0].StatusModeID == (int)StatusMode.SAMPLERECEIVED)
                    //{
                    //    this.WorkflowControllerInstance.CompleteTask(tasks[0], this.LoggedInUser.UserData.UserID);


                    //    this.WorkflowControllerInstance.CreateTask(StatusMode.COSTEDBIPL, instance.WorkflowInstanceID, DateTime.Today.AddDays(3));
                    //}
                }
            }
            catch (Exception ex)
            {
                this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
            */

            return success;
        }

        public bool UpdateStyleSampleStatus(SamplingStatus StyleStatus)
        {
           return  this.StyleDataProviderInstance.UpdateStyleSampleStatus(StyleStatus);
        }

        public void InsertFabricRemarksBAL(int intStyleId, string stringRemarks, string stringFileName, int UserId)
        {
            this.StyleDataProviderInstance.InsertFabricRemarksDAL(intStyleId, stringRemarks, stringFileName, UserId);
        }

        public void InsertIssueRemarksBAL(int intStyleId, string stringRemarks, int UserId)
        {
            this.StyleDataProviderInstance.InsertIssueRemarksDAL(intStyleId, stringRemarks, UserId);
        }

        public void InsertMeterageValueBAL(int intStyleId, string stringMeterage, string stringFabric)
        {
            this.StyleDataProviderInstance.InsertMeterageValueDAL(intStyleId, stringMeterage, stringFabric);
        }



        public void InsertOwnerRemarksBAL(int intStyleId, string stringRemarks, string stringFileName,string Status,string IsOwnerLoggedIn,int UserId)
        {
            this.StyleDataProviderInstance.InsertOwnerRemarksDAL(intStyleId, stringRemarks, stringFileName, Status,IsOwnerLoggedIn,UserId);
        }


        public string GetMaxStyleNumber(string Code)
        {
            return this.StyleDataProviderInstance.GetMaxStyleNumber(Code);

        }
        public List<Style> GetAllStyles(int PageSize, int PageIndex, out int TotalPageCount, int ClientId, string SearchText, string SeasonName)
        {
            return this.StyleDataProviderInstance.GetAllStyles(PageSize, PageIndex, out TotalPageCount, ClientId, SearchText, SeasonName);
        }
        public List<SamplingStatus> GetAllStylesPendingSamples(string SeasonName, int ClientID, String SearchText, int Marchent, DateTime FDate, DateTime Tdate, int DeptId, int FirstFilter, int SecondFilter, int ThirdFilter, int FourthFilter, decimal fromstatusID, decimal tostatusID, int Delay, int SortingOrder,int Criteria, int ChildDeptIDid)
        {
          return this.StyleDataProviderInstance.GetAllStylesPendingSamples(SeasonName, ClientID, SearchText, Marchent, FDate, Tdate, DeptId, FirstFilter, SecondFilter, ThirdFilter, FourthFilter, fromstatusID, tostatusID, Delay, SortingOrder,Criteria, ChildDeptIDid);
        }

        public string GetStyleRemarks(int StyleId)
        {
            return this.StyleDataProviderInstance.GetStyleRemarks(StyleId);
        }
        public bool UpdateStyleRemarks(int StyleId, string Remarks)
        {
            bool success = this.StyleDataProviderInstance.UpdateStyleRemarks(StyleId, Remarks);
            return success;
        }
        public int GetPrintIdByPrintNumber(string PrintNumber)
        {
            return this.StyleDataProviderInstance.GetPrintIdByPrintNumber(PrintNumber);
        }

        public List<Style> GetClientStyles(int ClientID)
        {
            return this.StyleDataProviderInstance.GetClientStyles(ClientID);
        }

        public DataSet GetAllStylePhotos(int StyleID, int OrderID, int OrderDetailID)
        {
            return this.StyleDataProviderInstance.GetAllStylePhotos(StyleID, OrderID, OrderDetailID);
        }

        public bool CloneStyleNumber(string parentStyleNumber, string styleNumber, int clientId, int departmentId, int costingId, string orderIDs,string selectedItemSample,int avg,int Cad,int obsheet,int sam,int ob,int cmt)
        {
            return this.StyleDataProviderInstance.CloneStyleNumber(parentStyleNumber, styleNumber, clientId, departmentId, costingId, orderIDs, selectedItemSample, avg, Cad, obsheet, sam, ob,cmt);
        }
        public bool CloneStyleNumber_New(string parentStyleNumber, string styleNumber, int clientId, int departmentId, int costingId, string orderIDs, string selectedItemSample, int avg, int Cad, int obsheet, int sam, int ob, int cmt, int userID)
        {
            return this.StyleDataProviderInstance.CloneStyleNumber_New(parentStyleNumber, styleNumber, clientId, departmentId, costingId, orderIDs, selectedItemSample, avg, Cad, obsheet, sam, ob, cmt, userID);
        }
        public bool UpdateStyleFromOrder(Style Style)
        {
            return this.StyleDataProviderInstance.UpdateStyleFromOrder(Style);
        }

        public List<Style> GetStylesByIDs(string StyleList)
        {
            return this.StyleDataProviderInstance.GetStylesByIDs(StyleList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StyleList"></param>
        /// <returns></returns>
        public List<Style> GetClient(string ClientID)
        {
           
                return this.StyleDataProviderInstance.GetClientDAL(ClientID);

        }


        public List<Style> GetNewlyCreatedStyles(DateTime CreatedOn)
        {
            return this.StyleDataProviderInstance.GetNewlyCreatedStyles(CreatedOn);
        }

        public bool CostingEnquiryUpdateStyle(string styleNumber, int StyleId, int type)
        {
            return this.StyleDataProviderInstance.CostingEnquiryUpdateStyle(styleNumber, StyleId, type);
        }

        public int CostingEnquiryUpdateStyleFromStyleNumber(string styleNumber)
        {
            return this.StyleDataProviderInstance.CostingEnquiryUpdateStyleFromStyleNumber(styleNumber);
        }

        public List<Style> CostingEnquiryGetAllStyles(int Type, int UserID)
        {
            return this.StyleDataProviderInstance.CostingEnquiryGetAllStyles(Type, UserID);
        }

        public List<Style> GetAllStyleVariations(int StyleID)
        {
            return this.StyleDataProviderInstance.GetAllStyleVariations(StyleID);
        }

        public string CheckStyleVersion(string StyleNumber)
        {
            return this.StyleDataProviderInstance.CheckStyleVersion(StyleNumber);
        }

        public string CloneStyleNumbers(List<ShowroomCosting> existingItems)
        {
            return this.StyleDataProviderInstance.CloneStyleNumbers(existingItems);
        }

        public List<ShowroomCosting> GetShowroomStyleDetails(string StyleIDs)
        {
            return this.StyleDataProviderInstance.GetShowroomStyleDetails(StyleIDs);
        }
       
        public List<ShowroomCosting> GetShowroomStyleDetails_Print(string StyleIDs)
        {
            return this.StyleDataProviderInstance.GetShowroomStyleDetails_Print(StyleIDs);
        }


        public List<ShowroomCosting> SearchShowroomStyles(int PageSize, int PageIndex, out int TotalRowCount, string ClientIDs, string DeptIDs, string GartmentType, int DateType, DateTime StartDate,
    DateTime EndDate, int IsBestSeller, double BIPLPriceFrom, double BIPLPriceTo, string TradeNames, int IsOrderPlaced, string SeasonName, Int64 ShippedQtyRange_From, Int64 ShippedQtyRange_To)
        {
            return this.StyleDataProviderInstance.SearchShowroomStyles(PageSize, PageIndex, out TotalRowCount, ClientIDs, DeptIDs, GartmentType, DateType, StartDate,
     EndDate, IsBestSeller, BIPLPriceFrom, BIPLPriceTo, TradeNames, IsOrderPlaced, SeasonName, ShippedQtyRange_From, ShippedQtyRange_To);
        }

        public bool DeleteStyleReferenceBlockById(int blockId)
        {
            return this.StyleDataProviderInstance.DeleteStyleReferenceBlockById(blockId);
        }

        public bool UpdateUrl(int StyleId, int Type)
        {
            return this.StyleDataProviderInstance.UpdateUrl(StyleId, Type);
        }

        public List<SamplingStatus> GetSampleDalayedOrToBeDispatchEmail()
        {
            List<SamplingStatus> samplingStatus = this.StyleDataProviderInstance.GetSampleDalayedOrToBeDispatchEmail();

            return samplingStatus;
        }
        public DataTable GetAllSeasonBAL()
        {
            return this.StyleDataProviderInstance.GetAllSeasonDAL();
        }
        public DataTable GetExcelReport()
        {
            return this.StyleDataProviderInstance.GetExcelReport();
        }
        public void DeleteSelectedCheckBox()
        {
            this.StyleDataProviderInstance.DeleteSelectedCheckBox();
        }
        
        public int GetGlobalType(int UserID,out int Days)
        {
            return StyleDataProviderInstance.GetGlobalType(UserID, out Days);
        }
        public DataTable GetAllMerchentDAL(int UserID) 
        {
            return this.StyleDataProviderInstance.GetAllMerchentDAL(UserID);
        }
        /// <summary>
        /// For Insert Owner Detail 4 Oct
        /// </summary>
        /// <param name="searchValue"></param>
        public void InsertOwnerSamplingBAL(string OwnerDetail)
        {
            this.StyleDataProviderInstance.InsertOwnerSamplingDAL(OwnerDetail);
        }


        public string GetOwnerSamplingBAL(int StyleId)
        {
          return  this.StyleDataProviderInstance.GetOwnerSamplingDAL(StyleId);
        }
        // Update By Ravi kumar on 11/8/15 For add style from order
        public int CloneStyleNumberByOrder(int ParentStyleID, string parentStyleNumber, string styleNumber, int clientId, int departmentId)
        {
            return this.StyleDataProviderInstance.CloneStyleNumberByOrder(ParentStyleID, parentStyleNumber, styleNumber, clientId, departmentId);
        }

        public string IsRepeatedStyle(int StyleId)
        {
            return this.StyleDataProviderInstance.IsRepeatedStyle(StyleId);
        }
        public DataSet GetAccsessoryDetails(int styleid)
        {
            return this.StyleDataProviderInstance.GetAccsessoryDetails(styleid);
        }
        public int DeleteAddACCDetails(int styleid, string AccesoriesName, string Remarks, int AccesoriesQualityID, string SIZE, double Rate, string FlagIsDelete)
        {
            return this.StyleDataProviderInstance.DeleteAddACCDetails(styleid, AccesoriesName, Remarks, AccesoriesQualityID, SIZE, Rate, FlagIsDelete);
        }
        public string GetMaxStyleCode(string Designercode)
        {
            return this.StyleDataProviderInstance.GetMaxStyleCode(Designercode);
        }
        public DataTable GetBuyerDetail(int StyleID)
        {
          return this.StyleDataProviderInstance.GetBuyerDetail(StyleID);
        }
        public bool UpdateStylesFabricDetails(int ID, string dates, int status, string flag)
        {
          return this.StyleDataProviderInstance.UpdateStylesFabricDetails(ID, dates, status, flag);
        }
        public bool UpdateBuyerStyleNumber(string SelectValue, string Styleid)
        {
            return this.StyleDataProviderInstance.UpdateBuyerStyleNumber(SelectValue, Styleid);
        }
        public bool UpdateSelectExports(string SelectValue, string Styleid, string AllSelect)
        {
            return this.StyleDataProviderInstance.UpdateSelectExports(SelectValue, Styleid, AllSelect);
        }
        public string UpdateStylesFabricStatus(int ID, string Etadate)
        {
          return this.StyleDataProviderInstance.UpdateStylesFabricStatus(ID, Etadate);
        }
        public string UpdateStylesFabricStatusActual(int ID, string Etadate, string UserId)
        {
            return this.StyleDataProviderInstance.UpdateStylesFabricStatusActual(ID, Etadate, UserId);
        }


        //Add By Prabhaker 30-March-18

        public DataSet GetProfitOn_Mode_Mo(int OrderDetailId, int Mode,string OnHold)
        {
            return this.StyleDataProviderInstance.GetProfitOn_Mode_Mo(OrderDetailId, Mode, OnHold);
        }
        public int UpdateProfitOn_Mode_Mo(int OrderDetailId, bool FinalisedPenalty, int SharePercent, int Mode, int Orderdiscount,string UserName)
        {
            return this.StyleDataProviderInstance.UpdateProfitOn_Mode_Mo(OrderDetailId, FinalisedPenalty, SharePercent, Mode, Orderdiscount, UserName);
        }

        public DataTable BindMoMode()
        {
            return this.StyleDataProviderInstance.BindMoMode();
        }
        public List<StyleFabric> GetStyleFabricsByStyleId_New(int styleId)
        {
            return this.StyleDataProviderInstance.GetStyleFabricsByStyleId_New(styleId);
        }
        public List<StyleFabric> Get_RegisterAcc(string RegisterAccName)
        {
            return this.StyleDataProviderInstance.Get_RegisterAcc(RegisterAccName);
        }
        public List<StyleFabric> Get_RegisterProcess_Name(string RegisterProcessName)
        {
            return this.StyleDataProviderInstance.Get_RegisterProcess_Name(RegisterProcessName);
        }
        public List<StyleFabric> Get_RegisterFabric(string RegisterFabricName)
        {
            return this.StyleDataProviderInstance.Get_RegisterFabric(RegisterFabricName);
        }
        //Added by RSB on 1 jul 2022 for design form fabric
        public List<StyleFabric> Get_RegisterFabric_Design(string RegisterFabricName)
        {
            return this.StyleDataProviderInstance.Get_RegisterFabric_Design(RegisterFabricName);
        }
        // End
        public List<StyleFabric> Get_Register_Print(string RegisterPrint)
        {
            return this.StyleDataProviderInstance.Get_Register_Print(RegisterPrint);
        }
       //End Of Code
        //add code by bhrata on 6-2-20
      
        public string Get_Register_MarketingTag(string RegisterTag)
        {
            return this.StyleDataProviderInstance.Get_Register_MarketingTag(RegisterTag);
        }
        //abhishek 
        public List<Client> BindDeptListAgainstParentDeptWithFlag(int UserId, int ClientId, int FitMerchantID, int ParentDeptID,string Flag)
        {
          return this.StyleDataProviderInstance.BindDeptListAgainstParentDeptWithFlag(UserId, ClientId, FitMerchantID, ParentDeptID, Flag);
        }
        public DataTable Getmodedetail(int orderdetailid)
        {
          return this.StyleDataProviderInstance.Getmodedetail(orderdetailid);
        }
        public int UpdateCuttingSheetSelection(int OrderDetailId, string UserSession)
        {
          return this.StyleDataProviderInstance.UpdateCuttingSheetSelection(OrderDetailId, UserSession);
        }
        public int DeleteSessionID(string UserSession)
        {
            return this.StyleDataProviderInstance.DeleteSessionID(UserSession);
        }
        public int UpdateCuttingSheet_CheckBox(int OrderDetailId,int userid,bool Checkbox)
        {
            return this.StyleDataProviderInstance.UpdateCuttingSheet_CheckBox(OrderDetailId, userid, Checkbox);
        }
        public List<StyleFabric> Get_Final_Rate_From_PO(string fabricname, string fabtype, string print)
        {
            return this.StyleDataProviderInstance.Get_Final_Rate_From_PO(fabricname, fabtype, print);
        }
        //abhishek 14/10
        public List<StyleReferenceBlock> GetStyleReferenceByINDnumber(int StyleID, string indnumber)
        {
            Style style = new Style();
            return style.ReferenceBlocks = this.StyleDataProviderInstance.GetStyleReferenceByINDnumber(StyleID, indnumber);
        }

        // Added by Yadvendra on 06/01/2020
        public DataSet GetFileDetailsByStyleId(int StyleId)
        {
            return this.StyleDataProviderInstance.GetFileDetailsByStyleId(StyleId);
        }

        public int SaveFileDetailByStyleId(int StyleId, string FilePath, int UserId,int SeqNumber)
        {
            return this.StyleDataProviderInstance.SaveFileDetailByStyleId(StyleId, FilePath, UserId, SeqNumber);
        }

        public int SaveMarketingDescription(int StyleId, string Title, string Gamenttype, Int32 MarKetingCollection, string MarKetingMOQ, decimal MarketPrice, string ShortDesc, string LongDesc, int UserId)
        {
            return this.StyleDataProviderInstance.SaveMarketingDescription(StyleId, Title, Gamenttype,MarKetingCollection,MarKetingMOQ, MarketPrice, ShortDesc, LongDesc, UserId);
        }
        public int SaveTagNameByStyleId(int StyleId, string Tagval)
        {
            return this.StyleDataProviderInstance.SaveTagNameByStyleId(StyleId, Tagval);
        }
        public DataTable GetTagsByStyleId(int StyleId)
        {
            return this.StyleDataProviderInstance.GetTagsByStyleId(StyleId);
        }
       
        public int DeleteFilesByStyleId(int StyleId)
        {
            return this.StyleDataProviderInstance.DeleteFilesByStyleId(StyleId);
        }
        //End Added by Yadvendra on 06/01/2020
        // Added by Bharat on 31/01/2020
        public DataTable BindGarmentTypeDropDown()
        {
            return this.StyleDataProviderInstance.BindGarmentTypeDropDown();
        }

        public DataSet BindMarketingTypeDropDown()
        {
            return this.StyleDataProviderInstance.BindMarketingTypeDropDown();
        }
    } 
}
