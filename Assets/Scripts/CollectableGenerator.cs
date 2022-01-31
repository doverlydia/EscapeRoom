using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CreateNewCollectable))]
public class CollectableGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CreateNewCollectable collactable = (CreateNewCollectable)target;
        if(GUILayout.Button("Generate Collectable"))
        {
            collactable.CreateNew();
        }
    }
}
