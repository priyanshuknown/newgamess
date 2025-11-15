using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : Character
{
    public Transform player;
    public float attackRange = 2f;
    public float decisionDelay = 1f;

    public GameObject punchHitbox;
    public GameObject kickHitbox;

    private NavMeshAgent agent;
    private float timeSinceLastDecision = 0;
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        punchHitbox.SetActive(false);
        kickHitbox.SetActive(false);
    }

    void Update()
    {
        if (isAttacking || isBlocking)
        {
            agent.isStopped = true;
            return;
        }
        agent.isStopped = false;

        timeSinceLastDecision += Time.deltaTime;
        if (timeSinceLastDecision >= decisionDelay)
        {
            MakeDecision();
            timeSinceLastDecision = 0;
        }
    }

    void MakeDecision()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            int randomAction = Random.Range(0, 3); // 0: Punch, 1: Kick, 2: Block
            if (randomAction == 0)
            {
                StartCoroutine(Attack("Punch", punchHitbox, 0.5f));
            }
            else if (randomAction == 1)
            {
                StartCoroutine(Attack("Kick", kickHitbox, 0.8f));
            }
            else
            {
                StartCoroutine(Block(1.0f));
            }
        }
        else
        {
            agent.SetDestination(player.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    IEnumerator Attack(string triggerName, GameObject hitbox, float duration)
    {
        isAttacking = true;
        animator.SetTrigger(triggerName);

        yield return new WaitForSeconds(0.2f);
        hitbox.SetActive(true);

        yield return new WaitForSeconds(duration - 0.2f);
        hitbox.SetActive(false);
        isAttacking = false;
    }

    IEnumerator Block(float duration)
    {
        isBlocking = true;
        animator.SetBool("Block", true);

        yield return new WaitForSeconds(duration);

        isBlocking = false;
        animator.SetBool("Block", false);
    }
}
