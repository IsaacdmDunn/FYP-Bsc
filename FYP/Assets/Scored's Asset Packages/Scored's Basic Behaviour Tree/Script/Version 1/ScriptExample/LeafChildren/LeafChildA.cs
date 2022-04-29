using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	public class LeafChildA : Leaf {

		public LeafChildA() { // Constructor
			Functions += TestFunction; // Leaf Function
			Functions += ChildTestFunc; // Leaf Child (local) Function
			Name = "Child A";
		}

		void ChildTestFunc() { // Functions made in leaf children also work
			Debug.Log(Name + " Successfully triggered");
		}
	}
}
// Load all of the functionallity you wish the leaf to do into the constructor as shown