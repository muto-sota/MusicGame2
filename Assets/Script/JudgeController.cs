using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JudgeController : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数

    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    private int nownotes = 0;
    // private float time;

    // AudioSource audioSource;
    // AudioClip hitSound;

    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        // hitSound = (AudioClip)Resources.Load("Musics/notes");
    }
    void Update()
    {
        // Debug.Log(Time.deltaTime);
        // Debug.Log(GetAbs(Time.time - notesManager.NotesTime[0]));
        // time += Time.deltaTime;
        if (nownotes != GManager.instance.maxnotes)
        {
            if (Input.GetKeyDown(KeyCode.D)) //〇キーが押されたとき
            {
                if (notesManager.LaneNum[0] == 1) //押されたボタンはレーンの番号とあっているか？
                {
                    Judgement(GetAbs(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                    /*
                    本来ノーツをたたく場所と実際にたたいた場所がどれくらいずれているかを求め、
                    その絶対値をJudgement関数に送る
                    */
                }
                else
                {
                    if (notesManager.LaneNum[1] == 1)
                    {
                        Judgement(GetAbs(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (notesManager.LaneNum[0] == 2)
                {
                    Judgement(GetAbs(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 2)
                    {
                        Judgement(GetAbs(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                if (notesManager.LaneNum[0] == 3)
                {
                    Judgement(GetAbs(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 3)
                    {
                        Judgement(GetAbs(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                if (notesManager.LaneNum[0] == 4)
                {
                    Judgement(GetAbs(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 4)
                    {
                        Judgement(GetAbs(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }

            if (Time.time >
                notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime) //本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
            {
                Message(3);
                DeleteData(0);
                // Debug.Log("Miss");
                GManager.instance.miss++;
                if (GManager.instance.maxCombo < GManager.instance.combo)
                {
                    GManager.instance.maxCombo = GManager.instance.combo;
                }

                GManager.instance.combo = 0;
                nownotes++;
                //ミス
            }
        }
    }
    private void Judgement(float timeLag, int numoffset)
    {
        // audio.PlayOneShot(hitSound);
        nownotes++;
        if (timeLag <= 0.10f)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            Debug.Log("Perfect");
            Message(0);
            GManager.instance.score += 500;
            GManager.instance.perfect++;
            GManager.instance.combo++;
            DeleteData(numoffset);
        }
        else
        {
            if (timeLag <= 0.15f)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                // Debug.Log("Great");
                Message(1);
                GManager.instance.score += 300;
                GManager.instance.great++;
                GManager.instance.combo++;
                DeleteData(numoffset);
            }
            else
            {
                if (timeLag <= 0.20f)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    // Debug.Log("Bad");
                    Message(2);
                    GManager.instance.score += 100;
                    GManager.instance.bad++;

                    if (GManager.instance.maxCombo < GManager.instance.combo)
                    {
                        GManager.instance.maxCombo = GManager.instance.combo;
                    }
                    GManager.instance.combo = 0;
                    DeleteData(numoffset);
                }
            }
        }
    }
    float GetAbs(float num)//引数の絶対値を返す関数
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    private void DeleteData(int numOffset)//すでにたたいたノーツを削除する関数
    {
        // audioSource.PlayOneShot(hitSound);
        Destroy(notesManager.NotesObj[numOffset]);
        notesManager.NotesObj.RemoveAt(numOffset);
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);

        comboText.text = GManager.instance.combo.ToString();
        scoreText.text = GManager.instance.score.ToString();
    }

    private void Message(int judge)//判定を表示する
    {
        Instantiate(MessageObj[judge],new Vector3(notesManager.LaneNum[0]-2.5f,0.76f,0.15f),Quaternion.Euler(45,0,0));
    }
}
