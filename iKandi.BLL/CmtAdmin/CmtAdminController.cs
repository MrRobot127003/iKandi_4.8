using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.BLL.CmtAdmin;
using iKandi.DAL;
using System.Data;
using iKandi.Common.Entities;

namespace iKandi.BLL.CmtAdmin
{
    public class CmtAdminController : BaseController
    {
       CmtAdminDataProvider objCmtAdmin = new CmtAdminDataProvider();
       //added by abhishek on 26/10/2015
       public int UpdateCMTAdmin(int CMTId, float AvlMinCost, float hrs, int barrierDays, int hdnUId, float txtpro_availble_mincost, float pro_hours, int maxload, int createobdays, int barrirday)
       {
           return this.objCmtAdmin.UpdateCMTAdmin(CMTId, AvlMinCost, hrs, barrierDays, hdnUId, txtpro_availble_mincost, pro_hours, maxload,createobdays,barrirday);

       }
       //end by abhishek on 26/10/2015

       //added by bharat on 25-july
       public int InsertCRTOrderQty(int textval, int Sr_No,string Flag)
       {
           return this.objCmtAdmin.InsertCRTOrderQty(textval, Sr_No, Flag);

       }
        // end
        public DataTable GetCmt()
        {
          return this.objCmtAdmin.GetCmtDAL();
           
        }
        public DataTable GetTargetDays()
        {
            return this.objCmtAdmin.TargetDaysDAL();

        }
        public DataTable GetAchievmentLabels()
        {
            return this.objCmtAdmin.GetAchievmentLabelsDAL();

        }


        public int InsertUpdateCMTEff(CMTAdmin pro_cmt)
        {
          return this.objCmtAdmin.InsertUpdateCMTEffDAL(pro_cmt);

        }
        //

        public int InsertUpdateCMTEAchievement(CMTAdmin pro_cmt)
        {
            return this.objCmtAdmin.InsertUpdateCMTEAchievementdal(pro_cmt);

        }

        //Added By Ashish on 14/11/2014

        public List<CMTSizeAdmin> GetSizeSetAdmin()
        {
            return this.objCmtAdmin.GetSizeSetAdmin();
        }

        public DataTable GetSizeSet()
        {
            return this.objCmtAdmin.GetSizeSet();

        }

        public int InsertSizeSet(List<CMTSizeAdmin> pos)
        {
            return this.objCmtAdmin.InsertSizeSet(pos);
        }
        public List<CMTSizeAdmin> GetSizeSetById(int Option)
        {
            return this.objCmtAdmin.GetSizeSetById(Option);
        }
        //Adde By Ashish on 25/12/2014 
        public DataTable BarrierDaysBAL()
        {
            return this.objCmtAdmin.BarrierDaysDAL();

        }

        public int UpdateBarrierDays(CMTAdmin pro_cmt)
        {
            return this.objCmtAdmin.UpdateBarrierDaysDAL(pro_cmt);

        }
        //added by abhishek on 27/8/2015
        public DataTable getOtCMTdetails()
        {
            return this.objCmtAdmin.getOtCMTdetails();
        }
        public DataTable Financial_dt()
        {
            return this.objCmtAdmin.Financial_dt();
        }
        public DataTable ProductionCost_dt()
        {
            return this.objCmtAdmin.ProductionCost_dt();
        }
        public DataTable OBCost_dt()
        {
            return this.objCmtAdmin.OBCost_dt();
        }

        public int Update_getOtCMTdetails(double ot1, double ot2, double ot3, double ot4)
        {
            return this.objCmtAdmin.Update_getOtCMTdetails(ot1, ot2, ot3, ot4);

        }
        public int Update_getProductionPieces(double Stiching, double Finishing)
        {
            return this.objCmtAdmin.Update_getProductionPieces(Stiching, Finishing);

        }
        public int Update_OBCostPerPieces(double CuttingCost, double FactoryOverHead, double OBPerPicesCost, double FinishingCost, double FabricCost, double AccesoriesCost, double LabourBaseSalary, double PFESI, double DiwaliGift, double Gratuity, double WorkingDays, int ActualWorkingDays, double IGST, double CGST, double SGST, int CMTOHSLOT)
        {
            return this.objCmtAdmin.Update_OBCostPerPieces(CuttingCost, FactoryOverHead, OBPerPicesCost, FinishingCost, FabricCost, AccesoriesCost, LabourBaseSalary, PFESI, DiwaliGift, Gratuity, WorkingDays, ActualWorkingDays, IGST, CGST, SGST, CMTOHSLOT);
        }
        
        public int Update_FinancialDetail(string From, string to)
        {
            return this.objCmtAdmin.Update_FinancialDetail(From,to);
        }

        //End abhishek on 27/8/2015

        //added by abhishek on 26/10/2015
        public int  Update_CMT_barrieday(string Colname, int Colval)
        {
            return objCmtAdmin.Update_CMT_barrieday(Colname, Colval);
        }
        public DataTable getOtCMTdetails_barrieday()
        {
            return this.objCmtAdmin.getOtCMTdetails_barrieday();

        }
        public DataSet GetCmtExpectedQty()
        {
            return this.objCmtAdmin.GetCmtExpectedQty();

        }
        public string UpdateCmtCostingExpectedQty(CMTAdmin objCmt)
        {
            return this.objCmtAdmin.UpdateCmtCostingExpectedQty(objCmt);
        }
        //End abhishek on 26/10/2015

        // Added By Ravi kumar on 18-4-18 for Update sunday working
        public int UpdateSundayWorking(int IsSundayWorking)
        {
            return this.objCmtAdmin.UpdateSundayWorking(IsSundayWorking);
        }
    }
}
