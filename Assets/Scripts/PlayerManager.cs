using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] private TextMeshProUGUI UILife;
    [SerializeField] private float gameOverDelay = 1f;
    [SerializeField] private HoopsManager hoopsmanagerRef;
    private Vector3 playerStart;
    private Rigidbody2D rbd2D;
    private PlayerAnimatorController animatorRef;
    private ScoreManager scoremanagerRef;
    

    [HideInInspector] public bool isalive = true;
    
    

    private void Awake()
    {
        rbd2D = GetComponent<Rigidbody2D>();
        animatorRef = GetComponent<PlayerAnimatorController>();
        scoremanagerRef = GetComponent<ScoreManager>();
    }
    private void Start()
    {
        UILife.text = life.ToString();
        playerStart = transform.position;
    }
    public void TakeHit()
    {
        life--;
        UILife.text = life.ToString();
        animatorRef.DeathAnimation(true);
        isalive = false;
        FreezePlayer(true);
        if (life <= 0) Invoke("GameOver", gameOverDelay);
        else  Invoke("Restart", gameOverDelay);
     
    }
    private void  GameOver()
    {
       
        SceneManager.LoadScene("Menu");
    }

    private void Restart()
    {
        transform.position = playerStart;
        FreezePlayer(false);
        animatorRef.DeathAnimation(false);
        isalive = true;
        hoopsmanagerRef.Reset(true);
        scoremanagerRef.Reset();

    }

    public void FreezePlayer (bool freeze)
    {
        rbd2D.velocity = Vector2.zero;
        rbd2D.angularVelocity = 0f;

        if (freeze)
        {
            
            rbd2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rbd2D.Sleep();
            rbd2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
      
    }
    

            

}
