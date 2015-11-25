using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(ZoneDescriptor))]
public class ZoneDrawer : PropertyDrawer
{
		
	// Draw the property inside the given rect
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) 
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty (position, label, property);
			
		// Draw label
		position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
			
		// Don't make child fields be indented
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
			
		// Calculate rects
		Rect segmentRect = new Rect (position.x, position.y, 100, position.height);
		Rect startFloorRect = new Rect (position.x+105, position.y, 33, position.height);
			
		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField (segmentRect, property.FindPropertyRelative ("Segment"), GUIContent.none);
		EditorGUI.PropertyField (startFloorRect, property.FindPropertyRelative ("StartFloor"), GUIContent.none);
			
		// Set indent back to what it was
		EditorGUI.indentLevel = indent;
			
		EditorGUI.EndProperty ();
	}
}
