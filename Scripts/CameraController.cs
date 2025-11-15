using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player1 != null && player2 != null)
        {
            Vector3 centerPoint = (player1.position + player2.position) / 2;
            Vector3 desiredPosition = centerPoint + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(centerPoint);
        }
    }
}
