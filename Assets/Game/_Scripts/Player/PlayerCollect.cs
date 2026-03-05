using System;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Collectible>(out Collectible collectible))
        {
            collectible.Collect();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Collectible collectible = other.GetComponent<Collectible>();
    //    if (collectible != null)
    //    {
    //        collectible.Collect(this.gameObject);
    //        Destroy(collectible.gameObject);
    //    }
    //}
}
