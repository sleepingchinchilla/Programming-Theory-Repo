using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{
    private TextMeshProUGUI playerNameText;
    private TMP_InputField inputField;
    private TMP_Dropdown dropdown;

    private string playerName;
    public string PlayerName
    {
        get { return playerName; }
        set
        {
            if (value != null && value.Length < 10)
            {
                playerName = value;
                SendData();
            }
            else
            {
                Debug.LogError("The name is too long or null");
                inputField.text = "Name too long!";
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("Name InputField").GetComponent<TMP_InputField>();
        dropdown = GameObject.Find("Animal Dropdown").GetComponent<TMP_Dropdown>();
    }

    public void CheckAndSetName()
    {
        PlayerName = inputField.text;
    }
    void SendData()
    {
        GameManager.Instance.playerName = PlayerName;
        //Debug.Log(dropdown.options[dropdown.value].text);
        GameManager.Instance.animal = dropdown.options[dropdown.value].text;
        GameManager.Instance.GameStart();
    }
}
