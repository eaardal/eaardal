using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Eaardal.TestSuite.Reflection
{
    public class PropertyReflectionBuilder<T>
    {
        private readonly PropertyInfo _property;

        public PropertyReflectionBuilder(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException("property");
            _property = property;
        }

        public PropertyReflectionBuilder<T> HasPrivateSetter()
        {
            var property = typeof(T).GetProperty(_property.Name);

            var setter = property.SetMethod;

            if (setter != null)
            {
                Assert.IsTrue(setter.IsPrivate);
            }
            else
            {
                Assert.Fail("Expected property " + _property.Name + " to have private setter");
            }

            return this;
        }

        public PropertyReflectionBuilder<T> HasPublicSetter()
        {
            var property = typeof(T).GetProperty(_property.Name);

            var setter = property.SetMethod;

            if (setter != null)
            {
                Assert.IsTrue(setter.IsPublic);
            }
            else
            {
                Assert.Fail("Expected property " + _property.Name + " to have public setter");
            }

            return this;
        }

        public PropertyReflectionBuilder<T> HasPrivateGetter()
        {
            var property = typeof(T).GetProperty(_property.Name);

            var getter = property.GetMethod;

            if (getter != null)
            {
                Assert.IsTrue(getter.IsPrivate);
            }
            else
            {
                Assert.Fail("Expected property " + _property.Name + " to have private getter");
            }

            return this;
        }

        public PropertyReflectionBuilder<T> HasPublicGetter()
        {
            var property = typeof(T).GetProperty(_property.Name);
            
            var getter = property.GetMethod;

            if (getter != null)
            {
                Assert.IsTrue(getter.IsPublic);
            }
            else
            {
                Assert.Fail("Expected property " + _property.Name + " to have public getter");
            }
            
            return this;
        }

        public PropertyReflectionBuilder<T> HasNoSetter()
        {
            var property = typeof(T).GetProperty(_property.Name);

            var setter = property.SetMethod;

            Assert.Null(setter);

            return this;
        } 
    }
}
