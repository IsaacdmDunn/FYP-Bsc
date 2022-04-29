using System.Collections.Generic;

namespace ScoredProductions.ScoredsBT.Version1 {
	public sealed class Selector : Branch {

		public override bool Execute() {
			Running = true;
			foreach (NodeBase node in NodeList) {
				if (node.Execute()) { // Due to C#'s polymorphism you can execute the node without casting
					Running = false;
					return true; // Once the first node succeeds, we dont need to continue so return the result
				}
			}
			Running = false;
			return false;
		}

		public Selector(List<NodeBase> Nodes) { // Constructor
			NodeList = Nodes;
		}
	}
}