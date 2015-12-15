using System.Collections.Generic;

namespace CodeChallenge05_StarWarsTrivia
{
	public static class QuestionData
	{
		public static IEnumerable<Question> GetAll()
		{
			var questions = new List<Question>
			{
				// easy
				new Question(1, "In the beginning of Episode 1, Qui-Gon Jinn and Obi-Wan Kenobi are sent to negotiate what?", DifficultyEnum.Easy, new[]
				{
					new Choice('a', "the terms for releasing prisoners held at Naboo", false),
					new Choice('b', "a territory dispute between the Jedi and Sith", false),
					new Choice('c', "a trade dispute between the Republic and the Trade Federation", true),
					new Choice('d', "the terms for releasing Amidala from prison", false)
				}),
				new Question(2, "In Episode 1, after the Jedi flee to Naboo, they end up rescuing whom?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "Obi-Wan Kenobi", false),
					new Choice('b', "Jar Jar Binks and Queen Amidala", true),
					new Choice('c', "Jango Fett", false),
					new Choice('d', "Anakin Skywalker", false)
				}),
				new Question(3, "In Episode 2, Obi-Wan discovers the creation of a clone army.  On which bounty hunter is the clone genetically based?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "Boba Fett", false),
					new Choice('b', "Darth Vader", false),
					new Choice('c', "Jango Fett", true),
					new Choice('d', "The Emperor", false)
				}),
				new Question(4, "Anakin's first noticable \"turn\" to the dark side occurs as a result of what?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "the death of Amidala", false),
					new Choice('b', "the death of Qui-Gon Jinn", false),
					new Choice('c', "a meeting with senator Palpatine", false),
					new Choice('d', "the death of his mother", true)
				}),
				new Question(5, "In Episode 3, when senator Palpatine entices Anakin with the knowledge of the dark side of the Force, he mentions what power specifically?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "the power to cheat death", true),
					new Choice('b', "the power to destroy the Death Star", false),
					new Choice('c', "the power to destroy the Sith", false),
					new Choice('d', "the power to read one's thoughts", false)
				}),
				new Question(6, "Prior to her death, what were the names of the two twins that Padme gave birth to?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "Luke and Leia", true),
					new Choice('b', "Anakin and Darth", false),
					new Choice('c', "Han and Lisa", false),
					new Choice('d', "Larry and Lucy", false)
				}),
				new Question(7, "In Episode 4, rebel leader Princess Leia sneaks the stolen plans for the Death Star into R2-D2, and R2-D2 ends up escaping to which planet?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "Tatooine", true),
					new Choice('b', "Hoth", false),
					new Choice('c', "Coruscant", false),
					new Choice('d', "Geonosis", false)
				}),
				new Question(8, "In Episode 4, who successfully destroys the Death Star (killing Tarkin seconds before he can fire on the rebel base)?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "Han Solo", false),
					new Choice('b', "Boba Fett", false),
					new Choice('c', "Princess Leia", false),
					new Choice('d', "Luke Skywalker", true)
				}),
				new Question(9, "In Episode 5, after evading the Imperial Fleet, Han takes the crew to Cloud City to to meet which friend (who later betrays them by handing them over to Darth Vader)?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "Lando", true),
					new Choice('b', "Jango", false),
					new Choice('c', "Boba", false),
					new Choice('d', "Jar Jar Binks", false)
				}),
				new Question(10, "In Episode 5, after Luke refuses to join Vader against the Emperor, Vader reveals that he is Luke's what?", DifficultyEnum.Easy, new []
				{
					new Choice('a', "son", false),
					new Choice('b', "mother", false),
					new Choice('c', "brother", false),
					new Choice('d', "father", true)
				}),

				// hard
				new Question(11, "In Episode 1, on which capital planet does Amidala plead her people's case (the crisis in Naboo) to Chancellor Valorum in the Galactic Senate?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Tatooine", false),
					new Choice('b', "Hoth", false),
					new Choice('c', "Coruscant", true),
					new Choice('d', "Naboo", false)
				}),
				new Question(12, "In Episode 1, Qui-Gon asks the Jedi Council for permission to train Anakin as a Jedi.  How many Jedi were actively serving on the Council at the time?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "8", false),
					new Choice('b', "12", true),
					new Choice('c', "2", false),
					new Choice('d', "6", false)
				}),
				new Question(13, "On which planet does Obi-Wan discover a Separatist gathering lead by Count Dooku that is secretly building a battle droid army?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Tatooine", false),
					new Choice('b', "Coruscant", false),
					new Choice('c', "Geonosis", true),
					new Choice('d', "Naboo", false)
				}),
				new Question(14, "Who were the two witnesses to Padme and Anakin's secret marriage on Naboo?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Qui-Gon Jinn and Obi-Wan Kenobi", false),
					new Choice('b', "Obi-Wan Kenobi and Yoda", false),
					new Choice('c', "There weren't any", false),
					new Choice('d', "C-3PO and R2-D2", true)
				}),
				new Question(15, "In Episode 3, what was the name of the order given to the clone troopers to kill all their Jedi commanders?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Order 473", false),
					new Choice('b', "Operation Kill the Jedi", false),
					new Choice('c', "Order 66", true),
					new Choice('d', "Route 66", false)
				}),
				new Question(16, "At the end of Episode 3, to whom and where were Luke and Leia sent to hide from the Empire by Obi-Wan and Yoda?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Leia is adopted by Bail Organa and is taken to Alderaan, Luke is adopted by his stepfamily Own and Beru Lars to Tatooine.", true),
					new Choice('b', "Luke is adopted by Bail Organa and is taken to Alderaan, Leia is adopted by his stepfamily Own and Beru Lars to Tatooine.", false),
					new Choice('c', "Leia is adopted by Obi-Wan Kenobi and taken to Tatooine, Luke is adopted by his stepfamily Own and Beru Lars to Tatooine.", false),
					new Choice('d', "Leia is adopted by Bail Organa and is taken to Alderaan, Luke is adopted by Obi-Wan Kenobi and taken to Tatooine", false)
				}),
				new Question(17, "In Episode 4, who was the commanding officer that gave the order to destroy Alderaan with the Death Star?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Grand Toff Markin", false),
					new Choice('b', "Grand Moff Tarkin", true),
					new Choice('c', "Darth Vader", false),
					new Choice('d', "The Emperor", false)
				}),
				new Question(18, "In Episode 4, where did Obi-Wan and Luke first meet Han Solo to transport them to Alderaan via the Millenium Falcon?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Mos Eisley Cantina", true),
					new Choice('b', "Tatooine", false),
					new Choice('c', "Coruscant", false),
					new Choice('d', "Geonosis", false)
				}),
				new Question(19, "In Episode 5, what was the name of the swamp planet on which Yoda trained Luke?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Tatooine", false),
					new Choice('b', "Coruscant", false),
					new Choice('c', "Geonosis", false),
					new Choice('d', "Dagobah", true)
				}),
				new Question(20, "In Episode 6, what was the name of the pit monster into which Boba Fett fell?", DifficultyEnum.Hard, new []
				{
					new Choice('a', "Dagobah", false),
					new Choice('b', "Sarlacc", true),
					new Choice('c', "Scarlett", false),
					new Choice('d', "Scarface", false)
				})
			};

			return questions;
		}
	}
}