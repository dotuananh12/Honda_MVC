namespace myHondaMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("anhminhhoa")]
    public partial class anhminhhoa
    {
        public int id { get; set; }

        public int? maxe { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        public virtual xemay xemay { get; set; }
    }
}
