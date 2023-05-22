using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common.Entities
{
   public class CMTAdmin
    {
       public Int32 CmtId
       {
           get;
           set;
       }
       public Int32 AvlMinCost    
       {
           get;
           set;
       }
       public Int32 hrs
       {
           get;  
           set;
       }
       public Int32 barrierDays  
       {
           get;
           set;
       }
       public Int32 CreatedBy
       {
           get;
           set;
       }
       public Int32 ModifyBy  
       {
           get;
           set;
       }

       public Int32 TargetEffID
       {
           get;
           set;
       }
       public Int32 Day
       {
           get; 
           set;
       }
       public Decimal TargetDayEff
       {
           get;
           set;
       }
       public Decimal TargetDayCostingEff
       {
           get;
           set;
       }

       public Int32 AchievementlabelsID
       {
           get;
           set;
       }

       public Decimal Achievement
       {
           get;
           set;
       }
       //Added By Ashish on 25/12/2014
       public Decimal StartMin
       {
           get;
           set;
       }
       public Decimal EndMin
       {
           get;
           set;
       }
       public Int32 Barrier
       {
           get;
           set;
       }
       public Int32 BarrierId
       {
           get;
           set;
       }
        //END
       //Added By Abhishek on 2/5/2017
       public int Costing_MultiplierId
       {
           get;
           set;
       }
       public int MinExpectedQty
       {
           get;
           set;
       }
       public int MaxExpectedQty
       {
           get;
           set;
       }
       public int Muliplier
       {
           get;
           set;
       }
       public string Flag
       {
           get;
           set;
       }
        //END
    }

   public class CMTSizeAdmin
   {
       public Int32 Id
       {
           get;
           set;
       }
       public Int32 SizeOption
       {
           get;
           set;
       }

       public string Sizes
       {
           get;
           set;
       }
       public string Size1
       {
           get;
           set;
       }
       public string Size2
       {
           get;
           set;
       }
       public string Size3
       {
           get;
           set;
       }
       public string Size4
       {
           get;
           set;
       }
       public string Size5
       {
           get;
           set;
       }
       public string Size6
       {
           get;
           set;
       }
       public string Size7
       {
           get;
           set;
       }
       public string Size8
       {
           get;
           set;
       }
       public string Size9
       {
           get;
           set;
       }
       public string Size10
       {
           get;
           set;
       }
       public string Size11
       {
           get;
           set;
       }
       public string Size12
       {
           get;
           set;
       }

       public string Size13
       {
           get;
           set;
       }

       public string Size14
       {
           get;
           set;
       }

       public string Size15
       {
           get;
           set;
       }

   }
}
