using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
// PlayerHurt

    PlayerController player;

    void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    public void Hurt(int damage=1)
    {
        if (player.currHp <= 0) 
            return;

        player.currHp -= damage;
        player.hpBar[player.currHp].SetActive(false);

        print("扣血");
    }

}
