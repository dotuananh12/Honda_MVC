namespace myHondaMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("taikhoan")]
    public partial class taikhoan
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string usename { get; set; }

        [StringLength(50)]
        public string pass { get; set; }

        public string hoten { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}
