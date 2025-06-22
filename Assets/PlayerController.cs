using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 2f;
    public float gravity = -1f;
    public Transform cameraTransform;
    public Transform spawnPoint;
    public int maxHP = 3;
    private int currentHP;
    public DoorAppear doorScript;

    public TextMeshProUGUI hpText;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentHP = maxHP;
        UpdateHPUI();
    }

    void Update()
    {
        Move();
        Jump();
        CheckFall();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = (moveZ * forward + moveX * right) * moveSpeed;


        characterController.Move(movement * Time.deltaTime);
    }

    void Jump()
    {
        // Проверяем, находится ли игрок на земле
        isGrounded = characterController.isGrounded || Physics.Raycast(transform.position, Vector3.down, 0.1f);
        Debug.Log("isGrounded: " + isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Легкая "подстройка" для предотвращения "дребезга"
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Формула для расчета силы прыжка
            Debug.Log("Jump triggered!");
        }

        // Применяем гравитацию
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 3f))
        {
            if (hit.collider.CompareTag("Button"))
            {
                if (hit.collider.GetComponent<ButtonInteract>() != null)
                {
                    hit.collider.GetComponent<ButtonInteract>().Activate();
                }
                if (hit.collider.GetComponent<Button2Interact>() != null)
                {
                    Debug.Log("Button2Interact found!");
                    hit.collider.GetComponent<Button2Interact>().Activate();
                }
                if (hit.collider.GetComponent<Button3Interact>() != null)
                {
                    Debug.Log("Button3Interact found!");
                    hit.collider.GetComponent<Button3Interact>().Activate();
                }
                if (hit.collider.GetComponent<TrophyInteract>() != null)
                {
                    Debug.Log("Trophy found!");
                    hit.collider.GetComponent<TrophyInteract>().Activate();
                }
            }
        }
    }

private bool isFalling = false;

void CheckFall()
{
    if (transform.position.y < -10f && !isFalling)
    {
        Debug.Log("Обнаружено падение");
        isFalling = true;
        HandleFall();
    }
    else if (transform.position.y >= -9f)
    {
        isFalling = false;
        Debug.Log("Выход из зоны падения");
    }
}

void HandleFall()
{
    if (spawnPoint == null)
    {
        return;
    }

    currentHP--;

    if (currentHP <= 0)
    {
        Debug.Log("HP = 0 → Загрузка меню");
        UIMainMenu.SetGameOver();
        SceneManager.LoadScene("Scenes/LoadScene");
    }
    else
    {
        transform.position = spawnPoint.position + Vector3.up * 0.5f;
        velocity = Vector3.zero;
        characterController.enabled = false;
        characterController.enabled = true;
        UpdateHPUI();
        if (doorScript != null)
        {
            doorScript.ResetDoor();
        }

        Debug.Log($"Телепортация выполнена: position = {transform.position}, velocity = {velocity}");
    }
}
    
    void UpdateHPUI()
    {
        if (hpText != null)
    {
        string hearts = "";
        for (int i = 0; i < currentHP; i++)
        {
            hearts += "<sprite=0>";
        }

        hpText.text = hearts;
    }
    else
    {
        Debug.LogError("HPText не назначен!");
    }
    }

}