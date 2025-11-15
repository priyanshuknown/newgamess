using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage = 10;
    private Character owner;

    void Awake()
    {
        // Automatically find the Character component in the parent hierarchy.
        owner = GetComponentInParent<Character>();
        if (owner == null)
        {
            Debug.LogError("Hitbox could not find a Character owner in its parent hierarchy.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Character opponent = other.GetComponent<Character>();
        if (opponent != null && opponent != owner)
        {
            // Ensure the opponent is not on the same team if you add teams later
            if (gameObject.layer != opponent.gameObject.layer)
            {
                opponent.TakeDamage(damage);
            }
        }
    }
}
