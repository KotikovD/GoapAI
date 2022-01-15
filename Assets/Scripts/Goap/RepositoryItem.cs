using System;
using UnityEngine;

public sealed class RepositoryItem : IRepositoryItem
{
    public int Count { get; set; }
    public Func<Vector3> GetPosition { get; }

    public RepositoryItem(int count, Func<Vector3> getPositionFunc)
    {
        Count = count;
        GetPosition = getPositionFunc;
    }
}