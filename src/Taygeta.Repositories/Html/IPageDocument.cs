// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.Collections.Generic;
using Taygeta.Repositories.Models;

namespace Taygeta.Repositories.Html
{
    /// <summary>
    /// Interface encapsulating an HTML page and DOM
    /// </summary>
    public interface IPageDocument
    {
        /// <summary>
        /// Get specific element with known id
        /// </summary>
        /// <param name="id">id to find</param>
        /// <returns>found element or null otherwise</returns>
        IPageElement GetElementById(string id);

        /// <summary>
        /// List of all elements (tags) with their unique paths as keys
        /// </summary>
        IDictionary<string, IPageElement> PageElements { get; }

        /// <summary>
        /// Current html page 
        /// </summary>
        Page Page { get; set; }
    }
}
