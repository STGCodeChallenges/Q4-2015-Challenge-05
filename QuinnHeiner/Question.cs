using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge05_StarWarsTrivia
{
	public class Question
	{
		// properties
		public int QuestionId { get; private set; }
		public string Text { get; private set; }
		public DifficultyEnum Difficulty { get; private set; }
		public ICollection<Choice> Choices { get; private set; }

		// methods
		public Choice GetAnswer()
		{
			return Choices.FirstOrDefault(c => c.IsCorrectChoice);
		}

		// constructor
		public Question(int questionId, string text, DifficultyEnum difficulty, ICollection<Choice> choices)
		{
			QuestionId = questionId;
			Text = text;
			Difficulty = difficulty;
			Choices = choices;
		}
	}
}