namespace Dispatcher.WebUI.Models.Shared
{
    using Entity.Abstract;
    using System.Collections.Generic;

    public class GenericViewModel<T> where T : AEntity
    {
        public T Model { get; set; }
        public string Selected { get; set; }
    }

    public static class GenericModelCreator
    {
        public static IEnumerable<GenericViewModel<T>> GetGenericModel<T>(IEnumerable<T> allElements, IEnumerable<T> selectedElements) where T : AEntity
        {
            var genericModels = new List<GenericViewModel<T>>();

            foreach (var element in allElements)
            {
                string selected = "";

                if (selectedElements != null)
                {
                    foreach (var selectedElement in selectedElements)
                    {
                        if (selectedElement != null &&
                            selectedElement.Id == element.Id)
                        {
                            selected = "selected";
                            break;
                        }
                    }
                }

                genericModels.Add(new GenericViewModel<T> { Selected = selected, Model = element });
            }


            return genericModels;
        }
    }
}