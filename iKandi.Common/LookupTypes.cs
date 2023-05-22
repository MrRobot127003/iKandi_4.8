using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    #region Role Enum

    public enum Role
    {
        Admin = 1,
        Client = 2,
        Partner = 3,
        iKandi = 4,
        BIPL = 5,
        Supplier = 6
    }

    #endregion

    #region Group Enum

    public enum Group
    {
        iKandi_Design = 1,
        ikandi_Sales = 2,
        iKandi_Technical = 3,
        iKandi_FinanceLogistics = 4,
        iKandi_TopManagement = 12,
        BIPL_Sales = 5,
        BIPL_Merchandising = 6,
        BIPL_Fabrics = 7,
        BIPL_Accessory = 8,
        BIPL_QA = 9,
        BIPL_Production = 10,
        BIPL_Logistics = 11,
        BIPL_TopManagement = 13,
        Technical_BIPL = 15
    }

    #endregion

    #region Company Enum

    public enum Company
    {//commented and updated by abhishek on 20/1/2015
        Boutique = 2,
        iKandi = 1


        //xny = 2
    }

    #endregion

    #region Designation Enum

    public enum Designation
    {
        iKandi_TopManagement_Manager = 1,
        iKandi_Design_Manager = 5,
        iKandi_Sales_Manager = 102,
        iKandi_Technical_Manager = 7,
        iKandi_FinanceLogistics_Manager = 8,
        iKandi_Design_Designers = 6,
        iKandi_Sales_SalesManager = 4,
        iKandi_Technical_Technologist = 10,
        iKandi_FinanceLogistics_Accountant = 11,
        iKandi_Design_Assistant = 12,

        BIPL_Admin = 83,
        BIPL_TopManagement_Manager = 2,

        BIPL_Sales_Manager = 13,
        BIPL_Sales_Advisor = 20,
        BIPL_Sales_Assistant = 30,

        BIPL_Merchandising_Manager = 14,
        BIPL_Merchandising_FitMerchant = 31,
        BIPL_Merchandising_SamplingMerchant = 32,
        BIPL_Merchandising_AccountManager = 21,

        BIPL_Fabrics_Manager = 15,
        BIPL_Fabrics_AssistantEntry = 22,
        BIPL_Fabrics_ManagerStore = 23,
        BIPL_Fabrics_ManagerProcessing = 24,
        BIPL_Fabrics_Assistant = 33,
        BIPL_Fabrics_Store_Assistent = 137,
        BIPL_Fabrics_Manager_Fabric_Store = 157,
        BIPL_Fabrics_Manager_PPC = 158,
        BIPL_Fabrics_PPC_Fabric_Executive = 149,


        BIPL_Accessory_Manager = 16,
        BIPL_Accessory_Accountant = 25,

        BIPL_QA_Manager = 17,
        BIPL_QA_QA = 26,

        BIPL_Production_Manager = 18,
        BIPL_Production_ProductionManager = 27,
        BIPL_Production_Assistant = 34,
        BIPL_Production_FactoryManager = 9,
        BIPL_Production_AssistantFactory = 35,
        BIPL_Production_PPC_Exec = 46,

        BIPL_Logistics_Manager = 19,
        BIPL_Logistics_ShippingManager = 28,
        BIPL_Logistics_DeliveryManager = 29,

        Partner = 36,
        BIPL_Logistict_Accountant = 37,
        BIPL_QA_FACTORY_HEAD = 38,
        BIPL_FITs_Manager = 104,
        BIPL_LAB_Supervisor = 40,
        BIPL_LAB_Assistant = 41,
        BIPL_Client_Head = 42,
        BIPL_Production_Merchandiser = 43,
        BIPL_Factory_IE = 53,
        BIPL_HR_Manager = 54,
        BIPL_HR_Assistant = 55,
        BIPL_Sourcing_Director = 101,
        BIPL_CAD_Manager = 99,
        BIPL_GM_IE = 44,
        BIPL_Supplier = 143,
        BIPL_FabricQA = 105,
        BIPL_Store_Accountant = 22,

    }

    #endregion

    #region Currency Enum

    public enum Currency
    {
        USD = 1,
        GBP = 2,
        INR = 3,
        EURO = 4,
        SEK = 5,
        AUD = 6,
        CHF = 8,
        AED = 9

    }

    #endregion

    #region PrintStatus Enum

    public enum PrintStatus
    {
        Sold = 1,
        Unsold
    }

    #endregion

    #region Fabric Enum

    public enum Fabric
    {
        VIS_GGT = 1,
        VIS_GGT_9Kg,
        VIS_CHIFFON,
        VIS_SATIN,
        VIS_VELVETTE,
        VIS_JAQUARD,
    }

    public enum FabricType
    {
        Print = 3,
        Dyed = 2,
        DigitalPrint = 4
    }

    public enum FabricMeasurementUnit
    {
        Mtr = 2,
        Kg = 1
    }
    //abhishek 29/7/2019
    public enum FabricUnit
    {

        Mtr = 1,
        Gross = 2,
        kg = 3,
        yard = 4,
        pcs = 5,
        set = 6,
        box = 7

    }
    #endregion

    #region Origin Enum

    public enum Origin
    {
        India = 1,
        Imported,
        China
    }

    #endregion

    #region Print Type

    public enum PrintType
    {
        PIGMENT = 1,
        PRUSSIAN,
        DISCHARGE,
        ACID_OVER_PRINT,
        OVERDYING
    }

    #endregion

    #region Print Technology

    public enum PrintTechnology
    {
        FLATBED = 1,
        ROTARY,
        TABLE
    }

    #endregion

    #region Auto Complete

    public enum AutoComplete
    {
        CourierBuyer,
        CourierBuyerDepartment,
        CourierCompany,
        CourierContact,
        CourierItem,
        CourierPurpose,
        CourierStyleNumber,
        CourierFabric,
        FabricMill,
        PrintNumber,
        PrintNumbers,
        Style,
        StyleWithCosting,
        StyleWithoutCosting,
        StyleFabric,
        StyleCode,
        SamplingFactory,
        FabricType,
        Fabric,
        AccessoryQualitySupplierName,
        AccessoryQualityCategory,
        FabricQualitySupplierReference,
        FabricQualityTradeName,
        AccessoryName,
        UnRegAccessoryName,
        PrintCompany,
        PrintCompanyReference,
        FabricQuality,
        INDBlockBrand,
        INDBlockReference,
        FabricSamplingFabric,
        INDBlock,
        Description,
        ReferenceBlock,
        Users,
        FabricQualitySupplierName,
        RegisteredTradeName,
        RegisteredAccessoryTradeName,
        ContractNumber,
        FitsFiveDigitStyleCode,
        FitsStyleCodeVersion,
        GroupName,
        SupplierName,
        SerialNumber,
        NatureOfFaults,
        ManageCategory,
        StyleAccsessory,
        StyleNumberCluster,
        StyleForPattern,
        suggestGroupCode_fabric,
        suggestGroupCode_Accessoires,
        SerialNumberOnly,
        GETALLBILLNO,
        Auditor,
        MarketingTags,
        //RajeevS
        AccQuality,
        AccColorPrint,
        AccPONumber,
        AccSupplier,
    }

    #endregion

    #region Query Type

    public enum QueryType
    {
        Insert,
        Update,
        Other
    }

    #endregion
    #region status type

    public enum POstatus
    {
        Open = 0,
        Cancel = 1,
        Closed = 2
    }

    #endregion

    #region Email Template Type

    public enum EmailTemplateType
    {
        USERREGISTRATION = 1,
        FORTOPASSWORD = 2,
        CLIENTREGISTRATION = 3,
        PARTNERREGISTRATION = 4,
        PREALERTSHIPMENT = 5,
        POSTALERTSHIPMENT = 6,
        BOOKINGEMAILTOPARTNER = 7,
        DESIGNCREATION = 8,
        COURIERDISPATCHLIST = 9,
        PENDINGBIPLAGREEMENT = 10,
        NEWORDER = 11,
        SUBORDERSTATUSMODELIVE = 12,
        STCUNALLOCATED = 13,
        ALLOCATED = 14,
        PRODUCTIONREPORT = 15,
        STATUSMEETINGREPORT = 16,
        ORDERFORMCHANGES = 17,
        STATUSMEETINGRESOLUTION = 18,
        ORDERPROPOSAL = 19,
        ALLOCATIONSUMMARY = 20,
        MONDAYCOMPANYREPORTS = 21,
        MONDAYCOMPANYFILECOMPLETED = 22,
        PPMEETINGSPENDING = 23,
        QAPENDING = 24,
        STCUNALLOCATEDSTYLES = 25,
        NEWORDERS = 26,
        EXFACTORY = 27,
        TOPSPENDING = 28,
        STYLEDELETED = 29,
        STYLESCOSTEDTODAY = 30,
        INLINECUTTODAY = 31,
        PACKINGTODAY = 32,
        ORDERSLIVETODAY = 33,
        EXFACTORYCHANGEDTODAY = 34,
        EXFACTORIESPLANNEDTODAY = 35,
        APPROVEDTOSHIPTODAY = 36,
        PARTEXFACTORYTODAY = 37,
        CANCELLEDORDER = 38,
        ONHOLD = 39,
        QAFAILED = 40,
        BIPLINVOICERAISED = 41,
        COMMENTSUPLOADED = 42,
        ORDERDELEVERED = 43,
        EDITACCESSORYORDER = 44,
        EDITFABRICORDER = 45,
        LIVEPENDING = 46,
        COSTCONFIRMED = 47,
        COSTDECLINED = 48,
        CANCELLEDORDERINVOICE = 49,
        QAAPPROVED = 50,
        SHIPMENTREPORT = 51,
        INLINECUTPENDING = 52,
        PPMEETINGFORMFORSTYLECUTTODAY = 53,
        COMMENTSPENDING = 54,
        PRICEVARIATION = 55,
        STYLEUPDATESANDPENDINGTASKS = 56,
        PENDINGBUYINGSAMPLES = 57,
        PRODUCTIONANDQAUPDATE = 58,
        SamplesDelayedOrToBeDispatchedThisWeek = 59,
        BULKORGARMENTTESTSPENDING = 60,
        FITPENDINGEMAIL = 61,
        SAMPLEPENDINGEMAIL = 62,
        ORDERCHANGEREQUESTIKANDI = 63,
        ORDERCHANGEREQUESTBIPL = 64,
        RESOLUTIONPENDINGSTATUSFILE = 65,
        COSTINGRATECONTRACTCHANGE = 66,
        CANCELLEDORDERWITHOUTLIABILITY = 67,
        SHIPMENTOFFERDATE = 68,
        ORDERDELEVEREDBQT = 69,
        ORDERDELEVEREDIKandi = 70,
        COMMENTSUPLOADEDBTQ = 72,
        BirthdayMail = 71,
        COMMENTSPENDINGbtq = 74,
        SAMPLEPENDINGEMAILbtq = 73,
        CONTACTUSENQUIRYMAIL = 75

    }

    #endregion

    #region Fabric Approval Status Enum

    public enum FabricApprovalStatus
    {
        SentForApproval = 1,
        Approved = 2,
        Rejected = 3
    }

    #endregion

    #region Fabric Approval Stage Enum

    public enum FabricApprovalStage
    {
        LabDip = 1,
        Bulk = 2
    }

    #endregion

    #region Workflow

    public enum StatusMode
    {
        SAMPLEPENDING = 1,
        SAMPLESENT = 2,
        SAMPLERECEIVED = 3,
        COSTEDBIPL = 4,
        PENDINGBIPLAGREEMENT = 5,
        COSTEDIKANDI = 6,
        NEWORDER = 7,
        ORDERCONFIRMED = 8,
        LIVE = 9,
        STCUNALLOCATED = 10,
        ALLOCATED = 11,
        INLINECUT = 12,
        CUTTING = 13,
        STITCHING = 14,
        PACKING = 15,
        EXFACTORYPLANNED = 16,
        APPROVEDTOEXFACTORY = 17,
        PARTEXFACTORIED = 18,
        EXFACTORIED = 19,
        UNDERCLEARANCE = 20,
        PROCESSING = 21,
        DELIVERED = 22,
        INVOICED = 23,
        CANCELLED = 24,
        ONHOLD = 25,
        WORKINGSCREATED = 26,
        BIPLAGREEMENT = 27,
        PPMEETING = 28,
        PRICEQUOTEDBIPL = 30,//earlier 29
        PPMEETINGBH = 29
    }

    public enum TaskMode
    {
        STYLE_CREATED = 1,
        SAMPLING_ACHIEVED = 2,
        SAMPLE_SENT = 3,
        DIGITAL_UPLOADED = 4,
        COSTING_BIPL = 5,
        PRICE_QUOTED_BIPL = 6,
        COSTED_IKANDI = 7,
        BIPL_AGREEMENT_BIPL = 8,
        BIPL_AGREEMENT_Ikandi = 9,
        NEW_ORDER = 10,
        ORDER_CONFIRMED_SALES = 11,
        Create_OB = 12,
        Reminder = 13,
        Order_Agreement = 14,
        Risk = 15,
        Create_Fabric = 16,
        Create_Accessories = 17,
        Fabric_Approved = 18,
        Accessory_Approved = 19,
        WORKINGS_CREATED = 20,
        Fill_Fabric = 21,
        Fill_Accessories = 22,
        Limitation_Fabric = 23,
        Limitation_Accessories = 24,
        LIVE = 25,
        STC_UNALLOCATED_Technol = 26,
        STC_UNALLOCATED_Fit_Merchant = 27,
        ALLOCATED = 28,
        INLINE_CUT = 29,
        Final_OB = 30,
        FACTORY_PPM = 34,
        HO_PPM = 36,
        Cutting = 37,
        Line_Plan = 38,
        Stitching = 39,
        Finishing = 40,
        EXFACTORY_PLANNED = 41,
        Approved_To_EX_Fact_QA_Pending = 43,//NTR
        Final_Inspection = 43,
        Approved_To_EX_CLT_QA_Pending = 44,
        Approved_To_EX_Approval_QA = 45,
        Approved_To_EX_Shipping = 46,
        PART_EX_FACTORIED = 47,
        EXFACTORIED = 48,
        UNDER_CLEARANCE_FLAT = 49,
        UNDER_CLEARENCE_HANGING = 50,
        Consolidated = 51,
        DELIVERED = 52,
        BIPL_INVOICED = 53,
        iKandi_Invoiced = 54,
        CANCELLED = 56,
        ONHOLD = 57,
        Pattern_Sample_Received = 58,
        TOP_Planned = 59,
        TOP_Sent = 60,
        Acknowledgement_Fabric = 61,
        Acknowledgement_Costing = 62,
        Initial_Approval = 63,
        Bulk_Approval = 64,
        PO_Upload = 65,
        Production_File = 67,
        Color_Print_REF_Received = 70,
        Fabric_Quality_Approved = 71,
        Buying_Sample = 72,
        Photo_Shoots = 73,
        Test_Report = 74,
        Fabric_BIH = 75,
        Accessory_BIH = 76,
        ORDER_CONFIRMED_MERCHANT = 77,
        Cutting_Sheet = 78,
        Sealed_To_Cut = 79,
        CD_Chart = 80,
        Approved_toEx = 81,
        UNDER_CLEARENCE = 82,
        INVOICED = 83,
        Inline_Inspection = 201,
        Mid_Inspection = 202,
        Online_Inspection = 204,
        ProductionPlanning = 301,
        Cut_Avg = 401,
        HandOver = 89,
        Pattern_Ready = 90,
        Fits_SampleSent = 91,
        FitsCommentes_Upload = 92,
        InvoicePackingList = 222,
        NonAgreementTask = 9000,
        PatternReadyAfterSTC = 8882,
        SampleSentAfterSTC = 8883,
        DebitNote_Task = 8887,
        CreditNote_Task = 8891,
        Cancel_Order_With_Liability_Task = 8898,
        Cancel_Order_ACC_With_Liability_Task = 9111,
        BIPL_Global_Daily_IE_Entry = 9888,
        ACC_DebitNote_Task = 7887,
        ACC_CreditNote_Task = 7791,
        Value_Addition_Entry = 6697,
        Value_Addition_PO = 9444,
        Stitch_OutHouse_PO = 9445,
        Venor_Stitch_OutHouse_PO = 9446,
        Vendor_Value_Addition_PO = 9447,
        Order_Open = 12003,
        Open_Costing = 9876
    }

    public enum StatusModeNew
    {
        SAMPLEPENDING = 1,
        SAMPLESENT = 2,
        SAMPLERECEIVED = 3,
        COSTINGBIPL = 4,
        PENDINGBIPLAGREEMENT = 5,
        COSTEDIKANDI = 6,
        NEWORDER = 7,
        ORDERCONFIRMED = 8,
        LIVE = 9,
        STCUNALLOCATED = 10,
        ALLOCATED = 11,
        INLINECUT = 12,
        CUTTING = 13,
        STITCHING = 14,
        PACKING = 15,
        EXFACTORYPLANNED = 16,
        APPROVEDTOEXFACTORY = 17,
        PARTEXFACTORIED = 18,
        EXFACTORIED = 19,
        UNDERCLEARANCE = 20,
        PROCESSING = 21,
        DELIVERED = 22,
        INVOICED = 23,
        CANCELLED = 24,
        ONHOLD = 25,
        WORKINGSCREATED = 26,
        BIPLAGREEMENT = 27,
        PPMEETING = 28,
        PPMEETINGBH = 29,
        PRICEQUOTEDBIPL = 30
    }

    public enum TaskStatusMode
    {
        STYLECREATED = 1,
        SAMPLINGACHIEVED = 2,
        SAMPLESENT = 3,
        DIGITALUPLOADED = 4,
        COSTINGBIPL = 5,
        PRICEQUOTEDBIPL = 6,
        BIPLAGREEMENTBIPL = 7,
        BIPLAGREEMENTiKandi = 8,
        COSTEDIKANDI = 9,
        NEWORDER = 10,
        ORDERCONFIRMEDSALES = 11,
        ORDERCONFIRMEDMERCHANDISING = 12,
        CREATEFABRICWORKING = 13,
        CREATEACCESSORIESWORKING = 14,
        FILLFABRICWORKING = 15,
        FILLACCESSORIESWORKING = 16,
        LIMITATIONFABRIC = 17,
        LIMITATIONACCESSORY = 18,
        LIMITATIONMERCHANDISING = 19,
        LIMITATIONPRODUCTION = 20,
        STCUNALLOCATEDFITMERCHANT = 21,
        STCUNALLOCATEDTECHNO = 22,
        ALLOCATED = 23,
        INLINECUT = 24,
        CUTTING = 25,
        STITCHPKG = 26,
        EXFACTORYPLANNED = 27,
        APPROVEDTOEX = 28,
        PENDINGAPPROVETOEX = 29,//earlier 29
        PARTEXFACTORIED = 30,
        EXFACTORIED = 31,
        BIPLORDERAGREEMENT = 32,
        UNDERCLEARANCE = 33,
        PROCESSING = 34,
        DELIVERED = 35,
        BIPLINVOICED = 36,
        iKANDIINVOICED = 37,
        CANCELLED = 38,
        ONHOLD = 39,
        PRICEQUOTEDIKANDI = 40
    }

    #region Delivery Mode Enum

    public enum StatusModeBySequence
    {
        SAMPLEPENDING = 1,
        SAMPLESENT = 2,
        SAMPLERECEIVED = 3,
        COSTEDBIPL = 4,
        PENDINGBIPLAGREEMENT = 5,
        COSTEDIKANDI = 6,
        NEWORDER = 7,
        ORDERCONFIRMED = 8,
        LIVE = 10,
        STCUNALLOCATED = 11,
        ALLOCATED = 12,
        INLINECUT = 13,
        CUTTING = 14,
        STITCHANDPKG = 15,
        PACKING = 16,
        EXFACTORYPLANNED = 17,
        APPROVEDTOEXFACTORY = 18,
        PARTEXFACTORIED = 19,
        EXFACTORIED = 20,
        UNDERCLEARANCE = 21,
        PROCESSING = 22,
        DELIVERED = 23,
        INVOICED = 24,
        CANCELLED = 25,
        ONHOLD = 26,
        WORKINGSCREATED = 9
    }
    #endregion



    public enum Phase
    {
        DESIGNANDCOST = 1,
        INITIALISING = 2,
        ORDERPROCESSING = 3,
        PRODUCTIONANDQA = 4,
        SHIPPINGANDDELIVERY = 5,
        SETUP = 6
    }

    public enum SubPhase
    {
        DESIGN = 1,
        COSTING,
        ORDERCONFIRMATION,
        DEPARTMENTALORDERPLACEMENT,
        FITS,
        FABRIC,
        ACCESSORIES,
        ALLOCATION,
        INLINE,
        CUTTING,
        STITCHING,
        PACKING,
        QA,
        SHIPPING,
        DELIVERY,
        INVOICING,
        MANAGEORDERS,
        CLOSURE,
        SETUP,
        PLANNING
    }

    #endregion

    #region Page Type

    public enum PageType
    {
        FORM = 1,
        FILE = 2,
        REPORT = 3,
        Admins = 4
    }

    #endregion

    #region ZipRate Type

    public enum ZipRateType
    {
        CLOSED = 1,
        OPEN = 2
    }

    #endregion

    #region Liability Payment Status

    public enum PaymentStatus
    {
        Paid = 1,
        Unpaid = 2,
        Partially_Paid = 3,
        Liability_WaivedOff = 4
        //No_Liability=5
    }

    #endregion

    #region Remarks
    public enum Remarks
    {
        Accessories,
        Cutting,
        FabricBulk,
        ExFactory,
        Tops
    }

    #endregion

    #region Delivery Mode Enum

    public enum PartnerDeliveryMode
    {
        LANDED = 1,
        FOB = 2
    }
    #endregion

    #region Partner Type Enum

    public enum PartnerType
    {
        UNKNOWN = -1,
        INDIA_AIR = 1,
        INDIA_SEA = 2,
        EXTERNAL_AIR = 3,
        EXTERNAL_SEA = 4,
        HANGING = 5,
    }

    #endregion

    #region Partner Email Function

    public enum PartnerEmailFunction
    {
        UNKNOWN = -1,
        DELIVERY = 1,
        PROCESSING_DELIVERY = 2,
        QA = 3
    }


    #endregion

    #region ApplicationModule

    public enum AppModule
    {
        DESIGN_FORM = 1,
        SAMPLING_STATUS_FILE = 2,
        DESIGN_LIST = 6,
        STYLE_IMAGE_UPLOAD = 7,
        COSTING_FORM = 9,
        ORDER_FORM = 10,
        FABRIC_WORKING_FORM = 13,
        ACCESSORY_WORKING_FORM = 14,
        ORDER_LIMITATION_FORM = 12,
        SEALING_FORM = 15,
        ALLOCATION_FORM = 24,
        MANAGE_ORDER_FILE = 11,
        PRODUCTION_PLANNING_FILE = 36,
        QUALITY_CONTROL = 30,
        SHIPMENT_PLANNING_FILE = 37,
        PROCESSING_FILE = 85,
        UK_DELIVERY_FILE = 39,
        IKANDI_INVOICES = 88,
        IKANDI_SALES_VIEW = 31,
        DISPATCH_ENTRY_FILE = 8,
        LIABILITY_FORM = 33,
        DC_BOOKING = 38,
        Sales_Report = 101,
        BIPL_Budget = 171
    }

    #endregion

    #region  ApplicationModulecolumn
    //public enum AppModuleColumn
    //{
    //    SAMPLING_STATUS_FILE_UNIT = 47,
    //    SAMPLING_STATUS_FILE_ASSIGNED_TO = 48,
    //    SAMPLING_STATUS_FILE_RECEIVED_ON = 49,
    //    SAMPLING_STATUS_FILE_EXPECTED_DISPATCH_DATE = 50,
    //    SAMPLING_STATUS_FILE_COUNTER_COMPLETE = 51,
    //    SAMPLING_STATUS_FILE_SAMPLING_STATUS_REMARKS = 228,
    //    FABRIC_SAMPLING_FILE_PRINT_DESIGN_NUMBER_LAB_DIPS = 52,
    //    FABRIC_SAMPLING_FILE_MILL_NAME = 53,
    //    FABRIC_SAMPLING_FILE_MILL_DESIGN_NUMBER = 54,
    //    FABRIC_SAMPLING_FILE_PRINT_TYPE = 55,
    //    FABRIC_SAMPLING_FILE_TECHNIQUE_OF_PRINT = 56,
    //    FABRIC_SAMPLING_FILE_QTY_ORDERED = 57,
    //    FABRIC_SAMPLING_FILE_QTY_RECEIVED = 58,
    //    FABRIC_SAMPLING_FILE_ORIGIN = 59,
    //    FABRIC_SAMPLING_FILE_NO_OF_COLS_SCREENS = 60,
    //    FABRIC_SAMPLING_FILE_COST_PER_SCREENS = 61,
    //    FABRIC_SAMPLING_FILE_REMARKS = 62,
    //    FABRIC_SAMPLING_FILE_DATE_OF_RECEIVING = 63,
    //    FABRIC_SAMPLING_FILE_EXPECTED_ISSUE_DATE = 64,
    //    FABRIC_SAMPLING_FILE_ACTUAL_ISSUE_DATE = 65,
    //    FABRIC_SAMPLING_FILE_EXPECTED_RECIEPT_DATE = 66,
    //    FABRIC_SAMPLING_ACTUAL_RECIEPT_DATE = 67,
    //    FABRIC_SAMPLING_FABRIC = 206,
    //    DESIGN_LIST_SAMPLING_FILE_COURIER_RECEIVED_ON = 44,
    //    DESIGN_LIST_SAMPLING_FILE_COURIER_RECEIVED = 45,
    //    DESIGN_LIST_SAMPLE_RECEIVED_COURIER_RECEIVED_ON = 46,
    //    IKANDI_INVOICES_PAYMENT_DUE_DATE = 109,
    //    IKANDI_INVOICES_PAYMENT_RECEVIED_DATE_AMOUNT = 110,
    //    PROCESSING_CARGO_RECEIPT_DATE = 105,
    //    PROCESSING_PROCESSING_COMPLETION_DATE = 106,
    //    PROCESSING_P_LIST_ENTERED = 107,
    //    PROCESSING_DELIVERY_NOTE_UPLOADED = 108,
    //    BIPL_INVOICES_RAISE_BE = 99,
    //    BIPL_INVOICES_BE_NO_DATE = 100,
    //    BIPL_INVOICES_BE_AMOUNT = 101,
    //    BIPL_INVOICES_PAYMENT_DUE_DATE = 102,
    //    BIPL_INVOICES_PAYMENT_RECEVIED_DATE = 103,
    //    BIPL_INVOICES_INVOICE_AMOUNT = 104,
    //    UK_DELIVERY_FILE_CARGO_RECEIPT_DATE = 96,
    //    UK_DELIVERY_FILE_SENT_TO_PROCESSING_HOUSE = 97,
    //    UK_DELIVERY_FILE_DELIVERY_NOTE_UPLOADED = 98,
    //    SHIPMENT_PLANNING_FILE_SHIPMENT_PLANNING_SELECTION = 72,
    //    SHIPMENT_PLANNING_FILE_UPLOAD_CUSTOMS_P_LIST = 73,
    //    SHIPMENT_PLANNING_FILE_UPLOAD_BUYER_P_LIST = 74,
    //    SHIPMENT_PLANNING_FILE_UPLOAD_DOCUMENTS_PRE = 75,
    //    SHIPMENT_PLANNING_FILE_UPLOAD_SHIPMENT_INSTRUCTIONS = 76,
    //    SHIPMENT_PLANNING_FILE_SEND_EMAIL_PRE_ALERT_INDIA = 77,
    //    SHIPMENT_PLANNING_FILE_PART_SHIPMENT = 78,
    //    SHIPMENT_PLANNING_FILE_SHIPMENT_SENT_TO_FORWARDER = 79,
    //    SHIPMENT_PLANNING_FILE_REMARKS_AUTHORIZATION_FOR_PART_SHIPMENT = 80,
    //    SHIPMENT_PLANNING_FILE_REMOVE = 81,
    //    SHIPMENT_PLANNING_FILE_SELECT_SHIPMENT_NO = 82,
    //    SHIPMENT_PLANNING_FILE_ENTER_DETAILS = 83,
    //    SHIPMENT_PLANNING_FILE_ENTER_FLIGHT_SAILING_DETAILS = 84,
    //    SHIPMENT_PLANNING_FILE_ENTER_LANDING_ETA = 85,
    //    SHIPMENT_PLANNING_FILE_DC_DATE = 86,
    //    SHIPMENT_PLANNING_FILE_SEND_EMAIL = 87,
    //    SHIPMENT_PLANNING_FILE_UPLOAD_DOCUMENTS_POST = 88,
    //    SHIPMENT_PLANNING_FILE_SPECIAL_INSTURCTIONS = 89,
    //    iKandi_Sales_View_TECHNICAL_STC_ETA = 15,
    //    iKandi_Sales_View_SALES_BIPL_PRICE = 16,
    //    iKandi_Sales_View_SALES_IKANDI_PRICE_GROSS = 17,
    //    iKandi_Sales_View_SALES_IKANDI_PRICE_DISCOUNTED = 18,
    //    iKandi_Sales_View_SALES_MARGIN = 19,
    //    iKandi_Sales_View_TAB_SALES = 116,
    //    iKandi_Sales_View_TAB_TECHNICAL = 117,
    //    iKandi_Sales_View_SALES_BUSINESS = 20,
    //    iKandi_Sales_View_EX_FACTORY = 210,
    //    iKandi_Sales_View_DC_DATE = 211,
    //    iKandi_Sales_View_TECHNICAL_EX_FACTORY = 212,
    //    iKandi_Sales_View_TECHNICAL_DC = 213,
    //    STATUS_DESIGN_CONTRACT_DETAILS_BIPL_PRICE = 26,
    //    STATUS_DESIGN_FITS_FITS_REMARKS = 27,
    //    STATUS_DESIGN_FITS_RESOLUTION = 28,
    //    STATUS_DESIGN_FITS_OWNER = 29,
    //    STATUS_DESIGN_FITS_PLANNED_DISPATCH_DATE = 30,
    //    STATUS_DESIGN_FABRIC_FABRIC_REMARKS = 31,
    //    STATUS_DESIGN_FABRIC_RESOLUTION = 32,
    //    STATUS_DESIGN_FABRIC_OWNER = 33,
    //    STATUS_MEETING_FILE_FITS_RESOLUTION = 34,
    //    STATUS_MEETING_FILE_PLANNED_DISPATCH_DATE = 35,
    //    STATUS_MEETING_FILE_FABRIC_RESOLUTION = 36,
    //    SEALERS_PENDING_SEALER_REMARKS_BIPL = 37,
    //    SEALERS_PENDING_SEALER_REMARKS_IKANDI = 38,
    //    MONDAY_COMPANY_FILE_ACCESSORIES_REMARKS = 39,
    //    MONDAY_COMPANY_FILE_CUTTING_REMARKS = 40,
    //    MONDAY_COMPANY_FILE_EXFACTORY_REMARKS = 41,
    //    MONDAY_COMPANY_FILE_FABRIC_BULK_REMARKS = 42,
    //    MONDAY_COMPANY_FILE_TOP_INFORMATION_REMARKS = 43,
    //    PRODUCTION_PLANNING_FORM_QTY_BEING_SHIPPED = 68,
    //    PRODUCTION_PLANNING_FORM_REASONS_FOR_SHORT_SHIPPING = 69,
    //    PRODUCTION_PLANNING_FORM_CHECK_TO_ENTER_SHIPMENT_PLANNING = 70,
    //    PRODUCTION_PLANNING_FORM_PLANNED_EX_BY_PRODUCTION = 71,
    //    PRODUCTION_PLANNING_FILE_REMOVE = 230,
    //    DC_BOOKING_FILE_CHECK_BOX_TO_BOOK = 90,
    //    DC_BOOKING_FILE_BOOKING_REQUESTED_ON = 91,
    //    DC_BOOKING_FILE_BOOKING_REF_NO = 92,
    //    DC_BOOKING_FILE_P_LIST_ENTERED_SPLITS_CONFIRMED_CHECK_BOX = 93,
    //    DC_BOOKING_FILE_BOOKING_REF_NO_EXPECTED_INTO_DC = 94,
    //    DC_BOOKING_FILE_ATTACH_BOOKING_DOCUMENTS = 95,
    //    DC_BOOKING_FILE_REMOVE = 231,
    //    MANAGE_ORDERS_FILE_MARCHANDISING_SANJEEV_REMARKS = 1,
    //    MANAGE_ORDERS_FILE_MARCHANDISING_MERCHANT_NOTES = 2,
    //    MANAGE_ORDERS_FILE_MARCHANDISING_PRICE = 3,
    //    MANAGE_ORDERS_FILE_MARCHANDISING_DC = 207,
    //    // edit by surendra on 14/10/2013
    //    MANAGE_ORDERS_FILE_MARCHANDISING_PCDate = 268,
    //    // end
    //    MANAGE_ORDERS_FILE_MARCHANDISING_EXFACTORY = 208,
    //    MANAGE_ORDERS_FILE_MARCHANDISING_MDA = 209,
    //    MANAGE_ORDERS_FILE_CUTTING_PCS_CUT = 4,
    //    MANAGE_ORDERS_FILE_CUTTING_CUT = 5,
    //    MANAGE_ORDERS_FILE_CUTTING_PCS_ISSUED = 6,
    //    MANAGE_ORDERS_FILE_CUTTING_BALANCE_IN_HOUSE = 7,
    //    MANAGE_ORDERS_FILE_CUTTING_PCS_TO_BE_CUT = 8,
    //    MANAGE_ORDERS_FILE_CUTTING_EXFACTORY = 214,
    //    MANAGE_ORDERS_FILE_STITCHING_PCS_SEND = 9,
    //    MANAGE_ORDERS_FILE_STITCHING_PCS_RECEIVED = 10,
    //    MANAGE_ORDERS_FILE_STITCHING_PCS_RECVD = 11,
    //    MANAGE_ORDERS_FILE_STITCHING_PCS_PACKED_TODAY = 12,
    //    MANAGE_ORDERS_FILE_STITCHING_OVERALL_PCS_PACKED = 13,
    //    MANAGE_ORDERS_FILE_STITCHING_PRODUCTION_REMARKS = 14,
    //    MANAGE_ORDERS_FILE_STITCHING_EXFACTORY = 215,
    //    MANAGE_ORDERS_FILE_TAB_MERCHANDISING = 111,
    //    MANAGE_ORDERS_FILE_TAB_FABRIC = 112,
    //    MANAGE_ORDERS_FILE_TAB_ACCESSORIES = 113,
    //    MANAGE_ORDERS_FILE_TAB_CUTTING = 114,
    //    MANAGE_ORDERS_FILE_TAB_STITCHING = 115,
    //    MANAGE_ORDERS_FILE_ACCESSORY_APPROVED_DATE = 221,
    //    MANAGE_ORDERS_FILE_FABRIC_BULK_IN_HOUSE = 218,
    //    MANAGE_ORDERS_FILE_ACCESSORY_PERCENTAGE = 220,
    //    MONDAY_COMPANY_REPORT_TOPS_REMARKS = 21,
    //    MONDAY_COMPANY_REPORT_FABRIC_BULK_REMARKS = 22,
    //    MONDAY_COMPANY_REPORT_ACCESORIES_REMARKS = 23,
    //    MONDAY_COMPANY_REPORT_CUTTING_REMARKS = 24,
    //    MONDAY_COMPANY_REPORT_EXFACTORY_REMARKS = 25,
    //    LIABILITY_FORM_MERCHANT_REMARKS = 144,
    //    INLINE_FORM_MERCHANDISING_MANAGER = 145,
    //    INLINE_FORM_ACCOUNT_MANAGER = 146,
    //    INLINE_FORM_FACTORY_MANAGER = 147,
    //    INLINE_FORM_PRODUCTION_DIRECTOR = 148,
    //    INLINE_FORM_PRODUCTION_MASTER = 149,
    //    INLINE_FORM_QA = 197,
    //    ACCESSORIES_WORKING_FORM_ACCOUNT_MANAGER = 185,
    //    ACCESSORIES_WORKING_FORM_ACCESSORY_MANAGER = 186,
    //    FABRIC_WORKING_FORM_FABRIC1_INITIAL_WIDTH = 151,
    //    FABRIC_WORKING_FORM_FABRIC1_USABLE_WIDTH = 152,
    //    FABRIC_WORKING_FORM_FABRIC2_INITIAL_WIDTH = 153,
    //    FABRIC_WORKING_FORM_FABRIC2_USABLE_WIDTH = 154,
    //    FABRIC_WORKING_FORM_FABRIC3_INITIAL_WIDTH = 155,
    //    FABRIC_WORKING_FORM_FABRIC3_USABLE_WIDTH = 156,
    //    FABRIC_WORKING_FORM_FABRIC4_INITIAL_WIDTH = 157,
    //    FABRIC_WORKING_FORM_FABRIC4_USABLE_WIDTH = 158,
    //    FABRIC_WORKING_FORM_UNIT_OF_AVERAGE = 159,
    //    FABRIC_WORKING_FORM_FABRIC1_WASTAGE = 161,
    //    FABRIC_WORKING_FORM_FABRIC1_SHRINKAGE = 162,
    //    FABRIC_WORKING_FORM_FABRIC1_AVG = 163,
    //    FABRIC_WORKING_FORM_FABRIC1_FINAL_ORDER = 164,
    //    FABRIC_WORKING_FORM_FABRIC2_WASTAGE = 165,
    //    FABRIC_WORKING_FORM_FABRIC2_SHRINKAGE = 166,
    //    FABRIC_WORKING_FORM_FABRIC2_AVG = 167,
    //    FABRIC_WORKING_FORM_FABRIC2_FINAL_ORDER = 168,
    //    FABRIC_WORKING_FORM_FABRIC3_WASTAGE = 169,
    //    FABRIC_WORKING_FORM_FABRIC3_SHRINKAGE = 170,
    //    FABRIC_WORKING_FORM_FABRIC3_AVG = 171,
    //    FABRIC_WORKING_FORM_FABRIC3_FINAL_ORDER = 172,
    //    FABRIC_WORKING_FORM_FABRIC4_WASTAGE = 173,
    //    FABRIC_WORKING_FORM_FABRIC4_SHRINKAGE = 174,
    //    FABRIC_WORKING_FORM_FABRIC4_AVG = 175,
    //    FABRIC_WORKING_FORM_FABRIC4_FINAL_ORDER = 176,
    //    FABRIC_WORKING_FORM_FABRIC1_REMARKS = 177,
    //    FABRIC_WORKING_FORM_FABRIC2_REMARKS = 178,
    //    FABRIC_WORKING_FORM_FABRIC3_REMARKS = 179,
    //    FABRIC_WORKING_FORM_FABRIC4_REMARKS = 180,
    //    FABRIC_WORKING_FORM_FABRIC_REMARKS = 181,
    //    FABRIC_WORKING_FORM_ALL_REMARKS = 182,
    //    FABRIC_WORKING_FORM_APPROVED_AVG_CHECKED_BY_ACCOUNT_MGR = 183,
    //    FABRIC_WORKING_FORM_APPROVED_FOR_FABRIC_MANAGER = 184,
    //    QUALITY_CONTROL_QA_MANAGER = 194,
    //    CUTTING_FORM_MERCHANT = 191,
    //    CUTTING_FORM_FABRIC_HEAD = 192,
    //    CUTTING_FORM_PRODUCTION_HEAD = 193,
    //    OrderForm-ORDER DATE = 120,
    //    OrderForm-STYLE NUMBER = 121,
    //    ORDER_FORM_BUYER = 122,
    //    ORDER_FORM_DESCRIPTION = 123,
    //    ORDER_FORM_BIPL_PRICE = 124,
    //    ORDER_FORM_LINE_ITEM_NUMBER = 125,
    //    ORDER_FORM_CONTRACT_NUMBER = 126,
    //    ORDER_FORM_BUYER_CONTRACT = 127,
    //    ORDER_FORM_FABRIC1 = 128,
    //    ORDER_FORM_FABRIC2 = 129,
    //    ORDER_FORM_FABRIC3 = 130,
    //    ORDER_FORM_FABRIC4 = 131,
    //    ORDER_FORM_QTY = 132,
    //    ORDER_FORM_MODE = 133,
    //    ORDER_FORM_IKANDI_PRICE = 134,
    //    ORDER_FORM_EX_FACTORY = 135,
    //    ORDER_FORM_DC_DATE = 136,
    //    ORDER_FORM_SINGLES = 137,
    //    ORDER_FORM_RATIO = 138,
    //    ORDER_FORM_RATIO_PACK = 216,
    //    ORDER_FORM_QUANTITY = 217,
    //    ORDER_FORM_IKANDI_COMMENTS = 139,
    //    ORDER_FORM_MERCHANDISING_MGR = 195,
    //    ORDER_FORM_SALES_MANAGER_BIPL = 196,
    //    ORDER_FORM_FABRIC1_DETAILS = 202,
    //    ORDER_FORM_FABRIC2_DETAILS = 203,
    //    ORDER_FORM_FABRIC3_DETAILS = 204,
    //    ORDER_FORM_FABRIC4_DETAILS = 205,
    //    ORDER_FORM_DEPARTMENT = 222,
    //    LIMITATIONS_FORM_BULK_TARGET = 118,
    //    LIMITATIONS_FORM_IKANDI_COMMENTS = 119,
    //    LIMITATIONS_FORM_APPROVED_BY_FABRIC_MGR = 187,
    //    LIMITATIONS_FORM_APPROVED_BY_ACCESSORIES_MGR = 188,
    //    LIMITATIONS_FORM_APPROVED_BY_PRODUCTION_MGR = 189,
    //    LIMITATIONS_FORM_APPROVED_BY_MERCHANDISING_MGR = 190,
    //    PACKING_LIST_TOP_SECTION = 150,
    //    ORDER_FORM_SEND_PROPOSAL = 219,
    //    STATUS_MEETING_FILE_FIT_REMARKS = 223,
    //    STATUS_MEETING_FILE_FABRIC_REMARKS = 224,
    //    STATUS_MEETING_FILE_FITS_OWNER = 225,
    //    STATUS_MEETING_FILE_FABRIC_OWNER = 226,
    //    STATUS_MEETING_FILE_BIPL_PRICE = 227,
    //    ORDER_FORM_SPLIT = 229,
    //    QUALITY_CONTROL_ONLINE_RESOLUTION = 230,
    //    QUALITY_CONTROL_RESOLUTION = 231,
    //    iKandi_Sales_iKANDIPRICE = 232,
    //    iKandi_Sales_View_TAB_SALES_REPORT = 233,
    //    iKandi_Sales_View_TAB_CLIENTS_REPORT = 234,
    //    iKandi_Sales_View_TAB_EXFACTORIES_REPORT = 235,
    //    iKandi_Sales_View_TAB_DEPARTMENTS_REPORT = 236,
    //    ORDER_FORM_LINK_EXFACTORYQUANTITYREPORT = 237,
    //    MANAGE_ORDERS_FILE_FABRIC_FABRIC_REMARKS = 238,
    //    MANAGE_ORDERS_FILE_ACCESSORIES_ACCESSORIES_REMARKS = 239,
    //    MANAGE_ORDERS_FILE_TAB_SALES_REPORT = 240,
    //    MANAGE_ORDERS_FILE_TAB_CLIENTS_REPORT = 241,
    //    MANAGE_ORDERS_FILE_TAB_EX_FACTORIES_REPORT = 242,
    //    MANAGE_ORDERS_FILE_TAB_DEPARTMENTS_REPORTS = 243,
    //    DASHBOARD_COSTING_AND_ENQUIRIES = 244,
    //    DASHBOARD_BOOKING_CALCULATOR = 245,
    //    DASHBOARD_HIT_RATES_FOR_DESIGNERS_REPORT = 246,
    //    LIABILITY_BOUTIQUE_SETTLEMENT_SECTION = 247,
    //    //LIABILITY_ACKNOWLEDGE = 248,
    //    //LIABILITY_IKANDI_OWNER = 249,
    //    //LIABILITY_ACCEPTANCE_TO_SETTLE = 250,
    //    //LIABILITY_RAISE_CUSTOMER_INVOICE = 251,
    //    LIABILITY_OVERALL_SECTION = 252,
    //    LIABILITY_DOCUMENTATION_REMARKS = 253,
    //    ORDER_FORM_TYPE_OF_PACKING = 254,
    //    PRICE_QUOTED = 255,
    //    UPDATE_PRICE_BIPL = 256,
    //    UPDATE_PRICE_IKANDI = 257,
    //    REQUEST_COST_CONFIRMATION = 258,
    //    CONFIRM_COST = 259,
    //    PRINT_TESTING_SECTION = 260,
    //    PRINT_BIPL_COSTING_FORM = 261,
    //    SAMPLING_STATUS_CURRENT_UPDATE = 262,
    //    DESIGN_LIST_CURRENT_UPDATE = 263,
    //    LIMITATIONS_FORM_BULK_IN_HOUSE_DAYS_COLUMN = 264,
    //    ORDER_FORM_REMINDERS = 266,
    //    QA_STATUS_MO = 267
    //}
    //=============ORDER_FORM=============================
    public enum AppModuleColumn
    {
        //ORDER HEADER
        ORDER_FORM_IKANDI_COMMENTS = 139,
        ORDER_FORM_BUYER = 122,
        ORDER_FORM_STYLE_NUMBER = 251,
        ORDER_FORM_PARENT_DEPARTMENT = 252,
        ORDER_FORM_DEPARTMENT = 253,
        ORDER_FORM_DESCRIPTION = 145,
        ORDER_FORM_ORDER_TYPE = 254,
        //ORDER BASIC SETION
        ORDER_FORM_LINE_NO = 255,
        ORDER_FORM_CONTRACT_NO = 256,
        ORDER_FORM_PO_UPLOAD = 257,
        ORDER_FORM_QTY = 258,
        ORDER_FORM_BIPL_PRICE = 259,
        ORDER_FORM_IKANDI_PRICE = 260,
        ORDER_FORM_MODE = 261,
        ORDER_FORM_EX_FACTORY = 262,
        ORDER_FORM_DC_DATE = 263,
        ORDER_FORM_DILIVER_INSTRUCTION = 264,
        ORDER_FORM_COUNTRY_CODE = 246,
        //ORDER FABRIC ACCESSORY SETION      
        ORDER_FORM_FABRIC_DETAILS = 240,
        ORDER_FORM_FABRIC_COLOR_PRINT = 247,
        ORDER_FORM_ACCESSORY_DETAIL = 241,
        ORDER_FORM_ACCESSORY_COLOR_PRINT = 265,
        ORDER_FORM_ACCESSORY_ISDTM = 266,
        //ORDER OTHER
        ORDER_FORM_SIZE = 267,
        ORDER_FORM_SPLIT = 28,
        ORDER_FORM_CONTRACT_DELETE = 249,
        ORDER_FORM_CONTRACT_ADD = 250,

        //COMMENT & HISTORY
        ORDER_FORM_COMMENT_ALL = 268,
        ORDER_FORM_COMMENT_HEADER = 269,
        ORDER_FORM_COMMENT_EXFACTORY = 270,
        ORDER_FORM_COMMENT_FINANCE = 271,
        ORDER_FORM_COMMENT_FABRIC = 272,
        ORDER_FORM_COMMENT_ACCESSORY = 273,
        ORDER_FORM_COMMENT_OTHER = 274,

        ORDER_FORM_HISTORY_ALL = 275,
        ORDER_FORM_HISTORY_HEADER = 276,
        ORDER_FORM_HISTORY_EXFACTORY = 277,
        ORDER_FORM_HISTORY_FINANCE = 278,
        ORDER_FORM_HISTORY_FABRIC = 279,
        ORDER_FORM_HISTORY_ACCESSORY = 280,
        ORDER_FORM_HISTORY_OTHER = 281,

        ORDER_FORM_TOP_MANAGER = 242,
        ORDER_FORM_ACCOUNT_MANAGER = 243,
        ORDER_FORM_FABRIC_MANAGER = 244,
        ORDER_FORM_ACCESSORY_MANAGER = 245,

        //BUTTON
        ORDER_FORM_SEND_PROPOSAL = 282,
        ORDER_FORM_ACCEPT_PROPOSAL = 283,
        ORDER_FORM_PRINT = 284,
        ORDER_FORM_SUBMIT_BUTTON = 174,

        //FABRIC DETAILS FORM
        FABRIC_DETAIL_ORDER_AVG = 234,
        FABRIC_DETAIL_ORDER_AVG_FILE = 237,
        FABRIC_DETAIL_CUT_AVG = 233,
        FABRIC_DETAIL_CUT_AVG_FILE = 235,
        FABRIC_DETAIL_ORDER_WIDTH = 236,
        FABRIC_DETAIL_CUT_WIDTH = 238,
        FABRIC_DETAIL_AVG_CHECKED = 232,

        //BASIC SECTION LEFT FIELD
        ORDER_FORM_TOTAL_ORDER_VALUE = 285,
        ORDER_FORM_TOTAL_ORDER_QTY = 286,
        ORDER_FORM_PRICE_AGREED_LINK = 287,
        /// </summary>done


        MANAGE_ORDERS_FILE_MARCHANDISING_MERCHANT_NOTES = 288,//Temp Need to Add in DB
        MANAGE_ORDERS_FILE_FABRIC_FABRIC_REMARKS = 289,//Temp Need to Add in DB
        MANAGE_ORDERS_FILE_ACCESSORIES_ACCESSORIES_REMARKS = 290,//Temp Need to Add in DB
        MANAGE_ORDERS_FILE_MARCHANDISING_EXFACTORY = 291,


        // =============ACCESSORIES_ORDER_FORM==================
        ACCESSORIES_ORDER_FORM_NUMBER = 292,//+		
        ACCESSORIES_ORDER_FORM_FLATWST = 293,//+			
        ACCESSORIES_ORDER_FORM_DETAILS = 294,//+			
        ACCESSORIES_ORDER_FORM_ISDTM = 295,//+		
        ACCESSORIES_ORDER_FORM_SWATCH = 296,//+			
        ACCESSORIES_ORDER_FORM_DELETED = 297,//+	
        ACCESSORIES_ORDER_FORM_ACCESSORIES = 298,//+	
        ACCESSORY_DETAIL_AVG_CHECKED = 231,
        ACCESSORY_DETAIL_AVG = 239,


        //==============COSTING================================
        COSTING_PRICE_QUOTED = 299,
        COSTING_UPDATE_PRICE_BIPL = 300,//+			
        COSTING_UPDATE_PRICE_IKANDI = 301,//+			
        COSTING_REQUEST_COST_CONFIRMATION = 302,//+			
        COSTING_CONFIRM_COST = 303,//+
        COSTING_CONFIRM_SUBMIT = 304,//<==abhishek

        //============SAMPLING_STATUS==========================
        SAMPLING_STATUS_FILE_UNIT = 305,
        SAMPLING_STATUS_FILE_ASSIGNED_TO = 306,
        SAMPLING_STATUS_FILE_RECEIVED_ON = 307,
        SAMPLING_STATUS_FILE_EXPECTED_DISPATCH_DATE = 308,
        SAMPLING_STATUS_FILE_COUNTER_COMPLETE = 309,
        SAMPLING_STATUS_FILE_SAMPLING_STATUS_REMARKS = 310,
        SAMPLING_STATUS_CURRENT_UPDATE = 311,

        //==============FABRIC_SAMPLING========================
        FABRIC_SAMPLING_FABRIC = 312,
        FABRIC_SAMPLING_FILE_PRINT_DESIGN_NUMBER_LAB_DIPS = 313,
        FABRIC_SAMPLING_FILE_MILL_NAME = 314,
        FABRIC_SAMPLING_FILE_MILL_DESIGN_NUMBER = 315,
        FABRIC_SAMPLING_FILE_PRINT_TYPE = 316,
        FABRIC_SAMPLING_FILE_TECHNIQUE_OF_PRINT = 317,
        FABRIC_SAMPLING_FILE_QTY_ORDERED = 318,
        FABRIC_SAMPLING_FILE_QTY_RECEIVED = 319,
        FABRIC_SAMPLING_FILE_ORIGIN = 320,
        FABRIC_SAMPLING_FILE_NO_OF_COLS_SCREENS = 321,
        FABRIC_SAMPLING_FILE_COST_PER_SCREENS = 322,
        FABRIC_SAMPLING_FILE_REMARKS = 323,
        FABRIC_SAMPLING_FILE_DATE_OF_RECEIVING = 324,
        FABRIC_SAMPLING_FILE_EXPECTED_ISSUE_DATE = 325,
        FABRIC_SAMPLING_FILE_ACTUAL_ISSUE_DATE = 326,
        FABRIC_SAMPLING_FILE_EXPECTED_RECIEPT_DATE = 327,
        FABRIC_SAMPLING_ACTUAL_RECIEPT_DATE = 328,

        //==============PRINT_TESTING===========================
        PRINT_TESTING_SECTION = 329,//+

        //==============DESIGN_LIST_SAMPLING====================

        //DESIGN_LIST_SAMPLING_CURRENT_UPDATE=105,
        DESIGN_LIST_CURRENT_UPDATE = 330,
        DESIGN_LIST_SAMPLING_FILE_COURIER_RECEIVED_ON = 331,
        DESIGN_LIST_SAMPLING_FILE_COURIER_RECEIVED = 332,
        DESIGN_LIST_SAMPLE_RECEIVED_COURIER_RECEIVED_ON = 333,

        //==============LIMITATIONS_FORM========================
        LIMITATIONS_FORM_BULK_IN_HOUSE_DAYS_COLUMN = 334,
        LIMITATIONS_FORM_BULK_TARGET = 335,
        LIMITATIONS_FORM_IKANDI_COMMENTS = 336,
        LIMITATIONS_FORM_APPROVED_BY_FABRIC_MGR = 152,
        LIMITATIONS_FORM_APPROVED_BY_ACCESSORIES_MGR = 153,

        //==============SEALERS_PENDING_SEALER==================

        SEALERS_PENDING_SEALER_REMARKS_BIPL = 337,
        SEALERS_PENDING_SEALER_REMARKS_IKANDI = 338,

        //==============PRODUCTION_PLANNING_FORM================
        PRODUCTION_PLANNING_FORM_QTY_BEING_SHIPPED = 339,
        PRODUCTION_PLANNING_FORM_REASONS_FOR_SHORT_SHIPPING = 340,
        PRODUCTION_PLANNING_FORM_CHECK_TO_ENTER_SHIPMENT_PLANNING = 341,
        PRODUCTION_PLANNING_FORM_PLANNED_EX_BY_PRODUCTION = 342,
        PRODUCTION_PLANNING_FILE_REMOVE = 343,

        //==============DC_BOOKING_FILE=========================
        DC_BOOKING_FILE_CHECK_BOX_TO_BOOK = 344,
        DC_BOOKING_FILE_BOOKING_REQUESTED_ON = 345,
        DC_BOOKING_FILE_BOOKING_REF_NO = 346,
        DC_BOOKING_FILE_P_LIST_ENTERED_SPLITS_CONFIRMED_CHECK_BOX = 347,
        DC_BOOKING_FILE_BOOKING_REF_NO_EXPECTED_INTO_DC = 348,
        DC_BOOKING_FILE_ATTACH_BOOKING_DOCUMENTS = 349,
        DC_BOOKING_FILE_REMOVE = 350,

        //==============UK_DELIVERY_FILE=========================
        UK_DELIVERY_FILE_CARGO_RECEIPT_DATE = 351,
        UK_DELIVERY_FILE_SENT_TO_PROCESSING_HOUSE = 352,
        UK_DELIVERY_FILE_DELIVERY_NOTE_UPLOADED = 353,

        //==============PACKING_LIST=============================
        PACKING_LIST_TOP_SECTION = 354,

        //==============DASHBOARD================================
        DASHBOARD_COSTING_AND_ENQUIRIES = 355,
        DASHBOARD_BOOKING_CALCULATOR = 356,
        DASHBOARD_HIT_RATES_FOR_DESIGNERS_REPORT = 357,

        //==============BIPL_INVOICES============================
        BIPL_INVOICES_RAISE_BE = 358,
        BIPL_INVOICES_BE_NO_DATE = 359,
        BIPL_INVOICES_BE_AMOUNT = 360,
        BIPL_INVOICES_PAYMENT_DUE_DATE = 361,
        BIPL_INVOICES_PAYMENT_RECEVIED_DATE = 362,
        BIPL_INVOICES_INVOICE_AMOUNT = 363,

        //==============PROCESSING===============================
        PROCESSING_CARGO_RECEIPT_DATE = 364,
        PROCESSING_PROCESSING_COMPLETION_DATE = 365,
        PROCESSING_P_LIST_ENTERED = 366,
        PROCESSING_DELIVERY_NOTE_UPLOADED = 367,

        //==============IKANDI_INVOICES==========================
        IKANDI_INVOICES_PAYMENT_DUE_DATE = 368,
        IKANDI_INVOICES_PAYMENT_RECEVIED_DATE_AMOUNT = 369,


        //==============SHIPMENT_PLANNING========================
        SHIPMENT_PLANNING_FILE_SHIPMENT_PLANNING_SELECTION = 154,
        SHIPMENT_PLANNING_FILE_UPLOAD_CUSTOMS_P_LIST = 155,
        SHIPMENT_PLANNING_FILE_UPLOAD_BUYER_P_LIST = 156,
        SHIPMENT_PLANNING_FILE_UPLOAD_DOCUMENTS_PRE = 157,
        SHIPMENT_PLANNING_FILE_UPLOAD_SHIPMENT_INSTRUCTIONS = 158,
        SHIPMENT_PLANNING_FILE_SEND_EMAIL_PRE_ALERT_INDIA = 159,
        SHIPMENT_PLANNING_FILE_PART_SHIPMENT = 160,
        SHIPMENT_PLANNING_FILE_SHIPMENT_SENT_TO_FORWARDER = 161,
        SHIPMENT_PLANNING_FILE_REMARKS_AUTHORIZATION_FOR_PART_SHIPMENT = 162,
        SHIPMENT_PLANNING_FILE_REMOVE = 163,
        SHIPMENT_PLANNING_FILE_SELECT_SHIPMENT_NO = 164,
        SHIPMENT_PLANNING_FILE_ENTER_DETAILS = 165,
        SHIPMENT_PLANNING_FILE_ENTER_FLIGHT_SAILING_DETAILS = 166,
        SHIPMENT_PLANNING_FILE_ENTER_LANDING_ETA = 167,
        SHIPMENT_PLANNING_FILE_DC_DATE = 168,
        SHIPMENT_PLANNING_FILE_SEND_EMAIL = 169,
        SHIPMENT_PLANNING_FILE_UPLOAD_DOCUMENTS_POST = 170,
        SHIPMENT_PLANNING_FILE_SPECIAL_INSTURCTIONS = 171,

        //DESIGN_LIST_CURRENT_UPDATE = 172,            
        QA_STATUS_MO = 173,
        ORDER_FORM_ORDER_DATE = 370,

        //===================NOT IN USE===========================
        //PRINT_BIPL_COSTING_FORM = 261,   
        //QUALITY_CONTROL_QA_MANAGER = 194,      
        //QUALITY_CONTROL_ONLINE_RESOLUTION = 230,
        //QUALITY_CONTROL_RESOLUTION = 231,
        REALLOCATION_FORM_SUBMIT_BUTTON = 230,
        MMR_REPORT_BUTTON = 294,
        REALLOCATION_DELETE = 229,

    }

    # endregion

    #region Style Reference Block Type

    public enum ReferenceBlockType
    {
        Block = 1,
        INDBlock = 2,
        EMBELLISHMENT = 3,
        MOCKS = 4,
        CAD = 5,
        MACHINE_EMBELLISHMENT = 6
    }


    #endregion

    #region Workflow Status ActionID Enum

    public enum WorkflowStatusActionID
    {
        Cancel = 34,
        OnHold = 35
    }


    #endregion

    #region Shipment Email Type Enum

    public enum ShipmentEmailType
    {
        PRE_ALERT = 1,
        POST_SHIPMENT = 2,
        BOTH = 3,
    }

    #endregion

    #region Category Type Enum

    public enum CategoryType
    {
        FABRIC_QUALITY = 1,
        ACCESSORY_QUALITY = 2
    }

    #endregion

    #region Category Type New Enum

    public enum CategoryTypeNew
    {
        Fabric = 1,
        Accessory = 2
    }

    #endregion

    #region SupplyType Enum

    public enum SupplyType
    {
        LANDED = 1,
        DIRECT_EX_FACTORY,
        DIRECT_EX_PORT
    }

    #endregion

    #region ModeType Enum

    public enum ModeType
    {
        SEA = 1,
        AIR
    }

    #endregion

    #region PackingType Enum

    public enum PackingType
    {
        HANGING = 1,
        FLAT,
        BOX_HANGING,

    }

    #endregion

    #region Terms Enum

    public enum Terms
    {
        FOB = 1,
        CIF
    }

    #endregion

    #region Garment Tesing ReportType

    public enum GarmentTestingReport
    {
        GarmentTest = 1,
        BulkTest = 2
    }

    #endregion

    #region Quality Analysis Status

    public enum QAStatus
    {
        PASS = 1,
        FAIL = 2
    }

    #endregion

    #region Holiday / Leave

    public enum LeaveStatus
    {
        Pending = 1,
        Granted,
        Rejected,
        Cancelled,
        Availed
    }

    public enum HolidayType
    {
        National = 1,
        Event,
        Other
    }

    #endregion

    #region Client Costing Items

    public enum ClientCostingItem
    {
        FINISH = 1,
        LBL_TAGS,
        TEST,
        HANGER_LOOPS,
        CONVERSION_TO,
        MARKUP_ON_UNIT_CTC,
        COMMISION,
        //manisha 12 may 2011
        OVERHEAD,
        HANGERS,
        //Added by Ashish ON 26/2/2014
        DESIGNCOMMISSION
        //END
    }

    #endregion

    #region User Task Type

    public enum UserTaskType
    {
        CostConfirmation = 1,
        StatusMeetingResolution = 2,
        QAResolution = 3,
        DeshboardWorkflow = 4,
        OrderCancellation = 5,
        HoldTillOrderCancellation = 6,
        BulkInHouseTarget = 7,
        BIPLOrderAgreement = 8,
        PriceUpdate = 9,
        ShipmentOffer = 10,
        SAMPLINGFILERESOLUTION = 11,
        Ucknowledgement = 14,
        OB = 15,
        Risk = 16,
        FinalOB = 17
    }


    #endregion

    #region Top Status Type

    // Update By Ravi kumar on 6/1/2015
    public enum TopStatusType
    {
        UNKNOWN = 0,
        REJECTED = 1,
        APPROVED = 2
    }

    #endregion

    #region Type of Packing of OrderForm

    public enum TypeofPacking
    {
        BDCM = 1,
        Coffin_Box = 2
    }

    #endregion

    #region Garment Type

    public enum GarmentType
    {
        TP = 1,
        SH,
        DR,
        SK,
        PS,
        JS,
        JK
    }

    #endregion

    #region Style Current update

    public enum StyleCurrentUpdates
    {
        Fabric_Sampling_Program_Issued = 1,
        Issued_For_Pattern_Making = 2,
        Fabric_Issued_For_Cutting = 3,
        On_Machine_Or_Finishing_Or_Ready_For_Dispatch = 4

    }

    #endregion

    #region POType

    public enum PoType
    {
        Greige = 1,
        Processed = 2,
        Finished = 3,
        Imported = 4,
        ReProcessing = 5,
        Sampling = 6,
        PreWash4Pc = 7,
        PostWash4Pc = 8,
        UnderWash = 9,
        Washed = 10,
        Cutting = 8
    }

    #endregion

    #region Instruction Group Master

    public enum IGMaster
    {
        TermCondition = 1,
        TechnicalInstruction = 2,
        Sampling = 3,
        Greige = 4,
        Production = 5,
        Fabric = 6,
        Acessory = 7
    }
    //Added by abhishek on 27/12/2019
    public enum FabricProcessTypes
    {
        Griege = 1,
        Dyed = 2,
        Printed = 3,
        DigitalPrinted = 6,
        Process = 8,
        Finished = 10,
        RFD = 29,
        Fabric_softening = 27,
        Width_adjustment = 28,
        Embellishment = 30,
        Embroidery = 31
    }
    public enum FabricPOStatus
    {
        Cancel = 1,
        Close = 2
    }

    #endregion

    #region Costing SerialWise Enum

    public enum CostingSerial
    {
        Fabric = 1,
        CMT = 2,
        Accessories = 3,
        Process = 4,
        Financial = 5,
        BIPL_Costing_Sheet = 1119,
        LandedCosting = 6,
        DirectCosting_FOB = 7,
        iKandi_Costing_Sheet = 1118,
        Agree = 118,
        Disagree = 119
    }

    #endregion


}



