using MiniatureGardenSound.Scripts.Manager;
using Zenject;

namespace MiniatureGardenSound.Scripts.Installer
{
    public class RainUmbrellaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IInitializable), typeof(ITickable)).To<UmbrellaManager>().AsSingle();
        }
    }
}