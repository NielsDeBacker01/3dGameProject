using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask ground, character;

    [Header("Patrol")]
    public Vector3 walkPoint;
    bool walkPointSet, playerInSightRange;
    public float walkPointRange, sightRange;

    [Header("Attack")]
    public float attackCd, attackRange;
    bool alreadyAttacked, playerInAttackRange;

    [Header("Animations")]
    public Animator animator;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, character);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, character);

        if (!playerInAttackRange && !playerInSightRange) Patrolling();
        if (!playerInAttackRange && playerInSightRange) Chase();
        if (playerInAttackRange && playerInSightRange) Attack();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        // animation

    }

    private void SearchWalkPoint()
    {
        // calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, ground))
            walkPointSet = true;
    }

    private void Chase()
    {
        agent.SetDestination(player.position);

        // animation

    }

    private void Attack()
    {
        // make sure enemy stops moving
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // attack code here

            alreadyAttacked = true;
            // animation

            Invoke(nameof(ResetAttack), attackCd);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
