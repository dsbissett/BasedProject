using System.Web.Http;

namespace Based.Api.Controllers
{
    public class CreditController : ApiController
    {
        [Route("api/Credit", Name = "CheckCredit")]
        public IHttpActionResult CheckCredit(int id)
        {
            return Ok(id);
        }
    }
}