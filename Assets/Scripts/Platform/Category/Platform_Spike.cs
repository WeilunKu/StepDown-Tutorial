using UnityEngine;

public class Platform_Spike : Platform
{
    [SerializeField, Range(1, 10)] int damage = 1;
    
    protected override void Features()
    {
        hurt.Hurt(damage);
        audio.PlayEffect(audio.hurtOnSpikeClip);
    }
}

