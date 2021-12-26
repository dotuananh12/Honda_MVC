namespace myHondaMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dathang")]
    public partial class dathang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dathang()
        {
            chitietdathangs = new HashSet<chitietdathang>();
        }

        [Key]
        public int madh { get; set; }

        public int? makh { get; set; }

        [StringLength(50)]
        public string tenkh { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string ghichu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        public double? tongtien { get; set; }

        public int? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdathang> chitietdathangs { get; set; }

        public virtual khachhang khachhang { get; set; }
    }
}
