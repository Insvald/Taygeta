// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using Taygeta.Repositories;
using Taygeta.Repositories.Models;
using Taygeta.UserWebSite.Models;

namespace Taygeta.UserWebSite.Controllers
{
    public class SearchController : Controller
    {
        private readonly IDataSupplier _dataSupplier;
        private readonly ILogger _logger;
        private readonly IGeoLocator _locator;
        private const int PageSize = 5;

        public SearchController(
            [NotNull] IDataSupplier dataSupplier,
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] IGeoLocator locator)
        {
            _dataSupplier = dataSupplier;
            _logger = loggerFactory.CreateLogger<SearchController>();
            _locator = locator;
        }        

        public IActionResult Index([NotNull] SearchViewModel model)
        {
            if (model.Location == null)
            {
                _logger.LogDebug("Location not specified, trying to get it from the client's IP.");
                string country;
                string city;
                string ipAddress = Context.GetFeature<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
                if (ipAddress != null && _locator.GetLocationByIp(ipAddress, out country, out city))
                {
                    model.Location = $"{city}, {country}";
                    _logger.LogDebug($"Location determined as '{model.Location}'.");
                }
            }
            _logger.LogDebug($"Searching the database with query '{model.Job}' in '{model.Location}'.");

            IList<Vacancy> allVacancies = _dataSupplier.Vacancies.Get(v =>
                (string.IsNullOrWhiteSpace(model.Job) || v.Position.ToLower().Contains(model.Job.ToLower())) &&
                (string.IsNullOrWhiteSpace(model.Location) || v.Location.ContainsOne(model.Location))).ToList();

            model.RecordCount = allVacancies.Count;
            model.PageSize = PageSize;

            _logger.LogDebug($"Found {model.RecordCount} vacancies.");

            // check that model.PageNumber is in bounds
            int lastPageNumber = (model.RecordCount + model.PageSize - 1) / model.PageSize;
            model.PageNumber = 
                model.PageNumber < 1 ? 1 :
                model.PageNumber > lastPageNumber ? lastPageNumber : model.PageNumber;
            
            model.Vacancies = allVacancies
                .Skip((model.PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            
            // check that it is AJAX request
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_SearchPartial", model);

            return View(model);
        }
    }
}
