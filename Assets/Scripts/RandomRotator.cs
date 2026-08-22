using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class RandomYRotation : MonoBehaviour
{
    [SerializeField] private List<Transform> objects = new();

    [ContextMenu("Randomize Y Rotation")]
    public void RandomizeRotations()
    {
#if UNITY_EDITOR
        foreach (Transform obj in objects)
        {
            if (obj == null)
                continue;

            Undo.RecordObject(obj, "Randomize Y Rotation");

            Vector3 rotation = obj.localEulerAngles;
            rotation.y = Random.Range(0f, 360f);

            obj.localEulerAngles = rotation;

            EditorUtility.SetDirty(obj);
        }

        EditorSceneManager.MarkSceneDirty(gameObject.scene);
#endif
    }
}