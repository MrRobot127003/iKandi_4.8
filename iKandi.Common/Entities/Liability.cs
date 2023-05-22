using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;


namespace iKandi.Common
{
  public class Liability
  {
    public int Id
    {
      get;
      set;
    }

    public OrderDetail OrderDetail
    {
      get;
      set;
    }

    public DateTime DateCancelled
    {
      get;
      set;
    }

    public int QuantityCancelled
    {
      get;
      set;
    }

    public DateTime InvoiceDate
    {
      get;
      set;
    }

    public int PaymentStatus
    {
      get;
      set;
    }

    public string Owner
    {
      get;
      set;
    }

    public string MerchantRemarks
    {
      get;
      set;
    }

    public string DocumentationRemarks
    {
      get;
      set;
    }

    public double Fabric1Price
    {
      get;
      set;
    }

    public double Fabric2Price
    {
      get;
      set;
    }

    public double Fabric3Price
    {
      get;
      set;
    }

    public double Fabric4Price
    {
      get;
      set;
    }


    public double Fabric1Average
    {
        get;
        set;
    }

    public double Fabric2Average
    {
        get;
        set;
    }

    public double Fabric3Average
    {
        get;
        set;
    }

    public double Fabric4Average
    {
        get;
        set;
    }

    public double Fabric1Length
    {
      get;
      set;
    }

    public double Fabric2Length
    {
      get;
      set;
    }

    public double Fabric3Length
    {
      get;
      set;
    }

    public double Fabric4Length
    {
      get;
      set;
    }

    public double CancellationCost
    {
      get;
      set;
    }

    public double Fabric1Quantity
    {
      get;
      set;
    }

    public double Fabric2Quantity
    {
      get;
      set;
    }

    public double Fabric3Quantity
    {
      get;
      set;
    }

    public double Fabric4Quantity
    {
      get;
      set;
    }

    public List<LiabilityAccessory> AccessoryLiability
    {
      get;
      set;
    }

    public DateTime HoldTillDate
    {
        get;
        set;
    }

    public string LiabilityDocuments
    {
        get;
        set;
    }

    public int IkandiAcknowledge
    {
        get;
        set;
    }

    public int AcceptanceToSettle
    {
        get;
        set;
    }

    public int RaiseCustomerInvoice
    {
        get;
        set;
    }

    public string InvoiceNumber
    {
        get;
        set;
    }

    public DateTime AcknowledgementDate
    {
        get;
        set;
    }

    public DateTime SettlementDate
    {
        get;
        set;
    }

    public DateTime InvoiceRaisedDate
    {
        get;
        set;
    }

    public string LiabilityNumber
    {
        get;
        set;
    }
  }

  public class LiabilityAccessory
  {
    public int Id
    {
      get;
      set;
    }

    public double Amount
    {
      get;
      set;
    }

    public double Cost
    {
      get;
      set;
    }

    public int LiabilityID
    {
      get;
      set;
    }

    public int TotalQuantity
    {
      get;
      set;
    }

    public AccessoryWorkingDetail AccessoryWorkingDetail
    {
      get;
      set;
    }
    
  }
}
