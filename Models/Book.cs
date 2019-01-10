namespace MyLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Books_Customers = new HashSet<Books_Customers>();
        }

        [Key]
        public int Book_ID { get; set; }

        public byte[] Cover { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [Column("Release year")]
        public int? Release_year { get; set; }

        [StringLength(50)]
        public string Publishment { get; set; }

        public string Content { get; set; }

        public double? Price { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [Column("Date of coming", TypeName = "date")]
        public DateTime? Date_of_coming { get; set; }

        [Column("Amount of coming")]
        public int? Amount_of_coming { get; set; }

        [Column("Inventary number")]
        public int? Inventary_number { get; set; }

        public bool? Availability { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Books_Customers> Books_Customers { get; set; }
    }
}
