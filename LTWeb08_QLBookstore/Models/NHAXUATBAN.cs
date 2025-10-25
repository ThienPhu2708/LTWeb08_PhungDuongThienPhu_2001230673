namespace LTWeb08_QLBookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAXUATBAN")]
    public partial class NHAXUATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAXUATBAN()
        {
            SACH = new HashSet<SACH>();
        }

        [Key]
        [StringLength(50)]
        public string MANXB { get; set; }

        [StringLength(100)]
        public string TENNXB { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(12)]
        public string DIENTHOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACH { get; set; }
    }
}
