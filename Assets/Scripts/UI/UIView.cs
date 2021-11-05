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

    private GameObject scoreLabel;

    private void Awake()
    {
        scoreLabel = scoreText.gameObject.transform.parent.gameObject;
    }

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
        scoreLabel.SetActive(true);
    }

    public void DisplayGameOverScreen()
    {
        loseText.SetActive(true);
    }

    public void ClearScreen()
    {
        scoreLabel.SetActive(false);
        startText.SetActive(false);
        loseText.SetActive(false);
    }
}
