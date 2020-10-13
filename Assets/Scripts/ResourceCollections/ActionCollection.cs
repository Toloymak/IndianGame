using System.Collections.Generic;
using Components;

namespace ResourceCollections
{
    public static class ActionCollection
    {
        public static readonly ActionModel[] ActionModels = new []
        {
            new ActionModel()
            {
                Name = "Fire",
                Description = "Fire in storage",
                FoodEffect = -3,
                MaterialEffect = -3,
                GoldEffect = 0,
                MoraleEffect = 0,
                NeedReaction = false,
                PowerEffect = 0
            },
            new ActionModel()
            {
                Name = "Attack",
                Description = "Indian attack",
                FoodEffect = 0,
                MaterialEffect = 0,
                GoldEffect = 0,
                MoraleEffect = -5,
                NeedReaction = true,
                PowerEffect = +1
            },
            new ActionModel()
            {
                Name = "Mouse",
                Description = string.Empty,
                FoodEffect = -10,
                MaterialEffect = 0,
                GoldEffect = 0,
                MoraleEffect = 0,
                NeedReaction = false,
                PowerEffect = 0
            },
            new ActionModel()
            {
                Name = "Support",
                Description = "The ships from Europe",
                FoodEffect = +100,
                MaterialEffect = +5,
                GoldEffect = 0,
                MoraleEffect = 10,
                NeedReaction = false,
                PowerEffect = 0
            },
            new ActionModel()
            {
                Name = "Bear",
                Description = "Bear near the settlement",
                FoodEffect = 0,
                MaterialEffect = 0,
                GoldEffect = 0,
                MoraleEffect = -10,
                NeedReaction = true,
                PowerEffect = 0
            },
        };
    }
}