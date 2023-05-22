using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class DeliveryBooking : ProductionPlanning 
    {
        public int BookingID
        {
            get;
            set;
        }

        public bool IsBooking
        {
            get;
            set;
        }
        public string CCGSM
        {
            get;
            set;
        }
        public bool IsEmailSent
        {
            get;
            set;
        }

        public DateTime NextStatusETA
        {
            get;
            set;
        }

        public DateTime BookingRequestedOn
        {
            get;
            set;
        }

        public string BookingReferenceNo
        {
            get;
            set;
        }

        public string DeliveryNoteFile
        {
            get;
            set;
        }

        public bool IsDelivered
        {
            get;
            set;
        }

        public bool IsPackinglistCompleteBooking
        {
            get;
            set;
        }

        public bool IsPackinglistCompletePartner
        {
            get;
            set;
        }

        public DateTime ExpectedDC
        {
            get;
            set;
        }


        public DateTime CargoReceiptDate
        {
            get;
            set;
        }

        public DateTime SentToProcessingHouseOn
        {
            get;
            set;
        }

        public DateTime ProcessingCompleteOn
        {
            get;
            set;
        }

        public ShipmentPlanningOrder ShipmentPlanningOrder
        {
            get;
            set;
        }

        public string BookingDocuments
        {
            get;
            set;
        }

        public string ProcessingInstructions
        {
            get;
            set;
        }

        public DateTime DeliveredDate
        {
            get;
            set;
        }

        public DateTime DeliveryNoteReceivedOn
        {
            get;
            set;
        }

        public string SpecialInstructions
        {
            get;
            set;
        }

    }
}
