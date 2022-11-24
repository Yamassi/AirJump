using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FuelIndicator : MonoBehaviour
{
    private float maxFuel = 5;
    public float MaxFuel
    {
        get
        {
            return maxFuel;
        }
        set
        {
            maxFuel = value;
        }
    }
    private float currentFuel;
    public float CurrentFuel
    {
        get
        {
            return currentFuel;
        }
        set
        {
            currentFuel = value;
        }
    }
    public float startFuel = 1;
    private FuelBar fuelBar;
    private PlayerCollision playerCollision;
    // Start is called before the first frame update
    void Start()
    {
        playerCollision = GetComponent<PlayerCollision>();
        var fuelBarObject = GameObject.Find("FuelBar");
        fuelBar = fuelBarObject.GetComponent<FuelBar>();
        currentFuel = startFuel;
        fuelBar.SetMaxFuel(maxFuel);
    }

    // Update is called once per frame
    void Update()
    {
        fuelBar.SetFuel(currentFuel);

        if (playerCollision.OnGround == false && playerCollision.fall == false)
        {
            currentFuel -= Time.deltaTime;
        }

    }

}
