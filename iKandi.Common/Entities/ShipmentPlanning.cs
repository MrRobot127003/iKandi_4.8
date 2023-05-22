using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class ShipmentPlanning : BaseEntity
    {
        public int ShipmentID
        {
            get;
            set;
        }

        public string ShipmentNumber
        {
            get;
            set;
        }

        public string ShipmentInstructionsFile
        {
            get;
            set;
        }

        public Partner Partner
        {
            get;
            set;
        }

        public DateTime ShipmentSentForwarder
        {
            get;
            set;
        }

        public int TotalPackages
        {
            get;
            set;
        }

        public string BLAWBNumber
        {
            get;
            set;
        }

        public DateTime ExpectedDispatchDate
        {
            get;
            set;
        }

        public string FlightSailingDetails
        {
            get;
            set;
        }

        public DateTime FlightDate
        {
            get;
            set;
        }

        public DateTime LandingETA
        {
            get;
            set;
        }

        public DateTime DCDate
        {
            get;
            set;
        }

        public int SendEmail
        {
            get;
            set;
        }

        public bool IsShipmentAdvise
        {
            get;
            set;
        }

        public string UploadDocument
        {
            get;
            set;
        }

        public string SpecialInstructions
        {
            get;
            set;
        }        

        public List<ShipmentPlanningOrder> ShipmentPlanningOrders
        {
            get;
            set;
        }

        public ShipmentPlanningOrder ShipmentPlanningOrder
        {
            get;
            set;
        }

        public Partner Partner2
        {
            get;
            set;
        }

        public Partner IndiaPartner
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

    public class ShipmentPlanningOrder
    {
        public int ShipmentPlanningOrderID
        {
            get;
            set;
        }
        public ShipmentPlanning ShipmentPlanning
        {
            get;
            set;
        }

        public Packing PackingList
        {
            get;
            set;
        }

        public string UploadCustomList
        {
            get;
            set;
        }

        public string UploadBuyerList
        {
            get;
            set;
        }

        public string UploadDocument
        {
            get;
            set;
        }

        public bool IsPartShipment
        {
            get;
            set;
        }

        public string PartShipmentRemarks
        {
            get;
            set;
        }

        public bool IsDelete
        {
            get;
            set;
        }

        public string ShipmentTo
        {
            get;
            set;
        }

        public string QAStatus
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public int StatusModeId
        {
            get;
            set;
        }

        public int StatusModeSequence
        {
            get;
            set;
        }
        public int ApprovedToExSequence
        {
            get;
            set;
        }
        public int DELIVEREDSequence
        {
            get;
            set;
        }
        
        public ProductionUnit Unit
        {
            get;
            set;
        }

        public int ModeId
        {
            get;
            set;
        }

        public string ModeName
        {
            get;
            set;
        }

        public int ClientId
        {
            get;
            set;
        }

        public string Buyer
        {
            get;
            set;
        }

        public DateTime PlannedEx
        {
            get;
            set;
        }

        public int ProductionPlanningId
        {
            get;
            set;
        }

        public int OrderDetailID
        {
            get;
            set;
        }

        public bool IsDeleteShipment
        {
            get;
            set;
        }    

        public bool IsShipmentPlanning
        {
            get;
            set;
        }
    }
}
