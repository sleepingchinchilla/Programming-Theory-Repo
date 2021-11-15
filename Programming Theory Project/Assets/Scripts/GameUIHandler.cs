using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIHandler : MonoBehaviour
{
    private TextMeshProUGUI playerName;
    // Start is called before the first frame update
    void Start()
    {
        playerName = GameObject.Find("Player Name").GetComponent<TextMeshProUGUI>();
        playerName.SetText(GameManager.Instance.playerName);
        Animal animal = GameManager.Instance.chosenAnimal;
        Instantiate(animal, animal.transform.position, animal.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
