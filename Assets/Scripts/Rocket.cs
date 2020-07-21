using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody rigidBody;
    private double fuelValue;

    [SerializeField] float rcsThrust = 100;
    [SerializeField] float mainThrust = 25;

    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
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
            Thrust();

            //Rocket turning
            Rotation();
        }
        else
        {
            print("No fuel remaining");
        }
    }

    private void Rotation()
    {
        rigidBody.freezeRotation = true; //Take manual control of rotation
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            print("Rotating Left");
            transform.Rotate(Vector3.forward * rotationThisFrame);
            fuelValue -= 0.01;
        }
        if (Input.GetKey(KeyCode.D))
        {
            print("Rotating Right");
            transform.Rotate(-Vector3.forward * rotationThisFrame);
            fuelValue -= 0.01;
        }

        rigidBody.freezeRotation = false; //Resume physics control
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Thrusting");
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            fuelValue -= 0.05;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            print("No Thrust");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                print("Friendly Collision");
                break;
            case "Fuel":
                fuelValue += 25;
                print("Refueled, fuel is now: " + fuelValue + " Units of Fuel.");
                break;
            default:
                print("Player is dead.");
                // kill player
                fuelValue = 0;
                // reload level
                break;

        }
    }

    public double getFuelValue()
    {
        return fuelValue;
    }
}
