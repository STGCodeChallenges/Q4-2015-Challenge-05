using System;
using System.Linq;

namespace CodeChallenge05_StarWarsTrivia
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string userResponse;
			do
			{
				Console.Clear();
				Console.WriteLine("Welcome to Star Wars Trivia!");

				const int numQuestions = 5;
				var numPlayers = GetNumPlayers();
				var difficulty = GetDifficulty();
				var game = new TriviaGame(numPlayers, numQuestions, (DifficultyEnum) difficulty);

				GetPlayerResponses(game);
				Console.Clear();
				Console.WriteLine(game.DisplayResults());

				Console.WriteLine("\n\nThanks for playing! Play again (y/n)?");
				userResponse = Console.ReadLine();

			} while (!string.IsNullOrEmpty(userResponse) && userResponse.Substring(0, 1).ToLower() == "y");
		}

		private static int GetNumPlayers()
		{
			Console.WriteLine("Please enter number of players (max 10):");
			var userResponse = Console.ReadLine();

			int numPlayers;
			while (!int.TryParse(userResponse, out numPlayers) || numPlayers < 1 || numPlayers > 10)
			{
				Console.WriteLine("Invalid number of players.  Please try again.");
				userResponse = Console.ReadLine();
			}
			return numPlayers;
		}

		private static int GetDifficulty()
		{
			Console.WriteLine("Select level of difficulty (1 for easy, 2 for hard):");
			var userResponse = Console.ReadLine();

			int difficulty;
			while (!int.TryParse(userResponse, out difficulty) || !Enum.IsDefined(typeof (DifficultyEnum), difficulty))
			{
				Console.WriteLine("Invalid level of difficulty selected.  Please try again.");
				userResponse = Console.ReadLine();
			}
			return difficulty;
		}

		public static void GetPlayerResponses(TriviaGame game)
		{
			foreach (var question in game.QuizQuestions)
			{
				Console.Clear();
				Console.WriteLine(question.Text);

				foreach (var choice in question.Choices)
				{
					Console.WriteLine(choice.Letter + ". " + choice.Text);
				}

				foreach (var player in game.Players)
				{
					Console.WriteLine("\n{0} response:", player.Name);
					var playerResponse = Console.ReadKey();
					var playerChoice = question.Choices.FirstOrDefault(c => Char.ToLower(c.Letter) == Char.ToLower(playerResponse.KeyChar));

					player.Responses.Add(new PlayerResponse(question, playerChoice));
				}
			}
		}
	}
}
