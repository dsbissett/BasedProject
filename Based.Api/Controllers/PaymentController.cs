using System.Web.Http;

namespace Based.Api.Controllers
{
    public class PaymentController : ApiController
    {
        [Route("api/Payment", Name = "TakePayment")]
        public IHttpActionResult TakePayment(int id)
        {
            return Ok();
        }
    }
}