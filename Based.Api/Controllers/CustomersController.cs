using System.Collections.ObjectModel;
using System.Web.Http;
using System.Web.Http.Routing;
using Based.Api.Models;
using Based.Business.Interfaces;

namespace Based.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerLogic customer;

        public CustomersController(ICustomerLogic customer)
        {
            this.customer = customer;
        }

        [HttpGet]
        [Route("api/Customers", Name = "TestGet")]
        public IHttpActionResult Get()
        {
            return Ok("it works!");
        }

        [HttpGet]
        [Route("api/Customers", Name = "CustomersGetById")]
        public IHttpActionResult GetById(int id)
        {
            var result = customer.GetById(id);

            var helper = new UrlHelper(Request);

            var checkCreditUrl = helper.Link("CheckCredit", new { id });
            var takePaymentUrl = helper.Link("TakePayment", new { id });

            var response = new
            {
                Links = new Collection<LinkModel>
                {
                    new LinkModel{ Href = checkCreditUrl, Rel = "checkCredit", Method = "POST" },
                    new LinkModel{ Href = takePaymentUrl, Rel = "takePayment", Method = "POST" }
                },
                Customer = result
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("api/Customers", Name = "CustomersPaging")]
        public IHttpActionResult GetPage(int pageNumber, int pageSize)
        {
            if (pageSize <= 0 || pageNumber <= 0)
            {
                return BadRequest();
            }

            var result = customer.GetPage(pageNumber, pageSize);

            var helper = new UrlHelper(Request);

            var prevUrl = pageNumber > 0 ? helper.Link("CustomersPaging", new { pageNumber = pageNumber - 1, pageSize }) : string.Empty;
            var nextUrl = pageNumber < result.Info.TotalPages - 1 ? helper.Link("CustomersPaging", new { pageNumber = pageNumber + 1, pageSize }) : string.Empty;

            var response = new
            {
                Links = new Collection<LinkModel>
                {
                    new LinkModel{ Href = prevUrl, Rel = "prevPage", Method = "GET" },
                    new LinkModel{ Href = nextUrl, Rel = "nextPage", Method = "GET" }
                },
                Items = result.Customers
            };

            return Ok(response);
        }
    }
}
