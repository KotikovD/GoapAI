using System.Collections.Generic;
using UnityEngine;


public sealed class Repository<TEnum> : IRepository<TEnum> where TEnum : System.Enum
{
    private readonly Dictionary<TEnum, ResourceGroup> _items = new Dictionary<TEnum, ResourceGroup>();
        
    public void AddItem(TEnum tType, IRepositoryItem repository)
    {
        if (_items.ContainsKey(tType))
            _items[tType].AddItem(repository);
        else
            _items.Add(tType, new ResourceGroup(repository));
    }

    public Vector3 ShowItemNearby(TEnum tType, Vector3 position)
    {
        return _items[tType].ShowItemNearby(position);
    }
        
    public bool IsEnoughItemCount(TEnum tType, int count)
    {
        return _items.ContainsKey(tType) && _items[tType].HasEnoughCount(count);
    }

    public IRepositoryItem GetItemNearby(TEnum tType, int count, Vector3 position)
    {
        return _items[tType].GetItemNearby(count, position);
    }

    public Dictionary<TEnum, int> GetTotalAmount()
    {
        var result = new Dictionary<TEnum, int>();
            
        foreach (var item in _items)
            result.Add(item.Key, item.Value.TotalAmount);
            
        return result;
    }
        
}