using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]

public class RoomObject : MonoBehaviour, IPointerClickHandler
{
    public bool moved { get; private set; }

    [Header("Position when clicked")]
    Vector2 pos1;
    [SerializeField] Vector2 pos2;
    private void Start()
    {
        pos1 = transform.position;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        moved = !moved;
        transform.position = moved ? pos2 : pos1;
    }
    void OnDrawGizmos()
    {
        // Blue
        Gizmos.color = new Color(0.0f, 0.0f, 1.0f);
        DrawRect(transform.position);
        DrawRect(pos2);
    }

    void OnDrawGizmosSelected()
    {
        // Red
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
        DrawRect(transform.position);
        DrawRect(pos2);
    }
    void DrawRect(Vector2 pos)
    {
        Gizmos.DrawWireCube(new Vector3(pos.x, pos.y, 0.01f), new Vector3(1f, 1f, 0.01f));
    }
}
