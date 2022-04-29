namespace ScoredProductions.ScoredsBT.Version1 {
	public sealed class MonoSelector : MonoBranch {

		public override bool Execute() {
			Running = true;
			foreach (MonoNodeBase node in NodeList) {
				if (node.Execute()) { // C#'s polymorphism, you can execute the node without casting
					Running = false;
					return true; // As only 1 needs to be successful then it can return once one is
				}
			}
			Running = false;
			return false;
		}
	}
}