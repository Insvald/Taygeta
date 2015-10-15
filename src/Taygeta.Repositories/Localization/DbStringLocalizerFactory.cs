// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Threading;
using JetBrains.Annotations;
using Microsoft.Framework.Localization;

namespace Taygeta.Repositories.Localization
{
    /// <summary>
    /// Implementation of the database stored localization strings
    /// </summary>
    public class DbStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IDataSupplier _dataSupplier;

        public DbStringLocalizerFactory([NotNull] IDataSupplier dataSupplier)
        {
            _dataSupplier = dataSupplier;
        }

        /// <inheritdoc />
        public IStringLocalizer Create(Type resourceSource)
        {
            return Create(null, null);
        }

        /// <inheritdoc />
        public IStringLocalizer Create([CanBeNull] string baseName, [CanBeNull] string location)
        {
            return new DbStringLocalizer(_dataSupplier, Thread.CurrentThread.CurrentCulture);
        }
    }
}
