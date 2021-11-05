using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private UIData model;
    [SerializeField]
    private GemTriggerChannel gtChannel;
    [SerializeField]
    public UIView view;

    void Start()
    {
        view = FindObjectOfType<UIView>();
        model.InitializeData();
    }

    private void OnEnable()
    {
        gtChannel.gemTriggerEvent.AddListener(UpdateScore);
    }

    private void OnDisable()
    {
        gtChannel.gemTriggerEvent.RemoveListener(UpdateScore);
    }

    public void UpdateScore()
    {
        model.score += 1;
        view.ChangeScoreView(model.score);
    }
}
