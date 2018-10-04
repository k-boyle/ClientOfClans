using System;

namespace ClientOfClans.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class StringValueAttribute : Attribute
    {
        public string Value { get; }

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
