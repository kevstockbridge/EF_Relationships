using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Relationship.data
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        public string PlayerName { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
    }
}