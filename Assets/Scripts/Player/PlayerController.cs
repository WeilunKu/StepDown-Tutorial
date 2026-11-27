using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    PlayerMovement move;
    Destroyer destroyer;
    PlayerHurt hurt;
    
    // Inspector Values
    public GameObject[] hpBar;
    
    // Hiding
    [HideInInspector] public GameObject currPlatform;
    [HideInInspector] public int currHp, maxHp;
    
    
    // === Life Cycle === //
    void Awake()
    {
        move = GetComponent<PlayerMovement>();
        hurt = GetComponent<PlayerHurt>();
        
        destroyer = GetComponent<Destroyer>();
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

            platformCollider.enabled = false;
            hurt.Hurt();
        }
    }

}
