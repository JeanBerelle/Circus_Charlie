using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
   

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "DeadZone") Destroy(transform.parent.gameObject);
        else if (collision.tag == "Player")
        {
           var playerRef =  collision.GetComponent<PlayerManager>();
            if (playerRef.isalive) playerRef.TakeHit();
            
           
        }

    }
}
