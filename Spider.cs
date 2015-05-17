using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {
	Animation anim;
	// Use this for initialization
	void Start () {
		this.anim = GetComponent<Animation> ();
		this.anim.Play ();

	}

	// Update is called once per frame
	void Update () {
		if (! this.anim.isPlaying ) {
			this.anim.Play();
		}
		transform.Translate (Vector3.forward * 2 * Time.deltaTime);
	}
}
