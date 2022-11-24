using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject AIPlatform;
    private float bottom = -20;
    private BoxCollider boxCollider;
    private PlayerCollision player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottom)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player" | collision.collider.tag == "Enemy")
        {
            Destroy(AIPlatform, 0.3f);

            player = collision.gameObject.GetComponent<PlayerCollision>();

            StartCoroutine(WaitAndFall());

        }


    }
    IEnumerator WaitAndFall()
    {
        //yield on a new YieldInstruction that waits for 1.5 seconds.
        yield return new WaitForSeconds(1.5f);
        if (player != null)
        {
            player.OnGround = false;
        }
        rb.isKinematic = false;
        boxCollider.enabled = false;


    }



}

