using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Routing;
using Based.Api.Models;
using Based.Business.Interfaces;
using SharpRepository.Repository.Caching.Hash;

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

        /// <summary>
        /// Enable paging for the customer route
        /// </summary>
        /// <param name="pageNumber">Page to be returned</param>
        /// <param name="pageSize">Size of pages to return</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Customers", Name = "CustomersPaging")]
        public IHttpActionResult GetPage(int pageNumber, int pageSize, string fields = null)
        {
            if (pageSize <= 0 || pageNumber <= 0)
            {
                return BadRequest();
            }

            var result = customer.GetPage(pageNumber, pageSize);

            var helper = new UrlHelper(Request);

            var prevUrl = string.Empty;
            var nextUrl = string.Empty;

            if (fields == null)
            {
                prevUrl = pageNumber - 1 > 0
                    ? helper.Link("CustomersPaging", new {pageNumber = pageNumber - 1, pageSize})
                    : string.Empty;
                nextUrl = pageNumber < result.Info.TotalPages - 1
                    ? helper.Link("CustomersPaging", new {pageNumber = pageNumber + 1, pageSize})
                    : string.Empty;
            }
            else
            {
                prevUrl = pageNumber - 1 > 0
                    ? helper.Link("CustomersPaging", new {pageNumber = pageNumber - 1, pageSize, fields})
                    : string.Empty;
                nextUrl = pageNumber < result.Info.TotalPages - 1
                    ? helper.Link("CustomersPaging", new {pageNumber = pageNumber + 1, pageSize, fields})
                    : string.Empty;
            }
            

            var customFields = new List<object>();

            if (fields != null)
            {
                var lstOfFields = fields.ToLower().Split(',').ToList();
                
                for (var i = 0; i < result.Customers.Count(); i++)
                {
                    result.Customers.ToList().ForEach(x =>
                    {
                        customFields.Add(CreateDataShapedObject(x, lstOfFields));
                    });
                }
            }

            dynamic response = new ExpandoObject();

            response.Info = result.Info;
            response.Links = new Collection<LinkModel>
            {
                new LinkModel {Href = prevUrl, Rel = "prevPage", Method = "GET"},
                new LinkModel {Href = nextUrl, Rel = "nextPage", Method = "GET"}
            };

            response.Items = fields == null ? (dynamic) result.Customers : customFields;

            return Ok(response);
        }

        private object CreateDataShapedObject(ICustomerDto customer, List<string> lstOfFields)
        {

            if (!lstOfFields.Any())
            {
                return null;
            }
            
            // Create a new ExpandoObject & dynamically create the properties for this object
            var objectToReturn = new ExpandoObject();

            foreach (var field in lstOfFields)
            {
                // need to include public and instance, b/c specifying a binding flag overwrites the
                // already-existing binding flags.

                var fieldValue = customer.GetType()
                    .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                    .GetValue(customer, null);

                // add the field to the ExpandoObject
                ((IDictionary<string, object>)objectToReturn).Add(field, fieldValue);
            }

            return objectToReturn;            
        }
    }
}
