using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Dynamic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddPoints(int brickValue)
    {
        score += brickValue;
        scoreText.text = score.ToString();
    }

    public void WinState()
    {
        if (score >= 448)
        {
            Restart.instance.RestartScene();
            scoreText.text = score.ToString();
        }
        if (score >= 896)
        {

        }
    }

}
