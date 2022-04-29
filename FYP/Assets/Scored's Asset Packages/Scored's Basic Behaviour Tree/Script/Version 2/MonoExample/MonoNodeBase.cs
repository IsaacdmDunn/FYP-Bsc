using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	[ExecuteInEditMode]
	public abstract class MonoNodeBase : MonoBehaviour {

		protected bool Running = false; // Bool used in all classes

		public abstract bool Execute(); // Function thats called in all classes
	}
}
// Base class of branches and leafs