using System;
using Client.Enums;
using Enums;
using UnityEngine;

namespace Components {
    public class StructureComponent
    {
        public GameObject Object { get; set; }
        public StructureStatus Status { get; set; }
        public BuildItemType Type { get; set; }
        public Guid Id { get; set; }
    }
}