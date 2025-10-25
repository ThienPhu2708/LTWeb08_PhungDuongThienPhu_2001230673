namespace LTWeb08_QLBookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONDATHANG = new HashSet<DONDATHANG>();
        }

        [Key]
        [StringLength(100)]
        public string MAKH { get; set; }

        [StringLength(100)]
        public string HOTEN { get; set; }

        [StringLength(100)]
        public string TAIKHOAN { get; set; }

        [StringLength(20)]
        public string MATKHAU { get; set; }

        [StringLength(20)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        [StringLength(12)]
        public string DIENTHOAI { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANG { get; set; }
    }
}
