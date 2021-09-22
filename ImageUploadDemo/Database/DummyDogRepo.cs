using ImageUploadDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadDemo.Database
{
	public static class DummyDogRepo
	{
		public static List<DogModel> Dogs { get; set; } = new List<DogModel>();

		public static List<DogModel> GetDogs()
		{
			if (!Dogs.Any())
			{
				Dogs = new List<DogModel>()
				{
					new DogModel()
					{
						Id = 0,
						Name = "Bosse",
						Cuteness = 10,
						PhotoPath = "bosse.jpg"
					},
					new DogModel()
					{
						Id = 1,
						Name = "Astrid",
						Cuteness = 8,
						PhotoPath = "astrid.jpg",
					},
					new DogModel()
					{
						Id = 2,
						Name = "Östen",
						Cuteness = 2,
						PhotoPath = "östen.jpg"
					},
					new DogModel()
					{
						Id = 3,
						Name = "Ronja",
						Cuteness = 9,
						PhotoPath = "ronja.jpg"
					}
				};
			}

			return Dogs;
		}
	}
}
