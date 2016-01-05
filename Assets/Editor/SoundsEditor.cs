using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Sounds))]
public class SoundsEditor : Editor 
{
	public override void OnInspectorGUI ()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(serializedObject.FindProperty("MusicSource"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("EffectsSource"));
		Show(serializedObject.FindProperty("EffectClips"));
		serializedObject.ApplyModifiedProperties();
		
	}
	
	public void Show (SerializedProperty list) {
		EditorGUILayout.PropertyField(list);
		EditorGUI.indentLevel += 1;
		if (list.isExpanded) {
			EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
			for (int i = 0; i < list.arraySize; i++) 
			{
				GUIContent label = new GUIContent(""+((Sounds.Effect)i).ToString());
				EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i),label);
			}
		}
		EditorGUI.indentLevel -= 1;
	}
}
