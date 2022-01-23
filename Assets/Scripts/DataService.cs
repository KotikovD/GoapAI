public class DataService : IDataService
{
	public ConstantsData Constants { get; }
	public GoalsData Goals { get; }

	public DataService(IDataLoader loader)
    {
	    Constants = loader.GetData<ConstantsData>("ConstantsData");
	    Goals = loader.GetData<GoalsData>("GoalsData");
    }

}