using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameMenuController : MonoBehaviour
{
    [Header("Minigames")]
    public MinigameKanji2PronunciationType KanjiToPronunciation;

    [Header("References")]
    public GameObject CorrectPanel;
    public GameObject MissPanel;

    private List<MinigameBase> minigameList = new List<MinigameBase>();

    private void Awake()
    {
        minigameList.Add(KanjiToPronunciation);
    }

    private void Start()
    {
        CorrectPanel.SetActive(false);
        MissPanel.SetActive(false);
        for(int i = 0; i < minigameList.Count; i++)
        {
            minigameList[i].gameObject.SetActive(false);
            minigameList[i].OnFinish += OnGameFinished;
        }
    }

    public void StartKanjiToPronunciation()
    {
        CorrectPanel.SetActive(false);
        MissPanel.SetActive(false);
        KanjiToPronunciation.StartGame();
    }


    private void OnGameFinished(bool isCorrect)
    {
        CorrectPanel.SetActive(isCorrect);
        MissPanel.SetActive(!isCorrect);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
