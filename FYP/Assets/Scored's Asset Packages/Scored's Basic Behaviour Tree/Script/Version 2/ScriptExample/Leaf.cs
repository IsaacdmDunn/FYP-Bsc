using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	public abstract class Leaf : NodeBase {
		
		public string Name = "UNNAMED LEAF"; // Without monobehaviour, this class will need a name to identify it for debugging

		protected abstract int SafetyCatch { get; } // Safety to end infinite loops, created like this so that it must be implemented in childrens inspectors

		private LeafState ReturnedState;

		public sealed override bool Execute() { // Sealing it makes sure it cant be overriden again and protects our safety checks
			Running = true;

			int safetyCount = 10000;
			if (SafetyCatch > 0) { // With no inspector attributes, a default safety value needs to be in place
				safetyCount = SafetyCatch;
			}

			for (int safety = 0; safety < safetyCount; safety++) { // Do | Whiles are dangerous, using a for is not only cleaner but safer
				ReturnedState = Leaf_Function();
				if (!ReturnedState.Running) {
					Running = false;
					return ReturnedState.ReturnValue;
				}
			}

			Running = false;
			Debug.LogWarning(Name + " : Safety catch triggered"); // Safety shouldnt be triggered, although caught it should never get here
			return ReturnedState.ReturnValue; // Although safety was triggered a value will still be returned, contemplated throwing an exception but a log warning is fine
		}

		public abstract LeafState Leaf_Function();

		public struct LeafState { // Simplified the setting system, now the return on the function will set both the Running and Return Value (plus I needed 2 values in 1 return)
			public bool Running;
			public bool ReturnValue;
		}
	}
}
// You can make children based from the leaf class to simplify and organise the functions ("LeafChildA", "LeafChildB")
