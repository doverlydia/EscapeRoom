using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

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
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 worldMousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (worldMousepos.x < Camera.main.transform.position.x)
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

    void OnDrawGizmos()
    {
        // Blue
        Gizmos.color = new Color(0.0f, 0.0f, 1.0f);
        DrawRect(Camera.main.ScreenToWorldPoint(Input.mousePosition), 3);
    }
    void DrawRect(Vector2 pos, float radius)
    {
        Gizmos.DrawWireCube(new Vector3(pos.x, pos.y, 0.01f), new Vector3(radius, radius, 0.01f));
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
