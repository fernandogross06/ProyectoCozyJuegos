using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GameObject labelCompletado;
    public GameObject labelGanoTodo;
    public GameObject labelReiniciar;

    // CAMERA POSITIONS
    public Camera Camera;
    public Transform baseCameraPosition;
    public Transform toiletCameraPosition;

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

        if (Input.GetKeyDown(KeyCode.R) && AlreadyCompletedGames)
        {
            //StopMinigame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (CheckCompletion() )
        {
            if (!AlreadyCompletedGames) {
                AlreadyCompletedGames = true;
                // TIRAR MENSAJE DE VICTORIA
                Debug.Log("Ya ganó amigo.");
                MostrarLabelGanoTodo();
            }

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StopMinigame();
            //WinMinigame();
        }


    }

    public void StartMinigame(int index)
    {
        minigameIndex = index;
        if (!minigameInProgress && !games[minigameIndex].isCompleted) {
            minigameInProgress = true;
            
            Debug.Log(games[minigameIndex].gameName);
            backgroundSet.SetActive(true);


            Camera.transform.position = baseCameraPosition.position;
            currentMinigameObject = Instantiate(games[minigameIndex].game);
            
        }

    }


    public void WinMinigame()
    {
        StopMinigame();


        // Esto es de debug por ahora
        games[minigameIndex].isCompleted = true;
        MostrarLabelCompletado();
        games[minigameIndex].gameText.color = new Color32(18, 255, 0, 255); // Poner verde de completado
        audioSource.PlayOneShot(completionSound);
    }

    public void MostrarLabelGanoTodo()
    {
        labelGanoTodo.SetActive(true);
        labelReiniciar.SetActive(true);
        Invoke("HideGanoTodoObject", 5f); // Hide after 2 seconds
    }


    void HideGanoTodoObject()
    {
        labelGanoTodo.SetActive(false);
    }

    public void MostrarLabelCompletado()
    {
        labelCompletado.SetActive(true);
        Invoke("HideObject", 2f); // Hide after 2 seconds
    }

    void HideObject()
    {
        labelCompletado.SetActive(false);
    }

    public void StopMinigame()
    {
        Debug.Log(games[minigameIndex].gameName);
        //games[minigameIndex].game.SetActive(false);
        Destroy(currentMinigameObject);
        backgroundSet.SetActive(false);
        minigameInProgress = false;

        if (currentFloor == 2)
        {
            Camera.transform.position = toiletCameraPosition.position;
        }
        else
        {
            Camera.transform.position = baseCameraPosition.position;
        }

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
