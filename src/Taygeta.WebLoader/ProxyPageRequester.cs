using System;
using System.Linq;
using System.Net;
using Abot.Core;
using Abot.Poco;
using JetBrains.Annotations;
using Taygeta.Repositories;
using Taygeta.Repositories.Models;

namespace Taygeta.WebLoader
{
    public class ProxyPageRequester : PageRequester
    {
        private readonly IDataSupplier _dataSupplier;
        private readonly WebProxy _webProxy = new WebProxy();

        public ProxyPageRequester([NotNull] CrawlConfiguration config, [CanBeNull] IDataSupplier dataSupplier) : base(config)
        {
            _dataSupplier = dataSupplier;
            string value;
            if(_config.ConfigurationExtensions.TryGetValue("Proxy", out value))
                _webProxy.Address = new Uri(value);
        }

        public Uri ProxyAddress
        {
            get { return _webProxy.Address; }
            set { _webProxy.Address = value; }
        }

        protected override HttpWebRequest BuildRequestObject(Uri uri)
        {
            HttpWebRequest request = base.BuildRequestObject(uri);
            
            // specify the latest version of the locally available page
            Page page = _dataSupplier?.Pages.Get(p => p.Url == uri.AbsoluteUri)
                .OrderByDescending(p => p.LastModified)
                .FirstOrDefault();
            if (page != null)
                request.IfModifiedSince = page.LastModified;

            if (ProxyAddress != null)
                request.Proxy = _webProxy;
            return request;
        }
    }
}
