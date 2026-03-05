using UnityEngine;

public class Collectible : MonoBehaviour
{
    //[SerializeField] private ParticleSystem _collectedParticles;
    public void Collect()
    {
        ExecuteEffect();
        Destroy(gameObject);
    }

    private void ExecuteEffect()
    {

    }
}
