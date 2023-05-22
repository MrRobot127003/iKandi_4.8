using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common.Entities
{
    public class OrderFlow : BaseEntity
    {
        public int ClientID
        {
            get;
            set;
        }
        public int DeptID
        {
            get;
            set;
        }
        public string StyleCode
        {
            get;
            set;
        }
        public int Styleid
        {
            get;
            set;
        }
        public int ReusestyleID
        {
            get;
            set;
        }
        public DateTime EventDate
        {
            get;
            set;
        }
    }
    public class RiskAnalysisOB : BaseEntity
    {
        public int Styleid
        {
            get;
            set;
        }
        public int ReusestyleID
        {
            get;
            set;
        }
        public string StyleCode
        {
            get;
            set;
        }
        public int StyleidVirsion
        {
            get;
            set;
        }
        public string StyleCodeVirsion
        {
            get;
            set;
        }
        public int RiskAnalysisID
        {
            get;
            set;
        }
        public bool IsAccountMgr
        {
            get;
            set;
        }
        public DateTime AccountMgrApprovedOn
        {
            get;
            set;
        }
        public bool IsQAPreProd
        {
            get;
            set;
        }

        public bool ISVaRequried
        {
            get;
            set;
        }
        public DateTime QAPreProdApprovedOn
        {
            get;
            set;
        }       
           
        public bool IsQAProd
        {
            get;
            set;
        }
        public DateTime QAProdApprovedOn
        {
            get;
            set;
        }

        public bool IsMerchandisingMgr
        {
            get;
            set;
        }
        public DateTime MerchandisingMgrApprovedOn
        {
            get;
            set;
        }    
        public string FabricRemarks
        {
            get;
            set;
        }
        public string AccesoriesRemarks
        {
            get;
            set;
        }
        public string FittingRemarks
        {
            get;
            set;
        }
        public string MakingRemarks
        {
            get;
            set;
        }
        public string OtherRemarks
        {
            get;
            set;
        }
        //added by abhishek on 17/5/2017
        public string QaRepresentativeIds
        {
            get;
            set;
        }

        public string FactoryRepresentativeIds
        {
            get;
            set;
        }

        public string QaRepresentativeNames
        {
            get;
            set;
        }

        public string FactoryRepresentativeNames
        {
            get;
            set;
        }
        public string IERepresentativesId
        {
            get;
            set;
        }

        public string IERepresentativesName
        {
            get;
            set;
        }
        public string SamplingRepresentativesId
        {
            get;
            set;
        }

        public string SamplingRepresentativesName
        {
            get;
            set;
        }
        public string FabricRepresentativesId
        {
            get;
            set;
        }

        public string FabricRepresentativesName
        {
            get;
            set;
        }
        public string AccessoryRepresentativesId
        {
            get;
            set;
        }

        public string AccessoryRepresentativesName
        {
            get;
            set;
        }
        public string OutRepresentativesId
        {
            get;
            set;
        }

        public string OutRepresentativesName
        {
            get;
            set;
        }
        //Added By Ashish on 23/7/2015

        public string MerchandiserId
        {
            get;
            set;
        }

        public string MerchandiserName
        {
            get;
            set;
        }

    }


    public class OBForm : BaseEntity
    {
        public int SectionId
        {
            get;
            set;
        }

        public string GarmentId
        {
            get;
            set;
        }

        public int FinalOBID
        {
            get;
            set;
        }

        public int ClientID
        {
            get;
            set;
        }
        public int DeptId
        {
            get;
            set;
        }
        public string StyleCode
        {
            get;
            set;
        }
        public int GarmentTypeID
        {
            get;
            set;
        }
        public int OperationId
        {
            get;
            set;
        }
        public int WorkerTypeID
        {
            get;
            set;
        }
        public int NoOfOperation
        {
            get;
            set;
        }
        public int OperationcuttingId
        {
            get;
            set;
        }
        public int FactoryWorkSpaceId
        {
            get;
            set;
        }
        public int AttachmentID
        {
            get;
            set;
        }
        public string Flag
        {
            get;
            set;
        }

        public Double Sam
        {
            get;
            set;
        }
        public Double Machine
        {
            get;
            set;
        }
        public Double MachineCount
        {
            get;
            set;
        }
        public int FinalCount
        {
            get;
            set;
        }
        public string Comments
        {
            get;
            set;
        }
      




    }

    public class OBCutting : BaseEntity
    {
        public int OperationId
        {
            get;
            set;
        }

        public int OperationName
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
    }



    public class HOPPMOB : BaseEntity
    {
        public int Styleid
        {
            get;
            set;
        }
        public int ReusestyleID
        {
            get;
            set;
        }
        public string StyleCode
        {
            get;
            set;
        }
        public int StyleidVirsion
        {
            get;
            set;
        }
        public string StyleCodeVirsion
        {
            get;
            set;
        }
        public int RiskAnalysisID
        {
            get;
            set;
        }
        public bool IsMerchandisingManagerApprovedOn
        {
            get;
            set;
        }
        public DateTime MerchandisingManagerApprovedOn
        {
            get;
            set;
        }
        public bool IsQAPreProdApprovedOn
        {
            get;
            set;
        }
        public DateTime QAPreProdApprovedOn
        {
            get;
            set;
        }
        public bool IsQAProdApprovedOn
        {
            get;
            set;
        }
        public DateTime QAProdApprovedOn
        {
            get;
            set;
        }
        public string FabricRemarks
        {
            get;
            set;
        }
        public string AccesoriesRemarks
        {
            get;
            set;
        }
        public string CuttingRemarks
        {
            get;
            set;
        }
        public string MakingRemarks
        {
            get;
            set;
        }
        public string EmbroideryRemarks
        {
            get;
            set;
        }
        public string WashingRemarks
        {
            get;
            set;
        }
        public string FinishingRemarks
        {
            get;
            set;
        }

        public string QaRepresentativeIds
        {
            get;
            set;
        }

        public string FactoryRepresentativeIds
        {
            get;
            set;
        }

        public string QaRepresentativeNames
        {
            get;
            set;
        }

        public string FactoryRepresentativeNames
        {
            get;
            set;
        }

        //Added By Ashish on 23/7/2015

        public string MerchandiserId
        {
            get;
            set;
        }

        public string MerchandiserName
        {
            get;
            set;
        }

        public string FileUploadUrl1 
        {
            get;
            set;
        }

        public string FileUploadUrl2
        {
            get;
            set;
        }

        //

        public bool IsFactoryPPMComplete
        {
            get;
            set;
        }
        public DateTime FactoryPPMCompleteOn
        {
            get;
            set;
        }
        public bool IsHOPPMComplete
        {
            get;
            set;
        }
        public DateTime HOPPMCompleteOn
        {
            get;
            set;
        }
        //added by abhishek 20/6/2016

        public bool Seam_Slippage_OK
        {
            get;
            set;
        }

        

    }

}
