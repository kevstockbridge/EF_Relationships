using Relationship.data;
using Relationship.models.PlayerModels;
using Relationship.models.TeamModels;
using Relationship.services.PlayerServices;
using Relationship.services.TeamServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Relationships
{
    public class ProgramUI
    {
        //I need access to the PlayerService and The TeamService 
        private TeamService CreateTeamService()
        {
            var svc = new TeamService();
            return svc;
        }

        private PlayerService CreatePlayerService()
        {
            var svc = new PlayerService();
            return svc;
        }



        public void Run()
        {

            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Welcome to the Ball Game\n" +
                                  "1.View Player Details\n" +
                                  "2.View Team Details\n" +
                                  "30.Exit Application\n");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewPlayerDetails();
                        break;
                    case "2":
                        ViewTeamDetails();
                        break;
                    case "30":
                        isRunning = false;
                        Console.WriteLine("Thank you for your time\n" +
                            "Press Any Key to Continue");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Sorry Invalid opperation");
                        break;
                }
            }
        }

        private void ViewTeamDetails()
        {
            Console.Clear();
            Console.WriteLine("Please input a TeamID.");
            var input = int.Parse(Console.ReadLine());
            var svc = CreateTeamService();
            var team = svc.GetTeamById(input);
            DisplayTeamInfo(team);
            Console.ReadKey();
        }

        private void ViewPlayerDetails()
        {
            Console.Clear();
            Console.WriteLine("Please input a PlayerID.");
            var input = int.Parse(Console.ReadLine());
            var svc = CreatePlayerService();
            var player = svc.GetPlayerById(input);
            DisplayPlayerInfo(player);
            Console.ReadKey();
        }

        //helper method
        private void DisplayTeamInfo(TeamDetails teamDetails)
        {
            Console.WriteLine($"{teamDetails.ID}\n" +
                              $"{teamDetails.TeamName}");

            foreach (var player in teamDetails.Players)
            {
                Console.WriteLine($"{player.ID}\n" +
                                    $"{player.PlayerName}");
            }
        }

        private void DisplayPlayerInfo(PlayerDetails playerDetails)
        {
            Console.WriteLine($"{playerDetails.ID}\n" +
                                    $"{playerDetails.PlayerName}");
        }

    }
}
