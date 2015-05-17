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

		Vector3 handlePos = 
			this.transform.position + 
				Vector3.up * 1.0f + 
					Vector3.forward * 2.0f + 
						Vector3.right * - 3.0f;

		Vector3 lastPos = 
			targetObj.transform.position + 
				Vector3.up * 1.0f + 
					Vector3.back * 2.0f + 
						Vector3.right * - 3.0f;

		switch ( curveType ) {
		case CurveType.Quadratic:
			StartCoroutine (
				QuadraticBezier.Calc (
					beginTrans: this.transform,
					handleWorldPos: handlePos,
					endTrans: targetObj.transform,
					speed: 0.5f
				)
			);
			break;
		case CurveType.Cubic:
			StartCoroutine (
				CubicBezier.Calc (
				beginTrans: this.transform,
				firstHandle: handlePos,
				lastHandle: lastPos,
				endTrans: targetObj.transform,
				speed: 0.5f
				)
			);
			break;
		}
	}

}
