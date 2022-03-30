using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIscore, UIfinalscore;
    [SerializeField] private int hoopscore, brazierscore, bothscore;
    [SerializeField] private int bonusscoremax = 5000, bonusscorelostperseconds = 10;


    private int score;
    private bool trackhoop, trackbrazier;
    private float bonusscore;


    public enum Obstacles
    {
        hoop, 
        brazier,
    }

    

    void Start()
    {
        Reset();
    }

    public void AddScore(Obstacles obstacle)
    {
        switch (obstacle)
        {
            case Obstacles.hoop:
                score += hoopscore;
                trackhoop = true;
                break;
            case Obstacles.brazier:
                score += brazierscore;
                trackbrazier = true;
                break;
        }
        if (trackhoop && trackbrazier) score += bothscore;
        UpdateUI();
    }

    public void Reset()
    {
        score = 0;
        bonusscore = bonusscoremax;
        UpdateUI();
        StartCoroutine (BonusScoreLosing());
        ShowVictoryScore(false);
        

    }

    private void UpdateUI()
    {
        UIscore.text = "SCORE : " + score.ToString() + "\n" + "BONUS : " + Mathf.RoundToInt(bonusscore).ToString();
    }

    public void IsOnGround()
    {
        trackbrazier = false;
        trackhoop = false;
    }

    public void ShowVictoryScore (bool show)
    {
       if (show ) score += Mathf.RoundToInt(bonusscore) ;
        UIfinalscore.gameObject.SetActive(show);
        UIfinalscore.text = "FINAL SCORE : " + score.ToString();
    }

    IEnumerator BonusScoreLosing ()
    {
        while (bonusscore > 0f)
        {
            yield return new WaitForSeconds(0.1f);
            bonusscore -= bonusscorelostperseconds / 10f;
            UpdateUI();
        }

        yield return null;
        
    }


}

