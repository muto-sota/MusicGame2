using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    public int songID;
    public float noteSpeed;
    
    public bool Start;
    public float StartTime;

    public int combo;
    public int maxCombo;
    public int score;
    public int maxnotes;
    public int highscore;
    public bool ishighscore;

    public int perfect;
    public int great;
    public int bad;
    public int miss;
    
    public GameObject other;
    
    public void Awake()
    {
        ChangeScene change = other.GetComponent<ChangeScene>();
        change.BlackIn();
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
