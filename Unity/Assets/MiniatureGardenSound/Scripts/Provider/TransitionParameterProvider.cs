using MiniatureGardenSound.Provider.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace MiniatureGardenSound.Provider
{
    public class TransitionParameterProvider : MonoBehaviour, ITransitionParameterProvidable
    {
    
        [SerializeField] private GameObject[] activeOrder;
        [SerializeField] private Image fadeImage;

        public GameObject[] ActiveOrder => activeOrder;
        public Image FadeImage => fadeImage;

    }
}
