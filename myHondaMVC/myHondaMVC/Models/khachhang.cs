namespace myHondaMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachhang()
        {
            dathangs = new HashSet<dathang>();
        }

        [Key]
        public int makh { get; set; }

        [StringLength(50)]
        public string tenkh { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string pass { get; set; }

        public double? sotiendamua { get; set; }

        public bool? status { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dathang> dathangs { get; set; }
    }
}
