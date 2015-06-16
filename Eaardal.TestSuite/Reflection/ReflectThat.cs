using System;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace Eaardal.TestSuite.Reflection
{
    public static class ReflectThat
    {
        public static MemberReflectionBuilder<TClass> MemberOf<TClass>(Expression<Func<TClass, object>> expression)
        {
            var memberInfo = LambdaHelper.GetMemberInfoForExpression(expression);
            return new MemberReflectionBuilder<TClass>(memberInfo);
        }

        public static MemberReflectionBuilder<TClass> MemberOf<TClass>(string memberName)
        {
            var memberInfos = typeof (TClass).GetMember(memberName);

            var memberInfo = memberInfos.FirstOrDefault();

            if (memberInfo != null)
            {
                return new MemberReflectionBuilder<TClass>(memberInfo);    
            }
            throw new Exception("Could not find member " + memberName);
        }

        public static PropertyReflectionBuilder<T> PropertyOf<T>(Expression<Func<T, object>> expression)
        {
            var memberInfo = LambdaHelper.GetMemberInfoForExpression(expression);

            return PropertyOf<T>(memberInfo.Name);
        }

        public static PropertyReflectionBuilder<T> PropertyOf<T>(Expression<Action<T>> expression)
        {
            var memberInfo = LambdaHelper.GetMemberInfoForExpression(expression);

            return PropertyOf<T>(memberInfo.Name);
        }

        public static PropertyReflectionBuilder<T> PropertyOf<T>(string propertyName)
        {
            var propertyInfo = typeof(T).GetProperty(propertyName);

            if (propertyInfo != null)
            {
                return new PropertyReflectionBuilder<T>(propertyInfo);
            }
            throw new Exception("Could not find property " + propertyName);
        }
    }
}
