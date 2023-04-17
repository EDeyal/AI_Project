using UnityEngine;
public class MechanicStateHandler : BaseStateHandler
{
    [SerializeField] BaseState _repairSpaceship;
    public BaseState RepairSpaceship => _repairSpaceship;
    public MechanicSpaceship MechanicSpaceship => Spaceship as MechanicSpaceship;
    public override void CheckValidation()
    {
        base.CheckValidation();
        if (_repairSpaceship == null)
            throw new System.Exception("MechanicStateHandler has no load reapair spaceship State");
    }
    private void Update()
    {
        Debug.Log($"Mechanic State handler current state: {CurrentState}");
    }
}
