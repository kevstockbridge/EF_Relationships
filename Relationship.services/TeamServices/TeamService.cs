using Relationship.data;
using Relationship.models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationship.services.TeamServices
{
    public class TeamService
    {
        public bool CreateTeam(TeamCreate model)
        {
            var entity = new Team
            {
                TeamName = model.TeamName
            };

            using (var ctx = new Context())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new Context())
            {
                var teams =
                      ctx
                      .Teams
                      .Select(t => new TeamListItem
                      {
                          ID = t.ID,
                          TeamName = t.TeamName
                      }).ToList();

                return teams;

            }
        }

        public TeamDetails GetTeamById(int id)
        {

            using (var ctx = new Context())
            {
                var teams =
                      ctx
                      .Teams
                      .SingleOrDefault(t => t.ID == id);

                return new TeamDetails
                {
                    ID = teams.ID,
                    TeamName=teams.TeamName,
                    Players=teams.Players
                };
            }
        }

        public bool UpdateTeam(TeamEdit team)
        {
            using (var ctx = new Context())
            {
                var oldTeamData =
                      ctx
                      .Teams
                      .SingleOrDefault(t => t.ID == team.ID);


                oldTeamData.TeamName = team.TeamName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int id)
        {
            using (var ctx = new Context())
            {
                var oldTeamData =
                      ctx
                      .Teams
                       .SingleOrDefault(t => t.ID == id);

                ctx.Teams.Remove(oldTeamData);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
