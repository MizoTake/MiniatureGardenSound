using MiniatureGardenSound.Provider.Interface;
using MiniatureGardenSound.Rain;
using UniRx;
using UnityEngine;
using Zenject;

namespace MiniatureGardenSound.Manager
{
    public class UmbrellaManager : IInitializable, ITickable
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

        public void Tick()
        {
            foreach (var umbrella in movableUmbrellas)
            {
                umbrella.AgentSpeed = 1.5f + umbrella.AgentSpeed * soundProvider.Power;
            }
        }
    }
}
