using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxRangeX;
    [SerializeField] private float maxRangeY;

    private Vector3 velocity = Vector3.zero;
    private Vector3 left, right, top, bottom;
    Camera camera;


    private float halfPartW;
    private float halfPartH;


    private void Start() {
        camera = GetComponent<Camera>();

        left = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
        right = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));
        top = camera.ViewportToWorldPoint(new Vector3(0.5f, 1, camera.nearClipPlane));
        bottom = camera.ViewportToWorldPoint(new Vector3(0.5f, 0, camera.nearClipPlane));
        halfPartW = Vector3.Distance(transform.position, left);
        halfPartH = Vector3.Distance(transform.position, top);

        maxRangeX = GamePlayConfig.borderW / 2;
        maxRangeY = GamePlayConfig.borderH / 2;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        newPosition.z = -10;
        newPosition.x = Mathf.Clamp(newPosition.x, -(maxRangeX - halfPartW), (maxRangeX - halfPartW));
        newPosition.y = Mathf.Clamp(newPosition.y, -(maxRangeY - halfPartH), (maxRangeY - halfPartH));
        transform.position = newPosition;
    }

    void OnDrawGizmosSelected() {
        camera = GetComponent<Camera>();

        left = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
        right = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));
        top = camera.ViewportToWorldPoint(new Vector3(0.5f, 1, camera.nearClipPlane));
        bottom = camera.ViewportToWorldPoint(new Vector3(0.5f, 0, camera.nearClipPlane));

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(left, 0.5F);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(right, 0.5F);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(top, 0.5F);

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(bottom, 0.5F);
    }
}
