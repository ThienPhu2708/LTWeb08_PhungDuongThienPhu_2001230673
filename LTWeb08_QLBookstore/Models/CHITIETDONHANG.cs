namespace LTWeb08_QLBookstore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string MADONHANG { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MASACH { get; set; }

        public int? SOLUONG { get; set; }

        public decimal? DONGIA { get; set; }

        public virtual DONDATHANG DONDATHANG { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
