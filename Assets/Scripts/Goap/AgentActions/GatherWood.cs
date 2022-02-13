//GOAP generated class

using System;
using System.Collections.Generic;
using RSG;
using UnityEngine;


namespace Goap.Actions
{
    public sealed class GatherWood : AgentAction
    {
        public GatherWood(AgentActionData actionData) : base(actionData)
        {
        }
 
        public override bool PrePerform(List<GameEntity> gameEntities, GameEntity agent)
        {
            var trees = gameEntities.FindAll(x => x.hasTree 
                                                  && x.isFreeInteractionPoint 
                                                  && x.commonInventory.Inventory.HasResource(x.resourceMining.MiningResourceType));
            if (FindClosestObject(agent.commonView.CommonView.GetPosition, trees, out var closestTree))
            {
                var requirementsForInteraction = closestTree.resourceMining.RequirementsForInteraction;
                var hasItem = requirementsForInteraction == ResourceType.None || agent.commonInventory.Inventory.HasResource(requirementsForInteraction);
                var canGetMore = agent.commonInventory.Inventory.CanGetMoreResources(closestTree.resourceMining.ResourceCountPerInterval);
                
                if (hasItem && canGetMore)
                {
                    agent.agentAction.ActionEntity = closestTree;
                    return true;
                }
            }
            
            return false;
        }

        public override void CompletePerform(GameEntity agent)
        {
            agent.agentAction.ActionEntity.AddTransaction(
                agent,
                agent.agentAction.ActionEntity.resourceMining.MiningResourceType,
                agent.agentAction.ActionEntity.resourceMining.ResourceCountPerInterval);
        }
    }
}