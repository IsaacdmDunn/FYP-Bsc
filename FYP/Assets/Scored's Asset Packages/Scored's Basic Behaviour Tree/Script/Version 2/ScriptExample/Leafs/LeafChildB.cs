namespace ScoredProductions.ScoredsBT.Version2 {
	public class LeafChildB : Leaf {
		
		public int SafetyValue = 10000; // Value used to stop endless loops
		protected override int SafetyCatch { get { return SafetyValue; } }

		public LeafChildB() {
			Name = "Child B";
		}

		public override LeafState Leaf_Function() {
			return new LeafState();
		}
	}
}
// Made to show what happens on a blank leaf