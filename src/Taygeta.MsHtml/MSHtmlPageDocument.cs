// The Taygeta Project
// (c) 2015 Ilya Rovensky

using mshtml;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Taygeta.Repositories.Html;
using Taygeta.Repositories.Models;
using System;

namespace Taygeta.MSHtml
{
    /// <summary>
    /// Wrapper for IHTMLDocument2
    /// Facade for working with DOM with MSHTML
    /// </summary>
    public class MsHtmlPageDocument : IPageDocument
    {
        private readonly IHTMLDocument2 _htmlDocument;
        private Page _page;

        private void AddAllPageElements(IPageElement pageElement)
        {
            PageElements.Add(pageElement.GetUniquePath(), pageElement);
            foreach (IPageElement child in pageElement.Children)
                AddAllPageElements(child);
        }

        public MsHtmlPageDocument()
        {
            _htmlDocument = new HTMLDocument() as IHTMLDocument2;
            PageElements = new Dictionary<string, IPageElement>();
            Timeout = 5000; // default timeout is 5 seconds
        }

        public MsHtmlPageDocument([NotNull] Page page) : this()
        {
            Load(page);
        }

        public int Timeout { get; set; }

        /// <summary>
        /// Loads a page into the document
        /// </summary>
        /// <param name="page">an html page to load</param>
        protected void Load(Page page)
        {
            PageElements.Clear();
            _htmlDocument.clear();
            _page = page;
            _htmlDocument.write(page.Content);
            _htmlDocument.close();

#if TESTING
            // if there is no message queue, mshtml cannot process DOM, so we just wait for our timeout to elapse
            Task.WaitAny(new [] {
                Task.Run(() => { while (_htmlDocument.readyState != "complete") Task.Delay(100); }) }, Timeout);
#else
            if (Task.WaitAny(new[]
                { Task.Run(() => { while (_htmlDocument.readyState != "complete") Task.Delay(100); }) }, Timeout) == -1)
                throw new TimeoutException("Document preparation timeout expired.");
#endif

            // set up an hierarchical element tree (skip not interesting tags such as DOCTYPE, xml, html and header)
            // this also creates all children
            AddAllPageElements(new MsHtmlPageElement(this, _htmlDocument.body, null));
        }

        #region IPageDocument implementation
        /// <inheritdoc />
        public IDictionary<string, IPageElement> PageElements { get; }

        /// <inheritdoc />
        public IPageElement GetElementById(string id)
        {
            return PageElements.Values.FirstOrDefault(e => e.Id == id);
        }

        /// <inheritdoc />
        public Page Page
        {
            get
            {
                return _page;
            }

            set
            {
                if (_page != value)
                    Load(value);
            }
        }
        #endregion
    }
}
