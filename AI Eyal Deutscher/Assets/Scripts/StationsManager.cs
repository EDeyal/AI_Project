using System.Collections.Generic;
using UnityEngine;
public enum SpaceshipType
{
    Fighter = 0,
    Cargo = 1,
    Carrier = 2
}

public class StationsManager : MonoSingleton<StationsManager>
{
    [SerializeField] Transform _shootingStation;
    [SerializeField] Transform _repairStation;
    [SerializeField] Transform _gasStation;
    [SerializeField] Transform _ammunitionStation;

    [SerializeField] List<BaseSpaceship> _shootingStationLine;
    [SerializeField] List<BaseSpaceship> _repairStationLine;
    [SerializeField] List<BaseSpaceship> _gasStationLine;
    [SerializeField] List<BaseSpaceship> _ammunitionStationLine;

    public Vector3 GetNextStation(BaseSpaceship spaceship, out BaseState nextState)
    {
        //if we have a malfanction we go to repairs
        nextState = null;
        if (spaceship.HasMalfunction)
        {
            TryAddToStation(_repairStationLine, spaceship);
            nextState = spaceship.StateHandler.RepairState;
            return _repairStation.position;
        }
        else
        {
            spaceship.CheckForMalfunctions();
        }
        if (spaceship.SpaceshipType == SpaceshipType.Fighter)
        {
            if (spaceship is FighterSpaceship fighter)
            {
                if (fighter.CurrentAmmunition <= 0)
                {
                    TryAddToStation(_ammunitionStationLine, fighter);
                    nextState = fighter.FighterStateHandler.ReloadAmmunition;
                    return _ammunitionStation.position;
                }
            }
        }
        //if we have enough fuel we go to the shooting range
        //need to be changed by the distance from the gas station
        if (spaceship.CurrentFuel > 0)
        {
            TryAddToStation(_shootingStationLine, spaceship);
            nextState = spaceship.StateHandler.ActionState;
            return _shootingStation.position;
        }
        //else we go to the fuel station
        else
        {
            TryAddToStation(_gasStationLine, spaceship);
            nextState = spaceship.StateHandler.FuelState;
            return _gasStation.position;
        }
        //Debug.LogError("Station Manager Logic Bug");
        //nextState = spaceship.StateHandler.IdleState;
        //return Vector3.zero;

    }

    private bool TryAddToStation(List<BaseSpaceship> station, BaseSpaceship spaceship)
    {
        if (!station.Contains(spaceship))
        {
            station.Add(spaceship);
            return true;
        }
        return false;
    }

}
