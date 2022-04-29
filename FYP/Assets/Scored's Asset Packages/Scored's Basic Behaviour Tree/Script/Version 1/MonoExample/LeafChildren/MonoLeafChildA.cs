using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	public class MonoLeafChildA : MonoLeaf {

		public MonoLeafChildA() { // Constructor
			Functions += TestFunction; // Parent Function
			Functions += ChildTestFunc; // Child (local) Function
		}

		void ChildTestFunc() { // Functions made in leaf children also work
			Debug.Log("Child A Successfully triggered");
		}
	}
}
// Because TestFunction was included, Running was toggled off and FunctionReturn was set to true,
// meaning multiple functions can be included and if atleast one toggles these values its ok