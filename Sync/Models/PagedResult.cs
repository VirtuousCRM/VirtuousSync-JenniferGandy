using System.Collections.Generic;

namespace Sync.Models
{
    public class PagedResult<T>
    {
        public int Total { get; set; }

        public List<T> List { get; set; }
    }
}
