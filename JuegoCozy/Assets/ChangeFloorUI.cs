using UnityEngine;

public class ChangeFloorUI : MonoBehaviour
{
    public GameObject[] pisos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pisoActual = GameStateManager.Instance.currentFloor;
        for (int i = 0; i< pisos.Length; i++)
        {
            pisos[i].SetActive( false);
        }
        pisos[pisoActual].SetActive(true);
        
    }
}
