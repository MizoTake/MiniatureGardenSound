using UnityEngine;

namespace MiniatureGardenSound.Provider.Interface
{
    public interface ITransitionParameterProvidable
    {
        GameObject[] ActiveOrder { get; }
    }

}