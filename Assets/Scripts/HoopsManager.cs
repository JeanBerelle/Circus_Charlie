using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoopsManager : MonoBehaviour


{
    [SerializeField] private GameObject hoops;
    [SerializeField] private GameObject start_Position_Right, start_Position_Left;
    [SerializeField] private float spawn_delay_minimum = 0.5f, spawn_delay_maximum = 2f;
    [SerializeField] float speedRight = 2f, speedLeft = -1f;
    [SerializeField] private float swap_delay_minimum = 8f, swap_delay_maximum = 12f;
    [SerializeField] private TextMeshProUGUI UITimer;

    private Transform position;
    private float speedHoop;
    public List<Hoop> listHoops = new List<Hoop>();
    private float swapDelay;




    void Start()
    {
        
        StartCoroutine(SwapCoroutine());
        StartCoroutine(SpawnerCoroutine());
        

    }

    IEnumerator SwapCoroutine()
    {
        speedHoop = speedLeft;
        position = start_Position_Right.transform;
        swapDelay = Random.Range(swap_delay_minimum, swap_delay_maximum);
        bool isGoingLeft = true;

        while (true)
        {
            UITimer.text =  "Time before swap\n" + (Mathf.CeilToInt(swapDelay)).ToString();
            if (swapDelay > 0) 
            {
                yield return new WaitForSeconds(0.1f);
                swapDelay -= 0.1f;
            } 
            else
            {
                swapDelay = Random.Range(swap_delay_minimum, swap_delay_maximum);
                isGoingLeft = !isGoingLeft;
                if (isGoingLeft)
                {
                    speedHoop = speedLeft;
                    position = start_Position_Right.transform;
                }
                else
                {
                    speedHoop = speedRight;
                    position = start_Position_Left.transform;
                }
                for (int i = 0; i < listHoops.Count; i++)
                {
                    if (listHoops[i] != null) listHoops[i].speed = speedHoop;
                }
                
               /* for (int i = listHoops.Count - 1; i >= 0; i--)
                {
                     if (listHoops[i] != null) listHoops[i].speed = speedHoop;
                    

                }*/
            }
           

        }
        //yield return null;
    }

    private void Update()
    {
        Debug.Log(listHoops.Count);
    }

   
    //Utiliser un Invoke
    IEnumerator SpawnerCoroutine()
    {
        float delay;
        Hoop spawnedHoop;

        while (true)
        {
            delay = Random.Range(spawn_delay_minimum, spawn_delay_maximum);
            yield return new WaitForSeconds(delay);
            spawnedHoop = Instantiate(hoops, position.position, Quaternion.identity).GetComponent<Hoop>();
            listHoops.Add(spawnedHoop);
            spawnedHoop.speed = speedHoop;
            spawnedHoop.HM = this;
            


        }
       // yield return null;
    }

    public void Reset()
    {
        StopAllCoroutines();
        for (int i = listHoops.Count - 1 ; i >= 0; i--)
        {
            if (listHoops[i] != null) Destroy(listHoops[i].gameObject);
           // listHoops.RemoveAt(i);
        }
       
        listHoops = new List<Hoop>();
        StartCoroutine("SwapCoroutine");
        StartCoroutine("SpawnerCoroutine");
    }

}
