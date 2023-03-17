using UnityEngine;

public class FighterStateHandler : BaseStateHandler
{
    [SerializeField] BaseState _reloadAmmunition;
    public BaseState ReloadAmmunition => _reloadAmmunition;
    public FighterSpaceship FighterSpaceship => Spaceship as FighterSpaceship;
    public override void CheckValidation()
    {
        base.CheckValidation();
        if (_reloadAmmunition == null)
            throw new System.Exception("FighterStateHandler has no reload Ammunition State");
    }
    private void Update()
    {
        Debug.Log($"Fighter State handler current state: {CurrentState}");
    }
}
