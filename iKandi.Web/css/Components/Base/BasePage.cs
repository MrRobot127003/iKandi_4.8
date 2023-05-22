using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using iKandi.Web.Components.Helper;
using System.IO;


namespace iKandi.Web
{
    public class BasePage : System.Web.UI.Page
    {

        #region Constants

        private const string SIMPLE_MASTER_PAGE_PATH = "/layout/SimpleSecure.Master";

        #endregion

        #region Properties

        private bool ChangeMasterPageForScreenShot
        {
            get
            {
                bool cmpfss = false;

                if (null != Request["cmpfss"])
                    cmpfss = Convert.ToBoolean(Request["cmpfss"]);

                return cmpfss;
            }
        }

        #endregion

        public BasePage()
        {
            this.PreInit += new EventHandler(BasePage_PreInit);
            this.Init += new EventHandler(BasePage_Init);
            this.PreRender += new EventHandler(BasePage_PreRender);
        }
        protected override void OnLoad(EventArgs e)
        {
            //Handling autocomplete issue generically
            if (this.Form != null)
            {
                this.Form.Attributes.Add("autocomplete", "off");
            }

            base.OnLoad(e);
        }
        void BasePage_PreInit(object sender, EventArgs e)
        {
            if (ChangeMasterPageForScreenShot)
            {
                this.MasterPageFile = SIMPLE_MASTER_PAGE_PATH;
            }
        }

        void BasePage_Init(object sender, EventArgs e)
        {

            if (Request.Path.ToLower().IndexOf("/internal/") > -1 || Request.Path.ToLower().IndexOf("/admin/") > -1)
            {
                if (ApplicationHelper.LoggedInUser == null)
                    Response.Redirect("~/internal/Logout.aspx");

                ApplicationModule appModule = null;

                if (Request.Path.IndexOf("TabCostingSheet.aspx") > -1)
                    appModule = ApplicationHelper.GetApplicationModuleByID((int)AppModule.COSTING_FORM);
                else
                    appModule = ApplicationHelper.GetApplicationModuleIDByURL(Request.Path);

                // TODO
                if ((ApplicationHelper.LoggedInUser.PartnerData != null && (Request.Path.ToLower().Contains("orderprocessing.aspx") || Request.Path.ToLower().Contains("orderforwarder.aspx")))
                    || (ApplicationHelper.LoggedInUser.ClientData != null && (Request.Path.ToLower().Contains("clientdepartmentorder.aspx") || Request.Path.ToLower().Contains("clienthomepage.aspx"))))
                    return;

                if (appModule == null) return;

                //if (!PermissionHelper.IsReadPermitted(appModule.ApplicationModuleID))
                //{
                //    string script = "ShowHideMessageBox(true,  'You do not have permission to access " + appModule.ApplicationModuleName + " !', 'Insufficient Privilege', RedirectToUrl, '/internal/default.aspx');";
                //    Response.Redirect("~/internal/default.aspx?errorMessage=" + "You do not have permission to access " + appModule.ApplicationModuleName + " !");
                //    Response.End();
                //}

                // Eddited By Ashish on 8/10/2014 for Set Permission, i am un-comment this code for set Permission
                if (PermissionHelper.IsReadPermitted(appModule.ApplicationModuleID) && !PermissionHelper.IsWritePermitted(appModule.ApplicationModuleID) && !PermissionHelper.IsWritePermittedOnAnyColumn(appModule.ApplicationModuleID))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "DisableAllFields('main_content');", true);
                }
                //END
            }
            if (ApplicationHelper.LoggedInUser != null)
            {
                this.MembershipControllerInstance.InsertPageHistory(ApplicationHelper.LoggedInUser.UserData.UserID,
                                                                    Request.Path);
            }
        }

        protected void BasePage_PreRender(object sender, EventArgs e)
        {
            iKandi.Web.Components.PageHelper.RegisterJScriptVariables(this);
        }

        //protected override void OnError(EventArgs e)
        //{
        //    base.OnError(e);

        //    string redirectUrl = (null == Request.UrlReferror) ? "/" : Request.UrlReferror.AbsolutePath;
        //    string errorMessage = (null == Server.GetLastError().InnerException) ? Server.GetLastError().Message : Server.GetLastError().InnerException.Message;

        //    Server.ClearError();

        //    Response.Redirect(redirectUrl + "?errorMessage=" + errorMessage);
        //}

        #region View State Compression

        //protected override PageStatePersister PageStatePersister
        //{
        //    get
        //    {
        //        // Store view state in session
        //        return new SessionPageStatePersister(this);
        //    }
        //}

        //protected override object LoadPageStateFromPersistenceMedium()
        //{            
        //    string viewState = Request.Form["__VSTATE"]; 
        //    byte[] bytes = Convert.FromBase64String(viewState);
        //    bytes = Compressor.Decompress(bytes);
        //    LosFormatter formatter = new LosFormatter();
        //    return formatter.Deserialize(Convert.ToBase64String(bytes));
        //}

        //protected override void SavePageStateToPersistenceMedium(object viewState)
        //{
        //    LosFormatter formatter = new LosFormatter();
        //    StringWriter writer = new StringWriter();
        //    formatter.Serialize(writer, viewState);
        //    string viewStateString = writer.ToString();
        //    byte[] bytes = Convert.FromBase64String(viewStateString);
        //    bytes = Compressor.Compress(bytes);
        //    ClientScript.RegisterHiddenField("__VSTATE", Convert.ToBase64String(bytes));
        //}

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
            this.Response.Flush();
            this.Response.Close();
            this.Response.End();

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


        #endregion


        #endregion

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

        private LiabilityController _liabilityQualityController = null;
        public LiabilityController LiabilityControllerInstance
        {
            get
            {
                if (_liabilityQualityController == null)
                    _liabilityQualityController = new LiabilityController(ApplicationHelper.LoggedInUser);
                return _liabilityQualityController;
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

        #endregion
    }
}
