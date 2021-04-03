using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onGemColisionEnter;
    public void GemColisionEnter(int id)
    {
        if (onGemColisionEnter != null)
        {
            onGemColisionEnter(id);
        }
    }

    public event Action<int> onGemDrop;
    public void GemDropped(int id)
    {
        if (onGemDrop != null)
        {
            onGemDrop(id);
        }
    }
}
