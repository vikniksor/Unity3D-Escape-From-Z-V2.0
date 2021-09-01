using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    
    [Tooltip("A distance on wich enemy will trigger on player.")]
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;


    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    private bool isProvoked = false;

    EnemyHealth health;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        { 
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked) { EngageTarget(); }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;            
        }            
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance) { ChaseTarget(); }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance) { AttackTarget(); }
        
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("isAttack", false);
        GetComponent<Animator>().SetTrigger("moveTrigger");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("isAttack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(
            transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
