using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using iKandi.Common.Entities;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public int GetDuplicateSrvByPoId_BillNo(int poId, string billNo,int srvId)
        {
            return this.SRVControllerInstance.GetDuplicateSrvByPoId_BillNo(poId, billNo, srvId);
        }

        [WebMethod(EnableSession = true)]
        public string GetSupplierInitialByName(string name)
        {
            return this.SupplierControllerInstance.GetSupplierInitialByName(name);
        }

        [WebMethod(EnableSession = true)]
        public List<Supplier> GetDupSupplierInit(string sName)
        {
            return this.SupplierControllerInstance.GetSupplierInit(sName); 

        }//GetDuplicateSupplierInit


        [WebMethod(EnableSession = true)]
        public List<Supplier> CheckGroupSupplier(string gName, string sName, string hdnSuppName)
        {

            return this.SupplierControllerInstance.CheckGroupSupplierBAL(gName, sName, hdnSuppName);

        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestGroupNameNumberCode(string q, int limit)
        { 
            return SuggestForAutoComplete(q, AutoComplete.GroupName.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public List<string> SuggestSupplierNameNumberCode(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.SupplierName.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public List<SupplierContact> GetContactsById(int supplierId)
        {
            return this.SupplierControllerInstance.GetContactsById(supplierId);
        }
        [WebMethod(EnableSession = true)]
        public string GetSupplierCode(int Flag, string SupplierName, string Type)
        {
            return this.SupplierControllerInstance.GetSupplierCode(Flag, SupplierName, Type);
        }        

        //Add code by Bharat on 25-Aug-20
        [WebMethod(EnableSession = true)]
        public string SupplierCodeValidate(int Flag, string SupplierCode,int SupplierId)
        {
            return this.SupplierControllerInstance.SupplierCodeValidate(Flag, SupplierCode, SupplierId);
        }
        [WebMethod(EnableSession = true)]
        public string SupplierEmailValidate(int Flag, string SupplierEmail, int grdsupId)
        {
            return this.SupplierControllerInstance.SupplierEmailValidate(Flag, SupplierEmail, grdsupId);
        }

    } 
} 
