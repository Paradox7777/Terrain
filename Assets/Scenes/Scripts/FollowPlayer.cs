using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	[SerializeField]
	public Transform playerBody;
	
	private float mouseSens = 100f;
	private float xRotation;


	private void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}
}
