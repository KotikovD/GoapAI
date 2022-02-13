using UnityEngine;


public sealed class CommonInventoryFacade
{
    private readonly ResourceRepository _repository;
    
    
    public CommonInventoryFacade(int maxResourceCapacity)
    {
        _repository = new ResourceRepository(maxResourceCapacity);
    }
    
    public void AddResource(ResourceType tType, IRepositoryItem repository)
    {
        _repository.AddItem(tType, repository);
    }

    public bool HasResource(ResourceType tType, int count = 1)
    {
        var isEnough = _repository.IsEnoughItemCount(tType, count);
        return isEnough;
    }
    
    public bool RemoveResource(ResourceType tType, int count)
    {
        var isEnough = _repository.IsEnoughItemCount(tType, count);

        if (isEnough)
            _repository.GetItemNearby(tType, count, Vector3.zero);

        return isEnough;
    }
    
    public bool GetResource(ResourceType tType, int count, out IRepositoryItem item)
    {
        item = null;
        var isEnough = _repository.IsEnoughItemCount(tType, count);

        if (isEnough)
            item = _repository.GetItemNearby(tType, count, Vector3.zero);

        return isEnough;
    }

    public int GetResourceCount(ResourceType tType)
    {
        return _repository.GetResourceCount(tType);
    }
    
    public int GetBusyTotalAmount()
    {
        return _repository.GetBusyTotalAmount();
    }

    public string GetTotalAmountString()
    {
        return _repository.GetTotalAmountString();
    }

    public bool CanGetMoreResources(int resourceValue)
    {
        return _repository.CanGetMoreResources(resourceValue);
    }
}