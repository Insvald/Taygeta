// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Collections.Generic;
using Abot.Poco;
using Abot.Core;
using HtmlAgilityPack;

namespace Taygeta.WebLoader
{
    public interface IHyperLinkCheck
    {
        void ShoudCrawlLink(Func<HtmlNode, CrawlDecision> decisionMaker);
    }

    /// <summary>
    /// Parser with a possibility to filter out individual links
    /// </summary>
    public class PreciseHyperLinkParser : HapHyperLinkParser, IHyperLinkCheck
    {
        private Func<HtmlNode, CrawlDecision> _linkDecisionMaker;

        public void ShoudCrawlLink(Func<HtmlNode, CrawlDecision> decisionMaker)
        {
            _linkDecisionMaker += decisionMaker;
        }

        /// <summary>
        /// Method overriden to insert a test for the link node
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        protected override List<string> GetLinks(HtmlNodeCollection nodes)
        {
            List<string> hrefs = new List<string>();

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    if (HasRelNoFollow(node))
                        continue;

                    string hrefValue = node.Attributes["href"].Value;
                    if (!string.IsNullOrWhiteSpace(hrefValue))
                    {
                        CrawlDecision decision = (_linkDecisionMaker != null) ? _linkDecisionMaker.Invoke(node) : new CrawlDecision { Allow = true };
                        if (decision.Allow)
                            hrefs.Add(DeEntitize(hrefValue));
                    }
                }
            }

            return hrefs;
        }
    }
}
