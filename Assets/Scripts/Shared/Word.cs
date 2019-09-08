
[System.Serializable]
public class Word
{
    [UnityEngine.SerializeField] private string _kanji;
    public string kanji { get => _kanji; private set { _kanji = value; } }

    [UnityEngine.SerializeField] private string _pronunciation;
    public string pronunciation { get => _pronunciation; private set { _pronunciation = value; } }

    [UnityEngine.SerializeField] private string _translation;
    public string translation { get => _translation; private set { _translation = value; } }

    [UnityEngine.SerializeField] private int _level;
    public int level { get => _level; private set { _level = value; } }

    [UnityEngine.SerializeField] private string _group;
    public string group { get => _group; private set { _group = value; } }

    [UnityEngine.SerializeField] private int _fails;
    public int fails { get => _fails; private set { _fails = value; } }

    [UnityEngine.SerializeField] private int _wins;
    public int wins { get => _wins; private set { _wins = value; } }

    [UnityEngine.SerializeField] private float _ratio;
    public float ratio { get => _ratio; private set { _ratio = value; } }

    public Word(string csvData)
    {
        string[] dataSplit = csvData.Split('\t');
        level = int.Parse(dataSplit[0]);
        group = dataSplit[1].Remove(dataSplit[1].Length - 1).Substring(1);
        kanji = dataSplit[2].Remove(dataSplit[2].Length - 1).Substring(1);
        pronunciation = dataSplit[3].Remove(dataSplit[3].Length - 1).Substring(1);
        translation = dataSplit[4].Remove(dataSplit[4].Length - 1).Substring(1);
        fails = int.Parse(dataSplit[5]);
        wins = int.Parse(dataSplit[6]);
        calculateTotal();
    }

    private void calculateTotal()
    {
        int total = fails + wins;
        ratio = total > 0? ((float)wins / total) : 0.0f;
    }

    public void AddWin()
    {
        _wins++;
        calculateTotal();
    }

    public void AddFail()
    {
        _fails++;
        calculateTotal();
    }

    public override string ToString()
    {
        return "[" + level + ", " + group + "] " +
            kanji + " (" + pronunciation + "): " + translation　+
            " [" + wins + "/" + fails + " = " + ratio + "]";
    }
}
