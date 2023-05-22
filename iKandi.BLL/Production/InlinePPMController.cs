using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;

namespace iKandi.BLL
{
    public class InlinePPMController : BaseController
    {
        #region Ctor(s)

        public InlinePPMController()
        {
        }

        public InlinePPMController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Public Methods

        public InlinePPM GetInlinePPMByStyleID(string StyleNumber, int StyleId)
        {
            return this.InlinePPMDataProviderInstance.GetInlinePPMByStyleID(StyleNumber, StyleId);
        }

        public InlinePPM GetInlinePPM(string StyleNumber, int DeptID)
        {
            return this.InlinePPMDataProviderInstance.GetInlinePPM(StyleNumber, DeptID);
        }

        public List<InlinePPMFile> GetPPMFileDataByPPMID(int InlinePPMID)
        {
            return this.InlinePPMDataProviderInstance.GetPPMFileInfoByPPMID(InlinePPMID);
        }


        public bool DeleteInlinePPMFile(int Id)
        {
            return this.InlinePPMDataProviderInstance.DeleteInlinePPMFile(Id);
        }

        #endregion

        #region Private Methods

        #endregion


        public void Save(InlinePPM InlinePPMData)
        {
            if (InlinePPMData.InlinePPMID == -1)
                this.InlinePPMDataProviderInstance.InsertInlinePPM(InlinePPMData);
            else
                this.InlinePPMDataProviderInstance.UpdateInlinePPM(InlinePPMData);
        }
    }
}
