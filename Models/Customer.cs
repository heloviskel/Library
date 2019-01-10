namespace MyLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Books_Customers = new HashSet<Books_Customers>();
        }

        [Key]
        public int Customer_ID { get; set; }

        [Column("Giveaway date", TypeName = "date")]
        public DateTime? Giveaway_date { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Adress { get; set; }

        [Column("Birth year")]
        [StringLength(50)]
        public string Birth_year { get; set; }

        [Column("Tel. number")]
        public string Tel__number { get; set; }

        [Column("Returning date", TypeName = "date")]
        public DateTime? Returning_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Books_Customers> Books_Customers { get; set; }
    }
}
