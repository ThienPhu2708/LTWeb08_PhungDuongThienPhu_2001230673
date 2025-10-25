namespace LTWeb08_QLBookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TACGIA")]
    public partial class TACGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TACGIA()
        {
            SACH = new HashSet<SACH>();
        }

        [Key]
        [StringLength(50)]
        public string MATG { get; set; }

        [StringLength(100)]
        public string TENTG { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(12)]
        public string DIENTHOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACH { get; set; }
    }
}
