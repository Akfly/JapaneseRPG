using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance { get; private set; }

    public TextAsset databaseFile;
    [HideInInspector] public List<Word> wordList { get; private set; }

    [HideInInspector] public List<int> levelList { get; private set; }
    [HideInInspector] public List<string> groupList { get; private set; }

    [HideInInspector] public Dictionary<int, List<int>> levelsWithGroupLists { get; private set; }
    [HideInInspector] public Dictionary<string, List<int>> groupsWithLevels { get; private set; }

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
        wordList = new List<Word>();
        levelList = new List<int>();
        groupList = new List<string>();
        levelsWithGroupLists = new Dictionary<int, List<int>>();
        groupsWithLevels = new Dictionary<string, List<int>>();
        for (int i = 0; i < rows.Length; i++)
        {
            if(rows[i].Length > 1)
            { 
                wordList.Add(new Word(rows[i]));
                if (!levelList.Contains(wordList[i].level))
                {
                    levelList.Add(wordList[i].level);
                    levelsWithGroupLists.Add(wordList[i].level, new List<int>());
                }
                if (!groupList.Contains(wordList[i].group))
                {
                    groupList.Add(wordList[i].group);
                    groupsWithLevels.Add(wordList[i].group, new List<int>());
                }

                if(!groupsWithLevels[wordList[i].group].Contains(wordList[i].level))
                {
                    groupsWithLevels[wordList[i].group].Add(wordList[i].level);
                }

                int groupIndex = groupList.IndexOf(wordList[i].group);
                if (!levelsWithGroupLists[wordList[i].level].Contains(groupIndex))
                {
                    levelsWithGroupLists[wordList[i].level].Add(groupIndex);
                }
            }
        }
    }
}
