
namespace ValidationAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public MyRequiredAttribute()
        {

        }
        public override bool IsValid(object obj)
        => obj != null;
    }
}
