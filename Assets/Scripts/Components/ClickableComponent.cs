using Enums;

namespace Components
{
    public class ClickableComponent
    {
        public bool IsClicked { get; set; }
        public bool IsActionCompleted { get; set; }
        public ActionType ActionType { get; set; }
    }
}