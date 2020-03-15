using MiniatureGardenSound.Scripts.Manager;
using MiniatureGardenSound.Scripts.Provider;
using MiniatureGardenSound.Scripts.Provider.Interface;
using Zenject;

namespace MiniatureGardenSound.Scripts.Installer
{
    public class RainUmbrellaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(ISoundParamProvider), typeof(ITickable)).To<SoundParamProvider>().AsSingle();
            Container.Bind(typeof(IInitializable)).To<UmbrellaManager>().AsSingle();

        }
    }
}