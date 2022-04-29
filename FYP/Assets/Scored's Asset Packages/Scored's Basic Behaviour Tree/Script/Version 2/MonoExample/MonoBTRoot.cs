using System.Collections.Generic;
using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	[ExecuteInEditMode]
	public class MonoBTRoot : MonoBehaviour {

		public bool Running = false; // Value exposed to the inspector
		
		private bool LoadedOperation = false; // Loading the trees is expensive so it is done once at the start of the operation
		public List<MonoNodeBase> Trees = new List<MonoNodeBase>(); // Now incorperates multiple trees instead of using the first found
		
		private void Update() {
			if (Running) {
				if (!LoadedOperation) { // Set to false after each run
					LoadedOperation = LoadTrees();
				}
				if (LoadedOperation) { // Set to true once trees are found
					foreach (MonoNodeBase Tree in Trees) {
						Tree.Execute();
					}
				}
			} else {
				LoadedOperation = false; // Only toggles off once Running is off
			}
		}

		private bool LoadTrees() {
			Trees.Clear();
			foreach (Transform child in this.transform) {
				MonoNodeBase script = child.GetComponent<MonoNodeBase>();
				if (script != null) {
					Trees.Add(script);
				}
			}
			return Trees.Count > 0; // Will toggle Loaded on only when a tree has been found
		}
	}
}