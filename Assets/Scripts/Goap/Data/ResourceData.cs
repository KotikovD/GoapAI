using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public sealed class ResourceData
    {
        public ResourceType resourceType = ResourceType.Wood;
        public float actionIntervalDelay = 1f;
        public ushort resourceCountPerInterval = 5;
        public ushort resourceAmount = 100;
        public ResourceType requirementsForInteraction = ResourceType.Axe;
    }
}