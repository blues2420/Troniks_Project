using Zenject;

public class Timer_Manager_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Timer_Manager>().FromComponentOn(gameObject).AsSingle();
    }
}