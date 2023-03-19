using UnityEngine;

public class CarrierStateHandler : BaseStateHandler
{
    [SerializeField] BaseState _unloadeAmmo;
    public BaseState UnloadAmmo => _unloadeAmmo;
    public CarrierSpaceship CarrierSpaceship => Spaceship as CarrierSpaceship;
    public override void CheckValidation()
    {
        base.CheckValidation();
        if (_unloadeAmmo == null)
            throw new System.Exception("CarrierStateHandler has no unload ammo State");
    }
    private void Update()
    {
        Debug.Log($"Carriier State handler current state: {CurrentState}");
    }
}
