using UnityEngine;

public class SphereAnimation : MonoBehaviour
{
    public GameObject sphere;
    private Animator sphereAnim;
    public bool isOneTimeTrigger = true; 
    public Transform player; 
    private bool activated = false;
    public ParticleSystem confetti;
    public ParticleSystem confetti2;
    public ParticleSystem confetti3;
    public ParticleSystem confetti4;

    public AudioSource audioSource; // Поле для AudioSource
    public AudioClip confettiSound;
    private void Awake()
    {
        sphereAnim = sphere.GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 1f && isOneTimeTrigger)
        {
            activated = true;
            sphereAnim.SetTrigger("ButtonOn");
            Debug.Log("Button2Interact activated!");
            isOneTimeTrigger = false;
            confetti.Play();
            confetti2.Play();
            confetti3.Play();
            confetti4.Play();

            if (audioSource != null && confettiSound != null)
        {
            audioSource.clip = confettiSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource или AudioClip не назначены!");
        }
        }
    }

}
