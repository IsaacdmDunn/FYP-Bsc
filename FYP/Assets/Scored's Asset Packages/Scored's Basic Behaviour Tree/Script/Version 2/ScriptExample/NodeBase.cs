using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	[ExecuteInEditMode]
	public abstract class NodeBase : ScriptableObject {

		protected bool Running = false;

		public abstract bool Execute();
	}
}
// Base node for the Sequence, Selector and Leaf Nodes