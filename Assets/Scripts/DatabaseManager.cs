using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance { get; private set; }

    public TextAsset databaseFile;
    private Word[] wordList;

    [HideInInspector] public HashSet<int> levelList { get; private set; }
    [HideInInspector] public HashSet<string> groupList { get; private set; }

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
    }

    void Start()
    {
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
        levelList = new HashSet<int>();
        groupList = new HashSet<string>();
        for (int i = 0; i < rows.Length; i++)
        {
            if(rows[i].Length > 1)
            { 
                Debug.Log(rows[i]);
                wordList[i] = new Word(rows[i]);
                levelList.Add(wordList[i].level);
                groupList.Add(wordList[i].group);
            }
        }
    }
}
