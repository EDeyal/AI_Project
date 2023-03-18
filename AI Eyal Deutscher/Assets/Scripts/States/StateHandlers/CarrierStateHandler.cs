using UnityEngine;

public class CarrierStateHandler : BaseStateHandler
{
    [SerializeField] BaseState _unloadeAmmo;
    public BaseState UnloadAmmo => _unloadeAmmo;
    public CarrierSpaceship CarrierSpaceship => Spaceship as CarrierSpaceship;
    //public override void CheckValidation()
    //{
    //    base.CheckValidation();
    //    if (_reloadAmmunition == null)
    //        throw new System.Exception("FighterStateHandler has no reload Ammunition State");
    //}
    private void Update()
    {
        Debug.Log($"Carriier State handler current state: {CurrentState}");
    }
}
