using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    PlayerController player;

    void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    public void Hurt(int damage=1)
    {
        int currHP = player.currHp;
        if (currHP <= 0)
            return;
        
        for (int i = 1; i <= damage; i++)
        {
            player.hpBar[currHP - i].SetActive(false);
            player.currHp --;
        }
    }

}
