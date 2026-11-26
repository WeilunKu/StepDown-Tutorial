using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float destroyPositonY;
    
    
    // === API === \\
    public void DestroyAtHeight(bool isPositive)
    {
        float targetHeight, currentHeight;
        targetHeight = destroyPositonY;
        currentHeight = transform.position.y;

        bool higherThanTarget, lowerThanTarget;
        higherThanTarget = currentHeight >= targetHeight;
        lowerThanTarget = currentHeight <= targetHeight;

        
        if (isPositive && higherThanTarget ||
            !isPositive && lowerThanTarget)
        {
            Destroy(gameObject);
        }

    }
}
