using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class ProductionUnit
    {
        public int ProductionUnitId
        {
            get;
            set;
        }

        public string FactoryName
        {
            get;
            set;
        }

        public string FactoryCode
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public int NumberOfMachines
        {
            get;
            set;
        }

        public int NumberOfLines
        {
            get;
            set;
        }

        public int NumberOfFloors
        {
            get;
            set;
        }

        public double Capacity
        {
            get;
            set;
        }

        public int ProductionUnitManagerId
        {
            get;
            set;
        }

        public string ProductionUnitManagerName
        {
            get;
            set;
        }

        public string ProductionUnitColor
        {
            get;
            set;
        }

        public int QAFactoryHeadId
        {
            get;
            set;
        }

        public string QAFactoryHeadName
        {
            get;
            set;
        }
        //Added by Abhishek on 5/6/2015
        public int Classification
        {
            get;
            set;
        }
        //Added by Bharat on 01/02/2020
        public string EmailId
        {
            get;
            set;
        }

        public double Unit_Monthly_Overheads
        {
            get;
            set;
        }

        public string Clientname
        {
            get;
            set;
        }
        public string fillterClientname
        {
            get;
            set;
        }
        //Added on 16/6/2015
        public int Cuttingshare
        {
            get;
            set;
        }
        public int stitchingshar
        {
            get;
            set;
        }
        public int finishingshar
        {
            get;
            set;
        }
        //added on 17/8/2015
        public int Finishing_Active
        {
            get;
            set;
        }
        public int Cutting_Active
        {
            get;
            set;

        }
        //end on 17/8/2015

        //added on 24/8/2015
        public string FactoryIE
        {
            get;
            set;
        }
        public string WirterIE
        {
            get;
            set;

        }
        //end on 17/8/2015

        
        //added on 14/9/2015
        public int FinishingAllocate_Unit
        {
            get;
            set;
        }
        public int CuttingAllocate_Unit
        {
            get;
            set;

        }
        //end on 14/9/2015


        //added by abhishek on 24/11/2015
       
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
        public string FileUploadUrl3
        {
            get;
            set;
        }

        public string FileUploadUrl4
        {
            get;
            set;
        }
        public int finishingSupervisor
        {
            get;
            set;
        }
        public int FinishingIncharge
        {
            get;
            set;

        }
        public int finishingQa
        {
            get;
            set;

        }
        public int Cluster
        {
            get;
            set;

        }

        public int IsVA_Enabled
        {
            get;
            set;
        }

        //end by abhishek on 24/11/2015
    }

    public class ProductionUnitCollection : List<ProductionUnit>
    {

    }

    public class OrderAllocationToProductionUnit
    {
        public int Id
        {
            get;
            set;
        }

        public ProductionUnit ProductionUnit
        {
            get;
            set;
        }

        public Order Order
        {
            get;
            set;
        }

        public OrderDetail OrderDetail
        {
            get;
            set;
        }

        public Int32 TotalPCSIssuedToUnit
        {
            get;
            set;
        }

        public Int32 PCSStichedToday
        {
            get;
            set;
        }

        public Int32 TotalPCSStiched
        {
            get;
            set;
        }

        public Int32 PCSPackedToday
        {
            get;
            set;
        }

        public Int32 TotalPCSPacked
        {
            get;
            set;
        }
      
    }

    public class ProductionDetail
    {
        public int OrderDetailId
        {
            get;
            set;
        }
        public DateTime RescanDate
        {
            get;
            set;
        }
        public int C47_ScanValue
        {
            get;
            set;
        }
        public int D169_ScanValue
        {
            get;
            set;
        }
        public int C52_ScanValue 
        {
            get;
            set;
        }
        public int C4546_ScanValue
        {
            get;
            set;
        }
        public bool chkIsScan
        {
            get;
            set;
        }
        public bool chkRescanCycle
        {
            get;
            set;
        }
        public bool chkRescanCycle1
        {
            get;
            set;
        }
        public bool chkRescanCycle2
        {
            get;
            set;
        }
        public bool chkRescanCycle3
        {
            get;
            set;
        }
        public bool chkRescanCycle4
        {
            get;
            set;
        }
        public bool chkRescanCycle5
        {
            get;
            set;
        }
        public bool chkRescanCycle6
        {
            get;
            set;
        }

        public bool chkRescanCycle7
        {
            get;
            set;
        }
        public bool chkRescanCycle8
        {
            get;
            set;
        }

    }
}
