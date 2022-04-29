using UnityEngine;
using UnityEditor;

namespace ScoredProductions.ScoredsBT.Version2 {
	[CustomEditor(typeof(BTRoot))]
	public class BTRootInspector : Editor {

		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			if (GUILayout.Button("Reset Script")) {
				((BTRoot)target).Reset(); // On build, containers if unchanged need clearing if neccessary
			}
		}

	}
}