﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inv.DAL.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InvEntities : DbContext
    {
        public InvEntities()
            : base("name=InvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATEGRE> CATEGRES { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<Enter_Money> Enter_Money { get; set; }
        public virtual DbSet<familly_Cat> familly_Cat { get; set; }
        public virtual DbSet<G_AlertControl> G_AlertControl { get; set; }
        public virtual DbSet<G_AlertLog> G_AlertLog { get; set; }
        public virtual DbSet<G_AlertType> G_AlertType { get; set; }
        public virtual DbSet<G_BRANCH> G_BRANCH { get; set; }
        public virtual DbSet<G_Codes> G_Codes { get; set; }
        public virtual DbSet<G_COMPANY> G_COMPANY { get; set; }
        public virtual DbSet<G_CONTROL> G_CONTROL { get; set; }
        public virtual DbSet<G_Currency> G_Currency { get; set; }
        public virtual DbSet<G_ModuleHelp> G_ModuleHelp { get; set; }
        public virtual DbSet<G_MODULES> G_MODULES { get; set; }
        public virtual DbSet<G_Noteifications> G_Noteifications { get; set; }
        public virtual DbSet<G_NotificationCompany> G_NotificationCompany { get; set; }
        public virtual DbSet<G_PaperSize> G_PaperSize { get; set; }
        public virtual DbSet<G_REGION> G_REGION { get; set; }
        public virtual DbSet<G_REGION_BRANCH> G_REGION_BRANCH { get; set; }
        public virtual DbSet<G_Role> G_Role { get; set; }
        public virtual DbSet<G_RoleModule> G_RoleModule { get; set; }
        public virtual DbSet<G_RoleUsers> G_RoleUsers { get; set; }
        public virtual DbSet<G_SearchForm> G_SearchForm { get; set; }
        public virtual DbSet<G_SearchFormModule> G_SearchFormModule { get; set; }
        public virtual DbSet<G_SearchFormSetting> G_SearchFormSetting { get; set; }
        public virtual DbSet<G_SUB_SYSTEMS> G_SUB_SYSTEMS { get; set; }
        public virtual DbSet<G_SYSTEM> G_SYSTEM { get; set; }
        public virtual DbSet<G_TransCounter> G_TransCounter { get; set; }
        public virtual DbSet<G_TransCounterSetting> G_TransCounterSetting { get; set; }
        public virtual DbSet<G_USER_BRANCH> G_USER_BRANCH { get; set; }
        public virtual DbSet<G_USER_COMPANY> G_USER_COMPANY { get; set; }
        public virtual DbSet<G_USER_LOG> G_USER_LOG { get; set; }
        public virtual DbSet<G_USERS> G_USERS { get; set; }
        public virtual DbSet<I_Control> I_Control { get; set; }
        public virtual DbSet<ORDER_DELIVERY> ORDER_DELIVERY { get; set; }
        public virtual DbSet<Outlet> Outlets { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<Purchases_Details> Purchases_Details { get; set; }
        public virtual DbSet<Purchases_Master> Purchases_Master { get; set; }
        public virtual DbSet<Report_Parameters> Report_Parameters { get; set; }
        public virtual DbSet<Settings_Report> Settings_Report { get; set; }
        public virtual DbSet<Stok_ORDER_DELIVERY> Stok_ORDER_DELIVERY { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Table_two_days> Table_two_days { get; set; }
        public virtual DbSet<The_Gard> The_Gard { get; set; }
        public virtual DbSet<HIJRA_CONVERT> HIJRA_CONVERT { get; set; }
        public virtual DbSet<GQ_GetUserBarnchAccess> GQ_GetUserBarnchAccess { get; set; }
        public virtual DbSet<GQ_GetUserBranch> GQ_GetUserBranch { get; set; }
        public virtual DbSet<GQ_GetUserModule> GQ_GetUserModule { get; set; }
        public virtual DbSet<GQ_GetUserRole> GQ_GetUserRole { get; set; }
        public virtual DbSet<GQ_GetUsers> GQ_GetUsers { get; set; }
        public virtual DbSet<GQ_Notifications> GQ_Notifications { get; set; }
        public virtual DbSet<GQ_ReportWebSetting> GQ_ReportWebSetting { get; set; }
        public virtual DbSet<I_VW_GetCompStatus> I_VW_GetCompStatus { get; set; }
        public virtual DbSet<IQ_Outlet> IQ_Outlet { get; set; }
        public virtual DbSet<IQ_Purchases_Details> IQ_Purchases_Details { get; set; }
        public virtual DbSet<IQ_Purchases_Master> IQ_Purchases_Master { get; set; }
        public virtual DbSet<ReviewSalesItemInfo> ReviewSalesItemInfoes { get; set; }
        public virtual DbSet<ReviewSalesMaster> ReviewSalesMasters { get; set; }
    
        [DbFunction("InvEntities", "GFun_Companies")]
        public virtual IQueryable<GFun_Companies_Result> GFun_Companies(string userCode)
        {
            var userCodeParameter = userCode != null ?
                new ObjectParameter("userCode", userCode) :
                new ObjectParameter("userCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GFun_Companies_Result>("[InvEntities].[GFun_Companies](@userCode)", userCodeParameter);
        }
    
        [DbFunction("InvEntities", "GFun_UserCompanyBranch")]
        public virtual IQueryable<GFun_UserCompanyBranch_Result> GFun_UserCompanyBranch(string userCode, Nullable<int> compCode)
        {
            var userCodeParameter = userCode != null ?
                new ObjectParameter("userCode", userCode) :
                new ObjectParameter("userCode", typeof(string));
    
            var compCodeParameter = compCode.HasValue ?
                new ObjectParameter("CompCode", compCode) :
                new ObjectParameter("CompCode", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GFun_UserCompanyBranch_Result>("[InvEntities].[GFun_UserCompanyBranch](@userCode, @CompCode)", userCodeParameter, compCodeParameter);
        }
    
        [DbFunction("InvEntities", "GFunc_GetPrivilage")]
        public virtual IQueryable<GFunc_GetPrivilage_Result> GFunc_GetPrivilage(Nullable<int> year, Nullable<int> comp, Nullable<int> bra, string user, string sys, string mod)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var compParameter = comp.HasValue ?
                new ObjectParameter("Comp", comp) :
                new ObjectParameter("Comp", typeof(int));
    
            var braParameter = bra.HasValue ?
                new ObjectParameter("bra", bra) :
                new ObjectParameter("bra", typeof(int));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var sysParameter = sys != null ?
                new ObjectParameter("Sys", sys) :
                new ObjectParameter("Sys", typeof(string));
    
            var modParameter = mod != null ?
                new ObjectParameter("Mod", mod) :
                new ObjectParameter("Mod", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GFunc_GetPrivilage_Result>("[InvEntities].[GFunc_GetPrivilage](@year, @Comp, @bra, @user, @Sys, @Mod)", yearParameter, compParameter, braParameter, userParameter, sysParameter, modParameter);
        }
    
        [DbFunction("InvEntities", "GFunc_GetPrivilageOld")]
        public virtual IQueryable<GFunc_GetPrivilageOld_Result> GFunc_GetPrivilageOld(Nullable<int> comp, Nullable<int> bra, string user, string sys, string sub, string mod)
        {
            var compParameter = comp.HasValue ?
                new ObjectParameter("Comp", comp) :
                new ObjectParameter("Comp", typeof(int));
    
            var braParameter = bra.HasValue ?
                new ObjectParameter("bra", bra) :
                new ObjectParameter("bra", typeof(int));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var sysParameter = sys != null ?
                new ObjectParameter("Sys", sys) :
                new ObjectParameter("Sys", typeof(string));
    
            var subParameter = sub != null ?
                new ObjectParameter("sub", sub) :
                new ObjectParameter("sub", typeof(string));
    
            var modParameter = mod != null ?
                new ObjectParameter("Mod", mod) :
                new ObjectParameter("Mod", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GFunc_GetPrivilageOld_Result>("[InvEntities].[GFunc_GetPrivilageOld](@Comp, @bra, @user, @Sys, @sub, @Mod)", compParameter, braParameter, userParameter, sysParameter, subParameter, modParameter);
        }
    
        [DbFunction("InvEntities", "GFunc_GetPrivilageRole")]
        public virtual IQueryable<GFunc_GetPrivilageRole_Result> GFunc_GetPrivilageRole(Nullable<int> comp, Nullable<int> bra, string user, string sys, string sub, string mod)
        {
            var compParameter = comp.HasValue ?
                new ObjectParameter("Comp", comp) :
                new ObjectParameter("Comp", typeof(int));
    
            var braParameter = bra.HasValue ?
                new ObjectParameter("bra", bra) :
                new ObjectParameter("bra", typeof(int));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var sysParameter = sys != null ?
                new ObjectParameter("Sys", sys) :
                new ObjectParameter("Sys", typeof(string));
    
            var subParameter = sub != null ?
                new ObjectParameter("sub", sub) :
                new ObjectParameter("sub", typeof(string));
    
            var modParameter = mod != null ?
                new ObjectParameter("Mod", mod) :
                new ObjectParameter("Mod", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GFunc_GetPrivilageRole_Result>("[InvEntities].[GFunc_GetPrivilageRole](@Comp, @bra, @user, @Sys, @sub, @Mod)", compParameter, braParameter, userParameter, sysParameter, subParameter, modParameter);
        }
    
        [DbFunction("InvEntities", "GFunc_GetPrivilageUM")]
        public virtual IQueryable<GFunc_GetPrivilageUM_Result> GFunc_GetPrivilageUM(Nullable<int> comp, Nullable<int> bra, string user, string sys, string sub, string mod)
        {
            var compParameter = comp.HasValue ?
                new ObjectParameter("Comp", comp) :
                new ObjectParameter("Comp", typeof(int));
    
            var braParameter = bra.HasValue ?
                new ObjectParameter("bra", bra) :
                new ObjectParameter("bra", typeof(int));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var sysParameter = sys != null ?
                new ObjectParameter("Sys", sys) :
                new ObjectParameter("Sys", typeof(string));
    
            var subParameter = sub != null ?
                new ObjectParameter("sub", sub) :
                new ObjectParameter("sub", typeof(string));
    
            var modParameter = mod != null ?
                new ObjectParameter("Mod", mod) :
                new ObjectParameter("Mod", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GFunc_GetPrivilageUM_Result>("[InvEntities].[GFunc_GetPrivilageUM](@Comp, @bra, @user, @Sys, @sub, @Mod)", compParameter, braParameter, userParameter, sysParameter, subParameter, modParameter);
        }
    
        public virtual int A_ProcessVouchers(string userCode, Nullable<int> comp, Nullable<int> opCode)
        {
            var userCodeParameter = userCode != null ?
                new ObjectParameter("userCode", userCode) :
                new ObjectParameter("userCode", typeof(string));
    
            var compParameter = comp.HasValue ?
                new ObjectParameter("Comp", comp) :
                new ObjectParameter("Comp", typeof(int));
    
            var opCodeParameter = opCode.HasValue ?
                new ObjectParameter("OpCode", opCode) :
                new ObjectParameter("OpCode", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("A_ProcessVouchers", userCodeParameter, compParameter, opCodeParameter);
        }
    
        public virtual ObjectResult<all_The_Gard_Result> all_The_Gard(string userName, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<all_The_Gard_Result>("all_The_Gard", userNameParameter, fromDateParameter, toDateParameter);
        }
    
        public virtual int Close_days()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Close_days");
        }
    
        public virtual ObjectResult<Nullable<System.DateTime>> Date_Time_Now()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.DateTime>>("Date_Time_Now");
        }
    
        public virtual int G_ProcessTrans(Nullable<int> comp, Nullable<int> branch, string trType, string opMode, Nullable<int> trID, ObjectParameter trNo, ObjectParameter ok)
        {
            var compParameter = comp.HasValue ?
                new ObjectParameter("Comp", comp) :
                new ObjectParameter("Comp", typeof(int));
    
            var branchParameter = branch.HasValue ?
                new ObjectParameter("Branch", branch) :
                new ObjectParameter("Branch", typeof(int));
    
            var trTypeParameter = trType != null ?
                new ObjectParameter("TrType", trType) :
                new ObjectParameter("TrType", typeof(string));
    
            var opModeParameter = opMode != null ?
                new ObjectParameter("OpMode", opMode) :
                new ObjectParameter("OpMode", typeof(string));
    
            var trIDParameter = trID.HasValue ?
                new ObjectParameter("TrID", trID) :
                new ObjectParameter("TrID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("G_ProcessTrans", compParameter, branchParameter, trTypeParameter, opModeParameter, trIDParameter, trNo, ok);
        }
    
        public virtual int G_TOL_GetCounter(string system, Nullable<int> comp, Nullable<int> branch, string trType, ObjectParameter trNo)
        {
            var systemParameter = system != null ?
                new ObjectParameter("System", system) :
                new ObjectParameter("System", typeof(string));
    
            var compParameter = comp.HasValue ?
                new ObjectParameter("Comp", comp) :
                new ObjectParameter("Comp", typeof(int));
    
            var branchParameter = branch.HasValue ?
                new ObjectParameter("Branch", branch) :
                new ObjectParameter("Branch", typeof(int));
    
            var trTypeParameter = trType != null ?
                new ObjectParameter("TrType", trType) :
                new ObjectParameter("TrType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("G_TOL_GetCounter", systemParameter, compParameter, branchParameter, trTypeParameter, trNo);
        }
    
        public virtual ObjectResult<Nullable<decimal>> Get_Balance()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("Get_Balance");
        }
    
        public virtual ObjectResult<Get_Settings_Report_Result> Get_Settings_Report(string iD_Button_Print)
        {
            var iD_Button_PrintParameter = iD_Button_Print != null ?
                new ObjectParameter("ID_Button_Print", iD_Button_Print) :
                new ObjectParameter("ID_Button_Print", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_Settings_Report_Result>("Get_Settings_Report", iD_Button_PrintParameter);
        }
    
        public virtual ObjectResult<Get_Settings_Report_and_Parameter_Result> Get_Settings_Report_and_Parameter(string iD_Button_Print)
        {
            var iD_Button_PrintParameter = iD_Button_Print != null ?
                new ObjectParameter("ID_Button_Print", iD_Button_Print) :
                new ObjectParameter("ID_Button_Print", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Get_Settings_Report_and_Parameter_Result>("Get_Settings_Report_and_Parameter", iD_Button_PrintParameter);
        }
    
        public virtual int GLnk_GenerateTrans(Nullable<int> comp, Nullable<int> bra, string user, string sys, string tRType, string fromDate, string toDate, Nullable<int> fromno, Nullable<int> toNo)
        {
            var compParameter = comp.HasValue ?
                new ObjectParameter("comp", comp) :
                new ObjectParameter("comp", typeof(int));
    
            var braParameter = bra.HasValue ?
                new ObjectParameter("Bra", bra) :
                new ObjectParameter("Bra", typeof(int));
    
            var userParameter = user != null ?
                new ObjectParameter("User", user) :
                new ObjectParameter("User", typeof(string));
    
            var sysParameter = sys != null ?
                new ObjectParameter("Sys", sys) :
                new ObjectParameter("Sys", typeof(string));
    
            var tRTypeParameter = tRType != null ?
                new ObjectParameter("TRType", tRType) :
                new ObjectParameter("TRType", typeof(string));
    
            var fromDateParameter = fromDate != null ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(string));
    
            var toDateParameter = toDate != null ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(string));
    
            var fromnoParameter = fromno.HasValue ?
                new ObjectParameter("Fromno", fromno) :
                new ObjectParameter("Fromno", typeof(int));
    
            var toNoParameter = toNo.HasValue ?
                new ObjectParameter("ToNo", toNo) :
                new ObjectParameter("ToNo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GLnk_GenerateTrans", compParameter, braParameter, userParameter, sysParameter, tRTypeParameter, fromDateParameter, toDateParameter, fromnoParameter, toNoParameter);
        }
    
        public virtual int GLnk_GenerateTransVchr(string user)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GLnk_GenerateTransVchr", userParameter);
        }
    
        public virtual int GProc_CreateBranch(Nullable<int> comp, Nullable<int> bra)
        {
            var compParameter = comp.HasValue ?
                new ObjectParameter("comp", comp) :
                new ObjectParameter("comp", typeof(int));
    
            var braParameter = bra.HasValue ?
                new ObjectParameter("bra", bra) :
                new ObjectParameter("bra", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GProc_CreateBranch", compParameter, braParameter);
        }
    
        public virtual int GProc_CreateStore(Nullable<int> comp, Nullable<int> bra, Nullable<int> stCode)
        {
            var compParameter = comp.HasValue ?
                new ObjectParameter("comp", comp) :
                new ObjectParameter("comp", typeof(int));
    
            var braParameter = bra.HasValue ?
                new ObjectParameter("bra", bra) :
                new ObjectParameter("bra", typeof(int));
    
            var stCodeParameter = stCode.HasValue ?
                new ObjectParameter("stCode", stCode) :
                new ObjectParameter("stCode", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GProc_CreateStore", compParameter, braParameter, stCodeParameter);
        }
    
        public virtual int GProc_CreateUser(string user, string likeUser)
        {
            var userParameter = user != null ?
                new ObjectParameter("User", user) :
                new ObjectParameter("User", typeof(string));
    
            var likeUserParameter = likeUser != null ?
                new ObjectParameter("LikeUser", likeUser) :
                new ObjectParameter("LikeUser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GProc_CreateUser", userParameter, likeUserParameter);
        }
    
        public virtual int GProc_SecCreateUser(string user, Nullable<int> comp)
        {
            var userParameter = user != null ?
                new ObjectParameter("User", user) :
                new ObjectParameter("User", typeof(string));
    
            var compParameter = comp.HasValue ?
                new ObjectParameter("Comp", comp) :
                new ObjectParameter("Comp", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GProc_SecCreateUser", userParameter, compParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> Insert_Enter_Money(string dasc_Name, Nullable<decimal> pirce, string userName, string tr_Type)
        {
            var dasc_NameParameter = dasc_Name != null ?
                new ObjectParameter("Dasc_Name", dasc_Name) :
                new ObjectParameter("Dasc_Name", typeof(string));
    
            var pirceParameter = pirce.HasValue ?
                new ObjectParameter("pirce", pirce) :
                new ObjectParameter("pirce", typeof(decimal));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var tr_TypeParameter = tr_Type != null ?
                new ObjectParameter("Tr_Type", tr_Type) :
                new ObjectParameter("Tr_Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("Insert_Enter_Money", dasc_NameParameter, pirceParameter, userNameParameter, tr_TypeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> insert_ORDER_DELIVERY(string userName, Nullable<int> namber_Order_Delivery, Nullable<decimal> total_All, string date_Order_Delivery, Nullable<double> tax, Nullable<int> cUSTOMER_ID, string type_order, Nullable<bool> confirmation)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var namber_Order_DeliveryParameter = namber_Order_Delivery.HasValue ?
                new ObjectParameter("Namber_Order_Delivery", namber_Order_Delivery) :
                new ObjectParameter("Namber_Order_Delivery", typeof(int));
    
            var total_AllParameter = total_All.HasValue ?
                new ObjectParameter("Total_All", total_All) :
                new ObjectParameter("Total_All", typeof(decimal));
    
            var date_Order_DeliveryParameter = date_Order_Delivery != null ?
                new ObjectParameter("Date_Order_Delivery", date_Order_Delivery) :
                new ObjectParameter("Date_Order_Delivery", typeof(string));
    
            var taxParameter = tax.HasValue ?
                new ObjectParameter("Tax", tax) :
                new ObjectParameter("Tax", typeof(double));
    
            var cUSTOMER_IDParameter = cUSTOMER_ID.HasValue ?
                new ObjectParameter("CUSTOMER_ID", cUSTOMER_ID) :
                new ObjectParameter("CUSTOMER_ID", typeof(int));
    
            var type_orderParameter = type_order != null ?
                new ObjectParameter("type_order", type_order) :
                new ObjectParameter("type_order", typeof(string));
    
            var confirmationParameter = confirmation.HasValue ?
                new ObjectParameter("Confirmation", confirmation) :
                new ObjectParameter("Confirmation", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("insert_ORDER_DELIVERY", userNameParameter, namber_Order_DeliveryParameter, total_AllParameter, date_Order_DeliveryParameter, taxParameter, cUSTOMER_IDParameter, type_orderParameter, confirmationParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> insert_Outlet(string dasc_Name, Nullable<decimal> pirce, string userName, string tr_Type)
        {
            var dasc_NameParameter = dasc_Name != null ?
                new ObjectParameter("Dasc_Name", dasc_Name) :
                new ObjectParameter("Dasc_Name", typeof(string));
    
            var pirceParameter = pirce.HasValue ?
                new ObjectParameter("pirce", pirce) :
                new ObjectParameter("pirce", typeof(decimal));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var tr_TypeParameter = tr_Type != null ?
                new ObjectParameter("Tr_Type", tr_Type) :
                new ObjectParameter("Tr_Type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("insert_Outlet", dasc_NameParameter, pirceParameter, userNameParameter, tr_TypeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> insert_Purchases_Master(string tr_Date, Nullable<int> iD_Supplier, Nullable<bool> type_Debit, Nullable<decimal> total_Amount, Nullable<decimal> paid_Up, Nullable<decimal> to_be_Paid, string rEMARKS)
        {
            var tr_DateParameter = tr_Date != null ?
                new ObjectParameter("Tr_Date", tr_Date) :
                new ObjectParameter("Tr_Date", typeof(string));
    
            var iD_SupplierParameter = iD_Supplier.HasValue ?
                new ObjectParameter("ID_Supplier", iD_Supplier) :
                new ObjectParameter("ID_Supplier", typeof(int));
    
            var type_DebitParameter = type_Debit.HasValue ?
                new ObjectParameter("Type_Debit", type_Debit) :
                new ObjectParameter("Type_Debit", typeof(bool));
    
            var total_AmountParameter = total_Amount.HasValue ?
                new ObjectParameter("Total_Amount", total_Amount) :
                new ObjectParameter("Total_Amount", typeof(decimal));
    
            var paid_UpParameter = paid_Up.HasValue ?
                new ObjectParameter("Paid_Up", paid_Up) :
                new ObjectParameter("Paid_Up", typeof(decimal));
    
            var to_be_PaidParameter = to_be_Paid.HasValue ?
                new ObjectParameter("To_be_Paid", to_be_Paid) :
                new ObjectParameter("To_be_Paid", typeof(decimal));
    
            var rEMARKSParameter = rEMARKS != null ?
                new ObjectParameter("REMARKS", rEMARKS) :
                new ObjectParameter("REMARKS", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("insert_Purchases_Master", tr_DateParameter, iD_SupplierParameter, type_DebitParameter, total_AmountParameter, paid_UpParameter, to_be_PaidParameter, rEMARKSParameter);
        }
    
        public virtual int insert_Table_two_days()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_Table_two_days");
        }
    
        public virtual int IProc_CreateCompany(Nullable<int> comp)
        {
            var compParameter = comp.HasValue ?
                new ObjectParameter("comp", comp) :
                new ObjectParameter("comp", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("IProc_CreateCompany", compParameter);
        }
    
        public virtual int New_Data_Bes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("New_Data_Bes");
        }
    
        public virtual ObjectResult<Stord_Get_Outlet_Result> Stord_Get_Outlet(string fromDate, string toDate, string uSER_CODE, Nullable<int> type)
        {
            var fromDateParameter = fromDate != null ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(string));
    
            var toDateParameter = toDate != null ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(string));
    
            var uSER_CODEParameter = uSER_CODE != null ?
                new ObjectParameter("USER_CODE", uSER_CODE) :
                new ObjectParameter("USER_CODE", typeof(string));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Stord_Get_Outlet_Result>("Stord_Get_Outlet", fromDateParameter, toDateParameter, uSER_CODEParameter, typeParameter);
        }
    }
}
