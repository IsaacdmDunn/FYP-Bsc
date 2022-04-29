using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version3 {
	public class MonoLeafChildA : MonoLeaf {

		public override ExecuteState Leaf_Function() { // Forced Implement.
			Debug.Log("Child A Successfully triggered"); // Why did I have this in its own function again?...
			return new ExecuteState(value: true);
		}
	}
}
// Example Leaf Child.