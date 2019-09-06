
public class Word
{
    public int level { get; private set; }
    public string group { get; private set; }
    public string kanji { get; private set; }
    public string pronunciation { get; private set; }
    public string translation { get; private set; }
    public int fails { get; private set; }
    public int wins { get; private set; }
    public float ratio { get; private set; }

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


    public override string ToString()
    {
        return "[" + level + ", " + group + "] " +
            kanji + " (" + pronunciation + "): " + translation;
    }
}
