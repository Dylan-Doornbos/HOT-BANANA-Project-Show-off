using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
    private Tool lastTool = Tool.None;

    private void OnSceneGUI()
    {
        Path path = target as Path;

        for (int i = 0; i < path.waypoints.Length; i++)
        {
            Undo.RecordObject(target, "Moved object");
            path.waypoints[i] = Handles.DoPositionHandle(path.waypoints[i], Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        lastTool = Tools.current;
        Tools.current = Tool.None;
    }

    private void OnDisable()
    {
        Tools.current = lastTool;
    }
}
