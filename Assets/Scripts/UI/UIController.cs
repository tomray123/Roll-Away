using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("UI Model")]
    [SerializeField]
    private UIData model;

    [Header("Gem Trigger Event Channel")]
    [SerializeField]
    private GemTriggerChannel gtChannel;

    [Header("UI View")]
    [SerializeField]
    public UIView view;

    void Start()
    {
        // Initializing variables.
        view = FindObjectOfType<UIView>();
        model.InitializeData();
    }

    private void OnEnable()
    {
        // Subscribing to corresponding event.
        gtChannel.gemTriggerEvent.AddListener(UpdateScore);
    }

    private void OnDisable()
    {
        // Unsubscribing from corresponding event.
        gtChannel.gemTriggerEvent.RemoveListener(UpdateScore);
    }

    // Increments the score and visualise it.
    public void UpdateScore()
    {
        model.score += 1;
        view.ChangeScoreView(model.score);
    }
}
