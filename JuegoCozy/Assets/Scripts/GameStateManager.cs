using System.Collections.Generic;
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

    }

    [SerializeField] public Minigame[] games;
    public bool minigameInProgress;
    public int minigameIndex;
    public GameObject backgroundSet;
    GameObject currentMinigameObject;
    // Set the Singleton instance
    // Every object that wants to interact with this class will do through the singleton instance
    private static GameStateManager _instance;

    public static GameStateManager Instance { get { return _instance; } }

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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            StopMinigame();
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

    public void StopMinigame()
    {
        Debug.Log(games[minigameIndex].gameName);
        //games[minigameIndex].game.SetActive(false);
        Destroy(currentMinigameObject);
        backgroundSet.SetActive(false);
        minigameInProgress = false;

    }
}
