// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Collections.Generic;
using mshtml;
using Taygeta.Repositories.Html;

namespace Taygeta.MSHtml
{
    /// <summary>
    /// Wrapper for IHTMLElement
    /// Facade for working with DOM with MSHTML
    /// </summary>
    public class MsHtmlPageElement : IPageElement
    {
        private readonly IHTMLElement _htmlElement;
        private readonly Lazy<string> _content;

        public object Bag { get; set; }

        public MsHtmlPageElement(IPageDocument pageDocument, IHTMLElement htmlElement, IPageElement parentElement)
        {
            _htmlElement = htmlElement;
            PageDocument = pageDocument;
            Parent = parentElement;
            Attributes = new MsHtmlAttributes(htmlElement);
            Path = $"{(parentElement == null ? string.Empty : parentElement.Path)}/{Tag}";
            _content = new Lazy<string>(GetContent);

            //create children list including references to previous and next element
            var list = new List<IPageElement>();
            MsHtmlPageElement previousElement = null;
            foreach (IHTMLElement childElement in (IHTMLElementCollection) _htmlElement.children)
            {
                var currentElement = new MsHtmlPageElement(PageDocument, childElement, this);
                list.Add(currentElement);
                currentElement.PreviousSibling = previousElement;
                if (previousElement != null)
                {
                    previousElement.NextSibling = currentElement;
                    
                    // calculate node index
                    IPageElement element = previousElement;
                    while (element != null)
                    {
                        if (element.Tag == Tag)
                        {
                            currentElement.NodeIndex = element.NodeIndex + 1;
                            break;
                        }
                        element = element.PreviousSibling;
                    }
                }
                previousElement = currentElement;
            }
            Children = list.ToArray();
        }

        /// <summary>
        /// Lazy initialization for Content
        /// </summary>
        /// <returns>text inside an element or null if there is none</returns>
        private string GetContent()
        {
            if (!(_htmlElement is IHTMLDOMNode))
                return null;
            string result = null;
            IHTMLDOMNode node = (IHTMLDOMNode)_htmlElement;
            IHTMLDOMNode nodeChild = node.firstChild;
            if ((nodeChild != null) && !DBNull.Value.Equals(nodeChild.nodeValue))
                result = nodeChild.nodeValue as string;
            return result;
        }

        /*
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            IHTMLElement objElement;
            if (obj is IHTMLElement)
                objElement = (IHTMLElement)obj;
            else if (obj is MsHtmlPageElement)
                objElement = ((MsHtmlPageElement)obj)._htmlElement;
            else
                // ReSharper disable once BaseObjectEqualsIsObjectEquals
                return base.Equals(obj);

            return _htmlElement == objElement;
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }
        */

        #region IPageElement implementation

        /// <inheritdoc />
        public IPageDocument PageDocument { get; }

        /// <inheritdoc />
        public IPageElement[] Children { get; }

        /// <inheritdoc />
        public IPageElement Parent { get; }

        /// <inheritdoc />
        public string Path { get; }

        /// <inheritdoc />
        public IPageElementAttributes Attributes { get; }

        /// <inheritdoc />
        public string Id => _htmlElement.id;

        /// <inheritdoc />
        public string InnerText => _htmlElement.innerText;

        /// <inheritdoc />
        public string Content => _content.Value;

        /// <inheritdoc />
        public string Tag => _htmlElement.tagName;

        /// <inheritdoc />
        public IPageElement PreviousSibling { get; private set; }

        /// <inheritdoc />
        public IPageElement NextSibling { get; private set; }

        /// <inheritdoc />
        public int NodeIndex { get; private set; }

        #endregion
    }
}
