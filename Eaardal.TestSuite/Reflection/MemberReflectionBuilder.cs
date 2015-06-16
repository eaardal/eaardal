using System;
using System.Reflection;
using NUnit.Framework;

namespace Eaardal.TestSuite.Reflection
{
    public class MemberReflectionBuilder<TClass>
    {
        private readonly MemberInfo _memberInfo;

        public MemberReflectionBuilder(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                throw new ArgumentNullException("memberInfo");
            }

            this._memberInfo = memberInfo;
        }

        public MemberReflectionBuilder<TClass> IsVirtual()
        {
            var memberName = this._memberInfo.Name;
            var property = typeof(TClass).GetProperty(memberName);
            var method = typeof(TClass).GetMethod(memberName);

            var isVirtual = false;
            if (property != null && method == null)
            {
                isVirtual = property.GetGetMethod().IsVirtual && property.GetSetMethod().IsVirtual;
            }
            else if (method != null && property == null)
            {
                isVirtual = method.IsVirtual;
            }

            Assert.IsTrue(isVirtual);
            return this;
        }
        
        public AttributeReflectionBuilder<TClass, TAttribute> IsDecoratedWith<TAttribute>() where TAttribute : Attribute
        {
            var attribute = Attribute.GetCustomAttribute(this._memberInfo, typeof(TAttribute));
            var attr = attribute as TAttribute;
            Assert.NotNull(attribute);
            Assert.NotNull(attr);
            return new AttributeReflectionBuilder<TClass, TAttribute>(_memberInfo, attr);
        }
    }
}