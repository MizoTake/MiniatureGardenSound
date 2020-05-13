using MiniatureGardenSound.Manager;
using MiniatureGardenSound.Provider;
using Zenject;

namespace MiniatureGardenSound.Installer
{
    public class SharedMainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SoundParamProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneManager>().AsSingle();
        }
    }
}