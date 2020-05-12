using MiniatureGardenSound.Transition.Interface;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Cycle
{
    public class SceneCycle : MonoBehaviour
    {

        private ISceneTransitionable transition;

        [Inject]
        private void Injection(ISceneTransitionable transition)
        {
            this.transition = transition;
        }
        
        private async void Awake()
        {
            await transition.Show();
        }

        private async void OnDestroy()
        {
            await transition.Hide();
        }
    }
}
