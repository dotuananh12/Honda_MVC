namespace myHondaMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loaixe")]
    public partial class loaixe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loaixe()
        {
            xemays = new HashSet<xemay>();
        }

        [Key]
        public int maloai { get; set; }

        [StringLength(50)]
        public string tenloai { get; set; }

        public string ghichu { get; set; }

        public string gioithieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<xemay> xemays { get; set; }
    }
}
