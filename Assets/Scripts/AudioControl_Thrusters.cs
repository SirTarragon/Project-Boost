using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl_Thrusters : MonoBehaviour
{
    private AudioSource[] sounds;
    private AudioSource rocketThruster;
    private AudioSource rcsThruster;

    private Rocket rocket;
    private double fuelValue;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        rocketThruster = sounds[0];
        rcsThruster = sounds[1];

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

                if (!rocketThruster.isPlaying) //So that the audio doesn't layer
                {
                    rocketThruster.Play();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                print("Stopping Thrust sound");
                rocketThruster.Stop();
            }

            //Rocket turning
            if (Input.GetKey(KeyCode.A))
            {
                //Update fuelValue
                fuelValue = rocket.getFuelValue();
                if (!rcsThruster.isPlaying)
                {
                    rcsThruster.Play();
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //Update fuelValue
                fuelValue = rocket.getFuelValue();
                if (!rcsThruster.isPlaying)
                {
                    rcsThruster.Play();
                }
            }
            else if(!(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
            {
                rcsThruster.Stop();
            }
        }
        else
        {
            //Stop audio if still running
            rocketThruster.Stop();
            rcsThruster.Stop();
        }
    }
}
