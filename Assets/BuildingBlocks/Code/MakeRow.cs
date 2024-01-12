using Random = System.Random;
using UnityEngine;

public class MakeRow : MonoBehaviour
{
    public bool getNarrower = false;
    public bool isBreathing = false;
    private bool hasSwitched = true;
    private bool hasSwitched2 = false;
    public float maxBreathSeconds = 1;
    public float minBreathSeconds = 1;
    Breather breather;
    public int wallWidth = 7;
    public int wallHeight = 4;
    public Transform redModel;
    public Transform ylwModel;
    Vector3 position;
    Transform cube;
    float xOffset;
    int yOffset;

    const float half = 0.5f;
    readonly static Quaternion noRotation = Quaternion.identity;

    // Objects of type Random have a public method, NextDouble, that
    // returns a random number on the interval [0,1). Call it like this:
    //
    //              (float)r.NextDouble();

    Random r = new Random();

    void Start()
    {

        // Create a Vector3 to set the position of an object with
        // the origin of the object's local space x, y, z coordinates
        // in world space passed as its arguments.

        // Create an instance of a prefab at a specific position in world
        // space, with no rotation.

        /*HOW I USED THE BREATHER: by calling the breather variable and setting it to cube after it has been instantiated, it sets that current instantiated cube with its own breather and can set its rate to a number. In this case by use the random r variable
           and calling the .NextDouble method it will allow me to set that current instantiated cube's rate to a random number on the interval [0,1) however by multiplying this random number by .5 it allows me to decrease the rate at which they breathe 
        while still ensuring I use random numbers from r. Breather originally had the form 
        */

        xOffset = (float)wallWidth / 2 - .5f;
        yOffset = wallHeight / 2;

        if (getNarrower == false && isBreathing == true)
        {
            for (int i = 0; i < wallHeight; i++)
            {
                for (int j = 0; j < wallWidth; j++)
                {
                    position = new Vector3(j - xOffset, i - yOffset, 0);
                    if (hasSwitched == true)
                    {
                       cube = Instantiate(redModel, position , noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.rate = (float)r.NextDouble() * half;
                        hasSwitched = false;
                    }
                    else
                    {
                      cube =  Instantiate(ylwModel, position , noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.rate = (float)r.NextDouble() * half;
                        hasSwitched = true;
                    }

                }
            }
        } else if (getNarrower == false)
        {
            for (int i = 0; i < wallHeight; i++)
            {
                for (int j = 0; j < wallWidth; j++)
                {
                    position = new Vector3(j - xOffset, i - yOffset, 0);
                    if (hasSwitched == true)
                    {
                        cube = Instantiate(redModel, position, noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.enabled = false;
                        hasSwitched = false;
                    }
                    else
                    {
                        cube = Instantiate(ylwModel, position, noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.enabled = false;
                        hasSwitched = true;
                    }

                }
            }
        }



        int temp = wallWidth;
        int hold = 0;
        if(getNarrower == true && isBreathing == true)
        {
            for(int i = 0; i < wallHeight; i = i + 2)
            {
                for (int j = hold; j < temp; j++)
                {
                    position = new Vector3(j - xOffset, i - yOffset, 0);
                    if (hasSwitched == true)
                    {
                        cube = Instantiate(redModel, position, noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.rate = (float)r.NextDouble() * half;
                        hasSwitched = false;
                    }
                    else
                    {
                        cube = Instantiate(ylwModel, position, noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.rate = (float)r.NextDouble() * half;
                        hasSwitched = true;
                    }
                }
                hasSwitched = true;
                temp = temp - 1;
                hold = hold + 1;
            }
        } else if (getNarrower == true)
        {
            for (int i = 0; i < wallHeight; i = i + 2)
            {
                for (int j = hold; j < temp; j++)
                {
                    position = new Vector3(j - xOffset, i - yOffset, 0);
                    if (hasSwitched == true)
                    {
                        cube = Instantiate(redModel, position, noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.enabled = false;
                        hasSwitched = false;
                    }
                    else
                    {;
                        cube = Instantiate(ylwModel, position, noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.enabled = false;
                        hasSwitched = true;
                    }
                }
                hasSwitched = true;
                temp = temp - 1;
                hold = hold + 1;
            }
        }







        float temp2 = (float)wallWidth;
        float hold2 = .5f;
        if (getNarrower == true && isBreathing == true)
        {
                for (int i = 1; i < wallHeight; i = i + 2)
                {
                    for (float j = hold2; j < temp2 -1 ; j = j + 1)
                    {
                        position = new Vector3(j - xOffset, i - yOffset, 0);
                        if (hasSwitched2 == true)
                        {
                            cube = Instantiate(redModel, position, noRotation);
                            breather = cube.GetComponent<Breather>();
                            breather.rate = (float)r.NextDouble() * half;
                            hasSwitched2 = false;
                        }
                        else
                        {
                            cube = Instantiate(ylwModel, position, noRotation);
                            breather = cube.GetComponent<Breather>();
                            breather.rate = (float)r.NextDouble() * half;
                            hasSwitched2 = true;
                        }
                    }
                    hasSwitched2 = false;
                    temp2 = temp2 - 1f;
                    hold2 = hold2 + 1f;
                
            }
        } else if (getNarrower == true)
        {
            breather.enabled = false;
            for (int i = 1; i < wallHeight; i = i + 2)
            {
                for (float j = hold2; j < temp2 - 1; j = j + 1)
                {
                    position = new Vector3(j - xOffset, i - yOffset, 0);
                    if (hasSwitched2 == true)
                    {
                        cube = Instantiate(redModel, position, noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.enabled = false;
                        hasSwitched2 = false;
                    }
                    else
                    {
                        cube = Instantiate(ylwModel, position, noRotation);
                        breather = cube.GetComponent<Breather>();
                        breather.enabled = false;
                        hasSwitched2 = true;
                    }
                }
                hasSwitched2 = false;
                temp2 = temp2 - 1f;
                hold2 = hold2 + 1f;
            }
        }

        // Get a reference to the newly created object's Breather component.

        //Breather breather = cube.GetComponent<Breather>();

        // Set the rate of breaths per second.

        //breather.rate = 0;
    }
 }





