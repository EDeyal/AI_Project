using UnityEngine;
public class MechanicStateHandler : BaseStateHandler
{
    [SerializeField] BaseState _loadExtraTank;
    public BaseState LoadExtraTank => _loadExtraTank;
    public MechanicSpaceship MechanicSpaceship => Spaceship as MechanicSpaceship;
    public override void CheckValidation()
    {
        base.CheckValidation();
        if (_loadExtraTank == null)
            throw new System.Exception("MechanicStateHandler has no load Extra Tank State");
    }
    private void Update()
    {
        Debug.Log($"Mechanic State handler current state: {CurrentState}");
    }
}
