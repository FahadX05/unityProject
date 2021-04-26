using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float Speed;
    public float Acceleration;

    Rigidbody2D rb;
    public float RotationControl;

    float MovY, MovX = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovY = Input.GetAxis("vertical");
    }

    private void FixedUpdate(){
        Vector2 Vel = transform.right * (MovX * Acceleration);
        rb.AddForce(Vel);

        float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if(Acceleration > 0){
            if(Dir > 0){
                rb.rotation += MovY * RotationControl * (rb.velocity.magnitude / Speed);
            }
            else {
                rb.rotation -= MovY * RotationControl * (rb.velocity.magnitude / Speed);

            }
        } 

        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustForce;
        rb.AddForce(rb.GetRelativeVector(relForce));

        if(rb.velocity.magnitude > Speed){
            rb.velocity = rb.velocity.normalized * Speed;
        }
    }
}
