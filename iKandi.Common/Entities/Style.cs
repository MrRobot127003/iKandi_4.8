using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class Style : BaseEntity
    {

        //public string SeasonName
        //{
        //    get;
        //    set;
        //}

        public string BuyingHouseName
        {
            get;
            set;
        }
        public string Season
        {
            get;
            set;
        }


        public int StyleID
        {
            get;
            set;
        }

        public string StyleNumber
        {
            get;
            set;
        }
        public string StyleNumberDesc
        {
            get;
            set;
        }

        public string ProcessingInstruction
        {
            get;
            set;
        }

        public int ClientID
        {
            get;
            set;
        }

        public int BuyingHouseID
        {
            get;
            set;
        }

        public int IsIkandiClient
        {
            get;
            set;
        }

        public string Buyer
        {
            get;
            set;
        }

        // Added by Yadvendra on 06/01/2020
        public bool IsMarketingVisible
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        //Changed by surendra2 on 24-10-2018.
        public int ParentDepartmentID
        {
            get;
            set;
        }
        public string ParentDepartmentName
        {
            get;
            set;
        }
        public string SketchURL
        {
            get;
            set;
        }

        public string DocURL
        {
            get;
            set;
        }
        public string TackpackFile
        {
            get;
            set;
        }
        public string TackpackFile1
        {
            get;
            set;
        }
        public string TackpackFile2
        {
            get;
            set;
        }
        public string SampleImageURL1
        {
            get;
            set;
        }
        public string Sample_Sent_Action
        {
            get;
            set;
        }

        public string SampleImageURL2
        {
            get;
            set;
        }

        public string SampleImageURL3
        {
            get;
            set;
        }

        public string SampleImageURL4
        {
            get;
            set;
        }

        public string SampleImageURL5
        {
            get;
            set;
        }

        public string SampleImageURL6
        {
            get;
            set;
        }

        public int DesignerID
        {
            get;
            set;
        }

        public DateTime ETA
        {
            get;
            set;
        }

        public decimal TargetPrice
        {
            get;
            set;
        }

        public string TargetPriceCurrency
        {
            get;
            set;
        }

        public int AccountManagerID
        {
            get;
            set;
        }

        public string AccountManagerName
        {
            get;
            set;
        }
        public int SamplingMerchandisingManagerID
        {
            get;
            set;
        }
        public string SamplingMerchandisingManagerName
        {
            get;
            set;
        }
        public string BuyerStyleNumber
        {
            get;
            set;
        }
        public bool IsSelected
        {
            get;
            set;
        }


        public DateTime IssuedOn
        {
            get;
            set;
        }

        public string ClientName
        {
            get;
            set;
        }
        public DateTime CourierReceivedOn
        {
            get;
            set;
        }

        public DateTime CourierSentOn
        {
            get;
            set;
        }

        public string ClientDepartment
        {
            get;
            set;
        }
        public string DesignerName
        {
            get;
            set;
        }
        //Gajendra Design
        public string DivisionID
        {
            get;
            set;
        }
        public int IsDefaultStyle
        {
            get;
            set;
        }
        public int fitstype
        {
            get;
            set;
        }

        public List<StyleFabric> Fabrics
        {
            get;
            set;
        }
        // worked by prabhaker 17-apr-17
        public int IcheckAutoAllocationDone
        {
            get;
            set;
        }
        // worked by prabhaker 17-apr-17
        public List<StyleCurrentUpdate> CurrentUpdate
        {
            get;
            set;
        }

        public List<StyleBuyerDetail> BuyerDetail { get; set; }

        public StyleReferenceBlock StyleReferenceBlocks
        {
            get;
            set;
        }

        public string FactoryName
        {
            get;
            set;
        }
        public iKandi.Common.Client client
        {
            get;
            set;
        }

        public iKandi.Common.ClientDepartment cdept
        {
            get;
            set;
        }

        public iKandi.Common.User AccountManager
        {
            get;
            set;
        }

        public DateTime InLineCutDate
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public Int32 StatusModeID
        {
            get;
            set;
        }

        public string StatusColor
        {
            get;
            set;
        }

        public DateTime SampleTrackingDate
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string UploadSpecsURL
        {
            get;
            set;
        }

        public DateTime DueDate
        {
            get;
            set;
        }

        public string StyleCode
        {
            get;
            set;
        }
        public string sCodeVersion
        {
            get;
            set;
        }

        public int SeasonID
        {
            get;
            set;
        }

        public string SeasonName
        {
            get;
            set;
        }

        public string Story
        {
            get;
            set;
        }

        public DateTime StyleMeeting
        {
            get;
            set;
        }
        // edit by prabhaker on 26-07-2017
        public DateTime HandOverEta
        {
            get;
            set;
        }
        public DateTime HandOverAct
        {
            get;
            set;
        }
        public DateTime PatternReadyEta
        {
            get;
            set;
        }
        public DateTime PatternReadyAct
        {
            get;
            set;
        }
        public DateTime SampleSentEta
        {
            get;
            set;
        }
        public DateTime SampleSentAct
        {
            get;
            set;
        }
        public DateTime CostingBiplEta
        {
            get;
            set;
        }
        public DateTime CostingBiplAct
        {
            get;
            set;
        }
        public DateTime PriceQuotedBiplEta
        {
            get;
            set;
        }
        public DateTime PriceQuotedBiplAct
        {
            get;
            set;
        }

        public DateTime FitsType
        {
            get;
            set;
        }

        public string CadMasterName
        {
            get;
            set;
        }
        //-------------end
        public List<StyleReferenceBlock> ReferenceBlocks
        {

            get;
            set;
        }

    }

    public class StyleFabric
    {
        public int StyleID
        {
            get;
            set;
        }

        public string CCGSM
        {
            get;
            set;
        }
        public string GSM
        {
            get;
            set;
        }
        public string cost
        {
            get;
            set;
        }
        public double CostWidth
        {
            get;
            set;
        }
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
        public double DigitalPrintRate
        {
            get;
            set;
        }
        public string CountConstruct
        {
            get;
            set;
        }
        public int FabricQualityId
        {
            get;
            set;
        }
        public string FabricName
        {
            get;
            set;
        }
        public string Acc
        {
            get;
            set;
        }

        public string FabricDesc
        {
            get;
            set;
        }
        public string FabTypeDetails
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }

        public int? PrintID
        {
            get;
            set;
        }

        public string SpecialFabricDetails
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public string PrintNumber
        {
            get;
            set;
        }

        public FabricType FabricType
        {
            get;
            set;
        }

        public int IsDeleted
        {
            get;
            set;
        }

        public int FabType
        {
            get;
            set;
        }
        public string IsPrintMultiple
        {
            get;
            set;
        }
    }

    public class StyleReferenceBlock
    {
        public string Name
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;
            set;
        }

        public int StyleID
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

    }

    public class StyleCurrentUpdate
    {
        public int Id
        {
            get;
            set;
        }

        public int StyleId
        {
            get;
            set;
        }

        public StyleCurrentUpdates Type
        {
            get;
            set;
        }

        public Boolean IsChecked
        {
            get;
            set;
        }

        public DateTime Date
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

    public class StyleBuyerDetail
    {
        public int Id { get; set; }

        public int StyleId { get; set; }

        public string FabricName { get; set; }

        public string Fabric_Name { get; set; }

        public string Remarks { get; set; }

        public int PrintID { get; set; }

        public string SpecialFabricDetails { get; set; }

        public int FabricType { get; set; }

        public DateTime RCVDBUYER { get; set; }

        public DateTime ISSUEDON { get; set; }

        public DateTime ETA { get; set; }

        public DateTime Actual { get; set; }

        public int STATUS { get; set; }
    }

    public class LinePlanningStyle
    {
        public string StyleCode
        {
            get;
            set;
        }
    }



    public class Styles : Collection<Style>
    {
    }
    public class Styles1 : Collection<Style>
    {
    }

    // added code by bharat on 9-1-20 for email
    [Serializable]
    public class User_EmailSend
    {
        public string StyleNoForEmail
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }

        public string UserEmailId
        {
            get;
            set;
        }
        public string UserPhoneNo
        {
            get;
            set;
        }
        public string UserMessage
        {
            get;
            set;
        }
    }

    [Serializable]
    public class Client_Department
    {
        public string GarmentDepartmentName
        {
            get;
            set;
        }

        public int GarmentDepartmentId
        {
            get;
            set;
        }
        public string FabricDepartmentName
        {
            get;
            set;
        }

        public int FabricDepartmentId
        {
            get;
            set;
        }
        public string DesignsImg
        {
            get;
            set;
        }
        public string MarketingPrice
        {
            get;
            set;
        }
        public string DesigFabricName
        {
            get;
            set;
        }
        public string FabShortDescription
        {
            get;
            set;
        }
        public string FabricLongDescription
        {
            get;
            set;
        }
        public string GarmentStyleNo
        {
            get;
            set;
        }
        public string FabricSearch
        {
            get;
            set;
        }
        public int FabricStyleId
        {
            get;
            set;
        }
        public string DepartmentShortDes
        {
            get;
            set;
        }
        public string DepartmentlongDes
        {
            get;
            set;
        }
        public string ProDuctImg1
        {
            get;
            set;
        }
        public string ProDuctImg2
        {
            get;
            set;
        }
        public string ProDuctImg3
        {
            get;
            set;
        }
        public string ProDuctImg4
        {
            get;
            set;
        }
        public string ProTitle
        {
            get;
            set;
        }
        public string MarkingCount
        {
            get;
            set;
        }
        public int ProLikeCount
        {
            get;
            set;
        }
        public string MarkingTag
        {
            get;
            set;
        }
        public string MarkingCompositon
        {
            get;
            set;
        }
        public string MarkingCollect
        {
            get;
            set;
        }
    }
}
