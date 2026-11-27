using UnityEngine;

// Platform_Bouncy

public class Platform_Normal : Platform
{
    protected override void Features()
    {
        base.Features();
        
        audio.PlayEffect(audio.landClip);
    }
}

