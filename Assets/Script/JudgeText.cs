using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class JudgeText : MonoBehaviour
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
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        Destroy(gameObject);
    }
}
