using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    [Serializable]
    public class WashingCuttingTotal : EntityBasetable
    {
        public int WahingCompleted
        {
            get; set;
        }

        public int CuttingCompleted
        {
            get;
            set;
        }

        public int WashingId
        {
            get;
            set;
        }

        public int CuttingId
        {
            get;
            set;
        }

        public double AvgLength
        {
            get;
            set;
        }

        public int StockId
        {
            get;
            set;
        }

        public int CutStockId
        {
            get;
            set;
        }

        public int OrderDetailId
        {
            get;
            set;
        }

        public string FabricName
        {
            get;
            set;
        }

        public string FactoryName
        {
            get;
            set;
        }

        public string FabricDetails
        {
            get;
            set;
        }

        public int ProcessId
        {
            get;
            set;
        }

        public double QtyWashIssued
        {
            get; set;
        }

        public double QtyWashIssuedTotal
        {
            get;
            set;
        }

        public double QtyWashReceived
        {
            get;
            set;
        }

        public double QtyWashReceivedTotal
        {
            get;
            set;
        }

        public double QtyCutIssued
        {
            get;
            set;
        }

        public double QtyCutIssuedTotal
        {
            get;
            set;
        }

        public int IsCompleteWash
        {
            get;
            set;
        }

        public int IsCompleteCut
        {
            get;
            set;
        }

        public double QtyCutReceived
        {
            get;
            set;
        }

        public double QtyCutReceivedTotal
        {
            get;
            set;
        }

        public int IsWashingRequired
        {
            get;
            set;
        }

        public int MasterPoId
        {
            get;
            set;
        }

        public int OrderDetailNumber
        {
            get;
            set;
        }
    }

    [Serializable]
    public class WCTList : List<WashingCuttingTotal>
    {

    } 

    [Serializable]
    public class WashingCutting : WashingCuttingTotal
    {
        public string StyleNumber
        {
            get;
            set;
        }

        public string Buyer
        {
            get;
            set;
        }

        public string Department
        {
            get;
            set;
        }

        public DateTime OrderDate
        {
            get;
            set;
        }

        public string OrderNumber
        {
            get;
            set;
        }

        public int Pieces
        {
            get;
            set;
        }

        public string ContractNumber
        {
            get;
            set;
        }

        public string LineItemNumber
        {
            get;
            set;
        }

        public string PrintColor
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public double AvgLength
        {
            get;
            set;
        }

        public double Requirement
        {
            get;
            set;
        }

        public double FcPerc
        {
            get;
            set;
        }

        public double SrvApprove
        {
            get;
            set;
        }

        public double FourptApproved
        {
            get;
            set;
        }

        public double FPRQuantity
        {
            get;
            set;
        }

        public double FPWQuantity
        {
            get;
            set;
        }

        public double OdSrv
        {
            get;
            set;
        }

        public int OrderId
        {
            get;
            set;
        }

        public double SrvQuantity
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }

        public int StyleId
        {
            get;
            set;
        }

        public double WashingPerc
        {
            get;
            set;
        }

        public double CuttingPerc
        {
            get;
            set;
        }

        public double Balance
        {
            get;
            set;
        }

        public double CuttingBalance
        {
            get;
            set;
        }

        public double CuttingRequirement
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }
    }

    [Serializable]
    public class WashingCuttingList : List<WashingCutting>
    {
        
    } 

    [Serializable]
    public class FabricSrvQuantity : EntityBasetable
    {
        public string FabricName
        {
            get; set;
        }

        public string FabricDetails
        {
            get;
            set;
        }

        public double Quantity
        {
            get; set;
        }
    }

    [Serializable]
    public class FSQList : List<FabricSrvQuantity>
    {

    }

    [Serializable]
    public class IIChallan_Main : EntityBasetable
    {
        public string ChallanNo
        {
            get; set;
        }

        public string FactoryName
        {
            get;
            set;
        }

        public string ChallanType
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public int FactoryId
        {
            get;
            set;
        }

        public string ChallanFrom
        {
            get;
            set;
        }

        public string ChallanTo
        {
            get;
            set;
        }

        public DateTime ChallanDate
        {
            get; set;
        }

        public int IssuedBy
        {
            get; set;
        }

        public string IssuedName
        {
            get;
            set;
        }
    }

    [Serializable]
    public class IIChallan_Detail : IIChallan_Main
    {
        public string Remarks
        {
            get;
            set;
        }

        public string FabricName
        {
            get;
            set;
        }

        public string PrintColor
        {
            get;
            set;
        }

        public int ChallanId
        {
            get;
            set;
        }


        public int OrderDetailid
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }
    }

    [Serializable]
    public class IICDList : List<IIChallan_Detail>
    {

    }

    [Serializable]
    public class IicdAll : IIChallan_Detail
    {
        public string Buyer
        {
            get; set;
        }

        public string SerialNo
        {
            get;
            set;
        }

        public string StyleNo
        {
            get;
            set;
        }

        public string LineNo
        {
            get;
            set;
        }

        public string ContractNo
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }
    }

    [Serializable]
    public class IicdPage : EntityBasetable
    {
        public DataTable Factory
        {
            get; set;
        }

        public IIChallan_Main Icm
        {
            get; set;
        }

        public List<IicdAll> LstIIcdAll
        {
            get; set;
        }
    }
}
