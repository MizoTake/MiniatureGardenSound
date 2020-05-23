using UnityEngine;
using UnityEngine.AI;

namespace MiniatureGardenSound.Component
{
    public class Patrol : MonoBehaviour
    {
        private NavMeshAgent agent;
        private int destPoint;
        public Transform[] points;
        
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.autoBraking = false;
            GotoNextPoint();
        }


        private void GotoNextPoint()
        {
            if (points.Length == 0)
                return;
            agent.destination = points[destPoint].position;
            destPoint = (destPoint + 1) % points.Length;
        }


        private void Update()
        {
            if (!agent.pathPending && agent.remainingDistance < agent.radius)
                GotoNextPoint();
        }
    }
}