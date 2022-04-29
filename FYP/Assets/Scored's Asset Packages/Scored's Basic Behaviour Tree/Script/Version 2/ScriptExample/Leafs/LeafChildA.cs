using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	public class LeafChildA : Leaf {

		public int SafetyValue = 10000; // Value used to stop endless loops
		protected override int SafetyCatch { get { return SafetyValue; } }

		public LeafChildA() {
			Name = "Child A";
		}

		public override LeafState Leaf_Function() {
			ChildTestFunc();
			return new LeafState() { ReturnValue = true };
		}

		void ChildTestFunc() {
			Debug.Log(Name + " Successfully triggered");
		}
	}
}
// Load all of the functionallity you wish the leaf to do into the constructor as shown