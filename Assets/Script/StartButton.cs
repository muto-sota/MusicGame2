using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject other;

    public void OnClick()
    {
        Debug.Log("in");
        // Initiate.Fade("GameScene", Color.black, 1.0f);
        ChangeScene change = other.GetComponent<ChangeScene>();
        change.Blackout("GameScene");
    }
}
