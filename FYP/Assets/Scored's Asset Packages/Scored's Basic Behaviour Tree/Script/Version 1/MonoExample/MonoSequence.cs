namespace ScoredProductions.ScoredsBT.Version1 {
	public sealed class MonoSequence : MonoBranch {

		public override bool Execute() {
			Running = true;
			foreach (MonoNodeBase node in NodeList) {
				if (!node.Execute()) { // C#'s polymorphism, you can execute the node without casting
					Running = false;
					return false; // Once the first node fails, we dont need to continue so return the result
				}
			}
			Running = false;
			return true;
		}
	}
}