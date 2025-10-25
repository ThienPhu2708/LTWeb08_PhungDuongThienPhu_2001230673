namespace LTWeb08_QLBookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CHITIETDONHANG = new HashSet<CHITIETDONHANG>();
            TACGIA = new HashSet<TACGIA>();
        }

        [Key]
        [StringLength(50)]
        public string MASACH { get; set; }

        [StringLength(100)]
        public string TENSACH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GIABAN { get; set; }

        [StringLength(100)]
        public string MOTA { get; set; }

        [StringLength(100)]
        public string ANHBIA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYCAPNHAT { get; set; }

        [StringLength(50)]
        public string MACHUDE { get; set; }

        [StringLength(50)]
        public string MANXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANG { get; set; }

        public virtual CHUDE CHUDE { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TACGIA> TACGIA { get; set; }
    }
}
