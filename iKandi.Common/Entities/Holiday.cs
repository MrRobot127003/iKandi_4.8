using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class Holiday
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TillDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Company { get; set; }
        public HolidayType Type { get; set; }
        public int HolidayTypeID
        {
            get { return Convert.ToInt32(Type); }
            set
            {
                Type = (HolidayType)value;
            }
        }

        public string DateString
        {
            get
            {
                return Date.ToString("dd MMM yy (ddd)");
            }
            set
            {
                Date = DateTime.ParseExact(value.Trim(), "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        public string TillDateString
        {
            get
            {
                return TillDate.ToString("dd MMM yy (ddd)");
            }
            set
            {
                TillDate = DateTime.ParseExact(value.Trim(), "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }
}
