using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone") Destroy(gameObject);
        else if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerManager>().TakeHit();
            
        }

    }
}
