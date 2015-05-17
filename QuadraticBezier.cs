using UnityEngine;
using System.Collections;

public static class QuadraticBezier {

	public static IEnumerator Calc ( Transform beginTrans, Vector3 handleLocalPos, Transform endTrans, float speed = 1.0f) {
		float ratio = 0.0f;

		Vector3 handlePosAtFirst = handleLocalPos + beginTrans.position;
		Vector3 endPosAtFirst = endTrans.position;

		do {
			beginTrans.position = CalcPos ( beginTrans.position,
			                                handleLocalPos + beginTrans.position,
			                                endTrans.position,
			                                ratio);
			yield return new WaitForEndOfFrame();
			ratio += Time.deltaTime * speed;
		} while ( ratio < 1.0f );
	}

	private static Vector3 CalcPos ( Vector3 beginPos, Vector3 handlePos, Vector3 endPos, float ratio) {
		return new Vector3 (
			CalcPosInAxis (beginPos.x, handlePos.x, endPos.x, ratio),
			CalcPosInAxis (beginPos.y, handlePos.y, endPos.y, ratio),
			CalcPosInAxis (beginPos.z, handlePos.z, endPos.z, ratio)
		);
	}

	private static float CalcPosInAxis ( float begin, float handle, float end, float ratio ) {
		return  Mathf.Pow (1 - ratio, 2) * begin +
				2 * (1 - ratio) * ratio  * handle +
				Mathf.Pow (ratio, 2)     * end;
	}
}
