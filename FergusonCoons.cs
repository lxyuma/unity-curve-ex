using UnityEngine;
using System.Collections;

public static class FergusonCoons {

	public static IEnumerator Calc ( Transform beginTrans, Transform endTrans, Vector3 firstVelocity, Vector3 lastVelocity, float speed = 1.0f ) {
		float ratio = 0;
		do {
			beginTrans.position = CalcPos (beginTrans.position, endTrans.position, firstVelocity, lastVelocity, ratio);
			yield return new WaitForEndOfFrame ();
			ratio += Time.deltaTime * speed;
		} while (ratio < 1.0f);
	}

	private static Vector3 CalcPos ( Vector3 beginPos, Vector3 endPos, Vector3 firstVelocity, Vector3 lastVelocity, float ratio) {
		return new Vector3 (
			CalcPosInAxis (beginPos.x, endPos.x, firstVelocity.x, lastVelocity.x, ratio),
			CalcPosInAxis (beginPos.y, endPos.y, firstVelocity.y, lastVelocity.y, ratio),
			CalcPosInAxis (beginPos.z, endPos.z, firstVelocity.z, lastVelocity.z, ratio)
		);
	}
	
	private static float CalcPosInAxis ( float begin, float end, float firstVelocity, float lastVelocity, float ratio ) {
		return ( 2 * begin - 2 * end + firstVelocity + lastVelocity) * Mathf.Pow (ratio, 3) +
				(- 3 * begin + 3 * end - 2 * firstVelocity - lastVelocity) * Mathf.Pow (ratio, 2) +
				firstVelocity * ratio +
				begin;
	}

}
