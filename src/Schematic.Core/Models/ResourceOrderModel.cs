using System.Collections.Generic;
using System.Linq;

namespace Schematic.Core
{
    public class ResourceOrderModel<T>
    {
        public List<T> Resources { get; set; }

        public IDictionary<int, int> ResourceOrder { get; set; }

        private string _facets;
        public string Facets
        {
            get => _facets;
            set
            {
                _facets = value;
                UpdateFacetDictionary();
            }
        }

        public Dictionary<string, string> FacetDictionary { get; set; }

        private List<KeyValuePair<string, string>> _errors { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Errors 
        { 
            get => _errors ?? new List<KeyValuePair<string, string>>(); 
        }

        protected void UpdateFacetDictionary()
        {
            FacetDictionary = _facets.GetFacets();
        }

        public void AddModelError(string key, string errorMessage)
        {
            var error = new KeyValuePair<string, string>(key, errorMessage);
            _errors.Add(error);
        }
    }
}