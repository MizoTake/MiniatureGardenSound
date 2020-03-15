using System;
using UniRx;
using UnityEngine;

namespace MiniatureGardenSound.Scripts.Provider.Interface
{
    public interface INativeProvidable
    {
        IObservable<Unit> ChangedMusic { get; }
        void Injection(AudioSource source);
    }
}