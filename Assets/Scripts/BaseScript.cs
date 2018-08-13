using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{

    // Awake is used to initialize any variables before the game starts
    // Called after all objects are initialized so you can safely
    // communicate with other objects
    //
    void Awake()
    {

    }

    // Whenever an object is created, the OnEnable method is called.
    // This is the same for when an objectis activated in the UI
    void OnEnable()
    {
        
    }

    // Start is called when a script is enabled. If you need
    // to make sure something is initialized put it in awake.
    //
    void Start()
    {

    }

    // Update is called once per frame. Do not put physics stuff here,
    // but all computations should use Time.deltaTime
    //
    void Update()
    {

    }

    // Called multiple times per frame depending on the frame rate
    // locked in sync with the physics engine so physics manipulation
    // should take place here - particularly with RigidBodies
    //
    void FixedUpdate()
    {

    }

    // Called after all the Update functions for all scripts have been called.
    // Use this only if you are trying to track a behavior after everything
    // in the scene has updated. Useful for camera manipulation
    // or tracking of gameobjects that have moved this frame
    void LateUpdate()
    {

    }
}