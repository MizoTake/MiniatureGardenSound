using MiniatureGardenSound.Data;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SceneDataInstaller", menuName = "Installers/SceneDataInstaller")]
public class SceneDataInstaller : ScriptableObjectInstaller<SceneDataInstaller>
{

    [SerializeField] private SceneList list;
    
    public override void InstallBindings()
    {
        Container.BindInstance(list);
    }
}