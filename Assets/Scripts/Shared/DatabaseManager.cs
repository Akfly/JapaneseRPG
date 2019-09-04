using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance { get; private set; }

    public TextAsset databaseFile;
    private Word[] wordList;

    [HideInInspector] public List<int> levelList { get; private set; }
    [HideInInspector] public List<string> groupList { get; private set; }

    void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadDatabase();
    }

    private void LoadDatabase()
    {
        if(!databaseFile)
        {
            Debug.Log("File not found");
            return;
        }
        string[] rows = databaseFile.text.Split('\n');
        wordList = new Word[rows.Length];
        levelList = new List<int>();
        groupList = new List<string>();
        for (int i = 0; i < rows.Length; i++)
        {
            if(rows[i].Length > 1)
            { 
                Debug.Log(rows[i]);
                wordList[i] = new Word(rows[i]);
                if(!levelList.Contains(wordList[i].level)) levelList.Add(wordList[i].level);
                if (!groupList.Contains(wordList[i].group)) groupList.Add(wordList[i].group);
            }
        }
    }
}
