namespace myDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string address { get; set; }

        [Required]
        [StringLength(15)]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dob { get; set; }
    }
}
