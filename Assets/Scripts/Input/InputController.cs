using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent onClick;

    void Update()
    {
        // Invoking OnClick event when user clicks button.
        if (Input.GetMouseButtonDown(0) && onClick != null)
        {
            onClick.Invoke();
        }
    }
}
