using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Jumper2D jumper2D;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        jumper2D = GetComponent<Jumper2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsJumping", !jumper2D.isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
    }
}
