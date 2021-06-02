using Relationship.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship.models.TeamModels
{
   public class TeamDetails
    {
        public int ID { get; set; }
        public string TeamName { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}
