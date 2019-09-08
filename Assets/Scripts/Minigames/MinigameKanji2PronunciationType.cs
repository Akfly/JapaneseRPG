using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinigameKanji2PronunciationType : MinigameBase
{
    public Text kanjiWord;
    public InputField userInput;
    public Text correctAnswer;
    private Word selectedWord;

    public override void StartGame()
    {
        base.StartGame();
        Utils.DebugList(GameManager.instance.wordsToUse);
        selectedWord = Utils.GetRandomWordByRatio(GameManager.instance.wordsToUse);
        kanjiWord.text = selectedWord.kanji;
        userInput.interactable = true;
        userInput.text = "";
        correctAnswer.text = "";
    }

    public void CheckCorrect()
    {
        userInput.interactable = false;
        string userText = Utils.KataToHira(userInput.text);
        string toCompareText = Utils.KataToHira(selectedWord.pronunciation);
        bool isCorrect = userText == toCompareText;
        correctAnswer.text = toCompareText == selectedWord.pronunciation ? selectedWord.pronunciation :
            toCompareText + " / " + selectedWord.pronunciation;
        if (isCorrect)
        {
            selectedWord.AddWin();
        } else
        {
            selectedWord.AddFail();
        }
#if UNITY_EDITOR
        Debug.Log(userText + " == " + toCompareText + ": " + isCorrect);
#endif
        OnFinish?.Invoke(isCorrect);
    }
}
