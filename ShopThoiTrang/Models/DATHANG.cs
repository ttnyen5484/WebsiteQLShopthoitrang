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
    
    public partial class DATHANG
    {
        public DATHANG()
        {
            this.CT_DATHANG = new HashSet<CT_DATHANG>();
            this.PHIEUNHAPs = new HashSet<PHIEUNHAP>();
        }
    
        public string MADH { get; set; }
        public string MANV { get; set; }
        public string MANCC { get; set; }
        public Nullable<System.DateTime> NGAYDAT { get; set; }
        public Nullable<System.DateTime> NGAYGIAO { get; set; }
        public Nullable<int> TIENDAT { get; set; }
        public string TTGIAOHANG { get; set; }
    
        public virtual ICollection<CT_DATHANG> CT_DATHANG { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }
    }
}
