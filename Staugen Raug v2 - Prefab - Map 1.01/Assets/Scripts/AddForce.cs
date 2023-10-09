
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Rigidbody rb;
    public float Vector3 = 100f;
    bool useDownForce = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //rb.AddForce(-transform.up * Vector3, ForceMode.Acceleration);

       if (Input.GetAxis("UpForce01") > 0)
       {
            rb.AddForce(transform.up * Vector3, ForceMode.Acceleration);
       }
        //{
        //    rb.AddForce(transform.up * Vector3, ForceMode.Acceleration);

        //    if (useDownForce)
        //    {
        //        rb.AddForce(transform.up * Vector3, ForceMode.Acceleration);
        //    }

        //}
    }
}
