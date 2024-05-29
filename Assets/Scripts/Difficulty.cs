using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public string difficulty = "easy";

    [SerializeField] private GameObject difficultySettings;
    [SerializeField] private GameObject OgOptions;

    private static Difficulty instance;

    private void Awake() 
    { 
        DontDestroyOnLoad(this); 

        if (instance) { Destroy(this); }
        else { instance = this; }
    }

    public void ViewSettings()
    {
        OgOptions.SetActive(false);
        difficultySettings.SetActive(true);
    }

    public void SetEasy() 
    { 
        difficulty = "easy"; 
        GoBack();
    }

    public void SetHard() 
    { 
        difficulty = "hard"; 
        GoBack();
    }

    public void GoBack()
    {
        difficultySettings.SetActive(false);
        OgOptions.SetActive(true);
    }
}
