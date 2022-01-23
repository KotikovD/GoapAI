using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public sealed class ResourceData
    {
        public ResourceType resourceType = ResourceType.Wood;
        public float actionIntervalDelay = 1f;
        public int resourceCountPerInterval = 5;
        public int resourceAmount = 100;
        public ResourcePlace resourcePlace = ResourcePlace.MiningLocation;
        public ResourceType requirementsForInteraction = ResourceType.Axe;
    }
}