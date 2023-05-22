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
using iKandi.Common;
using iKandi.BLL;

using System.Collections.Generic;
using iKandi.Common.Entities;

namespace iKandi.Web.Components
{
  public class DropdownHelper
  {
    #region Public Methods

    /// <summary>
    /// Return the list of designations
    /// </summary>
    /// <param name="DesignationList"></param>
    public static void BindDesignations(ListControl DesignationList)
    {
      Designation[] values = (Designation[])Enum.GetValues(typeof(Designation));
      IEnumerable<Designation> sorted = values.OrderBy(v => v.ToString());

      foreach (Designation des in sorted)
      {
        if (des != Designation.Partner)
          DesignationList.Items.Add(new ListItem(Constants.GetDesignationName((int)des), ((int)des).ToString()));
      }

    }



    /// <summary>
    /// Return the list of Garment Type
    /// </summary>
    /// <param name="DesignationList"></param>
    public static void BindGarmentTypes(ListControl GarmentTypeList)
    {


      FabricController controller = new FabricController();
      DataTable dt = controller.GetGarmentTypeBAL();
      for (int x = 0; x <= dt.Rows.Count - 1; x++)
      {

        GarmentTypeList.Items.Add(new ListItem(Convert.ToString(dt.Rows[x]["Garment_Name"]), Convert.ToString(dt.Rows[x]["Garment_Type"])));

      }
      //GarmentType[] values = (GarmentType[])Enum.GetValues(typeof(GarmentType));
      //IEnumerable<GarmentType> sorted = values.OrderBy(v => v.ToString());

      //foreach (GarmentType des in sorted)
      //{
      //    GarmentTypeList.Items.Add(new ListItem(Constants.GetGarmentTypeName(des), des.ToString()));
      //}
    }

    public static void BindStatusMode(ListControl StatusModeList)
    {
      foreach (StatusModes statusModes in BLLCache.StatusModes)
      {
        StatusModeList.Items.Add(new ListItem(statusModes.StatusModesName, statusModes.StatusModesID.ToString()));
      }
    }

    public static void FillDropDownClient(DropDownList ddlClient, int BuyingHouseId, bool IsAllRequired, int ClientId)
    {
      PrintController prn = new PrintController();
      ddlClient.DataSource = prn.GetAllClientForBuyingHouseBAL(Convert.ToInt32(BuyingHouseId), ClientId);
      ddlClient.DataTextField = "companyname";
      ddlClient.DataValueField = "ClientId";
      ddlClient.DataBind();
      if (IsAllRequired == false)
      {
        ddlClient.Items.RemoveAt(0);
      }

    }

    //Edit by surendra on 20 may 2013
    public static void FillUnit(DropDownList ddlUnit,int DesignationID,int UserID)
    {
      PrintController prn = new PrintController();
      ddlUnit.DataSource = prn.GetAllUnitL(DesignationID, UserID);
      ddlUnit.DataTextField = "Unit";
      ddlUnit.DataValueField = "UnitId";
      ddlUnit.DataBind();

    }

    public static void FillDropDownClient(ListBox ddlClient, int BuyingHouseId, bool IsAllRequired, int ClientId)
    {
      PrintController prn = new PrintController();
      ddlClient.DataSource = prn.GetAllClientForBuyingHouseBAL(Convert.ToInt32(BuyingHouseId), ClientId);
      ddlClient.DataTextField = "companyname";
      ddlClient.DataValueField = "ClientId";
      ddlClient.DataBind();
      if (IsAllRequired == false)
      {
        ddlClient.Items.RemoveAt(0);
      }
    }

    public static void BindUsedRegisteredFabric(ListControl RegisteredTradeName)
    {
      FabricQualityController controller = new FabricQualityController();
      DataSet ds = controller.GetRegisteredFabrics();

      foreach (DataRow row in ds.Tables[0].Rows)
      {
        string tradeName = (row["fabric"] != DBNull.Value) ? row["fabric"].ToString() : string.Empty;

        if (tradeName == string.Empty) continue;

        RegisteredTradeName.Items.Add(new ListItem(tradeName, tradeName));
      }
    }


    // Edit by surendra on 20 may 2013
    public static void BindFilteredStatusModeBySequence(ListControl StatusModeList, int UserId, bool IsStatusInvoiced)
    {
      //int startSequence;
      //int endSequence;
      //List<StatusModes> objAllowStatusModes = BLLCache.AllowStatusModesToDesignation;
      //StatusModes startEndStatusModesSequenc = objAllowStatusModes.Find(delegate(StatusModes sm) { return (sm.DesignationID == DesigmationID); });
      //startSequence = startEndStatusModesSequenc.StartSequence;
      //endSequence = startEndStatusModesSequenc.EndSequence;

      //List<StatusModes> objStatusModes = BLLCache.StatusModes.FindAll(delegate(StatusModes s) { return (s.Permission_Sequence >= startSequence && s.StatusModeSequences >= (int)StatusModeBySequence.NEWORDER && s.Permission_Sequence <= endSequence); });

      AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);
      List<StatusModes> objStatusModes = controller.GetAllStatusModesByUserId_ForSequence(UserId);

      foreach (StatusModes statusModes in objStatusModes)
      {
       // StatusModeList.Items.Add(new ListItem(statusModes.StatusModesName, statusModes.StatusModeSequences.ToString()));
        StatusModeList.Items.Add(new ListItem(statusModes.StatusModesName, statusModes.StatusMode_Double_Sequences.ToString()));

        if (IsStatusInvoiced)
        {
          statusModes.StatusModeSequences = 69;     // StatusModeSequences of Status 'InVoiced'
          StatusModeList.SelectedValue = statusModes.StatusMode_Double_Sequences.ToString();
        }
        else
        {
          if (statusModes.StatusModesID == (int)TaskMode.Approved_toEx)
          {
              StatusModeList.SelectedValue = statusModes.StatusMode_Double_Sequences.ToString();
          }
        }
      }
    }
    public static void BindFilteredStatusMode(ListControl StatusModeList, int UserId)
    {
        //int startSequence;
        //int endSequence;
        //List<StatusModes> objAllowStatusModes = BLLCache.AllowStatusModesToDesignation;
        //StatusModes startEndStatusModesSequenc = objAllowStatusModes.Find(delegate(StatusModes sm) { return (sm.DesignationID == DesigmationID); });
        //startSequence = startEndStatusModesSequenc.StartSequence;
        //endSequence = startEndStatusModesSequenc.EndSequence;

        //List<StatusModes> objStatusModes = BLLCache.StatusModes.FindAll(delegate(StatusModes s) { return (s.Permission_Sequence >= startSequence && s.StatusModeSequences >= (int)StatusModeBySequence.NEWORDER && s.Permission_Sequence <= endSequence); });

        AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);
        List<StatusModes> objStatusModes = controller.GetAllStatusModesByUserId(UserId);

        foreach (StatusModes statusModes in objStatusModes)
        {
            StatusModeList.Items.Add(new ListItem(statusModes.StatusModesName, statusModes.StatusMode_ForIntial.ToString()));
            //if (statusModes.StatusModesID == (int)TaskMode.Approved_toEx)
            //{
            //    StatusModeList.SelectedValue = "all";
            //}
        }
    }

    public static void BindCurrency(ListControl CurrencyList)
    {

      CostingController controller = new CostingController();
      DataTable dt = controller.GetCurrencyBAL();
      for (int x = 0; x <= dt.Rows.Count - 1; x++)
      {

        if (Convert.ToInt32(dt.Rows[x]["Id"]) == 4)
          CurrencyList.Items.Add(new ListItem("€", Convert.ToString(dt.Rows[x]["Id"])));
        else
          CurrencyList.Items.Add(new ListItem(Convert.ToString(dt.Rows[x]["CurrencySymbol"]), Convert.ToString(dt.Rows[x]["Id"])));

      }




      //  CurrencyList.Items.Add(new ListItem(@"£", (Convert.ToInt32(Currency.GBP)).ToString()));
      //  CurrencyList.Items.Add(new ListItem(@"Rs", (Convert.ToInt32(Currency.INR)).ToString()));
      //  CurrencyList.Items.Add(new ListItem(@"$", (Convert.ToInt32(Currency.USD)).ToString()));
      //  CurrencyList.Items.Add(new ListItem(@"€", (Convert.ToInt32(Currency.EURO)).ToString()));
      //  CurrencyList.Items.Add(new ListItem(@"kr", (Convert.ToInt32(Currency.KRO)).ToString()));
      //  CurrencyList.Items.Add(new ListItem(@"AUD", (Convert.ToInt32(Currency.AUD)).ToString()));
    }

    public static void BindFabric(ListControl FabricList)
    {
        foreach (int value in Enum.GetValues(typeof(iKandi.Common.Fabric)))
      {
          FabricList.Items.Add(new ListItem(Enum.GetName(typeof(iKandi.Common.Fabric), value), value.ToString()));
      }

    }

    public static void BindFabricType(ListControl FabricTypeList)
    {
      foreach (int value in Enum.GetValues(typeof(FabricType)))
      {
        FabricTypeList.Items.Add(new ListItem(Enum.GetName(typeof(FabricType), value), value.ToString()));
      }

    }

    /// <summary>
    /// Returns the list of group/roles
    /// </summary>
    /// <param name="GroupList"></param>
    public static void BindGroups(ListControl GroupList)
    {
      Group[] values = (Group[])Enum.GetValues(typeof(Group));
      IEnumerable<Group> sorted = values.OrderBy(v => v.ToString());

      foreach (Group grp in sorted)
      {
        GroupList.Items.Add(new ListItem(Constants.GetGroupName((int)grp), ((int)grp).ToString()));
      }
    }


    public static void BindDesignationFromDB(DropDownList GroupList, string string_TableName, string string_ColumnNames, string string_WhereColumn, string string_Operator, string string_WhereValue, bool bool_WithSeleted)
    {
      UserController controller = new UserController();
      DataTable dt = controller.BindGroupsFromDB(string_TableName, string_ColumnNames, string_WhereColumn, string_Operator, string_WhereValue, bool_WithSeleted);
      GroupList.DataSource = dt;
      GroupList.DataTextField = "Name";
      GroupList.DataValueField = "DesId";
      GroupList.DataBind();


    }
    public static void BindGroupsFromDB(DropDownList GroupList, string string_TableName, string string_ColumnNames, string string_WhereColumn, string string_Operator, string string_WhereValue, bool bool_WithSeleted)
    {
      UserController controller = new UserController();
      DataTable dt = controller.BindGroupsFromDB(string_TableName, string_ColumnNames, string_WhereColumn, string_Operator, string_WhereValue, bool_WithSeleted);
      GroupList.DataSource = dt;
      GroupList.DataTextField = "Name";
      GroupList.DataValueField = "DeptId";
      GroupList.DataBind();


    }

    public static void BindUsersByDesignation(ListControl RolesList, int DesignationID)
    {
      UserController controller = new UserController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetUsersByDesignation(DesignationID);

      foreach (User user in users)
      {
        RolesList.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.UserID.ToString()));
      }

    }

    public static void BindUsersByDesignation(ListControl GradeList)
    {
      FabricController controller = new FabricController(ApplicationHelper.LoggedInUser);

      List<GradeAdmin> grades = controller.GetAllDrGrades();

      foreach (GradeAdmin ga in grades)
      {
        GradeList.Items.Add(new ListItem(ga.Grade, ga.Grade));
      }
    }

    public static void BindUsersByDesignation(ListControl RolesList, int ManagerID, int DesignationID)
    {
      UserController controller = new UserController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetUsersByDesignation(ManagerID, DesignationID);

      foreach (User user in users)
      {
        RolesList.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.UserID.ToString()));
      }

    }
    //Gajendra Design
    public static void GetSamplingMerchandiserByDeptID(ListControl MerchandiserList, int DepartmentID, int DesignationID)
    {
      UserController controller = new UserController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetSamplingMerchandiserByDeptID(DepartmentID, DesignationID);

      foreach (User user in users)
      {
        MerchandiserList.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.UserID.ToString()));
      }

    }
    //Gajendra Design
    public static void GetClientAccMgrByClientID(ListControl AccMgrList, int DepartmentID)
    {
      ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetClientAccMgrByClientID(DepartmentID);

      foreach (User user in users)
      {
        AccMgrList.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.UserID.ToString()));
      }

    }
    public static void BindUsersByDesignationIDAndManagerID(ListControl RolesList, int ManagerID, int DesignationID)
    {
      UserController controller = new UserController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetUsersByDesignationIDAndManagerID(ManagerID, DesignationID);

      foreach (User user in users)
      {
        RolesList.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.UserID.ToString()));
      }

    }

    public static void BindUsers(ListControl UsersList)
    {
      UserController controller = new UserController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetAllUsers();

      foreach (User user in users)
      {
        UsersList.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.UserID.ToString()));
      }
    }

    public static void BindUsersEmail(ListControl UsersList)
    {
      UserController controller = new UserController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetAllUsers();

      foreach (User user in users)
      {
        UsersList.Items.Add(new ListItem(user.FirstName + " " + user.LastName + "( " + user.Email.ToString() + " )", user.Email.ToString()));
      }

    }

    public static void BindSeason(ListControl SeasonClist)
    {
      StyleController st = new StyleController();
      DataTable dt = st.GetAllSeasonBAL();
      SeasonClist.DataSource = dt;
      SeasonClist.DataTextField = "SeasonName";
      SeasonClist.DataValueField = "Id";
      SeasonClist.DataBind();
    }

    public static void BindClients(ListControl ClientList)
    {
      ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

      List<Client> clients = controller.GetAllClientsName();

      foreach (Client client in clients)
      {
        ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
      }

    }

    public static void BindClientsForFabric(ListControl ClientList)
    {
        ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

        List<Client> clients = controller.GetAllClientsNameForFabric();

        foreach (Client client in clients)
        {
            ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
        }

    }


    public static void BindClientsDesign(ListControl ClientList, int BuyingHouseID)
    {
      ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

      List<Client> clients = controller.GetAllClientsName(BuyingHouseID);

      ClientList.Items.Clear();
      foreach (Client client in clients)
      {
        ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
      }

    }

    public static void BindBuyingHouse(ListControl ClientList)
    {
      BuyingHouseController controller = new BuyingHouseController(ApplicationHelper.LoggedInUser);

      List<BuyingHouse> clients = controller.GetAllBuyingName();

      foreach (BuyingHouse client in clients)
      {
        ClientList.Items.Add(new ListItem(client.CompanyName, client.BuyingHouseID.ToString()));
      }
    }



    public static void FourPointCheckAcceptanceCriteria(ListControl ClientList)
    {
      BuyingHouseController controller = new BuyingHouseController(ApplicationHelper.LoggedInUser);

      DataTable dt = controller.GetFPCAcceptanceCriteria();

      ClientList.DataSource = dt;
      ClientList.DataTextField = "Data";
      ClientList.DataValueField = "Val";
      ClientList.DataBind();
    }


    public static void BindClientsIkandi(ListControl ClientList)
    {
      ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

      List<Client> clients = controller.GetAllClientsNameIkandi();

      foreach (Client client in clients)
      {
        ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
      }

    }

    public static void BindAllClients(ListControl ClientList)
    {
      ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

      List<Client> clients = controller.GetAllClients();

      foreach (Client client in clients)
      {
        ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
      }

    }

    public static void BindAllClientCode(ListControl ClientList)
    {
        ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

        List<Client> clients = controller.GetAll_Clients_WithCode();

        foreach (Client client in clients)
        {
            ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
        }

    }

    public static void BindDesignListAllClient(ListControl ClientList,string flag,int UserID)
    {
        ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

        List<Client> clients = controller.BindDesignListAllClient(flag, UserID);

        foreach (Client client in clients)
        {
            ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
        }

    }

      

    public static void BindAllClients(ListControl ClientList, int BuyingHouseId)
    {
      ClientList.Items.Clear();
      ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

      List<Client> clients = controller.GetAllClients(BuyingHouseId);

      foreach (Client client in clients)
      {
        ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
      }

    }
    // Add By Prabhaker  18-aug-17
  

    // end of code

    public static void BindPrints(ListControl PrintList)
    {
      PrintController controller = new PrintController(ApplicationHelper.LoggedInUser);

      List<Print> prints = controller.GetAllPrintsNo();

      foreach (Print print in prints)
      {
        PrintList.Items.Add(new ListItem(print.PrintNumber.ToString(), print.PrintID.ToString()));
      }

    }

    public static void BindZipDetails(ListControl ZipDetailList)
    {
      CostingController controller = new CostingController(ApplicationHelper.LoggedInUser);

      List<string> zipDetails = controller.GetAllZipDetails();

      foreach (string strZipDetail in zipDetails)
      {
        ZipDetailList.Items.Add(new ListItem(strZipDetail, strZipDetail));
      }
    }

    public static void BindZipSize(ListControl ZipSizeList)
    {
      for (int i = 2; i <= 36; i++)
      {
        if (i % 2 == 0)
        {
          ZipSizeList.Items.Add(new ListItem(i.ToString() + "\"", i.ToString()));
        }
      }
    }

    public static void BindFabricApprovalStatus(ListControl StatusList)
    {
      foreach (int value in Enum.GetValues(typeof(FabricApprovalStatus)))
      {
        if (value == 1)
          StatusList.Items.Add(new ListItem("SENT FOR APPROVAL", value.ToString()));
        else
          StatusList.Items.Add(new ListItem(Enum.GetName(typeof(FabricApprovalStatus), value), value.ToString()));
      }
    }

    public static void BindZipRateType(ListControl Control)
    {
      foreach (int value in Enum.GetValues(typeof(ZipRateType)))
      {
        Control.Items.Add(new ListItem(Enum.GetName(typeof(ZipRateType), value), Enum.GetName(typeof(ZipRateType), value).ToString()));
      }
    }

    public static void BindLiabilityPaymentStatus(ListControl PaymentStatusList)
    {
      foreach (int value in Enum.GetValues(typeof(PaymentStatus)))
      {
        string val = string.Empty;
        if (value == 4)
        {
          val = "Liability Waived Off";
        }
        else if (value == 3)
        {
          val = "Partially Paid";
        }
        else val = (Enum.GetName(typeof(PaymentStatus), value));

        PaymentStatusList.Items.Add(new ListItem(val, value.ToString()));
      }
    }

    public static void BindApplicationModule(ListControl ApplicationModuleList)
    {
      AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

      List<ApplicationModule> applicationModule = controller.GetAllApplicationModule();

      foreach (ApplicationModule name in applicationModule)
      {
        ApplicationModuleList.Items.Add(new ListItem(name.ApplicationModuleName, name.ApplicationModuleID.ToString()));
      }
    }

    public static void BindApplicationModuleByDepartment(ListControl ApplicationModuleList, int DepartmentID)
    {
      AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

      List<ApplicationModule> applicationModule = controller.GetAllApplicationModuleByDepartment(DepartmentID);

      foreach (ApplicationModule name in applicationModule)
      {
        ApplicationModuleList.Items.Add(new ListItem(name.ApplicationModuleName, name.ApplicationModuleID.ToString()));
      }
    }

    public static void BindApplicationModuleByDesignation(ListControl ApplicationModuleList, int DesignationID)
    {
      AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

      List<ApplicationModule> applicationModule = controller.GetAllApplicationModuleByDesignation(DesignationID);

      foreach (ApplicationModule name in applicationModule)
      {
        ApplicationModuleList.Items.Add(new ListItem(name.ApplicationModuleName, name.ApplicationModuleID.ToString()));
      }
    }

    public static void BindApplicationModuleByUser(ListControl ApplicationModuleList, int UserID)
    {
      AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

      List<ApplicationModule> applicationModule = controller.GetAllApplicationModuleByUser(UserID);

      foreach (ApplicationModule name in applicationModule)
      {
        ApplicationModuleList.Items.Add(new ListItem(name.ApplicationModuleName, name.ApplicationModuleID.ToString()));
      }
    }

    public static void BindYears(ListControl YearList)
    {
      //for (int i = 2000; i <= DateTime.Now.Year + 10; i++)
      for (int i = 2010; i <= 2014; i++)
      {
        YearList.Items.Add(i.ToString());
      }
    }

    public static void BindCurrentNextYears(ListControl YearCurrentNextList)
    {
      // DateTime year = DateTime.Today.AddYears(-10);
      for (int i = 2000; i <= DateTime.Now.Year; i++)
      {
        YearCurrentNextList.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="MonthList"></param>
    /// <author>vikas.agarwal</author>
    public static void BindMonths(ListControl MonthList)
    {
      for (int i = 1; i <= 12; i++)
      {
        DateTime time = new DateTime(DateTime.Now.Year, i, 1);
        MonthList.Items.Add(new ListItem(time.ToString("MMM"), i.ToString()));
      }
    }

    public static void BindUnitByUserId(ListControl ProductionUnitList, int UserID)
    {
      CommonController controller = new CommonController(ApplicationHelper.LoggedInUser);

      List<ProductionUnit> productionUnit = controller.GetUnitByUserId(UserID);

      foreach (ProductionUnit unit in productionUnit)
      {
        ProductionUnitList.Items.Add(new ListItem(unit.FactoryCode, unit.ProductionUnitId.ToString()));
      }
    }


    public static void BindUnitReports(ListControl ProductionUnitList)
    {
      CommonController controller = new CommonController(ApplicationHelper.LoggedInUser);

      List<ProductionUnit> productionUnit = controller.GetUnitReports();

      foreach (ProductionUnit unit in productionUnit)
      {
        ProductionUnitList.Items.Add(new ListItem(unit.FactoryCode, unit.ProductionUnitId.ToString()));
      }
    }



      //Add By Prabhaker 2-july-18

  
    public static void BindCategories_New(ListControl CategoryList, int Type)
    {
        AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

        IList<Category> categories = controller.GetAllCategoriesType_New(Type);

        foreach (Category category in categories)
        {
            CategoryList.Items.Add(new ListItem(category.CategoryName, category.CategoryID.ToString()));
        }

    }

    public static void BindParentCategories_New(ListControl CategoryList, int Type)
    {
        AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

        // prepares the search critiera for searching the categories
        Category searchCriteria = new Category();
        searchCriteria.Type = Type;
        searchCriteria.Parent = new Category() { CategoryID = -2 };
        
        // retreives the categories according to the search criteria
        IList<Category> categories = controller.GetAllCategories_New(searchCriteria);

        foreach (Category category in categories)
        {
            CategoryList.Items.Add(new ListItem(category.CategoryName, category.CategoryID.ToString()));
        }

    }
      //End Of Code


    public static void BindCategories(ListControl CategoryList, int Type)
    {
      AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

      IList<Category> categories = controller.GetAllCategories(Type);

      foreach (Category category in categories)
      {
        CategoryList.Items.Add(new ListItem(category.CategoryName, category.CategoryID.ToString()));
      }

    }

    public static void BindParentCategories(ListControl CategoryList, int Type)
    {
      AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

      // prepares the search critiera for searching the categories
      Category searchCriteria = new Category();
      searchCriteria.Type = Type;
      searchCriteria.Parent = new Category() { CategoryID = -2 };
      int TotalRowCount = 0;
      // retreives the categories according to the search criteria
      IList<Category> categories = controller.GetAllCategories(0, 0, out TotalRowCount, searchCriteria);

      foreach (Category category in categories)
      {
        CategoryList.Items.Add(new ListItem(category.CategoryName, category.CategoryID.ToString()));
      }

    }

    public static void BindSubCategories(ListControl CategoryList, int CatID)
    {
        AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);

        IList<Category> Subcategories = controller.GetSubCategories(CatID);

        foreach (Category Subcategory in Subcategories)
        {
            CategoryList.Items.Add(new ListItem(Subcategory.CategoryName, Subcategory.CategoryID.ToString()));
        }

    }

    /// <summary>
    /// Binds category types to the given list control e.g. DropDownList.
    /// </summary>
    /// <param name="CategoryTypeList">The ListControl to be binded.</param>
    public static void BindCategoryTypes(ListControl CategoryTypeList)
    {
      foreach (int value in Enum.GetValues(typeof(CategoryType)))
      {
        CategoryTypeList.Items.Add(new ListItem(Enum.GetName(typeof(CategoryType), value), value.ToString()));
      }

    }


    public static void BindCategoryTypesNew(ListControl CategoryTypeListNew)
    {
        foreach (int value in Enum.GetValues(typeof(CategoryTypeNew)))
        {
            CategoryTypeListNew.Items.Add(new ListItem(Enum.GetName(typeof(CategoryTypeNew), value), value.ToString()));
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="RolesList"></param>
    /// <param name="DesignationID"></param>
    public static void BindLeaveManagers(ListControl managersList, int departmentId, int topManagementId)
    {
      LeaveController controller = new LeaveController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetManagers(departmentId, topManagementId);

      foreach (User user in users)
      {
        if (ApplicationHelper.LoggedInUser.UserData.UserID != user.UserID)
          managersList.Items.Add(new ListItem(user.FirstName + " " + user.LastName, user.UserID.ToString()));
      }
    }

    public static void BindLeaveTypes(ListControl LeaveTypes, bool FilteredByLoggedInUser)
    {
      LeaveController controller = new LeaveController(ApplicationHelper.LoggedInUser);

      List<LeaveType> leaveTypes = controller.GetAllLeaveTypes();

      foreach (LeaveType leaveType in leaveTypes)
      {
        if (FilteredByLoggedInUser)
        {
          if (leaveType.CompanyType == (Company)ApplicationHelper.LoggedInUser.UserData.CompanyID)
            LeaveTypes.Items.Add(new ListItem(leaveType.Name, leaveType.LeaveTypeID.ToString()));
        }
        else
        {
          LeaveTypes.Items.Add(new ListItem(leaveType.Name, leaveType.LeaveTypeID.ToString()));
        }
      }

    }

    public static void BindSamplingStatusUser(ListControl SamplingUser, int Designation)
    {
      UserController controller = new UserController(ApplicationHelper.LoggedInUser);

      List<User> users = controller.GetUsersByDesignation(Designation);

      foreach (User user in users)
      {
        SamplingUser.Items.Add(new ListItem(user.FullName, user.UserID.ToString()));
      }
    }


    //public static void BindQualityFaultCategories(ListControl CategoryList)
    //{
    //    QualityController qController = new QualityController(ApplicationHelper.LoggedInUser);
    //    List<QualityFaultsCategory> categories = qController.GetQualityFaultCategories();

    //    foreach (QualityFaultsCategory qfc in categories)
    //    {
    //        CategoryList.Items.Add(new ListItem(qfc.FaultCategoryType, qfc.Id.ToString()));
    //    }
    //}

    //public static void BindQualityFaultSubCategories(ListControl SubCategoryList)
    //{
    //    QualityController qController = new QualityController(ApplicationHelper.LoggedInUser);
    //    List<QualityFaultsSubCategory> subCategories = qController.GetQualityFaultSubCategories();

    //    foreach (QualityFaultsSubCategory qfsc in subCategories)
    //    {
    //        SubCategoryList.Items.Add(new ListItem(qfsc.FaultSubCategoryType, qfsc.Id.ToString()));
    //    }
    //}

    public static void BindAllUnits(ListControl ProductionUnitList)
    {
      CommonController controller = new CommonController(ApplicationHelper.LoggedInUser);

      List<ProductionUnit> productionUnit = controller.GetAllUnits();

      foreach (ProductionUnit unit in productionUnit)
      {
        ProductionUnitList.Items.Add(new ListItem(unit.FactoryCode, unit.ProductionUnitId.ToString()));
      }
    }


    //public static void BindAllTypeOfPacking(ListControl TypeOfPackingList)
    //{
    //    foreach (int value in Enum.GetValues(typeof(iKandi.Common.TypeofPacking)))
    //    {
    //        TypeOfPackingList.Items.Add(new ListItem(Enum.GetName(typeof(iKandi.Common.TypeofPacking), value).Replace("_", " "), value.ToString()));
    //    }

    //}

    public static void BindAllOrderTypeOfPacking(ListControl TypeOfPackingList)
    {
      AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);
      List<TypeOfPacking> typeOfPacking = controller.GetAllOrderTypeOFPacking();

      foreach (TypeOfPacking top in typeOfPacking)
      {
        TypeOfPackingList.Items.Add(new ListItem(top.Name, top.Id.ToString()));
      }

    }


    public static void BindAllPrintTypes(ListControl PrintTypeList)
    {
      CommonController controller = new CommonController(ApplicationHelper.LoggedInUser);

      List<Print> printTypes = controller.GetAllPrintTypes();

      foreach (Print pType in printTypes)
      {
        PrintTypeList.Items.Add(new ListItem(pType.PrintType, pType.PrintTypeID.ToString()));
      }
    }

    public static void BindStatusModeForIkandiInvoiceList(ListControl StatusModeList)
    {
      //List<StatusModes> objStatusMode = BLLCache.StatusModes;
      //List<StatusModes> filteredStatusModes = objStatusMode.FindAll(delegate(StatusModes sm) { return (sm.StatusModesID >= 18 && sm.StatusModesID <= 23); });
      //filteredStatusModes.Sort(delegate(StatusModes t1, StatusModes t2)
      //{ return (t1.StatusModesID.CompareTo(t2.StatusModesID)); });
      //filteredStatusModes.Reverse();
       AdminController controller = new AdminController(ApplicationHelper.LoggedInUser);
       List<StatusModes> StatusModeForIkandiInvoice = controller.Get_StatusModeForIkandiInvoice();
      foreach (StatusModes statusModes in StatusModeForIkandiInvoice)
      {
        StatusModeList.Items.Add(new ListItem(statusModes.StatusModesName, statusModes.StatusModesID.ToString()));
      }
    }

    public static void FillDropDownDepartment(DropDownList ddlDepartment, int intID, int UserID, bool IsAllRequired, bool IsClient, bool IsClientDept)
    {
      PrintController prn = new PrintController();
      ddlDepartment.DataSource = prn.GetAllDeptByClientDAL(intID, UserID, IsClient, IsClientDept);
      ddlDepartment.DataTextField = "DepartmentName";
      ddlDepartment.DataValueField = "UserID";
      ddlDepartment.DataBind();
      if (IsAllRequired == false)
      {
        ddlDepartment.Items.RemoveAt(0);
      }
    }
    //Added By Ashish on 14/4/2015
    public static void FillDropDownClientDetails(DropDownList ddlClient, int BuyingHouseId, bool IsAllRequired, int ClientId, int DateType, string YearRange, int UserId,int AM)
    {
      PrintController prn = new PrintController();
      ddlClient.DataSource = prn.GetAllDeptByClientForManageOrder(Convert.ToInt32(BuyingHouseId), ClientId, DateType, YearRange, UserId,AM);
      ddlClient.DataTextField = "companyname";
      ddlClient.DataValueField = "ClientId";
      ddlClient.DataBind();
      if (IsAllRequired == false)
      {
        ddlClient.Items.RemoveAt(0);
      }

    }
    public static void FillDropDownDepartmentById(DropDownList ddlDepartment, int intID, int UserID, bool IsAllRequired, bool IsClient, bool IsClientDept, int DateType, string YearRange,int AM,int ParentDeptID)
    {
      PrintController prn = new PrintController();
      ddlDepartment.DataSource = prn.GetAllDeptByClientId(intID, UserID, IsClient, IsClientDept, DateType, YearRange, AM, ParentDeptID);
      ddlDepartment.DataTextField = "DepartmentName";
      ddlDepartment.DataValueField = "UserID";
      ddlDepartment.DataBind();
      if (IsAllRequired == false)
      {
        ddlDepartment.Items.RemoveAt(0);
      }
    }
    public static void FillParentDepartmentID(DropDownList ddlParentDeptID, int intID, int UserID, bool IsAllRequired, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM)
    {
        PrintController prn = new PrintController();
        ddlParentDeptID.DataSource = prn.GetParentDeptID(intID, UserID, IsClient, IsClientDept, DateType, YearRange, AM);
        ddlParentDeptID.DataTextField = "DepartmentName";
        ddlParentDeptID.DataValueField = "UserID";
        ddlParentDeptID.DataBind();
        if (IsAllRequired == false)
        {
            ddlParentDeptID.Items.RemoveAt(0);
        }
    }
    //Added By Ashish on 17/4/2015
    public static void BindClientsForIkandi(ListControl ClientList, int BuyingHouseId, int ClientId, int DateType, string YearRange, int UserId)
    {
      ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);

      List<Client> clients = controller.GetAllClientsNameForIkandi(Convert.ToInt32(BuyingHouseId), ClientId, DateType, YearRange, UserId);

      foreach (Client client in clients)
      {
        ClientList.Items.Add(new ListItem(client.CompanyName, client.ClientID.ToString()));
      }

    }
    //END
    #endregion
      //abhishek 
    public static void FillDropDownCAD(DropDownList ddlDepartment)
    {
        AdminController objadmin = new AdminController();
        ddlDepartment.DataSource = objadmin.GetCADMAster();
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataValueField = "ID";
        ddlDepartment.DataBind();
        //if (IsAllRequired == false)
        //{
        //    ddlDepartment.Items.RemoveAt(0);
        //}
    }
    public static void GetMasterName(DropDownList ddlDepartment)
    {
        AdminController objadmin = new AdminController();
        ddlDepartment.DataSource = objadmin.GetMasterName();
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataValueField = "ID";
        ddlDepartment.DataBind();
        //if (IsAllRequired == false)
        //{
        //    ddlDepartment.Items.RemoveAt(0);
        //}
    }
  }
    


}


