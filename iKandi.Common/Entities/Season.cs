using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
 public class Season
 {
     public int SeasonID
     {
         get;
         set;
     }

     public string SeasonName
     {
         get;
         set;
     }

     public DateTime StartDate
     {
         get;
         set;
     }

     public DateTime EndDate
     {
         get;
         set;
     }

     public int IsActive
     {
         get;
         set;
     }

     public int IsDefault
     {
         get;
         set;
     }

    }
 public class Seasons : Collection<Season>
 {
 }
}
