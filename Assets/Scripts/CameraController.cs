using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
     private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x,4.87f,-10) ;


    }
}
