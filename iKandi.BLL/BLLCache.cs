using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using iKandi.Common;

namespace iKandi.BLL
{
    public class BLLCache
    {
        #region Public Properties
        public static string debugMode = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["IsDebugMode"]);
        public static DataTable SystemConfigurationData
        {
            get
            {

                if (HttpRuntime.Cache["SYSTEM_CONFIGURATION_DATA"] == null || debugMode=="YES")
                {
                    iKandi.BLL.Configuration.Configuration controller = new iKandi.BLL.Configuration.Configuration();
                    HttpRuntime.Cache.Insert("SYSTEM_CONFIGURATION_DATA", controller.GetAllKeyValues(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["SYSTEM_CONFIGURATION_DATA"] as DataTable);
            }
        }

        public static DataTable ClientCostingDefaults
        {
            get
            {
               
                if (HttpRuntime.Cache["CLIENT_COSTING_DEFAULTS"] == null || debugMode=="YES")
                {
                    iKandi.BLL.AdminController controller = new iKandi.BLL.AdminController();


                DataSet ds = controller.GetClientCostingDefaults();

                  HttpRuntime.Cache.Insert("CLIENT_COSTING_DEFAULTS", ds.Tables[0], null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["CLIENT_COSTING_DEFAULTS"] as DataTable);
            }
        }

        public static List<DeliveryMode> DeliverModes
        {
            get
            {
                if (HttpRuntime.Cache["DELIVERY_MODES"] == null || debugMode == "YES")
                {
                    iKandi.BLL.AdminController controller = new iKandi.BLL.AdminController();
                    HttpRuntime.Cache.Insert("DELIVERY_MODES", controller.GetAllDeliveryModes(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["DELIVERY_MODES"] as List<DeliveryMode>);
            }
        }

        public static List<CurrencyConversion> CurrencyConversion
        {
            get
            {
                if (HttpRuntime.Cache["CURRENCY_CONVERSION"] == null || debugMode == "YES")
                {
                    iKandi.BLL.AdminController controller = new iKandi.BLL.AdminController();
                    HttpRuntime.Cache.Insert("CURRENCY_CONVERSION", controller.GetAllConversionRate(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["CURRENCY_CONVERSION"] as List<CurrencyConversion>);
            }
        }

        public static List<StatusModes> AllowStatusModesToDesignation
        {
            get
            {
                if (HttpRuntime.Cache["AllowStatusModesToDesignation"] == null || debugMode == "YES")
                {
                    AdminController controller = new AdminController();
                    HttpRuntime.Cache.Insert("AllowStatusModesToDesignation", controller.GetAllowStatusModesToDesignation(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["AllowStatusModesToDesignation"] as List<StatusModes>);
            }
        }

        public static List<StatusModes> StatusModes
        {
            get
            {
                if (HttpRuntime.Cache["StatusModes"] == null || debugMode == "YES")
                {
                    AdminController controller = new AdminController();
                    HttpRuntime.Cache.Insert("StatusModes", controller.GetAllStatusModes(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["StatusModes"] as List<StatusModes>);
            }
        }

        #endregion

        #region Public Method


        public static string GetConfigurationKeyValue(string Key)
        {
            DataRow[] rows = BLLCache.SystemConfigurationData.Select("name='" + Key.ToUpper() + "'");

            if (rows.Length > 0)
                return rows[0]["value"].ToString();

            return string.Empty;
        }

        public static void ClearSystemConfigurationCache()
        {
            if (HttpRuntime.Cache["SYSTEM_CONFIGURATION_DATA"] != null)
                HttpRuntime.Cache.Remove("SYSTEM_CONFIGURATION_DATA");
        }

        public static void ClearDeliverModesCache()
        {
            if (HttpRuntime.Cache["DELIVERY_MODES"] != null)
                HttpRuntime.Cache.Remove("DELIVERY_MODES");
        }

        public static void ClearClientCostingDefaultsCache()
        {
            if (HttpRuntime.Cache["CLIENT_COSTING_DEFAULTS"] != null)
                HttpRuntime.Cache.Remove("CLIENT_COSTING_DEFAULTS");
        }

        public static void ClearCurrencyConversionCache()
        {
            if (HttpRuntime.Cache["CURRENCY_CONVERSION"] != null)
                HttpRuntime.Cache.Remove("CURRENCY_CONVERSION");
        }

        #endregion
    }
}
