using UnityEngine;
using Zenject;

public class Input_Manager_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Input_Manager>().FromComponentOn(gameObject).AsSingle();
    }
}