using UnityEngine;
using Zenject;

public class MainMonoInstaller : MonoInstaller
{
    public TileSpawnManager tileSpawnManager;
    public GameBehavior gameBehavior;

    public override void InstallBindings()
    {
        Container.Bind<ITileSpawnManager>().FromInstance(tileSpawnManager).AsSingle();
        Container.Bind<GameBehavior>().FromInstance(gameBehavior).AsSingle();
    }
}