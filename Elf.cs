using UnityEngine;
using System.Collections;

public class Elf : MonoBehaviour {

	Locomotion loco;


	// Use this for initialization
	void Start () {
		this.loco = new Locomotion (GetComponent<Animator> ());
		this.loco.Do (100.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
