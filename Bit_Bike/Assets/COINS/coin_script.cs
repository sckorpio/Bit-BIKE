using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_script : MonoBehaviour
{
	public manager MAN;
	
     
	// Start is called before the first frame update
	

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.right * 10); 
	}
	private void OnTriggerEnter(Collider other)
	{
		//if(other.name=="Player")
		{
			MAN.collect();
		
			Debug.Log("coin collected");
			Destroy(gameObject);

		}
	}
}