using MiniatureGardenSound.Cycle;
using Zenject;

namespace MiniatureGardenSound.Installer
{
    public class DriveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneCycle>().AsSingle();
        }
    }
}