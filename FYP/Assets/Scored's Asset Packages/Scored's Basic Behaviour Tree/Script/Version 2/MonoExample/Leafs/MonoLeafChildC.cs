using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	public class MonoLeafChildC : MonoLeaf {

		[Range(1, 1000000)] // limits the inspector values
		public int SafetyValue = 1; // Value exposed to the Inspector
		protected override int SafetyCatch { get { return SafetyValue; } }

		private int count = 0;

		public override LeafState Leaf_Function() { // Forced Implement
			if (count < 100) { // counts up to 100, keeps the leaf on and running until its done for example
				count++;
				Debug.Log(count);
			} else {
				count = 0;
				return new LeafState() { ReturnValue = true }; // Option to change return value and if to continue running
			}
			return new LeafState() { Running = true }; // Continue Running
		}
	}
}

// This is an example of a leaf node that requires running to stay true until it is complete
// When it is finished the return value can be changed to true