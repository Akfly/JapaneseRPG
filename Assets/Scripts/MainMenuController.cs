using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject TogglePrefab;

    [Header("References")]
    public Transform ScrollViewContentLevels;
    public Transform ScrollViewContentGroups;

    // Start is called before the first frame update
    void Start()
    {
        AddToggles(DatabaseManager.instance.levelList, ScrollViewContentLevels);
        AddToggles(DatabaseManager.instance.groupList, ScrollViewContentGroups);
    }

    private void AddToggles<T>(List<T> list, Transform parent)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject toggle = Instantiate(TogglePrefab, parent);
            toggle.name = list[i].ToString();
            toggle.transform.Find("Label").GetComponent<Text>().text = list[i].ToString();
        }
    }

}
