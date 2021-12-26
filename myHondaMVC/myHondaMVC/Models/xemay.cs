namespace myHondaMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("xemay")]
    public partial class xemay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public xemay()
        {
            anhminhhoas = new HashSet<anhminhhoa>();
            chitietdathangs = new HashSet<chitietdathang>();
        }

        [Key]
        public int maxe { get; set; }

        public int? mancc { get; set; }

        public int? maloai { get; set; }

        public string tenxe { get; set; }

        public double? gianhap { get; set; }

        public double? giakhuyenmai { get; set; }

        public double? giaban { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaythem { get; set; }

        public string khungxe { get; set; }

        [StringLength(50)]
        public string mausac { get; set; }

        [StringLength(50)]
        public string khoiluong { get; set; }

        public string dungtichxylanh { get; set; }

        public string dongco { get; set; }

        public string muctieuthunguyenlieu { get; set; }

        public string phuoctruoc { get; set; }

        public string phuocsau { get; set; }

        public string ghichu { get; set; }

        [Required]
        public string mota { get; set; }

        public int? soluong { get; set; }

        public bool? status { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<anhminhhoa> anhminhhoas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdathang> chitietdathangs { get; set; }

        public virtual loaixe loaixe { get; set; }

        public virtual nhacungcap nhacungcap { get; set; }
    }
}
