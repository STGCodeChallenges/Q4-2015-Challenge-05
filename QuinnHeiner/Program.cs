using System;
using System.Linq;

/* Challenge #5 (due 12/21/2015): Star Wars Trivia
With all the hype around Star Wars: The Force Awakens, we’ve been tasked to come up with a Star Wars trivia game in order to refresh everyone’s memories of the previous episodes.

Description
The sky's the limit on what kind of UI you want to create--it can be as ugly or fancy as you’d like it.  These are the requirements:
The ability for the user to choose between at least 2 levels of difficulty
At least five randomly selected questions from a larger bank of questions (within the selected level of difficulty).  
Only one answer per question should be considered correct.
At the end of the quiz, print out the results, including the total score, along with a breakdown of each question, the user’s response, and the correct response.
Feel free to copy whatever questions/answers you’d like from the internet (or make up your own).  A suggested minimum is around 10 questions per difficulty to ensure a decent sampling of questions.

Bonus Entry
Extend the game to allow multiple people/teams to submit answers to each question, rather than just a single person.  
Of course, most UIs will allow players to see each others’ responses, but to keep things simple, that’s okay.  
Same rules above apply, except for the results will be broken down by each person/team, with a winner determined (or winners in the case of a tie).
 */

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
