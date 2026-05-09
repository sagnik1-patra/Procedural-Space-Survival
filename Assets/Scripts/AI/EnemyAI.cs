using UnityEngine;
using UnityEngine.AI;

namespace SpaceSurvival.AI
{
    public enum AIState { Idle, Patrol, Chase, Attack }

    public class EnemyAI : MonoBehaviour
    {
        public AIState currentState = AIState.Patrol;
        public Transform target;
        public float chaseRange = 15f;
        public float attackRange = 2f;
        public float patrolRadius = 20f;

        private NavMeshAgent agent;
        private Vector3 patrolPoint;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            SetNewPatrolPoint();
        }

        void Update()
        {
            float distance = Vector3.Distance(transform.position, target.position);

            switch (currentState)
            {
                case AIState.Patrol:
                    if (distance < chaseRange) currentState = AIState.Chase;
                    if (agent.remainingDistance < 1f) SetNewPatrolPoint();
                    break;

                case AIState.Chase:
                    agent.SetDestination(target.position);
                    if (distance < attackRange) currentState = AIState.Attack;
                    if (distance > chaseRange * 1.5f) currentState = AIState.Patrol;
                    break;

                case AIState.Attack:
                    if (distance > attackRange) currentState = AIState.Chase;
                    // Attack logic here
                    break;
            }
        }

        void SetNewPatrolPoint()
        {
            Vector3 randomDir = Random.insideUnitSphere * patrolRadius;
            randomDir += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDir, out hit, patrolRadius, 1);
            patrolPoint = hit.position;
            agent.SetDestination(patrolPoint);
        }
    }
}
