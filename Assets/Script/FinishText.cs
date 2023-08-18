using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishText : MonoBehaviour
{
    // [SerializeField] private Animation _animation;
    // private bool _isfinished;
    private void Start()
    {
        // _isfinished = false;
        WaitAnimationFinishAsync().Forget();
    }

    private async UniTask WaitAnimationFinishAsync()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        Destroy(gameObject);
        SceneManager.LoadScene("ResultScene");
    }
}