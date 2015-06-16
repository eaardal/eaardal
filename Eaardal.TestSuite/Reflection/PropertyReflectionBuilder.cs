using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Eaardal.TestSuite.Reflection
{
    public class PropertyReflectionBuilder<TClass>
    {
        private readonly PropertyInfo _property;

        public PropertyReflectionBuilder(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException("property");
            _property = property;
        }

        public PropertyReflectionBuilder<TClass> HasPrivateSetter()
        {
            var propertyName = _property.Name;
            var property = typeof(TClass).GetProperty(propertyName);
            Assert.IsTrue(property.GetSetMethod().IsPrivate);
            return this;
        }

        public PropertyReflectionBuilder<TClass> HasPublicSetter()
        {
            var propertyName = _property.Name;
            var property = typeof(TClass).GetProperty(propertyName);
            Assert.IsTrue(property.GetSetMethod().IsPublic);
            return this;
        }

        public PropertyReflectionBuilder<TClass> HasPrivateGetter()
        {
            var propertyName = _property.Name;
            var property = typeof(TClass).GetProperty(propertyName);
            Assert.IsTrue(property.GetGetMethod().IsPrivate);
            return this;
        }

        public PropertyReflectionBuilder<TClass> HasPublicGetter()
        {
            var propertyName = _property.Name;
            var property = typeof(TClass).GetProperty(propertyName);
            Assert.IsTrue(property.GetGetMethod().IsPublic);
            return this;
        } 
    }
}
