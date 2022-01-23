using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public sealed class ResourceGroup
{
    private readonly List<IRepositoryItem> _items;

    public ResourceGroup(IRepositoryItem repositoryItem)
    {
        _items = new List<IRepositoryItem>() {repositoryItem};
    }
        
    public int TotalAmount => _items.Select(x => x.Count).Sum();
    
    public bool HasEnoughCount(int value)
    {
        return _items.Any(x => x.Count >= value);
    }
    
    public Vector3 ShowItemNearby(Vector3 position)
    {
        return _items.OrderBy(x => Vector3.Distance(position, x.GetPosition.Invoke())).First().GetPosition();
    }
        
    public IRepositoryItem GetItemNearby(int count, Vector3 position)
    {
        var foundItems = _items.FindAll(x => x.Count >= count);
        
        if(foundItems.Count == 0)
             throw new Exception("You trying get more than inventory contains. Use \"HasEnoughCount\" function before");
        
        var resultItem = foundItems.OrderBy(x => Vector3.Distance(position, x.GetPosition.Invoke())).First();
        resultItem.Count -= count;
        
        return resultItem;
    }
        
    public void AddItem(IRepositoryItem repositoryItem)
    {
        if(repositoryItem.Count <= 0)
            throw new Exception("You trying add count lower than 0, your value = " + repositoryItem.Count);
        
        _items.Add(repositoryItem);
    }
        
}