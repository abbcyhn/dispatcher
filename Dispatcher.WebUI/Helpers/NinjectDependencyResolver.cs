namespace Dispatcher.WebUI.Helpers
{
    using System;
    using Ninject;
    using System.Web.Mvc;
    using UnitOfWorkPattern;
    using Repository.EF.UnitOfWork;    
    using System.Collections.Generic;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }


        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope();
        }
    }
}