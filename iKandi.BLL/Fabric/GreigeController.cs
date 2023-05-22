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
namespace iKandi.BLL
{
   public class GreigeController : BaseController
    {
        public GreigeController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }
        public GreigeController()           
        {
        }
        public FabricGroupAdmin getFabricBIPLinfoBAL(string Fabric)
        {
            FabricGroupAdmin FGA = new FabricGroupAdmin();
            FGA.FabricGroup = this.GreigeStockDataProviderInstance.getFabricBIPLinfoDAL(Fabric);          
            return FGA;
        }
        public DataSet GetSupplierAllBAL(string Fab, string Qty,string isStock,int MasterPOID)
        {
            return this.GreigeStockDataProviderInstance.GetSupplierAllDAL(Fab,Qty,isStock,MasterPOID);
        }

        public DataSet GetPOQualityBAL( int MasterPOID)
        {
            return this.GreigeStockDataProviderInstance.GetPOQualityDAL(MasterPOID);
        }
       
    }
}
