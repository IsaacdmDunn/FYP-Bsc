using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	public class MonoLeafChildB : MonoLeaf {

		[Range(1, 1000000)] // limits the inspector values
		public int SafetyValue = 1; // Value exposed to the Inspector
		protected override int SafetyCatch { get { return SafetyValue; } }

		public override LeafState Leaf_Function() {
			return new LeafState();
		}
	}
}
// Made to show what happens on a blank leaf