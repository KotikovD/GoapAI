using Entitas.CodeGeneration.Attributes;


[Game, Unique, ComponentName("DataService")]
public interface IDataService
{
    public ConstantsData Constants { get; }
    public GoalsData Goals { get; }
    public AgentsActionsData AgentsActions { get; }
}