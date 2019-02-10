using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class bicycle_sensor : MonoBehaviour 
{
	public float abs_speed;
	public float abs_angle;

		public int speed;
		public int angle;
	    
	public int max_speed;
	public int max_angle;

	public bicycle_script BICYCLE;

		SerialPort serial= new SerialPort("/dev/ttyUSB0",115200);
		
	    // Use this for initialization
		void Start () 
	    {
		  speed = 0;
		  angle = 0;

	    }

	// just for checking from keyboard
	/*void get_inputs()
	{
		if (Input.GetKey(KeyCode.UpArrow))
			speed += 1;
		if (Input.GetKey(KeyCode.DownArrow))
			speed -= 1;

		if (Input.GetKey (KeyCode.RightArrow))
			angle += 4;
		if (Input.GetKey (KeyCode.LeftArrow))
			angle -= 4;


	}*/

	void read_from_sensors()
	{
		
			if (!serial.IsOpen)
				serial.Open();

			string data = (serial.ReadLine());
			//Debug.Log(data);
			string[] values = data.Split(',');
			string x = values[0];
			string y = values[1];

			angle = Convert.ToInt32(x);
			speed = Convert.ToInt32(y);

			//TODO: Do some normalization on speed and angle

			//   get_inputs ();

			abs_speed = ((float) speed / 10);
			abs_angle = angle / 10;

//		if (abs_angle > max_angle)            // limiting angle
//			abs_angle = max_angle;
//		else if (abs_angle < -max_angle)
//			abs_angle = -max_angle;

			if (abs_speed > max_angle)
				abs_speed = max_speed;
			else if (abs_speed < -max_speed)
				abs_speed = -max_speed;
			
			Debug.Log("speed="+abs_speed+"  angle="+abs_angle);

		
	}
	   

		// Update is called once per frame
		void FixedUpdate () 
		{
		   	read_from_sensors();
		   

		BICYCLE.delta_handle_angle = abs_angle;
		BICYCLE.speed = abs_speed/100;
		//BICYCLE.speed = abs_speed;


		}
	}

