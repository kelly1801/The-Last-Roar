using UnityEngine;

[ExecuteInEditMode]
public class ChildrenRenamer : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private string newName;

    private void Rename()
    {
        int childIndex = -1;

        foreach (Transform child in parent)
        {
            childIndex++;
            child.gameObject.name = $"{newName} ({childIndex})";
        }

        Debug.Log("RENAMER END");
    }

#if UNITY_EDITOR
    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 100, 100), "RENAME"))
        {
            Rename();
        }
    }
#endif

}
