using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Image _PanelImage;
    private bool isSceneChange;
    private Color PanelColor;
    private void Awake()
    {
        isSceneChange = false;
        PanelColor = _PanelImage.color;
    }
    public void Blackout(string scene)
    {
        WaitSceneBlackOut(scene).Forget();
    }

    public void BlackIn()
    {
        WaitSceneBlackIn().Forget();
    }

    private async UniTask WaitSceneBlackOut(string scene)
    {
        while (!isSceneChange)
        {
            PanelColor.a += 0.1f;
            _PanelImage.color = PanelColor;
            if (PanelColor.a >= 1)
                isSceneChange = true;
            await UniTask.Delay(TimeSpan.FromMilliseconds(50));
        }
        SceneManager.LoadScene(scene);
    }

    private async UniTask WaitSceneBlackIn()
    {
        PanelColor.a = 1;
        PanelColor.a -= 0.1f;
        _PanelImage.color = PanelColor;
        if (PanelColor.a <= 0)
        {
            isSceneChange = false;
            await UniTask.Delay(TimeSpan.FromMilliseconds(50));
        }
    }
}
