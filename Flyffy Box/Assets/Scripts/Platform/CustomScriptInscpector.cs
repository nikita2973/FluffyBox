using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(PlatformMap))]
public class CustomScriptInscpector : Editor
{
    private PlatformMap _targetScript;

    private void OnEnable()
    {

        if (_targetScript == null)
            _targetScript = target as PlatformMap;
    }

    public override void OnInspectorGUI()
    {
        PlatformMap.X = EditorGUILayout.IntField(PlatformMap.X);
        PlatformMap.Y = EditorGUILayout.IntField(PlatformMap.Y);
        UpdatePlatform();
        if (GUILayout.Button("Generation"))
        {
            _targetScript.gameObject.GetComponent<LevelGenerator>().Generation();
        }
        if (GUILayout.Button("Clear"))
        {
            _targetScript.gameObject.GetComponent<LevelGenerator>().Clear();
            //_targetScript.columns = null;
            //_targetScript = null;
            //_targetScript = target as PlatformMap;
            //UpdatePlatform();
        }
    }

    private void UpdatePlatform()
    {
        EditorGUILayout.BeginHorizontal();
        for (int y = 0; y < PlatformMap.Y; y++)
        {
            Debug.Log(PlatformMap.X + "," + PlatformMap.Y);
            EditorGUILayout.BeginVertical();
            for (int x = 0; x < PlatformMap.X; x++)
            {
                try
                {
                    _targetScript.columns[x].rows[y] = EditorGUILayout.Toggle(_targetScript.columns[x].rows[y]);
                }
                catch
                {

                }
            }
            EditorGUILayout.EndVertical();

        }
        EditorGUILayout.EndHorizontal();
    }

}
