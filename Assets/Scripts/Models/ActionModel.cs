using System;

namespace Components
{
    public class ActionModel
    {
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool NeedReaction { get; set; }
        
        public float FoodEffect { get; set; }
        public float GoldEffect { get; set; }
        public float MaterialEffect { get; set; }
        public float MoraleEffect { get; set; }
        public float PowerEffect { get; set; }

        public string NeedReactionString
            => NeedReaction ? "NEED REACTION" : "";

    }
}