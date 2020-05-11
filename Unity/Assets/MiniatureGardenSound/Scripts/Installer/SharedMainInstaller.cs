using MiniatureGardenSound.Provider;
using MiniatureGardenSound.Provider.Interface;
using Zenject;

namespace MiniatureGardenSound.Installer
{
    public class SharedMainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IInitializable), typeof(ISoundParamProvider), typeof(ITickable)).To<SoundParamProvider>().AsSingle();
        }
    }
}