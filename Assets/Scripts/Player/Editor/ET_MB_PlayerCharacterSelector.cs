using UnityEngine;
using UnityEditor;


namespace Player
{
    [CustomEditor(typeof(MB_PlayerCharacterSelector))]
    public class ET_MB_PlayerCharacterSelector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            MB_PlayerCharacterSelector playerCharacterSelector = (MB_PlayerCharacterSelector)target;

            if (GUILayout.Button("Select Character"))
            {
                playerCharacterSelector.SelectCharacter();
            }

            serializedObject.Update();
            serializedObject.ApplyModifiedProperties();
        }

        public void OnSceneGUI()
        {
            EditorGUI.BeginChangeCheck();
            if (EditorGUI.EndChangeCheck())
            {

            }
        }
    }
}