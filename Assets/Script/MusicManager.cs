using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip Music;
    string songName;
    bool played;
    private bool finished;

    // [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField]GameObject finishUI;
    void Start()
    {
        GManager.instance.Start = false;
        songName = "Tell Your World";
        audioSource = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Time.time >= 1.0f) && !played)
        {
            GManager.instance.Start = true;
            GManager.instance.StartTime = Time.time;
            played = true;
            audioSource.PlayOneShot(Music);
        }

        if (!audioSource.isPlaying && Time.time >= 2.0f && !finished)
        {
            Debug.Log("Music finished!");
            // SceneManager.LoadScene("ResultScene");
            Instantiate(finishUI, new Vector3(0.0f,1.5f,0.15f),Quaternion.Euler(45,0,0));
            finished = true;
        }
    }
}
