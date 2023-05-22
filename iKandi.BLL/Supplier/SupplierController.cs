using System.Collections.Generic;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class SupplierController : BaseController
    {
        #region Ctor(s)
        public SupplierController()
        {
        }

        public SupplierController(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }
        #endregion
        public SupplierTables GetAllSupplierTables()
        {
            return this.SupplierDataProviderInstance.GetAllSupplierTables();
        }

        public int Insert_Update_SupplierTables(SupplierTables stbls)
        {
            return this.SupplierDataProviderInstance.Insert_Update_SupplierTables(stbls);

        }

        public SupplierTables GetSupplierTableById(int id)
        {
            return this.SupplierDataProviderInstance.GetSupplierTableById(id);
        }

        public List<SupplierContact> GetContactsBySupplierId(int supplierid)
        {
            return this.SupplierDataProviderInstance.GetContactsBySupplierId(supplierid);
        }

        public string GetGroupName(string gName)
        {
            return this.SupplierDataProviderInstance.GetGroupName(gName);
        }

        public int GetDuplicateSupplier(string gName, string sName, int sid)
        {
            return this.SupplierDataProviderInstance.GetDuplicateSupplier(gName, sName, sid);
        }

        public DataSet GetSupplierTableList(SupplierSearch ss)
        {
            return this.SupplierDataProviderInstance.GetSupplierTableList(ss);
        }

        public List<SupplierList> GetSupplierTableLists(SupplierSearch ss)
        {
            return this.SupplierDataProviderInstance.GetSupplierTableLists(ss);
        }

        public List<string> GetGroupNameByName(string type)
        {
            return this.SupplierDataProviderInstance.GetGroupNameByName(type);
        }

        public List<string> GetSupplierNameByName(string type)
        {
            return this.SupplierDataProviderInstance.GetSupplierNameByName(type);
        }

        public List<string> GetSupplierNameWithGroupByName(string type)
        {
            return this.SupplierDataProviderInstance.GetSupplierNameWithGroupByName(type);
        }

        public string GetSupplierAddressByNameWithGroup(string type)
        {
            return this.SupplierDataProviderInstance.GetSupplierAddressByNameWithGroup(type);
        }

        public string GetDuplicateGroupInit(string gInit, int sid)
        {
            return this.SupplierDataProviderInstance.GetDuplicateGroupInit(gInit, sid);
        }

        public int GetDuplicateSupplierInit(string sInit, int sid)
        {
            return this.SupplierDataProviderInstance.GetDuplicateSupplierInit(sInit, sid);
        }

        public int GetDuplicateGroupName(string gName, int sid)
        {
            return this.SupplierDataProviderInstance.GetDuplicateGroupName(gName, sid);
        }

        public int GetSupplierIdByNameWithGroup(string name)
        {
            return this.SupplierDataProviderInstance.GetSupplierIdByNameWithGroup(name);
        }

        public string GetSupplierInitialByName(string name)
        {
            return this.SupplierDataProviderInstance.GetSupplierInitialByName(name);
        }

        public List<Supplier> GetSupplierInit(string name) 
        {
            return this.SupplierDataProviderInstance.GetSupplierInit(name);
        }
        public List<Supplier> CheckGroupSupplierBAL(string GroupName, string SupName, string hdnSuppName)
        {
            return this.SupplierDataProviderInstance.CheckGroupSupplierDAL(GroupName, SupName, hdnSuppName);
        }
        public int InsertUpdateSuppilerBAL(List<SupplierContact> pos, Supplier prm_SupplierClass)
        {
            return this.SupplierDataProviderInstance.InsertUpdateSuppilerDAL(pos, prm_SupplierClass);
        }
        public DataTable SelectPamentBAL()
        {
            return this.SupplierDataProviderInstance.GetPaymentAdmin();
        }         
        public List<SupplierList> GetSupplierLists(SupplierSearch ss)
        {
            return this.SupplierDataProviderInstance.GetSupplierLists(ss);
        }
        public List<SupplierContact> GetContactsById(int supplierid)
        {
            return this.SupplierDataProviderInstance.GetContactsById(supplierid);
        }
        public DataTable GetSupplierById(int SupplierId)
        { 
            return this.SupplierDataProviderInstance.GetSupplierById(SupplierId);
        }

        public string GetSupplierCode(int Flag, string SupplierName, string Type)
        {
            return this.SupplierDataProviderInstance.GetSupplierCode(Flag, SupplierName, Type);
        }
        // Add Code By Bharat on 25-Aug-20 
        public string SupplierCodeValidate(int Flag, string SupplierCode, int SupplierId)
        {
            return this.SupplierDataProviderInstance.SupplierCodeValidate(Flag, SupplierCode, SupplierId);
        }

        public string SupplierEmailValidate(int Flag, string SupplierEmail, int grdsupId)
        {
            return this.SupplierDataProviderInstance.SupplierEmailValidate(Flag, SupplierEmail, grdsupId);
        }
    }
}
