using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIFuelIndicator : MonoBehaviour
{
    private float maxFuel = 5;

    public float MaxFuel
    {
        get { return maxFuel; }
        set { maxFuel = value; }

    }
    private float currentFuel;
    public float CurrentFuel
    {
        get { return currentFuel; }
        set { currentFuel = value; }
    }
    public float startFuel = 1;
    // public FuelBar fuelBar;
    private AICollision aiCollision;
    // Start is called before the first frame update
    void Start()
    {
        aiCollision = GetComponent<AICollision>();
        currentFuel = startFuel;

    }

    // Update is called once per frame
    void Update()
    {
        // fuelBar.SetFuel(currentFuel);
        // print("currentAIfuel" + currentFuel);
        if (aiCollision.OnGround == false && aiCollision.Fall == false)
        {
            currentFuel -= Time.deltaTime;
        }

    }

}
