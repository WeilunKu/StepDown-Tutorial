using UnityEngine;

public class Platform : MonoBehaviour
{
// Platform

// Component
    protected PlayerController player;
    protected PlayerHurt hurt;
    protected PlayerHeal heal;

// === Events === //
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject playerObj = other.gameObject;
        if (playerObj.CompareTag("Player"))
        {
            // Components
            AllComponents(playerObj);
        
            // Logics
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
    }

}
