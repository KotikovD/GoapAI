using UnityEngine;


public class GameController : MonoBehaviour
{
    private Contexts _contexts;
    private GameSystems _gameSystems;


    private void Start()
    {
        _contexts = new Contexts();
        _gameSystems = new GameSystems(_contexts.game);
        _gameSystems.Initialize();
    }

    private void Update()
    {
        _gameSystems.Execute();
    }
}