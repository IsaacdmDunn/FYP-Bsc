using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	public class LeafChildC : Leaf {
		
		public int SafetyValue = 10000; // Value used to stop endless loops
		protected override int SafetyCatch { get { return SafetyValue; } }

		private int count = 0;

		public LeafChildC() {
			Name = "Leaf C";
		}

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