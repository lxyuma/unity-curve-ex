using UnityEngine;
using System.Collections;

public static class CubicBezier {

	public static IEnumerator Calc (Transform beginTrans, Vector3 firstHandleLocalPos, Vector3 lastHandleLocalPos, Transform endTrans, float speed = 1.0f) {
		float ratio = 0.0f;
		do {
			beginTrans.position = CalcPos ( beginTrans.position,
			                                beginTrans.position + firstHandleLocalPos,
			                                endTrans.position + lastHandleLocalPos,
			                                endTrans.position,
			                                ratio );
			yield return new WaitForEndOfFrame();
			ratio += Time.deltaTime * speed;
		} while ( ratio < 1.0f );
	}

	private static Vector3 CalcPos ( Vector3 beginPos, Vector3 firstHandlePos, Vector3 lastHandlePos, Vector3 endPos, float ratio) {
		return new Vector3 (
			CalcPosInAxis (beginPos.x, firstHandlePos.x, lastHandlePos.x, endPos.x, ratio),
			CalcPosInAxis (beginPos.y, firstHandlePos.y, lastHandlePos.y, endPos.y, ratio),
			CalcPosInAxis (beginPos.z, firstHandlePos.z, lastHandlePos.z, endPos.z, ratio)
			);
	}
	
	private static float CalcPosInAxis ( float begin, float firstHandle, float lastHandle, float end, float ratio ) {
		return Mathf.Pow (1 - ratio, 3) * begin +
				3 * Mathf.Pow (1 - ratio, 2) * ratio * firstHandle +
				3 * (1 - ratio) * Mathf.Pow (ratio, 2) * lastHandle +
				Mathf.Pow (ratio, 3) * end;
	}

}
