using Entitas;
using UnityEngine;


public class InitializeInputSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private const float RAY_DISTANCE = 100f;
    private InputControls _input;
    private Camera _camera;
    private GameEntity _inputEntity;

    public InitializeInputSystem(GameContext context)
    {
        _context = context;
    }
		
    public void Initialize()
    {
        _camera = Camera.main;
        _inputEntity = _context.CreateEntity();
        _inputEntity.isInput = true;
        _inputEntity.AddCamera(_camera);
        
        _input = new InputControls();
        _input.Mouse.Choose.performed += context => Choose();
        _input.Mouse.ClearUi.performed += context => ClearUi();
        _input.Enable();
    }
    
    private void Choose()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, RAY_DISTANCE))
            _inputEntity.ReplaceInputClick(hit.point);
        else
            Debug.LogError("Raycast doesn't get anything");
        
    }

    private void ClearUi()
    {
        _context.gameUi.View.ClearAgentView();
    }
}