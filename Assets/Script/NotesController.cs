using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    private float _NotesSpeed = 8;
    private bool start;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        // _NotesSpeed = GManager.instance.noteSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }

        if (start)
        {
            transform.position -= transform.forward * Time.deltaTime * _NotesSpeed;
        }
    }
}
