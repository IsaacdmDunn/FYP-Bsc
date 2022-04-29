using System.Collections.Generic;
using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	public abstract class MonoBranch : MonoNodeBase {

		protected List<MonoNodeBase> NodeList; // Nodes to execute

		protected void Start() { // default Start() that is called in the branches 
			NodeList = new List<MonoNodeBase>();
			Refresh();
		}

		protected void Update() { // default Update() that is called in the branches 
			if (NodeList.Count != this.transform.childCount) { // Only when the number of children change
				Refresh();
			}
		}

		private void Refresh() {
			NodeList.Clear();
			foreach (Transform child in this.transform) {
				MonoNodeBase script = child.GetComponent<MonoNodeBase>();
				if (script != null) {
					NodeList.Add(script);
				}
			}
		}
	}
}