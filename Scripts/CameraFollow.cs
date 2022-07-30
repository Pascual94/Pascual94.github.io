using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject   follow;
    public Vector2      minCamPos, maxCamPos;
    public float        smoothTime;
    public bool         drch;

    Vector2 velocity;
    void FixedUpdate()
    {

        if (drch)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x +7, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

            transform.position = new Vector3(
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
                transform.position.z);
        }
        else
        {
            float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x -7, ref velocity.x, smoothTime);
            float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

            transform.position = new Vector3(
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
                transform.position.z);
        }
    }
}