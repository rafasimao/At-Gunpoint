using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(MapPooledObject))]
public class MapPooledObjectDrawer : PropertyDrawer 
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
		Rect prefabRect = new Rect (position.x-15, position.y, 115, position.height);
		Rect quantityRect = new Rect (position.x+105, position.y, 33, position.height);
		
		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField (prefabRect, property.FindPropertyRelative ("ObjectPrefab"), GUIContent.none);
		EditorGUI.PropertyField (quantityRect, property.FindPropertyRelative ("InitialQuantity"), GUIContent.none);
		
		// Set indent back to what it was
		EditorGUI.indentLevel = indent;
		
		EditorGUI.EndProperty ();
	}
}
