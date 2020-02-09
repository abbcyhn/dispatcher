namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAG_BUILDINGS")]
    public partial class Building : AEntity
    {
        public Building()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        [Column("BUILDING_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("BUILDING_NAME")]
        public string Name { get; set; }

        [Column("BUILDING_DESCRIPTION")]
        public string Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
