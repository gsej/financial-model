using System.Reflection;
using Xunit.Sdk;

namespace Tests.Model4;

[AttributeUsage(AttributeTargets.Method)]
public class RepeatAttribute : DataAttribute
{
    private readonly int _count;

    public RepeatAttribute(int count)
    {
        _count = count;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        return Enumerable.Repeat(new object[0], _count);
    }
}