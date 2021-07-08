using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

//Ensures all instances of this script also contains an ARRayCastManager component
[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{

    [SerializeField]
    private GameObject placedPrefab;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject PlacedPrefab
    {
        get
        {
            return placedPrefab;
        }
        set
        {
            placedPrefab = value;
        }
    }

    private static ARRaycastManager arRayCastManager;

    void Awake()
    {
        arRayCastManager = GetComponent<ARRaycastManager>();
    }

    //Gets the touch position to check if there is collision with the plane manager
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if (arRayCastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        }
    }

    public static Pose RayCastToWorld()
    {
        Pose hitPose;
        if (arRayCastManager.Raycast(Camera.main.transform.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            return hits[0].pose;
        }

        return default;
    }
}
