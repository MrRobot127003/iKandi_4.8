using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
 public class FabricApproval
  {
   public int Id
   {
     get;
     set;
   }

   public int ClientID
   {
     get;
     set;
   }

   public string FabricName
   {
     get;
     set;
   }

   public int OrderID
   {
       get;
       set;
   }

   public int StyleID
   {
       get;
       set;
   }

   public string FabricDetails
   {
       get;
       set;
   }

   public string CreatedBy
   {
     get;
     set;
   }

   public string UpdatedBy
   {
     get;
     set;
   }

   public DateTime CreatedOn
   {
     get;
     set;
   }

   public DateTime UpdatedOn
   {
     get;
     set;
   }

   public List<FabricApprovalDetails> LabDipApproval
   {
     get;
     set;
   }

   public List<FabricApprovalDetails> BulkApproval
   {
     get;
     set;
   }
  }

 public class FabricApprovalDetails
 {
   public int Id
   {
     get;
     set;
   }

   public int FabricApprovalId
   {
     get;
     set;
   }

   public int Stage
   {
     get;
     set;
   }

   public DateTime SentDate
   {
     get;
     set;
   }

   public string DHLNumber
   {
     get;
     set;
   }

   public string Status
   {
     get;
     set;
   }

   public string Remarks
   {
     get;
     set;
   }

   public DateTime ActionDate
   {
     get;
     set;
   }

   public string CreatedBy
   {
     get;
     set;
   }

   public string UpdatedBy
   {
     get;
     set;
   }

   public DateTime CreatedOn
   {
     get;
     set;
   }

   public DateTime UpdatedOn
   {
     get;
     set;
   }

   public string F1LabStatus
   {
       get;
       set;
   }
   public string F2LabStatus
   {
       get;
       set;
   }
   public string F3LabStatus
   {
       get;
       set;
   }

   public string F4LabStatus
   {
       get;
       set;
   }

   public string F5BulkStatus
   {
       get;
       set;
   }
   public string F6BulkStatus
   {
       get;
       set;
   }
   public string F7BulkStatus
   {
       get;
       set;
   }

   public string F8BulkStatus
   {
       get;
       set;
   }
   public string F9BulkStatus
   {
       get;
       set;
   }
   public string F10BulkStatus
   {
       get;
       set;
   }
   //Added By Ashish on 23/2/2015
   public DateTime Fab1ActionDate
   {
       get;
       set;
   }
   public DateTime Fab2ActionDate
   {
       get;
       set;
   }
   public DateTime Fab3ActionDate
   {
       get;
       set;
   }
   public DateTime Fab4ActionDate
   {
       get;
       set;
   }
   public DateTime Fab5ActionDate
   {
       get;
       set;
   }
   public DateTime Fab6ActionDate
   {
       get;
       set;
   }
   //END
   public DateTime F1ActionDate
   {
       get;
       set;
   }

   public DateTime F2ActionDate
   {
       get;
       set;
   }

   public DateTime F3ActionDate
   {
       get;
       set;
   }

   public DateTime F4ActionDate
   {
       get;
       set;
   }

   public DateTime F5ActionDate
   {
       get;
       set;
   }

   public DateTime F6ActionDate
   {
       get;
       set;
   }

   public DateTime F7ActionDate
   {
       get;
       set;
   }

   public DateTime F8ActionDate
   {
       get;
       set;
   }
 }
 
}
