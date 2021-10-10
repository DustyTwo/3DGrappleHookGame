using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    [SerializeField] Transform grappleGunTip;
    LineRenderer lineRenderer;
    Vector3 currentGrappleHitPosition;
    bool grappled;
    Transform cameraTransform;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        transform.rotation = cameraTransform.rotation;
    }

    private void LateUpdate()
    {
        if (grappled)
        {
            lineRenderer.SetPosition(0, grappleGunTip.position);
            lineRenderer.SetPosition(1, currentGrappleHitPosition);
        }
    }

    public void EnableGrapple(Vector3 grappleHitPosition)
    {
        grappled = true;
        lineRenderer.enabled = true;
        currentGrappleHitPosition = grappleHitPosition;



    }
    public void DisableGrapple()
    {
        grappled = false;
        lineRenderer.enabled = false;
    }
}
