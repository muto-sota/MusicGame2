using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数
    void Update()
    {
        Debug.Log(GetAbs(Time.time - notesManager.NotesTime[0]));
        if (Input.GetKeyDown(KeyCode.D))//〇キーが押されたとき
        {
            if (notesManager.LaneNum[0] == 1)//押されたボタンはレーンの番号とあっているか？
            {
                Judgement(GetAbs(Time.time - notesManager.NotesTime[0]));
                /*
                本来ノーツをたたく場所と実際にたたいた場所がどれくらいずれているかを求め、
                その絶対値をJudgement関数に送る
                */
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (notesManager.LaneNum[0] == 2)
            {
                Judgement(GetAbs(Time.time - notesManager.NotesTime[0]));
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (notesManager.LaneNum[0] == 3)
            {
                Judgement(GetAbs(Time.time - notesManager.NotesTime[0]));
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (notesManager.LaneNum[0] == 4)
            {
                Judgement(GetAbs(Time.time - notesManager.NotesTime[0]));
            }
        }

        if (Time.time > notesManager.NotesTime[0] + 0.2f)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
        {
            Message(3);
            DeleteData();
            Debug.Log("Miss");
            //ミス
        }
    }
    private void Judgement(float timeLag)
    {
        if (timeLag <= 0.10f)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            Debug.Log("Perfect");
            Message(0);
            DeleteData();
        }
        else
        {
            if (timeLag <= 0.15f)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                Debug.Log("Great");
                Message(1);
                DeleteData();
            }
            else
            {
                if (timeLag <= 0.20f)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    Debug.Log("Bad");
                    Message(2);
                    DeleteData();
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
    private void DeleteData()//すでにたたいたノーツを削除する関数
    {
        notesManager.NotesTime.RemoveAt(0);
        notesManager.LaneNum.RemoveAt(0);
        notesManager.NoteType.RemoveAt(0);
    }

    private void Message(int judge)//判定を表示する
    {
        Instantiate(MessageObj[judge],new Vector3(notesManager.LaneNum[0]-2.5f,0.76f,0.15f),Quaternion.Euler(45,0,0));
    }
}
