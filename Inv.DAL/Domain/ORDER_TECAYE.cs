//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ORDER_TECAYE
    {
        public int ID_Order_Tecaye { get; set; }
        public string Date_Order_Tecaye { get; set; }
        public Nullable<int> EMPLOYEE_ID { get; set; }
        public Nullable<int> Namber_Order_Tecaye { get; set; }
        public Nullable<decimal> Total_All { get; set; }
        public string type_order { get; set; }
        public Nullable<int> Num_Day { get; set; }
    }
}
