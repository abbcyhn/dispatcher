namespace Dispatcher.Entity.Entities
{
    using System;
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAG_ACADEMIC_DEGREES")]
    public partial class AcademicDegree : AEntity
    {
        public AcademicDegree()
        {
            Teachers = new HashSet<Teacher>();
        }

        [Key]
        [Column("DEGREE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("DEGREE_NAME")]
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
