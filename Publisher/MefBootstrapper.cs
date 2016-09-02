using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Windows;

namespace Publisher
{
    /// <summary>
    /// The MefBootstrapper
    /// </summary>
    public class MefBootstrapper : BootstrapperBase
    {
        /// <summary>
        /// The container
        /// </summary>
        private CompositionContainer container;

        /// <summary>
        /// The constructor
        /// </summary>
        public MefBootstrapper()
        {
            Initialize();
        }

        /// <summary>
        /// Configure MefBootstrapper
        /// </summary>
        protected override void Configure()
        {
            var catalog =
            new AggregateCatalog(
                AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>());

            container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(container);

            container.Compose(batch);
        }

        /// <summary>
        /// GetInstance MefBootstrapper
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        /// <summary>
        /// GetAllInstances MefBootstrapper
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        /// <summary>
        /// BuildUp MefBootstrapper
        /// </summary>
        /// <param name="instance"></param>
        protected override void BuildUp(object instance)
        {
            container.SatisfyImportsOnce(instance);
        }

        /// <summary>
        /// Handle action when start MefBootstrapper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }
    }
}
