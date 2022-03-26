using UnityEngine;

public class Jumper : MonoBehaviour
{
    [Header("Jump")] public float jumpForce;

    [Header("Ground Detection")] [Range(0, 1)]
    public float groundCheckRadius;
    private ScoreManager scoremanagerRef;

   
    public Transform feet;
    public bool isGrounded;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        scoremanagerRef = GetComponent<ScoreManager>();
    }

    public void Jump()
    {
        if (isGrounded)
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        var test = Physics2D.OverlapCircle(feet.position, groundCheckRadius);
        CheckGround();


    }

    private void CheckGround()
    {
        var test = Physics2D.OverlapCircle(feet.position, groundCheckRadius);
   
        if (test != null && test.gameObject.tag == "Ground")
        {
            if (!isGrounded) scoremanagerRef.IsOnGround();
            isGrounded = true;

        }
        else isGrounded = false;
   
    }
}
