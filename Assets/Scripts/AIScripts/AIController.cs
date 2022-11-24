using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public float speed = 6f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private AIVisible closestPlatform = null;
    public float lookRadius = 10f;
    private Transform target;
    private AICollision aiCollision;

    private void Start()
    {
        aiCollision = GetComponent<AICollision>();
    }
    void FixedUpdate()
    {
        PlayerMove();
        FaceTarget();
    }
    private void PlayerMove()
    {
        AIVisible[] allPlatforms = GameObject.FindObjectsOfType<AIVisible>();
        if (allPlatforms.Length != 0)
        {
            FindClosestObject(allPlatforms);

            float distance = Vector3.Distance(closestPlatform.gameObject.transform.position, transform.position);
            target = closestPlatform.gameObject.transform;
            var lookDirection = (new Vector3(target.position.x, 0, target.position.z) - transform.position).normalized;

            transform.position += (lookDirection).normalized * speed * Time.deltaTime;
        }
        else
        {
            aiCollision.OnGround = false;
        }

    }

    public void FindClosestObject(AIVisible[] allPlatforms)
    {
        float distanceToClosestPlatform = Mathf.Infinity;

        foreach (AIVisible currentPlatform in allPlatforms)
        {
            float distanceToPlatform = (currentPlatform.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlatform < distanceToClosestPlatform)
            {
                distanceToClosestPlatform = distanceToPlatform;
                closestPlatform = currentPlatform;
                print(closestPlatform);
            }
        }


        Debug.DrawLine(this.transform.position, closestPlatform.transform.position);
    }
    void FaceTarget()
    {
        AIVisible[] allPlatforms = GameObject.FindObjectsOfType<AIVisible>();
        if (allPlatforms.Length != 0)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            // transform.rotation = lookRotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


}
