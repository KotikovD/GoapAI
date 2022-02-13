using System;
using System.Collections.Generic;
using System.Linq;
using Entitas.Unity;
using UnityEngine;





public class TestGameLoader : IGameLoader
{
    private readonly GameContext _context;

    public TestGameLoader(GameContext context)
    {
        _context = context;
    }
    
    public void Load()
    {
        InitTestSceneWithTestData();
    }

    /// <summary>
    /// Method works with test scene only
    /// </summary>
    private void InitTestSceneWithTestData()
    {
        InitUnits();
        InitGameResources();
        InitPlayerBuildings();
        InitWorldInventory();
    }

    private void InitWorldInventory()
    {
        var worldInventory = _context.CreateEntity();
        worldInventory.AddWorldInventory(new WorldInventoryFacade(Int32.MaxValue));

        var startResources = new Dictionary<ResourceType, int>()
        {
            {ResourceType.Wood, 100},
            {ResourceType.Stone, 50}
        };
        
        worldInventory.AddResourceSetter(startResources);
    }

    private void InitPlayerBuildings()
    {
        var baseView = GameObject.FindObjectOfType<PlayerBaseView>();
        var baseLink = baseView.GetComponent<EntityLink>();
        var baseEntity = _context.CreateEntity();
        baseEntity.AddPlayerBase(baseView);
        baseLink.Link(baseEntity);
    }

    private void InitGameResources()
    {
        var trees = GameObject.FindObjectsOfType<TreeView>();
        foreach (var tree in trees)
        {
            var woodSetupData = _context.dataService.value.Constants.GetResourceConfig(ResourceType.Wood);
            var entity = tree.GetComponent<EntityLink>();
            var treeEntity = _context.CreateEntity();
            treeEntity.AddTree(tree);
            treeEntity.AddCommonView(tree.CommonView);
            treeEntity.AddCommonInventory(new CommonInventoryFacade(Int32.MaxValue));
            
            var miningResource = new Dictionary<ResourceType, int>() {{woodSetupData.resourceType, woodSetupData.resourceAmount}};
            treeEntity.AddResourceSetter(miningResource);
            
            treeEntity.AddResourceMining(
                woodSetupData.resourceType,
                woodSetupData.actionIntervalDelay, 
                woodSetupData.resourceCountPerInterval,
                woodSetupData.requirementsForInteraction);

            treeEntity.isFreeInteractionPoint = true;
            entity.Link(treeEntity);
        }
    }

    private void InitUnits()
    {
        var workers = GameObject.FindObjectsOfType<AgentView>();
        foreach (var worker in workers)
        {
            var entity = worker.GetComponent<EntityLink>();
            var workerEntity = _context.CreateEntity();
            workerEntity.AddAgentView(worker);
            workerEntity.AddCommonView(worker.CommonView);
            var maxCapacity = _context.dataService.value.Constants.AgentMaxResourceCapacity;
            workerEntity.AddCommonInventory(new CommonInventoryFacade(maxCapacity));

            if (workers.Length > 1 && workers.First().Equals(worker))
            {
                var startResources = new Dictionary<ResourceType, int>()
                {
                    {ResourceType.Wood, 20},
                    {ResourceType.Stone, 10}
                };
                workerEntity.AddResourceSetter(startResources);
            }
            
            entity.Link(workerEntity);
        }
        
    }
}