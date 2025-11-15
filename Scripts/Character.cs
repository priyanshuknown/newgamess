using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isBlocking = false;

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isBlocking) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            animator.SetTrigger("TakeHit");
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);

        // Disable character controls and AI components
        var playerController = GetComponent<PlayerController>();
        if (playerController != null) playerController.enabled = false;

        var enemyAI = GetComponent<EnemyAI>();
        if (enemyAI != null) enemyAI.enabled = false;

        var characterController = GetComponent<CharacterController>();
        if (characterController != null) characterController.enabled = false;

        var navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent != null) navMeshAgent.enabled = false;

        // Disable this script itself
        this.enabled = false;
    }
}
