// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Abot.Crawler;
using Abot.Poco;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Taygeta.Repositories;
using Taygeta.Repositories.Models;
using System.Linq;

namespace Taygeta.WebLoader
{
    /// <summary>
    /// The Vacancy Crawler
    /// TODO proxy support
    /// </summary>
    public class VacancyCrawler : PoliteWebCrawler
    {
        public enum CrawlMode
        {
            Free,
            SingleSite,
            Catalog
        };

        private PageToCrawl _currentPage;
        private readonly IDictionary<string, string> _vacancyPages = new Dictionary<string, string>();
        private readonly IDataSupplier _dataSupplier;
        private string _jobSynonyms;
        private string[] _cultures;

        public VacancyCrawler([NotNull] CrawlConfiguration crawlConfiguration, [NotNull] IDataSupplier dataSupplier) : base(
                crawlConfiguration,
                null,
                null,
                null,
                new ProxyPageRequester(crawlConfiguration, dataSupplier), 
                new PreciseHyperLinkParser(),
                null,
                null,
                null)
        {
            _dataSupplier = dataSupplier;           

            //set up a delegate to check links
            (_hyperLinkParser as IHyperLinkCheck)?.ShoudCrawlLink(CheckLink);

            //set up a handler for crawled page
            //PageCrawlCompletedAsync += StoreCrawledPage;
            PageCrawlCompleted += StoreCrawledPage; // maybe it helps solving problems with multithreading?
        }

        public string[] Cultures
        {
            get { return _cultures; }
            set
            {
                _cultures = value;
                //reading job synonyms from storage matching specified languages
                _jobSynonyms =
                    _dataSupplier.Resources.Get(keyword => _cultures.Contains(keyword.CultureName) && keyword.Name == "vacancyPageTitle")
                    .Select(e => e.Value)
                    .First();
            }
        }

        public CrawlMode Mode { get; set; } = CrawlMode.Free;

        protected virtual void StoreCrawledPage(object sender, PageCrawlCompletedArgs e)
        {
            string title;
            // check that the page is in the list
            if (_vacancyPages.TryGetValue(e.CrawledPage.Uri.AbsoluteUri, out title))
            {
                // trying to find the same version of  the page in the database
                // TODO a solution for sites without correct Last-Modified behavior
                // TODO not thread-safe, rewrite!
                bool found = _dataSupplier.Pages.Get(
                    p => p.Url == e.CrawledPage.Uri.AbsoluteUri &&
                    p.LastModified == e.CrawledPage.HttpWebResponse.LastModified).Any();
                if (!found) 
                    _dataSupplier.Pages.Add(new Page
                    {
                        Url = e.CrawledPage.Uri.AbsoluteUri,
                        Content = e.CrawledPage.Content.Text,
                        HomePageTitle = title,
                        LastModified = e.CrawledPage.HttpWebResponse.LastModified
                    });
            }
        }

        protected override void ProcessPage(PageToCrawl pageToCrawl)
        {
            _currentPage = pageToCrawl;
            base.ProcessPage(pageToCrawl);
            _vacancyPages.Clear();
        }

        protected virtual CrawlDecision CheckLink(HtmlNode node)
        {
            CrawlDecision decision = new CrawlDecision { Allow = false };

            try
            {
                Uri nodeUri = new Uri(node.Attributes["href"].Value);

                switch (Mode)
                {
                    case CrawlMode.Free:
                        decision.Allow = true;
                        break;
                    case CrawlMode.Catalog:
                        //allow links inside the catalog
                        if (_crawlContext.RootUri.Authority == nodeUri.Authority)
                            decision.Allow = true;
                        //allow outside links from the catalog                    
                        else if ((_currentPage.Uri.Authority == _crawlContext.RootUri.Authority) &&
                            (_crawlContext.RootUri.Authority != nodeUri.Authority) /*&&
                            (node.ParentNode?.Attributes["class"]?.Value == "mapme_place")*/)
                            decision.Allow = true;
                        //allow all other links with vacancies page pattern 
                        else goto case CrawlMode.SingleSite;
                        break;
                    case CrawlMode.SingleSite:
                        //check for vacancies page pattern 
                        if (node.InnerText.ContainsOne(_jobSynonyms) && !_vacancyPages.ContainsKey(nodeUri.AbsoluteUri))
                        {
                            //add the link to list, saving a page title
                            _vacancyPages.Add(nodeUri.AbsoluteUri, node.OwnerDocument.DocumentNode.SelectSingleNode("//head/title").InnerHtml);
                            decision.Allow = true;
                        }
                        break;
                }
            }
            catch (UriFormatException) { }

            return decision;
        }
    }
}
