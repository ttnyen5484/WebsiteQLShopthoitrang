//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KHACHHANG
    {
        public KHACHHANG()
        {
            this.HOADONs = new HashSet<HOADON>();
        }
    
        public int MAKH { get; set; }
        public string TENKH { get; set; }
        public string TENDN { get; set; }
        public string GMAIL { get; set; }
        public string SDT { get; set; }
        public string DIACHI { get; set; }
        public string PASS { get; set; }
        public string GIOITINH { get; set; }
    
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
