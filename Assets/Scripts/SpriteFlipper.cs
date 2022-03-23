using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteFlipper : MonoBehaviour
{
    [HideInInspector] public bool isFacingLeft;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnStickMoved(InputAction.CallbackContext ctx)
    {
        if(!ctx.performed)
            return;
        var value = ctx.ReadValue<float>();
        isFacingLeft = value < 0;
        spriteRenderer.flipX = isFacingLeft;
    }
}
