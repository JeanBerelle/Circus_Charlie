using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    [SerializeField] private ScoreManager.Obstacles obstacletype;
    private float enterDistance, exitDistance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enterDistance = collision.gameObject.transform.position.x - transform.position.x;
        }
            

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerManager>().isalive)
            {
                exitDistance = collision.gameObject.transform.position.x - transform.position.x;
                if ((enterDistance > 0f && exitDistance < 0f) || (enterDistance < 0f && exitDistance > 0f))
                {
                    collision.GetComponent<ScoreManager>().AddScore(obstacletype);
                }
            }
           
        }
       
            
    }
}
