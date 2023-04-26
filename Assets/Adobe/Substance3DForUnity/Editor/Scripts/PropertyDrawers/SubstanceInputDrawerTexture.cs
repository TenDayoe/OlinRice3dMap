using Adobe.Substance;
using UnityEditor;
using UnityEngine;

namespace Adobe.SubstanceEditor
{
    internal static class SubstanceInputDrawerTexture
    {
        public static bool DrawInput(SerializedProperty valueProperty, SubstanceInputGUIContent content, SubstanceNativeGraph handler, int inputID)
        {
            Texture2D newValue;
            bool changed;

            switch (content.Description.WidgetType)
            {
                default:
                    changed = DrawDefault(valueProperty, content, out newValue);
                    break;
            }

            if (changed)
            {
                if (newValue != null)
                {
                    var pixels = newValue.GetPixels32();
                    handler.SetInputTexture2D(inputID, pixels, newValue.width, newValue.height);
                }
                else
                {
                    handler.SetInputTexture2DNull(inputID);
                }
            }

            return changed;
        }

        private static bool DrawDefault(SerializedProperty valueProperty, SubstanceInputGUIContent content, out Texture2D newValue)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.ObjectField(valueProperty, content);
            var changed = EditorGUI.EndChangeCheck();
            newValue = null;

            if (changed)
            {
                if (valueProperty.objectReferenceValue != null)
                {
                    newValue = valueProperty.objectReferenceValue as Texture2D;

                    if (newValue != null)
                    {
                        if (!newValue.isReadable)
                            TextureUtils.SetReadableFlag(newValue, true);
                    }
                }
            }

            return changed;
        }
    }
}