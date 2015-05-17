using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public GameObject LaserObj;
	public GameObject Spider;

//	public GameObject AttackableSpider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			LaserObj.GetComponent<Laser> ().Fire (Camera.main.gameObject, this.Spider);
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			LaserObj.GetComponent<Laser> ().Fire (Camera.main.gameObject, this.Spider, Laser.CurveType.Cubic);
		}
	}
}
