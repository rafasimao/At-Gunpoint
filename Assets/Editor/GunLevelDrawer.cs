using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(GunLevel))]
public class GunLevelDrawer : PropertyDrawer
{
	// Draw the property inside the given rect
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) 
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty (position, label, property);
		
		// Draw label
		label.text = ""+label.text[label.text.Length-1];
		position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
		
		// Don't make child fields be indented
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
		
		// Calculate rects
		Rect delayLabelRect = new Rect (position.x, position.y, 20, position.height);
		Rect delayRect = new Rect (position.x+20, position.y, 40, position.height);
		Rect dmgLabelRect = new Rect (position.x+65, position.y, 30, position.height);
		Rect dmgRect = new Rect (position.x+95, position.y, 30, position.height);
		
		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.LabelField (delayLabelRect, "FD");
		EditorGUI.PropertyField (delayRect, property.FindPropertyRelative ("FireDelay"), GUIContent.none);
		EditorGUI.LabelField (dmgLabelRect, "DMG");
		EditorGUI.PropertyField (dmgRect, property.FindPropertyRelative ("BulletDamage"), GUIContent.none);
		
		// Set indent back to what it was
		EditorGUI.indentLevel = indent;
		
		EditorGUI.EndProperty ();
	}
}
