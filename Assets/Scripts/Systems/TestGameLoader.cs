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
        CreateTestData();
    }

    /// <summary>
    /// Method works with test scene only
    /// </summary>
    private void CreateTestData()
    {
        InitUnits();
        InitGameResources();
        InitPlayerBuildings();
        InitWorldInventory();
    }

    private void InitWorldInventory()
    {
        var worldInventory = _context.CreateEntity();
        worldInventory.AddWorldInventory(new Repository<ResourceType>());

        var startResources = new Dictionary<ResourceType, int>()
        {
            {ResourceType.Wood, 100},
            {ResourceType.Stone, 50}
        };
        
        worldInventory.AddResourceItem(startResources);
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
            var entity = tree.GetComponent<EntityLink>();
            var treeEntity = _context.CreateEntity();
            //treeEntity.Add

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
            workerEntity.AddAgent(worker);
            workerEntity.AddAgentInventory(new Repository<ResourceType>());

            if (workers.Length > 1 && workers.First().Equals(worker))
            {
                var startResources = new Dictionary<ResourceType, int>()
                {
                    {ResourceType.Wood, 20},
                    {ResourceType.Stone, 10}
                };
                workerEntity.AddResourceItem(startResources);
                // workerEntity.agentInventory.Inventory.AddItem(ResourceType.Wood, new RepositoryItem(50, () => worker.transform.position));}
            }

            entity.Link(workerEntity);
        }
        
    }
}