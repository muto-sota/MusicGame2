using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("button clicked");
        SceneManager.LoadScene("TitleScene");
    }
}
