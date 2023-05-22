using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class FabricWorking
    {
        public int Id
        {
            get;
            set;
        }

        public Order order
        {
            get;
            set;
        }

        public double Fabric1Wastage
        {
            get;
            set;
        }

        public double Fabric1Shrinkage
        {
            get;
            set;
        }

        public double Fabric1Greige
        {
            get;
            set;
        }


        public double TotalFabric1Greige
        {
            get;
            set;
        }
        public double TotalFabric2Greige
        {
            get;
            set;
        }
        public double TotalFabric3Greige
        {
            get;
            set;
        }
        public double TotalFabric4Greige
        {
            get;
            set;
        }


        public double Fabric1FinalOrder
        {
            get;
            set;
        }

        public double Fabric2Wastage
        {
            get;
            set;
        }

        public double Fabric2Shrinkage
        {
            get;
            set;
        }

        public double Fabric2Greige
        {
            get;
            set;
        }

        public double Fabric2FinalOrder
        {
            get;
            set;
        }

        public double Fabric3Wastage
        {
            get;
            set;
        }

        public double Fabric3Shrinkage
        {
            get;
            set;
        }

        public double Fabric3Greige
        {
            get;
            set;
        }

        public double Fabric3FinalOrder
        {
            get;
            set;
        }

        public double Fabric4Wastage
        {
            get;
            set;
        }

        public double Fabric4Shrinkage
        {
            get;
            set;
        }

        public double Fabric4Greige
        {
            get;
            set;
        }

        public double Fabric4FinalOrder
        {
            get;
            set;
        }

        public string Fabric1Remarks
        {
            get;
            set;
        }

        public string Fabric2Remarks
        {
            get;
            set;
        }

        public string Fabric3Remarks
        {
            get;
            set;
        }

        public string Fabric4Remarks
        {
            get;
            set;
        }

        public string FabricRemarks
        {
            get;
            set;
        }

        public double TotalGreigeFabric
        {
            get;
            set;
        }

        public int AvgChecked
        {
            get;
            set;
        }

        public int AcknowledgmentChecked
        {
            get;
            set;
        }

        public int ApprovedAcknowledgementManager
        {
            get;
            set;
        }
        public DateTime ApprovedAcknowledgementManagerOn
        {
            get;
            set;
        }

        public int ApprovedByAccountManager
        {
            get;
            set;
        }

        public int ApprovedByFabricManager
        {
            get;
            set;
        }

        public string CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedOn
        {
            get;
            set;
        }

        public string UpdatedBy
        {
            get;
            set;
        }

        public DateTime UpdatedOn
        {
            get;
            set;
        }

        public DateTime AvgCheckedOn
        {
            get;
            set;
        }

        public DateTime ApprovedByAccountManagerOn
        {
            get;
            set;
        }

        public DateTime ApprovedByFabricManagerOn
        {
            get;
            set;
        }

        public string AllRemarks
        {
            get;
            set;
        }

        public double Fabric1InitialWidth
        {
            get;
            set;
        }

        public double Fabric2InitialWidth
        {
            get;
            set;
        }

        public double Fabric3InitialWidth
        {
            get;
            set;
        }

        public double Fabric4InitialWidth
        {
            get;
            set;
        }

        public double Fabric1UsableWidth
        {
            get;
            set;
        }

        public double Fabric2UsableWidth
        {
            get;
            set;
        }

        public double Fabric3UsableWidth
        {
            get;
            set;
        }

        public double Fabric4UsableWidth
        {
            get;
            set;
        }

        public string UnitOfAverage1
        {
            get;
            set;
        }

        public string UnitOfAverage2
        {
            get;
            set;
        }

        public string UnitOfAverage3
        {
            get;
            set;
        }

        public string UnitOfAverage4
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }

        public string History
        {
            get;
            set;
        }
        public string Fabric1File
        {
            get;
            set;
        }
        public string Fabric2File
        {
            get;
            set;
        }
        public string Fabric3File
        {
            get;
            set;
        }
        public string Fabric4File
        {
            get;
            set;
        }
        //added by abhishek no 21/12/2015
        public int PrintColorRecdFabric
        {
            get;
            set;
        }
        public Int32 FabricQualtityAprdFabric
        {
            get;
            set;
        }
        public string PrintColorRecdOnFabric
        {
            get;
            set;
        }
        public string FabricQualtityAprdOnFabric
        {
            get;
            set;
        }
        public int IntialAprdFabric
        {
            get;
            set;
        }
        public string IntialAprdOnFabric
        {
            get;
            set;
        }
        public int BulkAprdFabric
        {
            get;
            set;
        }
        public string BulkAprdOnFabric
        {
            get;
            set;
        }

        /// <summary>
        ///first end 
        /// </summary>
       
       
       
       
       
      
       
       
        /// <summary>
        /// secound end
        /// </summary>
        /// 

       
       
        
      
        
       
        
        
        /// <summary>
        /// third fab end
        /// </summary>
        
        public int PrintColorRecdFabric5
        {
            get;
            set;
        }
        public int PrintColorRecdFabric6
        {
            get;
            set;

        }
       
        public int FabricQualtityAprdFabric6
        {
            get;
            set;
        }

       
       
       
        //third fab end
        //end by abhishek on 21/12/2015

        public string OrderDetailID
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string FabricName
        {
            get;
            set;
        }

        public string FabricDetails
        {
            get;
            set;
        }

        public string ClientID
        {
            get;
            set;
        }

        public string OrderID
        {
            get;
            set;
        }
        public string Fabric_ApprovalRemarks
        {
            get;
            set;
        }

       
        public string Fabric
        {
            get;
            set;
        }
        
        //--abhishek
        public string PrintQly
        {
            get;
            set;
        }
       
        public string FabQtyIntial
        {
            get;
            set;
        }
       
      
        public string Intial
        {
            get;
            set;
        }
        
        //---------------
        public string BulkIntial
        {
            get;
            set;
        }
        
        public string FabricChanged
        {
            get;
            set;
        }
        
        public string FabricDetailChanged
        {
            get;
            set;
        }
        
    }
}
