namespace QL_Employee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEE")]
    public partial class EMPLOYEE
    {
        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        public string NAME_EMP { get; set; }

        [StringLength(5)]
        public string GENDER { get; set; }

        [StringLength(100)]
        public string CITY { get; set; }

        [StringLength(100)]
        public string DEPT_ID { get; set; }

        [StringLength(100)]
        public string IMAGES_EMP { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}
