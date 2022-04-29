using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version3 {
	public class MonoLeafChildC : MonoLeaf {

		private int count = 0;

		public override ExecuteState Leaf_Function() { // Forced Implement.
			if (count < 100) { // counts up to 100, keeps the leaf on and running until its done for example.
				Debug.Log(count++);
			} else {
				count = 0;
				return new ExecuteState(value: true); // Option to change return value and if to continue running.
			}
			return new ExecuteState(running: true); // Continue Running.
		}
	}
}

// This is an example of a leaf node that requires running to stay true until it is complete.
// When it is finished the return value can be changed to true.