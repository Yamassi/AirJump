using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICollision : MonoBehaviour
{
    private bool onGround = false;
    public bool OnGround
    {
        get { return onGround; }
        set { onGround = value; }
    }
    private bool fall = false;
    public bool Fall
    {
        get { return fall; }
        set { fall = value; }
    }
    private Rigidbody rb;
    public ParticleSystem fireParticle;
    private AIFuelIndicator aiFuelIndicator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aiFuelIndicator = GetComponent<AIFuelIndicator>();
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
    void OnCollisionExit(Collision collision)
    {

        Falling(collision);

    }
    void CheckOnGround()
    {

        if (onGround == false)
        {

            if (aiFuelIndicator.CurrentFuel > 0)
            {
                fireParticle.Play();
            }
            else if (aiFuelIndicator.CurrentFuel <= 0)
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
            Debug.Log("AIOnCollision");
        }
    }

    void Falling(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = false;
            Debug.Log("AIExitCollision");
        }
    }

}
