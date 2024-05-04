using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBikeController : MonoBehaviour
{
    float moveInput, steerInput;
    public float maxSpeed, acceleration, steerStrength, timeOnBike;

    public Rigidbody sphereRB, BikeBody;
    public GetOnGoldBike getOnGoldBike;
    public GameObject Bike;
    public MoneyCounter moneyCounter;

    private Quaternion initialLocalRotation;
    private bool isOnCar = false;
    private bool rotationApplied = false;
    // public GameObject carModel;

    // Start is called before the first frame update
    void Start()
    {
        //sphereRB.transform.parent = null;
        //BikeBody.transform.parent = null;
        sphereRB.GetComponent<Renderer>().enabled = false;
        initialLocalRotation = BikeBody.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (getOnGoldBike.currentlyOn)
        {
            timeOnBike += Time.deltaTime;
            sphereRB.transform.parent = null;
            BikeBody.transform.parent = null;
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
            transform.position = sphereRB.transform.position;
            /* if (BikeBody.transform.parent == null && !rotationApplied)
                 {
                     BikeBody.transform.localRotation = initialLocalRotation; // Only rotate the bike body
                     rotationApplied = true;
                 Debug.Log("HOO");
                 }
             if(rotationApplied)*/
            BikeBody.MoveRotation(transform.rotation);
            if (timeOnBike >= 10f)
            {
                moneyCounter.addMoney();
                timeOnBike = 0f;
            }
        }
        else if (!getOnGoldBike.currentlyOn)
        {
            Debug.Log("adad");
            timeOnBike = 0f;
            sphereRB.transform.parent = Bike.transform;
            BikeBody.transform.parent = Bike.transform;
            sphereRB.velocity = Vector3.zero;
            sphereRB.angularVelocity = Vector3.zero;

            BikeBody.velocity = Vector3.zero;
            BikeBody.angularVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        Movement();
        Rotation();
    }
    void Movement()
    {
        sphereRB.velocity = Vector3.Lerp(sphereRB.velocity, moveInput * maxSpeed * transform.forward, Time.fixedDeltaTime * acceleration);
    }

    void Rotation()
    {
        transform.Rotate(0, steerInput * moveInput * steerStrength * Time.fixedDeltaTime, 0, Space.World);
    }
}
