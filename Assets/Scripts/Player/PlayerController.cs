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
    
    // Private Values
    int ceilingDamage;
    
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
        GameObject otherObject = other.gameObject;
        if (otherObject.CompareTag("Ceiling"))
        {
            BoxCollider2D platformCollider 
                = currPlatform.GetComponent<BoxCollider2D>();

            ceilingDamage = otherObject.GetComponent<CeilingSpike>().GetDamage();

            // Logics
            platformCollider.enabled = false;
            audio.PlayEffect(audio.hurtOnCeilingClip);
            hurt.Hurt(ceilingDamage);
        }
    }

}
