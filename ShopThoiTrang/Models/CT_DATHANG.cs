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
    
    public partial class CT_DATHANG
    {
        public int CTMADH { get; set; }
        public string MADH { get; set; }
        public string MASP { get; set; }
        public Nullable<int> SOLUONGDAT { get; set; }
        public Nullable<int> GIANHAP { get; set; }
        public Nullable<int> THANHTIEN { get; set; }
    
        public virtual DATHANG DATHANG { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
