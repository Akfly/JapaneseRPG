using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBase : MonoBehaviour
{
    public delegate void OnFinishDelegate(bool isOk);
    public OnFinishDelegate OnFinish;

    public virtual void StartGame()
    {
        gameObject.SetActive(true);
    }
}
