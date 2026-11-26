using UnityEngine;

public class Platform : MonoBehaviour
{
    // Component
    protected PlayerController player;
    protected PlayerHurt hurt;
    protected new AudioManager audio;
    
    PlayerHeal heal;

    // Private Values
    bool isPlayerOnPlatform;
    
    // === Events === //
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject playerObj = other.gameObject;
        if (playerObj.CompareTag("Player"))
        {
            // Components
            AllComponents(playerObj);
        
            // Logics
            isPlayerOnPlatform = 
                other.contacts[0].normal == Vector2.down;
            
            if (!isPlayerOnPlatform) return;
            player.currPlatform = gameObject;
            Features();
        }
    }

    protected virtual void Features()
    {
        heal.Heal();
        print($"Player collided with {gameObject.name}");
    }
    
    // === Methods === \\
    void AllComponents(GameObject playerObj)
    {
        player = playerObj.GetComponent<PlayerController>();
        hurt = playerObj.GetComponent<PlayerHurt>();
        heal = playerObj.GetComponent<PlayerHeal>();
        
        audio = GameObject.FindWithTag("AudioManager")
            .GetComponent<AudioManager>();
    }

}
