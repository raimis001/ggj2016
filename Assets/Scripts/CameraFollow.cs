using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform PlayerTransform = null;
	PlayerController Player;
	SimpleController InputController;
	Mountain Mountain;

	Vector3 LookTarget;
	bool LookTargetAssigned = false;

	// Use this for initialization
	void Start ()
	{
		Player = PlayerController.Instance;
		InputController = SimpleController.Instance;
		Mountain = Mountain.Instance;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (!LookTargetAssigned)
		{
			LookTarget = PlayerTransform.position;
			LookTargetAssigned = true;
		}
		Vector3 targetPosition = PlayerTransform.position;
		float zDiff = (Mountain.Konfigurācija.Rindas - InputController.ActiveCube.Row - 1);
		if (zDiff <= 2f)
		{
			targetPosition.y += 2f - zDiff;
		}
		else
		{
			targetPosition.y -= 2f;
		}
		if (LookTarget != targetPosition)
		{
			Vector3 diff = targetPosition - LookTarget;
			diff /= 10f;
			diff = diff.normalized * Mathf.Min(diff.magnitude, 1f);
			LookTarget += diff;
		}
		transform.LookAt(LookTarget, Vector3.up);
	}
}
