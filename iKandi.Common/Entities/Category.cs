using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    [Serializable]
    public class Category
    {
        public int CategoryID
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }       

        public decimal GriegeGST
        {
            get;
            set;
        }

        public decimal ProcessGST
        {
            get;
            set;
        }

        public decimal GST
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }
        public int fab_Griegday
        {
            get;
            set;
        }
        public int fab_Griegday_drange
        {
            get;
            set;
        }
        public int fab_DyedDay
        {
            get;
            set;
        }
        public int fab_DyedDay_drange
        {
            get;
            set;
        }
        public int Process_drange
        {
            get;
            set;
        }

        public int Process_day
        {
            get;
            set;
        }


        public int fab_PrintDay
        {
            get;
            set;
        }
        public int fab_PrintDay_drange
        {
            get;
            set;
        }
        public int fab_FinishDay
        {
            get;
            set;
        }
        public int fab_FinishDay_drange
        {
            get;
            set;
        }
        public int fab_RFDDay_stage1
        {
            get;
            set;
        }
        public int fab_RFD_stage1drange  
        {
            get;
            set;
        }

        public int fab_RFD_stage2
        {
            get;
            set;
        }

        public int fab_RFD_stage2drange
        {
            get;
            set;
        }

        public int fab_EmbroderyDay
        {
            get;
            set;
        }

        public int fab_EmbroderyDay_drange
        {
            get;
            set;
        }
        public int Fab_Embellishment_drange
        {
            get;
            set;
        }

        public int Fab_EmbellishmentDay
        {
            get;
            set;
        }


        public string CategoryCode
        {
            get;
            set;
        }

        public Category Parent
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }
        public float wastage
        {
            get;
            set;
        }
        public string wastage_
        {
            get;
            set;
        }
        public DateTime CreatedOn
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime ModifiedOn
        {
            get;
            set;
        }
        public int Weeks
        {
            get;
            set;
        }


        public bool GreigeToFinished
        {
            get;
            set;
        }

        public bool finished
        {
            get;
            set;
        }
        public float DyedRate
        {
            get;
            set;
        }

        public float PrintRate
        {
            get;
            set;
        }

        public float DigitalRate
        {
            get;
            set;
        }
        public string unit
        {
            get;
            set;
        }
        public int LoggedInUser
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
        public string FieldName
        {
            get;
            set;
        }
        public bool IsGroupHistoryCreated
        {
            get;
            set;
        }
        public bool IsGroupName_Change
        {
            get;
            set;
        }
        public string GroupName_OldValue
        {
            get;
            set;
        }
        public string GroupName_NewValue
        {
            get;
            set;
        }
        public bool IsWastage_Change
        {
            get;
            set;
        }
        public string Wastage_OldValue
        {
            get;
            set;
        }
        public string Wastage_NewValue
        {
            get;
            set;
        }
        public string Category_History
        {
            get;
            set;
        }
        public bool Is_CANDC
        {
            get;
            set;
        }
        // Start add new Property for HNSCode (06022023 Rajeevs) 
        public string HSNCode
        {
            get;
            set;
        }
        //end
    }
}
