using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    public float MaxBaloonValue = 3f;
    private FuelIndicator fuelIndicator;
    private AIFuelIndicator AIfuelIndicator1;
    private AIFuelIndicator AIfuelIndicator2;
    private AIFuelIndicator AIfuelIndicator3;
    private AIFuelIndicator AIfuelIndicator4;
    private AIFuelIndicator AIfuelIndicator5;
    private AIFuelIndicator AIfuelIndicator6;
    private AIFuelIndicator AIfuelIndicator7;
    // Start is called before the first frame update
    void Start()
    {
        fuelIndicator = GameObject.Find("Player").GetComponent<FuelIndicator>();
        AIfuelIndicator1 = GameObject.Find("AI01").GetComponent<AIFuelIndicator>();
        AIfuelIndicator2 = GameObject.Find("AI02").GetComponent<AIFuelIndicator>();
        AIfuelIndicator3 = GameObject.Find("AI03").GetComponent<AIFuelIndicator>();
        // AIfuelIndicator4 = GameObject.Find("AI04").GetComponent<AIFuelIndicator>();
        // AIfuelIndicator5 = GameObject.Find("AI05").GetComponent<AIFuelIndicator>();
        // AIfuelIndicator6 = GameObject.Find("AI06").GetComponent<AIFuelIndicator>();
        // AIfuelIndicator7 = GameObject.Find("AI07").GetComponent<AIFuelIndicator>();
    }

    // Update is called once per frame
    void Update()
    {




    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            float max = fuelIndicator.MaxFuel;
            float current = fuelIndicator.CurrentFuel;
            current += MaxBaloonValue;
            if (current > max)
            {
                fuelIndicator.CurrentFuel = max;
            }
            else
            {
                fuelIndicator.CurrentFuel += MaxBaloonValue;
            }


            Destroy(gameObject);
        }
        if (collision.collider.tag == "Enemy")
        {
            SetFuel(AIfuelIndicator1);
        }

    }

    void SetFuel(AIFuelIndicator aIFuelIndicator)
    {
        float max = aIFuelIndicator.MaxFuel;
        float current = aIFuelIndicator.CurrentFuel;
        current += 5;
        if (current > max)
        {
            aIFuelIndicator.CurrentFuel = max;
        }
        else
        {
            aIFuelIndicator.CurrentFuel += MaxBaloonValue;
        }


        Destroy(gameObject);
    }

}
