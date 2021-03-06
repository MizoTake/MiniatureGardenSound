﻿using System;
using MiniatureGardenSound.Transition.Interface;
using Zenject;

namespace MiniatureGardenSound.Cycle
{
    public class SceneCycle : IInitializable, IDisposable
    {

        private ISceneTransitionable transition;

        [Inject]
        private void Injection(ISceneTransitionable transition)
        {
            this.transition = transition;
        }
        
        public async void Initialize()
        {
            await transition.Show();
        }

        public async void Dispose()
        {
            await transition.Hide();
        }
    }
}
