using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Jumper jumper2D;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        jumper2D = GetComponent<Jumper>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        animator.SetBool("IsJumping", !jumper2D.isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        
    }

    public void DeathAnimation(bool Isdead)
    {
        animator.SetBool("IsDead",Isdead);
    }

    public void VictoryAnimation()
    {
        animator.SetTrigger("Victory");
    }
}


