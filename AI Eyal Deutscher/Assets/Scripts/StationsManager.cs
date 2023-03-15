using System.Collections.Generic;
using UnityEngine;

public class StationsManager : MonoSingleton<StationsManager>
{
    [SerializeField] Transform _shootingStation;
    [SerializeField] Transform _repairStation;
    [SerializeField] Transform _gasStation;

    [SerializeField] List<BaseSpaceship> _shootingStationLine;
    [SerializeField] List<BaseSpaceship> _repairStationLine;
    [SerializeField] List<BaseSpaceship> _gasStationLine;

    public Vector3 GetNextStation(BaseSpaceship spaceship,out BaseState nextState)
    {
        //if we have a malfanction we go to repairs
        if (spaceship.HasMalfanction)
        {
            if (TryAddToStation(_repairStationLine, spaceship))
            {
            nextState = spaceship.StateHandler.RepairState;
            return _repairStation.position;
            }
        }
        //if we have enough fuel we go to the shooting range
        //need to be changed by the distance from the gas station
        if (spaceship.CurrentFuel > 0)
        {
            if (TryAddToStation(_shootingStationLine, spaceship))
            {
                nextState = spaceship.StateHandler.ActionState;
                return _shootingStation.position;
            }
        }
        //else we go to the fuel station
        else
        {
            if (TryAddToStation(_gasStationLine, spaceship))
            {
                nextState = spaceship.StateHandler.FuelState;
                return _gasStation.position;
            }
        }
        Debug.LogError("Station Manager Logic Bug");
        nextState = spaceship.StateHandler.IdleState;
        return Vector3.zero;

    }

    private bool TryAddToStation(List<BaseSpaceship> station,BaseSpaceship spaceship)
    {
        if (!station.Contains(spaceship))
        {
            station.Add(spaceship);
            return true;
        }
        return false;
    }
}
