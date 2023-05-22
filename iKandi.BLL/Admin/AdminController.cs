using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using System.Data.SqlClient;
using System.Data;
using iKandi.Common.Entities;
using iKandi.BLL.Admin;


namespace iKandi.BLL
{
    public class AdminController : BaseController
    {
        //added abhishek 27/3/2015

        public DataSet GetworkerType_MMR()//frmworkerDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetWorkdType_Details_MMR();
            return ds;
        }
        //added by raghvinder on 28/05/2020 start
        public DataSet GetMMRReportDate()//frmworkerDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetMMRReportDate();
            return ds;
        }
        //added by raghvinder on 28/05/2020 end

        //added by raghvinder on 19-05-2020 start
        public DataSet GetMMRSummaryreport(string CreatedDate)//frmworkerDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetMMRSummaryreport(CreatedDate);
            return ds;
        }
        //added by raghvinder on 19-05-2020 end

        //added by raghvinder on 16-09-2020 start
        public DataSet GetPoSrvReport()//frmworkerDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetPoSrvReport();
            return ds;
        }
        //added by bharat on 27-Nov-2020 end
        public DataSet GetAccessoryPoSrvReport()//frmworkerDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetAccessoryPoSrvReport();
            return ds;
        }
        // End
        //added by raghvinder on 21-05-2020 start
        public DataSet GetBIPLBudgetShortfall(string CreatedDate)
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetBIPLBudgetShortfall(CreatedDate);
            return ds;
        }

        public DataSet GetKeyManPowerMMRreport(string CreatedDate)
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetKeyManPowerMMRreport(CreatedDate);
            return ds;
        }
        //added by raghvinder on 21-05-2020 end


        //added by raghvinder on 16/03/2020 start
        public DataSet GetMMRreport(string WorkerType, string Dept, string CreatedDate)//frmworkerDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetMMRreport(WorkerType, Dept, CreatedDate);
            return ds;
        }

        //added by raghvinder on 20/06/2020 start       

        public int UpdateCmtAdminRateAndPieces(decimal Rate, int Pieces)
        {
            int row;
            row = Convert.ToInt32(AdminDataProviderInstance.UpdateCmtAdminRateAndPieces(Rate, Pieces));
            return row;
        }
        //added by raghvinder on 20/06/2020 end

        //added by raghvinder on 29/07/2020 start
        public int InsertOTDays(string CreatedDate, int OTDays)
        {
            int row;
            row = Convert.ToInt32(AdminDataProviderInstance.InsertOTDays(CreatedDate, OTDays));
            return row;
        }
        //added by raghvinder on 29/07/2020 end

        //added by raghvinder on 23/05/2020 start 
        public int InsertBudgetShortfall_Report(string XMLDataAQL, string CreatedDate)
        {
            int row;
            row = Convert.ToInt32(AdminDataProviderInstance.InsertBudgetShortfall_Report(XMLDataAQL, CreatedDate));
            return row;
        }
        //added by raghvinder on 23/05/2020 end

        public int InserNewMMR_Report(string XMLDataAQL, string CreatedDate)
        {
            int row;
            row = Convert.ToInt32(AdminDataProviderInstance.InserNewMMR_Report(XMLDataAQL, CreatedDate));
            return row;
        }
        public int MMRLogOut(int UserID, int Flag)
        {
            int row;
            row = Convert.ToInt32(AdminDataProviderInstance.MMRLogOut(UserID, Flag));
            return row;
        }
        //added by raghvinder on 16/03/2020 end

        //added by raghvinder on 20/03/2020 start
        public DataSet GetSloWiseQCReport(DateTime QCDate)//frmworkerDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetSloWiseQCReport(QCDate);
            return ds;
        }
        //added by raghvinder on 20/03/2020 end



        public List<Client> BindClientListAgainstMerchant(int UserId, int flag)
        {
            return this.AdminDataProviderInstance.BindClientListAgainstMerchant(UserId, flag);
        }

        public List<Client> BindDeptListAgainstCliets(int UserId, int ClientId, int FitMerchantID)
        {
            return this.AdminDataProviderInstance.BindDeptListAgainstCliets(UserId, ClientId, FitMerchantID);
        }
        //abhishek 
        public List<Client> BindDeptListAgainstParentDept(int UserId, int ClientId, int FitMerchantID, int ParentDeptID)
        {
            return this.AdminDataProviderInstance.BindDeptListAgainstParentDept(UserId, ClientId, FitMerchantID, ParentDeptID);
        }
        public int InsertUpdateWorkerBAL_MMR(string WorkerType, int Salary_Range, int UserID, int machinecount, int Mmrcount, string ddlstaffvalue, string Discription, int OT1, int OT2, int OT3, int OT4, int Isstaff, string Catagory, decimal Measurement, decimal Qty, decimal Percent, int IsStatus)
        {
            return this.AdminDataProviderInstance.InsertUpdateWorkerDAL_MMR(WorkerType, Salary_Range, UserID, machinecount, Mmrcount, ddlstaffvalue, Discription, OT1, OT2, OT3, OT4, Isstaff, Catagory, Measurement, Qty, Percent, IsStatus);
        }
        public int UpdateWorkerBAL_MMR(string WorkerType, int Salary_Range, int UserID, int HdnID, string DdlStaff, int Machine_Count_rdo, int MmrCount, string txt_Discription, int OT1, int OT2, int OT3, int OT4, int Isstaff, string Catagorys, decimal Measurement, decimal Qty, decimal Percent, int isStatus)
        {
            return this.AdminDataProviderInstance.UpdateWorkerDAL_MMR(WorkerType, Salary_Range, UserID, HdnID, DdlStaff, Machine_Count_rdo, MmrCount, txt_Discription, OT1, OT2, OT3, OT4, Isstaff, Catagorys, Measurement, Qty, Percent, isStatus);
        }

        public int InsertUpdateWorkerBAL(string WorkerType, int Salary_Range, int UserID, int machinecount, int Mmrcount, string ddlstaffvalue, string Discription, int OT1, int OT2, int OT3, int OT4, int Isstaff, string Catagory, decimal Measurement, decimal Qty, decimal Percent)
        {
            return this.AdminDataProviderInstance.InsertUpdateWorkerDAL(WorkerType, Salary_Range, UserID, machinecount, Mmrcount, ddlstaffvalue, Discription, OT1, OT2, OT3, OT4, Isstaff, Catagory, Measurement, Qty, Percent);
        }
        public int UpdateWorkerBAL(string WorkerType, int Salary_Range, int UserID, int HdnID, string DdlStaff, int Machine_Count_rdo, int MmrCount, string txt_Discription, int OT1, int OT2, int OT3, int OT4, int Isstaff, string Catagorys, decimal Measurement, decimal Qty, decimal Percent)
        {
            return this.AdminDataProviderInstance.UpdateWorkerDAL(WorkerType, Salary_Range, UserID, HdnID, DdlStaff, Machine_Count_rdo, MmrCount, txt_Discription, OT1, OT2, OT3, OT4, Isstaff, Catagorys, Measurement, Qty, Percent);
        }

        public DataSet GetworkerType()//frmworkerDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetWorkdType_Details();
            return ds;
        }
        //End
        public DataSet Getattchmentdetails()//frmattchmentDetailsBAL methods Start
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.Getattchmentdetails();
            return ds;
        }

        public int InsertAttchmentBAL(string AttachmentName, string Discription, int UserID)// for insert
        {
            return this.AdminDataProviderInstance.InsertAttachmentDAL(AttachmentName, Discription, UserID);
        }
        public int UpdateAttchmentBAL(string AttachmentName, string Discription, int UserID, int HdnID)// for update
        {
            return this.AdminDataProviderInstance.UpdateAttachmentDAL(AttachmentName, Discription, UserID, HdnID);
        }
        //END

        public DataSet BindCheckboxBAL()
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.BindCheckboxDAL();
            return ds;
        }
        public DataSet BindDDlBAL()
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.BindDDlDAL();
            return ds;
        }
        public DataSet GetMachienattDetailsBAL()
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetMachienAttchment();
            return ds;
        }
        public int InsertMachienAttchmentBAL(string Machien_typ, string Chklist, string DdlselectedValue, int UserID)// for insert
        {
            return this.AdminDataProviderInstance.InsertMachienAttachmentDAL(Machien_typ, Chklist, DdlselectedValue, UserID);
        }

        public int UpdateMachienAttchmentBAL(string txtMachientype, string ddltext, string strCheckList, int UserID, int HdnID)// for update
        {
            return this.AdminDataProviderInstance.UpdateMachienAttachmentDAL(txtMachientype, ddltext, strCheckList, UserID, HdnID);
        }
        //END

        public DataSet GetGarmentsTypeBAL()//frmGarments type DetailsBAL
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetGarment_TypeDAL();
            return ds;
        }
        public int InsertUpdateGarmentsBAL(string GarmmentType, string Discription, int UserID)
        {
            return this.AdminDataProviderInstance.InsertUpdateGarmentsDAL(GarmmentType, Discription, UserID);
        }
        public int UpdateGarmentsBAL(string GarmmentType, string Discription, int UserID, int HdnID)
        {
            return this.AdminDataProviderInstance.UpdateGarmentstypeDAL(GarmmentType, Discription, UserID, HdnID);
        }

        public DataSet GetOBSectionBAL()//frmOB section type DetailsBAL
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetOBSectionDAL();
            return ds;
        }
        public int InsertOBSectionBAL(string Section, string Discription, int UserID)
        {

            return this.AdminDataProviderInstance.InsertOBSectionDAL(Section, Discription, UserID);
        }
        public int UpdateOBSectionBAL(string Section, string Discription, int UserID, int HdnID)
        {
            return this.AdminDataProviderInstance.UpdateOBSectionDAL(Section, Discription, UserID, HdnID);
        }
        //manpower OT Admin
        //2/6/2015
        public DataSet GetManpowerOT()//frmworkerDetailsBAL methods Start
        {
            DataSet ds1 = new DataSet();
            ds1 = AdminDataProviderInstance.GetManpowerOT();
            return ds1;
        }
        public int InsertGetManpowerOTBAL(string CatgoryOT, double CostPPPh, string FactoryStaff, int UserID)
        {

            return this.AdminDataProviderInstance.InsertGetManpowerOTDAL(CatgoryOT, CostPPPh, FactoryStaff, UserID);
        }
        public int UpdateGetManpowerOTBAL(string CatgoryOT, double CostPPPh, string FactoryStaff, int UserID, int HdnID)
        {
            return this.AdminDataProviderInstance.UpdateGetManpowerOTDAL(CatgoryOT, CostPPPh, FactoryStaff, UserID, HdnID);
        }
        public DataSet GetClientlist(int modeid)
        {
            return this.AdminDataProviderInstance.GetClientlist( modeid);
        }
        public DataTable GetClientlistFillter(string clientid)
        {
            return this.AdminDataProviderInstance.GetClientlistFillter(clientid);
        }
        //added by abhishek 24/8/2015
        public DataTable GeIedetails(string ids)
        {
            return this.AdminDataProviderInstance.GeIedetails(ids);
        }
        //End
        //added by abhishek 24/8/2015
        public DataTable PermissionToAccessPage(int departmentID, string ApplicationModulaPath)
        {
            return this.AdminDataProviderInstance.PermissionToAccessPage(departmentID, ApplicationModulaPath);
        }
        //End


        /*<------END -----abhi-->*/
        #region Ctor

        public AdminController()
        {
        }

        public AdminController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Zip Rate Methods

        public List<Zip> GetZipRate()
        {
            return this.AdminDataProviderInstance.GetAllZipRate();
        }


        public Zip Save(Zip objZipRate)
        {
            if (objZipRate.Id == -1)
            {
                this.AdminDataProviderInstance.InsertZipRate(objZipRate);
            }
            else
            {
                this.AdminDataProviderInstance.UpdateZipRate(objZipRate);

            }
            return objZipRate;

        }

        public Zip GetZipRateById(int ZipRateId)
        {
            return this.AdminDataProviderInstance.GetZipRateById(ZipRateId);
        }

        public Boolean DeleteZipRate(int ZipRateId)
        {
            return this.AdminDataProviderInstance.DeleteZipRate(ZipRateId);
        }

        public DataTable GetTaskDesignationMapping(string iTaskType)
        {
            return AdminDataProviderInstance.GetTaskDesignationMapping(iTaskType);
        }

        public DataTable GetDesignation(Int32 iTaskId, Int32 iDesignationId)
        {
            return AdminDataProviderInstance.GetDesignation(iTaskId, iDesignationId);
        }


        #endregion

        #region AppLicaton Module Method

        public List<ApplicationModule> GetAllApplicationModule()
        {
            return this.AdminDataProviderInstance.GetAllApplicationModule();
        }

        public List<ApplicationModule> GetAllApplicationModuleByDesignation(int DesignationID)
        {
            return this.AdminDataProviderInstance.GetAllApplicationModuleByDesignation(DesignationID);
        }

        public List<ApplicationModule> GetAllApplicationModuleByUser(int UserID)
        {
            return this.AdminDataProviderInstance.GetAllApplicationModuleByUser(UserID);
        }

        public List<ApplicationModule> GetAllApplicationModuleByDepartment(int DepartmentID)
        {
            return this.AdminDataProviderInstance.GetAllApplicationModuleByDepartment(DepartmentID);
        }

        #endregion

        #region Top Navigation Method

        public WorkFlowPhaseCollection GetPhases(int UserID)
        {
            return this.AdminDataProviderInstance.GetPhase(UserID);
        }

        #endregion

        #region Email Template Related Methods

        public void UpdateEmailTemplate(EmailTemplate objemailTemplate)
        {
            this.AdminDataProviderInstance.UpdateEmailTemplate(objemailTemplate);
        }

        public EmailTemplate GetEmailTemplateById(int ID)
        {
            return this.AdminDataProviderInstance.GetEmailTemplateById(ID);
        }

        public List<EmailTemplate> GetAllEmailTemplates()
        {
            return this.AdminDataProviderInstance.GetAllEmailTemplate();
        }

        public DataSet GetAllEmailSchedule()
        {
            return this.AdminDataProviderInstance.GetAllEmailSchedule();
        }

        public void Insert_Email_Schedule_Data(int emailid, string days, string time)
        {
            this.AdminDataProviderInstance.Insert_Email_Schedule_Data(emailid, days, time);
        }

        public List<EmailSchedule> Get_All_Email_Schedule_Tempalte_Data(string tmFrom, string tmTo)
        {
            return this.AdminDataProviderInstance.Get_All_Email_Schedule_Tempalte_Data(tmFrom, tmTo);
        }

        #endregion

        #region Category Methods

        /// <summary>
        /// Saves(Create or Update) the given <c>Category</c> into the database.
        /// </summary>
        /// <param name="category">The <c>Category</c> to save.</param>
        /// <returns>The saved category.</returns>
        public iKandi.Common.Category SaveCategory(iKandi.Common.Category category)
        {
            int categoryID = -1;
            if (category.CategoryID == -1)
            {
                categoryID = this.AdminDataProviderInstance.CreateCategory(category);
                category.CategoryID = categoryID;
            }
            else
            {
                categoryID = this.AdminDataProviderInstance.UpdateCategory(category);
            }

            return category;
        }

        //ADDED BY RAGHVINDER ON 22-09-2020 STARTS        
        public DataTable GetFabricCountConstruction(int CategoryID)
        {
            DataTable dt = new DataTable();
            dt = this.AdminDataProviderInstance.GetFabricCountConstruction(CategoryID);
            return dt;
        }
        //ADDED BY RAGHVINDER ON 22-09-2020 ENDS

        //ADDED BY RAGHVINDER ON 02-10-2020 START
        public DataTable FreezeUnit(int CategoryId, int Type)
        {
            DataTable dt = new DataTable();
            dt = this.AdminDataProviderInstance.FreezeUnit(CategoryId, Type);
            return dt;
        }
        //ADDED BY RAGHVINDER ON 02-10-2020 END


        //ADDED BY RAGHVINDER ON 25-09-2020 STARTS        
        public DataTable GetApprovedUnit(int Flag)
        {
            DataTable dt = new DataTable();
            dt = this.AdminDataProviderInstance.GetApprovedUnit(Flag);
            return dt;
        }
        //ADDED BY RAGHVINDER ON 25-09-2020 ENDS


        //Add By Prabhaker 22 jun 18
        public DataSet GetAllAdminUnit(string Flag)
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetAllAdminUnit(Flag);
            return ds;
        }
        public iKandi.Common.Category SaveCategoryNew(iKandi.Common.Category category)
        {
            int categoryID = -1;
            if (category.CategoryID == -1)
            {
                categoryID = this.AdminDataProviderInstance.CreateCategory_New(category);
                category.CategoryID = categoryID;
            }
            else
            {
                categoryID = this.AdminDataProviderInstance.UpdateCategory_New(category);
            }

            return category;
        }

        public AuditCategory SaveAuditCategory(AuditCategory category)
        {
            int ID = -1;
            if (category.Id == -1)
            {
                ID = this.AdminDataProviderInstance.CreateAuditCategory(category);
                category.Id = ID;
            }
            else
            {
                ID = this.AdminDataProviderInstance.UpdateAuditCategory(category);
                category.Id = ID;
            }

            return category;
        }

        public int DeleteAuditCategory(AuditCategory category)
        {
            return this.AdminDataProviderInstance.DeleteAuditCategory(category);

        }

        public iKandi.Common.Category GetCategoryById_New(int categoryId)
        {
            return this.AdminDataProviderInstance.GetCategoryById_New(categoryId);
        }

        public IList<iKandi.Common.Category> GetAllCategories_New(Category searchCriteria)
        {
            if (searchCriteria == null)
            {
                searchCriteria = new Category();
                searchCriteria.CategoryCode = null;
                searchCriteria.CategoryName = null;
                searchCriteria.Type = -1;
                searchCriteria.Parent = new Category();
                searchCriteria.Parent.CategoryID = -1;
            }
            IList<Category> result = this.AdminDataProviderInstance.GetAllCategories_New(searchCriteria);
            //categoriesCount = totalRecords;
            return result;
        }
        //Add By Prabhaker 23- jul-18
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select)]
        public IList<iKandi.Common.Category> GetAllCategories_New_Submit(int UserId, out int totalRecords)
        {
            IList<Category> result = this.AdminDataProviderInstance.GetAllCategories_New_Submit(UserId, out totalRecords);
            categoriesCount = totalRecords;
            return result;
        }
        //End Of Code

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select)]
        //public IList<Category> GetAllCategories_New(Category searchCriteria)
        //{           
        //    if (searchCriteria == null)
        //    {
        //        searchCriteria = new Category();
        //        searchCriteria.CategoryCode = null;
        //        searchCriteria.CategoryName = null;
        //        searchCriteria.Type = -1;
        //        searchCriteria.Parent = new Category();
        //        searchCriteria.Parent.CategoryID = -1;
        //    }
        //    IList<Category> result = this.AdminDataProviderInstance.GetAllCategories_New(searchCriteria);            
        //    return result;
        //}





        public List<iKandi.Common.Category> GetSubCategories_New(int parentId)
        {
            return this.AdminDataProviderInstance.GetSubCategories_New(parentId);
        }

        public IList<iKandi.Common.Category> GetAllCategoriesType_New(int Type)
        {
            return this.AdminDataProviderInstance.GetAllCategoriesType_New(Type);
        }
        //End Of Code

        /// <summary>
        /// Retrieves the <c>Category</c> by the given category id.
        /// </summary>
        /// <param name="categoryId">Id of the category to be retrieved.</param>
        /// <returns>The retrieved category.</returns>
        public iKandi.Common.Category GetCategoryById(int categoryId)
        {
            return this.AdminDataProviderInstance.GetCategoryById(categoryId);
        }

        int categoriesCount = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        public IList<iKandi.Common.Category> GetAllCategories(int pageIndex, int pageSize, out int totalRecords,
            Category searchCriteria)
        {
            int start = pageIndex * pageSize;
            if (searchCriteria == null)
            {
                searchCriteria = new Category();
                searchCriteria.CategoryCode = null;
                searchCriteria.CategoryName = null;
                searchCriteria.Type = -1;
                searchCriteria.Parent = new Category();
                searchCriteria.Parent.CategoryID = -1;
            }
            IList<Category> result = this.AdminDataProviderInstance.GetAllCategories(start, pageSize, out totalRecords, searchCriteria);
            categoriesCount = totalRecords;
            return result;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select)]
        public IList<Category> GetAllCategories(int startIndex, int pageSize, Category searchCriteria)
        {
            int totalRecords;
            if (searchCriteria == null)
            {
                searchCriteria = new Category();
                searchCriteria.CategoryCode = null;
                searchCriteria.CategoryName = null;
                searchCriteria.Type = -1;
                searchCriteria.Parent = new Category();
                searchCriteria.Parent.CategoryID = -1;
            }
            IList<Category> result = this.AdminDataProviderInstance.GetAllCategories(startIndex, pageSize, out totalRecords, searchCriteria);
            categoriesCount = totalRecords;
            return result;
        }

        public int GetAllCategoriesCount(int startIndex, int pageSize, Category searchCriteria)
        {
            return categoriesCount;
        }


        public IList<iKandi.Common.Category> GetAllCategories(int Type)
        {
            return this.AdminDataProviderInstance.GetAllCategories(Type);
        }

        public List<iKandi.Common.Category> GetSubCategories(int parentId)
        {
            return this.AdminDataProviderInstance.GetSubCategories(parentId);
        }
        #endregion

        #region Delivery Modes

        public List<DeliveryMode> GetAllDeliveryModes(int ClientID = 0)
        {
            return this.AdminDataProviderInstance.GetAllDeliveryModes(ClientID);
        }
        public void UpdateModes(List<DeliveryMode> DeliveryModes, ref string sMessag)
        {
            foreach (DeliveryMode dm in DeliveryModes)
            {
                if (dm.Id == -1)
                {
                    this.AdminDataProviderInstance.InsertDeliveryModes(dm);
                }
                else if (dm.Id > -1)
                {
                    //Edit By Prabhaker 25-jul-18
                    //string sMessage=string.Empty;
                  //  this.AdminDataProviderInstance.CheckDAssociateClintCostingMapping(dm.Id, dm.ClientMapping, ref sMessag);
                    if (sMessag == "")
                        this.AdminDataProviderInstance.UpdateDeliveryModes(dm);
                    else
                        return;
                }

            }
        }


        public void UpdateDeliveryModesAssociation(int id, string ClientAssociation)
        {


            this.AdminDataProviderInstance.UpdateDeliveryModesAssociation(id, ClientAssociation);


        }
        // Add By Ravi kumar for Booking modes
        public List<DeliveryMode> GetBookingModes()
        {
            return this.AdminDataProviderInstance.GetBookingModes();
        }

        #endregion

        #region Status Modes Related Methods

        public List<StatusModes> GetAllowStatusModesToDesignation()
        {
            return this.AdminDataProviderInstance.GetAllowStatusModesToDesignation();
        }

        public List<StatusModes> GetAllStatusModes()
        {
            return this.AdminDataProviderInstance.GetAllStatusModes();
        }

        public List<StatusModes> Get_StatusModeForIkandiInvoice()
        {
            return this.AdminDataProviderInstance.Get_StatusModeForIkandiInvoice();
        }

        #endregion

        #region Clients AQL Methods

        public DataSet GetClientsAQL()
        {
            return this.AdminDataProviderInstance.GetClientsAQL();
        }

        public bool InsertClientsAQL(List<ClientAQL> cAQL)
        {
            bool success = false;
            if (this.AdminDataProviderInstance.DeleteClientsAQL())
                foreach (ClientAQL cAql in cAQL)
                {
                    success = this.AdminDataProviderInstance.InsertClientsAQL(cAql);
                }
            return success;
        }

        #endregion

        #region QA Faults Methods

        public DataSet GetQAFaults()
        {
            return this.AdminDataProviderInstance.GetQAFaults();
        }

        public bool UpdateFaults(String FaultCode, String FaultDescription, Int32 SubcategoryType, Int32 FaultType, Int32 original_Id)
        {
            return this.AdminDataProviderInstance.UpdateFaults(FaultCode, FaultDescription, SubcategoryType, FaultType, original_Id);
        }

        public int DeleteFault(Int32 original_Id)
        {
            return this.AdminDataProviderInstance.DeleteFault(original_Id);
        }

        public bool InsertFaults(String FaultCode, String FaultDescription, Int32 SubcategoryType, Int32 FaultType)
        {
            return this.AdminDataProviderInstance.InsertFaults(FaultCode, FaultDescription, SubcategoryType, FaultType);
        }

        #endregion

        #region Client Costing Default

        public DataSet GetClientCostingDefaults(int clintid = 0)
        {
            return this.AdminDataProviderInstance.GetClientCostingDefaults(clintid);
        }
        public DataSet GetClientCostingDefaults_New(int clintid = 0)
        {
            return this.AdminDataProviderInstance.GetClientCostingDefaults_New(clintid);
        }
        public bool GetClientCostingDefaults_BreakDown_New(string ClientID, string Code, string DeptId)
        {
            return this.AdminDataProviderInstance.GetClientCostingDefaults_BreakDown_New(ClientID, Code, DeptId);
        }
        /*---------------Add-By Prabhaker--06-Dec-17-------------------*/

        public DataSet GetOhPercentValue(int clintid)
        {
            return this.AdminDataProviderInstance.GetOhPercentValue(clintid);
        }

        public DataSet GetOhValueNull(int clintid)
        {
            return this.AdminDataProviderInstance.GetOhValueNull(clintid);
        }
        /*----------------End Of Code--------------------------------*/

        public DataTable GetClientCosting_By_Client_Dept(int ClientId, int DeptId,int StyleId)
        {
            return this.AdminDataProviderInstance.GetClientCosting_By_Client_Dept(ClientId, DeptId, StyleId);
        }
        public DataTable GetLandedCosting_By_Client_Dept(int ClientId, int DeptId, int CostingId)
        {
            return this.AdminDataProviderInstance.GetLandedCosting_By_Client_Dept(ClientId, DeptId, CostingId);
        }
        public DataTable GetDirectCosting_By_Client_Dept(int ClientId, int DeptId, int CostingId)
        {
            return this.AdminDataProviderInstance.GetDirectCosting_By_Client_Dept(ClientId, DeptId, CostingId);
        }
        public DataTable GetBindModeCost()
        {
            return this.AdminDataProviderInstance.GetBindModeCost();
        }
        public DataTable GetBindProcessCost()
        {
            return this.AdminDataProviderInstance.GetBindProcessCost();
        }
        public DataTable GetClientCosting_By_Client_Dept_ForExpectedQty(int ClientId, int DeptId, int fromCisting)
        {
            return this.AdminDataProviderInstance.GetClientCosting_By_Client_Dept_ForExpectedQty(ClientId, DeptId, fromCisting);
        }


        public void SaveClientCostingDefault(ClientCostingDefault ccd)
        {
            this.AdminDataProviderInstance.SaveClientCostingDefault(ccd);
        }

        public void SaveClientCostingDefault_Achievement(string ClientName, string DeptName, int ItemId, double Value)
        {
            this.AdminDataProviderInstance.SaveClientCostingDefault_Achievement(ClientName, DeptName, ItemId, Value);
        }

        #endregion

        #region Conversion Rate

        public void SaveConversionRate(CurrencyConversion currencyConversion)
        {
            this.AdminDataProviderInstance.SaveConversionRate(currencyConversion.ID, currencyConversion.ConversionRate, currencyConversion.ExportConversionRate);

            iKandi.BLL.BLLCache.ClearCurrencyConversionCache();
        }

        public List<CurrencyConversion> GetAllConversionRate()
        {
            return this.AdminDataProviderInstance.GetAllConversionRate();
        }

        #endregion

        #region User Holiday Entitlement

        public List<UserHolidayEntitlement> GetUserEntitledHolidays()
        {
            return this.AdminDataProviderInstance.GetUserEntitledHolidays();
        }

        public void SaveUserEntitledHolidays(UserHolidayEntitlement UHE)
        {
            this.AdminDataProviderInstance.SaveUserEntitledHolidays(UHE);
        }

        #endregion

        public List<TypeOfPacking> GetAllOrderTypeOFPacking()
        {
            return this.AdminDataProviderInstance.GetAllOrderTypeOfPacking();
        }
        public DataSet Gettargetdatesforadmin()
        {
            return this.AdminDataProviderInstance.Gettargetdatesforadmin();
        }

        public DataSet GetTargetDateQA()
        {
            return this.AdminDataProviderInstance.GetTargetDateQA();
        }

        public void Updatetargetdatesforadmin(AdminTargetdate admintrgdate)
        {
            this.AdminDataProviderInstance.Updatetargetdatesforadmin(admintrgdate);
        }

        public void SaveTaskDesignationMapping(Int32 iTaskId, Int32 iDesignationId, String iDesignationName)
        {
            this.AdminDataProviderInstance.SaveTaskDesignationMapping(iTaskId, iDesignationId, iDesignationName);
        }

        public void DeleteTaskDesignationMapping(Int32 iTaskId)
        {
            this.AdminDataProviderInstance.DeleteTaskDesignationMapping(iTaskId);
        }


        public void UpdatetargetdatesforAll(int isValidForAll)
        {
            this.AdminDataProviderInstance.UpdatetargetdatesforAll(isValidForAll);
        }
        public DataSet GetCMTBAL()
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetCMTBAL();
            return ds;
        }


        public void UpdateCMTBAL(int intSam, int id, int int499, int int999, int int1999, int int2999, int int4999, int int9999, int int14999, int int20000, int intAbove20000)
        {
            AdminDataProviderInstance.UpdateCMTDAL(intSam, id, int499, int999, int1999, int2999, int4999, int9999, int14999, int20000, intAbove20000);
        }


        public void DeleteCMTBAL(int Id)
        {
            AdminDataProviderInstance.DeleteCMTDAL(Id);

        }

        public void InsertUpdateCMTDefault(int DefaultValue)
        {
            AdminDataProviderInstance.InsertUpdateCMTDefaultDAL(DefaultValue);

        }
        /// <summary>
        /// Yaten : Get GarmentType and CMT charges  12 Apr
        /// </summary>
        /// <param name="isValidForAll"></param>
        public DataSet GetGarmentTypeBAL()
        {
            DataSet ds = new DataSet();
            ds = AdminDataProviderInstance.GetGarmentTypeDAL();
            return ds;
        }


        /// <summary>
        /// Yaten : Insert/Update CMT Charges 12 Apr 2010
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GrmType"></param>
        /// <param name="Option"></param>
        /// <param name="intUp5"></param>
        /// <param name="intUp15"></param>
        /// <param name="intUp30"></param>
        /// <param name="intup50"></param>
        /// <param name="intUp100"></param>
        /// <param name="intAbv100"></param>
        /// <param name="intDefaultValue"></param>
        public void UpdateGarmentTypeBAL(int intSam, int id, string GrmType, string Option, int intUp5, int intUp15, int intUp30, int intup50, int intUp100, int intAbv100, int intDefaultValue)
        {
            AdminDataProviderInstance.UpdateGarmentTypeDAL(intSam, id, GrmType, Option, intUp5, intUp15, intUp30, intup50, intUp100, intAbv100, intDefaultValue);
        }
        /// <summary>
        /// Yaten : Delete CMT Charges 12 Apr
        /// </summary>
        /// <param name="Id"></param>
        public int DeleteGarmentTypeBAL(int Id)
        {
            int i = AdminDataProviderInstance.DeleteGarmentTypeDAL(Id);
            return i;
        }

        /// <summary>
        /// Get All Group Names 
        /// </summary>

        /// <returns></returns>

        public System.Data.DataSet GetAllGroupBAL()
        {
            return this.AdminDataProviderInstance.GetAllGroupDAL();
        }

        /// <sumary>
        /// Get All Process
        /// </sumary>
        public System.Data.DataSet GetProcess()
        {
            return this.AdminDataProviderInstance.Getprocess();
        }

        public DataSet GetFebricGroupMasterBAL()
        {
            return this.AdminDataProviderInstance.GetFebricGroupMasterDAL();
        }
        /// <sumary>
        /// Get All Process Group
        /// </sumary>
        public System.Data.DataSet GetProcessGroup()
        {
            return this.AdminDataProviderInstance.GetprocessGroup();
        }

        /// <summary>
        /// All process or Cutting  and grdType means Cutting or process
        /// </summary>
        /// <param name="grdType"></param>
        /// <returns></returns>
        public System.Data.DataSet GetAllProcessBAL(string grdType)
        {
            return this.AdminDataProviderInstance.GetAllProcessDAL(grdType);
        }

        /// <summary>
        /// Check combination of Group and Process
        /// </summary>
        /// <param name="intGroupId"></param>
        /// <param name="grdType"></param>
        /// <returns></returns>
        public System.Data.DataSet CheckProcessWithGroupBAL(int intGroupId, string grdType)
        {
            return this.AdminDataProviderInstance.CheckProcessWithGroupDAL(intGroupId, grdType);
        }

        /// <summary>
        /// Insert and Update Process  depend on Status if Insert or Update
        /// </summary>
        /// <param name="stringProcessName"></param>
        /// <param name="intGroupId"></param>
        /// <param name="Status"></param>
        /// <param name="intShrinkage"></param>
        /// <param name="intWashing"></param>
        /// <param name="iID"></param>
        /// <param name="rowcount"></param>
        public void InsertProcessBAL(string stringProcessName, int intGroupId, string Status, int? intShrinkage, int? intWashing, int iID, int rowcount)
        {
            this.AdminDataProviderInstance.InsertProcessDAL(stringProcessName, intGroupId, Status, intShrinkage, intWashing, iID, rowcount);
        }


        /// <summary>
        /// Insert and Update Cutting  depend on IsEdit is 0 Insert and id > 0 Update
        /// </summary>
        /// <param name="rangeFrom"></param>
        /// <param name="rangeTo"></param>
        /// <param name="QtyUnit"></param>
        /// <param name="cuttingwastage"></param>
        /// <param name="IsEdit"></param>
        /// <returns></returns>
        public int InsertCuttingBAL(int rangeFrom, int rangeTo, int QtyUnit, int cuttingwastage, int IsEdit)
        {
            return this.AdminDataProviderInstance.InsertCuttingDAL(rangeFrom, rangeTo, QtyUnit, cuttingwastage, IsEdit);
        }

        public void DeleteCuttingAndProcessBAL(int intRecordId, string type)
        {
            this.AdminDataProviderInstance.DeleteCuttingAndProcessDAL(intRecordId, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intGroupId"></param>
        /// <param name="grdType"></param>
        /// <returns></returns>
        public System.Data.DataSet GetProcessNumberBAL(string intProcessID)
        {
            return this.AdminDataProviderInstance.GetProcessNumberDAL(intProcessID);
        }


        public int InsertSecurityReceiptBAL(int userId, DateTime ChallanDate, DateTime CurrentDate, params string[] SecurityDetails)
        {
            return this.AdminDataProviderInstance.InsertSecurityReceiptDAL(userId, ChallanDate, CurrentDate, SecurityDetails);
        }



        public System.Data.DataSet GetSecurityReceiptBAL(DateTime? min, DateTime? max, string Type)
        {
            return this.AdminDataProviderInstance.GetSecurityReceiptDAL(min, max, Type);
        }




        //Supplier

        public System.Data.DataSet GetSupplierBAL(int intSupplierId)
        {
            return this.AdminDataProviderInstance.GetSupplierDAL(intSupplierId);
        }


        public void InsertSupplierBAL(int intSupplierId, string Person, string mailid, string phone, string Remarks)
        {
            this.AdminDataProviderInstance.InsertSupplierDAL(intSupplierId, Person, mailid, phone, Remarks);
        }


        //Currency Admin
        public System.Data.DataSet GetCurrencyBAL()
        {
            return this.AdminDataProviderInstance.GetCurrencyDAL();
        }

        public int InsertUpdateCurrencyBAL(int ID, double Conversion, double ExportConversionRate, string type, string symbol, bool IsPriceQuoted)
        {
            return this.AdminDataProviderInstance.InsertUpdateCurrencyDAL(ID, Conversion, ExportConversionRate, type, symbol, IsPriceQuoted);
        }

        //PO Instruction Admin
        public DataSet GetInstructionGroupMasterBAL()
        {
            return this.AdminDataProviderInstance.GetInstructionGroupMasterDAL();
        }

        public int InsertUpdateInstructionGroupMasterBAL(int? id, int type, int ordertype, int potype, int group, string desc, int userid, int GroupAccId, int row)
        {
            return this.AdminDataProviderInstance.InsertUpdateInstructionGroupMasterDAL(id, type, ordertype, potype, group, desc, userid, GroupAccId, row);
        }


        public int CheckDuplicateInstructionGroupMasterBAL(int type, int ordertype, int potype, int group, int? id)
        {
            return this.AdminDataProviderInstance.CheckDuplicateInstructionGroupMasterDAL(type, ordertype, potype, group, id);
        }


        /// <summary>
        /// Designation admin
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet GetClientBAL()
        {
            return this.AdminDataProviderInstance.GetClientDAL("100");
        }

        public string GetGateEntryNo(string entryType, string gateNo)
        {
            return this.AdminDataProviderInstance.GetGateEntryNo(entryType, gateNo);
        }

        public int CreateDepartment(string deptName, int compId)
        {
            return this.AdminDataProviderInstance.CreateDepartment(deptName, compId);
        }

        public int CreateDesignation(string desigName, int deptId, int linemanager, bool isHod)
        {
            return this.AdminDataProviderInstance.CreateDesignation(desigName, deptId, linemanager, isHod);
        }
        //Ashish
        //Insert Fabric group 

        public int InsertProcessNameBAL(string ProcessName, string Descr)
        {
            return this.AdminDataProviderInstance.InsertProcessNameDAL(ProcessName, Descr);
        }



        public void RefreshDashBoard()
        {
            this.AdminDataProviderInstance.RefreshDashBoard();
        }

        //public int InsertWastageBAL(WastageAdmin Prm_Wastage)
        //{
        //    return this.AdminDataProviderInstance.InsertWastageBAL(Prm_Wastage);
        //}
        public DataTable GetAllWastageBAL()
        {
            return this.AdminDataProviderInstance.GetAllWastageBAL();
        }
        // For Cutting
        public DataSet GetFactoryWork(string StaffDept)
        {
            return this.AdminDataProviderInstance.GetFactoryWork(StaffDept);
        }

        public DataTable GetCuttingOB(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetCuttingOB(OperationId, GarmentTypeId);
        }
        public int InsertUpdateCuttingOB(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateCuttingOB(OperationId, OperationVal, Flag);
        }
        public int InsertUpdateCuttingOBSam(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateCuttingOBSam(OperationId, GarmentTypeId, SamVal);
        }
        public int InsertOperation(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertOperation(OperationVal);
        }
        public DataTable GetCuttingOBSam(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetCuttingOBSam(OperationId, GarmentTypeId);
        }
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineOB(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineOB(OperationId);
        }
        //END 
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpaceOB(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId);
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineOB(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END

        //For Finishing
        //added by abhishek on 24/10/2015
        public DataTable GetFinishingOB(int OperationId, int GarmentTypeId, string serachtxt)
        {
            return this.AdminDataProviderInstance.GetFinishingOB(OperationId, GarmentTypeId, serachtxt);
        }

        //end by abhishek on 24/10/2015
        public DataTable GetFinishingOBSam(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetFinishingOBSam(OperationId, GarmentTypeId);
        }
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineFinishingOB(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineFinishingOB(OperationId);
        }
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpaceFinishing(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineFinishingOB(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END


        public int InsertUpdateFinishingOB(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateFinishingOB(OperationId, OperationVal, Flag);
        }
        public int InsertUpdateFinishingOBSam(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateFinishingOBSam(OperationId, GarmentTypeId, SamVal);
        }
        public int InsertFinishing(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertFinishing(OperationVal);
        }

        //For Stiching Font
        //added by abhishek on 24/10/2015

        public DataTable GetStichingOB(int OperationId, int GarmentTypeId, string Table1, string Table2, string Col1, string Col2, string Col3, string Col4, string sreachtxt)
        {
            return this.AdminDataProviderInstance.GetStichingOB(OperationId, GarmentTypeId, Table1, Table2, Col1, Col2, Col3, Col4, sreachtxt);
        }

        //end by abhishek on 24/10/2015
        public DataTable GetStichingOBSam(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSam(OperationId, GarmentTypeId);
        }
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingOB(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingOB(OperationId);
        }

        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpaceFront(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingOB(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END

        //END
        public int InsertUpdateStichingOB(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOB(OperationId, OperationVal, Flag);
        }
        public int InsertUpdateStichingOBSam(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSam(OperationId, GarmentTypeId, SamVal);
        }
        public int InsertStiching(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStiching(OperationVal);
        }

        //For Stiching Back 
        public DataTable GetStichingOBSamBack(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamBack(OperationId, GarmentTypeId);
        }
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingBackOB(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingBackOB(OperationId);
        }
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpaceBack(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId);  
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingBackOB(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END



        public int InsertStichingBack(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingBack(OperationVal);
        }
        public int InsertUpdateStichingOBBack(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBBack(OperationId, OperationVal, Flag);
        }
        public int InsertUpdateStichingOBSamBack(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamBack(OperationId, GarmentTypeId, SamVal);
        }

        //For Stiching neck 
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingOBNeck(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingOBNeck(OperationId);
        }
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpaceneck(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingOBNeck(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END

        public DataTable GetStichingOBSamNeck(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamNeck(OperationId, GarmentTypeId);
        }
        public int InsertStichingneck(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingneck(OperationVal);
        }
        public int InsertUpdateStichingOBNeck(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBNeck(OperationId, OperationVal, Flag);
        }
        public int InsertUpdateStichingOBSamNeck(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamNeck(OperationId, GarmentTypeId, SamVal);
        }

        //For Stiching Lining 
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingOBLining(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingOBLining(OperationId);
        }
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpaceLining(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingOBLining(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END

        public DataTable GetStichingOBSamLining(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamLining(OperationId, GarmentTypeId);
        }
        public int InsertStichingLining(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingLining(OperationVal);
        }
        public int InsertUpdateStichingOBSamLining(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamLining(OperationId, GarmentTypeId, SamVal);
        }
        public int InsertUpdateStichingOBLining(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBLining(OperationId, OperationVal, Flag);
        }

        //For Stiching lower  
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingOBLower(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingOBLower(OperationId);
        }
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpacelower(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationIdsa); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingOBLower(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END

        public DataTable GetStichingOBSamLower(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamLower(OperationId, GarmentTypeId);
        }
        public int InsertStichingLower(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingLower(OperationVal);
        }
        public int InsertUpdateStichingOBSamLower(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamLower(OperationId, GarmentTypeId, SamVal);
        }
        public int InsertUpdateStichingOBLower(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBLower(OperationId, OperationVal, Flag);
        }

        //For Stiching bottom 
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingOBbottom(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingOBbottom(OperationId);
        }
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpacebottom(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId);  
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingOBbottom(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END

        public DataTable GetStichingOBSambottom(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSambottom(OperationId, GarmentTypeId);
        }
        public int InsertStichingbottm(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingbottm(OperationVal);
        }
        public int InsertUpdateStichingOBSambottom(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSambottom(OperationId, GarmentTypeId, SamVal);
        }
        public int InsertUpdateStichingOBbottom(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBbottom(OperationId, OperationVal, Flag);
        }

        //For Stiching assembly  
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingOBassembly(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingOBassembly(OperationId);
        }

        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpaceassembly(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId);  
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingOBassembly(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END

        //Added By Ashish on 10/8/2015
        public DataTable GetStichingAddMachine(int OperationId, int GarmentTypeId, string Table1, string Table2, string Col1, string Col2, string Col3, string Col4, string Flag)
        {
            return this.AdminDataProviderInstance.GetStichingAddMachine(OperationId, GarmentTypeId, Table1, Table2, Col1, Col2, Col3, Col4, Flag);
        }
        //END


        public DataTable GetStichingOBSamassembly(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamassembly(OperationId, GarmentTypeId);
        }
        public int InsertStichingassembly(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingassembly(OperationVal);
        }
        public int InsertUpdateStichingOBSamassembly(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamassembly(OperationId, GarmentTypeId, SamVal);
        }
        public int InsertUpdateStichingOBassembly(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBassembly(OperationId, OperationVal, Flag);
        }


        //For Stiching Collor
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingcollerOB(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingcollerOB(OperationId);
        }

        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpacecoller(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingcollerOB(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END
        //END

        public DataTable GetStichingOBSamcoller(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamcoller(OperationId, GarmentTypeId);
        }
        public int InsertStichingcoller(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingcoller(OperationVal);
        }
        public int InsertUpdateStichingOBcoller(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBcoller(OperationId, OperationVal, Flag);
        }

        public int InsertUpdateStichingOBSamcoller(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamcoller(OperationId, GarmentTypeId, SamVal);
        }

        //For Stiching Sleep
        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingsleepOB(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingsleepOB(OperationId);
        }
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpacesleep(int OperationId)
        {
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingsleepOB(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END
        //END
        public DataTable GetStichingOBSamsleep(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamsleep(OperationId, GarmentTypeId);
        }
        public int InsertStichingsleep(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingsleep(OperationVal);
        }

        public int InsertUpdateStichingOBsleep(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBsleep(OperationId, OperationVal, Flag);
        }

        public int InsertUpdateStichingOBSamsleep(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamsleep(OperationId, GarmentTypeId, SamVal);
        }

        //For All Section 
        //For piping
        public DataTable GetStichedSection()
        {
            return this.AdminDataProviderInstance.GetStichedSection();
        }

        public int InsertUpdateStichingOBSamAll(int OperationId, string GarmentTypeId, string SamVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamAll(OperationId, GarmentTypeId, SamVal, Flag);
        }
        //public int InsertUpdateStichingOBSamAll_IsVA(int OperationId, string GarmentTypeId, string SamVal, string Flag, int IsVA)
        //{
        //    return this.AdminDataProviderInstance.InsertUpdateStichingOBSamAllIsVA(OperationId, GarmentTypeId, SamVal, Flag, IsVA);
        //}
        public int InsertUpdateStichingOBALL(int OperationId, string OperationVal, string Flag, string gridFlag)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBALL(OperationId, OperationVal, Flag, gridFlag);
        }

        public int InsertOpationStichingAll(string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertOpationStichingAll(OperationVal, Flag);
        }


        //Edited By Ashish on 26/6/2015
        public DataSet GetMachineStichingAll(int OperationId, string Flag)
        {
            return this.AdminDataProviderInstance.GetMachineStichingAll(OperationId, Flag);
        }
        //Edited By Ashish on 28/6/2015
        public List<OBCutting> GetFactoryWorkSpaceStichingAll(int OperationId, string Flag)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingAll(OperationId, Flag);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        //END


        public DataTable GetStichingOBSamAll(int OperationId, int GarmentTypeId, string Flag)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamAll(OperationId, GarmentTypeId, Flag);
        }
        //END
        //END


        public int InsertUpdateManpowerWorker(int WorkerCount, int ProductionId, int WorkforceId, int id, int catergoryattdence, string ot_date, int Workinghours)
        {
            return this.AdminDataProviderInstance.InsertUpdateManpowerWorker(WorkerCount, ProductionId, WorkforceId, id, catergoryattdence, ot_date, Workinghours);
        }

        public DataTable DailyManpowerAttandence(int UnitId, int FactoryWorkSpaceId, int attendnectype, string Date)
        {
            return this.AdminDataProviderInstance.DailyManpowerAttandence(UnitId, FactoryWorkSpaceId, attendnectype, Date);
        }

        public DataSet GetFactoryUnitType(int FactoryWorkSpace, int AttandenceCategory, string todayDate, int Flag, string Staff)
        {
            return this.AdminDataProviderInstance.GetFactoryUnitType(FactoryWorkSpace, AttandenceCategory, todayDate, Flag, Staff);
        }

        public DataTable Getfactoryworkforce()
        {
            return this.AdminDataProviderInstance.Getfactoryworkforce();
        }

        public DataTable GetProductionHouse()
        {
            return this.AdminDataProviderInstance.GetProductionHouse();
        }
        public DataTable GetmanpowerValueWithoutid()
        {
            return this.AdminDataProviderInstance.GetmanpowerValueWithoutid();
        }
        public int InsertUpdateOTManpower(int WorkerCount, int ProductionId, int WorkforceId, int id, int OTId, string OT_date, int Workinghours)
        {
            return this.AdminDataProviderInstance.InsertUpdateOTManpower(WorkerCount, ProductionId, WorkforceId, id, OTId, OT_date, Workinghours);
        }

        //Added By Ashish on 28/7/2015
        public DataSet GetFactorySubHeader(int FactoryWorkId, int Edit, string Staff)
        {
            return this.AdminDataProviderInstance.GetFactorySubHeader(FactoryWorkId, Edit, Staff);
        }
        public DataTable GetAttendanceGlobalBudget(int OTs, string OTDate)
        {
            return this.AdminDataProviderInstance.GetAttendanceGlobalBudget(OTs, OTDate);
        }
        public DataTable GetManPowerCountByUnitId(int WorkforceId, int ProductionUnit, string OTDate, int OTs)
        {
            return this.AdminDataProviderInstance.GetManPowerCountByUnitId(WorkforceId, ProductionUnit, OTDate, OTs);
        }
        public DataTable GetOtGridData(string Fromdate, string todate, int OperatorUnit, int AttandenceType, int form)
        {
            return this.AdminDataProviderInstance.GetOtGridData(Fromdate, todate, OperatorUnit, AttandenceType, form);
        }
        //Added By abhishek on 29/7/2015
        //---------------------------------------------------------Updated Remarks--------------------------------------------------------------------//

        public DataTable getcountRiskremarks(int orderid)
        {
            return this.AdminDataProviderInstance.getcountRiskremarks(orderid);
        }
        public DataTable getreptedremakrsWithStyleid(int styleid)
        {
            return this.AdminDataProviderInstance.getreptedremakrsWithStyleid(styleid);
        }
        //updated by abhishek on 18/8/2015
        public int insertOrderLimitationremarks(string FabricComments, string Accessoriescomment, int StyleID, string CreatedOn_1, int CreatedBy_1, string stylecode_1, int UpdatedBy_1, string @UpdatedOn_1, int sequenceNo_1, string FabricApprovedOn, string AccessoriesApprovedOn, int OrderId)
        {
            return this.AdminDataProviderInstance.insertOrderLimitationremarks(FabricComments, Accessoriescomment, StyleID, CreatedOn_1, CreatedBy_1, stylecode_1, UpdatedBy_1, @UpdatedOn_1, sequenceNo_1, FabricApprovedOn, AccessoriesApprovedOn, OrderId);
        }
        //end on 17/8/2015


        //---------------------------------------------------------END--------------------------------------------------------------------------------//



        //END

        //added by abhishek on 10/8/2015
        #region this method for line designation admin
        public DataSet getslotdetails()
        {
            return this.AdminDataProviderInstance.getslotdetails();
        }

        public DataSet GetLinedesignationDetails()
        {
            return this.AdminDataProviderInstance.GetLinedesignationDetails();
        }
        public int InsertUpdateLineDesignation(int DesignationID, int factoryId, int IsAct, int UserId, string Name, int stiching, int finishing, int cutting)
        {
            return this.AdminDataProviderInstance.InsertUpdateLineDesignation(DesignationID, factoryId, IsAct, UserId, Name, stiching, finishing, cutting);
        }
        public int updateSlot(int DesignationID, int factoryId, int IsAct, int UserId, string Name, int id, int stiching, int finishing, int cutting)
        {
            return this.AdminDataProviderInstance.updateSlot(DesignationID, factoryId, IsAct, UserId, Name, id, stiching, finishing, cutting);
        }
        #endregion
        #region this method for loss distribution
        public DataTable GetLossDistributionDetails()
        {
            return this.AdminDataProviderInstance.GetLossDistributionDetails();
        }
        public int InsertLossLineDesignation(int DeptID, int Isactive, int UserId, int stiching, int finishing, int cutting)
        {
            return this.AdminDataProviderInstance.InsertLossLineDesignation(DeptID, Isactive, UserId, stiching, finishing, cutting);
        }
        public int UpdateLossDesignation(int Dept_name, int Isactive, int UserId, int id, int stiching, int finishing, int cutting)
        {
            return this.AdminDataProviderInstance.UpdateLossDesignation(Dept_name, Isactive, UserId, id, stiching, finishing, cutting);
        }
        //for slot admin
        public DataTable GetslotadminDetails()
        {
            return this.AdminDataProviderInstance.GetslotadminDetails();
        }
        public string insertslotdetails(string SlotName, int TypeOfSlot, string StartHH, string startMM, string EndtimeHH, string EndtimeMM)
        {
            return this.AdminDataProviderInstance.insertslotdetails(SlotName, TypeOfSlot, StartHH, startMM, EndtimeHH, EndtimeMM);
        }

        public string updateSlotadmin(string SlotName, int TypeOfSlot, string start_HH, string start_MM, string End_HH, string End_MM, int id)
        {
            return this.AdminDataProviderInstance.Updateslotadmin(SlotName, TypeOfSlot, start_HH, start_MM, End_HH, End_MM, id);
        }
        //abhishek 19/10/2015
        public string SlotExistCheck(string SlotName, int SlotID)
        {
            return AdminDataProviderInstance.SlotExistCheck(SlotName, SlotID);
        }
        //end abhishek 19/10/2015
        public DataTable getfillterrecord(string Searchtxt, int IsAct)
        {
            return this.AdminDataProviderInstance.getfillterrecord(Searchtxt, IsAct);
        }
        #endregion
        //---------------------------------------------------------END--------------------------------------------------------------------------------//
        //Added By Ashish on 14/8/2015
        public DataSet GetDesignationName()
        {
            return this.AdminDataProviderInstance.GetDesignationName();
        }
        public DataSet GetFactorynames(int FactoryId, string strId)
        {
            return this.AdminDataProviderInstance.GetFactorynames(FactoryId, strId);
        }

        public DataSet GetFactorySpecificDetails(int Id, int LineDesignationID)
        {
            return this.AdminDataProviderInstance.GetFactorySpecificDetails(Id, LineDesignationID);
        }
        //abhishek 
        public DataSet GetFactorySpecificDetailsforcluster(int Id, int LineDesignationID)
        {
            return this.AdminDataProviderInstance.GetFactorySpecificDetailsforcluster(Id, LineDesignationID);
        }
        public DataSet GetDesignationNamecluster()
        {
            return this.AdminDataProviderInstance.GetDesignationNamecluster();
        }
        public DataTable GetFactoryLineFloor_IsClosedDetails(int UnitId, int LineNo)
        {
            return this.AdminDataProviderInstance.GetFactoryLineFloor_IsClosedDetails(UnitId, LineNo);
        }

        public DataTable GetFactoryLineDesignationDetails(int UnitId, int LineNo, int LineDesignationId)
        {
            return this.AdminDataProviderInstance.GetFactoryLineDesignationDetails(UnitId, LineNo, LineDesignationId);
        }
        public DataTable GetFactoryLineDesignationDetailscluster(int UnitId, int LineNo, int LineDesignationId)
        {
            return this.AdminDataProviderInstance.GetFactoryLineDesignationDetailscluster(UnitId, LineNo, LineDesignationId);
        }
        public DataTable GetFactorySpecificLinePlanningDetails(int FactoryId)
        {
            return this.AdminDataProviderInstance.GetFactorySpecificLinePlanningDetails(FactoryId);
        }

        public DataTable GetStartDate(int UnitId, int LineNo, int LinePlanFrameId, int SeqFrameId, bool IsParallel)
        {
            return this.AdminDataProviderInstance.GetStartDate(UnitId, LineNo, LinePlanFrameId, SeqFrameId, IsParallel);
        }

        public bool CheckIsLineVacent(int UnitId, int LineNo)
        {
            return this.AdminDataProviderInstance.CheckIsLineVacent(UnitId, LineNo);
        }

        public DataTable GetDesignationNameDetails(int FactoryId, int DesignationId)
        {
            return this.AdminDataProviderInstance.GetDesignationNameDetails(FactoryId, DesignationId);
        }

        public DataTable GetStyleSam_OB(int StyleId)
        {
            return this.AdminDataProviderInstance.GetStyleSam_OB(StyleId);
        }

        public DataTable GetSerialNumber(int UnitId, int StyleId, string Status)
        {
            return this.AdminDataProviderInstance.GetSerialNumber(UnitId, StyleId, Status);
        }

        public DataTable GetContract(int UnitId, int OrderId, string Status, int LineNo)
        {
            return this.AdminDataProviderInstance.GetContract(UnitId, OrderId, Status, LineNo);
        }

        public DataTable GetDateAndQty(int UnitId, int OrderId, int ContractId, string Status, int LineNo)
        {
            return this.AdminDataProviderInstance.GetDateAndQty(UnitId, OrderId, ContractId, Status, LineNo);
        }

        public DataTable GetSlot()
        {
            return this.AdminDataProviderInstance.GetSlot();
        }

        public DataTable GetHalfStitchDetails(int UnitId)
        {
            return this.AdminDataProviderInstance.GetHalfStitchDetails(UnitId);
        }

        public DataTable FillManageDesignation()
        {
            return this.AdminDataProviderInstance.FillManageDesignation();
        }

        public DataTable FillDepartmentDetails(int DepartmentId)
        {
            return this.AdminDataProviderInstance.FillDepartmentDetails(DepartmentId);
        }

        public bool CheckDepartmentIsAciveEnable(int DepartmentId)
        {
            return this.AdminDataProviderInstance.CheckDepartmentIsAciveEnable(DepartmentId);
        }

        public DataTable FillDivisionDetails()
        {
            return this.AdminDataProviderInstance.FillDivisionDetails();
        }

        public DataTable FillDesignationDetails(int DepartmentId)
        {
            return this.AdminDataProviderInstance.FillDesignationDetails(DepartmentId);
        }

        public DataSet GetStitchingManpowerDetail(int StyleId, int LinePlanFrameId, int CombinedFrameId)
        {
            return this.AdminDataProviderInstance.GetStitchingManpowerDetail(StyleId, LinePlanFrameId, CombinedFrameId);
        }
        public DataTable GetOperationName(int LinePlanFrameId, int CombinedFrameId)
        {
            return this.AdminDataProviderInstance.GetOperationName(LinePlanFrameId, CombinedFrameId);
        }

        public DataTable FillDesignationTypeDetails()
        {
            return this.AdminDataProviderInstance.FillDesignationTypeDetails();
        }

        public bool CheckIsDesignationAvailable(int DepartmentId, string DesignationName)
        {
            return this.AdminDataProviderInstance.CheckIsDesignationAvailable(DepartmentId, DesignationName);
        }

        public bool CheckIsLineDesignationAvailable(int DesignationId, int LineDesignationId)
        {
            return this.AdminDataProviderInstance.CheckIsLineDesignationAvailable(DesignationId, LineDesignationId);
        }

        public bool CheckIsRestrictDepartmentAvailable(int DepartmentId, int ApplicationModuleId)
        {
            return this.AdminDataProviderInstance.CheckIsRestrictDepartmentAvailable(DepartmentId, ApplicationModuleId);
        }

        public int GetPermissionType(int DepartmentId, int DesignationId, int ApplicationModuleId)
        {
            return this.AdminDataProviderInstance.GetPermissionType(DepartmentId, DesignationId, ApplicationModuleId);
        }

        public DataTable GetPermissionType(int ApplicationModuleId)
        {
            return this.AdminDataProviderInstance.GetPermissionType(ApplicationModuleId);
        }

        public DataTable GetDepartmentActive(int DepartmentId)
        {
            return this.AdminDataProviderInstance.GetDepartmentActive(DepartmentId);
        }

        public DataTable FillDesignationTypeDetails(int DepartmentId)
        {
            return this.AdminDataProviderInstance.FillDesignationTypeDetails(DepartmentId);
        }

        public DataTable GetPermissionType(int DepartmentId, int ApplicationModuleId)
        {
            return this.AdminDataProviderInstance.GetPermissionType(DepartmentId, ApplicationModuleId);
        }

        public DataTable GetApplicationModuleDetails()
        {
            return this.AdminDataProviderInstance.GetApplicationModuleDetails();
        }

        public int GetApplicationDEfaultLandingPageId(int DepartmentId, int DesignationId)
        {
            return this.AdminDataProviderInstance.GetApplicationDEfaultLandingPageId(DepartmentId, DesignationId);
        }

        public DataTable GetMenuShowDepartmentDetails()
        {
            return this.AdminDataProviderInstance.GetMenuShowDepartmentDetails();
        }

        public int GetMenuShowDepartment(int ApplicationModuleId)
        {
            return this.AdminDataProviderInstance.GetMenuShowDepartment(ApplicationModuleId);
        }

        public bool GetRestrictDepartment(int ApplicationModuleId, int DepartmentId)
        {
            return this.AdminDataProviderInstance.GetRestrictDepartment(ApplicationModuleId, DepartmentId);
        }

        public int AddDepartment(string DepartmentName, int DivisionId, bool IsActive)
        {
            return this.AdminDataProviderInstance.AddDepartment(DepartmentName, DivisionId, IsActive);
        }

        public int AddDesignation(string DesignationName, int DepartmentId, int GlobalType, int LineDesignationId)
        {
            return this.AdminDataProviderInstance.AddDesignation(DesignationName, DepartmentId, GlobalType, LineDesignationId);
        }

        public int UpdateDesignation(int DesignationId, string DesignationName, int GlobalType, int LineDesignationId)
        {
            return this.AdminDataProviderInstance.UpdateDesignation(DesignationId, DesignationName, GlobalType, LineDesignationId);
        }

        public string UpdatePermission(int PermissionType, int DepartmentId, int DesignationId, int ApplicationModuleId)
        {
            return this.AdminDataProviderInstance.UpdatePermission(PermissionType, DepartmentId, DesignationId, ApplicationModuleId);
        }

        public int UpdateDefaultLandingPage(int DepartmentId, int DesignationId, int ApplicationModuleId)
        {
            return this.AdminDataProviderInstance.UpdateDefaultLandingPage(DepartmentId, DesignationId, ApplicationModuleId);
        }

        public int UpdateDeparmentActive(int DepartmentId, bool IsActive)
        {
            return this.AdminDataProviderInstance.UpdateDeparmentActive(DepartmentId, IsActive);
        }

        public string UpdateRestrictDepartment(int ApplicationModuleId, int DepartmentId, bool IsActive)
        {
            return this.AdminDataProviderInstance.UpdateRestrictDepartment(ApplicationModuleId, DepartmentId, IsActive);
        }

        public string UpdateApplicationModuleIsActive(int ApplicationModuleId, bool IsActive)
        {
            return this.AdminDataProviderInstance.UpdateApplicationModuleIsActive(ApplicationModuleId, IsActive);
        }

        public int UpdateMenuShowDepartment(int ApplicationModuleId, int DepartmentId)
        {
            return this.AdminDataProviderInstance.UpdateMenuShowDepartment(ApplicationModuleId, DepartmentId);
        }

        public int UpdateDesignationOrder(int OrderId, int DepartmentId, int DesignationId)
        {
            return this.AdminDataProviderInstance.UpdateDesignationOrder(OrderId, DepartmentId, DesignationId);
        }

        public int UpdateFactoryLineStatus(int UnitId, int FloorNoId, int LineNoId, bool IsClosed, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateFactoryLineStatus(UnitId, FloorNoId, LineNoId, IsClosed, UserId);
        }

        public int UpdateLineFloor(int UnitId, int FloorNoId, int LineNoId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateLineFloor(UnitId, FloorNoId, LineNoId, UserId);
        }

        public int UpdateLineIsClosed(int UnitId, int FloorNoId, int LineNoId, bool IsClosed, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateLineIsClosed(UnitId, FloorNoId, LineNoId, IsClosed, UserId);
        }

        public int UpdateLineStatusDesignation(int UnitId, int LineNoId, int LineDesignationId, string DesignationName, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateLineStatusDesignation(UnitId, LineNoId, LineDesignationId, DesignationName, UserId);
        }

        public int UpdateLineDesignation(int UnitId, int FloorNoId, int LineNoId, int LineDesignationId, int LineNameId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateLineDesignation(UnitId, FloorNoId, LineNoId, LineDesignationId, LineNameId, UserId);
        }

        //public int InsertLinePlanning(int UnitId, int FloorNoId, int LineNoId, int StyleId, int OrderId, int OrderDetailId, DateTime StartDate, int SlotId, int ContractQty, int StichedQty, int StichedPer, int UnitQty, int LineQty, decimal Sam, int LinePlanFrameId, int CombinedFrameId, int UserId, bool IshalfStitch,
        //    int OB, decimal FinishSam, int FinishOB, bool DoubleOB_Stitch, bool DoubleOB_Finish) //, bool IshalfFinish
        //{
        //    return this.AdminDataProviderInstance.InsertLinePlanning(UnitId, FloorNoId, LineNoId, StyleId, OrderId, OrderDetailId, StartDate, SlotId, ContractQty, StichedQty, StichedPer, UnitQty, LineQty, Sam, LinePlanFrameId, CombinedFrameId, UserId, IshalfStitch, OB, FinishSam, FinishOB, DoubleOB_Stitch, DoubleOB_Finish);
        //}

        public int AddDuplicateHalfStitch(int UnitId, int FloorNoId, int LineNoId, DateTime StartDate, int SlotId, int LinePlanFrameId, int UserId)
        {
            return this.AdminDataProviderInstance.AddDuplicateHalfStitch(UnitId, FloorNoId, LineNoId, StartDate, SlotId, LinePlanFrameId, UserId);
        }

        //public int DeleteHalfStitch(int LinePlanFrameId)
        //{
        //    return this.AdminDataProviderInstance.DeleteHalfStitch(LinePlanFrameId);
        //}

        public int UpdateHalfStitching(int StyleId, int LinePlanFrameId, string FactoryWorkSpace, string WorkerType, bool IsCheckedStitched, int OperationID, double StitchSAM, double MachineCalc, int FinalOB, int CombinedFrameId, string OperationType)
        {
            return this.AdminDataProviderInstance.UpdateHalfStitching(StyleId, LinePlanFrameId, FactoryWorkSpace, WorkerType, IsCheckedStitched, OperationID, StitchSAM, MachineCalc, FinalOB, CombinedFrameId, OperationType);
        }
        public int UpdateHalfStitchingOperation(int LinePlanFrameId, string OperationName)
        {
            return this.AdminDataProviderInstance.UpdateHalfStitchingOperation(LinePlanFrameId, OperationName);
        }

        //public int UpdateStitchingSam(int StyleId, int LinePlanFrameId)
        //{
        //    return this.AdminDataProviderInstance.UpdateStitchingSam(StyleId, LinePlanFrameId);
        //}

        public int CloseTask(int UnitId, int UserId)
        {
            return this.AdminDataProviderInstance.CloseTask(UnitId, UserId);
        }

        //public int UpdateEndDate()
        //{
        //    return this.AdminDataProviderInstance.UpdateEndDate();
        //}

        //public int DeleteLinePlanning_Update(int UnitId, int FloorNoId, int LineNoId, int StyleId, int LinePlanFrameId)
        //{
        //    return this.AdminDataProviderInstance.DeleteLinePlanning_Update(UnitId, FloorNoId, LineNoId, StyleId, LinePlanFrameId);
        //}

        public int CheckLinePlanning(int UnitId, int FloorNoId, int LineNoId, int StyleId, int OrderDetailId)
        {
            return this.AdminDataProviderInstance.CheckLinePlanning(UnitId, FloorNoId, LineNoId, StyleId, OrderDetailId);
        }

        public int CheckLineStatus(int UnitId, int FloorNoId, int LineNoId)
        {
            return this.AdminDataProviderInstance.CheckLineStatus(UnitId, FloorNoId, LineNoId);
        }

        public int TotalLineQty(int UnitId, int LineNo, int OrderDetailId)
        {
            return this.AdminDataProviderInstance.TotalLineQty(UnitId, LineNo, OrderDetailId);
        }

        public DateTime CheckStartDate(DateTime StartDate, int SlotId)
        {
            return this.AdminDataProviderInstance.CheckStartDate(StartDate, SlotId);
        }

        public bool CheckIsAvailableSlot(int UnitId, int FloorNoId, int LineNoId, DateTime StartDate, int SlotId, int LinePlanFrameId)
        {
            return this.AdminDataProviderInstance.CheckIsAvailableSlot(UnitId, FloorNoId, LineNoId, StartDate, SlotId, LinePlanFrameId);
        }

        public bool CheckIsAvailableFrame(int LinePlanFrameId)
        {
            return this.AdminDataProviderInstance.CheckIsAvailableFrame(LinePlanFrameId);
        }

        public bool CheckIsHalfStitched(int LinePlanFrameId)
        {
            return this.AdminDataProviderInstance.CheckIsHalfStitched(LinePlanFrameId);
        }

        public int InsertFactoryLine(int Id, int FactoryUnitId, int FloorId, int LineId, string DesignationName, int designationId)
        {
            return AdminDataProviderInstance.InsertFactoryLine(Id, FactoryUnitId, FloorId, LineId, DesignationName, designationId);
        }

        public int InsertLine(int Id, int FactoryUnitId, int FloorId, int LineNo)
        {
            return AdminDataProviderInstance.InsertLine(Id, FactoryUnitId, FloorId, LineNo);
        }

        public DataTable CheckFacrotyUnit(int FactoryUnitId)
        {
            return AdminDataProviderInstance.CheckFacrotyUnit(FactoryUnitId);
        }


        public int FactoryisClosed(int Id, string isClose)
        {
            return AdminDataProviderInstance.FactoryisClosed(Id, isClose);
        }

        // Added by Ravi kumar on 28/8/15

        public int InsertAttandanceOT_Split(int AttandanceOTid, int ProductionUnit, int FactoryWorkSpace, int WorkerCount, string AttandenceDate, int OTType, int OT_Count, double OT_Hours, int UserId)
        {
            return this.AdminDataProviderInstance.InsertAttandanceOT_Split(AttandanceOTid, ProductionUnit, FactoryWorkSpace, WorkerCount, AttandenceDate, OTType, OT_Count, OT_Hours, UserId);
        }

        public DataTable GetAttandanceOT_Split(int ProductionUnit, int FactoryWorkSpace, string AttandenceDate, int OTType)
        {
            return this.AdminDataProviderInstance.GetAttandanceOT_Split(ProductionUnit, FactoryWorkSpace, AttandenceDate, OTType);
        }

        public string GetFactoryWorkerSpace(int FactoryWorkSpaceId)
        {
            return this.AdminDataProviderInstance.GetFactoryWorkerSpace(FactoryWorkSpaceId);
        }

        public int DeleteAttandanceOT_Split(int AttandanceOTid)
        {
            return AdminDataProviderInstance.DeleteAttandanceOT_Split(AttandanceOTid);
        }

        public DataTable Get_DailyManpowerAttandence(int ProductionUnit, int WorkforceId, string OTDate, int OTs)
        {
            return this.AdminDataProviderInstance.Get_DailyManpowerAttandence(ProductionUnit, WorkforceId, OTDate, OTs);
        }

        public int Check_WorkCount_Attandance(int ProductionUnit, int WorkforceId, string OTDate, int OTs, int WorkerCount)
        {
            return this.AdminDataProviderInstance.Check_WorkCount_Attandance(ProductionUnit, WorkforceId, OTDate, OTs, WorkerCount);
        }

        public int DeleteAll_AttandanceOT_Split(int ProductionUnit, int WorkforceId, string OTDate, int OTType)
        {
            return AdminDataProviderInstance.DeleteAll_AttandanceOT_Split(ProductionUnit, WorkforceId, OTDate, OTType);
        }

        // added by abhishek on 3/9/2015-----------------------------------------------------------------//
        //for new neck section

        public int InsertStichingNeck(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingNeck(OperationVal);
        }

        public int InsertUpdateNecksectionOB(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateNecksectionOB(OperationId, OperationVal, Flag);
        }
        public List<OBCutting> GetFactoryWorkSpaceNeckSection(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetMachineStichingOB_necksection(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        public DataSet GetMachineStichingOB_necksection(int OperationId)
        {
            return this.AdminDataProviderInstance.GetMachineStichingOB_necksection(OperationId);
        }
        public DataTable GetStichingOBSamNeck_Nec_Section(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamNeck_Nec_Section(OperationId, GarmentTypeId);
        }
        public int InsertUpdateStichingOBSamNeck_section(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamNeck_section(OperationId, GarmentTypeId, SamVal);
        }
        //end neck section

        //neck faching section--------------------------------------------------//

        public int InsertStichingNeck_faching(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingNeckfaching(OperationVal);
        }

        public int InsertUpdateNecksectionOB_faching(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateNeckfachingOB(OperationId, OperationVal, Flag);
        }
        public List<OBCutting> GetFactoryWorkSpaceNeckSection_faching(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetFactoryWorkSpaceNeck_faching(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        public DataSet GetMachineStichingOB_necksection_faching(int OperationId)
        {
            return this.AdminDataProviderInstance.GetFactoryWorkSpaceNeck_faching(OperationId);
        }
        public DataTable GetStichingOBSamNeck_Nec_Section_faching(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamNeck_Nec_faching(OperationId, GarmentTypeId);
        }
        public int InsertUpdateStichingOBSamNeck_section_faching(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamNeck_neckfaching(OperationId, GarmentTypeId, SamVal);
        }

        //end neck faching section

        //front and back section

        public int InsertStichingNeck_faching_frontback(string OperationVal)
        {
            return this.AdminDataProviderInstance.InsertStichingNeckfaching_frontback(OperationVal);
        }

        public int InsertUpdateNecksectionOB_frontback(int OperationId, string OperationVal, string Flag)
        {
            return this.AdminDataProviderInstance.InsertUpdateNeckfachingOB_frontback(OperationId, OperationVal, Flag);
        }
        public List<OBCutting> GetFactoryWorkSpaceNeckSection_frontback(int OperationId)
        {
            //return this.AdminDataProviderInstance.GetMachineOB(OperationId); 
            List<OBCutting> OBCut = new List<OBCutting>();

            DataSet dsDescription = new DataSet();
            dsDescription = AdminDataProviderInstance.GetFactoryWorkSpaceNeck_faching_frontback(OperationId);
            if (dsDescription.Tables[1].Rows.Count > 0)
            {
                int count = dsDescription.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    OBCutting OBOperation = new Common.Entities.OBCutting();
                    OBOperation.Description = dsDescription.Tables[1].Rows[i]["FactoryWorkSpace"].ToString();

                    OBCut.Add(OBOperation);
                }

            }
            return OBCut;
        }
        public DataSet GetMachineStichingOB_necksection_frontback(int OperationId)
        {
            return this.AdminDataProviderInstance.GetFactoryWorkSpaceNeck_faching_frontback(OperationId);
        }
        public DataTable GetStichingOBSamNeck_Nec_Section_frontback(int OperationId, int GarmentTypeId)
        {
            return this.AdminDataProviderInstance.GetStichingOBSamNeck_Nec_faching_frontback(OperationId, GarmentTypeId);
        }
        public int InsertUpdateStichingOBSamNeck_section_frontback(int OperationId, string GarmentTypeId, string SamVal)
        {
            return this.AdminDataProviderInstance.InsertUpdateStichingOBSamNeck_neckfaching_frontback(OperationId, GarmentTypeId, SamVal);
        }
        //end front and back section
        //end by abhishek 3/9/2015------------------------------------------------------------------------//

        public DataTable GetFactorynames(int Unitid, int Id)
        {
            return this.AdminDataProviderInstance.GetFactorynames(Unitid, Id);
        }
        public DataTable GetFactorynamesforfoter(int Unitid)
        {
            return this.AdminDataProviderInstance.GetFactorynamesforfoter(Unitid);
        }
        //abhishek added 29/10/2015
        public int getProdctionID(int ProdouctionUnitId)
        {
            return this.AdminDataProviderInstance.getProdctionID(ProdouctionUnitId);
        }
        public DataTable getProdctionID_get()
        {
            return this.AdminDataProviderInstance.getProdctionID_get();
        }
        //end by abhishek 29/10/2015-----------------------------------------------------------------------//
        //abhishek added 29/10/2015

        public DataTable BindDepartmentDdl()
        {
            return this.AdminDataProviderInstance.BindDepartmentDdl();
        }
        public DataTable getdepartment()
        {
            return this.AdminDataProviderInstance.getdepartment();
        }
        public DataTable GetEmailGroupPerioty(int emailid)
        {
            return this.AdminDataProviderInstance.GetEmailGroupPerioty(emailid);
        }
        public DataTable FillTargetAdmin(bool IsPredecessorApplied)
        {
            return this.AdminDataProviderInstance.FillTargetAdmin(IsPredecessorApplied);
        }

        public DataTable FillEmailDetails()
        {
            return this.AdminDataProviderInstance.FillEmailDetails();
        }

        public DataTable FillFromStatus(int SrNo)
        {
            return this.AdminDataProviderInstance.FillFromStatus(SrNo);
        }

        public DataTable GetClientDetails(int Filter)
        {
            return this.AdminDataProviderInstance.GetClientDetails(Filter);
        }

        public DataTable GetClientDetails(string ClientIds, int HeaderType, int UserId)
        {
            return this.AdminDataProviderInstance.GetClientDetails(ClientIds, HeaderType, UserId);
        }

        public DataTable GetDays_PredecessorDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.GetDays_PredecessorDetails(StatusModeId, ClientId);
        }

        public DataTable FillPredecessorDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.FillPredecessorDetails(StatusModeId, ClientId);
        }

        public DataTable FillDesignationDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.FillDesignationDetails(StatusModeId, ClientId);
        }

        public DataTable FillDirectTaskDesignationDetails(int StatusModeId)
        {
            return this.AdminDataProviderInstance.FillDirectTaskDesignationDetails(StatusModeId);
        }

        public DataTable FillEmailDesignationDetails(int EmailId, int ClientId)
        {
            return this.AdminDataProviderInstance.FillEmailDesignationDetails(EmailId, ClientId);
        }

        public DataTable GetDesignationDetails(int DesignationId)
        {
            return this.AdminDataProviderInstance.GetDesignationDetails(DesignationId);
        }

        public DataTable GetDesignationDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.GetDesignationDetails(StatusModeId, ClientId);
        }

        public DataTable GetDirectTasksDesignationDetails(int StatusModeId)
        {
            return this.AdminDataProviderInstance.GetDirectTasksDesignationDetails(StatusModeId);
        }

        public DataTable GetEmailDesignationDetails(int EmailId, int ClientId)
        {
            return this.AdminDataProviderInstance.GetEmailDesignationDetails(EmailId, ClientId);
        }

        public int GetEmailPermissionDetails(int EmailId, int ClientId)
        {
            return this.AdminDataProviderInstance.GetEmailPermissionDetails(EmailId, ClientId);
        }

        public DataTable FillNotificationDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.FillNotificationDetails(StatusModeId, ClientId);
        }

        public DataTable FillMOFilterNotificationDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.FillMOFilterNotificationDetails(StatusModeId, ClientId);
        }

        public DataTable FillDelayNotificationDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.FillDelayNotificationDetails(StatusModeId, ClientId);
        }

        public DataTable GetNotificationDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.GetNotificationDetails(StatusModeId, ClientId);
        }

        public DataTable GetMOFilterNotificationDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.GetMOFilterNotificationDetails(StatusModeId, ClientId);
        }

        public DataTable GetDelayNotificationDetails(int StatusModeId, int ClientId)
        {
            return this.AdminDataProviderInstance.GetDelayNotificationDetails(StatusModeId, ClientId);
        }

        public DataTable GetDescriptionDetails(int StatusModeId)
        {
            return this.AdminDataProviderInstance.GetDescriptionDetails(StatusModeId);
        }

        public DataTable GetCopyFromDataDetails(int ClientId)
        {
            return this.AdminDataProviderInstance.GetCopyFromDataDetails(ClientId);
        }

        public DataTable GetCopyFromEmailDataDetails(int ClientId)
        {
            return this.AdminDataProviderInstance.GetCopyFromEmailDataDetails(ClientId);
        }

        public DataTable GetFilteredClientDetails(int Filter, int UserId)
        {
            return this.AdminDataProviderInstance.GetFilteredClientDetails(Filter, UserId);
        }

        public DataTable FillEmailPlanDetails()
        {
            return this.AdminDataProviderInstance.FillEmailPlanDetails();
        }

        public DataTable GetEmailPlanDetails()
        {
            return this.AdminDataProviderInstance.GetEmailPlanDetails();
        }

        public int UpdateFromStatus(int StatusId, int FromStatusId)
        {
            return this.AdminDataProviderInstance.UpdateFromStatus(StatusId, FromStatusId);
        }

        public int UpdateIsRelevantToNewsLetter(int StatusId, bool IsRelevantToNewsLetter)
        {
            return this.AdminDataProviderInstance.UpdateIsRelevantToNewsLetter(StatusId, IsRelevantToNewsLetter);
        }

        public int UpdateIsRelevantToDelays(int StatusId, bool IsRelevantToDelays)
        {
            return this.AdminDataProviderInstance.UpdateIsRelevantToDelays(StatusId, IsRelevantToDelays);
        }

        public int UpdateStatusOrder(int StatusId, int OrderId)
        {
            return this.AdminDataProviderInstance.UpdateStatusOrder(StatusId, OrderId);
        }

        public int UpdateDays(int StatusId, int ClientId, int Days, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateDays(StatusId, ClientId, Days, UserId);
        }

        public int UpdatePredecessor(int StatusId, int ClientId, string Predecessor, int UserId)
        {
            return this.AdminDataProviderInstance.UpdatePredecessor(StatusId, ClientId, Predecessor, UserId);
        }

        public int UpdateDesignation(int StatusId, int ClientId, string DesignationId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateDesignation(StatusId, ClientId, DesignationId, UserId);
        }

        public int UpdateDirectTaskDesignation(int StatusId, string DesignationId)
        {
            return this.AdminDataProviderInstance.UpdateDirectTaskDesignation(StatusId, DesignationId);
        }

        public int UpdateEmailDesignation(int EmailId, int ClientId, string DesignationId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateEmailDesignation(EmailId, ClientId, DesignationId, UserId);
        }

        public int UpdateNotification(int StatusId, int ClientId, string DesignationId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateNotification(StatusId, ClientId, DesignationId, UserId);
        }

        public int UpdateMOFilterNotification(int StatusId, int ClientId, string DesignationId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateMOFilterNotification(StatusId, ClientId, DesignationId, UserId);
        }

        public int UpdateDelayNotification(int StatusId, int ClientId, string DesignationId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateDelayNotification(StatusId, ClientId, DesignationId, UserId);
        }

        public int AddApplicationModule()
        {
            return this.AdminDataProviderInstance.AddApplicationModule();
        }

        public int UpdateCopyFrom(int ClientId, int SelectedClientId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateCopyFrom(ClientId, SelectedClientId, UserId);
        }

        public int UpdateCopyFromEmail(int ClientId, int SelectedClientId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateCopyFromEmail(ClientId, SelectedClientId, UserId);
        }

        public int UpdateTargetAdminDescription(int StatusId, string Description)
        {
            return this.AdminDataProviderInstance.UpdateTargetAdminDescription(StatusId, Description);
        }

        public int UpdateEmailPermission(int EmailId, int ClientId, int PermissionType, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateEmailPermission(EmailId, ClientId, PermissionType, UserId);
        }
        public int UpdateEmailPlan(int EmailId, int EmailPlanId)
        {
            return this.AdminDataProviderInstance.UpdateEmailPlan(EmailId, EmailPlanId);
        }
        public string UpdateEmailPerority(int EmailId, int EmailPlanId)
        {
            return this.AdminDataProviderInstance.UpdateEmailPerority(EmailId, EmailPlanId);
        }
        public int UpdateEmailIsGroup(int EmailId, int EmailPlanId)
        {
            return this.AdminDataProviderInstance.UpdateEmailIsGroup(EmailId, EmailPlanId);
        }
        public int UpdateEmailTime(int EmailId, string Hours, string Min, string Meridian)
        {
            return this.AdminDataProviderInstance.UpdateEmailTime(EmailId, Hours, Min, Meridian);
        }
        public int UpdateEmailDays(int EmailId, string Days)
        {
            return this.AdminDataProviderInstance.UpdateEmailDays(EmailId, Days);
        }
        // Add By Ravi kumar on 18/1/2016 for new status modes
        public List<StatusModes> GetAllStatusModesByUserId(int UserId)
        {
            return this.AdminDataProviderInstance.GetAllStatusModesByUserId(UserId);
        }
        public List<StatusModes> GetAllStatusModesByUserId_ForSequence(int UserId)
        {
            return this.AdminDataProviderInstance.GetAllStatusModesByUserId_ForSequence(UserId);
        }
        //added by abhishek on 20/1/2016
        //public List<StatusModes> GetAllStatusModesByUserId_New(int UserId, int DataType, string Year, int BuyingHouseID, int ClientID, int DepartmentID)
        //{
        //    return this.AdminDataProviderInstance.GetAllStatusModesByUserId(UserId, DataType, Year, BuyingHouseID, ClientID, DepartmentID);
        //}
        //end by abhishek on 20/1/2016

        //added by abhishek on 16/6/2016
        public List<productionCalender> GetProductionCalenderDetails(int month, int year)
        {
            return this.AdminDataProviderInstance.GetProductionCalenderDetails(month, year);
        }
        public int UpdateInsertProdPlan_Calender(int CalenderID, int MonthNo, int year, int DayNo, bool Isvent, string workinghours, string eventdiscriptiontext)
        {
            return this.AdminDataProviderInstance.UpdateInsertProdPlan_Calender(CalenderID, MonthNo, year, DayNo, Isvent, workinghours, eventdiscriptiontext);
        }
        public int UpdateWorkingHrs(int Month, int Year, double workingHrs)
        {
            return this.AdminDataProviderInstance.UpdateWorkingHrs(Month, Year, workingHrs);
        }
        public DataTable GetHolidayDetails(int calenderID, double DyaNo, int MonthNo, int Year)
        {
            return this.AdminDataProviderInstance.GetHolidayDetails(calenderID, DyaNo, MonthNo, Year);
        }
        public DataTable GetworkingHrs(int month, int Year)
        {
            return this.AdminDataProviderInstance.GetworkingHrs(month, Year);
        }
        public DataSet GetShipmetReport(string flag)
        {
            return this.AdminDataProviderInstance.GetShipmetReport(flag);
        }
        public DataSet GetTopQaFualtReport(int UnitID, int Duration, string type)
        {
            return this.AdminDataProviderInstance.GetTopQaFualtReport(UnitID, Duration, type);
        }
        public DataSet GetTopQaFualtReport__top3FualtSummary(int UnitID, int Duration, string type, int OrderID, int LineNo)
        {
            return this.AdminDataProviderInstance.GetTopQaFualtReport__top3FualtSummary(UnitID, Duration, type, OrderID, LineNo);
        }
        //end by abhishek on 16/6/2016
        //added by abhishek on 25/7/2016
        public DataSet GetWastageVAdetails()
        {
            return this.AdminDataProviderInstance.GetWastageVAdetails();
        }
        //Add By Prabhaker On 28-sep-18
        public DataSet GetStyleCodeInterval()
        {
            return this.AdminDataProviderInstance.GetStyleCodeInterval();
        }

        public int Insert_Delete_StyleCodeInterval(int id, string fromQty, string toQty, int flag)
        {
            return this.AdminDataProviderInstance.Insert_Delete_StyleCodeInterval(id, fromQty, toQty, flag);
        }
        //End Of Code
        //Add By bharat On 24-july-19
        public DataSet GetOrderQuantity()
        {
            return this.AdminDataProviderInstance.GetOrderQuantity();
        }
        //end
        public int InsertVaWatageDetails(int FromRange, int ToRange, decimal CuttingWastage, decimal OrderingWastage, decimal CutCMT,decimal StitchCMT,decimal FinishCMT,decimal CMTOH,decimal Overhead, int leadday, string Flag, out int area)
        {
            return this.AdminDataProviderInstance.InsertVaWatageDetails(FromRange, ToRange, CuttingWastage, OrderingWastage, CutCMT, StitchCMT, FinishCMT, CMTOH, Overhead, leadday, Flag, out area);
        }
        public int InsertVaWatageDetails_VA(int wastageID, int ValueAdditionID, float ValueAdditionWastage, string Flag)
        {
            return this.AdminDataProviderInstance.InsertVaWatageDetails_VA(wastageID, ValueAdditionID, ValueAdditionWastage, Flag);
        }
        public DataSet getVAWastageDetails_byID(int VAID, int WastageID)
        {
            return this.AdminDataProviderInstance.getVAWastageDetails_byID(VAID, WastageID);
        }
        public int DeleteVAWastage(int wastageID)
        {
            return this.AdminDataProviderInstance.DeleteVAWastage(wastageID);
        }
        public int UpdateWastageValue(int VaID, int WastageID, float Values, string Flag)
        {
            return AdminDataProviderInstance.UpdateWastageValue(VaID, WastageID, Values, Flag);
        }
        //end by abhishek 25/7/2016

        //added by abhishek on 1/8/2016
        public DataSet GetSuppliarDetails(int MasterSupliarID = 0)
        {
            return this.AdminDataProviderInstance.GetSuppliarDetails(MasterSupliarID);
        }
        public DataSet GetSuppliarDetails_NEW_ForDebitNote(int MasterSupliarID = 0)
        {
            return this.AdminDataProviderInstance.GetSuppliarDetails_NEW_ForDebitNote(MasterSupliarID);
        }
        public int InsertSupplierProcess(int SupplierMasterID, string BasicType, string SupplyType, string Process, string flag)
        {
            return this.AdminDataProviderInstance.InsertSupplierProcess(SupplierMasterID, BasicType, SupplyType, Process, flag);
        }
        //Updated by Prabhaker on 24/8/2018 for Is Active Parameter Add--------------//
        public int InsertSupplierDetails(string BasicType, string SupplierName, string SupplierIntial, string Address, string GstNo, string SupplyType, int PaymentTerms, string Process, int USerID, string Fabric_Grade, string UploadSignature, int SupplieMasterID, out int MasterID, int DeliveryType)
        {
            return this.AdminDataProviderInstance.InsertSupplierDetails(BasicType, SupplierName, SupplierIntial, Address, GstNo, SupplyType, PaymentTerms, Process, USerID, Fabric_Grade, UploadSignature, SupplieMasterID, out  MasterID, DeliveryType);
        }
        //---------------End Of Code----------------//
        public int InsertSupplierConactDetailsDetails(int SupplieMasterID, string ContactPerson, string email, string ContactNo, string Contact_Remarks, int flag, string Types, int IsLogginUser)
        {
            return this.AdminDataProviderInstance.InsertSupplierConactDetailsDetails(SupplieMasterID, ContactPerson, email, ContactNo, Contact_Remarks, flag, Types, IsLogginUser);
        }
        public int InsertSupplierConactDetailsDetailsVA(int SupplieMasterID, int VA_id, int IsCheck)
        {
            return this.AdminDataProviderInstance.InsertSupplierConactDetailsDetailsVA(SupplieMasterID, VA_id, IsCheck);
        }
        public int deleteSupplierDetails(int SupplieMasterID)
        {
            return this.AdminDataProviderInstance.deleteSupplierDetails(SupplieMasterID);
        }
        public DataSet GetProccesNameWithSuppleType(string proceesID, string supplieType)
        {
            return this.AdminDataProviderInstance.GetProccesNameWithSuppleType(proceesID, supplieType);
        }
        public int InsertUpdateShop(string ShopName, string filename, int id, string flag, int userID, int Type)
        {
            return this.AdminDataProviderInstance.InsertUpdateShop(ShopName, filename, id, flag, userID, Type);
        }
        public int UpdateLineManPower(int UnitId, int manPower, int LineNoId, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateLineManPower(UnitId, manPower, LineNoId, UserId);
        }
        //end by abishek on 

        public string GetAttandanceDate()
        {
            return this.AdminDataProviderInstance.GetAttandanceDate();
        }

        //public int UpdateHalfFinishing(int StyleId, int LinePlanFrameId, string FactoryWorkSpace, string WorkerType, bool IsCheckedFinished, int OperationID)
        //{
        //    return this.AdminDataProviderInstance.UpdateHalfFinishing(StyleId, LinePlanFrameId, FactoryWorkSpace, WorkerType, IsCheckedFinished, OperationID);
        //}
        public DataSet GetShopDetails()
        {
            return this.AdminDataProviderInstance.GetShopDetails();
        }
        public DataSet GetFualtName(int orderDetailID)
        {
            return this.AdminDataProviderInstance.GetFualtName(orderDetailID);
        }
        public DataSet GetShipmentReportByValue(int maxDay, int minDay, int UnitID)
        {
            return this.AdminDataProviderInstance.GetShipmentReportByValue(maxDay, minDay, UnitID);
        }
        public DataSet GetShipmentReport_MonthTotal()
        {
            return this.AdminDataProviderInstance.GetShipmentReport_MonthTotal();
        }

        public DataSet GetPreiousMonthRevenue(int UnitID)
        {
            return this.AdminDataProviderInstance.GetPreiousMonthRevenue(UnitID);
        }
        public DataSet GetWipDetails(int UnitID, String flag)
        {
            return this.AdminDataProviderInstance.GetWipDetails(UnitID, flag);
        }
        public DataSet GetQaPedingDoneByDate(int orderdetailsID, string Flag)
        {
            return this.AdminDataProviderInstance.GetQaPedingDoneByDate(orderdetailsID, Flag);
        }
        public DataSet GetShipmentReportByICBIPL_ordring(int orderDetailsID, string Flag)
        {
            return this.AdminDataProviderInstance.GetShipmentReportByICBIPL_ordring(orderDetailsID, Flag);
        }
        public DataSet GetInceptionCountDone(int maxDay, int minDay, int UnitID)
        {
            return this.AdminDataProviderInstance.GetInceptionCountDone(maxDay, minDay, UnitID);
        }
        public DataSet GetInceptionDetailsSorting(int OrderDetailsID)
        {
            return this.AdminDataProviderInstance.GetInceptionDetailsSorting(OrderDetailsID);
        }
        //added by abhishek on 3/2/2017
        public int UpdateLineFloorCluster(int UnitId, int FloorNoId, int LineNoId, int UserId)
        {
            return AdminDataProviderInstance.UpdateLineFloorCluster(UnitId, FloorNoId, LineNoId, UserId);
        }
        public int UpdateLineIsClosedCluster(int UnitId, int FloorNoId, int LineNoId, bool IsClosed, int UserId)
        {
            return AdminDataProviderInstance.UpdateLineIsClosedCluster(UnitId, FloorNoId, LineNoId, IsClosed, UserId);
        }
        public int UpdateLineStatusDesignationCluster(int UnitId, int LineNoId, int LineDesignationId, string DesignationName, int UserId)
        {
            return AdminDataProviderInstance.UpdateLineStatusDesignationCluster(UnitId, LineNoId, LineDesignationId, DesignationName, UserId);
        }
        public int UpdateLineManPowerCluster(int UnitId, int manPower, int LineNoId, int UserId)
        {
            return AdminDataProviderInstance.UpdateLineManPowerCluster(UnitId, manPower, LineNoId, UserId);
        }
        //Add by prabhaker 14/11/17
        public int UpdateClusterName(int UnitId, string ClusterName, int LineNoId, int UserId)
        {
            return AdminDataProviderInstance.UpdateClusterName(UnitId, ClusterName, LineNoId, UserId);
        }
        //end
        public DataSet GetProductionWorkingHours()
        {
            return this.AdminDataProviderInstance.GetProductionWorkingHours();
        }
        public DataSet get_ctsl(int UnitId)
        {
            return this.AdminDataProviderInstance.get_ctsl(UnitId);
        }
        public DataSet GetInactiveuser(int ClientID, int UserID, int types, string StrUserID = "")
        {
            return this.MembershipDataProviderInstance.GetInactiveuser(ClientID, UserID, types, StrUserID);
        }
        public int UpsateClientDeptAssociation(int ClientDeptID, int DesignationID, int UserID, string Flag, int Isactive)
        {
            return AdminDataProviderInstance.UpsateClientDeptAssociation(ClientDeptID, DesignationID, UserID, Flag, Isactive);
        }
        public int ActiveInactiveUser(int UserID, int Isactive, string Flag = "")
        {
            return AdminDataProviderInstance.ActiveInactiveUser(UserID, Isactive, "");
        }
        public DataSet GetQtyByStyleCode(string stylecode)
        {
            return AdminDataProviderInstance.GetQtyByStyleCode(stylecode);
        }
        public DataTable GetCADMAster()
        {
            return this.AdminDataProviderInstance.GetCADMAster();
        }
        public string UpdateMasterDetails(string MasterName, int MasterType)
        {
            return this.AdminDataProviderInstance.UpdateMasterDetails(MasterName, MasterType);
        }
        public DataTable GetMasterName()
        {
            return this.AdminDataProviderInstance.GetMasterName();
        }
        public string UpdateMasterDetailsClientAssosi(int iaactive, string PrimaryClientID, string SecoundryCliemtID, int masterid, int IsReplace, int NewMAsterID)
        {
            return AdminDataProviderInstance.UpdateMasterDetailsClientAssosi(iaactive, PrimaryClientID, SecoundryCliemtID, masterid, IsReplace, NewMAsterID);
        }
        public DataSet GetClientMatserAssociationDetails(int MasterID, int Types)
        {
            return AdminDataProviderInstance.GetClientMatserAssociationDetails(MasterID, Types);
        }
        public DataTable getCadManagerTailor()
        {
            return AdminDataProviderInstance.getCadManagerTailor();
        }
        public DataSet getFactorySpecificlineTargetActual()
        {
            return AdminDataProviderInstance.getFactorySpecificlineTargetActual();
        }
        public DataSet getFactorySlotSpecificlineTargetActual()
        {
            return AdminDataProviderInstance.getFactorySlotSpecificlineTargetActual();
        }
        //Add By Prabhaker 15-09-17
        public DataTable getCadManagerStatus(string flag, int styleID, string status)
        {
            return AdminDataProviderInstance.getCadManagerStatus(flag, styleID, status);
        }
        public int UpdateCadManagerStatus(string flag, int RemakeCount, int styleID, string status)
        {
            return AdminDataProviderInstance.UpdateCadManagerStatus(flag, RemakeCount, styleID, status);
        }
        //
        public string UpdateMasterDetailsRole(int MasterID, int MasterRoleID)
        {
            return AdminDataProviderInstance.UpdateMasterDetailsRole(MasterID, MasterRoleID);
        }
        public string Get_POBreakDown(string AM, string Exfactory)
        {
            return AdminDataProviderInstance.Get_POBreakDown(AM, Exfactory);
        }
        //Add by bharat 25-jan-19
        public string Usp_GetOnhold_Contract_Status_BreakDown(string AM, string Exfactory)
        {
            return AdminDataProviderInstance.Usp_GetOnhold_Contract_Status_BreakDown(AM, Exfactory);
        }
        //Add by Surendra2 on 02/08/2018.
        public string Get_BrealDownForOuthouse(string ProcessName, int ValuesID, int TotalAverage, int TotalProcess)
        {
            return AdminDataProviderInstance.Get_BrealDownForOuthouse(ProcessName, ValuesID, TotalAverage, TotalProcess);
        }

        //Add by Surendra2 on 29-05-2018.
        public string Get_BrealDownForCompliance_QA(int ProcessType, string ProcessName, int QAComplaine_TypeAdmin, int ValuesID, int UnitId, int TotalAverage, int TotalProcess)
        {
            return AdminDataProviderInstance.Get_BrealDownForCompliance_QA(ProcessType, ProcessName, QAComplaine_TypeAdmin, ValuesID, UnitId, TotalAverage, TotalProcess);
        }

        //end
        // Added By Ravi kumar on 24-5-17
        public DataSet GetPendingQty_ByStyleCode(string stylecode)
        {
            return AdminDataProviderInstance.GetPendingQty_ByStyleCode(stylecode);
        }
        // Added By Prabhaker on 26-6-17
        public int InsertUpdateCadManagerTailor(int TailorOnLoad, int TailorPresent, int SampleMadeCount, DateTime requestdate)
        {
            return AdminDataProviderInstance.InsertUpdateCadManagerTailor(TailorOnLoad, TailorPresent, SampleMadeCount, requestdate);
        }
        public DataSet GetHeaderPOUploadPending()
        {
            return AdminDataProviderInstance.GetHeaderPOUploadPending();
        }
        public DataSet GetHeaderOnHoldUploadPending()
        {
            return AdminDataProviderInstance.GetHeaderOnHoldUploadPending();
        }
        //Add by Bharat on 18-12-2019.
        public DataSet GetHeaderPendingCostConfirmation()
        {
            return AdminDataProviderInstance.GetHeaderPendingCostConfirmation();
        }

        public string Usp_GetPenCostCon_Contract_Status_BreakDown(string AM, string Exfactory)
        {
            return AdminDataProviderInstance.Usp_GetPenCostCon_Contract_Status_BreakDown(AM, Exfactory);
        }
        //Add by Surendra2 on 28-05-2018.
        public DataSet GetHeaderComplianceQAuditReport(int ProcessType)
        {
            return AdminDataProviderInstance.GetHeaderComplianceQAuditReport(ProcessType);
        }

        //Add by Surendra2 on 02/08/2018.
        public DataSet GetHeaderOutHouseAuditReport()
        {
            return AdminDataProviderInstance.GetHeaderOutHouseAuditReport();
        }

        public void SetTruncateTable()
        {
            AdminDataProviderInstance.SetTruncateTable();
        }
        //Add By Prabhaker On 03-oct-18
        public DataSet Get_RevenueForBarchart()
        {
            return AdminDataProviderInstance.Get_RevenueForBarchart();
        }
        public DataSet Get_RevenueMonthWise()
        {
            return AdminDataProviderInstance.Get_RevenueMonthWise();
        }
        public DataSet Get_RevenueMonthWise_Delivery()
        {
            return AdminDataProviderInstance.Get_RevenueMonthWise_Delivery();
        }

        public DataSet Get_RevenueForBarchart_Department()
        {
            return AdminDataProviderInstance.Get_RevenueForBarchart_Department();
        }
        // End Of COde
        //Add code by bharat on 11-sep-19
        public DataSet GetMasterTaitorReport()
        {
            return AdminDataProviderInstance.GetMasterTaitorReport();
        }

        //Add By Prabhaker 15-feb-17//
        public DataSet GetHeaderQCSummeryReport()
        {
            return AdminDataProviderInstance.GetHeaderQCSummeryReport();
        }

        //Add By Prabhaker 18-may-18//
        public DataSet GetProductOccuptionResult(int UnitId, int QAComplienceId, int ValueId, int processType, string newdate, string floortype, bool bOpenFromLink)
        {
            return AdminDataProviderInstance.GetProductOccuptionResult(UnitId, QAComplienceId, ValueId, processType, newdate, floortype, bOpenFromLink);
        }
        public DataSet GetProductOccupationalAudit(int UnitId, int processType)
        {
            return AdminDataProviderInstance.GetProductOccupationalAudit(UnitId, processType);
        }
        public DataSet GetLineProcessValue(int UnitId, int ProcessType, int InternalAuditId, int QAComplienceId, int ValueId, string floorType, string newdate, bool bOpenFromLink)
        {
            return AdminDataProviderInstance.GetLineProcessValue(UnitId, ProcessType, InternalAuditId, QAComplienceId, ValueId, floorType, newdate, bOpenFromLink);
        }
        public DataSet GetLineProcessAuditdecision(int UnitId, int ProcessType, int InternalAuditId, int QAComplienceId, int ValueId, string LineNo, string CompareDate)
        {
            return AdminDataProviderInstance.GetLineProcessAuditdecision(UnitId, ProcessType, InternalAuditId, QAComplienceId, ValueId, LineNo, CompareDate);
        }

        public int InsertUpdate_Line_Process_Audit_decision(int ProcessType, int UnitID, int Internal_Audit_ProcessID, int QAComplaine_TypeAdmin, int ValuesID, int status, string Remarks, int ApplyToAll, int CreatedBy, string floorType, int IsClosed, string ImageFile, int IsActive, string CompareDate, int OutHouseValue, int flag)
        {
            return AdminDataProviderInstance.InsertUpdate_Line_Process_Audit_decision(ProcessType, UnitID, Internal_Audit_ProcessID, QAComplaine_TypeAdmin, ValuesID, status, Remarks, ApplyToAll, CreatedBy, floorType, IsClosed, ImageFile, IsActive, CompareDate, OutHouseValue, flag);
        }
        //-----Added by shubhendu on 27/05/2022
        public int UpdateCategorySupplierDays(int CategoryID, int grgDays, int grgrange, int dyedDays, int dyedrange,int ProcessDays,int txtProcess_drange, int PrintDays, int PrintRange, int FinishDays, int FinishRange, int RFDstg1day, int RFDstg1Range, int RFDstg2Days, int RFDstg2range, int embrDays, int embrRange, int embllDays, int embllRange, int Userid)
        {
            return this.AdminDataProviderInstance.UpdateCategorySupplierDays( CategoryID,  grgDays,  grgrange,  dyedDays,  dyedrange,  ProcessDays, txtProcess_drange, PrintDays,  PrintRange,  FinishDays,  FinishRange,  RFDstg1day,  RFDstg1Range,  RFDstg2Days,  RFDstg2range,  embrDays,  embrRange,  embllDays,  embllRange,  Userid);
        }
        //----------------end here-----------------------27/05/2022

        public int InsertUpdate_Line_Process_Audit_decision_All(int ProcessType, int UnitID, int Internal_Audit_ProcessID, int QAComplaine_TypeAdmin, int ValuesID, int status, string Remarks, int ApplyToAll, int CreatedBy, string floorType, string CompareDate)
        {
            return AdminDataProviderInstance.InsertUpdate_Line_Process_Audit_decision_All(ProcessType, UnitID, Internal_Audit_ProcessID, QAComplaine_TypeAdmin, ValuesID, status, Remarks, ApplyToAll, CreatedBy, floorType, CompareDate);
        }
        //End By Prabhaker 18-may-18//

        public int Insert_Update_AuditParameter_Admin(int QAComplienceId, string AuditParameter, int UnitId, int ProcessType, int Sequence, int IsActive, int flag)
        {
            return AdminDataProviderInstance.Insert_Update_AuditParameter_Admin(QAComplienceId, AuditParameter, UnitId, ProcessType, Sequence, IsActive, flag);
        }

        public DataSet Get_AuditParameter_Admin(int UnitId, int ProcessType)
        {
            return AdminDataProviderInstance.Get_AuditParameter_Admin(UnitId, ProcessType);
        }

        public DataSet GetHeaderLineManSummeryReport()
        {
            return AdminDataProviderInstance.GetHeaderLineManSummeryReport();

        }
        public DataSet GetHeaderAchievmentLineManSummeryReport()
        {
            return AdminDataProviderInstance.GetHeaderAchievmentLineManSummeryReport();

        }
        // Add By Prabhaker 28-jun-18
        public DataSet GetUnitAdmin(string UnitAdmin, int flag)
        {
            return AdminDataProviderInstance.GetUnitAdmin(UnitAdmin, flag);
        }

        public string InsertUnitAdmin(int GroupAdminId, string UnitAdmin, int convertPerpcs, bool IsActive, bool Isfabric, bool IsAccessory, int flag)
        {
            return AdminDataProviderInstance.InsertUnitAdmin(GroupAdminId, UnitAdmin, convertPerpcs, IsActive, Isfabric, IsAccessory, 1);
        }


        public int UpdateUnitAdmin(int GroupAdminId, string UnitAdmin, int ConvertPcs, bool IsActive, bool Isfabric, bool IsAccessory, int flag)
        {
            return AdminDataProviderInstance.UpdateUnitAdmin(GroupAdminId, UnitAdmin, ConvertPcs, IsActive, Isfabric, IsAccessory, 2);
        }

        //End Of Code

        public DataSet GetComplianceAdmin(int UnitId, int ProcessType, int flag)
        {
            return AdminDataProviderInstance.GetComplianceAdmin(UnitId, ProcessType, 0);
        }
        public DataSet GetParentDepartment(int ClientId, int flag)
        {
            return AdminDataProviderInstance.GetParentDepartment(ClientId, flag);
        }
        public int InsertComplianceAdmin(string ProcessName, int UnitId, int ProcessType, int flag, int UserId)
        {
            return AdminDataProviderInstance.InsertComplianceAdmin(ProcessName, UnitId, ProcessType, 1, UserId);
        }
        public int InsertParentDept(string DeptName, int ClientId)
        {
            return AdminDataProviderInstance.InsertParentDept(DeptName, ClientId);
        }
        public int UpdateParentDept(int Id, string DeptName)
        {
            return AdminDataProviderInstance.UpdateParentDept(Id, DeptName);
        }
        public int UpdateComplianceAdmin(int Internal_Audit_ProcessID, string ProcessName, int UnitId, int ProcessType, int flag, int UserId)
        {
            return AdminDataProviderInstance.UpdateComplianceAdmin(Internal_Audit_ProcessID, ProcessName, UnitId, ProcessType, 2, UserId);
        }

        public int deleteComplianceAdminData(int Internal_Audit_ProcessID, int flag)
        {
            return AdminDataProviderInstance.deleteComplianceAdminData(Internal_Audit_ProcessID, 3);
        }
        //End of Code// 
        //Add By Prabhaker 09-01-18
        public DataSet GetHeaderProductionMatrix(string StyleCode)
        {
            return AdminDataProviderInstance.GetHeaderProductionMatrix(StyleCode);
        }

        public string Get_ProductionmatrixPopUp(string StyleCode, DateTime Exfactory, int IsCombined, DateTime DcDate)
        {
            return AdminDataProviderInstance.Get_ProductionmatrixPopUp(StyleCode, Exfactory, IsCombined, DcDate);
        }

        public string Get_ProductionmatrixPopUp_Another(string StyleCode, string Exfactory)
        {
            return AdminDataProviderInstance.Get_ProductionmatrixPopUp_Another(StyleCode, Exfactory);
        }

        public string Get_ProductionmatrixPopUp_BelowGrid(string Optional_StyleCode, DateTime Exfactory, string StyleCode, int IsCombined, DateTime DcDate)
        {
            return AdminDataProviderInstance.Get_ProductionmatrixPopUp_BelowGrid(Optional_StyleCode, Exfactory, StyleCode, IsCombined, DcDate);
        }

        // End Of Code
        public DataSet GetHeaderPOUploadPendingMiddle()
        {
            return AdminDataProviderInstance.GetHeaderPOUploadPendingMiddle();
        }
        //added by abhishek on 28/6/2017
        public DataSet GetFitsReport(string flag)
        {
            return AdminDataProviderInstance.GetFitsReport(flag);
        }
        //added by Prabhaker on 21/3/2018
        public DataSet getDepartmentWiseReport()
        {
            return AdminDataProviderInstance.getDepartmentWiseReport();
        }
        public DataSet getDepartmentWiseReport_withoutassosiation()
        {
            return AdminDataProviderInstance.getDepartmentWiseReport_withoutassosiation();
        }
        public int GetWeek_Count(out int Days)
        {
            return AdminDataProviderInstance.GetWeek_Count(out Days);
        }
        public DataTable GetFitsMasterReport(string flag, string StartDate, string EndDate, int MasterID)
        {
            return AdminDataProviderInstance.GetFitsMasterReport(flag, StartDate, EndDate, MasterID);
        }
        public DataTable GetFitstailorMonthlyReport(string flag, string StartDate, string EndDate, int WeekNumber)
        {
            return AdminDataProviderInstance.GetFitstailorMonthlyReport(flag, StartDate, EndDate, WeekNumber);
        }
        public DataSet GetShipmetReportPnd(string flag, int ClientID = 0, string ExfactDate = "")
        {
            return this.AdminDataProviderInstance.GetShipmetReportPnd(flag, ClientID, ExfactDate);
        }
        public DataSet GetShipmetReportUpcming()
        {
            return this.AdminDataProviderInstance.GetShipmetReportUpcming();
        }
        public DataSet GetShipmentPenaltyReports()
        {
            return this.AdminDataProviderInstance.GetShipmentPenaltyReports();
        }
        public DataSet GetOuthouseSummary()
        {
            return this.AdminDataProviderInstance.GetOuthouseSummaryReport();
        }
        public DataSet TotalMuliplierFactor_For_Financial_Month()
        {
            return this.AdminDataProviderInstance.TotalMuliplierFactor_For_Financial_Month();
        }
        public DataSet GetOuthouseSummaryReportwithout()
        {
            return this.AdminDataProviderInstance.GetOuthouseSummaryReportwithout();
        }
        //end  
        // Update By Ravi kumar on 3-8-17
        public DataTable GetStyleDetails(int UnitId, int LineNo, string StyleCode, string Status)
        {
            return this.AdminDataProviderInstance.GetStyleDetails(UnitId, LineNo, StyleCode, Status);
        }
        // Added By Ravi kumar on 3-8-17
        //public DataTable GetStyleCodeDetails(int UnitId, int LineNo, string Status)
        //{
        //    return this.AdminDataProviderInstance.GetStyleCodeDetails(UnitId, LineNo, Status);
        //}

        public DataTable GetStyleDetail_LinePlan(int FactoryId, int LineNo, string StyleCode, int LinePlanFrameId, int StyleId)
        {
            return this.AdminDataProviderInstance.GetStyleDetail_LinePlan(FactoryId, LineNo, StyleCode, LinePlanFrameId, StyleId);
        }
        public DataTable GetContractStyleDetail_Grid(int FactoryId, int LineNo, string StyleCode, int StyleID, int LinePlanFrameId, int IsHalfStitch)
        {
            return this.AdminDataProviderInstance.GetContractStyleDetail_Grid(FactoryId, LineNo, StyleCode, StyleID, LinePlanFrameId, IsHalfStitch);
        }
        public DataTable GetContractStyleDetail_LinePlan(int FactoryId, int LineNo, string StyleCode, int LinePlanFrameId)
        {
            return this.AdminDataProviderInstance.GetContractStyleDetail_LinePlan(FactoryId, LineNo, StyleCode, LinePlanFrameId);
        }
        public DataSet Get_SAM_OB_ByStyleCode(string StyleCode, int StyleId, int UnitId)
        {
            return this.AdminDataProviderInstance.Get_SAM_OB_ByStyleCode(StyleCode, StyleId, UnitId);
        }
        public string GetSlotTime(int SlotId)
        {
            return this.AdminDataProviderInstance.GetSlotTime(SlotId);
        }
        public int InsertUpdateLinePlanning(LinePlan objLinePlan, int UserId, ref int LinePlanFrameIdOutput)
        {
            return this.AdminDataProviderInstance.InsertUpdateLinePlanning(objLinePlan, UserId, ref LinePlanFrameIdOutput);
        }
        public int Update_Start_EndDate_ByLinePlanFrameId(int LinePlanFrameId, string StyleCode, int UnitId, int LineNoId, int TotalQty)
        {
            return this.AdminDataProviderInstance.Update_Start_EndDate_ByLinePlanFrameId(LinePlanFrameId, StyleCode, UnitId, LineNoId, TotalQty);
        }
        public int DeleteLinePlanning(int UnitId, int LineNoId, string StyleCode, int LinePlanFrameId)
        {
            return AdminDataProviderInstance.DeleteLinePlanning(UnitId, LineNoId, StyleCode, LinePlanFrameId);
        }
        public int UpdateLinePlanStitchingSam(int StyleId, int LinePlanFrameId, bool IsFinishing, string OperationName)
        {
            return AdminDataProviderInstance.UpdateLinePlanStitchingSam(StyleId, LinePlanFrameId, IsFinishing, OperationName);
        }
        public int AddDuplicateHalfStitch_LinePlan(int UnitId, int FloorNoId, int LineNoId, DateTime StartDate, int SlotId, int LinePlanFrameId, int FullStitchFrame, int SeqFrameId, bool IsParallel, int UserId)
        {
            return AdminDataProviderInstance.AddDuplicateHalfStitch_LinePlan(UnitId, FloorNoId, LineNoId, StartDate, SlotId, LinePlanFrameId, FullStitchFrame, SeqFrameId, IsParallel, UserId);
        }

        public DataTable GetDesignationDetails(int FactoryId, int LineNo, int FactoryLineAdminID)
        {
            return this.AdminDataProviderInstance.GetDesignationDetails(FactoryId, LineNo, FactoryLineAdminID);
        }
        public DataTable GetContractStyleDetail(int FactoryId, int LineNo)
        {
            return this.AdminDataProviderInstance.GetContractStyleDetail(FactoryId, LineNo);
        }
        public List<LinePlanningStyle> GetStyleCodeDetails(int UnitId, int LineNo, string Status, string StylePrefix)
        {
            return this.AdminDataProviderInstance.GetStyleCodeDetails(UnitId, LineNo, Status, StylePrefix);
        }
        public int DeleteLinePlanFrame(int LinePlanFrameId)
        {
            return AdminDataProviderInstance.DeleteLinePlanFrame(LinePlanFrameId);
        }
        public DataTable GetSamOBDiff(string StyleCode, int StyleId, int CombinedFrameId, int IsHalfStitched)
        {
            return this.AdminDataProviderInstance.GetSamOBDiff(StyleCode, StyleId, CombinedFrameId, IsHalfStitched);
        }
        public DataTable GetLinePlanFrame(int UnitId, int LineNo, int LinePlanFrameId)
        {
            return this.AdminDataProviderInstance.GetLinePlanFrame(UnitId, LineNo, LinePlanFrameId);
        }
        public DataTable GetContractStyleDetail_outshoue(int FactoryId)
        {
            return this.AdminDataProviderInstance.GetContractStyleDetail_outshoue(FactoryId);
        }
        public DataTable GetLinePlanFrame_outhouse(int UnitId, int LineNo, int LinePlanFrameId)
        {
            return this.AdminDataProviderInstance.GetLinePlanFrame_outhouse(UnitId, LineNo, LinePlanFrameId);
        }
        public DataTable GetContractStyleDetail_LinePlan_out(int FactoryId, int LineNo, string StyleCode, int LinePlanFrameId)
        {
            return this.AdminDataProviderInstance.GetContractStyleDetail_LinePlan_out(FactoryId, LineNo, StyleCode, LinePlanFrameId);
        }
        //Added by abhishek on 22/1/2018
        public DataTable GetFabricInHouseQtyDetails(int OrderDetailID, int FabricType)
        {
            return this.AdminDataProviderInstance.GetFabricInHouseQtyDetails(OrderDetailID, FabricType);
        }
        public int UpdateFabricInHouseQty(int OrderDetailID, int FabricType, int InhouseQty, int issue_issueQty, string issue_Challan, int OnholdQty, int RejectQty, int CreatedBy)
        {
            return this.AdminDataProviderInstance.UpdateFabricInHouseQty(OrderDetailID, FabricType, InhouseQty, issue_issueQty, issue_Challan, OnholdQty, RejectQty, CreatedBy);
        }
        public DataTable GetFabricInHouseQty(int OrderDetailID, int FabricType)
        {
            return this.AdminDataProviderInstance.GetFabricInHouseQty(OrderDetailID, FabricType);
        }
        public DataTable GetFabricInHousePlannedQty(int OrderDetailID, int FabricType, string IsBlankRow)
        {
            return this.AdminDataProviderInstance.GetFabricInHousePlannedQty(OrderDetailID, FabricType, IsBlankRow);
        }
        public int UpdateFabricPlannedQty(int OrderDetailID, int FabricType, int P_Id, DateTime PlannedETA, int DelaysDays, int Quantity, int IsComplete)
        {
            return this.AdminDataProviderInstance.UpdateFabricPlannedQty(OrderDetailID, FabricType, P_Id, PlannedETA, DelaysDays, Quantity, IsComplete);
        }
        public int UpdateRevisedQty(int OrderDetailID, int FabricType, DateTime PlannedETA, int DelaysDays, int Quantity)
        {
            return this.AdminDataProviderInstance.UpdateRevisedQty(OrderDetailID, FabricType, PlannedETA, DelaysDays, Quantity);
        }
        public int DeleteFabricInHouseETA(int P_Id, DateTime PlannedETA)
        {
            return this.AdminDataProviderInstance.DeleteFabricInHouseETA(P_Id, PlannedETA);
        }
        public string GetExistLinePlanFrame(int FactoryId, int LineNo, string StyleCode)
        {
            return this.AdminDataProviderInstance.GetExistLinePlanFrame(FactoryId, LineNo, StyleCode);
        }
        public string ValidateExsitingPlannedDate(DateTime dates, int OrderDetailID, int FabricType)
        {
            return this.AdminDataProviderInstance.ValidateExsitingPlannedDate(dates, OrderDetailID, FabricType);
        }
        public DataTable GetBindFabrRshuffle(int OrderDetailID, int FabricType, DateTime EntryDate)
        {
            return this.AdminDataProviderInstance.GetBindFabrRshuffle(OrderDetailID, FabricType, EntryDate);
        }
        public int UpdateFabPlannedHoldQty(int p_id, int OnholdQty, int InHouseQty, int RejectQty, int IssueQty, int CreatedBy)
        {
            return this.AdminDataProviderInstance.UpdateFabPlannedHoldQty(p_id, OnholdQty, InHouseQty, RejectQty, IssueQty, CreatedBy);
        }
        public int UptfabEND_Eta(int OrderDetailID, int FabricType)
        {
            return this.AdminDataProviderInstance.UptfabEND_Eta(OrderDetailID, FabricType);
        }
        public int UpdateCutissue(int OrderDetailsID, int CutIssue, string ChalanNo, int UnitID, DateTime CutIssueDate, int CreatedBy)
        {
            return this.AdminDataProviderInstance.UpdateCutissue(OrderDetailsID, CutIssue, ChalanNo, UnitID, CutIssueDate, CreatedBy);
        }
        public DataTable GetCutIssueDetail(int OrderDetailID, int UnitId)
        {
            return this.AdminDataProviderInstance.GetCutIssueDetail(OrderDetailID, UnitId);
        }
        //END abhishek
        //Added for complete line plan frame
        public int CompleteLinePlanFrame(int UnitiD, int LineNo, int LinePlanFrameId)
        {
            return AdminDataProviderInstance.CompleteLinePlanFrame(UnitiD, LineNo, LinePlanFrameId);
        }
        //Added By Prabhaker 23/mar/2018
        public int UpdateQCManPowerChecker(int OrderDetailsID, int ManPower, int QCId, int Checker, int UnitID, int stitchQty, int IsCompleted, string type)
        {
            return this.AdminDataProviderInstance.UpdateQCManPowerChecker(OrderDetailsID, ManPower, QCId, Checker, UnitID, stitchQty, IsCompleted, type);
        }
        public DataSet GetQCManPowerChecker(int OrderDetailID, int UnitId, string type)
        {
            return this.AdminDataProviderInstance.GetQCManPowerChecker(OrderDetailID, UnitId, type);
        }
        //End Of Code
        public DataTable GetStaffAttendence(string Flag, int DeparmentID, int designationid, int userid)
        {
            return this.AdminDataProviderInstance.GetStaffAttendence(Flag, DeparmentID, designationid, userid);
        }
        public DataTable CheckPlanleaveStaffAttendence(string Flag, int DeparmentID, int designationid, int userid, DateTime Leavedate)
        {
            return this.AdminDataProviderInstance.CheckPlanleaveStaffAttendence(Flag, DeparmentID, designationid, userid, Leavedate);
        }
        public int UpdateStaffAttendence(int DeptID,
            int DesignationID,
            int LoggedInUser,
              string Intime,
            string Outtime,
            int StatusiD,
            DateTime Leavefrom,
            DateTime Leaveto,
            decimal NoOfLeaveDay,
            string Remarks, DateTime StaffAttandanceDate, int UpdatedBy, string ExtraOutTime)
        {
            return this.AdminDataProviderInstance.UpdateStaffAttendence(DeptID, DesignationID, LoggedInUser, Intime, Outtime, StatusiD, Leavefrom, Leaveto, NoOfLeaveDay, Remarks, StaffAttandanceDate, UpdatedBy, ExtraOutTime);
        }
        public DataSet GetStaffAttendenceDetailByDate(int DeptID, int designationID, int UserID, DateTime AttendencDate)
        {
            return this.AdminDataProviderInstance.GetStaffAttendenceDetailByDate(DeptID, designationID, UserID, AttendencDate);
        }
        public DataTable CheckHoliday(DateTime AttendencDate)
        {
            return this.AdminDataProviderInstance.CheckHoliday(AttendencDate);
        }

        public DataTable GetStaffAttendenceDetailByDateleave(int DeptID, int designationID, int UserID, DateTime AttendencDate)
        {
            return this.AdminDataProviderInstance.GetStaffAttendenceDetailByDateleave(DeptID, designationID, UserID, AttendencDate);
        }
        public DataSet GetHeaderstaffAtten(int monthno)
        {
            return AdminDataProviderInstance.GetHeaderstaffAtten(monthno);
        }
        public DataSet GetHeaderstaffAtten_Report(int DeparmentID, int DesignationID, int UserID, DateTime StaffAttandanceDate)
        {
            return AdminDataProviderInstance.GetHeaderstaffAtten_Report(DeparmentID, DesignationID, UserID, StaffAttandanceDate);
        }
        public int UpdateQcFile(string filename, int orderdetailID, string filetype)
        {
            return this.AdminDataProviderInstance.UpdateQcFile(filename, orderdetailID, filetype);
        }
        public DataSet GetHeaderstaffAtten_ReportMothIse(int DeparmentID, int DesignationID, int UserID, int month)
        {
            return AdminDataProviderInstance.GetHeaderstaffAtten_ReportMothIse(DeparmentID, DesignationID, UserID, month);
        }
        public DataSet GetSuppliarDetails_new(int Flag, int SupplierType)
        {
            return this.AdminDataProviderInstance.GetSuppliarDetails_new(Flag, SupplierType);
        }
        public DataSet GetSuppliarContactDetails_new(int Flag, int SupplierMasterID, string Search = "", int searchIsActive = -1, string txtSearch = "")
        {
            return this.AdminDataProviderInstance.GetSuppliarContactDetails_new(Flag, SupplierMasterID, Search, searchIsActive, txtSearch);
        }
        public DataSet GetCatagory(int Flag)
        {
            return this.AdminDataProviderInstance.GetCatagory(Flag);
        }
        public DataSet GetSuppliarProcess(int Flag, int SupplierType, int SupplierMasterID)
        {
            return this.AdminDataProviderInstance.GetSuppliarProcess(Flag, SupplierType, SupplierMasterID);
        }
        public DataTable GetCatagorySelectedVal(int Flag, int SelectedVal)
        {
            return this.AdminDataProviderInstance.GetCatagorySelectedVal(Flag, SelectedVal);
        }

        public int DeleteAccMasterByID(int AccMasterID)
        {
            return this.AdminDataProviderInstance.DeleteAccMasterByID(AccMasterID);
        }
        public DataTable GetCatagoryFilter(int Flag, int CatGroupID, string TradeName, int Unit, int SearchDefault)
        {
            return this.AdminDataProviderInstance.GetCatagoryFilter(Flag, CatGroupID, TradeName, Unit, SearchDefault);
        }
        public DataTable GetAccSizedetails(int Flag, int AccMasterID)
        {
            return this.AdminDataProviderInstance.GetAccSizedetails(Flag, AccMasterID);
        }
        public int UpdateAccSize(int flag, int AccMasterID, string SizeName, string accessory_quality_SizeID, decimal Greige, decimal procees, decimal Finish, int OptionNo, int UserId)
        {
            return this.AdminDataProviderInstance.UpdateAccSize(flag, AccMasterID, SizeName, accessory_quality_SizeID, Greige, procees, Finish, OptionNo, UserId);
        }
        public string UpdateAccSizeValidate(string AccSizeName, int AccMasterID)
        {
            return this.AdminDataProviderInstance.UpdateAccSizeValidate(AccSizeName, AccMasterID);
        }
        public int DeleteAccSize(int AccMasterID, int accessory_quality_SizeID, string SizeName)
        {
            return this.AdminDataProviderInstance.DeleteAccSize(AccMasterID, accessory_quality_SizeID, SizeName);
        }
        public DataSet GetAccSizegrd(int AccsessMasterID)
        {
            return this.AdminDataProviderInstance.GetAccSizegrd(AccsessMasterID);
        }
        public int UpdateAccSupplier(string flag, int accessory_qualityID, double AccesoriesWastage, double Accesories_ShrinkageWastage, string AccesoriesType,
        int AccessoryMaster_ID, int SupplierID, int LeadTime, string UploadBaseTestFile, DateTime TestConductedOn, double MinimumOrderQuality, string UploadFile, int UserID)
        {
            return this.AdminDataProviderInstance.UpdateAccSupplier(flag, accessory_qualityID, AccesoriesWastage, Accesories_ShrinkageWastage, AccesoriesType,
           AccessoryMaster_ID, SupplierID, LeadTime, UploadBaseTestFile, TestConductedOn, MinimumOrderQuality, UploadFile, UserID);
        }
        public int UpdateAccSupplierSizetable(string flag, int accessory_qualityID, double Price, double FinalPrice, int UserID, int AccessoryMaster_ID, int accessory_quality_SizeID, string SizeName, int IsGreigeSupply, int IsProcessSupply, int IsFinishSupply, double GriegePrice, double ProcessPrice, double FinshingPrice)
        {
            return this.AdminDataProviderInstance.UpdateAccSupplierSizetable(flag, accessory_qualityID, Price, FinalPrice, UserID, AccessoryMaster_ID, accessory_quality_SizeID, SizeName, IsGreigeSupply, IsProcessSupply, IsFinishSupply, GriegePrice, ProcessPrice, FinshingPrice);
        }
        public DataTable GetAccSizeHistory(string flag, int accessory_quality_SizeID, int AccessoryMaster_ID, int AccMasterID, string SizeName)
        {
            return this.AdminDataProviderInstance.GetAccSizeHistory(flag, accessory_quality_SizeID, AccessoryMaster_ID, AccMasterID, SizeName);
        }
        public DataTable GetAccSizedetailsNew(int AccMasterID, int Acc_qualityID)
        {
            return this.AdminDataProviderInstance.GetAccSizedetailsNew(AccMasterID, Acc_qualityID);
        }

        public int Insert_SAMLinePlan(int LinePlanFrameId, int StyleId, double SAM, bool IsActive)
        {
            return this.AdminDataProviderInstance.Insert_SAMLinePlan(LinePlanFrameId, StyleId, SAM, IsActive);
        }
        public DataTable SetActiveSupplierMaster(int Flag, int SupplierMasterID, int IsActive)
        {
            return this.AdminDataProviderInstance.SetActiveSupplierMaster(Flag, SupplierMasterID, IsActive);
        }
        public int Create_PlanDate_ByLinePlanFrameID(int LinePlanFrameId)
        {
            return this.AdminDataProviderInstance.Create_PlanDate_ByLinePlanFrameID(LinePlanFrameId);
        }
        public DataTable GetOutHouseFactory(int FactoryId)
        {
            return this.AdminDataProviderInstance.GetOutHouseFactory(FactoryId);
        }
        public string GetSupplierSelectedType(int Supplierid)
        {
            return this.AdminDataProviderInstance.GetSupplierSelectedType(Supplierid);
        }
        // Added By Ravi kumar on 14-aug-18 for half stitch replica
        public DataTable GetContractDetailsForReplica(int LinePlanFrameId)
        {
            return AdminDataProviderInstance.GetContractDetailsForReplica(LinePlanFrameId);
        }

        public int InsertReplicaLinePlanning(LinePlan objLinePlan, int BaseLinePlanFrame, int FirstUnitID, int ReplicaUnitId, int FirstLineQty, int ReplicaLineQty, int UserId, ref int FirstLinePlanFrameId, ref int ReplicaLinePlanFrameId)
        {
            return this.AdminDataProviderInstance.InsertReplicaLinePlanning(objLinePlan, BaseLinePlanFrame, FirstUnitID, ReplicaUnitId, FirstLineQty, ReplicaLineQty, UserId, ref FirstLinePlanFrameId, ref ReplicaLinePlanFrameId);
        }

        public int UpdateReplicaEndDate(int FirstLinePlanFrameId, int ReplicaLinePlanFrameId, int FirstUnitID, int ReplicaUnitId, int StyleId)
        {
            return this.AdminDataProviderInstance.UpdateReplicaEndDate(FirstLinePlanFrameId, ReplicaLinePlanFrameId, FirstUnitID, ReplicaUnitId, StyleId);
        }
        public bool deleteAccQualityMaster(int AccQualityMasterID, int AccMasterID)
        {
            return this.AdminDataProviderInstance.deleteAccQualityMaster(AccQualityMasterID, AccMasterID);
        }
        public DataTable CheckSupplierNameExists(int SupplierMasterID, string SupplierName, int types)
        {
            return this.AdminDataProviderInstance.CheckSupplierNameExists(SupplierMasterID, SupplierName, types);
        }
        public DataTable GetAccSizeValue(int AccsessMasterID, string sizeName)
        {
            return this.AdminDataProviderInstance.GetAccSizeValue(AccsessMasterID, sizeName);
        }
        public DataSet BindStylecodePlan()
        {
            return this.AdminDataProviderInstance.BindStylecodePlan();
        }
        //added by abhishek 
        public int UpdateIntimeUser(int DeptID, int DesignationID, int UserID, string Intime, int UpdatedBy, DateTime AttendenceDate)
        {
            return this.AdminDataProviderInstance.UpdateIntimeUser(DeptID, DesignationID, UserID, Intime, UpdatedBy, AttendenceDate);
        }
        public int UpdateOuttimetimeUser(int DeptID, int DesignationID, int UserID, string Intime, int UpdatedBy, DateTime AttendenceDate, string ExtraOuttime, string Outtimetime)
        {
            return this.AdminDataProviderInstance.UpdateOuttimetimeUser(DeptID, DesignationID, UserID, Intime, UpdatedBy, AttendenceDate, ExtraOuttime, Outtimetime);
        }
        public bool UpdatedealydayCountTask(int StatusMode_id)
        {
            return this.AdminDataProviderInstance.UpdatedealydayCountTask(StatusMode_id);
        }
        public bool getProdctionIDInhouse(string Unitid)
        {
            return this.AdminDataProviderInstance.getProdctionIDInhouse(Unitid);
        }
        public DataSet attlatecommerc()
        {
            return this.AdminDataProviderInstance.attlatecommerc();
        }
        public DataSet Get_AM_Reports()
        {
            return AdminDataProviderInstance.Get_AM_Reports();
        }
        public DataTable GetAccSizeValueSetSizeDelete(int AccsessMasterID, string sizeName)
        {
            return AdminDataProviderInstance.GetAccSizeValueSetSizeDelete(AccsessMasterID, sizeName);
        }

        public int UpdateDeliveryModesdelete(int id)
        {
            return AdminDataProviderInstance.UpdateDeliveryModesdelete(id);
        }
        public List<string> GetAdminHistory(int typeflag, string FieldName, DateTime FromDate, DateTime ToDate)
        {
            return this.AdminDataProviderInstance.GetAdminHistory(typeflag, FieldName, FromDate, ToDate);
        }

        public DataSet GetAllQC_And_Checker()
        {
            return this.AdminDataProviderInstance.GetAllQC_And_Checker();
        }

        public bool Check_SupplierType(string SupplierName, string SupplyType, int Types, string Intial)
        {
            return AdminDataProviderInstance.Check_SupplierType(SupplierName, SupplyType, Types, Intial);
        }

        public List<AuditCategory> GetAllAuditCategories(int flag)
        {
            return AdminDataProviderInstance.GetAllAuditCategories(flag);
        }

        public int CreateAuditCategory(AuditCategory category)
        {
            return AdminDataProviderInstance.CreateAuditCategory(category);
        }

        public int UpdateAuditCategory(AuditCategory category)
        {
            return AdminDataProviderInstance.UpdateAuditCategory(category);
        }

        public DataTable GetAuditCategoryDetails(int categoryId)
        {
            return AdminDataProviderInstance.GetAuditCategoryDetails(categoryId);
        }

        public int DeleteAuditCategoryDetails(AuditCategoryDetails category)
        {
            return this.AdminDataProviderInstance.DeleteAuditCategoryDetails(category);
        }

        public int CreateAuditCategoryDetails(AuditCategoryDetails category)
        {
            int ID = -1;
            if (category.CategoryQuesId == -1)
            {
                ID = this.AdminDataProviderInstance.CreateAuditCategoryDetails(category);
                category.CategoryQuesId = ID;
            }
            else
            {
                ID = this.AdminDataProviderInstance.UpdateAuditCategoryDetails(category);
            }
            return ID;
        }

        public DataTable BindDesignationDdl(int deptId)
        {
            return PermissionDataProviderInstance.GetDesignationByDepartId(deptId);
        }

        public int SaveAuditCategoryDetails(AuditCategoryDetails category)
        {
            return this.AdminDataProviderInstance.CreateAuditCategoryDetails(category);
        }

        public DataTable GetInternalAudit(int categoryId, int unitId)
        {
            return this.AdminDataProviderInstance.GetInternalAudit(categoryId, unitId);
        }

        public DataTable GetFileDetailsByInternalMonthlyAudId(int Id, int UnitId)  //modified 31-05-2021
        {
            return this.AdminDataProviderInstance.GetFileDetailsByInternalMonthlyAudId(Id, UnitId);
        }

        public DataTable GetFileDetailsByInternalMonthlyAudId_New(int Id, int UnitId, int Month, int Year)  //modified 31-05-2021
        {
            return this.AdminDataProviderInstance.GetFileDetailsByInternalMonthlyAudId_New(Id, UnitId, Month, Year);
        }

        public int UploadFileInternalAudit(int Id, string TotalFilePath, int UnitId)
        {
            return this.AdminDataProviderInstance.UploadFileInternalAudit(Id, TotalFilePath, UnitId);
        }

        public int SaveInternalMonthlyAudit(InternalMonthlyAudit monthlyAudit)
        {
            return this.AdminDataProviderInstance.SaveInternalMonthlyAudit(monthlyAudit);
        }

        public DataTable GetAllMonthlyAudit(int categoryId, int unitId, int month, int year)
        {
            return this.AdminDataProviderInstance.GetAllMonthlyAudit(categoryId, unitId, month, year);
        }

        public int SaveAuditors(Auditor auditor)
        {
            return this.AdminDataProviderInstance.SaveAuditors(auditor);
        }

        public DataTable GetAuditorsByCatgQusId(int CatgQusId)
        {
            return this.AdminDataProviderInstance.GetAuditorsByCatgQusId(CatgQusId);
        }

        public int DeleteAuditorById(int Id)
        {
            return this.AdminDataProviderInstance.DeleteAuditorById(Id);
        }

        public int UpdateAuditDetails(AuditCategoryDetails auditCatg)
        {
            return this.AdminDataProviderInstance.UpdateAuditDetails(auditCatg);
        }

        public AuditCategoryDetails GetAuditDetails(int catgQusId)
        {
            return this.AdminDataProviderInstance.GetAuditDetails(catgQusId);
        }

        public bool CheckAuditor(int catgQusId, int userId)
        {
            return this.AdminDataProviderInstance.CheckAuditor(catgQusId, userId);
        }

        public DataSet GetAllUnit()
        {
            return this.AdminDataProviderInstance.GetAllUnit();
        }

        public int InternalAuditCount(int UnitId)
        {
            return this.AdminDataProviderInstance.InternalAuditCount(UnitId);
        }

        public DataSet GetAllMonthYear()
        {
            return this.AdminDataProviderInstance.GetAllMonthYear();
        }

        public DataSet GetLineManAdmin(string SearchText, int LineManType)
        {
            return this.AdminDataProviderInstance.GetLineManAdmin(SearchText, LineManType);
        }

        public DataSet GetMarketingAdmin(string SearchText)
        {
            return this.AdminDataProviderInstance.GetMarketingAdmin(SearchText);
        }

        //public DataSet GetFabCompAdmin(string SearchText)
        //{
        //    return this.AdminDataProviderInstance.GetFabCompAdmin(SearchText);
        //}

        public DataSet GetCollectionAdmin(string SearchText)
        {
            return this.AdminDataProviderInstance.GetCollectionAdmin(SearchText);
        }

        public int SaveCollectionMarketingAdmin1(int hdnId, string CollectionName, bool IsActive, string Flag, int UserId)
        {
            return this.AdminDataProviderInstance.SaveCollectionMarketingAdmin1(hdnId, CollectionName, IsActive, Flag, UserId);
        }

        public int SaveMarketingAdmin1(int hdnId, string MarketingName, bool IsActive, string Flag, int UserId)
        {
            return this.AdminDataProviderInstance.SaveMarketingAdmin1(hdnId, MarketingName, IsActive, Flag, UserId);
        }

        public int SaveMarketingAdmin(string MarketingName, bool IsActive, string Flag, int UserId)
        {
            return this.AdminDataProviderInstance.SaveMarketingAdmin(MarketingName, IsActive, Flag, UserId);
        }

        public int SaveCollectionMarketingAdmin(string CollectionName, bool IsActive, string Flag, int UserId)
        {
            return this.AdminDataProviderInstance.SaveCollectionMarketingAdmin(CollectionName, IsActive, Flag, UserId);
        }

        //public int SaveFabCampMarketingAdmin(string FabCompName, bool IsActive, string Flag, int UserId)
        //{
        //    return this.AdminDataProviderInstance.SaveFabCampMarketingAdmin(FabCompName, IsActive, Flag, UserId);
        //}

        //public int SaveFabCampMarketingAdmin1(int hdnId, string FabCompName, bool IsActive, string Flag, int UserId)
        //{
        //    return this.AdminDataProviderInstance.SaveFabCampMarketingAdmin1(hdnId, FabCompName, IsActive, Flag, UserId);
        //} 

        public int SaveLineManAdmin(string LineManName, string LineManType, bool IsActive, string Flag, int UserId)
        {
            return this.AdminDataProviderInstance.SaveLineManAdmin(LineManName, LineManType, IsActive, Flag, UserId);
        }
        public DataTable GetQCAdmin(string SearchText)
        {
            return this.AdminDataProviderInstance.GetQCAdmin(SearchText);
        }

        public int SaveQCAdmin(int QCId, string QCName, bool IsActive, string Flag, int UserId)
        {
            return this.AdminDataProviderInstance.SaveQCAdmin(QCId, QCName, IsActive, Flag, UserId);
        }


        //public DataSet GetProductionDetails(DateTime FromRange, DateTime ToRange)
        //{
        //    throw new NotImplementedException();
        //}

        public DataSet GetProductionDetails(string Type)
        {
            return this.AdminDataProviderInstance.GetProductionDetails(Type);
        }

        //added by raghvinder on 26th feb 2020 start
        public DataSet GetIncentiveScore()
        {
            return this.AdminDataProviderInstance.GetIncentiveScore();
        }
        //added by raghvinder on 26th feb 2020 end

        public DataTable GetLineDesignation(string DesignationType)
        {
            return this.AdminDataProviderInstance.GetLineDesignation(DesignationType);
        }
        //added by bharat on 18th Mar 2020 startGetIncentiveScoreAmPerformnce
        public DataSet GetIncentiveScoreSampling()
        {
            return this.AdminDataProviderInstance.GetIncentiveScoreSampling();
        }
        public DataSet GetIncentiveScoreAmPerformnce()
        {
            return this.AdminDataProviderInstance.GetIncentiveScoreAmPerformnce();
        }
        //added by bharat on 19th Mar 2020
        public DataTable GetInhouseQCName()
        {
            return this.AdminDataProviderInstance.GetInhouseQCName();
        }

        public DataTable GetInhouseQCUnit()
        {
            return this.AdminDataProviderInstance.GetInhouseQCUnit();
        }


        public DataTable GetInhouseQCLineNo(int UnitVal)
        {
            return this.AdminDataProviderInstance.GetInhouseQCLineNo(UnitVal);
        }

        public DataTable GetInhouseQCCluster(int UnitId)
        {
            return this.AdminDataProviderInstance.GetInhouseQCCluster(UnitId);
        }

        public int RoamingQcEntryFunt(int QcNameval, int Unitnameval, int LineNoval, int Clusterval)
        {
            return this.AdminDataProviderInstance.RoamingQcEntryFunt(QcNameval, Unitnameval, LineNoval, Clusterval);
        }
        public DataTable GetGridViewData()
        {
            return this.AdminDataProviderInstance.GetGridViewData();
        }
        public DataTable GetAccessFileUpload(int AccMasterID, int Acc_qualityID)
        {
            return this.AdminDataProviderInstance.GetAccessFileUpload(AccMasterID, Acc_qualityID);
        }

        public int UpdateAccSizeFile(int accessory_qualityID, string UploadBaseTestFile, string UploadFile)
        {
            return AdminDataProviderInstance.UpdateAccSizeFile(accessory_qualityID, UploadBaseTestFile, UploadFile);
        }

        public int UpdatePartySignBySupplier(int PO_Id, int UserID,string type)
        {
            return AdminDataProviderInstance.PartySignBySupplier(PO_Id, UserID, type);
        }
        public DataSet GetMaterialReport(string flag)
        {
            return AdminDataProviderInstance.GetMaterialReport(flag);
        }

    }
}
