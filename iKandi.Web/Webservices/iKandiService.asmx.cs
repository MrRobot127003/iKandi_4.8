using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using iKandi.BLL;
using iKandi.BLL.Production;
using iKandi.Web.Components;

namespace iKandi.Web
{
    /// <summary>
    /// Summary description for iKandiService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public partial class iKandiService : System.Web.Services.WebService
    {

        #region Controllers

        private AllocationController _allocationController = null;
        public AllocationController AllocationControllerInstance
        {
            get
            {
                if (_allocationController == null)
                    _allocationController = new AllocationController(ApplicationHelper.LoggedInUser);
                return _allocationController;
            }
        }

        private ClientController _clientController = null;
        public ClientController ClientControllerInstance
        {
            get
            {
                if (_clientController == null)
                    _clientController = new ClientController(ApplicationHelper.LoggedInUser);
                return _clientController;
            }
        }

        private CommonController _commonController = null;
        public CommonController CommonControllerInstance
        {
            get
            {
                if (_commonController == null)
                    _commonController = new CommonController(ApplicationHelper.LoggedInUser);
                return _commonController;
            }
        }

        private CourierController _courierController = null;
        public CourierController CourierControllerInstance
        {
            get
            {
                if (_courierController == null)
                    _courierController = new CourierController(ApplicationHelper.LoggedInUser);
                return _courierController;
            }
        }

        private DepartmentController _departmentController = null;
        public DepartmentController DepartmentControllerInstance
        {
            get
            {
                if (_departmentController == null)
                    _departmentController = new DepartmentController(ApplicationHelper.LoggedInUser);
                return _departmentController;
            }
        }

        private DesignationController _designationController = null;
        public DesignationController DesignationControllerInstance
        {
            get
            {
                if (_designationController == null)
                    _designationController = new DesignationController(ApplicationHelper.LoggedInUser);
                return _designationController;
            }
        }


        private ConfigurationController _configurationControllerInstance = null;
        public ConfigurationController ConfigurationControllerInstance
        {
            get
            {
                if (_configurationControllerInstance == null)
                    _configurationControllerInstance = new ConfigurationController(ApplicationHelper.LoggedInUser);
                return _configurationControllerInstance;
            }
        }


        private CostingController _costingController = null;
        public CostingController CostingControllerInstance
        {
            get
            {
                if (_costingController == null)
                    _costingController = new CostingController(ApplicationHelper.LoggedInUser);
                return _costingController;
            }
        }

        private CostingContollerNew _costingControllerNew = null;
        public CostingContollerNew CostingControllerInstanceNew
        {
            get
            {
                if (_costingControllerNew == null)
                    _costingControllerNew = new CostingContollerNew(ApplicationHelper.LoggedInUser);
                return _costingControllerNew;
            }
        }

        private FabricSmplingController _fabricSmplingController = null;
        public FabricSmplingController FabricSmplingControllerInstance
        {
            get
            {
                if (_fabricSmplingController == null)
                    _fabricSmplingController = new FabricSmplingController(ApplicationHelper.LoggedInUser);
                return _fabricSmplingController;
            }
        }

        private FabricWorkingController _fabricWorkingController = null;
        public FabricWorkingController FabricWorkingControllerInstance
        {
            get
            {
                if (_fabricWorkingController == null)
                    _fabricWorkingController = new FabricWorkingController(ApplicationHelper.LoggedInUser);
                return _fabricWorkingController;
            }
        }

        private MembershipController _membershipController = null;
        public MembershipController MembershipControllerInstance
        {
            get
            {
                if (_membershipController == null)
                    _membershipController = new MembershipController(ApplicationHelper.LoggedInUser);
                return _membershipController;
            }
        }


        private PrintController _printController = null;
        public PrintController PrintControllerInstance
        {
            get
            {
                if (_printController == null)
                    _printController = new PrintController(ApplicationHelper.LoggedInUser);
                return _printController;
            }
        }

        private StyleController _styleController = null;
        public StyleController StyleControllerInstance
        {
            get
            {
                if (_styleController == null)
                    _styleController = new StyleController(ApplicationHelper.LoggedInUser);
                return _styleController;
            }
        }

        private OrderController _orderController = null;
        public OrderController OrderControllerInstance
        {
            get
            {
                if (_orderController == null)
                    _orderController = new OrderController(ApplicationHelper.LoggedInUser);
                return _orderController;
            }
        }
        private OrderProcessController _OrderProcessFlow = null;
        public OrderProcessController OrderProcessFlowInstance
        {
            get
            {
                if (_OrderProcessFlow == null)
                    _OrderProcessFlow = new OrderProcessController(ApplicationHelper.LoggedInUser);
                return _OrderProcessFlow;
            }
        }

        private UserController _userController = null;
        public UserController UserControllerInstance
        {
            get
            {
                if (_userController == null)
                    _userController = new UserController(ApplicationHelper.LoggedInUser);
                return _userController;
            }
        }
        //Added by US for getting owners
        private UserController _userControllerowner = null;
        public UserController UserDataProviderInstance
        {
            get
            {
                if (_userControllerowner == null)
                    _userControllerowner = new UserController(ApplicationHelper.LoggedInUser);
                return _userControllerowner;
            }
        }
        //Added by US for populating owners
        private UserController _userControllerownerpopulat = null;
        public UserController UserDataProviderInstance1
        {
            get
            {
                if (_userControllerownerpopulat == null)
                    _userControllerownerpopulat = new UserController(ApplicationHelper.LoggedInUser);
                return _userControllerownerpopulat;
            }
        }
        private WorkflowController _workflowController = null;
        public WorkflowController WorkflowControllerInstance
        {
            get
            {
                if (_workflowController == null)
                    _workflowController = new WorkflowController(ApplicationHelper.LoggedInUser);
                return _workflowController;
            }
        }

        private PermissionController _permissionController = null;
        public PermissionController PermissionControllerInstance
        {
            get
            {
                if (_permissionController == null)
                    _permissionController = new PermissionController(ApplicationHelper.LoggedInUser);
                return _permissionController;
            }
        }

        private FabricQualityController _fabricQualityController = null;
        public FabricQualityController FabricQualityControllerInstance
        {
            get
            {
                if (_fabricQualityController == null)
                    _fabricQualityController = new FabricQualityController(ApplicationHelper.LoggedInUser);
                return _fabricQualityController;
            }
        }

        private FabricController _fabricController = null;
        public FabricController FabricControllerInstance
        {
            get
            {
                if (_fabricController == null)
                    _fabricController = new FabricController(ApplicationHelper.LoggedInUser);
                return _fabricController;
            }
        }

        private FourPointController _fourpointController = null;
        public FourPointController FourPointControllerInstance
        {
            get
            {
                if (_fourpointController == null)
                    _fourpointController = new FourPointController(ApplicationHelper.LoggedInUser);
                return _fourpointController;
            }
        }

        private InlinePPMController _inlinePPMController = null;
        public InlinePPMController InlinePPMControllerInstance
        {
            get
            {
                if (_inlinePPMController == null)
                    _inlinePPMController = new InlinePPMController(ApplicationHelper.LoggedInUser);
                return _inlinePPMController;
            }
        }

        private AccessoryQualityController _accessoryQualityController = null;
        public AccessoryQualityController AccessoryQualityControllerInstance
        {
            get
            {
                if (_accessoryQualityController == null)
                    _accessoryQualityController = new AccessoryQualityController(ApplicationHelper.LoggedInUser);
                return _accessoryQualityController;
            }
        }

        private AccessoryWorkingController _accessoryWorkingController = null;
        public AccessoryWorkingController AccessoryWorkingControllerInstance
        {
            get
            {
                if (_accessoryWorkingController == null)
                    _accessoryWorkingController = new AccessoryWorkingController(ApplicationHelper.LoggedInUser);
                return _accessoryWorkingController;
            }
        }

        private ReportController _reportController = null;
        public ReportController ReportControllerInstance
        {
            get
            {
                if (_reportController == null)
                    _reportController = new ReportController(ApplicationHelper.LoggedInUser);
                return _reportController;
            }
        }

        private DeliveryController _deliveryController = null;
        public DeliveryController DeliveryControllerInstance
        {
            get
            {
                if (_deliveryController == null)
                    _deliveryController = new DeliveryController(ApplicationHelper.LoggedInUser);
                return _deliveryController;
            }
        }

        private PDFController _pDFController = null;
        public PDFController PDFControllerInstance
        {
            get
            {
                if (_pDFController == null)
                    _pDFController = new PDFController(ApplicationHelper.LoggedInUser);
                return _pDFController;
            }
        }


        private AdminController _adminController = null;
        public AdminController AdminControllerInstance
        {
            get
            {
                if (_adminController == null)
                    _adminController = new AdminController(ApplicationHelper.LoggedInUser);
                return _adminController;
            }
        }

        private InvoiceController _InvoiceController = null;
        public InvoiceController InvoiceControllerInstance
        {
            get
            {
                if (_InvoiceController == null)
                    _InvoiceController = new InvoiceController(ApplicationHelper.LoggedInUser);
                return _InvoiceController;
            }
        }

        private UserTaskController _userTaskController = null;
        public UserTaskController UserTaskControllerInstance
        {
            get
            {
                if (_userTaskController == null)
                    _userTaskController = new UserTaskController(ApplicationHelper.LoggedInUser);
                return _userTaskController;
            }
        }

        private LiabilityController _LiabilityController = null;
        public LiabilityController LiabilityControllerInstance
        {
            get
            {
                if (_LiabilityController == null)
                    _LiabilityController = new LiabilityController(ApplicationHelper.LoggedInUser);
                return _LiabilityController;
            }
        }

        private NotificationController _NotificationController = null;
        public NotificationController NotificationControllerInstance
        {
            get
            {
                if (_NotificationController == null)
                    _NotificationController = new NotificationController(ApplicationHelper.LoggedInUser);
                return _NotificationController;
            }
        }

        private FITsController _fITsController = null;
        public FITsController FITsControllerInstance
        {
            get
            {
                if (_fITsController == null)
                    _fITsController = new FITsController(ApplicationHelper.LoggedInUser);
                return _fITsController;
            }
        }

        private SRVController _srvController = null;
        public SRVController SRVControllerInstance
        {
            get
            {
                if (_srvController == null)
                    _srvController = new SRVController(ApplicationHelper.LoggedInUser);
                return _srvController;
            }
        }

        private SupplierController _supplierController = null;
        public SupplierController SupplierControllerInstance
        {
            get
            {
                if (_supplierController == null)
                    _supplierController = new SupplierController(ApplicationHelper.LoggedInUser);
                return _supplierController;
            }
        }

        private GreigeController _greigeController = null;
        public GreigeController GreigeControllerInstance
        {
            get
            {
                if (_greigeController == null)
                    _greigeController = new GreigeController(ApplicationHelper.LoggedInUser);
                return _greigeController;
            }
        }

        private POController _POController = null;
        public POController POControllerInstance
        {
            get
            {
                if (_POController == null)
                    _POController = new POController(ApplicationHelper.LoggedInUser);
                return _POController;
            }
        }
        //private ProductionController _pdController = null;
        public ProductionController ProductionControllerInstance
        {
            get;
            set;
        }       

        private QualityController _qualityController = null;
        public QualityController QualityControllerInstance
        {
            get
            {
                if (_qualityController == null)
                    _qualityController = new QualityController(ApplicationHelper.LoggedInUser);
                return _qualityController;
            }
        }

        private OrderPlaceController _OrderPlaceController = null;
        public OrderPlaceController OrderPlaceControllerInstance
        {
            get
            {
                if (_OrderPlaceController == null)
                    _OrderPlaceController = new OrderPlaceController(ApplicationHelper.LoggedInUser);
                return _OrderPlaceController;
            }
        }             

        #endregion

    }
}
