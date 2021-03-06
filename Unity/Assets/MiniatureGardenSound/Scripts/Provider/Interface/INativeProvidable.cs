﻿using System;
using CrazyMinnow.AmplitudeWebGL;
using UniRx;

namespace MiniatureGardenSound.Provider.Interface
{
    public interface INativeProvidable
    {
        IObservable<Unit> ChangedMusic { get; }
        void Injection(Amplitude amplitude);
    }
}