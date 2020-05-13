using UnityEngine;
using UnityEngine.UI;

namespace MiniatureGardenSound.Provider.Interface
{
    public interface ITransitionParameterProvidable
    {
        GameObject[] ActiveOrder { get; }
        Image FadeImage { get; }
    }

}