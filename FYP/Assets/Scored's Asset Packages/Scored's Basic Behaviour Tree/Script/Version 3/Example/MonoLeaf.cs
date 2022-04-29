using System.Collections.Generic;
using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version3 {
	public abstract class MonoLeaf : MonoNodeBase {
		
		[Range(1, 1000000)] // limits the inspector values.
		public int SafetyValue = 10000; // Value exposed to the Inspector.

		private ExecuteState ReturnedState;
		
		public sealed override IEnumerator<ExecuteState> Execute() { // As IEnumerator dont just end from inside itself, creative restructing was required.
			int safety = 0;
			for (; safety < SafetyValue; safety++) { // definition part of fors can be left empty.
				ReturnedState = Leaf_Function();
				if (!ReturnedState.Running) {
					break;
				}
				yield return new ExecuteState(running: true); // Although the first value, it makes it clearer what the desired action is.
			}

			if (safety == SafetyValue) { // As it could trigger every time in an IEnumerator, it needed a check.
				Debug.LogWarning(gameObject.name + " : Safety catch triggered"); // Safety shouldnt be triggered, although caught it should never get here.
			}

			yield return new ExecuteState(value: ReturnedState.ReturnValue); // Naming the parameter allows for selective setting of optional parameters.
		}
		
		public abstract ExecuteState Leaf_Function(); // Class that must be implemented in child classes, functionality is now all placed in here removing delegates.
	}
}
// You can make children based from the leaf class to simplify and organise the functions. ("LeafChildA", "LeafChildB")
