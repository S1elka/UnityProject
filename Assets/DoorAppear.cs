using UnityEngine;

public class DoorAppear : MonoBehaviour
{
    public GameObject doorpref; 
    public Vector3 spawnPosition; 
    public bool isOneTimeTrigger = true; 
    public Transform player; 

    private GameObject currentDoorInstance;
    
    void Start()
    {
        spawnPosition = new Vector3(-18.09f, 2.1564f, -11.9625f);
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 1f && currentDoorInstance == null)
        {
            Debug.Log("Player is near. Spawning door...");
            Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);
            currentDoorInstance = Instantiate(doorpref, spawnPosition, rotation);
        }
    }

    public void ResetDoor()
    {
        if (currentDoorInstance != null)
        {
            Destroy(currentDoorInstance);
            currentDoorInstance = null;
        }
    }
}

