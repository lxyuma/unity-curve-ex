using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public enum CurveType {
		Quadratic,
		Cubic,
		CatmullRom
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Fire ( GameObject beginObj, GameObject targetObj, CurveType curveType = CurveType.Quadratic ) {
		this.transform.position = beginObj.transform.position + Vector3.forward;

		Vector3 firstHandleLocalPos = Vector3.up * 1.0f + 
			Vector3.forward * 4.0f + 
			Vector3.right * - 3.0f;

		Vector3 firstHandleWorldPos = firstHandleLocalPos + beginObj.transform.position;

		Vector3 lastHandleLocalPos = Vector3.up * 1.0f + 
			Vector3.back * 2.0f + 
				Vector3.right * - 3.0f;

		Vector3 lastHandleWorldPos = lastHandleLocalPos + targetObj.transform.position;

		switch ( curveType ) {
		case CurveType.Quadratic:
			Debug.Log("Quad");
			StartCoroutine (
				QuadraticBezier.Calc (
					beginTrans: this.transform,
					handleLocalPos: firstHandleLocalPos,
					endTrans: targetObj.transform,
					speed: 0.5f
				)
			);
			break;
		case CurveType.Cubic:
			Debug.Log("Cubic");

			StartCoroutine (
				CubicBezier.Calc (
				beginTrans: this.transform,
				firstHandleLocalPos: firstHandleLocalPos,
				lastHandleLocalPos: lastHandleLocalPos,
				endTrans: targetObj.transform,
				speed: 0.5f
				)
			);
			break;
		}
	}

}
