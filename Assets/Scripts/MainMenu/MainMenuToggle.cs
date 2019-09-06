using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuToggle : MonoBehaviour
{
    [HideInInspector] public string currentName = "";
    [HideInInspector] public System.Action<MainMenuToggle, bool> onToggleChangeEvent = null;

    private Text label;
    [HideInInspector] public Toggle toggle { get; private set; }

    public void Awake()
    {
        label = transform.Find("Label").GetComponent<Text>();
        toggle = transform.GetComponent<Toggle>();
    }

    public void setName(string name)
    {
        gameObject.name = name;
        label.text = name;
        currentName = name;
    }

    public void setEnabled(bool isEnabled)
    {
        toggle.interactable = isEnabled;
    }

    public void onToggleChange()
    {
        onToggleChangeEvent?.Invoke(this, toggle.isOn);
    }
}
