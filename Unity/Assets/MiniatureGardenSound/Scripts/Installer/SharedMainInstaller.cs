using MiniatureGardenSound.Scripts.Provider;
using MiniatureGardenSound.Scripts.Provider.Interface;
using Zenject;

namespace MiniatureGardenSound.Scripts.Installer
{
    public class SharedMainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(IInitializable), typeof(ISoundParamProvider), typeof(ITickable)).To<SoundParamProvider>().AsSingle();
        }
    }
}