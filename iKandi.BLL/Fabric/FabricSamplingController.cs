using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Data;

namespace iKandi.BLL
{
    public class FabricSmplingController: BaseController
    {
        #region

        public FabricSmplingController()
        {
        }

        public FabricSmplingController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        public List<SamplingFabric> GetAllSamplingFabric(int PageSize, int PageIndex, out int TotalPageCount, string SearchText, int ShowLastPage)
        {
            return this.FabricSamplingDataProviderInstance.GetAllSamplingFabric( PageSize,  PageIndex, out  TotalPageCount, SearchText, ShowLastPage);
        }

        public SamplingFabric GetSamplingFabricByID(int SamplingFabricID)
        {


            return this.FabricSamplingDataProviderInstance.GetSamplingFabricByID(SamplingFabricID);
        }

        public bool InsertSamplingFabric(SamplingFabric Fabric)
        {


            return this.FabricSamplingDataProviderInstance.InsertSamplingFabric(Fabric);
        }

        public bool UpdateSamplingFabric(SamplingFabric Fabric)
        {


            return this.FabricSamplingDataProviderInstance.UpdateSamplingFabric(Fabric);
        }

        public List<SamplingFabric> GetSamplingFabricByPrintNumber(string PrintNumber)
        {
            return this.FabricSamplingDataProviderInstance.GetSamplingFabricByPrintNumber(PrintNumber);
        }


        public List<SamplingFabric> GetSamplingFabricByPrintNumber_And_StyleId(string PrintNumber, string parameter2)
        {
            return this.FabricSamplingDataProviderInstance.GetSamplingFabricByPrintNumber_And_StyleId(PrintNumber, parameter2);
        }


        public List<SamplingFabric> GetSamplingFabricByStyleNumber(string StyleNumber)
        {
            return this.FabricSamplingDataProviderInstance.GetSamplingFabricByStyleNumber(StyleNumber);
        }
        /// <summary> 
        /// Yaten : For Binding Solid/Special Grid 26 Apr
        /// </summary>
        /// <param name="StyleNumber"></param>
        /// <returns></returns>
        public DataTable Get_All_Solid_Special_BLL(string StyleNumber)
        {
            DataTable dt = FabricSamplingDataProviderInstance.Get_All_Solid_Special(StyleNumber);
            return dt;
        }
    }
}
