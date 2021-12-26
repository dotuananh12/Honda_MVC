namespace myHondaMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietdathang")]
    public partial class chitietdathang
    {
        [Key]
        public int mactdh { get; set; }

        public int? madh { get; set; }

        public int? maxe { get; set; }

        public double? giaban { get; set; }

        public int? soluong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydat { get; set; }

        public virtual dathang dathang { get; set; }

        public virtual xemay xemay { get; set; }
    }
}
