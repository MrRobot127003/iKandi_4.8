using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class QualityControl
    {
        public int Id
        {
            get;
            set;
        }

        public OrderDetail OrderDetail
        {
            get;
            set;
        }

        
        public int TotalBoxes
        {
            get;
            set;
        }

        public int QA
        {
            get;
            set;
        }

        public int ActualSamplesChecked
        {
            get;
            set;
        }

        public int TotalMajorFaults
        {
            get;
            set;
        }

        public int TotalMinorFaults
        {
            get;
            set;
        }

        public int TotalCriticalFaults
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string CommentsBy_DMM
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public int ProcessingInstruction
        {
            get;
            set;
        }
        public int Production_Unit
        {
            get;
            set;
        }

        public string OtherInstruction
        {
            get;
            set;
        }

        public int ApprovedByQAManager
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public DateTime ApprovedByQAManagerOn
        {
            get;
            set;
        }

        public DateTime DateConducted
        {
            get;
            set;
        }

        public List<QualityFaults> Faults
        {
            get;
            set;
        }

        public List<QualityFaults> Faults1
        {
            get;
            set;
        }

        public List<QualityFaults> FaultsPP
        {
            get;
            set;
        }

        public List<QualityFaultsCategory> Category
        {
            get;
            set;
        }

        public List<QualityFaultsSubCategory> SubCategory
        {
            get;
            set;
        }

        public List<QualityProcess> Process
        {
            get;
            set;
        }
        public List<LineManQC> LineMan
        {
            get;
            set;
        }        

        public int SampleQuantity
        {
            get;
            set;
        }

        public int MajorDefectsAllowed
        {
            get;
            set;
        }

        public int MinorDefectsAllowed
        {
            get;
            set;
        }

        public string AqlValue
        {
            get;
            set;
        }
        #region Gajendra Workflow

        public int ApprovedByClientHead
        {
            get;
            set;
        }
        
        public DateTime ApprovedByClientHeadOn
        {
            get;
            set;
        }
        public int ApprovedByFactoryHead
        {
            get;
            set;
        }
        
        public DateTime ApprovedByFactoryHeadOn
        {
            get;
            set;
        }
        #endregion

        public int InspectionID
        {
            get;
            set;
        }

        public string InspectionType
        {
            get;
            set;
        }
        public string RiskRemarks
        {
            get;
            set;
        }
        public int ApprovedByCQD_QAManager
        {
            get;
            set;
        }
        public DateTime ApprovedByCQD_QAManagerOn
        {
            get;
            set;
        }

        public int ApprovedByShippingOfficer
        {
            get;
            set;
        }

        public DateTime ApprovedByShippingOfficerOn
        {
            get;
            set;
        }
        public int ApprovedByDMM
        {
            get;
            set;
        }

        public DateTime ApprovedByDMMOn
        {
            get;
            set;
        }

        public int ApprovedByBuyingHouse
        {
            get;
            set;
        }

        public DateTime ApprovedByBuyingHouseOn
        {
            get;
            set;
        }

        public int ApprovedByBuyingHouse_Factory
        {
            get;
            set;
        }

        public DateTime ApprovedByBuyingHouse_FactoryOn
        {
            get;
            set;
        }

        public int ApprovedByBuyingHouse_IC
        {
            get;
            set;
        }

        public DateTime ApprovedByBuyingHouse_ICOn
        {
            get;
            set;
        }

        public string BuyingHouse_FilePath
        {
            get;
            set;
        }


        public string InlineTopFiftyReports
        {
            get;
            set;
        }
        public int MissedfaultCount
        {
          get;
          set;
        }
        public int TotalOcuured
        {
          get;
          set;
        }
        public string BuyingHouse_Factory_FilePath
        {
            get;
            set;
        }

        public string BuyingHouse_IC_FilePath
        {
            get;
            set;
        }

        public String FaultXML
        {
            get;
            set;
        }
        public static int SQualityId
        {
            get;
            set;
        }
        public string BuyingHouse_Status
        {
            get;
            set;
        }

        public string BuyingHouse_QAName
        {
            get;
            set;
        }
        public string BuyingHouseFactory_Status
        {
            get;
            set;
        }

       
        public int shippedqty
        {
            get;
            set;
        }
        public bool IsShipped
        {
            get;
            set;
        }
        public double BP_CR
        {
            get;
            set;
        }

        public string BuyingHouseFactory_QAName
        {
            get;
            set;
        }
        public int chkGMQA
        {
            get;
            set;
        }
        public int chkCQD
        {
            get;
            set;
        }
        public int chkFactoryManager
        {
            get;
            set;
        }
        public int chkProdIncharge
        {
            get;
            set;
        }
        public int chkQC
        {
            get;
            set;
        }
        public int chkFinishIncharge
        {
            get;
            set;
        }
        public int chkFinishSuperwisor
        {
            get;
            set;
        }
        public int ckhLineMan
        {
            get;
            set;
        }
        public int chkAsstLineMan
        {
            get;
            set;
        }
        public int chkChecker
        {
            get;
            set;
        }
        public int chkPressMan
        {
            get;
            set;
        }
        public int chkOthers
        {
            get;
            set;
        }
        public string AdditionalInformation
        {
            get;
            set;
        }
        public bool WithoutNatureOfFaults
        {
            get;
            set;
        }
        //Add By Prabhaker 07-feb-18

        public int LineManId
        {
            get;
            set;
        }

        public int QcId
        {
            get;
            set;
        }


        //   End Of Code
        public string ProcessXML
        {
            get;
            set;
        }
    }

    public class QualityFaults : QualityControlStatus
    {
        public int Id
        {
            get;
            set;
        }

        public QualityControl ParentQualityControl
        {
            get;
            set;
        }

        public int FaultId
        {
            get;
            set;
        }

        public string FaultDescription
        {
            get;
            set;
        }

        public string Fault
        {
            get;
            set;
        }

        public string FaultValue
        {
            get;
            set;
        }

        public string Resolution
        {
            get;
            set;
        }

        public int Occurrence
        {
            get;
            set;
        }

        public int FaultType
        {
            get;
            set;
        }

        public int IsOnline
        {
            get;
            set;
        }

        public int IsDeleted
        {
            get;
            set;
        }

        public int Owner
        {
            get;
            set;
        }

        public int Permission
        {
            get;
            set;
        }

        public string LastResolution
        {
            get;
            set;
        }

        public int QualityFaultsCategoryId
        {
            get;
            set;
        }

        public int QualityFaultsSubCategoryId
        {
            get;
            set;
        }

        public string FaultSubCategoryType
        {
            get;
            set;
        }

        public string FaultCategoryType
        {
            get;
            set;
        }

        public int ProductionPlanningID //NTR
        {
            get;
            set;
        }

        public int ShippingQty
        {
            get;
            set;
        }

        public bool IsPartShipment //NTR
        {
            get;
            set;
        }
        public string InspectionID
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }
        public string FaultDetails
        {
            get;
            set;
        }
        public string CorrectiveActionPlan
        {
            get;
            set;
        }
    }

    public class ItemsToCheck
    {
        public int Id
        {
            get;
            set;
        }

        public QualityControl ParentQualityControl
        {
            get;
            set;
        }

        public int Missing
        {
            get;
            set;
        }

        public int NotRequired
        {
            get;
            set;
        }

        public int Present
        {
            get;
            set;
        }

        public int CheckingItem
        {
            get;
            set;
        }
        public int ProductionPlanningID
        {
            get;
            set;
        }
        public string InspectionID
        {
            get;
            set;
        }
    }

    public class QualityFaultsCategory
    {
        public int Id
        {
            get;
            set;
        }

        public string FaultCategoryType
        {
            get;
            set;
        }

    }

    public class QualityFaultsSubCategory
    {
        public int Id
        {
            get;
            set;
        }

        public string FaultSubCategoryType
        {
            get;
            set;
        }

        public string FaultCategoryType
        {
            get;
            set;
        }

        public List<QualityFaults> SubCategoryFaults
        {
            get;
            set;
        }


    }

    public class QualityControlStatus
    {
        public int Id
        {
            get;
            set;
        }

        public QualityControl ParentQualityControl
        {
            get;
            set;
        }

        public int ProductionPlanningID
        {
            get;
            set;
        }

        public String Status
        {
            get;
            set;
        }

        public int QA
        {
            get;
            set;
        }

        public int ActualSamplesChecked
        {
            get;
            set;
        }

        public DateTime DateConducted
        {
            get;
            set;
        }

        public int SampleQuantity
        {
            get;
            set;
        }

        public int MajorDefectsAllowed
        {
            get;
            set;
        }

        public int MinorDefectsAllowed
        {
            get;
            set;
        }

        public string AqlValue
        {
            get;
            set;
        }

        public List<ItemsToCheck> CheckingItems
        {
            get;
            set;
        }

        public List<OrderDetailSizes> SizesList
        {
            get;
            set;
        }        
    }

    public class QualityContract
    {
        public string OrderDetailID
        {
            get;
            set;
        }
        public string ContractNumber
        {
            get;
            set;
        }  
    }

    public class QualityProcess
    {
        public string ProcessId
        {
            get;
            set;
        }
        public string ProcessName
        {
            get;
            set;
        }
        public int ProcessStatus
        {
            get;
            set;
        }
        public string ProcessActivePlan
        {
            get;
            set;
        }

    }

    public class LineManQC
    {
        public int LineManId
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public int QCId
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
    }
    public class QCFormSupport
    {
      public string Flag
      {
        get;
        set;
      }
      public int QCID
      {
        get;
        set;
      }
      public int OrderDetailID
      {
        get;
        set;
      }
      public string Contarctnumber
      {
        get;
        set;
      }
      public string Updatedon
      {
        get;
        set;
      }
      public string CQDname
      {
        get;
        set;
      }
      public string Qty
      {
        get;
        set;
      }
      public string SerialNumber
      {
        get;
        set;
      }
    }
    

}
