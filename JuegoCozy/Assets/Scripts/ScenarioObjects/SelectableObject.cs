using System;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public Camera Camera;
    public GameObject outline;
    public Rigidbody2D rb;
    public float jumpForce;
    public bool isSelected;
    public int minigameIndex;
    public int floor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Selected(false);

        if(outline != null){
            outline.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                GameStateManager.Instance.StartMinigame(minigameIndex);
            }

        }
        
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //Debug.Log("Mouse is over GameObject.");
        //outline.SetActive(true);
        if (GameStateManager.Instance.currentFloor == floor)
        {
            Selected(true);
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //Debug.Log("Mouse is no longer on GameObject.");
        //outline.SetActive(false);
        Selected(false);
    }

    void Selected(bool state)
    {
        if(outline!= null) outline.SetActive(state);
        isSelected = state;
    }
}
