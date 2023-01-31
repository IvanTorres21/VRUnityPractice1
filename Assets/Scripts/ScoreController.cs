using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;

    private int score = 0;

    public static ScoreController instance;

    private void Start()
    {
        instance = this;
    }

    public void IncreaseScore()
    {
        score++;
        scoreTxt.text = "Score: " + score.ToString();
    }
}
