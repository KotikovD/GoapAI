using Entitas;
using Entitas.Unity;
using UnityEngine;

public class InitializeGameUiSystem : IInitializeSystem
{
    private GameContext _context;

    public InitializeGameUiSystem(GameContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        var view = GameObject.FindObjectOfType<GameUiView>();
        var viewLink = view.GetComponent<EntityLink>();
        var entity = _context.CreateEntity();
        entity.AddGameUi(view);
        viewLink.Link(entity);
        entity.gameUi.View.ClearAllUi();
    }
}