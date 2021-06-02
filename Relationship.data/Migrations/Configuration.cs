namespace Relationship.data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Relationship.data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Relationship.data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            context.Teams.AddOrUpdate(t => t.TeamName,
            new Team
            {
                ID=1,
                TeamName="Cubs"
            });



            context.Players.AddOrUpdate(p => p.PlayerName, 
            new Player
            {
                ID = 1,
                PlayerName = "Kevin",
                TeamID = 1
            },
             new Player
             {
                 ID = 2,
                 PlayerName = "Terry",
                 TeamID = 1
             }
            );
        }
    }
}
