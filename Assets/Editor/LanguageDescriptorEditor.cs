using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LanguageDescriptor))]
public class LanguageDescriptorEditor : Editor 
{
	public override void OnInspectorGUI ()
	{
		serializedObject.Update();
		Show(serializedObject.FindProperty("Phrases"));
		serializedObject.ApplyModifiedProperties();

	}

	public void Show (SerializedProperty list) {
		EditorGUILayout.PropertyField(list);
		EditorGUI.indentLevel += 1;
		if (list.isExpanded) {
			EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
			for (int i = 0; i < list.arraySize; i++) 
			{
				GUIContent label = new GUIContent(""+((LanguageDescriptor.PhraseKey)i).ToString());
				EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i),label);
			}
		}
		EditorGUI.indentLevel -= 1;
	}

}




