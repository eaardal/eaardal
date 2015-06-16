using System.Reflection;

namespace Eaardal.TestSuite.Reflection
{
    public class AttributeReflectionBuilder<TClass, TAttribute> : MemberReflectionBuilder<TClass>
    {
        public TAttribute Attr { get; private set; }

        public AttributeReflectionBuilder(MemberInfo memberInfo, TAttribute attr)
            : base(memberInfo)
        {
            Attr = attr;
        }
    }
}