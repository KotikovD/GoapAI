public sealed class WorldInventoryFacade
{
    private readonly ResourceRepository _repository;
    public WorldInventoryFacade()
    {
        _repository = new ResourceRepository();
    }
    
    public void AddItem(ResourceType tType, IRepositoryItem repository)
    {
        _repository.AddItem(tType, repository);
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