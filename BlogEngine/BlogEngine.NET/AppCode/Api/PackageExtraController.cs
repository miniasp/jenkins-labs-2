using BlogEngine.Core.Packaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogEngine.NET.AppCode.Api
{
    public class PackageExtraController : ApiController
    {
        public IEnumerable<PackageExtra> Get()
        {
            try
            {
                return Gallery.GetPackageExtras();
            }
            catch (UnauthorizedAccessException)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new HttpResponseException(HttpStatusCode.ExpectationFailed);

                var result = Gallery.GetPackageExtra(id);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, result);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (UnauthorizedAccessException)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
