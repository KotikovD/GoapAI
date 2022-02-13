//GOAP generated class

using System;
using Goap.Actions;

public sealed class AgentActionsCollection : AgentActionsKeeper
{
    private readonly AgentsActionsData _actionsData;

    public AgentActionsCollection(GameContext context)
    {
        _actionsData = context.dataService.value.AgentsActions;

        var collectWoodData = GetData(nameof(GatherWood));
        var collectWood = new GatherWood(collectWoodData);
        
        Add(collectWood);
    }

    private AgentActionData GetData(string actionName)
    {
        var actionData = _actionsData.AgentsActions.Find(x => String.Equals(x.ActionName, actionName, StringComparison.CurrentCultureIgnoreCase));

        if (actionData == null)
            throw new Exception("Didn't found actionName = " + actionName + " in AgentsActionsData SO");
        
        return actionData;
    }
}