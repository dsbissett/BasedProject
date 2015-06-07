using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Based.Api.FakeData;
using Ploeh.AutoFixture;

namespace Based.Api.Controllers
{
    // ETag caching
    // Versioning
    // Paging
    // Links:  href, rel.. one href="www", rel="self"
    public class Customers2Controller : ApiController
    {
        private const int PAGESIZE = 3;
        private readonly IEnumerable<ICustomerModel> Customers;
        
        public Customers2Controller()
        {
            IFixture fixture = new Fixture();
            try
            {
                Customers =
                fixture.Build<CustomerModel>()
                    .With(x => x.Address, fixture.Create<Address>())
                    .With(x => x.Phone, fixture.Create<Phone>())
                    .CreateMany(100);
            }
            catch (Exception ex)
            {                  
                Debug.WriteLine(ex);
            }
        }

        //[VersionedRoute("api/Customers", "1.2")]
        public IHttpActionResult Get(int page = 0)
        {
            var baseQuery = Customers.OrderBy(x => x.Id);

            var totalCount = baseQuery.Count();

            var totalPage = (int) Math.Ceiling((double) totalCount / PAGESIZE);

            var query = baseQuery.Skip(PAGESIZE * page).Take(PAGESIZE).ToList();

            var helper = new UrlHelper(Request);

            var prevUrl = page > 0 ? helper.Link("Customers", new {page = page - 1}) : string.Empty;
            var nextUrl = page < totalPage - 1 ? helper.Link("Customers", new {page = page + 1}) : string.Empty;

            var response = new CustomerResponse
            {
                TotalCount = totalCount,
                TotalPages = totalPage,
                Link = new Link
                {
                    PrevPageUrl = prevUrl,
                    NextPageUrl = nextUrl
                },
                Customer = query
            };

            var tt = new
            {
                thing = totalCount,
                other = helper
            };

            return Ok(response);
        }
    }

    internal class VersionConstraint : IHttpRouteConstraint
    {
        public const string VersionHeaderName = "api-version";

        private const string DefaultVersion = "1.0";

        public string AllowedVersion { get; set; }

        public VersionConstraint(string allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }
        
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (routeDirection == HttpRouteDirection.UriResolution)
            {
                var version = GetVersionFromCustomRequestHeader(request);

                if (!string.IsNullOrWhiteSpace(version))
                {
                    version = GetVersionFromCustomRequestHeader(request);
                }

                return ((version ?? DefaultVersion) == AllowedVersion);
            }

            return true;
        }

        private string GetVersionFromCustomRequestHeader(HttpRequestMessage request)
        {
            string versionAsString;
            IEnumerable<string> headValues;

            if (request.Headers.TryGetValues(VersionHeaderName, out headValues) && headValues.Count() == 1)
            {
                versionAsString = headValues.First();
            }
            else
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(versionAsString))
            {
                return versionAsString;
            }

            return null;
        }
    }

    //internal class VersionedRoute : RouteFactoryAttribute
    //{
    //    public string AllowedVersion { get; set; }

    //    public VersionedRoute(string template, string allowedVersion) : base(template)
    //    {
    //        AllowedVersion = allowedVersion;
    //        Name = "Customers";
    //    }

    //    public override IDictionary<string, object> Constraints
    //    {
    //        get
    //        {
    //            var constraints = new HttpRouteValueDictionary
    //            {
    //                {"version", new VersionConstraint(AllowedVersion)}
    //            };
    //            return constraints;
    //        }
    //    }
    //}
}
