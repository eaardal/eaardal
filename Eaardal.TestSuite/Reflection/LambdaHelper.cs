using System;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;

namespace Eaardal.TestSuite.Reflection
{
    public static class LambdaHelper
    {
        public static MemberInfo GetMemberInfoForExpression<TClass>(Expression<Action<TClass>> expression)
        {
            try
            {
                var lambda = (LambdaExpression)expression;

                MemberInfo member;

                if (TryGetAsUnaryExpression(lambda, out member))
                    return member;

                if (TryGetAsMethodCallExpression(lambda, out member))
                    return member;

                if (TryGetAsMemberExpression(lambda, out member))
                    return member;
            }
            catch (Exception)
            {
                Assert.Fail("Could not find property name for given expression");
            }

            return null;
        }

        public static MemberInfo GetMemberInfoForExpression<TClass>(Expression<Func<TClass, object>> expression)
        {
            try
            {
                var lambda = (LambdaExpression)expression;

                MemberInfo member;

                if (TryGetAsUnaryExpression(lambda, out member))
                    return member;

                if (TryGetAsMethodCallExpression(lambda, out member))
                    return member;

                if (TryGetAsMemberExpression(lambda, out member))
                    return member;
            }
            catch (Exception)
            {
                Assert.Fail("Could not find property name for given expression");
            }

            return null;
        }

        private static bool TryGetAsMemberExpression(LambdaExpression lambda, out MemberInfo member)
        {
            var memberExpression = lambda.Body as MemberExpression;
            if (memberExpression != null)
            {
                member = GetAsMemberExpression(memberExpression);
                return true;
            }
            member = null;
            return false;
        }

        private static bool TryGetAsUnaryExpression(LambdaExpression lambda, out MemberInfo member)
        {
            var unary = lambda.Body as UnaryExpression;
            if (unary != null)
            {
                member = GetAsUnaryExpression(unary);
                return true;
            }
            member = null;
            return false;
        }

        private static bool TryGetAsMethodCallExpression(LambdaExpression lambda, out MemberInfo member)
        {
            var unary = lambda.Body as MethodCallExpression;
            if (unary != null)
            {
                member = GetAsMethodCallExpression(unary);
                return true;
            }
            member = null;
            return false;
        }

        private static MemberInfo GetAsMemberExpression(MemberExpression memberExpression)
        {
            return memberExpression.Member;
        }

        private static MethodInfo GetAsMethodCallExpression(MethodCallExpression methodCall)
        {
            return methodCall.Method;
        }

        private static MemberInfo GetAsUnaryExpression(UnaryExpression lambda)
        {
            var expression = (MemberExpression) lambda.Operand;
            return expression.Member;
        }
    }
}