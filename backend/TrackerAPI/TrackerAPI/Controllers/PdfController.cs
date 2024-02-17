using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrackerAPI.Controllers
{
    public class PdfController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            // Implement your logic here
            return Ok("Hello from PdfCreatorController");
        }

        private readonly IConverter _converter;

        // Parameterized constructor
        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }

        // Parameterless constructor
        public PdfCreatorController() : this(new SynchronizedConverter(new PdfTools()))
        {
            // This constructor initializes the converter with default settings
        }

        [HttpGet]
        [Route("generate-task-pdf")]
        public IActionResult GenerateTaskPdf()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Task Report",
                Out = @"D:\PDFCreator\Task_Report.pdf" // Specify the output path here
            };

            // Create an instance of ReportDao to access task data
            var dao = new PdfDao();
            var tasks = dao.GetAllTasks(); // Assuming GetAllTasks returns a List<Task>

            string htmlContent = GenerateHtmlContent(tasks);

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Task Report Footer" }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf"); // Return PDF file as response
        }

        private IActionResult File(byte[] file, string v)
        {
            throw new NotImplementedException();
        }

        private string GenerateHtmlContent(List<Pdf> tasks)
        {
            string htmlContent = "<table border='1' cellpadding='5'><tr><th>Task ID</th><th>Project ID</th><th>User ID</th><th>Name</th><th>Description</th><th>Priority</th><th>Type</th><th>Start Date</th><th>Owner</th><th>End Date</th></tr>";

            foreach (var task in tasks)
            {
                htmlContent += $"<tr><td>{task.TaskID}</td><td>{task.ProjectID}</td><td>{task.UserID}</td><td>{task.Name}</td><td>{task.Description}</td><td>{task.Priority}</td><td>{task.Type}</td><td>{task.StartDate}</td><td>{task.Owner}</td><td>{task.EndDate}</td></tr>";
            }

            htmlContent += "</table>";

            return htmlContent;
        }
    }
}

    }
}
