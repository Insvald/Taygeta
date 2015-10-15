// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Globalization;
using System.Threading;
using JetBrains.Annotations;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Localization;
using Taygeta.Repositories;
using Taygeta.Repositories.Html;
using Taygeta.Rsp;

namespace Taygeta.UserWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPageDocument _pageDocument;
        private readonly IDataSupplier _dataSupplier;

        public HomeController(
            [NotNull] IPageDocument pageDocument,
            [NotNull] IDataSupplier dataSupplier,
            [NotNull] ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
            _pageDocument = pageDocument;
            _dataSupplier = dataSupplier;
        }

        public IActionResult Index()
        {
            _logger.LogDebug($"Home page hit by {Context.GetFeature<IHttpConnectionFeature>()?.RemoteIpAddress}.");
            // TODO sliding expiration for cookie
            ViewData["CultureCode"] = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToUpper();
            return View();
        }

        [HttpGet]
        public IActionResult Language([NotNull] string code)
        {
            string cookieValue = 
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(new CultureInfo(code)));
            Context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                cookieValue,
                new CookieOptions { Expires = DateTime.Now + new TimeSpan(365, 0, 0, 0) }); // set the cookie for one year
            _logger.LogDebug($"Culture cookie is set: ({CookieRequestCultureProvider.DefaultCookieName}={cookieValue}).");

            //reload the the page to enable the cookie
            return RedirectToAction(nameof(HomeController.Index));
        }

        [Authorize]
        public IActionResult VacancyRefresh()
        {
            RspExtractor extractor = new RspExtractor(_pageDocument, _dataSupplier, _logger);
            extractor.Run();
            return RedirectToAction(nameof(HomeController.Index));
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
