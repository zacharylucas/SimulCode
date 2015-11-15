using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHack.Controllers
{
    public class TextAreaController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Compile(string docDataIn)
        {
            Console.WriteLine("YOU ARE IN THE FUNCTION THING");
            string targetFile = @"C:\CompileTesting\ctests2.cs";
            System.IO.File.WriteAllText(targetFile, docDataIn);

            var processInfo = new ProcessStartInfo(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe",
                "ctests2.cs");
            processInfo.UseShellExecute = true;
            processInfo.WorkingDirectory = Path.GetDirectoryName(targetFile);

            var process = new Process();
            process.StartInfo = processInfo;
            process.Start();
            process.WaitForExit();
            process.Close();

            var runProcess = new Process();
            runProcess.StartInfo.FileName = @"C:\CompileTesting\ctests2.exe";
            runProcess.StartInfo.UseShellExecute = false;
            runProcess.StartInfo.RedirectStandardOutput = true;
            runProcess.Start();

            var reader = runProcess.StandardOutput;
            var output = reader.ReadToEnd();

            runProcess.WaitForExit();
            runProcess.Close();

            return Json(new { compiled = output });

        }

    }

}