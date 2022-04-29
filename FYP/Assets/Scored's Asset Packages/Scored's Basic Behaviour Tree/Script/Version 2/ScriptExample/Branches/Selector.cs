using System.Collections.Generic;

namespace ScoredProductions.ScoredsBT.Version2 {
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

		public void LoadNodes(List<NodeBase> Nodes) { // Now that the constructor isnt used, a function was required to load the nodes in
			NodeList = Nodes;
		}
	}
}