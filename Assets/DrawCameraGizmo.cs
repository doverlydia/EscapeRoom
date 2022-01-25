using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCameraGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Green
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f);
        DrawRect();
    }

    void OnDrawGizmosSelected()
    {
        // Orange
        Gizmos.color = new Color(1.0f, 0.5f, 0.0f);
        DrawRect();
    }

    void DrawRect()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, 0.01f), new Vector3(Camera.main.aspect * 2f * Camera.main.orthographicSize, 2f * Camera.main.orthographicSize, 0.01f));
    }
}
