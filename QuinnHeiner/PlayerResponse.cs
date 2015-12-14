namespace CodeChallenge05_StarWarsTrivia
{
	public class PlayerResponse
	{
		// properties
		public Question Question { get; private set; }
		public Choice Response { get; private set; }

		// constructor
		public PlayerResponse(Question question, Choice response)
		{
			Question = question;
			Response = response;
		}
	}
}