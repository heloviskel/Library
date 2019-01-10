namespace MyLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books_Customers
    {
        public int ID { get; set; }

        public int? Books_ID { get; set; }

        public int? Customers_ID { get; set; }

        public virtual Book Book { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
