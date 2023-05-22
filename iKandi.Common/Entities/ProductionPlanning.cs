using System;
using System.Collections.Generic;
using System.Text;

namespace iKandi.Common
{
    public class ProductionPlanning : InlinePPMOrderContract
    {
        public int ProductionPlanningID
        {
            get;
            set;
        }

        public double ShipmentQty 
        {
            get;
            set;
        }

        public double PartShipmentQty
        {
            get;
            set;
        }

        public bool IsShipmentPlanning
        {
            get;
            set;
        }

        public bool IsProductionPlanning
        {
            get;
            set;
        }

        public string ReasonForShortShipping
        {
            get;
            set;
        }

        public Packing Packing
        {
            get;
            set;
        }

        public DateTime PlannedEx
        {
            get;
            set;
        }

        public int BalanceQty
        {
            get;
            set;
        }

        public bool IsShortShipment
        {
            get;
            set;
        }

        public int ShipmentId
        {
            get;
            set;
        }

        public int ShipmentPlanningOrderId
        {
            get;
            set;
        }

        public string ShipmentNo
        {
            get;
            set;
        }
        public string CCGSM
        {
            get;
            set;
        }

        public bool IsPartShipment
        {
            get;
            set;
        }
       
    }
    //added by abhishek on 16/6/2016---------//
    public class productionCalender
    {
        public int CalenderID
        {
            get;
            set;
        }
        public string Sunday
        {
            get;
            set;

        }
        public string Monday
        {
            get;
            set;

        }
        public string Tuesday
        {
            get;
            set;

        }
        public string Wednesday
        {
            get;
            set;

        }
        public string Thursday
        {
            get;
            set;

        }
        public string Friday
        {
            get;
            set;

        }
        public string Seterday
        {
            get;
            set;

        }
        public string MonthNo
        {
            get;
            set;

        }
        public string Year
        {
            get;
            set;

        }
        public bool IsEvent
        {
            get;
            set;

        }
        public string EventDiscription
        {
            get;
            set;

        }
        public string WorkingHousr
        {
            get;
            set;
        }

    }
    public class ProductionMatrixCls
    {
        public int TotalWorkingHrs
        {
            get;
            set;
        }
        public int OrderQty
        {
            get;
            set;
        }
        public int TotalStitched
        {
            get;
            set;
        }
        public double SAM
        {
            get;
            set;
        }
        public int OB
        {
            get;
            set;
        }
        public string OrderAvailMins
        {
            get;
            set;
        }       
        public int Line
        {
            get;
            set;
        }
        public int Fabric1InHouse
        {
            get;
            set;
        }
        public int Fabric2InHouse
        {
            get;
            set;
        }
        public int Fabric3InHouse
        {
            get;
            set;
        }
        public int Fabric4InHouse
        {
            get;
            set;
        }
        public double Fabric1Avg
        {
            get;
            set;
        }
        public double Fabric2Avg
        {
            get;
            set;
        }
        public double Fabric3Avg
        {
            get;
            set;
        }
        public double Fabric4Avg
        {
            get;
            set;
        }

        public string Fabric1Name
        {
            get;
            set;
        }
        public string Fabric2Name
        {
            get;
            set;
        }
        public string Fabric3Name
        {
            get;
            set;
        }
        public string Fabric4Name
        {
            get;
            set;
        }

        public List<ProductionMaxtrixGrid>ProductionGrid
        {
            get;
            set;
        }

        public class ProductionMaxtrixGrid
        {

            public string LinePlanningDate
            {
                get;
                set;
            }
            public int DayWorkingHrs
            {
                get;
                set;
            }
            public int ProdDay
            {
                get;
                set;
            }
            public int Stitching
            {
                get;
                set;
            }
            public string AvailMins
            {
                get;
                set;
            }
            public int TargetEff
            {
                get;
                set;
            }
            public int ActualEff
            {
                get;
                set;
            }
            public int DayStitch
            {
                get;
                set;
            }
            public int TotalDayStitch
            {
                get;
                set;
            }           
            public int Fabric1Stch
            {
                get;
                set;
            }
            public int Fabric2Stch
            {
                get;
                set;
            }
            public int Fabric3Stch
            {
                get;
                set;
            }
            public int Fabric4Stch
            {
                get;
                set;
            }
        }

        public List<ProductionAccessory> ProductionAccessorylst
        {
            get;
            set;
        }

        public class ProductionAccessory
        {
            public string AccessoryName
            {
                get;
                set;
            }
            public int AccessoryInHouse
            {
                get;
                set;
            }
            public double Number
            {
                get;
                set;
            }
        }

              

        //

    }

}
 