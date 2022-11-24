using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private bool onGround = true;
    public bool OnGround
    {
        get
        {
            return onGround;
        }
        set
        {
            onGround = value;
        }
    }

    public bool fall = false;
    private Rigidbody rb;
    public ParticleSystem fireParticle;
    private FuelIndicator fuelIndicator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fuelIndicator = GetComponent<FuelIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnGround();
    }


    void OnCollisionStay(Collision collision)
    {
        StayOnGround(collision);
    }
    void OnCollisionEnter(Collision collision)
    {

    }
    void OnCollisionExit(Collision collision)
    {

        Fall(collision);

    }
    void CheckOnGround()
    {

        if (onGround == false)
        {

            if (fuelIndicator.CurrentFuel > 0)
            {
                fireParticle.Play();
            }
            else if (fuelIndicator.CurrentFuel <= 0)
            {
                rb.constraints = RigidbodyConstraints.None;
                fireParticle.Stop();
                fireParticle.Clear();
                rb.useGravity = true;
                fall = true;
            }

        }


    }

    void StayOnGround(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
            fireParticle.Stop();
            Debug.Log("OnCollision");

        }
    }
    public void SetOnGroundFalse()
    {
        onGround = false;
    }

    void Fall(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = false;
            Debug.Log("ExitCollision");
        }
    }

}
