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
        #region HasPrivateGetter

        [Test]
        public void HasPrivateGetter_StringOverload_ShouldBeTrueForPropertyWithPrivateGetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PrivateGet_PublicSet").HasPrivateGetter();
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void HasPrivateGetter_StringOverload_ShouldBeFalseForPropertyWithPublicGetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PublicGet_PublicSet").HasPrivateGetter();
        }

        #endregion

        #region HasPublicGetter

        [Test]
        public void HasPublicGetter_ExpressionOverload_ShouldBeTrueForPropertyWithPublicGetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_PublicSet).HasPublicGetter();
        }

        [Test]
        public void HasPublicGetter_StringOverload_ShouldBeTrueForPropertyWithPublicGetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PublicGet_PublicSet").HasPublicGetter();
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void HasPublicGetter_StringOverload_ShouldBeFalseForPropertyWithPrivateGetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PrivateGet_PublicSet").HasPublicGetter();
        }

        #endregion

        #region HasPublicSetter

        [Test]
        public void HasPublicSetter_ExpressionOverload_ShouldBeTrueForPropertyWithPublicSetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_PublicSet).HasPublicSetter();
        }

        [Test]
        public void HasPublicSetter_StringOverload_ShouldBeTrueForPropertyWithPublicSetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PublicGet_PublicSet").HasPublicSetter();
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void HasPublicSetter_ExpressionOverload_ShouldBeFalseForPropertyWithPrivateSetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_PrivateSet).HasPublicSetter();
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void HasPublicSetter_StringOverload_ShouldBeFalseForPropertyWithPrivateSetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PublicGet_PrivateSet").HasPublicSetter();
        }

        #endregion

        #region HasPrivateSetter

        [Test]
        public void HasPrivateSetter_ExpressionOverload_ShouldBeTrueForPropertyWithPrivateSetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_PrivateSet).HasPrivateSetter();
        }

        [Test]
        public void HasPrivateSetter_StringOverload_ShouldBeTrueForPropertyWithPrivateSetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PublicGet_PrivateSet").HasPrivateSetter();
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void HasPrivateSetter_ExpressionOverload_ShouldBeFalseForPropertyWithPublicSetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_PrivateSet).HasPublicSetter();
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void HasPrivateSetter_StringOverload_ShouldBeFalseForPropertyWithPublicSetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PublicGet_PrivateSet").HasPublicSetter();
        }

        #endregion

        #region HasNoSetter

        [Test]
        public void HasNoSetter_ExpressionOverload_ShouldBeTrueForPropertyWithNoSetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_NoSet).HasNoSetter();
        }

        [Test]
        public void HasNoSetter_StringOverload_ShouldBeTrueForPropertyWithNoSetter()
        {
            ReflectThat.PropertyOf<TestClass>("PropWith_PublicGet_NoSet").HasNoSetter();
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void HasNoSetter_ExpressionOverload_ShouldBeFalseForPropertyWithPublicSetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_PublicSet).HasNoSetter();
        }

        [Test, ExpectedException(typeof(AssertionException))]
        public void HasNoSetter_ExpressionOverload_ShouldBeFalseForPropertyWithPrivateSetter()
        {
            ReflectThat.PropertyOf<TestClass>(x => x.PropWith_PublicGet_PrivateSet).HasNoSetter();
        }

        #endregion
    }

    class TestClass
    {
        public string PropWith_PublicGet_PublicSet { get; set; }
        public string PropWith_PrivateGet_PublicSet { private get; set; }
        public string PropWith_PublicGet_PrivateSet { get; private set; }
        public string PropWith_PublicGet_NoSet { get { return "foo"; } }
    }
}
