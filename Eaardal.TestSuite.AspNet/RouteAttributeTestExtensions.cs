using System.Web.Mvc;
using NUnit.Framework;

namespace Eaardal.TestSuite.AspNet
{
    public static class RouteAttributeTestExtensions
    {
        public static void WithTemplate(this RouteAttribute attr, string expectedRouteTemplate)
        {
            Assert.AreEqual(expectedRouteTemplate, attr.Template);
        }
    }
}
