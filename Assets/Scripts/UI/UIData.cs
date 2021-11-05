using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI Data")]
public class UIData : ScriptableObject
{
    [HideInInspector]
    public int score;

    public void InitializeData()
    {
        score = 0;
    }
}
