using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [HideInInspector] public List<Word> wordsToUse;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if(wordsToUse == null || wordsToUse.Count <= 0)
        {
            wordsToUse = DatabaseManager.instance.wordList;
        }
    }
}
