using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eaardal.TestSuite.Reflection;
using NUnit.Framework;

namespace Eaardal.TestSuite.UnitTests
{
    [TestFixture]
    public class PropertyReflectionBuilderTests
    {
        [Test]
        public void HasPublicGetter_ShouldBeTrueForPropertyWithPublicGetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_PublicSet).HasPublicGetter();
        }

        [Test]
        public void HasPublicGetter_ShouldBeFalseForPropertyWithPrivateGetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PrivateGet_PublicSet").HasPublicGetter();
        }
        
    }

    class TestClass
    {
        public string PropWith_PublicGet_PublicSet { get; set; }
        public string PropWith_PrivateGet_PublicSet { private get; set; }
        public string PropWith_PublicGet_PrivateSet { get; private set; }
    }
}
