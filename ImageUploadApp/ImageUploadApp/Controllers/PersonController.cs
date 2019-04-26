using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ImageUploadApp.Models;

namespace ImageUploadApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            return View(_context.Persons.ToList());
        }


        [HttpPost]
        public void Upload()
        {
            if (System.Web.HttpContext.Current.Request.Files.Count > 0)
            {
                //CompanyModels comp = new CompanyModels();
                PersonModels person=new PersonModels();
                //Fetch the Uploaded File.
                HttpPostedFile postedFile = System.Web.HttpContext.Current.Request.Files[0];

                //Set the Folder Path.
                string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Images/");
                //context.Response.Write("file name:"+ folderPath);

                //Set the File Name.
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(postedFile.FileName);
                string fileExtension = Path.GetExtension(postedFile.FileName);
                string personName = person.PersonName;               
                //Save the File in Folder.
                postedFile.SaveAs(folderPath + personName +"" + fileName);

                //Send File details in a JSON Response.
                string json = new JavaScriptSerializer().Serialize(
                    new
                    {
                        name = personName + "" + fileName
                    });
                System.Web.HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.OK;
                System.Web.HttpContext.Current.Response.ContentType = "text/json";
                System.Web.HttpContext.Current.Response.Write(json);
                System.Web.HttpContext.Current.Response.End();
            }
        }

        [HttpGet]
        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPerson(PersonModels personModels)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                _context.Persons.Add(personModels);
                _context.SaveChanges();
                result = true;
            }
            return new JsonResult
            {
                Data = new
                {
                    status = result
                }
            };
        }


    }
}