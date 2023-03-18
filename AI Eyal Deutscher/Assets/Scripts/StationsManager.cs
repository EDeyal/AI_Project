using System.Collections.Generic;
using UnityEngine;
public enum SpaceshipType
{
    Fighter = 0,
    Carrier = 1,
    Mechanic = 2
}

public class StationsManager : MonoSingleton<StationsManager>
{
    [SerializeField] Transform _shootingStation;
    [SerializeField] Transform _repairStation;
    [SerializeField] Transform _gasStation;
    [SerializeField] Transform _ammunitionStation;
    [SerializeField] Transform _ammunitionWarehouse;

    [SerializeField] List<BaseSpaceship> _stuckCars;
    [SerializeField] List<BaseSpaceship> _repairingCars;
    [SerializeField] float _ammoInAmmunitionStation;
    public List<BaseSpaceship> StuckCars => _stuckCars;
    public float AmmoInAmmunitionStation { get => _ammoInAmmunitionStation; set => _ammoInAmmunitionStation = value; }

    public Vector3 GetNextStation(BaseSpaceship spaceship, out BaseState nextState)
    {
        nextState = null;


        //if we are low on fuel we need to go get fuel
        if (spaceship.CheckIfLowFuel())
        {
            Debug.Log("Missing Fuel");
            //TryAddToStation(_gasStationLine, spaceship);
            nextState = spaceship.StateHandler.FuelState;
            return _gasStation.position;
        }


        //if we have a malfanction we go to repairs
        if (spaceship.HasMalfunction)
        {
            Debug.Log("Spaceship Has Malfunction");
            //TryAddToStation(_repairStationLine, spaceship);
            nextState = spaceship.StateHandler.RepairState;
            return _repairStation.position;
        }
        else
        {
            spaceship.CheckForMalfunctions();
        }

        //action for spaceships
        nextState = spaceship.StateHandler.ActionState;
        if (spaceship.SpaceshipType == SpaceshipType.Fighter)
        {
            if (spaceship is FighterSpaceship fighter)
            {
                if (fighter.CurrentAmmunition <= 0)
                {
                    Debug.Log("Missing Ammo for Spaceship");
                    //TryAddToStation(_ammunitionStationLine, fighter);
                    nextState = fighter.FighterStateHandler.ReloadAmmunition;
                    return _ammunitionStation.position;
                }
            }
            //TryAddToStation(_shootingStationLine, spaceship);
            return _shootingStation.position;
        }
        else if (spaceship.SpaceshipType == SpaceshipType.Carrier)
        {
            if (spaceship is CarrierSpaceship carrier)
            {
                if (carrier.CarrierState == CarrierStateType.Loading)
                {
                    return _ammunitionWarehouse.position;
                }
                else
                {
                    nextState = carrier.CarrierStateHandler.UnloadAmmo;
                }
            }
            return _ammunitionStation.position;
        }
        else
        {
            if (_stuckCars.Count > 1)
            {
                //if (!_repairingCars.Contains(spaceship))
                //{
                //    _repairingCars.Add(spaceship);
                //}
                return _stuckCars[0].transform.position;
            }
            return _repairStation.position;
        }
    }

    //private bool TryAddToStation(List<BaseSpaceship> station, BaseSpaceship spaceship)
    //{
    //    if (!station.Contains(spaceship))
    //    {
    //        station.Add(spaceship);
    //        return true;
    //    }
    //    return false;
    //}

}
