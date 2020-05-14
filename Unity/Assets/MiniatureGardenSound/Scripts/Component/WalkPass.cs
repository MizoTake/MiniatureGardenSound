using System.Threading.Tasks;
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
        
        async void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            if (passPoint.Length == 0) return;
            
            await UniTask.WaitWhile(() => agent.pathStatus == NavMeshPathStatus.PathInvalid);
            
            var currentPoint = passPoint[nextPassIndex];
            agent.SetDestination(currentPoint.position);
        }

        async Task Update()
        {
            await UniTask.WaitWhile(() => agent.pathStatus == NavMeshPathStatus.PathInvalid);
            
            if (passPoint.Length <= 0) return;
            nextPassIndex += 1;
            if (nextPassIndex >= passPoint.Length) nextPassIndex = 0;
            var currentPoint = passPoint[nextPassIndex];
            agent.SetDestination(currentPoint.position);
            
            await UniTask.WaitWhile(() => agent.remainingDistance < agent.radius);
        }
    }
}
