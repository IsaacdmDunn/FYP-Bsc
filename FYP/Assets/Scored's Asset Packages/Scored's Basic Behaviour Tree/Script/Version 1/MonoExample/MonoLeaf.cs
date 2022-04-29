using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	public class MonoLeaf : MonoNodeBase {

		protected delegate void DelegateFunction();
		protected event DelegateFunction Functions; // Delegate which holds the functions it will call

		protected bool FunctionReturn = false; // bool that Execute() returns

		private int RunningBreak = 1000; // Safety to end infinite loops

		public sealed override bool Execute() { // Sealing it makes sure it cant be overriden again and protects our safety checks
			Running = true;
			int safety = 0;

			do { // Be carefull when making functions so that it only loops when neccessary
				FunctionMethod(); // Should always run the function atleast once
				if (safety >= RunningBreak && Running == true) { // 
					Running = false;
					Debug.Log("Safety was triggered to end loop");
				} else {
					safety++;
				}
			} while (Running);

			return FunctionReturn;
		}

		// an overridable function to allow avoiding the use of the delegate
		public virtual void FunctionMethod() {
			if (Functions == null) { // set to use the delegate by default
				Debug.Log("Leaf " + this.name + " : Method not Overriden and Delegate is empty");
				Running = false; // Nothing to do then we stop the node
				FunctionReturn = false; // incase it gets changed so that it always returns false for an empty leaf node
			} else {
				Functions(); // functions will be assigned in the childrens constructor
			}
		}

		public void TestFunction() {
			FunctionReturn = true; // Determines if the leaf is successful
			Running = false; // Leafs could have functions where they need to repeat until the task is complete but do rememeber to have this somewhere in the function
		}
	}
}
// You can make children based from the leaf class to simplify and organise the functions ("LeafChildA", "LeafChildB")
