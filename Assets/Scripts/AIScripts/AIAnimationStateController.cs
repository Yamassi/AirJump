using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimationStateController : MonoBehaviour
{
    public Animator animator;
    private float xAxis;
    private float yAxis;
    private Vector2 previousPos;
    const string Idle = "Idle";
    const string RunForward = "RunForward";
    const string Fall = "Fall";
    const string Fly = "Fly";
    private string currentState;
    private AICollision aiCollision;
    private AIFuelIndicator aiFuelIndicator;


    // Start is called before the first frame update
    void Start()
    {
        aiCollision = GetComponent<AICollision>();
        aiFuelIndicator = GetComponent<AIFuelIndicator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.z);
        // AIVisible[] allPlatforms = GameObject.FindObjectsOfType<AIVisible>();
        Vector2 deltaPos = currentPos - previousPos;


        if (aiCollision.OnGround == true)
        {

            if (deltaPos.magnitude > 0.1f)
            {
                ChangeAnimationState(RunForward);

            }
            if (deltaPos.magnitude == 0 && aiCollision.OnGround == true)
            {
                ChangeAnimationState(Idle);
            }
        }
        else if (aiCollision.OnGround == false && aiFuelIndicator.CurrentFuel > 0)
        {
            ChangeAnimationState(Fly);

        }
        else if (aiCollision.OnGround == false && aiFuelIndicator.CurrentFuel <= 0)
        {
            ChangeAnimationState(Fall);
        }
        // if (allPlatforms.Length == 0)
        // {
        //     ChangeAnimationState(Idle);
        // }
        previousPos.x = transform.position.x;
        previousPos.y = transform.position.z;
    }
    private void LateUpdate()
    {

    }


    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
