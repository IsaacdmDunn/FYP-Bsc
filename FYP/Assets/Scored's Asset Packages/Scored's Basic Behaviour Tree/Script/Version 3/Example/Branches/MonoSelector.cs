using System.Collections.Generic;

namespace ScoredProductions.ScoredsBT.Version3 {
	public sealed class MonoSelector : MonoBranch {

		public override IEnumerator<ExecuteState> Execute() {
			bool returningValue = false;
			foreach (MonoNodeBase node in NodeList) {
				StartCoroutine(CurrentRunningBranch = node.Execute()); // C#'s polymorphism, you can execute the node without casting

				while (CurrentRunningBranch.Current.Running) {
					yield return new ExecuteState(true);
				}
				if (CurrentRunningBranch.Current.ReturnValue) { // Once the first node fails, we dont need to continue so return the result
					returningValue = true;
					break;
				}
			}

			yield return new ExecuteState(value: returningValue);
		}
	}
}