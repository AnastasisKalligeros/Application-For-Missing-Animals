
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Dynamic;
using ApplicationForMissingAnimals.Models;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Azure.Documents;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Web.Helpers;
using Microsoft.Data.SqlClient.DataClassification;
using ApplicationForMissingAnimals.Data;
using ApplicationForMissingAnimals.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForMissingAnimals.Controllers
{
	public class AccountController : Controller
	{
        public AccountController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }


        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();


        SqlDataReader dr;
     


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-AVTLD8A\\SQLEXPRESS01; database=appaboutlostanimals; integrated security = SSPI; TrustServerCertificate = True;";
        }

        public ActionResult back()
        {
            return View("index");
        }


        public ViewResult Chat()
        {
         
            return View(); 
        }
       

        public ActionResult AddRegister()
        {
            return View();
        }
        public ActionResult index(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from users where username='" + acc.Name + "' and password='" + acc.Password + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("index");
            }
            else
            {
                con.Close();
                return View("ErrorLogin");
            }

        }

        public ActionResult Reg(Register reg)
        {
            connectionString();

            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM users WHERE username='" + reg.Name + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                return View("ErrorLogin");
            }
            else
            {
                dr.Close();
                com.CommandText = "INSERT INTO users VALUES ('" + reg.Name.ToString() + "','" + reg.Password.ToString() + "','" + reg.ConfirmPassword.ToString() + "','" + reg.FirstName.ToString() + "','" + reg.LastName.ToString() + "','" + reg.Date + "','" + reg.Gender + "','" + reg.Email.ToString() + "','" + reg.PhoneNumber + "')";
                dr = com.ExecuteReader();
                con.Close();
                return View("Login");
            }
        }

       


        public ActionResult Associations()
        {
            return View();
        }
       
        public ActionResult Entry()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }











        













        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
       

        public async Task<IActionResult> Index1()
        {
            var animal = await dbContext.NewAnimals.ToListAsync();
            return View(animal);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(AnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Animal animal = new Animal
                {
                    Microchip = model.Microchip,
                    Content = model.Content,
                    Title = model.Title + " ",
                    City = model.City,
                    Age = model.Age,
                    Street = model.Street,
                    Information = model.Information,
                    Type = model.Type,
                    Name = model.Name,
                    Description = model.Description,
                    Color = model.Color,
                    ProfilePicture = uniqueFileName,
                };
                dbContext.Add(animal);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index1));
            }
            return View();
        }

        private string UploadedFile(AnimalViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "imgs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}



