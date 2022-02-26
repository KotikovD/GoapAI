//GOAP generated class

using Goap.Actions;

public sealed class AgentActionsCollection : AgentActionsKeeper
{
    public AgentActionsCollection(GameContext context)
    {
        var actionsData = context.dataService.value.AgentsActions;

        var collectWoodData = GetData(nameof(GatherWood), actionsData);
        var collectWood = new GatherWood(collectWoodData);
        
        Add(collectWood);
    }

 
}