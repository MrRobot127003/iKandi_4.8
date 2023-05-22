using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class WorkflowInstance
    {
        public int WorkflowInstanceID
        {
            get;
            set;
        }

        public Fits Fit
        {
            get;
            set;
        }


        public Style Style
        {
            get;
            set;
        }

        public Order Order
        {
            get;
            set;
        }

        public int OrderDetailID
        {
            get;
            set;
        }

       

        public WorkflowInstanceDetail CurrentStatus
        {
            get;
            set;
        }

        public List<WorkflowInstanceDetail> WorkflowInstanceHistory
        {
            get;
            set;
        }

        public int ProductionPlanningID
        {
            get;
            set;
        }

        public UserTask AdditionalTask
        {
            get;
            set;
        }

        public User AssignedTo
        {
          get;
          set;
        }
    }

    public class WorkflowInstanceDetail
    {
        public int WorkflowInstanceDetailID
        {
            get;
            set;
        }

        public WorkflowInstance WorkflowInstance
        {
            get;
            set;
        }

        public int UserTaskType  // new created by dewasish
        {
            get;
            set;
        }


        public int SubPhaseID
        {
            get;
            set;
        }

        public int StatusModeID
        {
            get;
            set;
        }
        // Add By Ravi kumar for current status on 12/9/2015
        public int CurrentStatusID
        {
            get;
            set;
        }
        // edit by surendra on 3-sep-2013
        public int ischeckAllocationData
        {
            get;
            set;
        }

        public int StatusModeSequence
        {
            get;
            set;
        }

        public double Permission_Sequence
        {
            get;
            set;
        }

        public string StatusMode
        {
            get;
            set;
        }
        public string PO_Number
        {
            get;
            set;
        }

        public string SubPhase
        {
            get;
            set;
        }

        public string Phase
        {
            get;
            set;
        }

        public DateTime ActionDate
        {
            get;
            set;
        }

        public DateTime ETA
        {
            get;
            set;
        }
        public DateTime ExFactory
        {
            get;
            set;
        }
        public string OrderExfactory
        {
            get;
            set;
        }

        public User AssignedTo
        {
            get;
            set;
        }

        public Designation AssignedToDesignation
        {
            get;
            set;
        }

        public ApplicationModule ApplicationModule
        {
            get;
            set;
        }

        public string Task
        {
            get;
            set;
        }

        public string ModeName
        {
            get;
            set;
        }

        public int ActionID
        {
            get;
            set;
        }

        public bool IsHidden
        {
            get;
            set;
        }

        public int StartStatusModeSequence
        {
            get;
            set;
        }

        public int EndStatusModeSequence
        {
            get;
            set;
        }

        public String DepartmentName
        {
            get;
            set;
        }

        public string BIPLPrice
        {
            get;
            set;
        }
        public int FactorySpecification
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }

        public int ValueInR
        {
            get;
            set;
        }
        public string OrderDate
        {
            get;
            set;
        }
        public string ClinetCurrency
        {
            get;
            set;
        }
        public string User_Narration
        {
            get;
            set;
        }
        public string CreateFabricTask
        {
            get;
            set;
        }
        public Int32 Fabric_QualityID
        {
            get;
            set;
        }
        public double BoutiqueBussiness
        {
            get;
            set;
        }
        public double ConversionRate
        {
            get;
            set;
        }
        public string IsIkandiClient
        {
            get;
            set;
        }
        //abhishek on 22/7/2016
        public string ContractNumber
        {
            get;
            set;
        }
        public string LineitemNumber
        {
            get;
            set;
        }
        public string BuyingHouse
        {
            get;
            set;
        }
        public string FinalText
        {
            get;
            set;
        }
        public string Supplier
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }
        

        public string  AgreeRate
        {
            get;
            set;
        }
    }
   

    public class WorkflowPhase
    {
        public Int32 Id
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public Int32 Order
        {
            get;
            set;
        }

        public List<WorkflowSubPhase> SubPhase
        {
            get;
            set;
        }


     

    }

    public class WorkFlowPhaseCollection : Collection<WorkflowPhase>
    {
    }

    public class WorkflowSubPhase
    {
        public Int32 Id
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public Int32 PhaseID
        {
            get;
            set;
        }

        public Int32 Order
        {
            get;
            set;
        }

        public List<ApplicationModule> Modules
        {
            get;
            set;
        }

        public List<ApplicationModule> Forms
        {
            get;
            set;
        }

        public List<ApplicationModule> Files
        {
            get;
            set;
        }

        public List<ApplicationModule> Reports
        {
            get;
            set;
        }
        //added by abhishek on 2/6/2016
        public List<ApplicationModule> Admins
        {
            get;
            set;
        }
        //end by abhishek

    }


    public class StatusModes
    {
        public Int32 StatusModesID
        {
            get;
            set;
        }

        public String StatusModesName
        {
            get;
            set;
        }

        public Int32 StatusModeSequences
        {
            get;
            set;
        }
        public double StatusMode_Double_Sequences
        {
            get;
            set;
        }
        public double StatusMode_ForIntial
        {
            get;
            set;
        }
        public Decimal Permission_Sequence
        {
            get;
            set;
        }

        public Int32 StartSequence
        {
            get;
            set;
        }


        public Int32 EndSequence
        {
            get;
            set;
        }


        public Int32 DesignationID
        {
            get;
            set;
        }
        //Added by abhishek on 20/1/2016

        //public Int32 StatusModesNewID
        //{
        //    get;
        //    set;
        //}

        //public String StatusModesNewName
        //{
        //    get; 
        //    set;
        //}
        //public Int32 StatusModeSequencesNew
        //{
        //    get;
        //    set;
        //}
        //End by abhishek on 20/1/2016
         
    }

     

}
