using Relationship.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship.models.PlayerModels
{
    public class PlayerDetails
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public virtual Team Team { get; set; }
    }
}
