using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController_02 : MonoBehaviour
{
    public WheelCollider[] wheels;
    public float motorPower = 100;
    public float steerPower = 100;

    public GameObject centerOfMass;
    public new Rigidbody rigidbody;

    [SerializeField] Transform player2ResetPoint;
    [SerializeField] KeyCode resetButton;

    private void ResetPosition()
    {
        if (Input.GetKeyDown(resetButton))
        {
            transform.position = player2ResetPoint.position;
            transform.rotation = Quaternion.identity;
        }
    }

    private void Update()
    {
        ResetPosition();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var wheel in wheels)
        { float vertical = 0;
            vertical = Input.GetAxis("P2Vertical");

            if (Input.GetKey(KeyCode.W)) vertical = 1;
            if (Input.GetKey(KeyCode.S)) vertical = -1;

            wheel.motorTorque = vertical * motorPower;
        }
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                if (i < 2)
                {
                    float horizontal = 0;
                    horizontal = Input.GetAxis("P2Horizontal");

                    if (Input.GetKey(KeyCode.D)) horizontal = 1;
                    if (Input.GetKey(KeyCode.A)) horizontal = -1;
                    wheels[i].steerAngle = horizontal * steerPower;
                }
            }
        }
    }
}

