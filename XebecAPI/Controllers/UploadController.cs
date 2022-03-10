using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Python.Deployment;
using Python.Runtime;

namespace XebecAPI.Controllers
{
    [Route("api/upload2")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            try
            {
                await Installer.SetupPython();
                PythonEngine.Initialize();
                Installer.TryInstallPip();
                Installer.PipInstallModule("nltk");
                Installer.PipInstallModule("spacy==2.3.5");
                Installer.PipInstallModule("https://github.com/explosion/spacy-models/releases/download/en_core_web_sm-2.3.1/en_core_web_sm-2.3.1.tar.gz");
                Installer.PipInstallModule("pyresparser");
                
                dynamic pyresparser = PythonEngine.ImportModule("pyresparser");
                dynamic data = pyresparser.ResumeParser("C:\\Users\\me\\Desktop\\CVs\\Resume.pdf").get_extracted_data();
                return Ok(data.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}