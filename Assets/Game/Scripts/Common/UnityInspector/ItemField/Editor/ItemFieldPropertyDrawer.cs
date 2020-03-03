
using UnityEditor;
using UnityEngine;

namespace GameSystem.Common.UnityInspector.Editor {
    [CustomPropertyDrawer(typeof(ItemFieldAttribute))]
    public class ItemFieldPropertyDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            bool isInteger = property.propertyType == SerializedPropertyType.Integer;

            if(isInteger) {
                //EditorGUI.BeginChangeCheck();

                //int selectedValue = property.intValue;

                //GUIContent[] contents = new GUIContent[ItemDatabase.GetCount() + 1];
                //contents[0] = new GUIContent("None", "None");
                //int[] optionsValue = new int[ItemDatabase.GetCount() + 1];
                //optionsValue[0] = ItemDatabase.NoneId;

                //int index = 1;
                //foreach (IItem item in ItemDatabase.GetAllItem()) {
                //    string name = $"{item.Name} (ID: {item.Id})";
                //    contents[index] = new GUIContent(name);
                //    optionsValue[index] = item.Id;
                //    index++;
                //}

                //selectedValue = EditorGUI.IntPopup(position, label, selectedValue, contents, optionsValue);

                //if (EditorGUI.EndChangeCheck()) {
                //    property.intValue = selectedValue;
                //}
            }
            else {
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}