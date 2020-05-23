using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace MiniatureGardenSound.Component
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class WalkPass : MonoBehaviour
    {

        [SerializeField] private Transform[] passPoint;
        
        private NavMeshAgent agent;
        private int nextPassIndex;

        private bool IsPathInvalid => agent.pathStatus == NavMeshPathStatus.PathInvalid;
        
        async void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            if (passPoint.Length == 0) return;
            
            await UniTask.WaitWhile(() => IsPathInvalid);
            
            var currentPoint = passPoint[nextPassIndex];
            agent.SetDestination(currentPoint.position);
        }

        async void Update()
        {
            await UniTask.WaitWhile(() => IsPathInvalid);
            if (agent.remainingDistance > agent.radius) return;
            Debug.Log($"{agent.destination} {agent.remainingDistance} > {agent.radius}");

            if (passPoint.Length <= 0) return;
            nextPassIndex += 1;
            if (nextPassIndex >= passPoint.Length) nextPassIndex = 0;
            Debug.Log(nextPassIndex);
            var currentPoint = passPoint[nextPassIndex];
            agent.SetDestination(currentPoint.position);
        }
    }
}
