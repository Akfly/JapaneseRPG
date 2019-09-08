using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Utils
{
    private static char[] hiraganaIndices =
    {
        'あ', 'い', 'う', 'え', 'お', 'か', 'き', 'く', 'け', 'こ', 'さ', 'し' , 'す', 'せ', 'そ',
        'た', 'ち', 'つ', 'て', 'と', 'な', 'に', 'ぬ', 'ね', 'の', 'は', 'ひ' , 'ふ', 'へ', 'ほ',
        'ま', 'み', 'む', 'め', 'も', 'ら', 'り', 'る', 'れ', 'ろ', 'が', 'ぎ' , 'ぐ', 'げ', 'ご',
        'ざ', 'じ', 'ず', 'ぜ', 'ぞ', 'だ', 'ぢ', 'づ', 'で', 'ど', 'ば', 'び' , 'ぶ', 'べ', 'ぼ',
        'ぱ', 'ぴ', 'ぷ', 'ぺ', 'ぽ', 'や', 'ゆ', 'よ', 'わ', 'を', 'ん', 'っ' , 'ぁ', 'ぃ', 'ぅ',
        'ぇ', 'ぉ', 'ゕ', 'ヶ', 'ゎ', 'ゃ', 'ゅ', 'ょ', 'ゔ'
    };

    private static char[] katakanaIndices =
    {
        'ア', 'イ', 'ウ', 'エ', 'オ', 'カ', 'キ', 'ク', 'ケ', 'コ', 'サ', 'シ' , 'ス', 'セ', 'ソ',
        'タ', 'チ', 'ツ', 'テ', 'ト', 'ナ', 'ニ', 'ヌ', 'ネ', 'ノ', 'ハ', 'ヒ' , 'フ', 'ヘ', 'ホ',
        'マ', 'ミ', 'ム', 'メ', 'モ', 'ラ', 'リ', 'ル', 'レ', 'ロ', 'ガ', 'ギ' , 'グ', 'ゲ', 'ゴ',
        'ザ', 'ジ', 'ズ', 'ゼ', 'ゾ', 'ダ', 'ヂ', 'ヅ', 'デ', 'ド', 'バ', 'ビ' , 'ブ', 'ベ', 'ボ',
        'パ', 'ピ', 'プ', 'ペ', 'ポ', 'ヤ', 'ユ', 'ヨ', 'ワ', 'ヲ', 'ン', 'ッ' , 'ァ', 'ィ', 'ゥ',
        'ェ', 'ォ', 'ヵ', 'ヶ', 'ヮ', 'ャ', 'ュ', 'ョ', 'ヴ'
    };

    public static Dictionary<char, char> hiraToKataDictionary = new Dictionary<char, char>();
    public static Dictionary<char, char> kataToHiraDictionary = new Dictionary<char, char>();
    static Utils()
    {
        for(int i = 0; i < hiraganaIndices.Length; i++)
        {
            hiraToKataDictionary.Add(hiraganaIndices[i], katakanaIndices[i]);
            kataToHiraDictionary.Add(katakanaIndices[i], hiraganaIndices[i]);
        }
    }
#if UNITY_EDITOR
    public static void DebugList<T>(List<T> list)
    {
        if(list == null || list.Count <= 0)
        {
            Debug.Log(list);
            return;
        }

        string output = "[0]: " + list[0].ToString();
        for(int i = 1; i < list.Count; i++)
        {
            output += ",\n[" + i + "]: " + list[i].ToString();
        }

        Debug.Log(output);
    }
#endif

    public static string HiraToKata(string input)
    {
        string output = "";
        for(int i = 0; i < input.Length; i++)
        {
            output += hiraToKataDictionary.ContainsKey(input[i]) ? hiraToKataDictionary[input[i]] : input[i];
        }

        return output;
    }

    public static string KataToHira(string input)
    {
        string output = "";
        for (int i = 0; i < input.Length; i++)
        {
            output += kataToHiraDictionary.ContainsKey(input[i]) ? kataToHiraDictionary[input[i]] : input[i];
        }

        return output;
    }

    public static Word GetRandomWordByRatio(List<Word> wordList)
    {
        float sumRatio = 0.0f;
        for(int i = 0; i < wordList.Count; i++)
        {
            sumRatio += 1 - wordList[i].ratio;
        }

        float randomSelector = Random.Range(0.0f, sumRatio);
        sumRatio = 0.0f;

        for (int i = 0; i < wordList.Count; i++)
        {
            sumRatio += 1 - wordList[i].ratio;
            if(sumRatio >= randomSelector)
            {
                return wordList[i];
            }
        }

        return null;
    }
}
