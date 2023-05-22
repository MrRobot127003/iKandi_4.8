using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data;
using System.Web;

namespace iKandi.BLL
{
    public class CommonHelper
    {
        public static List<DeliveryMode> GetDeliveryModes(bool IsVisibleOnly)
        {
            return BLLCache.DeliverModes.FindAll(delegate(DeliveryMode DM) { return DM.IsVisible == Convert.ToInt32(IsVisibleOnly); });
        }

        public static bool IsAirDelivery(int ModeId)
        {

            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            return (dm.ModeType == ModeType.AIR);
        }

        public static bool IsFOBDelivery(int ModeId)
        {

            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            return (dm.SupplyType != SupplyType.LANDED);
        }

        public static bool IsFOB(int ModeId)
        {

            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            return (dm.Terms == Terms.FOB);
        }

        public static bool IsFlatDelivery(int ModeId)
        {
            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            return (dm.PackingType == PackingType.FLAT);
        }

        public static int GetLeadTime(int Air, int Flat, int FOB)
        {
            int leadTime = 0;
            DeliveryMode dm;

            if (FOB == 0)
            {
                dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.SupplyType != SupplyType.LANDED; });
                leadTime = dm.LeadTime;
            }
            else
            {
                if (Air == 1 && Flat == 1)
                {
                    dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.ModeType == ModeType.AIR && DM.PackingType == PackingType.FLAT; });
                    leadTime = dm.LeadTime;
                }
                else if (Air == 1 && Flat == 0)
                {
                    dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.ModeType == ModeType.AIR && DM.PackingType != PackingType.FLAT; });
                    leadTime = dm.LeadTime;
                }
                else if (Air == 0 && Flat == 1)
                {
                    dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.ModeType != ModeType.AIR && DM.PackingType == PackingType.FLAT; });
                    leadTime = dm.LeadTime;
                }
                else if (Air == 0 && Flat == 0)
                {
                    dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.ModeType != ModeType.AIR && DM.PackingType != PackingType.FLAT; });
                    leadTime = dm.LeadTime;
                }
            }


            return leadTime;
        }

        public static int GetDefaultLeadTime(string mode)
        {
            int leadTime = 0;
            mode = mode.ToLower();

            switch (mode)
            {
                case "a/f":
                    leadTime = GetLeadTime(1, 1, 1);
                    break;

                case "a/h":
                    leadTime = GetLeadTime(1, 0, 1);
                    break;

                case "s/f":
                    leadTime = GetLeadTime(0, 1, 1);
                    break;

                case "s/h":
                    leadTime = GetLeadTime(0, 0, 1);
                    break;

                case "fob":
                    leadTime = GetLeadTime(0, 0, 0);
                    break;
            }


            return leadTime;
        }

        public static int GetDefaultLeadTimeById(int ModeId)
        {
            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            return dm.LeadTime;
        }


        public static string GetShipmentInitial(int ModeId)
        {
            string initial = string.Empty;

            if (IsAirDelivery(ModeId))
                initial = "AIR-";
            else
                initial = "SEA-";

            if (IsFOBDelivery(ModeId))
                initial += "D-";
            else
                initial += "L-";

            return initial;
        }

        public static string GetOrderDeliveryMode(int ModeId)
        {
            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });
            string Code = string.Empty;
            if (dm != null)
                Code = dm.Code;


            return Code;
        }

        public static string GetDeliveryModeColor(int ModeId)
        {
            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            return dm.Color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExFactory"></param>
        /// <param name="DCDate"></param>
        /// <param name="ModeId"></param>
        /// <returns></returns>

        public static string GetExFactoryColor(DateTime ExFactory, DateTime DCDate, int ModeId)
        {
            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            long days = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, ExFactory, DCDate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1);

            if (days >= dm.RedRangeStart && days <= dm.RedRangeEnd)
                return "#ff3300";
            else if (days <= dm.AmberRangeEnd && days >= dm.AmberRangeStart)
                return "#fd9903";
            else if (days <= dm.GreenRangeEnd && days >= dm.GreenRangeStart)
                // return "#006600";
                return "#00FF70";
            return "#fd9903";
        }
        // edit by surendra on 14/10/2013
        public static string GetPCDColor(DateTime PCD, int PCSCut)
        {

            // if (PCD >DateTime.Now.ToString())
            //long days = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, ExFactory, DCDate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1);
            return "#ff3300";
            //if (days >= dm.RedRangeStart && days <= dm.RedRangeEnd)
            //    return "#ff3300";
            //else if (days <= dm.AmberRangeEnd && days >= dm.AmberRangeStart)
            //    return "#fd9903";
            //else if (days <= dm.GreenRangeEnd && days >= dm.GreenRangeStart)
            //    return "#00FF70";
            //return "#fd9903";
        }
        //end
        //Added By Ashish on 25/2/2015 function for return ColorCode
        //Added By Ashish on 25/2/2015 function for return ColorCode

        public static string GetBIHBackColorCode(DateTime BIHDate, DateTime ENDETA, int Parcent, bool IsShiped, bool FBIHDateRead)
        {
            string green = "#00FF70";
            string white = "#FFFFFF";
            string red = "#FF3300";
            string StrBackColorCode = string.Empty;

            if (FBIHDateRead == true)
            {
                if (IsShiped == true)
                {
                    StrBackColorCode = "#F9F9FA";
                }
                else
                {
                    if (BIHDate.Date >= DateTime.Now.Date)
                    {
                        if (ENDETA.Date != DateTime.MinValue)
                        {
                            if (Parcent != 0)
                            {
                                if (Parcent >= 100)
                                {
                                    StrBackColorCode = green;//green
                                }
                                else
                                {
                                    StrBackColorCode = white;//white
                                }
                            }
                            else
                            {
                                StrBackColorCode = white; //white
                            }
                        }
                        else
                        {
                            StrBackColorCode = white;//white
                        }
                    }
                    if (BIHDate.Date < DateTime.Now.Date)
                    {
                        if (ENDETA != DateTime.MinValue)
                        {
                            if (BIHDate.Date < ENDETA.Date)
                            {
                                StrBackColorCode = red;//red
                            }
                            if (Parcent != 0)
                            {
                                if (Parcent >= 100 && BIHDate.Date >= ENDETA.Date)
                                {
                                    StrBackColorCode = green;//green
                                }
                                else
                                {
                                    StrBackColorCode = red;//red 
                                }
                            }
                            else
                            {
                                StrBackColorCode = red;//red
                            }
                        }
                        else
                        {
                            StrBackColorCode = red;//red
                        }
                    }
                }
            }
            else
            {
                StrBackColorCode = white;
            }

            return StrBackColorCode;
        }
        public static string GetBIHForColorCode(DateTime BIHDate, DateTime ENDETA, int Parcent, bool IsShiped)
        {
            string StrForColorCode = string.Empty;

            if (IsShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                if (BIHDate.Date >= DateTime.Now.Date)
                {
                    if (ENDETA.Date != DateTime.MinValue)
                    {
                        if (Parcent != 0)
                        {
                            if (Parcent >= 100)
                            {
                                StrForColorCode = "#000000";//Black
                            }
                            else
                            {
                                StrForColorCode = "#000000";//Black
                            }
                        }
                        else
                        {
                            StrForColorCode = "#000000"; //Black
                        }
                    }
                    else
                    {
                        StrForColorCode = "#000000";//Black
                    }
                }
                if (BIHDate.Date < DateTime.Now.Date)
                {
                    if (ENDETA != DateTime.MinValue)
                    {
                        if (BIHDate.Date < ENDETA.Date)
                        {
                            StrForColorCode = "#FDFD96";//Yellow
                        }
                        if (Parcent != 0)
                        {
                            if (Parcent >= 100 && BIHDate.Date >= ENDETA.Date)
                            {
                                StrForColorCode = "#000000";//Black
                            }
                            else
                            {
                                StrForColorCode = "#FDFD96";//Yellow 
                            }
                        }
                        else
                        {
                            StrForColorCode = "#FDFD96";//Yellow
                        }
                    }
                    else
                    {
                        StrForColorCode = "#FDFD96";//Yellow
                    }
                }
            }

            return StrForColorCode;
        }

        public static string GetTechnicalBackColor(DateTime StcDateReq, DateTime FitsDate, bool isShiped)
        {
            string StrBackColorCode = string.Empty;
            if (isShiped == true)
            {
                StrBackColorCode = "#F9F9FA";
            }
            else
            {
                //if (FitsDate.Date != DateTime.MinValue)
                //{
                //    if (StcDateReq.Date >= DateTime.Now.Date)
                //    {
                //        StrBackColorCode = "#FFFFFF";
                //    }
                //    else
                //    {
                //        StrBackColorCode = "#FFFF66";
                //    }
                //}
                if (StcDateReq.Date != DateTime.MinValue && FitsDate.Date != DateTime.MinValue)
                {
                    StrBackColorCode = "#FFFFFF";
                }
                else
                {
                    StrBackColorCode = "#FFFFFF";
                }

            }
            return StrBackColorCode;
        }

        public static string GetTechnicalForColor(DateTime StcDateReq, DateTime FitsDate, bool isShiped)
        {
            string StrForColorCode = string.Empty;
            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                //if (FitsDate.Date != DateTime.MinValue)
                //{
                //    if (StcDateReq.Date >= DateTime.Now.Date)
                //    {
                //        StrForColorCode = "#000000";
                //    }
                //    else
                //    {
                //        StrForColorCode = "#FF3300";
                //    }
                //}

                if (StcDateReq.Date != DateTime.MinValue && FitsDate.Date != DateTime.MinValue)
                {
                    StrForColorCode = "#807F80";
                }
                else
                {
                    StrForColorCode = "#000000";
                }
            }



            return StrForColorCode;
        }
        //END

        public static string GetPricevariationForeColor(bool isShiped)
        {
            string StrForColorCode = string.Empty;
            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                StrForColorCode = "#FF0000";
            }

            return StrForColorCode;
        }
        public static string GetAuditForeColor(bool isShiped, string Naration)
        {
            string StrForColorCode = string.Empty;
            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                if (Naration.IndexOf("Rejt") == 12)
                {
                    StrForColorCode = "#FF0000";
                }
                else if (Naration.IndexOf("Aprd") == 12)
                {
                    StrForColorCode = "#00FF70";
                }
                else
                {
                    StrForColorCode = "#807F80";
                }
            }



            return StrForColorCode;
        }
        public static string CQDForeColor(bool isShiped)
        {
            string StrForColorCode = string.Empty;
            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                StrForColorCode = "#000000";
            }



            return StrForColorCode;
        }

        public static string GetSummaryForeColor(bool isShiped)
        {
            string StrForColorCode = string.Empty;
            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                StrForColorCode = "";
            }

            return StrForColorCode;
        }

        public static string GetBlackToForeColor(bool isShiped)
        {
            string StrBackForCode = string.Empty;
            if (isShiped == true)
            {
                StrBackForCode = "#807F80";
            }
            else
            {
                StrBackForCode = "#000000";
            }

            return StrBackForCode;
        }

        //Added By Ashish on 29/28/2015
        public static string GetstylenumberColor(bool isShiped, int IsRiskTask)
        {
            string StrBackForCode = string.Empty;
            if (isShiped == true)
            {
                StrBackForCode = "#807F80";
            }
            else
            {
                if (IsRiskTask == 1)
                {
                    StrBackForCode = "#000000";
                }
                else
                {
                    StrBackForCode = "#FF0000";
                }
            }


            return StrBackForCode;
        }

        public static string GetSamOBValColor(bool isShiped, int IsOBCreate, int IsFinalizeOB)
        {
            string StrBackForCode = string.Empty;
            if (isShiped == true)
            {
                StrBackForCode = "#807F80";
            }
            else
            {

                if (IsOBCreate == 1 && IsFinalizeOB == 1)
                {
                    StrBackForCode = "#0000FF";
                }
                else
                {
                    if (IsOBCreate == 1)
                    {
                        StrBackForCode = "#000000";
                    }
                    else if (IsFinalizeOB == 1)
                    {
                        StrBackForCode = "#0000FF";
                    }
                    else
                    {
                        StrBackForCode = "#FF0000";
                    }
                }

            }

            return StrBackForCode;
        }


        //END

        public static string GetLinktypeBackColor(bool isShiped)
        {
            string StrBackColorCode = string.Empty;
            if (isShiped == true)
            {
                StrBackColorCode = "#F9F9FA";
            }

            return StrBackColorCode;
        }

        public static string GetLinktypeForeColor(bool isShiped)
        {
            string StrForColorCode = string.Empty;
            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                StrForColorCode = "#808080";
            }

            return StrForColorCode;
        }
        //END
        // updated  By sushil on 26/3/2015
        public static string GetFitsPendingBackColor(bool IsFitsPending, bool isShiped)
        {
            string StrBackColorCode = string.Empty;
            if (isShiped == true)
            {
                StrBackColorCode = "#F9F9FA";
            }
            else if (IsFitsPending == true)
            {
                StrBackColorCode = "#FDFD96";
            }
            else
            {
                StrBackColorCode = "#F9F9FA"; ;
            }

            return StrBackColorCode;
        }
        public static string GetLinktypeForeColorforfitspending(bool isShiped, bool IsFitsPending = false)
        {
            string StrForColorCode = string.Empty;
            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                if (IsFitsPending == true)
                {
                    StrForColorCode = "#FF3300";
                }
                else
                {
                    StrForColorCode = "#0000ee";
                }
            }


            return StrForColorCode;
        }
        // End updated  By sushil on 26/3/2015
        //Added By Ashish on 25/2/2015 function for return ColorCode
        //Added By Prabhaker on 08/08/2017 function for return ColorCode
        public static string GetPercentBackColor(int Percent, bool isShiped, bool IsPermission)
        {
            string StrBackColorCode = string.Empty;
            if (IsPermission == true)
            {
                if (isShiped == true)
                {
                    StrBackColorCode = "#F9F9FA";//Gray
                }
                else
                {
                    if (Percent == 0)
                    {
                        StrBackColorCode = "#F9F9FA";//Gray
                    }
                    if (Percent >= 0.1 && Percent <= 89.99)
                    {
                        StrBackColorCode = "#FDFD96";//Yellow
                    }
                    if (Percent >= 90 && Percent <= 99.99)
                    {
                        StrBackColorCode = "#FFA500";//orange
                    }
                    else if (Percent >= 100 && Percent <= 105)
                    {
                        StrBackColorCode = "#d7e4bc";//green
                    }
                    else if (Percent > 105)
                    {
                        StrBackColorCode = "#C24641";

                    }

                }
            }
            else
            {
                StrBackColorCode = "#F9F9FA";//Normal
            }
            return StrBackColorCode;
        }
        //Added By Prabhaker on 08/08/2017 function for return ColorCode
        public static string GetPercentForColor(int Percent, bool isShiped)
        {
            string StrBackForCode = string.Empty;
            if (isShiped == true)
            {
                StrBackForCode = "#807F80";
            }
            else
            {
                if (Percent == 0)
                {
                    StrBackForCode = "#807F80";
                }
                if (Percent >= 0.1 && Percent <= 89.99)
                {
                    StrBackForCode = "#807F80";
                }
                if (Percent >= 90 && Percent <= 99.99)
                {
                    StrBackForCode = "#807F80";
                }               
                else if (Percent >= 100 && Percent <= 105)
                {
                    StrBackForCode = "#807F80";
                }

                else if (Percent > 105)
                {
                    StrBackForCode = "white";

                }
            }

            return StrBackForCode;
        }
        //END
        //Added By Ashish on 20/2/2015 function for return ColorCode
       
        public static string GetFabricNameBackColor(int Percent, bool isShiped, DateTime Bihdate, bool IsPermissionTrue)
        {
            string StrBackColorCode = string.Empty;
            if (IsPermissionTrue == true)
            {
                if (isShiped == true)
                {
                    StrBackColorCode = "#F9F9FA";
                }
                else
                {
                    if ((Percent == 0) && (Bihdate >= DateTime.Now.Date))
                    {
                        StrBackColorCode = "#F9F9FA";
                    }
                    else if (Percent <= 99.9)
                    {
                        StrBackColorCode = "#FDFD96"; // update bg color code 22-feb
                    }
                    else
                    {
                        StrBackColorCode = "#F9F9FA";
                    }
                }
            }
            else
            {
                StrBackColorCode = "#F9F9FA";
            }
            return StrBackColorCode;
        }

        public static string GetFabricNameForColor(int Percent, bool isShiped, DateTime Bihdate)
        {
            string StrBackColorCode = string.Empty;
            if (isShiped == true)
            {
                StrBackColorCode = "#807F80";
            }
            else
            {
                if (((Percent == 0) && (Bihdate >= DateTime.Now.Date)))
                {
                    StrBackColorCode = "#000000";
                }
                else if (Percent <= 99.9)
                {
                    StrBackColorCode = "#FF3300";
                }
                else
                {
                    StrBackColorCode = "#807F80";
                }
            }
            return StrBackColorCode;
        }
        public static string GetETABackColor(DateTime ETA, int Percent, bool isShiped, DateTime BIHDate, bool IsPermissionTrue)
        {
            string StrBackColorCode = string.Empty;

            if (IsPermissionTrue == true)
            {
                if (isShiped == true)
                {
                    StrBackColorCode = "#F9F9FA";
                }
                else
                {
                    if (Percent <= 99.9)
                    {

                        if (ETA.Date < DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                        {
                            StrBackColorCode = "#FDFD96";
                        }
                        else if (ETA.Date >= DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                        {
                            StrBackColorCode = "#F9F9FA";
                        }
                        else if (ETA.Date == DateTime.Now.Date)
                        {
                            StrBackColorCode = "#F9F9FA";
                        }
                        //else if (ETA.Date == DateTime.MinValue)
                        //{
                        //    StrBackColorCode = "#FFFF00";
                        //}
                        else if ((ETA.Date == DateTime.MinValue) && (BIHDate >= DateTime.Now.Date))
                        {
                            StrBackColorCode = "#F9F9FA";
                        }
                        else
                        {
                            StrBackColorCode = "#FDFD96";
                        }

                    }
                    else
                    {
                        StrBackColorCode = "#F9F9FA";
                    }
                }
            }
            else
            {
                StrBackColorCode = "#F9F9FA";
            }
            return StrBackColorCode;
        }
        //added for color by sushil on date  30/3/2015
        public static string GetStartETABackColor(DateTime ETA, int Percent, bool isShiped, DateTime BIHDate, bool IsPermissionTrue)
        {


            string StrBackColorCode = string.Empty;

            if (IsPermissionTrue == true)
            {
                if (isShiped == true)
                {
                    StrBackColorCode = "#F9F9FA";
                }
                else
                {
                    if (Percent <= 99.9 && Percent != 0)
                    {
                        if (ETA.Date != DateTime.MinValue)
                        {
                            StrBackColorCode = "#F9F9FA";
                        }

                        else if (ETA.Date < DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                        {
                            StrBackColorCode = "#FDFD96";
                        }
                        else if (ETA.Date >= DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                        {
                            StrBackColorCode = "#F9F9FA";
                        }
                        else if (ETA.Date == DateTime.Now.Date)
                        {
                            StrBackColorCode = "#FRF9FA";
                        }
                        //else if (ETA.Date == DateTime.MinValue)
                        //{
                        //    StrBackColorCode = "#FFFF00";
                        //}
                        else if ((ETA.Date == DateTime.MinValue) && (BIHDate >= DateTime.Now.Date))
                        {
                            StrBackColorCode = "#F9F9FA";
                        }
                        else
                        {
                            StrBackColorCode = "#FDFD96";
                        }

                    }
                    else if (Percent == 0 && ETA.Date < DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                    {
                        StrBackColorCode = "#FDFD96";
                    }
                    else
                    {
                        StrBackColorCode = "#F9F9FA";
                    }
                }
            }
            else
            {
                StrBackColorCode = "#F9F9FA";
            }
            return StrBackColorCode;
        }

        public static string GetStartETAForColor(DateTime ETA, int Percent, bool isShiped, DateTime Bihdate)
        {
            string StrForColorCode = string.Empty;

            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                if (Percent <= 99.9)
                {
                    if (ETA.Date < DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                    {
                        StrForColorCode = "#FF3300";
                    }
                    else if (ETA.Date >= DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                    {
                        StrForColorCode = "#00000";
                    }
                    else if (ETA.Date == DateTime.Now.Date)
                    {
                        StrForColorCode = "#000000";
                    }
                    else if ((ETA.Date == DateTime.MinValue) && (Bihdate >= DateTime.Now.Date))
                    {
                        StrForColorCode = "#00000";
                    }
                    //else if (ETA.Date == DateTime.MinValue)
                    //{
                    //    StrForColorCode = "#FF3300";
                    //}
                    else
                    {
                        StrForColorCode = "#FF3300";
                    }

                }
                //else if (Percent == 0 && ETA.Date < DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                //{
                //    StrForColorCode = "#FF3300";
                //}
                else
                {
                    StrForColorCode = "#807F80";
                }
            }
            return StrForColorCode;



        }

        //end by sushil on date 30/3/2015
        public static string GetETAForColor(DateTime ETA, int Percent, bool isShiped, DateTime Bihdate)
        {
            string StrForColorCode = string.Empty;

            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                if (Percent <= 99.9)
                {

                    if (ETA.Date < DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                    {
                        StrForColorCode = "#FF3300";
                    }
                    else if (ETA.Date >= DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                    {
                        StrForColorCode = "#00000";
                    }
                    else if (ETA.Date == DateTime.Now.Date)
                    {
                        StrForColorCode = "#000000";
                    }
                    else if ((ETA.Date == DateTime.MinValue) && (Bihdate >= DateTime.Now.Date))
                    {
                        StrForColorCode = "#00000";
                    }
                    //else if (ETA.Date == DateTime.MinValue)
                    //{
                    //    StrForColorCode = "#FF3300";
                    //}
                    else
                    {
                        StrForColorCode = "#FF3300";
                    }

                }
                else
                {
                    StrForColorCode = "#807F80";
                }
            }
            return StrForColorCode;
        }

        //END
        //Added By Ashish on 23/2/2015

        public static string GetBulkSatusBackColor(DateTime ActionDate, DateTime BIHDate, int Percent, bool isShiped, bool IsPermissionTrue)
        {
            string StrBackColorCode = string.Empty;
            if (IsPermissionTrue == true)
            {

                if (BIHDate != DateTime.MinValue)
                {
                    BIHDate = BIHDate.AddDays(-10);
                }
                if (isShiped == true)
                {
                    StrBackColorCode = "#F9F9FA";
                }
                else
                {
                    if (Percent <= 99.9)
                    {

                        if (ActionDate > BIHDate)
                        {
                            StrBackColorCode = "#f9f9fa";
                        }
                        else
                        {
                            StrBackColorCode = "#FDFD96";
                        }
                    }
                    else
                    {
                        //StrBackColorCode = "#d7e4bc";
                        StrBackColorCode = "#f9f9fa";
                    }
                }
            }
            else
            {
                StrBackColorCode = "#f9f9fa";
            }

            return StrBackColorCode;
        }

        public static string GetBulkSatusForeColor(DateTime ActionDate, DateTime BIHDate, int Percent, bool isShiped)
        {
            //  DateTime BIH = DateTime.Today.Date.AddDays(-10);
            string StrBackColorCode = string.Empty;
            if (BIHDate != DateTime.MinValue)
            {
                BIHDate = BIHDate.AddDays(-10);
            }
            if (isShiped == true)
            {
                StrBackColorCode = "#807F80";
            }
            else
            {
                if (Percent <= 99.9)
                {
                    if (ActionDate > BIHDate)
                    {
                        StrBackColorCode = "#000000";
                    }
                    else
                    {
                        StrBackColorCode = "#FF3300";
                    }
                }
                else
                {
                    StrBackColorCode = "#807F80";
                }
            }
            return StrBackColorCode;
        }

        public static string GetTrackingSatusForeColor(DateTime TargetDate, string ActionDate, bool isShiped)
        {
            //  DateTime BIH = DateTime.Today.Date.AddDays(-10);
            string StrBackColorCode = string.Empty;
            //if (BIHDate != DateTime.MinValue)
            //{
            //    BIHDate = BIHDate.AddDays(-10);
            //}
            if (isShiped == true)
            {
                StrBackColorCode = "#807F80";
            }

            else
            {
                if (ActionDate == string.Empty)
                {
                    if (TargetDate.Date > DateTime.Now.Date)
                    {
                        StrBackColorCode = "#000000";
                    }
                }
                else
                {
                    if (ActionDate != null)
                    {
                        if (ActionDate.Substring(0, 3) == "B R" || ActionDate.Substring(0, 3) == "I R" || ActionDate.Substring(0, 5) == "F-Q R")
                        {
                            StrBackColorCode = "#FF3300";
                        }
                        else if (TargetDate.Date >= Convert.ToDateTime(ActionDate.Substring(ActionDate.Length - 20)).Date)
                        {
                            StrBackColorCode = "#006400";
                        }
                        else if (TargetDate.Date < Convert.ToDateTime(ActionDate.Substring(ActionDate.Length - 20)).Date)
                        {
                            StrBackColorCode = "#FF3300";
                        }
                        else
                        {
                            StrBackColorCode = "#000000";
                        }
                    }
                }
            }
            //else
            //{
            //    if (Percent <= 99.9)
            //    {
            //        if (ActionDate > BIHDate)
            //        {
            //            StrBackColorCode = "#000000";
            //        }
            //        else
            //        {
            //            StrBackColorCode = "#FF3300";
            //        }
            //    }
            //    else
            //    {
            //        StrBackColorCode = "#807F80";
            //    }
            //}
            return StrBackColorCode;
        }
        //END

        //Added By Ashish on 9/4/2015
        public static string GetTechnicalETABackColor(DateTime ETA, bool isShiped, DateTime TargetDate, bool FitsSTCETARead, DateTime SealDate)
        {
            string StrBackColorCode = string.Empty;

            if (FitsSTCETARead == true)
            {
                if (isShiped == true)
                {
                    StrBackColorCode = "#F9F9FA";
                }
                else
                {
                    if (SealDate == DateTime.MinValue)
                    {

                        if (ETA.Date < DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                        {
                            StrBackColorCode = "#FDFD96"; //update color code 22-feb
                        }
                        else if (ETA.Date >= DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                        {
                            StrBackColorCode = "#FFFFFF";
                        }
                        else if (ETA.Date == DateTime.Now.Date)
                        {
                            StrBackColorCode = "#FFFFFF";
                        }
                        //else if (ETA.Date == DateTime.MinValue)
                        //{
                        //    StrBackColorCode = "#FFFF00";
                        //}
                        else if ((ETA.Date == DateTime.MinValue) && (TargetDate >= DateTime.Now.Date))
                        {
                            StrBackColorCode = "#FFFFFF";
                        }
                        else
                        {
                            StrBackColorCode = "#FDFD96"; //update color code 22-feb
                        }

                    }
                    else
                    {
                        StrBackColorCode = "#FFFFFF";
                    }
                }
            }
            else
            {
                StrBackColorCode = "#FFFFFF";
            }
            return StrBackColorCode;

        }

        public static string GetTechnicalETAForColor(DateTime ETA, bool isShiped, DateTime TargetDate, bool FitsSTCETARead, DateTime SealDate)
        {
            string StrForColorCode = string.Empty;

            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                if (SealDate == DateTime.MinValue)
                {

                    if (ETA.Date < DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                    {
                        StrForColorCode = "#FF3300";
                    }
                    else if (ETA.Date >= DateTime.Now.Date && ETA.Date != DateTime.MinValue)
                    {
                        StrForColorCode = "#00000";
                    }
                    else if (ETA.Date == DateTime.Now.Date)
                    {
                        StrForColorCode = "#000000";
                    }
                    else if ((ETA.Date == DateTime.MinValue) && (TargetDate >= DateTime.Now.Date))
                    {
                        StrForColorCode = "#00000";
                    }
                    //else if (ETA.Date == DateTime.MinValue)
                    //{
                    //    StrForColorCode = "#FF3300";
                    //}
                    else
                    {
                        StrForColorCode = "#FF3300";
                    }

                }
                else
                {
                    StrForColorCode = "#807F80";
                }
            }
            return StrForColorCode;
        }
        public static string StrikeOfForeColor(int IntialApproved, bool isShiped)
        {
            string StrForColorCode = string.Empty;

            if (isShiped == true)
            {
                StrForColorCode = "#807F80";
            }
            else
            {
                if (IntialApproved == 2)
                {
                    StrForColorCode = "#807F80";
                }

                else
                {
                    StrForColorCode = "#000000";
                }

            }


            return StrForColorCode;
        }
        public static string StrikeOfBackColor(int IntialApproved, bool isShiped)
        {
            string StrForColorCode = string.Empty;

            if (isShiped == true)
            {
                StrForColorCode = "#F9F9FA";
            }
            else
            {
                if (IntialApproved == 2)
                {

                    StrForColorCode = "#F9F9FA";
                }
                else
                {
                    StrForColorCode = "#F9F9FA";
                }
            }
            return StrForColorCode;
        }
        //END

        public static double GetDefaultModeCost(int ModeID)
        {
            if (IsAirDelivery(ModeID))
                return 0.50;
            else
                return 0.15;

        }

        public static int GetModeDays(int ModeId)
        {
            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            return dm.SystemExDC;
        }

        public static int GetOrderPackingType(int ModeId)
        {
            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });

            if (dm == null)
                throw new Exception("Invalid Mode");

            return dm.OrderPackingType;
        }

        public static string GetDeliveryModeToolTip(int ModeId)
        {
            DeliveryMode dm = BLLCache.DeliverModes.Find(delegate(DeliveryMode DM) { return DM.Id == ModeId; });
            string toolTip = string.Empty;
            if (dm == null)
                throw new Exception("Invalid Mode");

            if (dm.ToolTip == null)
            {
                toolTip = string.Empty;
            }
            else
            {
                toolTip = dm.ToolTip.ToString();
            }
            return toolTip;
        }


        public static string ConvertNumberToWord(long nNumber)
        {

            long CurrentNumber = nNumber;

            string sReturn = "";

            if (CurrentNumber >= 1000000000)
            {

                sReturn = sReturn + " " + GetWord(CurrentNumber / 1000000000, "Billion");

                CurrentNumber = CurrentNumber % 1000000000;

            }

            if (CurrentNumber >= 1000000)
            {

                sReturn = sReturn + " " + GetWord(CurrentNumber / 1000000, "Million");

                CurrentNumber = CurrentNumber % 1000000;

            }

            if (CurrentNumber >= 1000)
            {

                sReturn = sReturn + " " + GetWord(CurrentNumber / 1000, "Thousand");

                CurrentNumber = CurrentNumber % 1000;

            }

            if (CurrentNumber >= 100)
            {

                sReturn = sReturn + " " + GetWord(CurrentNumber / 100, "Hundred");

                CurrentNumber = CurrentNumber % 100;

            }

            if (CurrentNumber >= 20)
            {

                sReturn = sReturn + " " + GetWord(CurrentNumber, "");

                CurrentNumber = CurrentNumber % 10;

            }

            else if (CurrentNumber > 0)
            {

                sReturn = sReturn + " " + GetWord(CurrentNumber, "");

                CurrentNumber = 0;

            }

            return sReturn.Replace(" ", " ").Trim();

        }

        public static string GetWord(long nNumber, string sPrefix)
        {

            long nCurrentNumber = nNumber;

            string sReturn = "";

            while (nCurrentNumber > 0)
            {

                if (nCurrentNumber > 100)
                {

                    sReturn = sReturn + " " + GetWord(nCurrentNumber / 100, "Hundred");

                    nCurrentNumber = nCurrentNumber % 100;

                }

                else if (nCurrentNumber >= 20)
                {

                    sReturn = sReturn + " " + GetTwentyWord(nCurrentNumber / 10);

                    nCurrentNumber = nCurrentNumber % 10;

                }

                else
                {

                    sReturn = sReturn + " " + GetLessThanTwentyWord(nCurrentNumber);

                    nCurrentNumber = 0;

                }

            }

            sReturn = sReturn + " " + sPrefix;

            return sReturn;

        }

        private static string GetTwentyWord(long nNumber)
        {

            string sReturn = "";

            switch (nNumber)
            {

                case 2:

                    sReturn = "Twenty";

                    break;

                case 3:

                    sReturn = "Thirty";

                    break;

                case 4:

                    sReturn = "Forty";

                    break;

                case 5:

                    sReturn = "Fifty";

                    break;

                case 6:

                    sReturn = "Sixty";

                    break;

                case 7:

                    sReturn = "Seventy";

                    break;

                case 8:

                    sReturn = "Eighty";

                    break;

                case 9:

                    sReturn = "Ninety";

                    break;

            }

            return sReturn;

        }

        public static string GetLessThanTwentyWord(long nNumber)
        {

            string sReturn = "";

            switch (nNumber)
            {

                case 1:

                    sReturn = "One";

                    break;

                case 2:

                    sReturn = "Two";

                    break;

                case 3:

                    sReturn = "Three";

                    break;

                case 4:

                    sReturn = "Four";

                    break;

                case 5:

                    sReturn = "Five";

                    break;

                case 6:

                    sReturn = "Six";

                    break;

                case 7:

                    sReturn = "Seven";

                    break;

                case 8:

                    sReturn = "Eight";

                    break;

                case 9:

                    sReturn = "Nine";

                    break;

                case 10:

                    sReturn = "Ten";

                    break;

                case 11:

                    sReturn = "Eleven";

                    break;

                case 12:

                    sReturn = "Twelve";

                    break;

                case 13:

                    sReturn = "Thirteen";

                    break;

                case 14:

                    sReturn = "Forteen";

                    break;

                case 15:

                    sReturn = "Fifteen";

                    break;

                case 16:

                    sReturn = "Sixteen";

                    break;

                case 17:

                    sReturn = "Seventeen";

                    break;

                case 18:

                    sReturn = "Eighteen";

                    break;

                case 19:

                    sReturn = "Nineteen";

                    break;
            }

            return sReturn;
        }

        //public static string GetLeaveTypeStringValue(LeaveType type, bool shortString)
        //{
        //    switch (type)
        //    {
        //        case LeaveType.PrivilegeLeave:
        //            if (shortString) return "PL"; else return "Privilege Leave";
        //            break;
        //        case LeaveType.CasualLeave:
        //            if (shortString) return "CL"; else return "Casual Leave";
        //            break;
        //        case LeaveType.SickLeave:
        //            if (shortString) return "SL"; else return "Sick Leave";
        //            break;
        //        case LeaveType.CompOffLeave:
        //            if (shortString) return "CO(L)"; else return "CompOff Leave";
        //            break;
        //        case LeaveType.CompOffWork:
        //            if (shortString) return "CO(W)"; else return "CompOff Work";
        //            break;
        //        default:
        //            return "";
        //            break;
        //    }
        //}

        public static string GetClientCostingDefaultValue(int ClientID, int DepartmentID, ClientCostingItem Item)
        {
            DataRow[] row = BLLCache.ClientCostingDefaults.Select("ClientID=" + ClientID.ToString() + " AND DeptId=" + DepartmentID.ToString() + " AND ItemID=" + ((int)Item).ToString());

            if (row.Length > 0)
                return row[0]["Value"].ToString();

            return string.Empty;
        }

        public static double GetCurrencyRate(Currency From, Currency To)
        {
            CurrencyConversion rate = BLLCache.CurrencyConversion.Find(delegate(CurrencyConversion cc) { return cc.From == From && cc.To == To; });

            if (rate == null)
            {
                rate = BLLCache.CurrencyConversion.Find(delegate(CurrencyConversion cc) { return cc.From == To && cc.To == From; });

                if (rate == null)
                    return 1;
                else
                    return (1 / rate.ConversionRate);
            }
            else
                return rate.ConversionRate;

        }

        public static double GetExportConversionRate(Currency From, Currency To)
        {
            CurrencyConversion expRate = BLLCache.CurrencyConversion.Find(delegate(CurrencyConversion cc) { return cc.From == From && cc.To == To; });

            if (expRate == null)
            {
                expRate = BLLCache.CurrencyConversion.Find(delegate(CurrencyConversion cc) { return cc.From == To && cc.To == From; });

                if (expRate == null)
                    return 1;
                else
                    return (1 / expRate.ExportConversionRate);
            }
            else
                return expRate.ExportConversionRate;

        }

        public static string GetCurrencyName(int currency)
        {
            switch (currency)
            {
                case 1:
                    return "USD";
                case 2:
                    return "GBP";
                case 3:
                    return "INR";
                case 4:
                    return "EURO";
                case 5:
                    return "KRO";
                case 6:
                    return "AUD";
                default:
                    return "---";
            }
        }

    }
}
