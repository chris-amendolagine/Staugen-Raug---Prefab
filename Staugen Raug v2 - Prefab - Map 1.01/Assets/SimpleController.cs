using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    public WheelCollider[] wheels;
    public float motorPower = 100;
    public float steerPower = 100;

    public GameObject centerOfMass;
    public new Rigidbody rigidbody;

    [SerializeField] Transform player1ResetPoint;
    [SerializeField] KeyCode resetButton;

    private void ResetPosition()
    {
        if (Input.GetKeyDown(resetButton))
        {
            transform.position = player1ResetPoint.position;
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
        {
            float vertical = 0;
            vertical = Input.GetAxis("P1Vertical");

            if (Input.GetKey(KeyCode.UpArrow)) vertical = 1;
            if (Input.GetKey(KeyCode.DownArrow)) vertical = -1;

            wheel.motorTorque = vertical * motorPower;
        }
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                if (i < 2)
                {
                    float horizontal = 0;
                    horizontal = Input.GetAxis("P1Horizontal");

                    if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1;
                    if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1;
                    wheels[i].steerAngle = horizontal * steerPower;
                }
            }
        }
    }
}
    
