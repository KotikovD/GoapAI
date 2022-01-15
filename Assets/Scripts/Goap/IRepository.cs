using System.Collections.Generic;
using UnityEngine;

public interface IRepository<TEnum>
{
    void AddItem(TEnum tType, IRepositoryItem repository);
    bool IsEnoughItemCount(TEnum tType, int count);
    IRepositoryItem GetItemNearby(TEnum tType, int count, Vector3 position);
    Dictionary<TEnum, int> GetTotalAmount();
}