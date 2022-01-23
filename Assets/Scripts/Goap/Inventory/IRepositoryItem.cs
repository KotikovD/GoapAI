using System;
using UnityEngine;

public interface IRepositoryItem
{
    int Count { get; set; }
    Func<Vector3> GetPosition { get; }
}