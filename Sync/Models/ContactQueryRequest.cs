using System.Collections.Generic;

namespace Sync.Models
{
    public class ContactQueryRequest
    {
        public ContactQueryRequest()
        {
            Groups = new List<Group>();
            SortBy = "Id";
            Descending = false;
        }

        public List<Group> Groups { get; set; }

        public string SortBy { get; set; }

        public bool Descending { get; set; }
    }
}
