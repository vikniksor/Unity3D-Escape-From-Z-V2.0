using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [Tooltip("A distance on wich enemy will trigger on player.")]
    [SerializeField] float chaseRange = 10f;


    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    private bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked) { EngageTarget(); }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;            
        }            
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance) { ChaseTarget(); }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance) { AttackTarget(); }
        
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log("Attacking");
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
