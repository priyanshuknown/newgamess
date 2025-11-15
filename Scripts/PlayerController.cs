using UnityEngine;
using System.Collections;

public class PlayerController : Character
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float gravity = 20.0f;

    public GameObject punchHitbox;
    public GameObject kickHitbox;

    private bool isAttacking = false;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        punchHitbox.SetActive(false);
        kickHitbox.SetActive(false);
    }

    void Update()
    {
        // Block
        isBlocking = Input.GetKey(KeyCode.L);
        animator.SetBool("Block", isBlocking);

        // Prevent actions if blocking or attacking
        if (isBlocking || isAttacking)
        {
            // Stop movement but still apply gravity
            if (controller.isGrounded)
            {
                moveDirection = Vector3.zero;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            return;
        }

        // Movement and Rotation
        if (controller.isGrounded)
        {
            float move = Input.GetAxis("Vertical");
            moveDirection = new Vector3(0, 0, move);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
            animator.SetFloat("Speed", move);
        }

        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        // Actions
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Attack("Punch", punchHitbox, 0.5f));
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Attack("Kick", kickHitbox, 0.8f));
        }
    }

    IEnumerator Attack(string triggerName, GameObject hitbox, float duration)
    {
        isAttacking = true;
        animator.SetTrigger(triggerName);

        yield return new WaitForSeconds(0.2f); // Delay to sync with animation
        hitbox.SetActive(true);

        yield return new WaitForSeconds(duration - 0.2f); // Active hitbox duration
        hitbox.SetActive(false);
        isAttacking = false;
    }
}
