using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupIS1024.Pages
{
    public class FormModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private string result;

        public FormModel(IWebHostEnvironment _environment)
        {
          environment = _environment;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string fileName = Upload.FileName;
            var file = Path.Combine(environment.ContentRootPath, "upload", fileName);

            using(var fileStream = new FileStream(file, FileMode.Create))
            {
                Upload.CopyTo(fileStream);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            ValidateXML(file);

            XmlNode Favoritegames = doc.SelectSingleNode("/survey/memorable_games/game");
            string comments = Favoritegames.InnerText;
            XmlNodeList childelements = doc.DocumentElement.ChildNodes;
            XmlNodeList games = doc.SelectNodes("/survey/memorable_games/game");
        }

        private void ValidateXML(string file)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;

            // read in schema file.
            var xsdPath = Path.Combine(environment.ContentRootPath, "Upload", "survey.xsd");

            settings.Schemas.Add(null, xsdPath);

            settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings;

            settings.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandler);

            try {
                XmlReader xmlReader = XmlReader.Create(file, settings);
                while (xmlReader.Read())
                {


                }
                ViewData["result"] = "Validation Passed";
            } catch (Exception e)
            {
                ViewData["result"] = e.Message;
            }
            }
            public void ValidationEventHandler(object sender, ValidationEventArgs args)
            {
                result = "Validation Failed.  Message: " + args.Message;

                // TODO throw an exception
                throw new Exception("Validation failed.  Message: " + args.Message);
            }
        }
        }
