using UnityEngine;

public class FuelCollect : Collectible
{
    [SerializeField] private float _fuelAmount = 1f;
    public override void ExecuteEffect(GameObject player)
    {
        Jetpack jetpack = player.GetComponentInChildren<Jetpack>();
        jetpack.AddFuel(_fuelAmount);
    }
}
