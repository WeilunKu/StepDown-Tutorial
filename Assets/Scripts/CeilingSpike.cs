using UnityEngine;

public class CeilingSpike : MonoBehaviour
{
    [SerializeField, Range(1, 10)] int damage = 1;

    public int GetDamage() => damage;
}
