using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	[ExecuteInEditMode]
	public abstract class MonoNodeBase : MonoBehaviour {

		protected bool Running = false;

		public abstract bool Execute();

	}
}