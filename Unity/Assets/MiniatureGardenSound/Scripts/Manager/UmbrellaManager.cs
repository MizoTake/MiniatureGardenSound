﻿using MiniatureGardenSound.Scripts.Provider.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Scripts.Manager
{
    public class UmbrellaManager : IInitializable
    {
        [Inject(Id = "Left")]
        private Transform[] leftUmbrellas;
        [Inject(Id = "Right")]
        private Transform[] rightUmbrellas;
        [Inject(Id = "Movable")]
        private MovableUmbrella[] movableUmbrellas;
        
        private ISoundParamProvider soundProvider;
        private IParameterThresholdProvider thresholdProvider;

        [Inject]
        private void Inject(ISoundParamProvider soundProvider, IParameterThresholdProvider thresholdProvider)
        {
            this.soundProvider = soundProvider;
            this.thresholdProvider = thresholdProvider;
        }
        
        // 音のボリュームも変えていいのかもa
        // 音からの数値で動かす数などを決めて行く
        public void Initialize()
        {
            foreach (var umbrella in movableUmbrellas)
            {
                umbrella.StateAsObservable
                    .Where(x => x == MovableUmbrella.State.Wait)
                    .Select(x => soundProvider.Power)
                    .TakeUntilDestroy(umbrella)
                    .Subscribe(x =>
                    {
                        if (x < thresholdProvider.WaitRequest)
                        {
                            umbrella.IsWait = true;
                        }
                    });
            }
        }
    }
}
