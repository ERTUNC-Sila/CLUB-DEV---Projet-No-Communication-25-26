using UnityEngine;

public class Collectible : MonoBehaviour
{
    public void Collect()
    {
        ExecuteEffect();
        Destroy(gameObject);
    }

    private void ExecuteEffect()
    {

    }
}
