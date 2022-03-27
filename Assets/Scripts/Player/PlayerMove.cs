using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2D;

    private float stickDirection;


    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var horizontalVelocity = stickDirection * speed;
        var verticalVelocity = rb2D.velocity.y;
        rb2D.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }

    public void OnStickMoved(InputAction.CallbackContext ctx)
    {
        stickDirection = ctx.ReadValue<float>();
    }
}
