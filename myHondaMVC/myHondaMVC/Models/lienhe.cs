namespace myHondaMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lienhe")]
    public partial class lienhe
    {
        [Key]
        public int malh { get; set; }

        [StringLength(50)]
        public string tenkh { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string chude { get; set; }

        public string noidung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaygui { get; set; }

        public bool? status { get; set; }
    }
}
