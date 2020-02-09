namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAG_COURSES")]
    public partial class Course : AEntity
    {
        public Course()
        {
            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("COURSE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("COURSE_NAME")]
        public string Name { get; set; }

        [Column("COURSE_DESCRIPTION")]
        public string Description { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
