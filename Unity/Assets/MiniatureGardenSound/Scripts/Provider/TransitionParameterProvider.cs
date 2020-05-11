using MiniatureGardenSound.Provider.Interface;
using UnityEngine;

namespace MiniatureGardenSound.Provider
{
    public class TransitionParameterProvider : MonoBehaviour, ITransitionParameterProvidable
    {
    
        [SerializeField] private GameObject[] activeOrder;

        public GameObject[] ActiveOrder => activeOrder;
        
    }
}
