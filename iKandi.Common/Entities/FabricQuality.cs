using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class FabricQuality : BaseEntity
    {
        public string FQMasterID
        {
            get;
            set;
        }
        //Added by Abhishek on 1/7/2015
        public decimal oldWidthInchValue
        {
            get;
            set;
        }

        public decimal NewWidthInchValue
        {
            get;
            set;
        }
        public string FabricTypeReg_UnReg
        {
            get;
            set;
        }
        //END

        public int MinStockQuantity
        {
            get;
            set;
        }
        public int? MinStockQuality
        {
            get;
            set;
        }
        public double oldAirGreigePrice
        {
            get;
            set;
        }

        public double oldAirDyingPrice
        {
            get;
            set;
        }

        public double oldAirPrintingPrice
        {
            get;
            set;
        }

        public double oldSeaGreigePrice
        {
            get;
            set;
        }

        public double oldSeaDyingPrice
        {
            get;
            set;
        }
        public double oldSeaPrintingPrice
        {
            get;
            set;
        }
        public double oldGreigeIndian
        {
            get;
            set;
        }
        public double oldDyedIndian
        {
            get;
            set;
        }
        public double oldPrintedIndian
        {
            get;
            set;
        }
        public int StockUnit
        {
            get;
            set;
        }
        public int Dyeing_Greige_Sh
        {
            get;
            set;
        }
        public int Printing_Greige_Sh
        {
            get;
            set;
        }
        public int Res_Sh
        {
            get;
            set;
        }
        public int FabricQualityID
        {
            get;
            set;
        }

        public string SupplierReference
        {
            get;
            set;
        }


        public string UpdateDate
        {
            get;
            set;
        }
        public string TradeName
        {
            get;
            set;
        }

        //public int FabricDesign
        //{
        //    get;
        //    set;
        //}

        public string CountConstruction
        {
            get;
            set;
        }

        public int Origin
        {
            get;
            set;
        }

        public string Composition
        {
            get;
            set;
        }

        public double GSM
        {
            get;
            set;
        }

        public string Fabric
        {
            get;
            set;
        }

        public decimal Width
        {
            get;
            set;
        }

        public string HandFeel
        {
            get;
            set;
        }

        public decimal Shrinkage
        {
            get;
            set;
        }

        public int UsableWidth
        {
            get;
            set;
        }
        //public string Remarks
        //{
        //    get;
        //    set;
        //}

        public string UpdateBaseTestFile
        {
            get;
            set;
        }

        public DateTime TestConductedOn
        {
            get;
            set;
        }

        public double MinimumOrderQuantity
        {
            get;
            set;
        }

        public int LeadTimeForGreige
        {
            get;
            set;
        }

        public int LeadTimeForDyed
        {
            get;
            set;
        }
        public int LeadTimeForPrinted
        {
            get;
            set;
        }

        public double PriceForGreigeByAir
        {
            get;
            set;
        }
        public double PriceForGreigeBySea
        {
            get;
            set;
        }

        public double PriceForDyedByAir
        {
            get;
            set;
        }
        public double PriceForDyedBySea
        {
            get;
            set;
        }
        public double PriceForPrintedByAir
        {
            get;
            set;
        }

        public double PriceForPrintedBySea
        {
            get;
            set;
        }

        public string SupplierName
        {
            get;
            set;
        }

        public DateTime ApprovedOn
        {
            get;
            set;

        }
        //added by abhishek history



        public double PriceForGreigeBySea_old
        {
            get;
            set;
        }
        public double PriceForDyedBySea_old
        {
            get;
            set;
        }

        public double PriceForPrintedBySea_old
        {
            get;
            set;
        }
        public double PriceForDigitalBySea_old
        {
            get;
            set;
        }


        public double PriceForGreigeByAir_old
        {
            get;
            set;
        }
        public double PriceForDyedByAir_old
        {
            get;
            set;
        }

        public double PriceForPrintedByAir_old
        {
            get;
            set;
        }
        public double PriceForDigitalByAir_old
        {
            get;
            set;
        }



        public double PriceForGreigeByIndian_old
        {
            get;
            set;
        }
        public double PriceForDyedByIndian_old
        {
            get;
            set;
        }

        public double PriceForPrintedByIndian_old
        {
            get;
            set;
        }
        public double PriceForDigitalByIndian_old
        {
            get;
            set;
        }





        //end

        public List<FabricQualityBuyer> Buyers
        {
            get;
            set;
        }

        public List<FabricQualityPicture> Pictures
        {
            get;
            set;
        }

        //public string DesignFullNo
        //{
        //    get
        //    {
        //        string FabricDesignStr = FabricDesign.ToString();
        //        int FabricDesignNoLength = FabricDesignStr.Length;
        //        for (int i = 0; i < 6 - FabricDesignNoLength; i++)
        //        {
        //            FabricDesignStr = "0" + FabricDesignStr;
        //        }
        //        //FabricDesignStr = "DES" + FabricDesignStr;
        //        return FabricDesignStr;
        //    }
        //    set {}
        //}

        public int CategoryId
        {
            get;
            set;
        }

        public int SubCategoryId
        {
            get;
            set;
        }

        public string Group
        {
            get;
            set;
        }

        public string SubGroup
        {
            get;
            set;
        }

        public string Identification
        {
            get;
            set;
        }

        public decimal Wastage
        {
            get;
            set;
        }

        public double PriceGreigeIndian
        {
            get;
            set;
        }

        public double PriceDyedIndian
        {
            get;
            set;
        }

        public double PricePrintedIndian
        {
            get;
            set;
        }

        public bool IsBiplRegistered
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }

        public string SubCategoryName
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public bool IsCommentHistoryDeleted
        {
            get;
            set;
        }
        //------------------
        public string Sids
        {
            get;
            set;
        }
        public string SRefs
        {
            get;
            set;
        }

        public string SNames
        {
            get;
            set;
        }
        public int LeadTimeForProcessed
        {
            get;
            set;
        }

        public int LeadTimeForApproval
        {
            get;
            set;
        }
        public double PriceForGreigeByAirDuty
        {
            get;
            set;
        }
        public double PriceForGreigeBySeaDuty
        {
            get;
            set;
        }
        public double PriceForDyedByAirDuty
        {
            get;
            set;
        }
        public double PriceForDyedBySeaDuty
        {
            get;
            set;
        }
        public double PriceForPrintedByAirDuty
        {
            get;
            set;
        }
        public double PriceForPrintedBySeaDuty
        {
            get;
            set;
        }
        public double PriceForPaperPrintedByAir
        {
            get;
            set;
        }

        public double PriceForPaperPrintedByAirDuty
        {
            get;
            set;
        }
        public double PriceForPaperPrintedBySea
        {
            get;
            set;
        }
        public double PriceForPaperPrintedBySeaDuty
        {
            get;
            set;
        }
        public double PriceForDigitalPrintedByAir
        {
            get;
            set;
        }
        public double PriceForDigitalPrintedByAirDuty
        {
            get;
            set;
        }
        public double PriceForDigitalPrintedBySea
        {
            get;
            set;
        }
        public double PriceForDigitalPrintedBySeaDuty
        {
            get;
            set;
        }
        public double PriceDigitalPrintedIndian
        {
            get;
            set;
        }

        public double PricePaperPrintedIndian
        {
            get;
            set;
        }

        //

        public double PriceForGreigeByAirTotal
        {
            get;
            set;
        }
        public double PriceForGreigeBySeaTotal
        {
            get;
            set;
        }
        public double PriceForDyedByAirTotal
        {
            get;
            set;
        }
        public double PriceForDyedBySeaTotal
        {
            get;
            set;
        }
        public double PriceForPrintedByAirTotal
        {
            get;
            set;
        }
        public double PriceForPrintedBySeaTotal
        {
            get;
            set;
        }
        public double PriceForPaperPrintedByAirTotal
        {
            get;
            set;
        }
        public double PriceForPaperPrintedBySeaTotal
        {
            get;
            set;
        }
        public double PriceForDigitalPrintedByAirTotal
        {
            get;
            set;
        }
        public double PriceForDigitalPrintedBySeaTotal
        {
            get;
            set;
        }

        //===========Gajendra For New Quality Form======================
        public double MOQPrint { get; set; }
        public string FilePath { get; set; }
        public int SupplierId { get; set; }
        public Boolean TestFileVisibility { get; set; }


        public double GSMGreigeAir { get; set; }
        public decimal WidthGreigeAir { get; set; }
        public double ResidualShrinkageGreigeAir { get; set; }

        public double GSMDyedAir { get; set; }
        public decimal WidthDyedAir { get; set; }
        public double ResidualShrinkageDyedAir { get; set; }

        public double GSMPrintedAir { get; set; }
        public decimal WidthPrintedAir { get; set; }
        public double ResidualShrinkagePrintedAir { get; set; }

        public double PriceForDigitalByAir { get; set; }
        public double GSMDigitalAir { get; set; }
        public decimal WidthDigitalAir { get; set; }
        public double ResidualShrinkageDigitalAir { get; set; }



        public double GSMDyedSea { get; set; }
        public decimal WidthDyedSea { get; set; }
        public double ResidualShrinkageDyedSea { get; set; }

        public double GSMGreigeSea { get; set; }
        public decimal WidthGreigeSea { get; set; }
        public double ResidualShrinkageGreigeSea { get; set; }

        public double GSMPrintedSea { get; set; }
        public decimal WidthPrintedSea { get; set; }
        public double ResidualShrinkagePrintedSea { get; set; }

        public double PriceForDigitalBySea { get; set; }
        public double GSMDigitalSea { get; set; }
        public decimal WidthDigitalSea { get; set; }
        public double ResidualShrinkageDigitalSea { get; set; }



        public double GSMDyedIndian { get; set; }
        public decimal WidthDyedIndian { get; set; }
        public double ResidualShrinkageDyedIndian { get; set; }

        public double GSMGreigeIndian { get; set; }
        public decimal WidthGreigeIndian { get; set; }
        public double ResidualShrinkageGreigeIndian { get; set; }

        public double GSMPrintedIndian { get; set; }
        public decimal WidthPrintedIndian { get; set; }
        public double ResidualShrinkagePrintedIndian { get; set; }

        public double PriceForDigitalByIndian { get; set; }
        public double GSMDigitalIndian { get; set; }
        public decimal WidthDigitalIndian { get; set; }
        public double ResidualShrinkageDigitalIndian { get; set; }


        public double DyedRate
        {
            get;
            set;
        }
        public double PrintRate
        {
            get;
            set;
        }
        public double DigitalRate
        {
            get;
            set;
        }



    }
}
