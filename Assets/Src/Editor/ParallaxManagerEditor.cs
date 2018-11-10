using UnityEditor;

[CustomEditor(typeof(ParallaxManager))]
public class SceneLoaderEditor : Editor {

    private ParallaxManager parallaxManager;
    private SerializedObject parallaxManagerSerializedObject;
    private SerializedProperty backgroundSizeProp;
    private SerializedProperty layersProp;
    private int layersSize;

    void OnEnable() {
        this.parallaxManager = target as ParallaxManager;
        this.parallaxManagerSerializedObject = new SerializedObject(this.parallaxManager);
        this.backgroundSizeProp = this.parallaxManagerSerializedObject.FindProperty("backgroundSize");
        this.layersProp = this.parallaxManagerSerializedObject.FindProperty("layers");
        this.layersSize = this.layersProp.arraySize;
    }

    public override void OnInspectorGUI() {
        this.parallaxManagerSerializedObject.Update();

        EditorGUILayout.PropertyField(this.backgroundSizeProp);

        this.layersSize = this.layersProp.arraySize;
        this.layersSize = EditorGUILayout.DelayedIntField("Size of Layers", this.layersSize);

        EditorGUI.indentLevel++;
        if (this.layersSize != this.layersProp.arraySize) {
            while (this.layersSize > this.layersProp.arraySize) {
                this.layersProp.InsertArrayElementAtIndex(this.layersProp.arraySize);
            }
            while (this.layersSize < this.layersProp.arraySize) {
                this.layersProp.DeleteArrayElementAtIndex(this.layersProp.arraySize - 1);
            }
        }

        for (int i = 0; i < this.layersProp.arraySize; i++) {
            SerializedProperty layer = this.layersProp.GetArrayElementAtIndex(i);
            SerializedProperty speed = layer.FindPropertyRelative("speed");
            SerializedProperty offset = layer.FindPropertyRelative("offset");
            SerializedProperty elements = layer.FindPropertyRelative("elements");
            SerializedProperty foldOutProp = layer.FindPropertyRelative("foldOut");
            SerializedProperty slideProp = layer.FindPropertyRelative("slide");
            SerializedProperty loopProp = layer.FindPropertyRelative("loop");

            foldOutProp.boolValue = EditorGUILayout.Foldout(foldOutProp.boolValue, "Layer " + i);

            if (foldOutProp.boolValue) {
                speed.floatValue = EditorGUILayout.FloatField("Speed ", speed.floatValue);
                offset.floatValue = EditorGUILayout.FloatField("Offest ", offset.floatValue);
                EditorGUILayout.PropertyField(slideProp);
                EditorGUILayout.PropertyField(loopProp);

                int elementsSize = elements.arraySize;
                elementsSize = EditorGUILayout.DelayedIntField("Size of Elements", elementsSize);

                EditorGUI.indentLevel++;
                if (elementsSize != elements.arraySize) {
                    while (elementsSize > elements.arraySize) {
                        elements.InsertArrayElementAtIndex(elements.arraySize);
                    }
                    while (elementsSize < elements.arraySize) {
                        elements.DeleteArrayElementAtIndex(elements.arraySize - 1);
                    }
                }
                for (int k = 0; k < elements.arraySize; k++) {
                    elements.GetArrayElementAtIndex(k).objectReferenceValue =
                        EditorGUILayout.ObjectField("Element " + k, elements.GetArrayElementAtIndex(k).objectReferenceValue, typeof(UnityEngine.Transform), true);
                }
                EditorGUI.indentLevel--;
            }
        }
        EditorGUI.indentLevel--;

        this.parallaxManagerSerializedObject.ApplyModifiedProperties();
    }
}