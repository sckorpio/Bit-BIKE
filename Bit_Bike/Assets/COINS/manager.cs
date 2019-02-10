using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
	public int points = 0;
	public GameObject SOUND;
	public Text T;
	public AudioSource A;
	// Use this for initialization
	void Start ()
	{
		A = SOUND.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void collect()
	{
		points++;
		A.Play();
	}

	private void OnGUI()
	{
		//GUI.Label(new Rect(20,20,200,40), "Score : " + points );
		T.text = points.ToString();
	}
}
