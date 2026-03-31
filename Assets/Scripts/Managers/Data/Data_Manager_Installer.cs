using UnityEngine;
using Zenject;

public class Data_Manager_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Data_Manager>().FromComponentOn(gameObject).AsSingle().NonLazy();
    }
}