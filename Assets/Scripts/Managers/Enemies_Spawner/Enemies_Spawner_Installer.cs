using UnityEngine;
using Zenject;

public class Enemies_Spawner_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Enemies_Spawner>().FromComponentOn(gameObject).AsSingle().NonLazy();
    }
}