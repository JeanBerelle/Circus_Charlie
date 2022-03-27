using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Podium : MonoBehaviour
{
    private GameObject playerRef;
   [SerializeField]private Transform snapposition;
   [SerializeField] private HoopsManager hoopmanagerRef;
   [SerializeField] private float snapdelay = 0.5f;
   [SerializeField] private float victorydelay = 8f;
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            playerRef = collision.gameObject ;
            playerRef.GetComponent<PlayerManager>().FreezePlayer(true);
            hoopmanagerRef.Reset(false);
            playerRef.GetComponent<ScoreManager>().StopAllCoroutines();
            StartCoroutine(SnapPlayer(snapdelay));

        }
            

    }

    IEnumerator SnapPlayer(float duration)
    {
        float time = 0f;
        Vector2 startposition = playerRef.transform.position;

        while (time < duration )
        {
            playerRef.transform.position = Vector2.Lerp(startposition, snapposition.position, time / duration);
            time += Time.deltaTime;

            yield return null;
        }
        playerRef.transform.position = snapposition.position;
        playerRef.GetComponent<PlayerAnimatorController>().VictoryAnimation();
        playerRef.GetComponent<ScoreManager>().ShowVictoryScore(true);
        yield return new WaitForSeconds(victorydelay);
        SceneManager.LoadScene("Menu");



    }
}
