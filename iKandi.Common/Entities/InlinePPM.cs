using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class InlinePPM : BaseEntity
    {
 
        public int InlinePPMID
        {
            get;
            set;
        }

        public string StyleNumber
        {
            get;
            set;
        }
        public int StyleID
        {
            get;
            set;
        }
        public int orderdetailid
        {
            get;
            set;
        }

        public Order Order
        {
            get;
            set;
        }

        public DateTime DateHeldOn
        {
            get;
            set;
        }

        public string StitchingComments
        {
            get;
            set;
        }

        public string WashCareComments
        {
            get;
            set;
        }

        public string EMBMachineComments
        {
            get;
            set;
        }

        public string EMBHandComments
        {
            get;
            set;
        }

        public string LiningFusingComments
        {
            get;
            set;
        }

        public string LiniingInterLiningComments
        {
            get;
            set;
        }

        public string LiningPocketLiningComments
        {
            get;
            set;
        }

        public string LiningShoulderPadComments
        {
            get;
            set;
        }

        public string FinishingDCComments
        {
            get;
            set;
        }

        public string FinishingWashComments
        {
            get;
            set;
        }

        public string FinishingCrinckleComments
        {
            get;
            set;
        }

        public string PackingTagsComments
        {
            get;
            set;
        }

        public string PackingSpaceButtonsComments
        {
            get;
            set;
        }

        public string PackingCardBoardComments
        {
            get;
            set;
        }


        public string PackingWOCardBoardComments
        {
            get;
            set;
        }

        public string PackingPolytheneComments
        {
            get;
            set;
        }

        public string PackingTissueComments
        {
            get;
            set;
        }

        public string PackingFoamComments
        {
            get;
            set;
        }

        public string PackingHangerPackComments
        {
            get;
            set;
        }

        public string PackingBoxComments
        {
            get;
            set;
        }

        public string PPMRemarks
        {
            get;
            set;
        }

        public string PPMInstructions
        {
            get;
            set;
        }

        public User MerchandisingManager
        {
            get;
            set;
        }

        public User AccountManager
        {
            get;
            set;
        }

        public User FactoryManager
        {
            get;
            set;
        }

        public User ProductionDirecrtor
        {
            get;
            set;
        }

        public User ProductionMaster
        {
            get;
            set;
        }

        public User QAManager
        {
            get;
            set;
        }

        public List<InlinePPMTrims> TrimsComments
        {
            get;
            set;
        }

        public List<InlinePPMOrderContract> OrderContracts
        {
            get;
            set;
        }

        public List<InlinePPMFile> InlinePPmFile
        {
            get;
            set;
        }

        public bool IsApprovedByMerchandisingManager
        {
            get;
            set;
        }

        public bool IsApprovedByAccountManager
        {
            get;
            set;
        }

        public bool IsApprovedByFactoryManager
        {
            get;
            set;
        }

        public bool IsApprovedByProductionDirector
        {
            get;
            set;
        }

        public bool IsApprovedByProductionMaster
        {
            get;
            set;
        }

        public bool IsApprovedByQAManager
        {
            get;
            set;
        }

        public DateTime ApprovedByMerchandisingManagerOn 
        {
            get;
            set;
        }

        public DateTime ApprovedByAccountManagerOn 
        {
            get;
            set;
        }

        public DateTime ApprovedByFactoryManagerOn 
        {
            get;
            set;
        }

        public DateTime ApprovedByProductionDirectorOn 
        {
            get;
            set;
        }

        public DateTime ApprovedByProductionMasterOn 
        {
            get;
            set;
        }

        public DateTime ApprovedByQAManagerOn 
        {
            get;
            set;
        }

        public bool IsMeetingComplete
        {
            get;
            set;
        }

        public DateTime IsMeetingCompletedOn
        {
            get;
            set;
        }

        public bool IsBHMeetingComplete
        {
            get;
            set;
        }

        public DateTime BHMeetingCompleteOn
        {
            get;
            set;
        }


        public DateTime BBPlannedMeeting
        {
            get;
            set;
        }

        public string UserIds
        {
            get;
            set;
        }

        public string UserNames
        {
            get;
            set;
        }

        public string MeetingAttendedOtherUser
        {
            get;
            set;
        }
        public double ProdSAM
        {
            get;
            set;
        }
        public int ProdOB
        {
            get;
            set;
        }

        public string ProdSamFile
        {
            get;
            set;
        }

        public string ProdOBfile
        {
            get;
            set;
        }

    }

    public class InlinePPMTrims : AccessoryWorkingDetail
    {
        public string TrimsComments
        {
            get;
            set;
        }

        public DateTime LastCommentedOn
        {
            get;
            set;
        }

    }

    public class InlinePPMFile
    {
        public int InlinePPMID
        {
            get;
            set;
        }

        public string File
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }
    }

    public class InlinePPMOrderContract : OrderDetail
    {
        public int InlinePPMId
        {
            get;
            set;
        }
        public DateTime TopSentTarget
        {
            get;
            set;
        }

        public DateTime TopSentActual
        {
            get;
            set;
        }

        public DateTime TopActualApproval
        {
            get;
            set;
        }

        public string MDA
        {
            get;
            set;
        }
        //add code debit note 01-apr-19
  
        public string DebitSupplierName
        {
            get;
            set;
        }
        public string CreditSupplierName
        {
            get;
            set;
        }
        public DateTime debitPodate
        {
            get;
            set;
        }
        public DateTime CreditPodate
        {
            get;
            set;
        }
        public int DebitNoteId
        {
            get;
            set;
        }
        public int CreditNoteId
        {
            get;
            set;
        }
         public string DebitNoteNumber
        {
            get;
            set;
        }
         public string CreditNoteNumber
         {
             get;
             set;
         }       
        public DateTime DebitChallanDate
        {
            get;
            set;
        }
        public DateTime CreditChallanDate
        {
            get;
            set;
        }
        public string DebitChallanReturnNo
        {
            get;
            set;
        }
        public string CreditChallanReturnNo
        {
            get;
            set;
        }
        public DateTime FDebitChallanReturnDate
        {
            get;
            set;
        }
        public DateTime FCreditChallanReturnDate
        {
            get;
            set;
        }
        public DateTime PoBillDate
        {
          get;
          set;
        }
        public string DebitRupees
        {
            get;
            set;
        }
        public string DebitAgaistBillNo
        {
            get;
            set;
        }
        public string CreditAgaistBillNo
        {
            get;
            set;
        }

        // add code by bharat 27-mar-19

        public int PoDetailID
        {
            get;
            set;
        }
        public string SupplierName
        {
            get;
            set;
        }
        public string PO_Number
        {
            get;
            set;
        }
        public string Receiving_Voucher_No
        {
            get;
            set;
        }

        public DateTime SRVDate
        {
            get;
            set;
        }
        public string PartyChallanNumber
        {
            get;
            set;
        }
        public string ReceivedUnit
        {
            get;
            set;
        }
        public string SRV_Flag
        {
            get;
            set;
        }
        public string GateNumber
        {
            get;
            set;
        }
        public string ReceivedQty
        {
            get;
            set;
        }
        public string SignFlag
        {

            get;
            set;
        }
        public string ActualReceivedQty { get; set; }
        //new 
        public string SRVRemarks
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public string GarmentUnit
        {
            get;
            set;
        }
        public string SRVFabric
        {
            get;
            set;
        }
        public string Print
        {
            get;
            set;
        }

        public string PartyBillNumber
        {
            get;
            set;
        }


        public string BIPLUploadFile
        {
            get;
            set;
        }

        public string BIPLComments
        {
            get;
            set;
        }

        public string iKandiUploadFile
        {
            get;
            set;
        }

        public string iKandiComments
        {
            get;
            set;
        }
        public string PPSampleStatus
        {
            get;
            set;
        }
        public string PartyAmount
        {
            get;
            set;
        }
        public DateTime Billdate
        {
            get;
            set;
        }
        public int PartyBillId
        {
            get;
            set;
        }
        public int SupplierMasterID
        {
            get;
            set;
        }
        public int SrvMasterID
        {
            get;
            set;
        }
        public TopStatusType TopStatus
        {
            get;
            set;
        }
        public DateTime TOPPlannedDispatchDate
        {
            get;
            set;
        }
        public DateTime SpecUploadPlannedDate
        {
            get;
            set;
        }
        public string DetailClass
        {
            get;
            set;
        }
        public string FabClass
        {
            get;
            set;
        }

        

        public int DebitNote_ParticularId
        {
            get;
            set;
        }
        public string Particulars
        {
            get;
            set;
        }       
        //public decimal DebitRate
        //{
        //    get;
        //    set;
        //}
        public decimal DebitAmount
        {
            get;
            set;
        }
        public decimal TotalAmount
        {
            get;
            set;
        }
        public int DebitNoteIdOut
        {
            get;
            set;
        }
        public int StoreInchargeId
        {
            get;
            set;
        }
        public int QtyCheckedBy
        {
            get;
            set;
        }
        public DateTime StoreInchargeCheckedDate
        {
            get;
            set;
        }
        public DateTime QtyCheckedDate
        {
            get;
            set;
        }
        public string PartyChallanQue
        {
            get;
            set;
        }
        public int IsFabricGMCheckDone
        {
            get;
            set;
        }
        public int ConverToUnit
        {
            get;
            set;
        }
        public int DefaultUnit
        {
            get;
            set;
        }
        public float ConversionValue { get; set; } 


    }
   
}
