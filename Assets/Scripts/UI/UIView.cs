using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [Header("Score Text")]
    [SerializeField]
    private Text scoreText;

    [Header("Start/Lose Labels")]
    [SerializeField]
    private GameObject startText;
    [SerializeField]
    private GameObject loseText;

    private GameObject scoreLabel;

    private void Awake()
    {
        // Getting score label from score text.
        scoreLabel = scoreText.gameObject.transform.parent.gameObject;
    }

    // Changes score number text.
    public void ChangeScoreView(int score)
    {
        scoreText.text = score.ToString();
    }

    // Displays start label.
    public void DisplayStartScreen()
    {
        startText.SetActive(true);
    }

    // Displays score label.
    public void DisplayScoreScreen()
    {
        scoreLabel.SetActive(true);
    }

    // Displays lose label.
    public void DisplayGameOverScreen()
    {
        loseText.SetActive(true);
    }

    // Clear screen from labels.
    public void ClearScreen()
    {
        scoreLabel.SetActive(false);
        startText.SetActive(false);
        loseText.SetActive(false);
    }
}
