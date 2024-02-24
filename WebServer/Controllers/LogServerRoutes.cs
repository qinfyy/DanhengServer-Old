using Microsoft.AspNetCore.Mvc;

namespace EggLink.DanhengServer.WebServer.Controllers
{
    [ApiController]
    [Route("/")]
    public class LogServerRoutes
    {
        [HttpPost("/sdk/dataUpload")]
        [HttpPost("/crashdump/dataUpload")]
        [HttpPost("/apm/dataUpload")]
        public JsonResult LogUpload() => new("{\"code\":0}");

        [HttpPost("/common/h5log/log/batch")]
        public JsonResult BatchUpload() => new("{\"retcode\":0,\"message\":\"success\",\"data\":null}");
    }
}
