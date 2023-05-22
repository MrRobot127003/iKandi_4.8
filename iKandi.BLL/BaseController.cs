using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;

namespace iKandi.BLL
{
    public class BaseController
    {
        #region Fields

        #endregion

        #region Properties

        #region Data Providers

        public SessionInfo LoggedInUser
        {
            get;
            set;
        }


        private TaskMappingProvider _TaskMappingProvider = null;
        protected TaskMappingProvider TaskMappingProviderInstance
        {
            get
            {
                if (_TaskMappingProvider == null)
                    _TaskMappingProvider = new TaskMappingProvider(this.LoggedInUser);
                return _TaskMappingProvider;
            }
        }

        private AllocationDataProvider _allocationDataProvider = null;
        protected AllocationDataProvider AllocationDataProviderInstance
        {
            get
            {
                if (_allocationDataProvider == null)
                    _allocationDataProvider = new AllocationDataProvider(this.LoggedInUser);

                return _allocationDataProvider;
            }

        }

        private ClientDataProvider _clientDataProvider = null;
        protected ClientDataProvider ClientDataProviderInstance
        {
            get
            {
                if (_clientDataProvider == null)
                    _clientDataProvider = new ClientDataProvider(this.LoggedInUser);

                return _clientDataProvider;
            }

        }

        private UserTaskDataProvider _userTaskDataProvider = null;
        protected UserTaskDataProvider UserTaskDataProviderInstance
        {
            get
            {
                if (_userTaskDataProvider == null)
                    _userTaskDataProvider = new UserTaskDataProvider(this.LoggedInUser);

                return _userTaskDataProvider;
            }

        }

        private CommonDataProvider _commonDataProvider = null;
        protected CommonDataProvider CommonDataProviderInstance
        {
            get
            {
                if (_commonDataProvider == null)
                    _commonDataProvider = new CommonDataProvider(this.LoggedInUser);

                return _commonDataProvider;
            }

        }


        private ConfigurationDataProvider _configurationDataProvider = null;
        protected ConfigurationDataProvider ConfigurationDataProviderInstance
        {
            get
            {
                if (_configurationDataProvider == null)
                    _configurationDataProvider = new ConfigurationDataProvider(this.LoggedInUser);

                return _configurationDataProvider;
            }

        }


        private CostingDataProvider _costingDataProvider = null;
        protected CostingDataProvider CostingDataProviderInstance
        {
            get
            {
                if (_costingDataProvider == null)
                    _costingDataProvider = new CostingDataProvider(this.LoggedInUser);

                return _costingDataProvider;
            }

        }

        private CostingDataProviderNew _costingDataProviderNew = null;
        protected CostingDataProviderNew CostingDataProviderInstanceNew
        {
            get
            {
                if (_costingDataProviderNew == null)
                    _costingDataProviderNew = new CostingDataProviderNew(this.LoggedInUser);

                return _costingDataProviderNew;
            }

        }


        private CourierDataProvider _courierDataProvider = null;
        protected CourierDataProvider CourierDataProviderInstance
        {
            get
            {
                if (_courierDataProvider == null)
                    _courierDataProvider = new CourierDataProvider(this.LoggedInUser);

                return _courierDataProvider;
            }
        }

        private CuttingDataProvider _cuttingDataProvider = null;
        protected CuttingDataProvider CuttingDataProviderInstance
        {
            get
            {
                if (_cuttingDataProvider == null)
                    _cuttingDataProvider = new CuttingDataProvider(this.LoggedInUser);

                return _cuttingDataProvider;
            }
        }

        private DepartmentDataProvider _departmentDataProvider = null;
        protected DepartmentDataProvider DepartmentDataProviderInstance
        {
            get
            {
                if (_departmentDataProvider == null)
                    _departmentDataProvider = new DepartmentDataProvider(this.LoggedInUser);

                return _departmentDataProvider;
            }
        }

        private DesignationDataProvider _designationDataProvider = null;
        protected DesignationDataProvider DesignationDataProviderInstance
        {
            get
            {
                if (_designationDataProvider == null)
                    _designationDataProvider = new DesignationDataProvider(this.LoggedInUser);

                return _designationDataProvider;
            }
        }

        private FabricSamplingDataProvider _fabricSamplingDataProvider = null;
        protected FabricSamplingDataProvider FabricSamplingDataProviderInstance
        {
            get
            {
                if (_fabricSamplingDataProvider == null)
                    _fabricSamplingDataProvider = new FabricSamplingDataProvider(this.LoggedInUser);

                return _fabricSamplingDataProvider;
            }
        }

        private FabricWorkingDataProvider _fabricWorkingDataProvider = null;
        protected FabricWorkingDataProvider FabricWorkingDataProviderInstance
        {
            get
            {
                if (_fabricWorkingDataProvider == null)
                    _fabricWorkingDataProvider = new FabricWorkingDataProvider(this.LoggedInUser);

                return _fabricWorkingDataProvider;
            }
        }

        private FabricAccessoriesWorkSheetDataProvider _fabricAccessoryWorkingDataProvider = null;
        protected FabricAccessoriesWorkSheetDataProvider AccessoryWorkingDataProviderInstance
        {
            get
            {
                if (_fabricAccessoryWorkingDataProvider == null)
                    _fabricAccessoryWorkingDataProvider = new FabricAccessoriesWorkSheetDataProvider(this.LoggedInUser);

                return _fabricAccessoryWorkingDataProvider;
            }
        }

        private FabricApprovalDataProvider _fabricApprovalDataProvider = null;
        protected FabricApprovalDataProvider FabricApprovalDataProviderInstance
        {
            get
            {
                if (_fabricApprovalDataProvider == null)
                    _fabricApprovalDataProvider = new FabricApprovalDataProvider(this.LoggedInUser);

                return _fabricApprovalDataProvider;
            }
        }

        private FactoryDataProvider _factoryDataProvider = null;
        protected FactoryDataProvider FactoryDataProviderInstance
        {
            get
            {
                if (_factoryDataProvider == null)
                    _factoryDataProvider = new FactoryDataProvider(this.LoggedInUser);

                return _factoryDataProvider;
            }
        }

        private MembershipDataProvider _membershipDataProvider = null;
        protected MembershipDataProvider MembershipDataProviderInstance
        {
            get
            {
                if (_membershipDataProvider == null)
                    _membershipDataProvider = new MembershipDataProvider(this.LoggedInUser);

                return _membershipDataProvider;
            }
        }

        private OrderDataProvider _orderDataProvider = null;
        protected OrderDataProvider OrderDataProviderInstance
        {
            get
            {
                if (_orderDataProvider == null)
                    _orderDataProvider = new OrderDataProvider(this.LoggedInUser);

                return _orderDataProvider;
            }
        }

        private OrderProcessFlow _OrderProcessFlow = null;
        protected OrderProcessFlow OrderProcessFlow_Instance
        {
            get
            {
                if (_OrderProcessFlow == null)
                    _OrderProcessFlow = new OrderProcessFlow(this.LoggedInUser);

                return _OrderProcessFlow;
            }
        }

        private PrintDataProvider _printDataProvider = null;
        protected PrintDataProvider PrintDataProviderInstance
        {
            get
            {
                if (_printDataProvider == null)
                    _printDataProvider = new PrintDataProvider(this.LoggedInUser);

                return _printDataProvider;
            }
        }

        private StyleDataProvider _styleDataProvider = null;
        protected StyleDataProvider StyleDataProviderInstance
        {
            get
            {
                if (_styleDataProvider == null)
                    _styleDataProvider = new StyleDataProvider(this.LoggedInUser);

                return _styleDataProvider;
            }
        }

        private UserDataProvider _userDataProvider = null;
        protected UserDataProvider UserDataProviderInstance
        {
            get
            {
                if (_userDataProvider == null)
                    _userDataProvider = new UserDataProvider(this.LoggedInUser);

                return _userDataProvider;
            }
        }

        private WorkflowDataProvider _workflowDataProvider = null;
        protected WorkflowDataProvider WorkflowDataProviderInstance
        {
            get
            {
                if (_workflowDataProvider == null)
                    _workflowDataProvider = new WorkflowDataProvider(this.LoggedInUser);

                return _workflowDataProvider;
            }
        }

        private PermissionDataProvider _permissionDataProvider = null;
        protected PermissionDataProvider PermissionDataProviderInstance
        {
            get
            {
                if (_permissionDataProvider == null)
                    _permissionDataProvider = new PermissionDataProvider(this.LoggedInUser);

                return _permissionDataProvider;
            }
        }

        private FabricQualityDataProvider _fabricQualityDataProvider = null;
        protected FabricQualityDataProvider FabricQualityDataProviderInstance
        {
            get
            {
                if (_fabricQualityDataProvider == null)
                    _fabricQualityDataProvider = new FabricQualityDataProvider(this.LoggedInUser);

                return _fabricQualityDataProvider;
            }
        }

        private FabricDataProvider _fabricDataProvider = null;
        protected FabricDataProvider FabricDataProviderInstance
        {
            get
            {
                if (_fabricDataProvider == null)
                    _fabricDataProvider = new FabricDataProvider(this.LoggedInUser);

                return _fabricDataProvider;
            }
        }

        private WashingCuttingDataProvider _washingCuttingDataProvider = null;
        protected WashingCuttingDataProvider WashingCuttingDataProviderInstance
        {
            get
            {
                if (_washingCuttingDataProvider == null)
                    _washingCuttingDataProvider = new WashingCuttingDataProvider(this.LoggedInUser);

                return _washingCuttingDataProvider;
            }
        }

        private FourPointDataProvider _fourpointDataProvider = null;
        protected FourPointDataProvider FoutPointDataProviderInstance
        {
            get
            {
                if (_fourpointDataProvider == null)
                    _fourpointDataProvider = new FourPointDataProvider(this.LoggedInUser);

                return _fourpointDataProvider;
            }
        }

        private FinancialDataProvider _financialDataProvider = null;
        protected FinancialDataProvider FinancialDataProviderInstance
        {
            get
            {
                if (_financialDataProvider == null)
                    _financialDataProvider = new FinancialDataProvider(this.LoggedInUser);

                return _financialDataProvider;
            }
        }

        private InlinePPMDataProvider _inlinePPMDataProvider = null;
        protected InlinePPMDataProvider InlinePPMDataProviderInstance
        {
            get
            {
                if (_inlinePPMDataProvider == null)
                    _inlinePPMDataProvider = new InlinePPMDataProvider(this.LoggedInUser);

                return _inlinePPMDataProvider;
            }
        }

        private FITsDataProvider _fITsDataProvider = null;
        protected FITsDataProvider FITsDataProviderInstance
        {
            get
            {
                if (_fITsDataProvider == null)
                    _fITsDataProvider = new FITsDataProvider(this.LoggedInUser);

                return _fITsDataProvider;
            }
        }

        private AccessoryQualityDataProvider _accessoryQualityDataProvider = null;
        protected AccessoryQualityDataProvider AccessoryQualityDataProviderInstance
        {
            get
            {
                if (_accessoryQualityDataProvider == null)
                    _accessoryQualityDataProvider = new AccessoryQualityDataProvider(this.LoggedInUser);

                return _accessoryQualityDataProvider;
            }
        }

        private AdminDataProvider _adminDataProvider = null;
        protected AdminDataProvider AdminDataProviderInstance
        {
            get
            {
                if (_adminDataProvider == null)
                    _adminDataProvider = new AdminDataProvider(this.LoggedInUser);

                return _adminDataProvider;
            }
        }

        private LiabilityDataProvider _liabilityDataProvider = null;
        protected LiabilityDataProvider LiabilityDataProviderInstance
        {
            get
            {
                if (_liabilityDataProvider == null)
                    _liabilityDataProvider = new LiabilityDataProvider(this.LoggedInUser);

                return _liabilityDataProvider;
            }
        }

        private ReportDataProvider _reportDataProvider = null;
        protected ReportDataProvider ReportDataProviderInstance
        {
            get
            {
                if (_reportDataProvider == null)
                    _reportDataProvider = new ReportDataProvider(this.LoggedInUser);

                return _reportDataProvider;
            }
        }

        private DeliveryDataProvider _deliveryDataProvider = null;
        protected DeliveryDataProvider DeliveryDataProviderInstance
        {
            get
            {
                if (_deliveryDataProvider == null)
                    _deliveryDataProvider = new DeliveryDataProvider(this.LoggedInUser);

                return _deliveryDataProvider;
            }
        }

        private QualityControlDataProvider _qualityControlDataProvider = null;
        protected QualityControlDataProvider QualityControlDataProviderInstance
        {
            get
            {
                if (_qualityControlDataProvider == null)
                    _qualityControlDataProvider = new QualityControlDataProvider(this.LoggedInUser);

                return _qualityControlDataProvider;
            }
        }

        private PartnerDataProvider _partnerDataProvider = null;
        protected PartnerDataProvider PartnerDataProviderInstance
        {
            get
            {
                if (_partnerDataProvider == null)
                    _partnerDataProvider = new PartnerDataProvider(this.LoggedInUser);

                return _partnerDataProvider;
            }
        }

        private DesignerTargetAllocationDataprovider _designerTargetAllocationDataprovider = null;
        protected DesignerTargetAllocationDataprovider DesignerTargetAllocationDataproviderInstance
        {
            get
            {
                if (_designerTargetAllocationDataprovider == null)
                    _designerTargetAllocationDataprovider = new DesignerTargetAllocationDataprovider(this.LoggedInUser);

                return _designerTargetAllocationDataprovider;
            }
        }

        private InvoiceDataProvider _invoiceDataProvider = null;
        protected InvoiceDataProvider InvoiceDataProviderInstance
        {
            get
            {
                if (_invoiceDataProvider == null)
                    _invoiceDataProvider = new InvoiceDataProvider(this.LoggedInUser);

                return _invoiceDataProvider;
            }
        }

        private INDBlockDataProvider _iNDBlockDataProvider = null;
        protected INDBlockDataProvider INDBlockDataProviderInstance
        {
            get
            {
                if (_iNDBlockDataProvider == null)
                    _iNDBlockDataProvider = new INDBlockDataProvider(this.LoggedInUser);

                return _iNDBlockDataProvider;
            }
        }

        private LeaveDataProvider _leaveDataProvider = null;
        protected LeaveDataProvider LeaveDataProviderInstance
        {
            get
            {
                if (_leaveDataProvider == null)
                    _leaveDataProvider = new LeaveDataProvider(this.LoggedInUser);

                return _leaveDataProvider;
            }

        }

        private LabTestDataProvider _labTestDataProvider = null;
        protected LabTestDataProvider LabTestDataProviderInstance
        {
            get
            {
                if (_labTestDataProvider == null)
                    _labTestDataProvider = new LabTestDataProvider(this.LoggedInUser);

                return _labTestDataProvider;
            }
        }

        private BuyingHouseDataProvider _BuyingHouseDataProvider = null;
        protected BuyingHouseDataProvider BuyingHouseDataProvider
        {
            get
            {
                if (_BuyingHouseDataProvider == null)
                    _BuyingHouseDataProvider = new BuyingHouseDataProvider(this.LoggedInUser);

                return _BuyingHouseDataProvider;
            }
        }

        private PODataProvider _poDataProvider = null;
        protected PODataProvider PODataProviderInstance
        {
            get
            {
                if (_poDataProvider == null)
                    _poDataProvider = new PODataProvider(this.LoggedInUser);
                return _poDataProvider;
            }
        }

        private SupplierDataProvider _supplierDataProvider = null;
        protected SupplierDataProvider SupplierDataProviderInstance
        {
            get
            {
                if (_supplierDataProvider == null)
                    _supplierDataProvider = new SupplierDataProvider(this.LoggedInUser);
                return _supplierDataProvider;
            }
        }

        private SrvDataProvider _srvDataProvider = null;
        protected SrvDataProvider SRVDataProviderInstance
        {
            get
            {
                if (_srvDataProvider == null)
                    _srvDataProvider = new SrvDataProvider(this.LoggedInUser);
                return _srvDataProvider;
            }
        }

        private GreigeStockDataProvider _greigeDataProvider = null;
        public GreigeStockDataProvider GreigeStockDataProviderInstance
        {
            get
            {
                if (_greigeDataProvider == null)
                    _greigeDataProvider = new GreigeStockDataProvider(this.LoggedInUser);
                return _greigeDataProvider;
            }
        }

        private ProductionDataProvider _productionDataProvider = null;
        protected ProductionDataProvider ProductionDataProviderInstance
        {
            get
            {
                if (_productionDataProvider == null)
                    _productionDataProvider = new ProductionDataProvider(this.LoggedInUser);

                return _productionDataProvider;
            }
        }

        private OrderPlaceDataProvider _OrderPlaceDataProvider = null;
        protected OrderPlaceDataProvider OrderPlaceDataProviderInstance
        {
            get
            {
                if (_OrderPlaceDataProvider == null)
                    _OrderPlaceDataProvider = new OrderPlaceDataProvider(this.LoggedInUser);

                return _OrderPlaceDataProvider;
            }
        }

        #endregion


        #region Controllers

        private FabricController _fabricController = null;
        protected FabricController FabricInstance
        {
            get
            {
                if (_fabricController == null)
                    _fabricController = new FabricController(this.LoggedInUser);

                return _fabricController;
            }
        }

        private WorkflowController _workflowController = null;
        protected WorkflowController WorkflowControllerInstance
        {
            get
            {
                if (_workflowController == null)
                    _workflowController = new WorkflowController(this.LoggedInUser);

                return _workflowController;
            }
        }

        private NotificationController _notificationController = null;
        protected NotificationController NotificationControllerInstance
        {
            get
            {
                if (_notificationController == null)
                    _notificationController = new NotificationController(this.LoggedInUser);

                return _notificationController;
            }
        }

        private StyleController _styleController = null;
        protected StyleController StyleControllerInstance
        {
            get
            {
                if (_styleController == null)
                    _styleController = new StyleController(this.LoggedInUser);

                return _styleController;
            }
        }

        private ReportController _reportController = null;
        protected ReportController ReportControllerInstance
        {
            get
            {
                if (_reportController == null)
                    _reportController = new ReportController(this.LoggedInUser);

                return _reportController;
            }
        }

        private LiabilityController _liabilityController = null;
        protected LiabilityController LiabilityControllerInstance
        {
            get
            {
                if (_liabilityController == null)
                    _liabilityController = new LiabilityController(this.LoggedInUser);

                return _liabilityController;
            }
        }

        private BuyingHouseController _buyingHouseController = null;
        protected BuyingHouseController BuyingHouseControllerInstance
        {
            get
            {
                if (_buyingHouseController == null)
                    _buyingHouseController = new BuyingHouseController(this.LoggedInUser);

                return _buyingHouseController;
            }
        }

        private POController _poController = null;
        public POController POControllerInstance
        {
            get
            {
                if (_poController == null)
                    _poController = new POController(this.LoggedInUser);
                return _poController;
            }
        }

        private SRVController _srvController = null;
        public SRVController SRVControllerInstance
        {
            get
            {
                if (_srvController == null)
                    _srvController = new SRVController(this.LoggedInUser);
                return _srvController;
            }
        }

        private SupplierController _supplierController = null;
        public SupplierController SupplierControllerInstance
        {
            get
            {
                if (_supplierController == null)
                    _supplierController = new SupplierController(this.LoggedInUser);
                return _supplierController;
            }
        }

        private FourPointController _fourpointController = null;
        public FourPointController FourPointControllerInstance
        {
            get
            {
                if (_fourpointController == null)
                    _fourpointController = new FourPointController(this.LoggedInUser);
                return _fourpointController;
            }
        }


        private GreigeController _greigeController = null;
        public GreigeController GreigeControllerInstance
        {
            get
            {
                if (_greigeController == null)
                    _greigeController = new GreigeController(this.LoggedInUser);
                return _greigeController;
            }
        }
        //Gajendra Email Notification
        private NotificationDataProvider _notificationDataProvider = null;
        protected NotificationDataProvider NotificationDataProviderInstance
        {
            get
            {
                if (_notificationDataProvider == null)
                    _notificationDataProvider = new NotificationDataProvider(this.LoggedInUser);

                return _notificationDataProvider;
            }
        }
        #endregion

        #endregion

        #region Ctor(s)

        public BaseController()
        {
        }

        public BaseController(SessionInfo LoggedInUser)
        {
            this.LoggedInUser = LoggedInUser;
        }
        #endregion

    }
}
