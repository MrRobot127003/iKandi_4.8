using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;
using System.Web;

namespace iKandi.DAL
{
    public class LabTestDataProvider : BaseDataProvider
    {
        //test
        #region Ctor(s)

        public LabTestDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Read Methods

        public LabTest GetBasicInformationByOrderDetailId(int OrderDetailID)
        {
            LabTest labTest = new LabTest();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_lab_test_get_basic_info_by_orderdetailId";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@OrderDetailId", SqlDbType.Int);
                    param.Value = OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsLabTest = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsLabTest);

                    labTest = ConvertDataSetToLabTestByOrderDetailId(dsLabTest);

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return labTest;
        }

        private LabTest ConvertDataSetToLabTestByOrderDetailId(DataSet dsLabTest)
        {
            LabTest labTest = new LabTest();
            labTest.OrderDetail = new OrderDetail();
            labTest.OrderDetail.ParentOrder = new Order();
            labTest.OrderDetail.ParentOrder.AccessoryInHouseHistory = new AccessoryInHouseHistory();
            labTest.OrderDetail.ParentOrder.Style = new Style();
            labTest.OrderDetail.ParentOrder.Style.client = new Client();
            labTest.PrintHistory1 = new List<PrintHistory>();
            labTest.PrintHistory2 = new List<PrintHistory>();
            labTest.PrintHistory3 = new List<PrintHistory>();
            labTest.PrintHistory4 = new List<PrintHistory>();
            labTest.LabBulkTest1 = new List<LabBulkTest>();
            labTest.LabBulkTest2 = new List<LabBulkTest>();
            labTest.LabBulkTest3 = new List<LabBulkTest>();
            labTest.LabBulkTest4 = new List<LabBulkTest>();


            DataTable dtBasicInfo = dsLabTest.Tables[0];
            if (dtBasicInfo.Rows.Count > 0)
            {
                DataRow row1 = dtBasicInfo.Rows[0];

                labTest.LabTestID = (row1["LabTestID"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["LabTestID"]);
                labTest.OrderDetail.OrderDetailID = Convert.ToInt32(row1["Id"]);
                labTest.OrderDetail.Quantity = (row1["Quantity"] == DBNull.Value) ? 0 : Convert.ToInt32(row1["Quantity"]);
                labTest.OrderDetail.LineItemNumber = (row1["LineItemNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["LineItemNumber"]);
                labTest.OrderDetail.ContractNumber = (row1["ContractNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["ContractNumber"]);

                labTest.PrintID1 = (row1["PrintID1"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["PrintID1"]);
                labTest.PrintID2 = (row1["PrintID2"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["PrintID2"]);
                labTest.PrintID3 = (row1["PrintID3"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["PrintID3"]);
                labTest.PrintID4 = (row1["PrintID4"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["PrintID4"]);

                labTest.OrderDetail.Fabric1Details = (row1["Fabric1Details"] == DBNull.Value) ? string.Empty : (labTest.PrintID1 > 0 ? "PRD:" + Convert.ToString(row1["Fabric1Details"]) : Convert.ToString(row1["Fabric1Details"]));
                labTest.OrderDetail.Fabric2Details = (row1["Fabric2Details"] == DBNull.Value) ? string.Empty : (labTest.PrintID2 > 0 ? "PRD:" + Convert.ToString(row1["Fabric2Details"]) : Convert.ToString(row1["Fabric2Details"]));
                labTest.OrderDetail.Fabric3Details = (row1["Fabric3Details"] == DBNull.Value) ? string.Empty : (labTest.PrintID3 > 0 ? "PRD:" + Convert.ToString(row1["Fabric3Details"]) : Convert.ToString(row1["Fabric3Details"]));
                labTest.OrderDetail.Fabric4Details = (row1["Fabric4Details"] == DBNull.Value) ? string.Empty : (labTest.PrintID4 > 0 ? "PRD:" + Convert.ToString(row1["Fabric4Details"]) : Convert.ToString(row1["Fabric4Details"]));

                labTest.OrderDetail.ModeName = (row1["Code"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["Code"]));
                labTest.OrderDetail.Status = (row1["Status"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["Status"]));
                labTest.OrderDetail.BulkTarget = (row1["BulkTarget"] == DBNull.Value || row1["BulkTarget"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["BulkTarget"]);
                labTest.OrderDetail.InlineCut = (row1["InlineCut"] == DBNull.Value || row1["InlineCut"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["InlineCut"]);

                labTest.OrderDetail.Fabric1 = (row1["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Fabric1"]);
                labTest.OrderDetail.Fabric2 = (row1["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Fabric2"]);
                labTest.OrderDetail.Fabric3 = (row1["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Fabric3"]);
                labTest.OrderDetail.Fabric4 = (row1["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Fabric4"]);
                labTest.OrderDetail.CCGSM1 = (row1["Fabric11"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Fabric11"]);
                labTest.OrderDetail.CCGSM2 = (row1["Fabric12"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Fabric12"]);
                labTest.OrderDetail.CCGSM3 = (row1["Fabric13"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Fabric13"]);
                labTest.OrderDetail.CCGSM4 = (row1["Fabric14"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Fabric14"]);
               

                labTest.OrderDetail.ParentOrder.OrderDate = (row1["OrderDate"] == DBNull.Value || row1["OrderDate"].ToString() == String.Empty) ? DateTime.MinValue : Convert.ToDateTime(row1["OrderDate"]);
                labTest.OrderDetail.ParentOrder.SerialNumber = Convert.ToString(row1["SerialNumber"]);
                labTest.OrderDetail.ParentOrder.Description = (row1["Description"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Description"]);
                labTest.OrderDetail.ParentOrder.OrderID = (row1["OrderID"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["OrderID"]);
                labTest.OrderDetail.ParentOrder.Style.StyleNumber = (row1["StyleNumber"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["StyleNumber"]));
                labTest.OrderDetail.ParentOrder.Style.client.ClientID = (row1["ClientId"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["ClientId"]);
                labTest.BaseTestFile1 = (row1["UploadBaseTestFile1"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["UploadBaseTestFile1"]));
                labTest.BaseTestFile2 = (row1["UploadBaseTestFile2"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["UploadBaseTestFile2"]));
                labTest.BaseTestFile3 = (row1["UploadBaseTestFile3"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["UploadBaseTestFile3"]));
                labTest.BaseTestFile4 = (row1["UploadBaseTestFile4"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["UploadBaseTestFile4"]));
                labTest.Comments1 = (row1["Comments1"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["Comments1"])).IndexOf("$$") > -1 ? Convert.ToString(row1["Comments1"]).Replace("$$", "<br/>") : Convert.ToString(row1["Comments1"]);
                labTest.Comments2 = (row1["Comments2"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["Comments2"])).IndexOf("$$") > -1 ? Convert.ToString(row1["Comments2"]).Replace("$$", "<br/>") : Convert.ToString(row1["Comments2"]);
                labTest.Comments3 = (row1["Comments3"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["Comments3"])).IndexOf("$$") > -1 ? Convert.ToString(row1["Comments3"]).Replace("$$", "<br/>") : Convert.ToString(row1["Comments3"]);
                labTest.Comments4 = (row1["Comments4"] == DBNull.Value) ? string.Empty : (Convert.ToString(row1["Comments4"])).IndexOf("$$") > -1 ? Convert.ToString(row1["Comments4"]).Replace("$$", "<br/>") : Convert.ToString(row1["Comments4"]);
                labTest.FabricQualityID1 = (row1["Fabric1Id"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["Fabric1Id"]);
                labTest.FabricQualityID2 = (row1["Fabric2Id"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["Fabric2Id"]);
                labTest.FabricQualityID3 = (row1["Fabric3Id"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["Fabric3Id"]);
                labTest.FabricQualityID4 = (row1["Fabric4Id"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["Fabric4Id"]);
            }

            DataTable dtAccessoryHistory = dsLabTest.Tables[1];
            if (dtAccessoryHistory.Rows.Count > 0)
            {
                foreach (DataRow dr in dtAccessoryHistory.Rows)
                {
                    labTest.OrderDetail.ParentOrder.AccessoryInHouseHistory.Date = (dr["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
                    labTest.OrderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse = (dr["PercentInHouse"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PercentInHouse"]);
                    labTest.OrderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName = (dr["AccessoryName"] == DBNull.Value) ? string.Empty : dr["AccessoryName"].ToString();
                    labTest.OrderDetail.AccessoryHistory += labTest.OrderDetail.ParentOrder.AccessoryInHouseHistory.AccessoryName + " " + labTest.OrderDetail.ParentOrder.AccessoryInHouseHistory.PercentInHouse + "% on" + " " + labTest.OrderDetail.ParentOrder.AccessoryInHouseHistory.Date.ToString("dd MMM yy (ddd)") + "<br/>";
                }
            }

            DataTable dtAccessories = dsLabTest.Tables[2];
            if (dtAccessories.Rows.Count > 0)
            {
                foreach (DataRow dr in dtAccessories.Rows)
                {
                    string AccessoryName = (dr["AccessoryName"] == DBNull.Value) ? string.Empty : dr["AccessoryName"].ToString();
                    if (labTest.OrderDetail.AccessoryHistory != null && labTest.OrderDetail.AccessoryHistory != string.Empty)
                    {
                        if (labTest.OrderDetail.AccessoryHistory.IndexOf(AccessoryName) == -1)
                        {
                            labTest.OrderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/>";
                        }
                    }
                    else
                    {
                        labTest.OrderDetail.AccessoryHistory += AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "<br/>";
                    }
                }
            }

            DataTable dtInitialTest1 = dsLabTest.Tables[3];
            int PrintHistory1Count = -1;
            if (dtInitialTest1.Rows.Count > 0)
            {
                PrintHistory1Count = dtInitialTest1.Rows.Count;
                foreach (DataRow dr in dtInitialTest1.Rows)
                {
                    PrintHistory1Count--;
                    PrintHistory ph1Data = new PrintHistory();
                    ph1Data.ParentPrint = new Print();
                    ph1Data.PrintHistoryID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                    ph1Data.ParentPrint.PrintID = (dr["PrintID1"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["PrintID1"]);
                    ph1Data.TestingDate = (dr["TestingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingDate"]);
                    ph1Data.PDFPath = (dr["FilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FilePath"]);
                    ph1Data.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                    ph1Data.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                    labTest.PrintHistory1.Add(ph1Data);

                    if (PrintHistory1Count == 0 && Convert.ToInt32(ph1Data.Status) == -1 && ph1Data.ParentPrint.PrintID > 0)
                        PrintHistory1Count = -1;
                    else if (PrintHistory1Count == 0 && Convert.ToInt32(ph1Data.Status) != 1 && ph1Data.ParentPrint.PrintID > 0)
                        PrintHistory1Count = dtInitialTest1.Rows.Count;

                    labTest.PrintID1 = ph1Data.ParentPrint.PrintID;
                }
                if (PrintHistory1Count == dtInitialTest1.Rows.Count)
                {
                    PrintHistory ph1Fail = new PrintHistory();
                    ph1Fail.ParentPrint = new Print();
                    ph1Fail.PrintHistoryID = -1;
                    ph1Fail.ParentPrint.PrintID = -1;
                    ph1Fail.TestingDate = DateTime.MinValue;
                    ph1Fail.PDFPath = string.Empty;
                    ph1Fail.Status = -1;
                    ph1Fail.Comments = string.Empty;
                    labTest.PrintHistory1.Add(ph1Fail);
                }
            }
            //else if (dtInitialTest1.Rows.Count == 0)
            //{
            //    PrintHistory ph1NewRow = new PrintHistory();
            //    ph1NewRow.ParentPrint = new Print();
            //    ph1NewRow.PrintHistoryID = -1;
            //    ph1NewRow.ParentPrint.PrintID = -1;
            //    ph1NewRow.TestingDate = DateTime.MinValue;
            //    ph1NewRow.PDFPath = string.Empty;
            //    ph1NewRow.Status = -1;
            //    ph1NewRow.Comments = string.Empty;
            //    labTest.PrintHistory1.Add(ph1NewRow);
            //}

            if (labTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper()
               )
            {
                DataTable dtInitialTest2 = dsLabTest.Tables[4];
                int PrintHistory2Count = -1;
                if (dtInitialTest2.Rows.Count > 0)
                {
                    PrintHistory2Count = dtInitialTest2.Rows.Count;
                    foreach (DataRow dr in dtInitialTest2.Rows)
                    {
                        PrintHistory2Count--;
                        PrintHistory ph2Data = new PrintHistory();
                        ph2Data.ParentPrint = new Print();
                        ph2Data.PrintHistoryID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                        ph2Data.ParentPrint.PrintID = (dr["PrintID2"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["PrintID2"]);
                        ph2Data.TestingDate = (dr["TestingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingDate"]);
                        ph2Data.PDFPath = (dr["FilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FilePath"]);
                        ph2Data.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                        ph2Data.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                        labTest.PrintHistory2.Add(ph2Data);

                        if (PrintHistory2Count == 0 && Convert.ToInt32(ph2Data.Status) == -1 && ph2Data.ParentPrint.PrintID > 0)
                            PrintHistory2Count = -1;
                        else if (PrintHistory2Count == 0 && Convert.ToInt32(ph2Data.Status) != 1 && ph2Data.ParentPrint.PrintID > 0)
                            PrintHistory2Count = dtInitialTest2.Rows.Count;

                        labTest.PrintID2 = ph2Data.ParentPrint.PrintID;
                    }
                    if (PrintHistory2Count == dtInitialTest2.Rows.Count)
                    {
                        PrintHistory ph2Fail = new PrintHistory();
                        ph2Fail.ParentPrint = new Print();
                        ph2Fail.PrintHistoryID = -1;
                        ph2Fail.ParentPrint.PrintID = -1;
                        ph2Fail.TestingDate = DateTime.MinValue;
                        ph2Fail.PDFPath = string.Empty;
                        ph2Fail.Status = -1;
                        ph2Fail.Comments = string.Empty;
                        labTest.PrintHistory2.Add(ph2Fail);
                    }
                }
                //else if (dtInitialTest2.Rows.Count == 0)
                //{
                //    PrintHistory ph2NewRow = new PrintHistory();
                //    ph2NewRow.ParentPrint = new Print();
                //    ph2NewRow.PrintHistoryID = -1;
                //    ph2NewRow.ParentPrint.PrintID = -1;
                //    ph2NewRow.TestingDate = DateTime.MinValue;
                //    ph2NewRow.PDFPath = string.Empty;
                //    ph2NewRow.Status = -1;
                //    ph2NewRow.Comments = string.Empty;
                //    labTest.PrintHistory2.Add(ph2NewRow);
                //}
            }

            if (
                (labTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper())
                &&
                (labTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper())
                )
            {
                DataTable dtInitialTest3 = dsLabTest.Tables[5];
                int PrintHistory3Count = -1;
                if (dtInitialTest3.Rows.Count > 0)
                {
                    PrintHistory3Count = dtInitialTest3.Rows.Count;
                    foreach (DataRow dr in dtInitialTest3.Rows)
                    {
                        PrintHistory3Count--;
                        PrintHistory ph3Data = new PrintHistory();
                        ph3Data.ParentPrint = new Print();
                        ph3Data.PrintHistoryID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                        ph3Data.ParentPrint.PrintID = (dr["PrintID3"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["PrintID3"]);
                        ph3Data.TestingDate = (dr["TestingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingDate"]);
                        ph3Data.PDFPath = (dr["FilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FilePath"]);
                        ph3Data.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                        ph3Data.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                        labTest.PrintHistory3.Add(ph3Data);

                        if (PrintHistory3Count == 0 && Convert.ToInt32(ph3Data.Status) == -1 && ph3Data.ParentPrint.PrintID > 0)
                            PrintHistory3Count = -1;
                        else if (PrintHistory3Count == 0 && Convert.ToInt32(ph3Data.Status) != 1 && ph3Data.ParentPrint.PrintID > 0)
                            PrintHistory3Count = dtInitialTest3.Rows.Count;

                        labTest.PrintID3 = ph3Data.ParentPrint.PrintID;
                    }
                    if (PrintHistory3Count == dtInitialTest3.Rows.Count)
                    {
                        PrintHistory ph3Fail = new PrintHistory();
                        ph3Fail.ParentPrint = new Print();
                        ph3Fail.PrintHistoryID = -1;
                        ph3Fail.ParentPrint.PrintID = -1;
                        ph3Fail.TestingDate = DateTime.MinValue;
                        ph3Fail.PDFPath = string.Empty;
                        ph3Fail.Status = -1;
                        ph3Fail.Comments = string.Empty;
                        labTest.PrintHistory3.Add(ph3Fail);
                    }
                }
                //else if (dtInitialTest3.Rows.Count == 0)
                //{
                //    PrintHistory ph3NewRow = new PrintHistory();
                //    ph3NewRow.ParentPrint = new Print();
                //    ph3NewRow.PrintHistoryID = -1;
                //    ph3NewRow.ParentPrint.PrintID = -1;
                //    ph3NewRow.TestingDate = DateTime.MinValue;
                //    ph3NewRow.PDFPath = string.Empty;
                //    ph3NewRow.Status = -1;
                //    ph3NewRow.Comments = string.Empty;
                //    labTest.PrintHistory3.Add(ph3NewRow);
                //}
            }
            if (
                (labTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
                &&
                (labTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
                &&
                (labTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
                )
            {
                DataTable dtInitialTest4 = dsLabTest.Tables[6];
                int PrintHistory4Count = -1;
                if (dtInitialTest4.Rows.Count > 0)
                {
                    PrintHistory4Count = dtInitialTest4.Rows.Count;
                    foreach (DataRow dr in dtInitialTest4.Rows)
                    {
                        PrintHistory4Count--;
                        PrintHistory ph4Data = new PrintHistory();
                        ph4Data.ParentPrint = new Print();
                        ph4Data.PrintHistoryID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                        ph4Data.ParentPrint.PrintID = (dr["PrintID4"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["PrintID4"]);
                        ph4Data.TestingDate = (dr["TestingDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingDate"]);
                        ph4Data.PDFPath = (dr["FilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["FilePath"]);
                        ph4Data.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                        ph4Data.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                        labTest.PrintHistory4.Add(ph4Data);

                        if (PrintHistory4Count == 0 && Convert.ToInt32(ph4Data.Status) == -1 && ph4Data.ParentPrint.PrintID > 0)
                            PrintHistory4Count = -1;
                        if (PrintHistory4Count == 0 && Convert.ToInt32(ph4Data.Status) != 1 && ph4Data.ParentPrint.PrintID > 0)
                            PrintHistory4Count = dtInitialTest4.Rows.Count;

                        labTest.PrintID4 = ph4Data.ParentPrint.PrintID;
                    }
                    if (PrintHistory4Count == dtInitialTest4.Rows.Count)
                    {
                        PrintHistory ph4Fail = new PrintHistory();
                        ph4Fail.ParentPrint = new Print();
                        ph4Fail.PrintHistoryID = -1;
                        ph4Fail.ParentPrint.PrintID = -1;
                        ph4Fail.TestingDate = DateTime.MinValue;
                        ph4Fail.PDFPath = string.Empty;
                        ph4Fail.Status = -1;
                        ph4Fail.Comments = string.Empty;
                        labTest.PrintHistory4.Add(ph4Fail);
                    }
                }
                //else if (dtInitialTest4.Rows.Count == 0)
                //{
                //    PrintHistory ph4NewRow = new PrintHistory();
                //    ph4NewRow.ParentPrint = new Print();
                //    ph4NewRow.PrintHistoryID = -1;
                //    ph4NewRow.ParentPrint.PrintID = -1;
                //    ph4NewRow.TestingDate = DateTime.MinValue;
                //    ph4NewRow.PDFPath = string.Empty;
                //    ph4NewRow.Status = -1;
                //    ph4NewRow.Comments = string.Empty;
                //    labTest.PrintHistory4.Add(ph4NewRow);
                //}
            }

            DataTable dtLabBulkTest1 = dsLabTest.Tables[7];
            int LabBulkTest1Count = -1;

            if (dtLabBulkTest1.Rows.Count > 0)
            {
                LabBulkTest1Count = dtLabBulkTest1.Rows.Count;
                foreach (DataRow dr in dtLabBulkTest1.Rows)
                {
                    LabBulkTest1Count--;
                    LabBulkTest lbt1Data = new LabBulkTest();
                    lbt1Data.LabBulkTestID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                    lbt1Data.TestingCompletionActual = (dr["TestingCompletionActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingCompletionActual"]);
                    lbt1Data.TestReportFilePath = (dr["TestReportFilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["TestReportFilePath"]);
                    lbt1Data.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                    lbt1Data.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                    lbt1Data.ClientID = (dr["ClientId"] != DBNull.Value) ? Convert.ToInt32(dr["ClientId"]) : labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                    lbt1Data.FabricName = (dr["FabricName"] != DBNull.Value) ? Convert.ToString(dr["FabricName"]) : labTest.OrderDetail.Fabric1.ToString();
                    lbt1Data.FabricDetail = (dr["FabricDetail"] != DBNull.Value) ? (labTest.PrintID1 > 0 ? "PRD:" + Convert.ToString(dr["FabricDetail"]) : Convert.ToString(dr["FabricDetail"])) : labTest.OrderDetail.Fabric1Details.ToString();
                    lbt1Data.OrderID = (dr["OrderId"] != DBNull.Value) ? Convert.ToInt32(dr["OrderId"]) : (lbt1Data.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);

                    labTest.LabBulkTest1.Add(lbt1Data);

                    if (LabBulkTest1Count == 0 && Convert.ToInt32(lbt1Data.Status) == -1)
                        LabBulkTest1Count = -1;
                    else if (LabBulkTest1Count == 0 && Convert.ToInt32(lbt1Data.Status) != 1)  // In case of Fail
                        LabBulkTest1Count = dtLabBulkTest1.Rows.Count;
                }
                if (LabBulkTest1Count == dtLabBulkTest1.Rows.Count)
                {
                    LabBulkTest lbt1Fail = new LabBulkTest();
                    lbt1Fail.LabBulkTestID = -1;
                    lbt1Fail.TestingCompletionActual = DateTime.MinValue;
                    lbt1Fail.TestReportFilePath = string.Empty;
                    lbt1Fail.Status = -1;
                    lbt1Fail.Comments = string.Empty;
                    lbt1Fail.ClientID = labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                    lbt1Fail.FabricName = labTest.OrderDetail.Fabric1.ToString();
                    lbt1Fail.FabricDetail = labTest.OrderDetail.Fabric1Details.ToString();
                    lbt1Fail.OrderID = (lbt1Fail.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);

                    labTest.LabBulkTest1.Add(lbt1Fail);
                }
            }
            else if (dtLabBulkTest1.Rows.Count == 0 && labTest.OrderDetail.Fabric1.Trim() != string.Empty)
            {
                LabBulkTest lbt1NewRow = new LabBulkTest();
                lbt1NewRow.LabBulkTestID = -1;
                lbt1NewRow.TestingCompletionActual = DateTime.MinValue;
                lbt1NewRow.TestReportFilePath = string.Empty;
                lbt1NewRow.Status = -1;
                lbt1NewRow.Comments = string.Empty;
                lbt1NewRow.ClientID = labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                lbt1NewRow.FabricName = labTest.OrderDetail.Fabric1.ToString();
                lbt1NewRow.FabricDetail = labTest.OrderDetail.Fabric1Details.ToString();
                lbt1NewRow.OrderID = (lbt1NewRow.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);

                labTest.LabBulkTest1.Add(lbt1NewRow);
            }

            DataTable dtLabBulkTest2 = dsLabTest.Tables[8];
            int LabBulkTest2Count = -1;

            if (
                (labTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() ||
                labTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper())
                )
            {
                if (dtLabBulkTest2.Rows.Count > 0)
                {
                    LabBulkTest2Count = dtLabBulkTest2.Rows.Count;
                    foreach (DataRow dr in dtLabBulkTest2.Rows)
                    {
                        LabBulkTest2Count--;
                        LabBulkTest lbt2Data = new LabBulkTest();
                        lbt2Data.LabBulkTestID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                        lbt2Data.TestingCompletionActual = (dr["TestingCompletionActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingCompletionActual"]);
                        lbt2Data.TestReportFilePath = (dr["TestReportFilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["TestReportFilePath"]);
                        lbt2Data.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                        lbt2Data.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                        lbt2Data.ClientID = (dr["ClientId"] != DBNull.Value) ? Convert.ToInt32(dr["ClientId"]) : labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                        lbt2Data.FabricName = (dr["FabricName"] != DBNull.Value) ? Convert.ToString(dr["FabricName"]) : labTest.OrderDetail.Fabric2.ToString();
                        lbt2Data.FabricDetail = (dr["FabricDetail"] != DBNull.Value) ? (labTest.PrintID2 > 0 ? "PRD:" + Convert.ToString(dr["FabricDetail"]) : Convert.ToString(dr["FabricDetail"])) : labTest.OrderDetail.Fabric2Details.ToString();
                        lbt2Data.OrderID = (dr["OrderId"] != DBNull.Value) ? Convert.ToInt32(dr["OrderId"]) : (lbt2Data.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                        labTest.LabBulkTest2.Add(lbt2Data);

                        if (LabBulkTest2Count == 0 && Convert.ToInt32(lbt2Data.Status) == -1)
                            LabBulkTest2Count = -1;
                        else if (LabBulkTest2Count == 0 && Convert.ToInt32(lbt2Data.Status) != 1)
                            LabBulkTest2Count = dtLabBulkTest2.Rows.Count;
                    }
                    if (LabBulkTest2Count == dtLabBulkTest2.Rows.Count)
                    {
                        LabBulkTest lbt2Fail = new LabBulkTest();
                        lbt2Fail.LabBulkTestID = -1;
                        lbt2Fail.TestingCompletionActual = DateTime.MinValue;
                        lbt2Fail.TestReportFilePath = string.Empty;
                        lbt2Fail.Status = -1;
                        lbt2Fail.Comments = string.Empty;
                        lbt2Fail.ClientID = labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                        lbt2Fail.FabricName = labTest.OrderDetail.Fabric2.ToString();
                        lbt2Fail.FabricDetail = labTest.OrderDetail.Fabric2Details.ToString();
                        lbt2Fail.OrderID = (lbt2Fail.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                        labTest.LabBulkTest2.Add(lbt2Fail);
                    }
                }
                else if (dtLabBulkTest2.Rows.Count == 0 && labTest.OrderDetail.Fabric2.Trim() != string.Empty)
                {
                    LabBulkTest lbt2NewRow = new LabBulkTest();
                    lbt2NewRow.LabBulkTestID = -1;
                    lbt2NewRow.TestingCompletionActual = DateTime.MinValue;
                    lbt2NewRow.TestReportFilePath = string.Empty;
                    lbt2NewRow.Status = -1;
                    lbt2NewRow.Comments = string.Empty;
                    lbt2NewRow.ClientID = labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                    lbt2NewRow.FabricName = labTest.OrderDetail.Fabric2.ToString();
                    lbt2NewRow.FabricDetail = labTest.OrderDetail.Fabric2Details.ToString();
                    lbt2NewRow.OrderID = (lbt2NewRow.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                    labTest.LabBulkTest2.Add(lbt2NewRow);
                }
            }

            DataTable dtLabBulkTest3 = dsLabTest.Tables[9];
            int LabBulkTest3Count = -1;
            if (
                (labTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper())
               &&
                (labTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper())
               )
            {
                if (dtLabBulkTest3.Rows.Count > 0)
                {
                    LabBulkTest3Count = dtLabBulkTest3.Rows.Count;
                    foreach (DataRow dr in dtLabBulkTest3.Rows)
                    {
                        LabBulkTest3Count--;
                        LabBulkTest lbt3Data = new LabBulkTest();
                        lbt3Data.LabBulkTestID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                        lbt3Data.TestingCompletionActual = (dr["TestingCompletionActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingCompletionActual"]);
                        lbt3Data.TestReportFilePath = (dr["TestReportFilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["TestReportFilePath"]);
                        lbt3Data.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                        lbt3Data.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                        lbt3Data.ClientID = (dr["ClientId"] != DBNull.Value) ? Convert.ToInt32(dr["ClientId"]) : labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                        lbt3Data.FabricName = (dr["FabricName"] != DBNull.Value) ? Convert.ToString(dr["FabricName"]) : labTest.OrderDetail.Fabric3.ToString();
                        lbt3Data.FabricDetail = (dr["FabricDetail"] != DBNull.Value) ? (labTest.PrintID3 > 0 ? "PRD:" + Convert.ToString(dr["FabricDetail"]) : Convert.ToString(dr["FabricDetail"])) : labTest.OrderDetail.Fabric3Details.ToString();
                        lbt3Data.OrderID = (dr["OrderId"] != DBNull.Value) ? Convert.ToInt32(dr["OrderId"]) : (lbt3Data.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                        labTest.LabBulkTest3.Add(lbt3Data);

                        if (LabBulkTest3Count == 0 && Convert.ToInt32(lbt3Data.Status) == -1)
                            LabBulkTest3Count = -1;
                        else if (LabBulkTest3Count == 0 && Convert.ToInt32(lbt3Data.Status) != 1)
                            LabBulkTest3Count = dtLabBulkTest3.Rows.Count;
                    }
                    if (LabBulkTest3Count == dtLabBulkTest3.Rows.Count)
                    {
                        LabBulkTest lbt3Fail = new LabBulkTest();
                        lbt3Fail.LabBulkTestID = -1;
                        lbt3Fail.TestingCompletionActual = DateTime.MinValue;
                        lbt3Fail.TestReportFilePath = string.Empty;
                        lbt3Fail.Status = -1;
                        lbt3Fail.Comments = string.Empty;
                        lbt3Fail.ClientID = labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                        lbt3Fail.FabricName = labTest.OrderDetail.Fabric3.ToString();
                        lbt3Fail.FabricDetail = labTest.OrderDetail.Fabric3Details.ToString();
                        lbt3Fail.OrderID = (lbt3Fail.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                        labTest.LabBulkTest3.Add(lbt3Fail);
                    }
                }
                else if (dtLabBulkTest3.Rows.Count == 0 && labTest.OrderDetail.Fabric3.Trim() != string.Empty)
                {
                    LabBulkTest lbt3NewRow = new LabBulkTest();
                    lbt3NewRow.LabBulkTestID = -1;
                    lbt3NewRow.TestingCompletionActual = DateTime.MinValue;
                    lbt3NewRow.TestReportFilePath = string.Empty;
                    lbt3NewRow.Status = -1;
                    lbt3NewRow.Comments = string.Empty;
                    lbt3NewRow.ClientID = labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                    lbt3NewRow.FabricName = labTest.OrderDetail.Fabric3.ToString();
                    lbt3NewRow.FabricDetail = labTest.OrderDetail.Fabric3Details.ToString();
                    lbt3NewRow.OrderID = (lbt3NewRow.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                    labTest.LabBulkTest3.Add(lbt3NewRow);
                }
            }

            DataTable dtLabBulkTest4 = dsLabTest.Tables[10];
            int LabBulkTest4Count = -1;
            if (
                (labTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
               &&
                (labTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
                &&
                (labTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                 labTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper() != labTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
               )
            {
                if (dtLabBulkTest4.Rows.Count > 0)
                {
                    LabBulkTest4Count = dtLabBulkTest4.Rows.Count;
                    foreach (DataRow dr in dtLabBulkTest4.Rows)
                    {
                        LabBulkTest4Count--;
                        LabBulkTest lbt4Data = new LabBulkTest();
                        lbt4Data.LabBulkTestID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                        lbt4Data.TestingCompletionActual = (dr["TestingCompletionActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingCompletionActual"]);
                        lbt4Data.TestReportFilePath = (dr["TestReportFilePath"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["TestReportFilePath"]);
                        lbt4Data.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                        lbt4Data.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                        lbt4Data.ClientID = (dr["ClientId"] != DBNull.Value) ? Convert.ToInt32(dr["ClientId"]) : labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                        lbt4Data.FabricName = (dr["FabricName"] != DBNull.Value) ? Convert.ToString(dr["FabricName"]) : labTest.OrderDetail.Fabric4.ToString();
                        lbt4Data.FabricDetail = (dr["FabricDetail"] != DBNull.Value) ? (labTest.PrintID4 > 0 ? "PRD:" + Convert.ToString(dr["FabricDetail"]) : Convert.ToString(dr["FabricDetail"])) : labTest.OrderDetail.Fabric4Details.ToString();
                        lbt4Data.OrderID = (dr["OrderId"] != DBNull.Value) ? Convert.ToInt32(dr["OrderId"]) : (lbt4Data.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                        labTest.LabBulkTest4.Add(lbt4Data);

                        if (LabBulkTest4Count == 0 && Convert.ToInt32(lbt4Data.Status) == -1)
                            LabBulkTest4Count = -1;
                        else if (LabBulkTest4Count == 0 && Convert.ToInt32(lbt4Data.Status) != 1)
                            LabBulkTest4Count = dtLabBulkTest4.Rows.Count;
                    }

                    if (LabBulkTest4Count == dtLabBulkTest4.Rows.Count)
                    {
                        LabBulkTest lbt4Fail = new LabBulkTest();
                        lbt4Fail.LabBulkTestID = -1;
                        lbt4Fail.TestingCompletionActual = DateTime.MinValue;
                        lbt4Fail.TestReportFilePath = string.Empty;
                        lbt4Fail.Status = -1;
                        lbt4Fail.Comments = string.Empty;
                        lbt4Fail.ClientID = labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                        lbt4Fail.FabricName = labTest.OrderDetail.Fabric4.ToString();
                        lbt4Fail.FabricDetail = labTest.OrderDetail.Fabric4Details.ToString();
                        lbt4Fail.OrderID = (lbt4Fail.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                        labTest.LabBulkTest4.Add(lbt4Fail);
                    }
                }
                else if (dtLabBulkTest4.Rows.Count == 0 && labTest.OrderDetail.Fabric4.Trim() != string.Empty)
                {
                    LabBulkTest lbt4NewRow = new LabBulkTest();
                    lbt4NewRow.LabBulkTestID = -1;
                    lbt4NewRow.TestingCompletionActual = DateTime.MinValue;
                    lbt4NewRow.TestReportFilePath = string.Empty;
                    lbt4NewRow.Status = -1;
                    lbt4NewRow.Comments = string.Empty;
                    lbt4NewRow.ClientID = labTest.OrderDetail.ParentOrder.Style.client.ClientID;
                    lbt4NewRow.FabricName = labTest.OrderDetail.Fabric4.ToString();
                    lbt4NewRow.FabricDetail = labTest.OrderDetail.Fabric4Details.ToString();
                    lbt4NewRow.OrderID = (lbt4NewRow.FabricDetail.ToString().ToUpper().IndexOf("PRD:") > -1 ? -1 : labTest.OrderDetail.ParentOrder.OrderID);
                    labTest.LabBulkTest4.Add(lbt4NewRow);
                }
            }

            return labTest;
        }

        public LabTest GetLabTestDataById(int LabTestID)
        {
            LabTest labTest = new LabTest();

            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_lab_test_get_lab_test_by_Id";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter param = new SqlParameter("@LabTestID", SqlDbType.Int);
                    param.Value = LabTestID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    DataSet dsLabTest = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dsLabTest);

                    labTest = ConvertDataSetToLabTestDataByLabTestID(dsLabTest);

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            return labTest;
        }

        private LabTest ConvertDataSetToLabTestDataByLabTestID(DataSet dsLabTest)
        {
            LabTest labTest = new LabTest();
            labTest.OrderDetail = new OrderDetail();
            labTest.LabGarmentTests = new List<LabGarmentTest>();
            labTest.LabInternalTests = new List<LabInternalTest>();

            DataTable dtlabTest = dsLabTest.Tables[0];
            if (dtlabTest.Rows.Count > 0)
            {
                DataRow row1 = dtlabTest.Rows[0];
                labTest.LabTestID = (row1["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["Id"]);
                labTest.OrderDetail.OrderDetailID = (row1["OrderDetailID"] == DBNull.Value) ? -1 : Convert.ToInt32(row1["OrderDetailID"]);
                labTest.ObservationsAndRemarks = (row1["Remarks"] == DBNull.Value) ? string.Empty : Convert.ToString(row1["Remarks"]);
            }

            DataTable dtLabGarmentTest = dsLabTest.Tables[1];
            int LabGarmentTestCount = -1;
            if (dtLabGarmentTest.Rows.Count > 0)
            {
                LabGarmentTestCount = dtLabGarmentTest.Rows.Count;
                foreach (DataRow dr in dtLabGarmentTest.Rows)
                {
                    LabGarmentTestCount--;
                    LabGarmentTest lgtData = new LabGarmentTest();
                    lgtData.LabTest = new LabTest();
                    lgtData.LabGarmentTestID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                    lgtData.LabTest.LabTestID = (dr["LabTestID"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["LabTestID"]);
                    lgtData.TestingCompletionActual = (dr["TestingCompletionActual"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingCompletionActual"]);
                    lgtData.TestingCompletionTarget = (dr["TestingCompletionTarget"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestingCompletionTarget"]);
                    lgtData.TestReportFilePaths = (dr["TestReportFilePaths"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["TestReportFilePaths"]);
                    lgtData.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                    lgtData.Comments = (dr["Comments"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["Comments"]);
                    labTest.LabGarmentTests.Add(lgtData);

                    if (LabGarmentTestCount == 0 && Convert.ToInt32(lgtData.Status) == -1)
                        LabGarmentTestCount = -1;
                    else if (LabGarmentTestCount == 0 && Convert.ToInt32(lgtData.Status) != 1)
                        LabGarmentTestCount = dtLabGarmentTest.Rows.Count;
                }
                if (LabGarmentTestCount == dtLabGarmentTest.Rows.Count)
                {
                    LabGarmentTest lgtFail = new LabGarmentTest();
                    lgtFail.LabTest = new LabTest();
                    lgtFail.LabGarmentTestID = -1;
                    lgtFail.LabTest.LabTestID = -1;
                    lgtFail.TestingCompletionActual = DateTime.MinValue;
                    lgtFail.TestingCompletionTarget = DateTime.MinValue;
                    lgtFail.TestReportFilePaths = string.Empty;
                    lgtFail.Status = -1;
                    lgtFail.Comments = string.Empty;
                    labTest.LabGarmentTests.Add(lgtFail);
                }
            }
            else if (dtLabGarmentTest.Rows.Count == 0)
            {
                LabGarmentTest lgtNewRow = new LabGarmentTest();
                lgtNewRow.LabTest = new LabTest();
                lgtNewRow.LabGarmentTestID = -1;
                lgtNewRow.LabTest.LabTestID = -1;
                lgtNewRow.TestingCompletionActual = DateTime.MinValue;
                lgtNewRow.TestingCompletionTarget = DateTime.MinValue;
                lgtNewRow.TestReportFilePaths = string.Empty;
                lgtNewRow.Status = -1;
                lgtNewRow.Comments = string.Empty;
                labTest.LabGarmentTests.Add(lgtNewRow);
            }

            DataTable dtLabInternalTest = dsLabTest.Tables[2];
            int LabInternalTestCount = -1;
            if (dtLabInternalTest.Rows.Count > 0)
            {
                LabInternalTestCount = dtLabInternalTest.Rows.Count;
                foreach (DataRow dr in dtLabInternalTest.Rows)
                {
                    LabInternalTestCount--;
                    LabInternalTest litData = new LabInternalTest();
                    litData.LabTest = new LabTest();
                    litData.LabInternalTestID = (dr["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Id"]);
                    litData.LabTest.LabTestID = (dr["LabTestID"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["LabTestID"]);
                    litData.WashCareCodePaths = (dr["WashCareCodePaths"] == DBNull.Value) ? String.Empty : Convert.ToString(dr["WashCareCodePaths"]);
                    litData.TestedOn = (dr["TestedOn"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TestedOn"]);
                    litData.ColorChange = (dr["ColorChange"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["ColorChange"]);
                    litData.Status = (dr["Status"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["Status"]);
                    litData.SelfStaining = (dr["SelfStaining"] == DBNull.Value) ? string.Empty : Convert.ToString(dr["SelfStaining"]);
                    litData.TestingOn = (dr["TestingOn"] == DBNull.Value) ? -1 : Convert.ToInt32(dr["TestingOn"]);
                    labTest.LabInternalTests.Add(litData);

                    if (LabInternalTestCount == 0 && Convert.ToInt32(litData.Status) == -1)
                        LabInternalTestCount = -1;
                    else if (LabInternalTestCount == 0 && Convert.ToInt32(litData.Status) != 1)
                        LabInternalTestCount = dtLabInternalTest.Rows.Count;
                }
                //if (LabInternalTestCount == dtLabInternalTest.Rows.Count)
                //{
                //    LabInternalTest litFail = new LabInternalTest();
                //    litFail.LabTest = new LabTest();
                //    litFail.LabInternalTestID = -1;
                //    litFail.LabTest.LabTestID = -1;
                //    litFail.TestedOn = DateTime.MinValue;
                //    litFail.TestingOn = -1;
                //    litFail.SelfStaining = string.Empty;
                //    litFail.Status = -1;
                //    litFail.ColorChange = string.Empty;
                //    labTest.LabInternalTests.Add(litFail);
                //}
            }
            else if (dtLabInternalTest.Rows.Count == 0)
            {
                LabInternalTest litNewRow = new LabInternalTest();
                litNewRow.LabTest = new LabTest();
                litNewRow.LabInternalTestID = -1;
                litNewRow.LabTest.LabTestID = -1;
                litNewRow.TestedOn = DateTime.MinValue;
                litNewRow.TestingOn = -1;
                litNewRow.SelfStaining = string.Empty;
                litNewRow.Status = -1;
                litNewRow.ColorChange = string.Empty;
                litNewRow.WashCareCodePaths = string.Empty;
                labTest.LabInternalTests.Add(litNewRow);
            }

            return labTest;
        }

        #endregion

        #region Insertion Methods

        public bool SaveLabTest(LabTest labTest)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                SqlTransaction transaction = null;

                try
                {
                    string cmdText = "sp_lab_test_save_lab_test";
                    cnx.Open();

                    transaction = cnx.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    cmd.Transaction = transaction;

                    SqlParameter outParam;
                    outParam = new SqlParameter("@d", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    SqlParameter param;

                    param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                    param.Value = labTest.OrderDetail.OrderDetailID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments1", SqlDbType.VarChar);
                    param.Value = labTest.Comments1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments2", SqlDbType.VarChar);
                    param.Value = labTest.Comments2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments3", SqlDbType.VarChar);
                    param.Value = labTest.Comments3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Comments4", SqlDbType.VarChar);
                    param.Value = labTest.Comments4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", SqlDbType.VarChar);
                    param.Value = labTest.ObservationsAndRemarks;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    int labTestID = Convert.ToInt32(outParam.Value);

                    foreach (PrintHistory printHistory in labTest.PrintHistory1)
                    {
                        SavePrintTestingHistory(printHistory, cnx, transaction);

                        if (printHistory.IsSendCommentsToLimitation == true && printHistory.Comments != string.Empty)
                        {
                            UpdateLimitationFabricRemarks(labTest.OrderDetail.OrderDetailID, printHistory.Comments, -1, -1, string.Empty, string.Empty, cnx, transaction);
                        }
                    }

                    foreach (PrintHistory printHistory in labTest.PrintHistory2)
                    {
                        SavePrintTestingHistory(printHistory, cnx, transaction);

                        if (printHistory.IsSendCommentsToLimitation == true && printHistory.Comments != string.Empty)
                        {
                            UpdateLimitationFabricRemarks(labTest.OrderDetail.OrderDetailID, printHistory.Comments, -1, -1, string.Empty, string.Empty, cnx, transaction);
                        }
                    }

                    foreach (PrintHistory printHistory in labTest.PrintHistory3)
                    {
                        SavePrintTestingHistory(printHistory, cnx, transaction);

                        if (printHistory.IsSendCommentsToLimitation == true && printHistory.Comments != string.Empty)
                        {
                            UpdateLimitationFabricRemarks(labTest.OrderDetail.OrderDetailID, printHistory.Comments, -1, -1, string.Empty, string.Empty, cnx, transaction);
                        }
                    }

                    foreach (PrintHistory printHistory in labTest.PrintHistory4)
                    {
                        SavePrintTestingHistory(printHistory, cnx, transaction);

                        if (printHistory.IsSendCommentsToLimitation == true && printHistory.Comments != string.Empty)
                        {
                            UpdateLimitationFabricRemarks(labTest.OrderDetail.OrderDetailID, printHistory.Comments, -1, -1, string.Empty, string.Empty, cnx, transaction);
                        }
                    }

                    foreach (LabBulkTest labBulkTest in labTest.LabBulkTest1)
                    {
                        if (labBulkTest.ClientID > 0 && !String.IsNullOrEmpty(labBulkTest.FabricName) && !String.IsNullOrEmpty(labBulkTest.FabricDetail))
                        {
                            SaveLabBulkTest(labBulkTest, cnx, transaction);
                        }
                    }

                    foreach (LabBulkTest labBulkTest in labTest.LabBulkTest2)
                    {
                        SaveLabBulkTest(labBulkTest, cnx, transaction);
                    }

                    foreach (LabBulkTest labBulkTest in labTest.LabBulkTest3)
                    {
                        SaveLabBulkTest(labBulkTest, cnx, transaction);
                    }

                    foreach (LabBulkTest labBulkTest in labTest.LabBulkTest4)
                    {
                        SaveLabBulkTest(labBulkTest, cnx, transaction);
                    }

                    foreach (LabGarmentTest labGarmentTest in labTest.LabGarmentTests)
                    {
                        labGarmentTest.LabTest = new LabTest();
                        labGarmentTest.LabTest.LabTestID = labTestID;
                        SaveLabGarmentTest(labGarmentTest, cnx, transaction);
                    }

                    foreach (LabInternalTest labInternalTest in labTest.LabInternalTests)
                    {
                        labInternalTest.LabTest = new LabTest();
                        labInternalTest.LabTest.LabTestID = labTestID;

                        if (labInternalTest.LabInternalTestID > 0 && labInternalTest.IsDelete == true)
                        {
                            DeleteLabInternalTest(labInternalTest.LabInternalTestID, cnx, transaction);
                        }
                        else
                        {
                            SaveLabInternalTest(labInternalTest, cnx, transaction);
                        }
                    }

                    transaction.Commit();
                    cnx.Close();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }

            return true;
        }

        public int SavePrintTestingHistory(PrintHistory PrintTesting, SqlConnection cnx, SqlTransaction transaction)
        {
            int printHistoryID;

            SqlDataAdapter adapter = new SqlDataAdapter();
            string cmdText = "sp_print_testing_history_save_print_testing_history";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.Transaction = transaction;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            SqlParameter outParam;
            outParam = new SqlParameter("@oId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;
            param = new SqlParameter("@d", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            param.Value = PrintTesting.PrintHistoryID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PrintID", SqlDbType.Int);
            param.Value = PrintTesting.ParentPrint.PrintID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TestingDate", SqlDbType.DateTime);
            param.Value = PrintTesting.TestingDate;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Comments", SqlDbType.VarChar);
            param.Value = PrintTesting.Comments;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Value = PrintTesting.Status;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PDFPath", SqlDbType.VarChar);
            param.Value = PrintTesting.PDFPath;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            printHistoryID = Convert.ToInt32(outParam.Value);

            //cnx.Close();

            return printHistoryID;
        }

        public bool SaveLabBulkTest(LabBulkTest labBulkTest, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_lab_bulk_test_save_lab_bulk_test";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@TestingCompletionActual", SqlDbType.DateTime);
            param.Value = labBulkTest.TestingCompletionActual;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Value = labBulkTest.Status;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TestReportFilePath", SqlDbType.VarChar);
            param.Value = labBulkTest.TestReportFilePath;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Comments", SqlDbType.VarChar);
            param.Value = labBulkTest.Comments;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ClientId", SqlDbType.Int);
            param.Value = labBulkTest.ClientID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderId", SqlDbType.Int);
            param.Value = labBulkTest.OrderID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricName", SqlDbType.VarChar);
            param.Value = labBulkTest.FabricName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            string FabricDetail = labBulkTest.FabricDetail.ToString().Trim().ToUpper().Contains("PRD:") ? labBulkTest.FabricDetail.ToString().Trim().ToUpper().Replace("PRD:", string.Empty) : labBulkTest.FabricDetail.ToString().Trim().ToUpper();
            param = new SqlParameter("@FabricDetail", SqlDbType.VarChar);
            param.Value = FabricDetail.Trim();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

            if (labBulkTest.IsSendCommentsToLimitation == true)
            {
                UpdateLimitationFabricRemarks(-1, labBulkTest.Comments, labBulkTest.ClientID, labBulkTest.OrderID, labBulkTest.FabricName, labBulkTest.FabricDetail.ToString().Trim(), cnx, transaction);
            }

            return true;
        }

        public bool SaveLabGarmentTest(LabGarmentTest labGarmentTest, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_lab_garment_test_save_lab_garment_test";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@oId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;
            param = new SqlParameter("@d", SqlDbType.Int);
            param.Value = labGarmentTest.LabGarmentTestID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LabTestID", SqlDbType.Int);
            param.Value = labGarmentTest.LabTest.LabTestID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TestingCompletionActual", SqlDbType.DateTime);
            param.Value = labGarmentTest.TestingCompletionActual;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TestingCompletionTarget", SqlDbType.DateTime);
            param.Value = labGarmentTest.TestingCompletionTarget;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Value = labGarmentTest.Status;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TestReportFilePaths", SqlDbType.VarChar);
            param.Value = labGarmentTest.TestReportFilePaths;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Comments", SqlDbType.VarChar);
            param.Value = labGarmentTest.Comments;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            int labGarmentTestID = Convert.ToInt32(outParam.Value);
            return true;
        }

        public bool SaveLabInternalTest(LabInternalTest labInternalTest, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_lab_internal_test_save_lab_internal_test";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter outParam;
            outParam = new SqlParameter("@oId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            SqlParameter param;

            param = new SqlParameter("@LabInternalTestID", SqlDbType.Int);
            param.Value = labInternalTest.LabInternalTestID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LabTestID", SqlDbType.Int);
            param.Value = labInternalTest.LabTest.LabTestID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TestedOn", SqlDbType.DateTime);
            param.Value = labInternalTest.TestedOn;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Status", SqlDbType.Int);
            param.Value = labInternalTest.Status;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@WashCareCodePaths", SqlDbType.VarChar);
            param.Value = labInternalTest.WashCareCodePaths;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ColorChange", SqlDbType.VarChar);
            param.Value = labInternalTest.ColorChange;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SelfStaining", SqlDbType.VarChar);
            param.Value = labInternalTest.SelfStaining;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TestingOn", SqlDbType.Int);
            param.Value = labInternalTest.TestingOn;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            int labInternalTestID = Convert.ToInt32(outParam.Value);
            return true;
        }

        #endregion

        #region Deletion Methods

        public bool DeleteLabInternalTest(int LabInternalTestID, SqlConnection cnx, SqlTransaction transaction)
        {
            string cmdText = "sp_lab_internal_test_delete_lab_internal_test";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
            cmd.Transaction = transaction;

            SqlParameter param;
            param = new SqlParameter("@LabInternalTestID", SqlDbType.Int);
            param.Value = LabInternalTestID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            return true;
        }

        #endregion

        #region Updation Methods

        public bool UpdateLimitationFabricRemarks(int OrderDetailID, String Comments, int ClientId, int OrderId, string FabricName, string FabricDetail, SqlConnection cnx, SqlTransaction transaction)
        {

            //cnx.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string cmdText = "sp_lab_test_update_order_limitation_fabric_remarks";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;

            param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
            param.Value = OrderDetailID;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Comments", SqlDbType.VarChar);
            param.Value = Comments;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ClientId", SqlDbType.Int);
            param.Value = ClientId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@FabricName", SqlDbType.VarChar);
            param.Value = FabricName;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            string fabDetails = FabricDetail.Trim().ToUpper().Contains("PRD:") ? FabricDetail.Trim().ToUpper().Replace("PRD:", string.Empty) : FabricDetail.Trim().ToUpper();
            int orderId = FabricDetail.Trim().ToUpper().Contains("PRD:") ? -1 : OrderId;

            param = new SqlParameter("@FabricDetail", SqlDbType.VarChar);
            param.Value = fabDetails;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OrderId", SqlDbType.Int);
            param.Value = orderId;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            return true;
        }


        #endregion


        public List<LabTest> GetBulkOrGarmetTestPendingEmail()
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataReader reader;
                SqlCommand cmd;
                string cmdText;

                cmdText = "sp_sent_bulk_or_garment_test_pending_email";
                cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                reader = cmd.ExecuteReader();

                List<LabTest> objLabTestList = new List<LabTest>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LabTest objLabTest = new LabTest();
                        objLabTest.LabTestID = (reader["LabTestID"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["LabTestID"]);

                        objLabTest.OrderDetail = new OrderDetail();
                        objLabTest.OrderDetail.ParentOrder = new Order();

                        string PrintCode1 = (reader["PrintNumber1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintNumber1"]);
                        string PrintCode2 = (reader["PrintNumber2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintNumber2"]);
                        string PrintCode3 = (reader["PrintNumber3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintNumber3"]);
                        string PrintCode4 = (reader["PrintNumber4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["PrintNumber4"]);

                        objLabTest.OrderDetail.OrderDetailID = (reader["Id"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["Id"]);
                        objLabTest.OrderDetail.BulkTarget = (reader["BulkTarget"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["BulkTarget"]);
                        objLabTest.OrderDetail.Fabric1 = (reader["Fabric1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1"]);
                        objLabTest.OrderDetail.Fabric2 = (reader["Fabric2"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2"]);
                        objLabTest.OrderDetail.Fabric3 = (reader["Fabric3"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3"]);
                        objLabTest.OrderDetail.Fabric4 = (reader["Fabric4"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4"]);

                        objLabTest.OrderDetail.Fabric1Details = (reader["Fabric1Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric1Details"]);
                        objLabTest.OrderDetail.Fabric2Details = (reader["Fabric2Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric2Details"]);
                        objLabTest.OrderDetail.Fabric3Details = (reader["Fabric3Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric3Details"]);
                        objLabTest.OrderDetail.Fabric4Details = (reader["Fabric4Details"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Fabric4Details"]);

                        objLabTest.OrderDetail.Fabric1Details = (PrintCode1 == string.Empty) ? objLabTest.OrderDetail.Fabric1Details : "PRD: " + objLabTest.OrderDetail.Fabric1Details;
                        objLabTest.OrderDetail.Fabric2Details = (PrintCode2 == string.Empty) ? objLabTest.OrderDetail.Fabric2Details : "PRD: " + objLabTest.OrderDetail.Fabric2Details;
                        objLabTest.OrderDetail.Fabric3Details = (PrintCode3 == string.Empty) ? objLabTest.OrderDetail.Fabric3Details : "PRD: " + objLabTest.OrderDetail.Fabric3Details;
                        objLabTest.OrderDetail.Fabric4Details = (PrintCode4 == string.Empty) ? objLabTest.OrderDetail.Fabric4Details : "PRD: " + objLabTest.OrderDetail.Fabric4Details;

                        objLabTest.OrderDetail.ParentOrder.OrderID = (reader["OrderId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["OrderId"]);
                        objLabTest.OrderDetail.ParentOrder.OrderDate = (reader["OrderDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["OrderDate"]);
                        objLabTest.OrderDetail.ParentOrder.SerialNumber = (reader["SerialNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SerialNumber"]);

                        objLabTest.OrderDetail.ParentOrder.Style = new Style();
                        objLabTest.OrderDetail.ParentOrder.Style.StyleNumber = (reader["StyleNumber"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["StyleNumber"]);
                        objLabTest.OrderDetail.ParentOrder.Style.SampleImageURL1 = (reader["SampleImageURL1"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["SampleImageURL1"]);

                        objLabTest.OrderDetail.ParentOrder.Style.client = new Client();
                        objLabTest.OrderDetail.ParentOrder.Style.client.CompanyName = (reader["Buyer"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["Buyer"]);
                        objLabTest.OrderDetail.ParentOrder.Style.client.ClientID = (reader["ClientId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["ClientId"]);

                        objLabTest.OrderDetail.ParentOrder.Style.cdept = new ClientDepartment();
                        objLabTest.OrderDetail.ParentOrder.Style.cdept.Name = (reader["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(reader["DepartmentName"]);

                        objLabTest.OrderDetail.ParentOrder.FabricApprovalDetails = new FabricApprovalDetails();
                        objLabTest.OrderDetail.ParentOrder.FabricApprovalDetails.F1ActionDate = (reader["ActionDate1"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate1"]);
                        objLabTest.OrderDetail.ParentOrder.FabricApprovalDetails.F2ActionDate = (reader["ActionDate2"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate2"]);
                        objLabTest.OrderDetail.ParentOrder.FabricApprovalDetails.F3ActionDate = (reader["ActionDate3"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate3"]);
                        objLabTest.OrderDetail.ParentOrder.FabricApprovalDetails.F4ActionDate = (reader["ActionDate4"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(reader["ActionDate4"]);

                        objLabTest.labGarmetTest = new LabGarmentTest();
                        objLabTest.labGarmetTest.LabGarmentTestID = (reader["LabGarmetTestId"] == DBNull.Value) ? -1 : Convert.ToInt32(reader["LabGarmetTestId"]);
                        objLabTest.labGarmetTest.Status = (reader["LabGarmetTestStatus"] == DBNull.Value) ? -2 : Convert.ToInt32(reader["LabGarmetTestStatus"]);

                        objLabTest.labBulkTest1 = new LabBulkTest();
                        objLabTest.labBulkTest1.Status = (reader["lbt1Satatus"] == DBNull.Value) ? -2 : Convert.ToInt32(reader["lbt1Satatus"]);

                        objLabTest.labBulkTest2 = new LabBulkTest();
                        objLabTest.labBulkTest2.Status = -2;

                        if (
                            (objLabTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() ||
                             objLabTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper())
                           )
                        {
                            objLabTest.labBulkTest2.Status = (reader["lbt2Satatus"] == DBNull.Value) ? -2 : Convert.ToInt32(reader["lbt2Satatus"]);
                        }

                        objLabTest.labBulkTest3 = new LabBulkTest();
                        objLabTest.labBulkTest3.Status = -2;

                        if (
                          (objLabTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() ||
                           objLabTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper())
                            &&
                             (objLabTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() ||
                           objLabTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper())
                            )
                        {
                            objLabTest.labBulkTest3.Status = (reader["lbt3Satatus"] == DBNull.Value) ? -2 : Convert.ToInt32(reader["lbt3Satatus"]);
                        }

                        objLabTest.labBulkTest4 = new LabBulkTest();
                        objLabTest.labBulkTest4.Status = -2;

                        if (
                          (objLabTest.OrderDetail.Fabric1.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                           objLabTest.OrderDetail.Fabric1Details.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
                            &&
                             (objLabTest.OrderDetail.Fabric2.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                           objLabTest.OrderDetail.Fabric2Details.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
                            &&
                             (objLabTest.OrderDetail.Fabric3.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric4.ToString().Trim().ToUpper() ||
                           objLabTest.OrderDetail.Fabric3Details.ToString().Trim().ToUpper() != objLabTest.OrderDetail.Fabric4Details.ToString().Trim().ToUpper())
                            )
                        {
                            objLabTest.labBulkTest4.Status = (reader["lbt4Satatus"] == DBNull.Value) ? -2 : Convert.ToInt32(reader["lbt4Satatus"]);
                        }

                        objLabTestList.Add(objLabTest);
                    }
                }
                cnx.Close();
                return objLabTestList;
            }
        }


    }
}
