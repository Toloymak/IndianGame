using System.Collections.Generic;

namespace Components
{
    public class ActionComponent
    {
        public IList<ActionModel> ActionModels { get; set; } = new List<ActionModel>();
    }
}