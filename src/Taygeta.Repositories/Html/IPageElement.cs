// The Taygeta Project
// (c) 2015 Ilya Rovensky

namespace Taygeta.Repositories.Html
{
    /// <summary>
    /// List of tag attributes
    /// </summary>
    public interface IPageElementAttributes
    {
        string this[string index] { get; }
    }

    /// <summary>
    /// Interface encapsulating DOM element on an HTML page
    /// </summary>
    public interface IPageElement
    {
        /// <summary>
        /// Name of the tag
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Array of the attributes
        /// </summary>
        IPageElementAttributes Attributes { get; }

        /// <summary>
        /// The path of tags from the root
        /// </summary>
        string Path { get; }

        string Id { get; }

        string InnerText { get; }

        int NodeIndex { get; }

        /// <summary>
        /// The text between open and closing tags, not including child tags
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Hierarchical list of child nodes
        /// </summary>
        IPageElement[] Children { get; }

        /// <summary>
        /// The parent element, if any
        /// </summary>
        IPageElement Parent { get; }

        /// <summary>
        /// The previous element in the parent collection, if any
        /// </summary>
        IPageElement PreviousSibling { get; }

        /// <summary>
        /// The next element in the parent child collection, if any
        /// </summary>
        IPageElement NextSibling { get; }
        //int NodeIndex { get; }

        /// <summary>
        /// Parent page document
        /// </summary>
        IPageDocument PageDocument { get; }

        /// <summary>
        /// Arbitrary object holder
        /// </summary>
        object Bag { get; set; }
    }
}
