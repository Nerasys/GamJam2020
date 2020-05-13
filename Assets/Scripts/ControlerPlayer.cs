﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlerPlayer : MonoBehaviour
{

    private AudioManager michel;

    // Start is called before the first frame update
    private static ControlerPlayer instance;

    DataInfo data;
    public System.Action OnRamassable;

    //Movement Information
    public float moveSpeed = 10.0f;
    public float moveBoost = 10.0f;
    public float rotateSpeed = 0.5f;


    //Controls
    public KeyCode Accelerate = KeyCode.Z;
    public KeyCode Decelerate = KeyCode.S;
    public KeyCode SteerLeft = KeyCode.Q;
    public KeyCode SteerRight = KeyCode.D;

    public KeyCode Accelerate2 = KeyCode.UpArrow;
    public KeyCode Decelerate2 = KeyCode.DownArrow;
    public KeyCode SteerLeft2 = KeyCode.LeftArrow;
    public KeyCode SteerRight2 = KeyCode.RightArrow;

    public KeyCode Boost = KeyCode.Space;
    public bool useRelativeForce = true;

    //Movement Limit

    public float limSpeedMin = -20.0f;
    public float limSpeedMax = 20.0f;

    public float timerFXboost = 2.0f;
    private float timerBoost = 0.0f;
    bool isBoosted = false;
    //Movemement 
    [SerializeField]
    public GameObject fx1Z;
    [SerializeField]
    public GameObject fx2Z;
    [SerializeField]
    public GameObject fxVitessBoost;


    Rigidbody rb;

    DataDontDestroy dtn;
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

        if(michel == null)
        {
            michel = FindObjectOfType<AudioManager>();
        }
        michel.Play("LevelBegin");
    }

    public static ControlerPlayer GetInstance()
    {
        return instance;
    }

    void Start()
    {
        dtn = DataDontDestroy.GetInstance();
        rb = gameObject.GetComponent<Rigidbody>();
        data = DataInfo.GetInstance();
    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!data.death)
        {
            OnDrive();

            OnLimit();
        }
    }

    void OnDrive()
    {
        michel.Play("BoucleRoue");
        if (Input.GetKey(Accelerate)||Input.GetKey(Accelerate2))
        {

            if (useRelativeForce)
            {
                rb.AddRelativeForce(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                rb.AddForce(gameObject.transform.forward * moveSpeed);
            }


            ParticleSystem.EmissionModule emission = fx1Z.GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
            ParticleSystem.EmissionModule emission2 = fx2Z.GetComponent<ParticleSystem>().emission;
            emission2.enabled = true;

        }
        else
        {
            ParticleSystem.EmissionModule emission = fx1Z.GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
            ParticleSystem.EmissionModule emission2 = fx2Z.GetComponent<ParticleSystem>().emission;
            emission2.enabled = false;
        }

        if (Input.GetKey(Decelerate)|| Input.GetKey(Decelerate2))
        {
            if (useRelativeForce)
            {
                rb.AddRelativeForce(-Vector3.forward * moveSpeed* Time.deltaTime);
            }
            else
            {
                rb.AddForce(-gameObject.transform.forward * moveSpeed);
            }
        }

        if (Input.GetKey(SteerLeft)||Input.GetKey(SteerLeft2))
        {

            michel.Play("BoucleThrust");
            if (useRelativeForce)
            {
                rb.AddTorque(Vector3.up * -rotateSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up * -rotateSpeed);
            }

        }


        if (Input.GetKey(SteerRight) || Input.GetKey(SteerRight2))
        {
            michel.Play("Drift");
            if (useRelativeForce)
            {
                rb.AddTorque(Vector3.up * +rotateSpeed * Time.deltaTime);

            }
            else
            {
                transform.Rotate(Vector3.up * +rotateSpeed);
            }
        }


        if (Input.GetKeyDown(Boost))
        {
            michel.Play("Drift");
            if (data.boost == data.boostMax)
            {
                if (useRelativeForce)
                {
                    rb.AddForce(gameObject.transform.forward * moveSpeed * moveBoost* Time.deltaTime);
                }
                else
                {
                    rb.AddForce(gameObject.transform.forward * moveSpeed * moveBoost);
                }
                FindObjectOfType<AudioManager>().Play("Thrust");
                data.boost = 0.0f;
                isBoosted = true;

            }
        }


        if (isBoosted)
        {

            if (timerBoost > timerFXboost)
            {
                fxVitessBoost.SetActive(false);
                isBoosted = false;
                timerBoost = 0.0f;
            }
            else
            {
                fxVitessBoost.SetActive(true);
                timerBoost += Time.deltaTime;
            }

        }

    }


    void OnLimit()
    {
        if (rb.velocity.x > limSpeedMax)
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
        if (other.gameObject.tag == "Ramassable")
        {
            michel.Play("Confirm");

            if (other.gameObject.GetComponent<Items>().isObligatoire)
            {
                for (int i = 0; i < data.canvasList.transform.GetChild(2).childCount; i++)
                {
                    if(data.canvasList.transform.GetChild(2).GetChild(i).gameObject.GetComponent<Text>().text.Contains(other.name))
                    {
                        data.canvasList.transform.GetChild(2).GetChild(i).gameObject.GetComponent<Text>().enabled = false;
                    }
                }

            }
            else
            {
                for (int i = 0; i < data.canvasList.transform.GetChild(3).childCount; i++)
                {
                    if (data.canvasList.transform.GetChild(3).GetChild(i).gameObject.GetComponent<Text>().text.Contains(other.name))
                    {
                        data.canvasList.transform.GetChild(3).GetChild(i).gameObject.GetComponent<Text>().enabled = false;
                    }
                }
            }



            dtn.score += other.GetComponent<Items>().scoreGive;
            for (int i = 0; i < data.myListItems.Count; i++)
            {
                if(data.myListItems[i].name.Contains(other.GetComponent<Items>().name))
                {
                    data.myListItems[i].GetComponent<Items>().isObligatoire = false;
                }
            }

           

            Destroy(other.gameObject);

        }
    }

}

