using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;

namespace iKandi.BLL
{
    public class FourPointController:BaseController
    { 
        //test
        #region Ctor(s)
        public FourPointController()
        {
        }

        public FourPointController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }
        #endregion

        #region Methods
        //Four Point Check Block
        public List<FourPointCheckAdmin> GetFourPointCheck(int tableId, int id)
        {
            return this.FoutPointDataProviderInstance.GetFourPointCheck(tableId, id);
        }

        public int UpdateFourPointCheckHolePatta(int patta, int hole)
        {
            return this.FoutPointDataProviderInstance.UpdateFourPointCheckHolePatta(patta, hole);
        }

        public int Insert_UpdateFourPointAC(string process, int point, int iu, int id)
        {
            return this.FoutPointDataProviderInstance.Insert_UpdateFourPointAC(process, point, iu, id);
        }

        public void DeleteFourPointAC(int id, int tableId)
        {
            this.FoutPointDataProviderInstance.DeleteFourPointAC(id, tableId);
        }

        public int Insert_UpdateFourPointPR(FourPointCheckAdmin fourPointCheck)
        {
            return this.FoutPointDataProviderInstance.Insert_UpdateFourPointPR(fourPointCheck);
        }

        public List<string> GetFourPoint(string type, string q)
        {
            return this.FoutPointDataProviderInstance.GetFourPointProcess(type, q);
        }

        public int Insert_UpdateFourPointDetail(FourPointDetail fpc)
        {
            return this.FoutPointDataProviderInstance.Insert_UpdateFourPointDetail(fpc);
        }

        public FourPointSystemHeader GetFpsHeader(int poId, int wId)
        {
            return this.FoutPointDataProviderInstance.GetFpsHeader(poId, wId);
        }

        public FourPointDetail GetFourPointData(int FourPointId)
        {
            return this.FoutPointDataProviderInstance.GetFourPointData(FourPointId);
        }

        public int Insert4PCFMQA(FourPointDetail fpd)
        {
            return this.FoutPointDataProviderInstance.Insert4PCFMQA(fpd);
        }

        #endregion
    }
}
