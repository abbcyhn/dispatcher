namespace Dispatcher.WebUI.Models.Shared
{
    using Entity.Abstract;
    using System.Collections.Generic;

    public class GenericLibraryViewModel<T> where T : AEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public IEnumerable<T> Models { get; set; }
    }
}