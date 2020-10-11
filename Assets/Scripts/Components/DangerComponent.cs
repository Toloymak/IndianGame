using System.Collections.Generic;

namespace Components
{
    public class DangerComponent
    {
        public long Value { get; set; }
        public IList<DangerItem> Items { get; set; }
    }
}