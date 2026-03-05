using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    //[SerializeField] private ParticleSystem _collectedParticles;
    public void Collect(GameObject player)
    {
        ExecuteEffect(player);
        Destroy(gameObject);
    }

    public abstract void ExecuteEffect(GameObject player);
   
}
