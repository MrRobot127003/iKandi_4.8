using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Web.Components;
using System.IO;

namespace iKandi.Web
{
    public class BaseUserControl : UserControl
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

        private CuttingController _cuttingController = null;
        public CuttingController CuttingControllerInstance
        {
            get
            {
                if (_cuttingController == null)
                    _cuttingController = new CuttingController(ApplicationHelper.LoggedInUser);
                return _cuttingController;
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

        private FinancialController _financialController = null;
        public FinancialController FinancialControllerInstance
        {
            get
            {
                if (_financialController == null)
                    _financialController = new FinancialController(ApplicationHelper.LoggedInUser);
                return _financialController;
            }
        }

        private WashingCuttingController _washingCuttingController = null;
        public WashingCuttingController WashingCuttingControllerInstance
        {
            get
            {
                if (_washingCuttingController == null)
                    _washingCuttingController = new WashingCuttingController(ApplicationHelper.LoggedInUser);
                return _washingCuttingController;
            }
        }

        private AccessoryWorkingController _fabricAccessoryWorkingController = null;
        public AccessoryWorkingController AccessoryWorkingControllerInstance
        {
            get
            {
                if (_fabricAccessoryWorkingController == null)
                    _fabricAccessoryWorkingController = new AccessoryWorkingController(ApplicationHelper.LoggedInUser);

                return _fabricAccessoryWorkingController;
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

        private NotificationController _notificationController = null;
        public NotificationController NotificationControllerInstance
        {
            get
            {
                if (_notificationController == null)
                    _notificationController = new NotificationController(ApplicationHelper.LoggedInUser);
                return _notificationController;
            }
        }

        private FabricApprovalController _fabricApprovalController = null;
        public FabricApprovalController FabricApprovalControllerInstance
        {
            get
            {
                if (_fabricApprovalController == null)
                    _fabricApprovalController = new FabricApprovalController(ApplicationHelper.LoggedInUser);
                return _fabricApprovalController;
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

        private GarmentTestingController _garmentTestingController = null;
        public GarmentTestingController GarmentTestingControllerInstance
        {
            get
            {
                if (_garmentTestingController == null)
                    _garmentTestingController = new GarmentTestingController(ApplicationHelper.LoggedInUser);
                return _garmentTestingController;
            }
        }

        private SealerPendingController _sealerPendingController = null;
        public SealerPendingController SealerPendingControllerInstance
        {
            get
            {
                if (_sealerPendingController == null)
                    _sealerPendingController = new SealerPendingController(ApplicationHelper.LoggedInUser);
                return _sealerPendingController;
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

        private LiabilityController _liabilityController = null;
        public LiabilityController LiabilityControllerInstance
        {
            get
            {
                if (_liabilityController == null)
                    _liabilityController = new LiabilityController(ApplicationHelper.LoggedInUser);
                return _liabilityController;
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


        private PartnerController _partnerController = null;
        public PartnerController PartnerControllerInstance
        {
            get
            {
                if (_partnerController == null)
                    _partnerController = new PartnerController(ApplicationHelper.LoggedInUser);
                return _partnerController;
            }
        }

        private DesignerTargetAllocationController _designerTargetAllocationController = null;
        public DesignerTargetAllocationController DesignerTargetAllocationControllerInstance
        {
            get
            {
                if (_designerTargetAllocationController == null)
                    _designerTargetAllocationController = new DesignerTargetAllocationController(ApplicationHelper.LoggedInUser);
                return _designerTargetAllocationController;
            }
        }

        private InvoiceController _invoiceController = null;
        public InvoiceController InvoiceControllerInstance
        {
            get
            {
                if (_invoiceController == null)
                    _invoiceController = new InvoiceController(ApplicationHelper.LoggedInUser);
                return _invoiceController;
            }
        }

        private INDBlockController _iNDBlockController = null;
        public INDBlockController INDBlockControllerInstance
        {
            get
            {
                if (_iNDBlockController == null)
                    _iNDBlockController = new INDBlockController(ApplicationHelper.LoggedInUser);
                return _iNDBlockController;
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

        private LeaveController _leaveController = null;
        public LeaveController LeaveControllerInstance
        {
            get
            {
                if (_leaveController == null)
                    _leaveController = new LeaveController(ApplicationHelper.LoggedInUser);
                return _leaveController;
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

        private LabTestController _labTestController = null;
        public LabTestController LabTestControllerInstance
        {
            get
            {
                if (_labTestController == null)
                    _labTestController = new LabTestController(ApplicationHelper.LoggedInUser);
                return _labTestController;
            }
        }

        private BuyingHouseController _BuyingHouseController = null;
        public BuyingHouseController BuyingHouseController
        {
            get
            {
                if (_BuyingHouseController == null)
                    _BuyingHouseController = new BuyingHouseController(ApplicationHelper.LoggedInUser);
                return _BuyingHouseController;
            }
        }

        private POController _poController = null;
        public POController POControllerInstance
        {
            get
            {
                if (_poController == null)
                    _poController = new POController(ApplicationHelper.LoggedInUser);
                return _poController;
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


        private TaskContoller _TaskContoller = null;
        public TaskContoller TaskContollerInstance
        {
            get
            {
                if (_TaskContoller == null)
                    _TaskContoller = new TaskContoller(ApplicationHelper.LoggedInUser);
                return _TaskContoller;
            }
        }


        private GreigeController _GreigeController = null;
        public GreigeController GreigeControllerInstance
        {
            get
            {
                if (_GreigeController == null)
                    _GreigeController = new GreigeController(ApplicationHelper.LoggedInUser);
                return _GreigeController;
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

        #endregion

        #region Public Methods

        public void RenderFile(string FilePath, string FilName, string ContentType)
        {
            // Set up the Response object...
            this.Response.BufferOutput = false;
            this.Response.Charset = string.Empty;
            this.Response.Clear();
            this.Response.ClearContent();
            this.Response.ClearHeaders();
            this.Response.ContentType = ContentType;
            this.Response.AppendHeader("content-disposition", "attachment; filename=" + FilName);

            this.Response.WriteFile(FilePath);

            // Close the Response stream...
            //this.Response.Flush();
            //this.Response.Close();
            //this.Response.End();

            // Delete this file
            try
            {
                File.Delete(FilePath);
            }
            catch (Exception ex)
            { //TODO: Log it 
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected string DoubleToTextWithComma(double d)
        {
            if (d == 0)
                return "0";
            return d > Math.Floor(d)
                       ? d.ToString("N", new CultureInfo("en-US"))
                       : string.Format("{0:##,####}", d);
        }

        protected string DoubleToStringWithComma(double d)
        {
            if (d == 0)
                return "";
            return d > Math.Floor(d)
                       ? d.ToString("N", new CultureInfo("en-US"))
                       : string.Format("{0:##,####}", d);
        }

        protected string DoubleToText(double d)
        {
            return d == 0 ? "0" : string.Format(d > Math.Floor(d) ? "{0:0.00}" : "{0}", d);
        }

        protected string DoubleToString(double d)
        {
            return d == 0 ? "" : string.Format(d > Math.Floor(d) ? "{0:0.00}" : "{0}", d);
        }

        protected string DoubleObjectToString(object obj)
        {
            if (obj is double)
            {
                double d = Convert.ToDouble(obj);
                return d == 0 ? "" : string.Format(d > Math.Floor(d) ? "{0:0.00}" : "{0}", d);
            }
            return "";
        }

        protected string DoubleObjectToDateText(object obj)
        {
            if (Convert.ToDateTime(obj) == DateTime.MinValue)
                return "";
            return Convert.ToDateTime(obj).ToString("dd MMM yy (ddd)");
        }

        protected string DoubleObjectToStringWithComma(object obj)
        {
            if (Convert.ToString(obj) != "")
            {
                double d = Convert.ToDouble(obj);
                return d == 0 ? "" : d > Math.Floor(d)
                       ? d.ToString("N", new CultureInfo("en-US"))
                       : string.Format("{0:##,####}", d);
            }
            return "";
        }

        public string FixUp(string s)
        { 
            if (s.Length <= 21)  
                return s; if (s[20] != ' ')  
                    return s.Insert(21, "-<br />");
            return s.Insert(21, "<br />");
        } 

        protected int GetInt32(TextBox textBox)
        {
            return GetInt32(textBox.Text);
        }

        protected int GetInt32(string str)
        {
            int val;
            if (Int32.TryParse(str.Trim(), out val))
                return val;
            return 0;
        }

        protected double GetDouble(TextBox textBox)
        {
            return GetInt32(textBox.Text);
        }

        protected double GetDouble(string str)
        {
            double d;
            if (Double.TryParse(str.Trim(), out d))
                return d;
            return 0;
        }

        protected string GetFirstSmall(string str)
        {
            if (str != null)
            {
                if (string.IsNullOrEmpty(str.Trim()))
                    return "";
                return str.Substring(0, 1).ToLower();
            }
            else
                return "";
        }
        #endregion

        public int TaskId
        {
            get
            {
                if (Request.QueryString["TaskId"] == null)
                    return -1;
                return Convert.ToInt32(Request.QueryString["TaskId"]);
            }
        }

        public bool IsSubmit
        {
            get
            {
                return Convert.ToBoolean(ViewState["IsSubmit"]);
            }
            set
            {
                ViewState["IsSubmit"] = value;
            }
        }
    }
}
