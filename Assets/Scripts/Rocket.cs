using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private double fuelValue;

    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        fuelValue = 100;
    }

    // Update is called once per frame
    void Update() {
        ProcessInput();
    }

    private void ProcessInput() {
        if(fuelValue > 0)
        {
            print(fuelValue + " units of Fuel remaining.");

            //Rocket thrust
            if (Input.GetKey(KeyCode.Space))
            {
                print("Thrusting");
                rigidBody.AddRelativeForce(Vector3.up);
                fuelValue -= 0.05;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                print("No Thrust");
            }

            //Rocket turning
            if (Input.GetKey(KeyCode.A))
            {
                print("Rotating Left");
                transform.Rotate(Vector3.forward);
                fuelValue -= 0.01;
            }
            if (Input.GetKey(KeyCode.D))
            {
                print("Rotating Right");
                transform.Rotate(-Vector3.forward);
                fuelValue -= 0.01;
            }
        }
        else
        {
            print("No fuel remaining");
        }
    }

    public double getFuelValue()
    {
        return fuelValue;
    }
}
