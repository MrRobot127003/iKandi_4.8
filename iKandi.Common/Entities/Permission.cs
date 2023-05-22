using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
   public class Permission
    {
       public Int32 PermissionId
       {
           get;
           set;
       }

       public Int32 UserID
       {
           get;
           set;
       }

       public Int32 DesignationID
       {
           get;
           set;
       }

       public Boolean Read
       {
           get;
           set;
       }

       public Boolean Write
       {
           get;
           set;
       }

       public Int32 ApplicationModuleID
       {
           get;
           set;
       }

       public Int32 ApplicationModuleColumnID
       {
           get;
           set;
       }

       public Int32 DepartmentID
       {
           get;
           set;
       }

       public String ApplicationModuleName
       {
           get;
           set;
       }

       public String ApplicationModuleColumnName
       {
           get;
           set;
       }

       public String PhaseName
       {
           get;
           set;
       }

       public String SubPhaseName
       {
           get;
           set;
       }

       public PageType PageType
       {
           get;
           set;
       }
       public static string BasicSection
       {
           get;
           set;
       }
       public static string StyleSection
       {
           get;
           set;
       }
       public static string QtySection
       {
           get;
           set;
       }

       public static string FabricSection
       {
           get;
           set;
       }
       public static string AccessoriesSection
       {
           get;
           set;
       }
       public static string FitsSection
       {
           get;
           set;
       }
       public static string PCDSection
       {
           get;
           set;
       }
       public static string ProductionSection
       {
           get;
           set;
       }
       public static string DeliverySection
       {
           get;
           set;
       }


       //Added by uday
       public int PermissionType
       {
           get;
           set;
       }

       // Ended by uday


    }
}
