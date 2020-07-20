using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This handles the NozzleFlame particles

public class NozzleFlame : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private Rocket rocket;
    private double fuelValue;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        rocket = Rocket.FindObjectOfType<Rocket>();
        fuelValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuelValue > 0)
        {
            //Rocket thrust
            if (Input.GetKey(KeyCode.Space))
            {
                //Update fuelValue
                fuelValue = rocket.getFuelValue();

                print(fuelValue);

                if (particleSystem.isStopped)
                {
                    print("Emitting thrust particles");
                    particleSystem.Play();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
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
                //Update fuelValue
                fuelValue = rocket.getFuelValue();
            }
            if (Input.GetKey(KeyCode.D))
            {
                //Update fuelValue
                fuelValue = rocket.getFuelValue();
            }
        }
        else
        {
            //Clear particles if still running
            if (particleSystem.isPlaying)
            {
                print("Stopping thrust particles");
                particleSystem.Stop();
                particleSystem.Clear();
                print("Cleared thrust particles");
            }
        }
    }
}
