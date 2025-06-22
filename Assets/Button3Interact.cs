using UnityEngine;

public class Button3Interact : MonoBehaviour
{
    public Vector3 spawnPosition; 
    public GameObject doorPrefab; // Префаб двери
    public GameObject currentDoorInstance; // Текущий экземпляр двери

    void Start()
    {
        spawnPosition = new Vector3(-58.36f, 5.37f, 5.11f);
    }

    public void Activate()
    {
        // Уничтожаем текущую дверь, если она существует
        if (currentDoorInstance != null)
        {
            Destroy(currentDoorInstance);
        }

        // Запланировать появление двери через 3 секунды
        Invoke("SpawnDoor", 4.2f);
    }

    public void SpawnDoor()
    {
        // Создаём новую дверь и сохраняем ссылку
        Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);
        currentDoorInstance = Instantiate(doorPrefab, spawnPosition, rotation);
    }
}