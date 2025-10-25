namespace LTWeb08_QLBookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CHITIETDONHANG = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [StringLength(100)]
        public string MADON { get; set; }

        public bool? DATHANHTOAN { get; set; }

        public bool? TINHTRANGGIAO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYDAT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYGIAO { get; set; }

        [StringLength(100)]
        public string MAKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
