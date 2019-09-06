using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Utils
{
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
}
