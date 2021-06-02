using Relationship.data;
using Relationship.models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship.services.PlayerServices
{
    public class PlayerService
    {
        public bool CreatePlayer(PlayerCreate model)
        {
            var entity = new Player()
            {
                PlayerName=model.PlayerName,
                TeamID=model.TeamID
            };

            using (var ctx = new Context())
            {
                //add player to the EXISTING TEAM
                var team = ctx.Teams.FirstOrDefault(t => t.ID == entity.TeamID);
                //adding player to the team ...
                team.Players.Add(entity);
                //adding the player to the player table in the database
                ctx.Players.Add(entity);
                //save changes

                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new Context())
            {
                var players =
                    ctx
                    .Players
                    .Select(p => new PlayerListItem
                    {
                        ID=p.ID,
                        PlayerName=p.PlayerName
                    }).ToList();
                return players;
            }
        }

        public PlayerDetails GetPlayerById(int id)
        {
            using (var ctx = new Context())
            {
                var player =
                    ctx
                    .Players
                   .SingleOrDefault(p => p.ID == id);

                return new PlayerDetails
                {
                    ID=player.ID,
                    PlayerName=player.PlayerName,
                    Team=player.Team
                };
              
            }
        }

        public bool UpdatePlayer(PlayerEdit player)
        {
            using (var ctx = new Context())
            {
                var oldPlayerData =
                    ctx
                    .Players
                   .SingleOrDefault(p => p.ID == player.ID);

                oldPlayerData.PlayerName = player.PlayerName;

                return ctx.SaveChanges() == 1;

            }
        }


        public bool DeletePlayer(int id)
        {
            using (var ctx = new Context())
            {
                var oldPlayerData =
                    ctx
                    .Players
                   .SingleOrDefault(p => p.ID == id);

                ctx.Players.Remove(oldPlayerData);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
