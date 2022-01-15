public class DataService : IDataService
{
	public ConstantsData Constants { get; }
	
    public DataService(IDataLoader loader)
    {
	    Constants = loader.GetData<ConstantsData>("ConstantsData");
    }

}