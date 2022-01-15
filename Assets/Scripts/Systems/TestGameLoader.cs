using System;
using System.Linq;
using Entitas.Unity;
using UnityEngine;


public class TestGameLoader : IGameLoader
{
    private readonly Contexts _context;

    public TestGameLoader(Contexts context)
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
        var baseView = InitPlayerBuildings();
        InitWorldInventory(baseView);
    }

    private void InitWorldInventory(PlayerBaseView baseView)
    {
        var worldInventory = _context.game.CreateEntity();
        worldInventory.AddWorldInventory(new Repository<ResourceType>());
        worldInventory.worldInventory.Inventory.AddItem(ResourceType.Wood, new RepositoryItem(100, () => baseView.InteractionPoint));
    }

    private PlayerBaseView InitPlayerBuildings()
    {
        var baseView = GameObject.FindObjectOfType<PlayerBaseView>();
        var baseLink = baseView.GetComponent<EntityLink>();
        var baseEntity = _context.game.CreateEntity();
        baseEntity.isPlayerBase = true;
        baseLink.Link(baseEntity);
        return baseView;
    }

    private void InitGameResources()
    {
        var trees = GameObject.FindObjectsOfType<TreeView>();
        foreach (var tree in trees)
        {
            var entity = tree.GetComponent<EntityLink>();
            var treeEntity = _context.game.CreateEntity();
            //treeEntity.Add

            entity.Link(treeEntity);
        }
    }

    private void InitUnits()
    {
        var workers = GameObject.FindObjectsOfType<WorkerView>();
        foreach (var worker in workers)
        {
            var entity = worker.GetComponent<EntityLink>();
            var workerEntity = _context.game.CreateEntity();
            workerEntity.isAgent = true;
            workerEntity.AddAgentInventory(new Repository<ResourceType>());
           
            if (workers.Length > 1 && workers.First().Equals(worker))
                workerEntity.agentInventory.Inventory.AddItem(ResourceType.Wood, new RepositoryItem(50, () => worker.transform.position));
            
            entity.Link(workerEntity);
        }
        
    }
}