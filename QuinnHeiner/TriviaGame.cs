using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge05_StarWarsTrivia
{
	public class TriviaGame
	{
		// properties
		public IEnumerable<Question> QuizQuestions { get; private set; }
		public List<Player> Players { get; private set; }

		// methods		
		public string DisplayResults()
		{
			var results = new StringBuilder();

			results.AppendLine("\n\nRESULTS:");

			foreach (var question in QuizQuestions)
			{
				results.AppendLine(string.Format("\nQ: {0}", question.Text));
				results.AppendLine(string.Format("A: {0}", question.GetAnswer().Display()));

				foreach (var player in Players)
				{
					results.AppendLine(player.DisplayResponse(question));
				}
			}

			results.AppendLine();
			Players.ForEach(p => results.AppendLine(string.Format("{0} score: {1}", p.Name, p.DisplayScore())));

			var winners = GetWinners();
			results.AppendLine(string.Format("\n\nWINNER(S): {0}", string.Join(", ", winners)));

			return results.ToString();
		}

		public IEnumerable<string> GetWinners()
		{
			var topScore = GetTopScore();
			var winners = Players.Where(p => p.GetNumCorrectAnswers() == topScore).Select(p => p.Name);
			return winners;
		}

		private int GetTopScore()
		{
			var topScore = Players.Max(p => p.GetNumCorrectAnswers());
			return topScore;
		}

		// constructor
		public TriviaGame(int numPlayers, int numQuestions, DifficultyEnum difficulty)
		{
			var random = new Random();

			QuizQuestions = QuestionData
				.GetAll()
				.Where(q => q.Difficulty == difficulty)
				.OrderBy(r => random.Next())
				.ToList()
				.Take(numQuestions);

			Players = new List<Player>();

			for (var i = 1; i <= numPlayers; i++)
			{
				Players.Add(new Player("Player " + i, i));
			}
		}
	}
}