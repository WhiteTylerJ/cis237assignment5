namespace assignment1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Beverage
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string pack { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal price { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool active { get; set; }
    }
}
