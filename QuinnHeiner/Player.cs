using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge05_StarWarsTrivia
{
	public class Player
	{
		// properties
		public string Name { get; private set; }
		public int PlayerId { get; private set; }
		public List<PlayerResponse> Responses { get; set; }

		// methods
		public string DisplayResponse(Question question)
		{
			var response = Responses.SingleOrDefault(r => r.Question.QuestionId == question.QuestionId);
			return string.Format("{0} answered: {1}", Name,
				response == null || response.Response == null ? "" : response.Response.Display());
		}

		public string DisplayScore()
		{
			return string.Concat(GetNumCorrectAnswers(), " / ", Responses.Count);
		}

		public int GetNumCorrectAnswers()
		{
			var numCorrectAnswers = Responses.Count(r => r.Response != null && r.Response.IsCorrectChoice);

			return numCorrectAnswers;
		}

		// constructor
		public Player(string name, int playerId)
		{
			PlayerId = playerId;
			Name = name;
			Responses = new List<PlayerResponse>();
		}
	}
}