using System;
using System.Diagnostics;
using Components;
using Enums;

namespace Extensions
{
    public static class BuildItemTypeExtensions
    {
        public static ResourceItem GetResources(this BuildItemType type)
        {
            switch (type)
            {
                case BuildItemType.Grocery:
                    return new ResourceItem(type.ToString())
                    {
                        Gold = 10,
                        Stability = 1
                    };
                case BuildItemType.Church:
                    return new ResourceItem(type.ToString())
                    {
                        Stability = 5
                    };
                case BuildItemType.Barracks:
                    return new ResourceItem(type.ToString())
                    {
                        Stability = 10
                    };
                case BuildItemType.TownHall:
                    return new ResourceItem(type.ToString())
                    {
                        Gold = 10,
                        Stability = 2
                    };
                case BuildItemType.Storage:
                    return new ResourceItem(type.ToString())
                    {
                        Stability = 5
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}