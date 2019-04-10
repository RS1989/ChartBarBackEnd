using Bars.Action;
using Bars.Models;
using Bars.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bars.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BarController : ApiController
    {
        private readonly IDataProvider _dataProvider;
        private readonly IRandomizaProvider _randomProvider;

        public BarController(IDataProvider dataProvider, IRandomizaProvider randomProvider)
        {
            _dataProvider = dataProvider;
            _randomProvider = randomProvider;
        }

        
        // POST api/PostData
        [HttpPost, Route("api/upload")]
        public IHttpActionResult PostData()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var file = httpRequest.Files[0];
                    var reader = new StreamReader(file.InputStream);
                    var value = reader.ReadToEnd().Trim();
                    var result = _dataProvider.LoadData(value);
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return new ExceptionWithMessage(ex.Message);                
            }
        }

        // POST api/Randomize
        [HttpPost, Route("api/random")]
        public IHttpActionResult Randomize(List<Bar> value)
        {
            try
            {
                var result = _randomProvider.Randomize(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ExceptionWithMessage(ex.Message);
            }
        }

    }
}
