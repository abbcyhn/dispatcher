namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("STUDENTS")]
    public partial class Student : APerson, IVisible
    {
        [Key]
        [Column("STUDENT_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("STUDENT_NAME")]
        public override string Name { get; set; }

        [Column("STUDENT_SURNAME")]
        public override string Surname { get; set; }

        [Column("STUDENT_PATRONYMIC")]
        public override string Patronymic { get; set; }

        [Column("STUDENT_VISIBILITY")]
        public bool Visibility { get; set; }

        [Column("GROUP_ID")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
