using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddlemovement : MonoBehaviour
{
    public bool RightPlayer;
    public float unitsPerSecond = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontalValue = Input.GetAxis(RightPlayer ? "right paddle" : "left paddle");
        Vector3 force = Vector3.right * horizontalValue * unitsPerSecond;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
        // t.position += Vector.right * horizontalValue * unitsPerSecond * time.deltaTime;

    }
    private void OnCollisionEnter(Collision collision)
    {
 if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 bounceDirection = (collision.contacts[0].point - transform.position).normalized;

            Rigidbody ballRb = collision.rigidbody;
            ballRb.velocity += bounceDirection * unitsPerSecond;
        }
    }
}
