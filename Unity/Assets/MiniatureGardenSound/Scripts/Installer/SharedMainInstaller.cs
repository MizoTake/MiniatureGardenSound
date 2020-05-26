using MiniatureGardenSound.Manager;
using MiniatureGardenSound.Provider;
using MiniatureGardenSound.Scene;
using Zenject;

namespace MiniatureGardenSound.Installer
{
    public class SharedMainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SoundParamProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneManager>().AsSingle();
            Container.BindInstance(new SceneEnumeration(Scenes.SharedMain));
            Container.BindInstance(new SceneEnumeration(Scenes.Rain));
            Container.BindInstance(new SceneEnumeration(Scenes.Drive));
        }
    }
}