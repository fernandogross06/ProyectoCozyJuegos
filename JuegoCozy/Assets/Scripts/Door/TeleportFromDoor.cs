using UnityEngine;

public class TeleportFromDoor : MonoBehaviour
{
    public GameObject player;
    public bool playerInside;
    public bool playerTeleportedHere;
    public TeleportFromDoor destinationDoor;
    public Transform destinationTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            // Do something when up key is pressed while in trigger
            //destinationDoor.playerTeleportedHere = true;
            //destinationDoor.playerInside = true;
            player.transform.position = destinationDoor.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
           // if (!playerInside && !playerTeleportedHere) {
           //     destinationDoor.playerTeleportedHere = true;
           //     destinationDoor.playerInside = true;
           //     player.transform.position = destinationDoor.transform.position;
           //         // Do something when player enters
           // }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTeleportedHere = false;

            playerInside = false;
        }
    }
}
