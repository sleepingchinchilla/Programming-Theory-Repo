using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName { set; get; } // automatically sets the backing field
    public string animal { set; get; }
    public Animal chosenAnimal { set; get; }

    [SerializeField] List<Animal> animalPrefabs;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);

        if(animal == "Frog")
        {
            chosenAnimal = animalPrefabs[0];
        }
        if (animal == "Cat")
        {
            chosenAnimal = animalPrefabs[1];
        }
        if (animal == "Elephant")
        {
            chosenAnimal = animalPrefabs[2];
        }
      
    }
}
