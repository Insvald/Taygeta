// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using JetBrains.Annotations;

namespace Taygeta.Repositories.Html
{
    public static class PageElementExtension
    {
        /// <summary>
        /// Distance to an element (in nodes)
        /// </summary>
        /// <param name="element1">An element to measure distance from</param>
        /// <param name="element2">An element to measure distance to</param>
        /// <returns>Count of nodes between elements</returns>
        public static int DistanceTo(this IPageElement element1, [NotNull] IPageElement element2)
        {
            IPageElement secondTree = element2;
            IPageElement firstTree = element1;
            int firstTreeSteps = 0;
            int secondTreeSteps = 0;
            while ((firstTree != secondTree) && (firstTree != null))
            {
                while ((firstTree != secondTree) && (secondTree != null))
                {
                    secondTree = secondTree.Parent;
                    secondTreeSteps++;
                }
                if (firstTree != secondTree)
                {
                    //restoring second element
                    secondTree = element2;
                    secondTreeSteps = 0;
                    firstTree = firstTree.Parent;
                    firstTreeSteps++;
                }
                else //common parent found, decrease number of steps by one
                    secondTreeSteps--;
            }

            if ((firstTree == null) || (secondTree == null))
                throw new NotSupportedException("the pageElement is from different document");

            return firstTreeSteps + secondTreeSteps;
        }

        /// <summary>
        /// Gets tag names from both side of an element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="leftTag">the tag name of the previous sibling</param>
        /// <param name="rightTag">the tag name of the next sibling</param>
        public static void GetSiblingsTags(this IPageElement element, out string leftTag, out string rightTag)
        {
            IPageElement leftSibling = element.PreviousSibling;
            leftTag = leftSibling?.Tag;
            IPageElement rightSibling = element.NextSibling;
            rightTag = rightSibling?.Tag;
        }

        /// <summary>
        /// Gets a parent of specified level in the DOM tree
        /// </summary>
        /// <param name="element"></param>
        /// <param name="level">level of hierarchy to look at</param>
        /// <returns>parent element</returns>
        public static IPageElement GetParentAtLevel(this IPageElement element, int level)
        {
            IPageElement result = element;
            for (int i = 0; i < level; i++)
                result = result.Parent;
            return result;
        }

        /// <summary>
        /// Get unique path to a tag and/or to its attribute
        /// Example: /HTML/BODY/DIV#2/SPAN/A#3@HREF
        /// Unqiue path - list of slash-delimited tags from root to an element, 
        /// after the '#' - a zero-based ordinal number of a tag from the first sibling 
        /// (#0 or if it is a unique tag - number is optional also)
        /// (optional) after the '@' - attribute name or @CONTENT - text between tags not including child elements
        /// </summary>
        /// <param name="pageElement"></param>
        /// <returns>a unique path</returns>
        public static string GetUniquePath(this IPageElement pageElement)
        {
            string parentString = string.Empty;
            string numberString = string.Empty;
            bool numberIsMandatory = false;
            int number = 0;

            if (pageElement.Parent != null)
            {
                parentString = pageElement.Parent.GetUniquePath();
                for (int i = 0; i < pageElement.Parent.Children.Length; i++)
                {
                    IPageElement child = pageElement.Parent.Children[i];
                    if (child == pageElement)
                        number = i;
                    else if (child.Tag == pageElement.Tag)
                        numberIsMandatory = true;
                }
                if (numberIsMandatory)
                    numberString = $"#{number}";
            }
            return $"{parentString}/{pageElement.Tag}{numberString}";
        }
    }
}
