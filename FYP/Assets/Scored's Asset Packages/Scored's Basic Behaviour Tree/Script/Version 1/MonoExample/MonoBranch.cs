using System.Collections.Generic;
using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	public abstract class MonoBranch : MonoNodeBase {

		protected List<MonoNodeBase> NodeList; // Nodes to execute
		private int ChildCount; // Number of children

		protected void Start() { // default Start() that is called in the branches 
			ChildCount = 0;
			NodeList = new List<MonoNodeBase>();
			Refresh();
		}

		protected void Update() { // default Update() that is called in the branches 
			if (ChildCount != this.transform.childCount) { // Only when the number of children change
				Refresh();
			}
		}

		protected void Refresh() { // Refresh the list of nodes under this branch
			NodeList.Clear();
			foreach (Transform child in this.transform) {
				MonoNodeBase script = child.GetComponent<MonoNodeBase>();
				if (script != null) {
					NodeList.Add(script);
					ChildCount++;
				}
			}
		}
	}
}