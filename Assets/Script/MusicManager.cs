using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip Music, FinishMusic;
    string songName;
    bool played;
    private bool finished;
    private float time;
    
    // [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField]GameObject finishUI;
    
    void Start()
    {
        ResetTime();
        ResetScore();
        // Debug.Log("ok");
        GManager.instance.Start = false;
        songName = "Tell Your World";
        audioSource = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;
        finished = false;
        FinishMusic = (AudioClip)Resources.Load("Musics/finish");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if ((Input.GetKeyDown(KeyCode.Space) || time >= 1.0f) && !played)
        {
            GManager.instance.Start = true;
            GManager.instance.StartTime = Time.time;
            // Debug.Log($"スタートタイム{GManager.instance.StartTime}");
            played = true;
            audioSource.PlayOneShot(Music);
        }

        if (!audioSource.isPlaying && time >= 2.0f && !finished)
        {
            // Debug.Log("Music finished!");
            Instantiate(finishUI, new Vector3(0.0f,1.5f,0.15f),Quaternion.Euler(45,0,0));
            finished = true;
            audioSource.PlayOneShot(FinishMusic);
            if ((GManager.instance.score > GManager.instance.highscore) && !GManager.instance.ishighscore)
            {
                GManager.instance.highscore = GManager.instance.score;
                GManager.instance.ishighscore = true;
            }
        }
    }

    void ResetTime()
    {
        GManager.instance.StartTime = Time.time;
    }
    void ResetScore()
    {
        GManager.instance.perfect = 0;
        GManager.instance.great = 0;
        GManager.instance.bad = 0;
        GManager.instance.miss = 0;
        GManager.instance.score = 0;
        GManager.instance.combo = 0;
        GManager.instance.maxCombo = 0;
        GManager.instance.ishighscore = false;
    }
}
