using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody rigidBody;
    private ParticleSystem particleSystem;

    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update() {
        ProcessInput();
    }

    private void ProcessInput() {
        //Rocket thrust
        if (Input.GetKey(KeyCode.Space))
        {
            print("Thrusting");
            rigidBody.AddRelativeForce(Vector3.up);
            if (particleSystem.isStopped)
            {
                print("Emitting thrust particles");
                particleSystem.Play();
            }
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            print("No Thrust");
            if (particleSystem.isPlaying)
            {
                print("Stopping thrust particles");
                particleSystem.Stop();
                particleSystem.Clear();
                print("Cleared thrust particles");
            }
        }

        //Rocket turning
        if (Input.GetKey(KeyCode.A))
        {
            print("Rotating Left");
            transform.Rotate(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            print("Rotating Right");
            transform.Rotate(-Vector3.forward);
        }
    }
}
