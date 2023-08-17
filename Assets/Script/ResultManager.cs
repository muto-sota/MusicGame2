using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI maxcomboText;
    [SerializeField] TextMeshProUGUI finalscoreText;
    [SerializeField] TextMeshProUGUI perfectCountText;
    [SerializeField] TextMeshProUGUI greatCountText;
    [SerializeField] TextMeshProUGUI batCountText;
    [SerializeField] TextMeshProUGUI missCountText;
    // Start is called before the first frame update
    void Start()
    {
        maxcomboText.text = GManager.instance.maxCombo.ToString();
        finalscoreText.text = GManager.instance.score.ToString();
        perfectCountText.text = GManager.instance.perfect.ToString();
        greatCountText.text = GManager.instance.great.ToString();
        batCountText.text = GManager.instance.bad.ToString();
        missCountText.text = GManager.instance.miss.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
