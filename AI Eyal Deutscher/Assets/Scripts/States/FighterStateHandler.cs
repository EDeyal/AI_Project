using UnityEngine;

public class FighterStateHandler : BaseStateHandler
{
    [SerializeField] BaseState _reloadAmmunition;
    public BaseState ReloadAmmunition => _reloadAmmunition;
    public override void CheckValidation()
    {
        base.CheckValidation();
        if (_reloadAmmunition == null)
            throw new System.Exception("FighterStateHandler has no reload Ammunition State");
    }
}
