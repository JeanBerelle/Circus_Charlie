using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hoop : MonoBehaviour
{
    public float speed;
    public Collision collisionRef;


    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.right * speed * Time.deltaTime  ;
    }

 

}
