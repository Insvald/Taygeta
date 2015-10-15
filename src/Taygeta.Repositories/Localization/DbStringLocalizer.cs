// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Framework.Localization;
using Taygeta.Repositories.Models;

namespace Taygeta.Repositories.Localization
{
    /// <summary>
    /// Implementation of IStringLocalizer for database stored localization strings
    /// </summary>
    public class DbStringLocalizer : IStringLocalizer
    {
        private readonly IDataSupplier _dataSupplier;
        private readonly CultureInfo _cultureInfo;
        protected const string DefaultCultureName = "en-US";

        public DbStringLocalizer([NotNull] IDataSupplier dataSupplier, CultureInfo cultureInfo = null)
        {
            _dataSupplier = dataSupplier;
            _cultureInfo = cultureInfo ?? new CultureInfo(DefaultCultureName);
        }

        /// <inheritdoc />
        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
        {
            if (includeAncestorCultures && _cultureInfo.Name != DefaultCultureName)
                return
                    from l in _dataSupplier.Resources.Get(e => e.CultureName == DefaultCultureName)
                    join r in _dataSupplier.Resources.Get(e => e.CultureName == _cultureInfo.Name) on l.Name equals r.Name into ps
                    from p in ps.DefaultIfEmpty()
                    select new LocalizedString(p.Name, p.Value ?? l.Value, p.Value == null);

            return _dataSupplier.Resources
                .Get(r => r.CultureName == _cultureInfo.Name)
                .Select(e => new LocalizedString(e.Name, e.Value));
        }

        /// <inheritdoc />
        public IStringLocalizer WithCulture(CultureInfo cultureInfo)
        {
            return new DbStringLocalizer(_dataSupplier, cultureInfo);
        }

        /// <inheritdoc />
        public LocalizedString this[string name] => this[name, null];

        /// <inheritdoc />
        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                Resource result = _dataSupplier.Resources.Get(r => r.Name == name && r.CultureName == _cultureInfo.Name).FirstOrDefault();
                bool notFound = result == null && _cultureInfo.Name != DefaultCultureName;
                // if no localized string exists, try to fetch default (en-US) string
                if (notFound)
                    result = _dataSupplier.Resources.Get(r => r.Name == name && r.CultureName == DefaultCultureName).FirstOrDefault();

                if (result == null)
                    throw new KeyNotFoundException();

                string value = arguments == null ? result.Value : string.Format(result.Value, arguments);
                
                return new LocalizedString(name, value, notFound);
            }
        }
    }
}
