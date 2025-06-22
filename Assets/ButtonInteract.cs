using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public GameObject door;

    private bool activated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate(){
        if(!activated){
            activated = true;
            Destroy(door, 2f);
        }
    }
}
