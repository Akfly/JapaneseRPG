using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Prefabs")]
    public MainMenuToggle TogglePrefab;

    [Header("References")]
    public Transform ScrollViewContentLevels;
    public Transform ScrollViewContentGroups;

    private List<MainMenuToggle> levelToggles = new List<MainMenuToggle>();
    private List<MainMenuToggle> groupToggles = new List<MainMenuToggle>();
    private Dictionary<int, MainMenuToggle> levelTogglesByLevel = new Dictionary<int, MainMenuToggle>();
    private Dictionary<string, MainMenuToggle> groupTogglesByGroup = new Dictionary<string, MainMenuToggle>();

    // Start is called before the first frame update
    void Start()
    {
        AddToggles(DatabaseManager.instance.levelList, ScrollViewContentLevels, levelToggles, levelTogglesByLevel, true);
        AddToggles(DatabaseManager.instance.groupList, ScrollViewContentGroups, groupToggles, groupTogglesByGroup);
    }

    private void AddToggles<T>(List<T> list, Transform parent, List<MainMenuToggle> listToAdd,
        Dictionary<T, MainMenuToggle> dictionaryToAdd, bool subscribeToEvent = false)
    {
        for (int i = 0; i < list.Count; i++)
        {
            MainMenuToggle toggle = Instantiate(TogglePrefab, parent);
            toggle.setName(list[i].ToString());
            toggle.setEnabled(true);
            if(subscribeToEvent)
            {
                toggle.onToggleChangeEvent = onToggleChange;
            }
            listToAdd.Add(toggle);
            dictionaryToAdd.Add(list[i], toggle);
        }
    }

    private void onToggleChange(MainMenuToggle toggle, bool isOn)
    {
        refreshTogglesEnable();
    }

    public void refreshTogglesEnable()
    {
        for (int i = 0; i < groupToggles.Count; i++)
        {
            bool isEnabled = false;
            List<int> levels = DatabaseManager.instance.groupsWithLevels[groupToggles[i].name];
            for (int j = 0; j < levels.Count; j++)
            {
                if (levelTogglesByLevel[levels[j]].toggle.isOn)
                {
                    isEnabled = true;
                    break;
                }
            }
            groupToggles[i].setEnabled(isEnabled);
        }
    }

    public void StartGame()
    {
        List<Word> gameList = new List<Word>();
        for(int i = 0; i < DatabaseManager.instance.wordList.Count; i++)
        {
            Word word = DatabaseManager.instance.wordList[i];
            if (levelTogglesByLevel[word.level].toggle.isOn && groupTogglesByGroup[word.group].toggle.isOn
                && groupTogglesByGroup[word.group].toggle.interactable)
            {
                gameList.Add(word);
            }
        }

        GameManager.instance.wordsToUse = gameList;
        Utils.DebugList(gameList);
        SceneManager.LoadScene("MinigamePlayer");
    }
}
