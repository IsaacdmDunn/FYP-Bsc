using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	[ExecuteInEditMode]
	public class MonoBTRoot : MonoBehaviour {

		public bool Running = false;
		public MonoNodeBase TreeStart; // The root of a tree can only have 1 branch as it has no real functionality

		private void Start() {
			FindFirst();
		}

		private void Update() {
			if (Running) {
				if (TreeStart != null) {
					TreeStart.Execute();
				}
			}
			FindFirst();
		}

		public void FindFirst() {
			if (TreeStart == null) { // if it has a value then ignore
				foreach (Transform child in this.transform) {
					MonoNodeBase script = child.GetComponent<MonoNodeBase>();
					if (script != null) {
						TreeStart = script; // finds first child containing a node execute
						break; // Once the variable is filled there is no need to continue
					}
				}
			} else {
				if (TreeStart.gameObject.transform.parent == null) { // Seperate null check to stop errors
					TreeStart = null;
				} else {
					if (TreeStart.gameObject.transform.parent.gameObject != this.gameObject) { // compare if the parent gameobject and this are the same
						TreeStart = null;
					}
				}
			}
		}
	}
}