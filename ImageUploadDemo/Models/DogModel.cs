using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploadDemo.Models
{
	public class DogModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Cuteness { get; set; }
		public string PhotoPath { get; set; }
	}
}
