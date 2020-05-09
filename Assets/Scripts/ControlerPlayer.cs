using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private static ControlerPlayer instance;

    DataInfo data;
    public System.Action OnRamassable;

    //Movement Information
    public float moveSpeed = 10.0f;
    public float moveBoost = 10.0f;
    public float rotateSpeed  = 0.5f;


    //Controls
    public KeyCode Accelerate = KeyCode.Z;
    public KeyCode Decelerate = KeyCode.S;
    public KeyCode SteerLeft = KeyCode.Q;
    public KeyCode SteerRight = KeyCode.D;
    public KeyCode Boost = KeyCode.Space;

    //Movement Limit

    public float limSpeedMin = -20.0f;
    public float limSpeedMax = 20.0f;



    Rigidbody rb;

    // Use this for initialization


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static ControlerPlayer GetInstance()
    {
        return instance;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        data = DataInfo.GetInstance();
    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        OnDrive();
        OnLimit();
    }

    void OnDrive()
    {
        if (Input.GetKey(Accelerate))
        {
            rb.AddForce(gameObject.transform.forward * moveSpeed);
        }

        if (Input.GetKey(Decelerate))
        {
            rb.AddForce(-gameObject.transform.forward * moveSpeed);
        }


        if (Input.GetKey(SteerLeft))
        {
            transform.Rotate(Vector3.up * -rotateSpeed);
        }


        if (Input.GetKey(SteerRight))
        {
            transform.Rotate(Vector3.up * +rotateSpeed);
        }


        if (Input.GetKeyDown(Boost))
        {
            if (data.boost == data.boostMax)
            {
                rb.AddForce(gameObject.transform.forward * moveSpeed * moveBoost);
                data.boost = 0.0f;

            }
        }
    }


    void OnLimit()
    {
        if(rb.velocity.x > limSpeedMax)
        {
            rb.velocity = new Vector3(limSpeedMax, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.x < limSpeedMin)
        {
            rb.velocity = new Vector3(limSpeedMin, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.z > limSpeedMax)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, limSpeedMax);
        }
        if (rb.velocity.z < limSpeedMin)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, limSpeedMin);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ramassable")
        {
            Ramassable();
        }
    }


    [ContextMenu("Ramassable")]
    void Ramassable()
    {
        OnRamassable();
    }
}

