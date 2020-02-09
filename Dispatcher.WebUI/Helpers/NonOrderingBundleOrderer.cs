namespace Dispatcher.WebUI.Helpers
{
    using System.Web.Optimization;
    using System.Collections.Generic;
    
    public class NonOrderingBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}