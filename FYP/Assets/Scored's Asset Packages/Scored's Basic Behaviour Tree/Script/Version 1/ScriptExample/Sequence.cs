using System.Collections.Generic;

namespace ScoredProductions.ScoredsBT.Version1 {
	public sealed class Sequence : Branch {

		public override bool Execute() {
			Running = true;
			foreach (NodeBase node in NodeList) {
				if (!node.Execute()) { // Due to C#'s polymorphism you can execute the node without casting
					Running = false;
					return false; // Once the first node fails, we dont need to continue so return the result
				}
			}
			Running = false;
			return true;
		}

		public Sequence(List<NodeBase> Nodes) { // Constructor
			NodeList = Nodes;
		}
	}
}