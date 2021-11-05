using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject startText;
    [SerializeField]
    private GameObject loseText;

    public void ChangeScoreView(int score)
    {
        scoreText.text = score.ToString();
    }

    public void DisplayStartScreen()
    {
        startText.SetActive(true);
    }

    public void DisplayScoreScreen()
    {
        scoreText.gameObject.SetActive(true);
    }

    public void DisplayGameOverScreen()
    {
        loseText.SetActive(true);
    }

    public void ClearScreen()
    {
        scoreText.gameObject.SetActive(false);
        startText.SetActive(false);
        loseText.SetActive(false);
    }
}
