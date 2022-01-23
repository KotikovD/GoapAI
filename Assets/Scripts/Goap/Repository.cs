using System.Collections.Generic;
using UnityEngine;


public abstract class Repository<TEnum> : IRepository<TEnum> where TEnum : System.Enum
{
    private readonly Dictionary<TEnum, ResourceGroup> _items = new Dictionary<TEnum, ResourceGroup>();
        
    public void AddItem(TEnum tType, IRepositoryItem repository)
    {
        if (_items.ContainsKey(tType))
            _items[tType].AddItem(repository);
        else
            _items.Add(tType, new ResourceGroup(repository));
    }

    protected Vector3 ShowItemNearby(TEnum tType, Vector3 position)
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

    public int GetBusyTotalAmount()
    {
        var result = 0;
        foreach (var item in _items)
            result += item.Value.TotalAmount;

        return result;
    }

    public string GetTotalAmountString()
    {
        var resultString = string.Empty;
        foreach (var resource in _items)
            resultString += resource.Key + " - " + resource.Value.TotalAmount + "\n";

        return string.IsNullOrEmpty(resultString) ? "Empty" : resultString;
    }
}