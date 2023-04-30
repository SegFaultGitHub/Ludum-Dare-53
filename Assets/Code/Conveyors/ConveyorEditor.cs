#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Code.Conveyors {
    [CustomEditor(typeof(Conveyor)), CanEditMultipleObjects]
    public class ConveyorEditor : Editor {
        public override void OnInspectorGUI() {
            this.serializedObject.Update();

            this.DrawDefaultInspector();

            Conveyor conveyor = ((Conveyor)this.target).gameObject.GetComponent<Conveyor>();

            if (GUILayout.Button("UP")) {
                conveyor!.EditorRotate(Direction.Up);
                EditorUtility.SetDirty(conveyor);
            } else if (GUILayout.Button("DOWN")) {
                conveyor!.EditorRotate(Direction.Down);
                EditorUtility.SetDirty(conveyor);
            } else if (GUILayout.Button("LEFT")) {
                conveyor!.EditorRotate(Direction.Left);
                EditorUtility.SetDirty(conveyor);
            } else if (GUILayout.Button("RIGHT")) {
                conveyor!.EditorRotate(Direction.Right);
                EditorUtility.SetDirty(conveyor);
            }

            this.serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
