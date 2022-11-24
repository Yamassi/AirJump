using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;
    private float xAxis;
    private float yAxis;
    const string PlayerIdle = "Idle";
    const string PlayerRunForward = "RunForward";
    const string Fall = "Fall";
    const string Fly = "Fly";
    private string currentState;
    private PlayerCollision playerCollision;

    private FuelIndicator fuelIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerCollision = GetComponent<PlayerCollision>();
        fuelIndicator = GetComponent<FuelIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        if (playerCollision.OnGround == true)
        {
            if (yAxis != 0 || xAxis != 0)
            {
                ChangeAnimationState(PlayerRunForward);
            }
            if (yAxis == 0 && xAxis == 0 && playerCollision.OnGround == true)
            {
                ChangeAnimationState(PlayerIdle);
            }
        }
        else if (playerCollision.OnGround == false && fuelIndicator.CurrentFuel > 0)
        {
            ChangeAnimationState(Fly);
            Debug.Log("PlayerFly");
        }
        else if (playerCollision.OnGround == false && fuelIndicator.CurrentFuel <= 0)
        {
            ChangeAnimationState(Fall);
            Debug.Log("PlayerFall");
        }

    }


    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
