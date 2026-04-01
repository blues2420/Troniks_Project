using UnityEngine;
using Zenject;

public class Game_Manager_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Game_Manager>().FromComponentOn(gameObject).AsSingle().NonLazy();
    }
}