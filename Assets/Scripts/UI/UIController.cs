using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private UIData model;
    [SerializeField]
    private GemTriggerChannel gtChannel;
    
    private UIView view;

    void Start()
    {
        view = FindObjectOfType<UIView>();
        model.InitializeData();
    }

    private void OnEnable()
    {
        gtChannel.gemTriggerEvent += UpdateScore;
    }

    private void OnDisable()
    {
        gtChannel.gemTriggerEvent -= UpdateScore;
    }

    public void UpdateScore(GameObject gem)
    {
        model.score += 1;
        view.ChangeScoreView(model.score);
    }
}
