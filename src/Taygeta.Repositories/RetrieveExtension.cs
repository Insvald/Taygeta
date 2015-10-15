// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Taygeta.Repositories
{
    public static class RetrieveExtension
    {
        /// <summary>
        /// Checks if a string contains one of the specified keywords
        /// </summary>
        /// <param name="textToSearch">string to check</param>
        /// <param name="keywords">keywords to search</param>
        /// <returns>true, if the match is found, or false otherwise</returns>
        public static bool ContainsOne([NotNull] this string textToSearch, [NotNull] string[] keywords)
        {
            // it looks like mumbo-jubmo (it is regex after all), but it works
            return Regex.Match(
                textToSearch,
                $@"(\W|^)({keywords.Aggregate(string.Empty, (current, s) => $@"{current}|{Regex.Escape(s.Trim())}").TrimStart('|')})(\W|$)",
                RegexOptions.IgnoreCase | RegexOptions.Compiled)
                .Success;
        }

        /// <summary>
        /// Checks if a string contains one of the specified keywords
        /// </summary>
        /// <param name="textToSearch">string to check</param>
        /// <param name="keywords">comma-delimited string of keywords</param>
        /// <returns>true, if the match is found, or false otherwise</returns>
        public static bool ContainsOne([NotNull] this string textToSearch, [NotNull] string keywords)
        {
            return textToSearch.ContainsOne(keywords.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Gets an attribute applied to the specified property, if any
        /// </summary>
        /// <typeparam name="T">type of an attribute</typeparam>
        /// <param name="instance">object instance to check</param>
        /// <param name="propertyName">name of the property to check</param>
        /// <returns>the found attribute or null otherwise</returns>
        public static T GetAttributeFrom<T>([NotNull] this object instance, [NotNull] string propertyName) where T : Attribute
        {
            return (T)instance.GetType().GetProperty(propertyName)
                .GetCustomAttributes(typeof(T), false).FirstOrDefault();
        }

        /// <summary>
        /// Gets max length of a string if it is specified by attributes
        /// </summary>
        /// <param name="instance">object instance to check</param>
        /// <param name="propertyName">name of the property to check</param>
        /// <returns>maximum length of the string</returns>
        public static int GetAnnotatedLength([NotNull] this object instance, [NotNull] string propertyName)
        {
            var stringLengthAttr = instance.GetAttributeFrom<StringLengthAttribute>(propertyName);
            if (stringLengthAttr != null)
                return stringLengthAttr.MaximumLength;
            var maxLengthAttr = instance.GetAttributeFrom<MaxLengthAttribute>(propertyName);
            if (maxLengthAttr != null)
                return maxLengthAttr.Length;
            return int.MaxValue;
        }

    }
}
