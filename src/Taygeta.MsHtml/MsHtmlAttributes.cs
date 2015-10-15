// The Taygeta Project
// (c) 2015 Ilya Rovensky

using mshtml;
using System;
using Taygeta.Repositories.Html;

namespace Taygeta.MSHtml
{
    public class MsHtmlAttributes : IPageElementAttributes
    {
        private readonly IHTMLElement _htmlElement;

        public MsHtmlAttributes(IHTMLElement htmlElement)
        {
            _htmlElement = htmlElement;
        }

        /// <inheritdoc />
        public string this[string key]
        {
            get
            {
                dynamic v = _htmlElement.getAttribute(key, 2);
                string result = DBNull.Value.Equals(v) ? null : v;
                return result;
            }
        }
    }
}
