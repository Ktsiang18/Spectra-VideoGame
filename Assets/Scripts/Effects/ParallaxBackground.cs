using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	public Transform[] parallaxLayers;				// Array of the backgrounds and foregrounds to parallax
	public float parallaxSmoothing = 1f;			// how smooth should the parallax be
	public Transform cam;							// transform of the camera

	private float[] parallaxScales;					// The scale of the cameras movement to impacts the backgrounds by
	private Vector3 previousCameraPosition;			// where the camera was last frame


	void Awake()
	{
	}

	// Use this for initialization
	void Start () 
	{
		previousCameraPosition = cam.position;


		parallaxScales = new float[parallaxLayers.Length];

		// go through each background and assign its scale to its z position
		//
		for (int i = 0; i < parallaxLayers.Length; i++) 
		{
			parallaxScales [i] = parallaxLayers[i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < parallaxLayers.Length; i++) 
		{
			// the parallax effect is equal to the amount the camera has moved 
			// multiplied by its scale (which is its z distance from the camera)
			float parallax = (previousCameraPosition.x - cam.position.x) * parallaxScales [i];	
		
			// the new X position of the layer is equal to the current position of the layer 
			// added to the parallax value computed above
			float layerXPosition = parallaxLayers [i].position.x + parallax;

			Vector3 newLayerPosition = new Vector3 (layerXPosition, parallaxLayers [i].position.y, parallaxLayers [i].position.z);

			// smoothly interpolate between the old layer position and the new layer position
			parallaxLayers[i].position = Vector3.Lerp( parallaxLayers[i].position, newLayerPosition, parallaxSmoothing * Time.deltaTime );
		}

		// store the previous camera position so we have it next time
		//
		previousCameraPosition = cam.position;
	}
}
