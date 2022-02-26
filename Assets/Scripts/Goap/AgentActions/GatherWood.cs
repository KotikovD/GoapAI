//GOAP generated class
using System.Collections.Generic;


namespace Goap.Actions
{
    public sealed class GatherWood : AgentAction
    {
        public GatherWood(AgentActionData actionData) : base(actionData)
        {
        }

        public override bool CanPerform(List<GameEntity> gameEntities, GameEntity agent, out GameEntity actionEntity)
        {
            actionEntity = null;
            var trees = gameEntities.FindAll(x => x.hasTree 
                                                  && x.isFreeInteractionPoint 
                                                  && x.commonInventory.Inventory.HasResource(x.resourceMining.MiningResourceType));
            
            if (FindClosestObject(agent.commonView.CommonView.GetPosition, trees, out var closestTree))
            {
                actionEntity = agent.agentAction.ActionEntity == null
                    ? closestTree
                    : agent.agentAction.ActionEntity;
                
                var requirementsForInteraction = actionEntity.resourceMining.RequirementsForInteraction;
                var hasItem = requirementsForInteraction == ResourceType.None || agent.commonInventory.Inventory.HasResource(requirementsForInteraction);
                var hasAnyMore = actionEntity.commonInventory.Inventory.HasAnyResource(actionEntity.resourceMining.MiningResourceType);
                var canGetMore = agent.commonInventory.Inventory.HasAnyCapacity(out int freeCapacity);

                if (hasItem && hasAnyMore && canGetMore)
                    return true;
            }
            
            return false;
        }

        public override void ProducePerform(GameEntity agent)
        {
            agent.agentAction.ActionEntity.AddTransaction(
                agent,
                agent.agentAction.ActionEntity.resourceMining.MiningResourceType,
                agent.agentAction.ActionEntity.resourceMining.ResourceCountPerInterval);
        }
    }
}