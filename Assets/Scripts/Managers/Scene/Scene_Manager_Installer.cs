using UnityEngine;
using Zenject;

public class Scene_Manager_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Scene_Manager>().FromComponentOn(gameObject).AsSingle().NonLazy();
    }
}