using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	public class LeafChildC : Leaf {

		// This is an example of a leaf node that requires running to stay true until it is complete
		// When it is finished it can then move on
		int count;

		// Use this for initialization
		public LeafChildC() { // Constructor
			Name = "Child C";
			count = 0;
		}

		// Overriding this function negates the use of the delegate
		// unless you wish to use it then you can re-apply it
		public override void FunctionMethod() {
			if (count < 100) { // counts up to 100, keeps the node on and running until its done for example
				count++;
				Debug.Log(count);
			} else {
				Running = false;
				FunctionReturn = true;
				count = 0;
			}
		}
	}
}