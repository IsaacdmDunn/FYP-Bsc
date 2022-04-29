using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version3 {
	public class MonoLeafChildB : MonoLeaf {

		public override ExecuteState Leaf_Function() { // Forced Implement.
			return new ExecuteState();
		}
	}
}
// Made to show what happens on a blank leaf.