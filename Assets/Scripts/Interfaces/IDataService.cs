using Entitas.CodeGeneration.Attributes;


[Game, Unique, ComponentName("DataService")]
public interface IDataService
{
    public ConstantsData Constants { get; }
}