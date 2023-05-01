using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New spaceship data", menuName = "ScriptableObjects/SpaceshipData")]
public class SpaceshipDataSO : ScriptableObject
{
    public SpaceshipType SpaceshipType;
    [SerializeField,Range(0, 100)] float _lowFuelPrecentage;
    [SerializeField,Range(0, 10)]  float _malfunctionChance;
    [SerializeField] float _maxFuel;
    [SerializeField] float _speed;
    [SerializeField] string _spaceshipName;
    [SerializeField] float _repairTime;

    public float MalfunctionChance => _malfunctionChance;
    public float LowFuelPrecentage => _lowFuelPrecentage;
    public string SpaceshipName=>_spaceshipName;
    public float RepairTime => _repairTime;
    public float Speed => _speed;
    public float MaxFuel => _maxFuel;

    //Fighter
    [Header("Fighter")]
    [SerializeField] private int _maxAmmo;
    public int MaxAmmo
    {
        get
        {
            if (SpaceshipType == SpaceshipType.Fighter)
            {
                return _maxAmmo;
            }
            return 0;
        }
    }
    //Carrier
    [Header("Carrier")]
    [SerializeField] float _carrierLoadAmount = 1;
    public float CarrierLoadAmount
    {
        get
        {
            if (SpaceshipType == SpaceshipType.Carrier)
            {
                return _carrierLoadAmount;
            }
            return 0;
        }
    }
    [SerializeField] float _maxCarryWeight;
    public float MaxCarryWeight
    {
        get
        {
            if (SpaceshipType == SpaceshipType.Carrier)
            {
                return _maxCarryWeight;
            }
            return 0;
        }
    }
    //Mechanic
    [Header("Mechanic")]
    [SerializeField] float _mechanicLoadAmount = 1;
    public float MechanicLoadAmount
    {
        get
        {
            if (SpaceshipType == SpaceshipType.Mechanic)
            {
                return _mechanicLoadAmount;
            }
            return 0;
        }
    }
    [SerializeField] float _maxMechanicFuelTankAmount;

    public float MaxMechanicFuelTankAmount
    {
        get
        {
            if (SpaceshipType == SpaceshipType.Mechanic)
            {
                return _maxMechanicFuelTankAmount;
            }
            return 0;
        }
    }
}
