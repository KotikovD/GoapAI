using UnityEngine;


public sealed class CommonInventoryFacade
{
    private readonly ResourceRepository _repository;
    public CommonInventoryFacade()
    {
        _repository = new ResourceRepository();
    }
    
    public void AddItem(ResourceType tType, IRepositoryItem repository)
    {
        _repository.AddItem(tType, repository);
    }

    public bool RemoveItem(ResourceType tType, int count)
    {
        var isEnough = _repository.IsEnoughItemCount(tType, count);

        if (isEnough)
            _repository.GetItemNearby(tType, count, Vector3.zero);

        return isEnough;
    }
    
    public bool GetItem(ResourceType tType, int count, out IRepositoryItem item)
    {
        item = null;
        var isEnough = _repository.IsEnoughItemCount(tType, count);

        if (isEnough)
            item = _repository.GetItemNearby(tType, count, Vector3.zero);

        return isEnough;
    }

    public int GetBusyTotalAmount()
    {
        return _repository.GetBusyTotalAmount();
    }

    public string GetTotalAmountString()
    {
        return _repository.GetTotalAmountString();
    }
    
}