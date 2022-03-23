using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] private TextMeshProUGUI UILife;
    private Vector3 playerStart;
    private Rigidbody2D rbd2D;

    private void Start()
    {
        UILife.text = life.ToString();
        playerStart = transform.position;
        rbd2D = GetComponent<Rigidbody2D>();
    }
    public void TakeHit()
    {
        life--;
        UILife.text = life.ToString();
        if (life <= 0) GameOver() ;
        else
        {
            transform.position = playerStart;
            rbd2D.velocity = Vector2.zero;
            rbd2D.angularVelocity = 0f;
            rbd2D.Sleep();
        }
        
    }
    private void GameOver()
    {
        
    }
}
