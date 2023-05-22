using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class LabTest
    {
        public int LabTestID
        {
            get;
            set;
        }

        public OrderDetail OrderDetail
        {
            get;
            set;
        }

        public string ObservationsAndRemarks
        {
            get;
            set;
        }
       

        public string BaseTestFile1
        {
            get;
            set;
        }

        public string BaseTestFile2
        {
            get;
            set;
        }

        public string BaseTestFile3
        {
            get;
            set;
        }

        public string BaseTestFile4
        {
            get;
            set;
        }

        public string Comments1
        {
            get;
            set;
        }
        public string Comments2
        {
            get;
            set;
        }

        public string Comments3
        {
            get;
            set;
        }

        public string Comments4
        {
            get;
            set;
        }

        public int FabricQualityID1
        {
            get;
            set;
        }

        public int FabricQualityID2
        {
            get;
            set;
        }

        public int FabricQualityID3
        {
            get;
            set;
        }

        public int FabricQualityID4
        {
            get;
            set;
        }

        public int PrintID1
        {
            get;
            set;
        }

        public int PrintID2
        {
            get;
            set;
        }

        public int PrintID3
        {
            get;
            set;
        }

        public int PrintID4
        {
            get;
            set;
        }

        public List<PrintHistory> PrintHistory1
        {
            get;
            set;
        }

        public List<PrintHistory> PrintHistory2
        {
            get;
            set;
        }

        public List<PrintHistory> PrintHistory3
        {
            get;
            set;
        }

        public List<PrintHistory> PrintHistory4
        {
            get;
            set;
        }

        public List<LabBulkTest> LabBulkTest1
        {
            get;
            set;
        }

        public LabBulkTest labBulkTest1
        {
            get;
            set;
        }

        public List<LabBulkTest> LabBulkTest2
        {
            get;
            set;
        }

        public LabBulkTest labBulkTest2
        {
            get;
            set;
        }


        public List<LabBulkTest> LabBulkTest3
        {
            get;
            set;
        }
        public LabBulkTest labBulkTest3
        {
            get;
            set;
        }

        public List<LabBulkTest> LabBulkTest4
        {
            get;
            set;
        }

        public LabBulkTest labBulkTest4
        {
            get;
            set;
        }


        public List<LabGarmentTest> LabGarmentTests
        {
            get;
            set;
        }

        public LabGarmentTest labGarmetTest
        {
            get;
            set;
        }

        public List<LabInternalTest> LabInternalTests
        {
            get;
            set;
        }
    }

    public class LabInternalTest
    {
        public int LabInternalTestID
        {
            get;
            set;
        }

        public LabTest LabTest
        {
            get;
            set;
        }

        public string WashCareCodePaths
        {
            get;
            set;
        }

        public string ColorChange
        {
            get;
            set;
        }

        public string SelfStaining
        {
            get;
            set;
        }

        public int TestingOn
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public bool IsDelete
        {
            get;
            set;
        }

        public DateTime TestedOn
        {
            get;
            set;
        }
    }

    public class LabGarmentTest
    {
        public int LabGarmentTestID
        {
            get;
            set;
        }

        public LabTest LabTest
        {
            get;
            set;
        }

        public DateTime TestingCompletionTarget
        {
            get;
            set;
        }

        public string TestReportFilePaths
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public DateTime TestingCompletionActual
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }
    }

    public class LabBulkTest
    {
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

        public string FabricDetail
        {
            get;
            set;
        }

        public int OrderID
        {
            get;
            set;
        }

        public int LabBulkTestID
        {
            get;
            set;
        }

        //public LabTest LabTest
        //{
        //    get;
        //    set;
        //}

        public DateTime TestingCompletionActual
        {
            get;
            set;
        }

        public string TestReportFilePath
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }        

        public int Status
        {
            get;
            set;
        }

        //public int FabricSerialNo
        //{
        //    get;
        //    set;
        //}

        public bool IsSendCommentsToLimitation
        {
            get;
            set;
        }
    }    
}
