using System;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Collectible>(out Collectible collectible))
        {
            collectible.Collect(this.gameObject);
        }
    }
}
