using UnityEngine;

public class PlatformDrag : MonoBehaviour
{
    public float distance = 2f;
    public float raycDist = 3f;
    public LayerMask platformLayer;

    private Transform platform;
    private CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            GrabPlatform();
        }
        if(Input.GetKeyUp(KeyCode.E)){
            ReleasePlatform();
        }
        if(platform!=null){
            Move();
        }
    }
    void GrabPlatform(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, raycDist, platformLayer)){
            Debug.Log("Raycast hit: " + hit.collider.name);
            if(hit.collider.CompareTag("Platform")){
                platform = hit.collider.transform;
                Debug.Log("Platform grabbed!");
            }
        }
    }
    void ReleasePlatform(){
        if(platform!=null){
            platform=null;
        }
    }
    void Move(){
        Vector3 targetPosition = transform.position + transform.forward * distance;
        platform.position = targetPosition;
    }
    
}
