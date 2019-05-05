using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Sample.API.Cmdlets
{
    public class PSDeferredEnumerable //: IEnumerable
    {
        internal IEnumerable<PSObject> Collection { get; set; }
        //private readonly IEnumerable<PSDeferredEnumerable> _deferredEnumerable;

        public PSDeferredEnumerable()
        {
            //_deferredEnumerable = new[] { this };
        }

        //public IEnumerator GetEnumerator() => _deferredEnumerable.GetEnumerator();
    }

    internal static class PSDeferredEnumerableExtensions
    {
        public static PSDeferredEnumerable AsPSDeferredEnumerable(this List<PSObject> collection) =>
            collection.Select(e => e?.ImmediateBaseObject).OfType<PSDeferredEnumerable>().LastOrDefault() ?? new PSDeferredEnumerable { Collection = collection };


        //public static PSDeferredEnumerable AsPSDeferredEnumerable(this List<object> collection) =>
        //    collection.OfType<PSDeferredEnumerable>().LastOrDefault() ?? new PSDeferredEnumerable { Collection = collection };
        //public static PSDeferredEnumerable AsPSDeferredEnumerable(this List<object> collection) =>
        //    collection.Select(e => e.ImmediateBaseObject).OfType<PSDeferredEnumerable>().LastOrDefault() ?? new PSDeferredEnumerable { Collection = collection };
    }
}