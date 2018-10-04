using ClientOfClans.Attributes;
using System;
using System.Reflection;

namespace ClientOfClans
{
    internal static class ExtensionMethods
    {
        public static string GetStringValue(this Enum @enum)
        {
            if (@enum is null)
                return null;

            var member = @enum.GetType().GetMember(@enum.ToString());
            var attribute = member[0].GetCustomAttribute<StringValueAttribute>();
            return attribute?.Value;
        }
    }
}
