using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version3 {
	[ExecuteInEditMode]
	public class MonoBTRoot : MonoBehaviour {

		public bool Running = false; // Value exposed to the inspector.

		private bool LoadedOperation = false; // Loading the trees is expensive so it is done once at the start of the operation.
		public List<MonoNodeBase> Trees = new List<MonoNodeBase>(); // Now incorperates multiple trees instead of using the first found.

		// List of IEnumerator to store the Routines, just starting a Routine would mean we cant get results from them.
		private List<IEnumerator<MonoNodeBase.ExecuteState>> RunningRoutines = new List<IEnumerator<MonoNodeBase.ExecuteState>>();

		private void Update() {
			if (Running) {
				if (!LoadedOperation) { // Set to false after each run
					LoadedOperation = LoadTrees();
				}
				if (LoadedOperation && RunningRoutines.All(e => !e.Current.Running)) { // Set to true once trees are found.
					RunningRoutines = new List<IEnumerator<MonoNodeBase.ExecuteState>>();
					foreach (MonoNodeBase Tree in Trees) {
						IEnumerator<MonoNodeBase.ExecuteState> newRoutine = Tree.Execute(); // Way to create, store and start routines.
						RunningRoutines.Add(newRoutine);
						StartCoroutine(newRoutine);
					}
				}
			} else {
				LoadedOperation = false; // Only toggles off once Running is off.
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
			return Trees.Count > 0; // Will toggle Loaded on only when a tree has been found.
		}
	}
}