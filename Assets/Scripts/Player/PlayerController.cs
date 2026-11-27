using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    new AudioManager audio;
    
    Destroyer destroyer;
    PlayerMovement move;
    PlayerHurt hurt;
    
    // Inspector Values
    public GameObject[] hpBar;
    
    // Hiding
    [HideInInspector] public GameObject currPlatform;
    [HideInInspector] public int currHp, maxHp;
    
    
    // === Life Cycle === //
    void Awake()
    {
        audio = GameObject.FindWithTag("AudioManager")
            .GetComponent<AudioManager>();
        
        destroyer = GetComponent<Destroyer>();
        move = GetComponent<PlayerMovement>();
        hurt = GetComponent<PlayerHurt>();
    }

    void Start()
    {
        currHp = hpBar.Length;
        maxHp = hpBar.Length;
    }
    
    void Update()
    {
        destroyer.DestroyAtHeight(isPositive: false);
    }
    
    void FixedUpdate()
    {
        move.Movement();
    }
    
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ceiling"))
        {
            BoxCollider2D platformCollider 
                = currPlatform.GetComponent<BoxCollider2D>();

            // Logics
            platformCollider.enabled = false;
            hurt.Hurt();
            audio.PlayEffect(audio.hurtOnCeilingClip);
        }
    }

}
