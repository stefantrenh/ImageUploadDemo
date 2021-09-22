using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageUploadDemo.Database;
using ImageUploadDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ImageUploadDemo.Pages
{
	public class IndexModel : PageModel
	{
        public List<DogModel> Dogs { get; set; }
        public IndexModel()
		{
			
		}

		public void OnGet()
		{
			Dogs = DummyDogRepo.GetDogs();
		}
	}
}
