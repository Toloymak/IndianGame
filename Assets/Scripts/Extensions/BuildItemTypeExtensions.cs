using System;
using System.Diagnostics;
using Components;
using Enums;

namespace Extensions
{
    public static class BuildItemTypeExtensions
    {
        public static EffectItem GetResources(this BuildItemType type)
        {
            switch (type)
            {
                case BuildItemType.Grocery:
                    return new EffectItem(type.ToString())
                    {
                        Gold = 10,
                        Stability = 1
                    };
                case BuildItemType.Church:
                    return new EffectItem(type.ToString())
                    {
                        Stability = 5
                    };
                case BuildItemType.Barracks:
                    return new EffectItem(type.ToString())
                    {
                        Stability = 10
                    };
                case BuildItemType.TownHall:
                    return new EffectItem(type.ToString())
                    {
                        Gold = 10,
                        Stability = 2
                    };
                case BuildItemType.Storage:
                    return new EffectItem(type.ToString())
                    {
                        Stability = 5
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}