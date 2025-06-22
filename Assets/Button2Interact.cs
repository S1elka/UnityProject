using UnityEngine;

public class Button2Interact : MonoBehaviour
{
     public Transform platform;
    public float speed = 1f;
    private bool activated = false;
    private Vector3 targetPos;

    void Start()
    {
        
        targetPos = platform.position;
    }

    void Update()
    {
        
        if (activated)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos, speed * Time.deltaTime);
        }
    }

    public void Activate()
    {
        if (!activated)
        {
            activated = true;
            targetPos = new Vector3(platform.position.x, platform.position.y + 3f, platform.position.z);
            Debug.Log("Button2Interact activated!");
        }
    }
}
