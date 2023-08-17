using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public int bpm;
    public int offset;
    public Note[] notes;
}
[Serializable]
public class Note
{
    public int lpb;
    public int num;
    public int block;
    public int type;
}

public class NotesManager : MonoBehaviour
{
    public int noteNum;
    private string songName;

    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<GameObject> NotesObj = new List<GameObject>();

    [SerializeField] float NotesSpeed = 8;
    [SerializeField] GameObject noteObj;

    void OnEnable()
    {
        // NotesSpeed = GManager.instance.noteSpeed;
        noteNum = 0;
        songName = "Tell Your World";
        Load(songName);
    }

    private void Load(string songName)
    {
        string inputString = Resources.Load<TextAsset>(songName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        noteNum = inputJson.notes.Length;
        // GManager.instance.maxSrore = noteNum * 5;
        
        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            float kankaku = 60 / (inputJson.bpm * (float)inputJson.notes[i].lpb);
            float beatSec = kankaku * (float)inputJson.notes[i].lpb;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].lpb) + inputJson.offset * 0.01f;
            NotesTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            NoteType.Add(inputJson.notes[i].type);

            float z = NotesTime[i] * NotesSpeed;
            // Debug.Log(z);
            NotesObj.Add(Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 2.5f, 0.55f, z), Quaternion.identity));
        }
    }
}