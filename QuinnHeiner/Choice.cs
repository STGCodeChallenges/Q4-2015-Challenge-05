namespace CodeChallenge05_StarWarsTrivia
{
	public class Choice
	{
		// properties
		public char Letter { get; private set; }
		public string Text { get; private set; }
		public bool IsCorrectChoice { get; private set; }

		// methods
		public string Display()
		{
			return string.Concat(Letter, ". ", Text);
		}

		// constructor
		public Choice(char letter, string text, bool isCorrectChoice)
		{
			Letter = letter;
			Text = text;
			IsCorrectChoice = isCorrectChoice;
		}
	}
}