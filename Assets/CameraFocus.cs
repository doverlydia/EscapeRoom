using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] List<Transform> allCameraLocations;
    int currentLocation = 0;
    public void PlusLocation()
    {
        currentLocation++;
        if (currentLocation > allCameraLocations.Count - 1)
        {
            currentLocation = 0;
        }
    }
    public void MinusLocation()
    {
        currentLocation--;
        if (currentLocation < 0)
        {
            currentLocation = allCameraLocations.Count - 1;
        }
    }
    public void CreateNew()
    {
        GameObject focalPointObj = new GameObject();
        focalPointObj.AddComponent<DrawCameraGizmo>();
        focalPointObj.name = "new focal point";
        Transform t = focalPointObj.transform;
        allCameraLocations.Add(t);
    }

    private void Start()
    {
        Camera.main.transform.position = new Vector3(allCameraLocations[currentLocation].position.x, allCameraLocations[currentLocation].position.y, Camera.main.transform.position.z);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float worldMouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            if (worldMouseX < Camera.main.transform.position.x)
            {
                PlusLocation();
            }
            else
            {
                MinusLocation();
            }
            Camera.main.transform.position = new Vector3(allCameraLocations[currentLocation].position.x, allCameraLocations[currentLocation].position.y, Camera.main.transform.position.z);
        }
    }
}

[CustomEditor(typeof(CameraFocus))]
public class CameraFocalGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CameraFocus focalPoint = (CameraFocus)target;
        if (GUILayout.Button("add"))
        {
            focalPoint.CreateNew();
        }
    }
}
