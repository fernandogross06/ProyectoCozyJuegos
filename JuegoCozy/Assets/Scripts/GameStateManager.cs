using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;



public class GameStateManager : MonoBehaviour
{
    [System.Serializable]
    public class Minigame
    {
        [SerializeField] public string gameName;
        [SerializeField] public int gameNumber;

        [SerializeField] public GameObject game;

        [SerializeField] public bool isCompleted;

        [SerializeField] public TextMeshProUGUI gameText;

    }

    [SerializeField] public Minigame[] games;
    public bool minigameInProgress;
    public int minigameIndex;
    public GameObject backgroundSet;
    GameObject currentMinigameObject;
    [SerializeField] AudioClip completionSound;
    [SerializeField] AudioSource audioSource;
    // Set the Singleton instance
    // Every object that wants to interact with this class will do through the singleton instance
    private static GameStateManager _instance;

    public static GameStateManager Instance { get { return _instance; } }
    public bool AlreadyCompletedGames;

    public int currentFloor;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minigameInProgress = false;
        minigameIndex = 0;
        AlreadyCompletedGames = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckCompletion() )
        {
            if (!AlreadyCompletedGames) { 
                // TIRAR MENSAJE DE VICTORIA
                Debug.Log("Ya ganó amigo.");
            }

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //StopMinigame();
            WinMinigame();
        }


    }

    public void StartMinigame(int index)
    {
        if(!minigameInProgress) {
            minigameInProgress = true;
            minigameIndex = index;
            Debug.Log(games[minigameIndex].gameName);
            backgroundSet.SetActive(true);
            currentMinigameObject = Instantiate(games[minigameIndex].game);
            
        }

    }


    public void WinMinigame()
    {
        StopMinigame();


        // Esto es de debug por ahora
        games[minigameIndex].isCompleted = true;
        games[minigameIndex].gameText.color = new Color32(18, 255, 0, 255); // Poner verde de completado
        audioSource.PlayOneShot(completionSound);
    }
    public void StopMinigame()
    {
        Debug.Log(games[minigameIndex].gameName);
        //games[minigameIndex].game.SetActive(false);
        Destroy(currentMinigameObject);
        backgroundSet.SetActive(false);
        minigameInProgress = false;
    }

    public bool CheckCompletion()
    {
        bool allCompleted = true;

        for(int i = 0; i < games.Length; i++)
        {
            if (!games[i].isCompleted) {
                allCompleted = false;
                break;
            }

        }

        return allCompleted;

    }
}
