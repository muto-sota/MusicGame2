using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    private int _NotesSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * _NotesSpeed;
    }
}
