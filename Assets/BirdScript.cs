using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public AudioSource myAudioSource; 
    public AudioClip bubbleSound;
    public AudioClip deathSound;
    public Rigidbody2D myRigidbody;
    public float FlapStrength;
    public LogicScript logic;
    public AudioSource musicSource;
    public bool birdIsAlive = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * FlapStrength;
            myAudioSource.PlayOneShot(bubbleSound);
        }
       
        if (transform.position.y > 45 || transform.position.y < -45)
        {
            musicSource.Stop();
            logic.gameOver();
            birdIsAlive = false;
        }
    }
    public ParticleSystem deathParticles;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        logic.gameOver();
        birdIsAlive = false;
        musicSource.Stop();
        myAudioSource.PlayOneShot(deathSound);
    }
}
