using HomeWork.DAL.Entities;
using System;

namespace HomeWork
{
    public class MenuService
    {
        private readonly TeamService _teamService;

        public MenuService()
        {
            _teamService = new TeamService();
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Football Tournament Menu");
                Console.WriteLine("1. Display All Teams");
                Console.WriteLine("2. Add New Team");
                Console.WriteLine("3. Update Team");
                Console.WriteLine("4. Delete Team");
                Console.WriteLine("5. Find Team by Criteria");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        DisplayAllTeams();
                        break;
                    case "2":
                        AddNewTeam();
                        break;
                    case "3":
                        UpdateTeam();
                        break;
                    case "4":
                        DeleteTeam();
                        break;
                    case "5":
                        FindTeamByCriteria();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void DisplayAllTeams()
        {
            Console.Clear();
            var teams = _teamService.GetAllTeams();
            foreach (var team in teams)
            {
                Console.WriteLine($"Team: {team.Name}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}, Draws: {team.Draws}, Goals Scored: {team.GoalsScored}, Goals Conceded: {team.GoalsConceded}");
            }
        }

        private void AddNewTeam()
        {
            Console.Clear();
            Team team = new Team();
            Console.Write("Enter Team Name: ");
            team.Name = Console.ReadLine();
            Console.Write("Enter Team City: ");
            team.City = Console.ReadLine();

            // Using TryParse to safely parse integer values
            team.Wins = GetValidInteger("Enter Wins: ");
            team.Losses = GetValidInteger("Enter Losses: ");
            team.Draws = GetValidInteger("Enter Draws: ");
            team.GoalsScored = GetValidInteger("Enter Goals Scored: ");
            team.GoalsConceded = GetValidInteger("Enter Goals Conceded: ");

            _teamService.AddTeam(team);
            Console.WriteLine("Team added successfully!\n");
        }

        private void UpdateTeam()
        {
            Console.Clear();
            Console.Write("Enter the name of the team to update: ");
            string name = Console.ReadLine();
            Team team = _teamService.GetTeamByCriteria(name);
            if (team != null)
            {
                Console.WriteLine($"Updating team {team.Name}");
                team.Wins = GetValidInteger("Enter new Wins: ");
                team.Losses = GetValidInteger("Enter new Losses: ");
                team.Draws = GetValidInteger("Enter new Draws: ");
                team.GoalsScored = GetValidInteger("Enter new Goals Scored: ");
                team.GoalsConceded = GetValidInteger("Enter new Goals Conceded: ");

                _teamService.UpdateTeam(team);
                Console.WriteLine("Team updated successfully!\n");
            }
            else
            {
                Console.WriteLine("Team not found.\n");
            }
        }

        private void DeleteTeam()
        {
            Console.Clear();
            Console.Write("Enter the name of the team to delete: ");
            string name = Console.ReadLine();
            Team team = _teamService.GetTeamByCriteria(name);
            if (team != null)
            {
                _teamService.DeleteTeam(team);
                Console.WriteLine("Team deleted successfully!\n");
            }
            else
            {
                Console.WriteLine("Team not found.\n");
            }
        }

        private void FindTeamByCriteria()
        {
            Console.Clear();
            Console.WriteLine("Find Team by Criteria");
            Console.WriteLine("1. Wins");
            Console.WriteLine("2. Losses");
            Console.WriteLine("3. Draws");
            Console.WriteLine("4. Goals Scored");
            Console.WriteLine("5. Goals Conceded");
            Console.Write("Select criteria: ");
            string criterion = Console.ReadLine();

            Team team = _teamService.GetTeamByCriteria(criterion);
            if (team != null)
            {
                Console.WriteLine($"Team: {team.Name}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}, Draws: {team.Draws}, Goals Scored: {team.GoalsScored}, Goals Conceded: {team.GoalsConceded}\n");
            }
            else
            {
                Console.WriteLine("No team found for the selected criteria.\n");
            }
        }

        // Helper method to safely parse integers using TryParse
        private int GetValidInteger(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
