public class DataService : IDataService
{
	public ConstantsData Constants { get; }
	public GoalsData Goals { get; }
	public AgentsActionsData AgentsActions { get; }

	public DataService(IDataLoader loader)
    {
	    Constants = loader.GetData<ConstantsData>("ConstantsData");
	    Goals = loader.GetData<GoalsData>("GoalsData");
	    AgentsActions = loader.GetData<AgentsActionsData>("AgentsActionsData");
    }

}