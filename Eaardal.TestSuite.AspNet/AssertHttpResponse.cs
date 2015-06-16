using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace Eaardal.TestSuite.AspNet
{
    public static class AssertHttpResponse
    {
        public static void Is200OkResult(HttpResponseMessage result)
        {
            Assert.IsInstanceOf<HttpResponseMessage>(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.Null(result.Content);
        }

        public static T Is200OkResult<T>(HttpResponseMessage result)
        {
            Assert.IsInstanceOf<HttpResponseMessage>(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var content = result.Content as ObjectContent<T>;
            Assert.NotNull(content);

            return ((T)content.Value);
        }

        public static void Is400BadRequestResult(HttpResponseMessage response, string expectedMessage = null)
        {
            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            if (expectedMessage != null)
            {
                var content = response.Content as ObjectContent<string>;
                Assert.NotNull(content);

                Assert.AreEqual(expectedMessage, content.Value);
            }
        }

        public static void Is500InternalServerErrorResult(HttpResponseMessage response)
        {
            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        public static void Is204NoContentResult(HttpResponseMessage response)
        {
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
