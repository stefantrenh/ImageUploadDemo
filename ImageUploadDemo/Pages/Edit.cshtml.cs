using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageUploadDemo.Database;
using ImageUploadDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ImageUploadDemo.Pages
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public DogModel Dog { get; set; }
        
        [BindProperty]
        public IFormFile Photo { get; set; }

        public EditModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public void OnGet(int id)
        {
            Dog = DummyDogRepo.GetDogs().Where(x => x.Id == id).FirstOrDefault();
        }

        public IActionResult OnPost() 
        {
            if (Photo != null)
            {
                //Change Photo

                //Get Path to wwwroot/images
                string folder = Path.Combine(webHostEnvironment.WebRootPath,"images");

                //Check if image dir exist
                if (!Directory.Exists(folder))
                {

                    //If not: Create  Image dir
                    Directory.CreateDirectory(folder);
                }

                //Check if dog has image in image dir
                string file = Path.Combine(folder, Dog.PhotoPath);
                if (System.IO.File.Exists(file))
                {
                    //If yes: remove that photo
                    System.IO.File.Delete(file);
                }

                //Create unique filename for new photo
                string uniqeFileName = String.Concat(Guid.NewGuid().ToString(), "-", Dog.Name.ToLower(), ".jpg");

                string uploadsFolder = Path.Combine(folder, uniqeFileName);
                //Upload new photo
                using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }

                //Update Doggo repo with new PhotoPath
                DummyDogRepo.Dogs.Where(x => x.Id == Dog.Id).FirstOrDefault().PhotoPath = uniqeFileName;

                return RedirectToPage("/Edit", new { Dog.Id });
            }
            return Page();
        }
    }
}
