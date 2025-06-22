using UnityEngine;
using UnityEngine.SceneManagement;
public class TrophyInteract : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Activate()
    {
        Debug.Log("трофей → Загрузка меню");
        UIMainMenu.SetGameWon();
        SceneManager.LoadScene("Scenes/LoadScene");
    }
}
