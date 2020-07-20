using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttleScripts : MonoBehaviour
{
    //Accesses Rocket script
    Rocket spaceShuttle;

    //This is set up so that the spaceshuttle will detach from the booster at certain points.
    public Boolean FuelStageOne;
    public Boolean FuelStageTwo;
    public Boolean FuelStageThree;

    //Fuel value of rocket
    private double fuelValue;

    // Start is called before the first frame update
    void Start()
    {
        FuelStageOne = true;
        fuelValue = spaceShuttle.getFuelValue();
    }

    // Update is called once per frame
    void Update()
    {
        fuelValue = spaceShuttle.getFuelValue();
    }
}
