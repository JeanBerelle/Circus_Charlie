using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hoop : MonoBehaviour
{
    public float speed;
   // Transform tr;
    public HoopsManager HM;



   /* void Start()
    {
        //tr = gameObject.GetComponent<Transform>() ;
        
    }*/


    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.right * speed * Time.deltaTime  ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone") Destroy(gameObject);
        else if (collision.tag == "Player") 
        {
            collision.GetComponent<PlayerLife>().TakeHit();
            HM.Reset();

        }
        
    }
    


}
