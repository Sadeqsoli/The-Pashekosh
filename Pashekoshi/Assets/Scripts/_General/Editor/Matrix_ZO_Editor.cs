using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(Matrix_ZO))]
public class Matrix_ZO_Editor : PropertyDrawer
{ 
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);
        Rect newposition = position;
        newposition.y += 20f;
        SerializedProperty data = property.FindPropertyRelative("rows_ZO");
        for (int j = 0; j < 14; j++)
        {
            SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row_ZO");
            newposition.height = 20f;
            if (row.arraySize != 14)
                row.arraySize = 14;
            newposition.width = position.width / 14;
            for (int i = 0; i < 14; i++)
            {
                EditorGUI.PropertyField(newposition, row.GetArrayElementAtIndex(i), GUIContent.none);
                newposition.x += newposition.width;
            }

            newposition.x = position.x;
            newposition.y += 20f;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 18f;
    }
}//EndClassss/SadeQ
