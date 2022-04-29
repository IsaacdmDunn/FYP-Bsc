using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	public class Leaf : NodeBase {

		protected delegate void DelegateFunction();
		protected event DelegateFunction Functions; // Delegate which holds the functions it will call
		protected string Name = "UNNAMED LEAF";

		protected bool FunctionReturn = false;

		public int RunningBreak = 1000; // Safety to end infinite loops

		public sealed override bool Execute() { // Sealing it makes sure it cant be overriden again and protects our safety checks
			Running = true;
			int safety = 0;

			do { // Be carefull when making functions so that it only loops when neccessary
				FunctionMethod(); // Should always run the function atleast once
				if (safety >= RunningBreak && Running == true) {
					Running = false;
					Debug.Log("Running Break was triggered to end loop");
				} else {
					safety++;
				}
			} while (Running);

			return FunctionReturn;
		}

		// an overridable function to allow avoiding the use of the delegate
		public virtual void FunctionMethod() {
			if (Functions == null) { // set to use the delegate by default
				Debug.Log("Leaf " + Name + " : Method not Overriden and Delegate is empty");
				Running = false; // Nothing to do so then we stop the node
				FunctionReturn = false; // incase it gets changed so that it always returns false for an empty leaf node
			} else {
				Functions();
			}
		}

		// Test if the leaf node works, also these functions can be accessible in the child leafs
		public void TestFunction() {
			FunctionReturn = true; // Determines if the leaf is successful
			Running = false; // Leafs could have functions where they need to repeat until the task is complete but do rememeber to have this somewhere in their
		}
	}
}
// You can make children based from the leaf class to simplify and organise the functions ("LeafChildA", "LeafChildB")
