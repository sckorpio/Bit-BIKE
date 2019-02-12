using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bicycle_script : MonoBehaviour
{
	public GameObject BIKE;             // game object bike
	public GameObject HANDLE;           // Handle

	

	public float speed;                 // speed ( from the rpm speed of wheel )
	public float delta_handle_angle;    // change in angle of handle

	public float start_handle_angle;
	public float init_handle_angle;
	public float abs_handle_angle;
	public float handle_limit;
	public float speed_limit;

	//-------------------------------------------------------------------------------------------------------

	public float acc;
	public float steer;


	//-------------------------------------------------------------------------------------------------------

	// Start is called before the first frame update
	void Start()
	{
		speed = 0.1f;
		init_handle_angle = HANDLE.transform.eulerAngles.y;
		start_handle_angle= init_handle_angle;

	}

	void Set_Handle_angle()
	{
		abs_handle_angle = init_handle_angle + delta_handle_angle;


		HANDLE.transform.localEulerAngles = new Vector3(HANDLE.transform.eulerAngles.x ,
			                                            abs_handle_angle,
			                                            HANDLE.transform.eulerAngles.z);

		init_handle_angle = abs_handle_angle;

	}
	/*	
	// JUST_FOR_TESTING: to test without sensor
	void get_inputs()
	{
		if (Input.GetKey(KeyCode.UpArrow))
			speed += 0.1f;
		if (Input.GetKey(KeyCode.DownArrow))
			speed -= 0.1f;

		if (Input.GetKey (KeyCode.RightArrow))
			delta_handle_angle =1;
		if (Input.GetKey(KeyCode.LeftArrow))
			delta_handle_angle = -1;


	}
	
	*/

	// Update is called once per frame
	void FixedUpdate()
	{

		// get_inputs();
		Set_Handle_angle ();

		delta_handle_angle = 0;
		BIKE.transform.Rotate (Vector3.up, ((abs_handle_angle - start_handle_angle)* speed)* Time.deltaTime);

		BIKE.transform.Translate (Vector3.forward * speed * Time.deltaTime);


	}
}
