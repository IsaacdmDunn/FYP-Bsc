using System.Collections.Generic;
using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version3 {
	[ExecuteInEditMode]
	public abstract class MonoNodeBase : MonoBehaviour {

		public abstract IEnumerator<ExecuteState> Execute(); // Function thats called in all classes.

		public class ExecuteState { // Now lives here so that the IEnumerator has access to it.
			public bool Running;
			public bool ReturnValue;

			public ExecuteState(bool running = false, bool value = false) {
				Running = running;
				ReturnValue = value;
			}
		}
	}
}
// Base class of branches and leafs.