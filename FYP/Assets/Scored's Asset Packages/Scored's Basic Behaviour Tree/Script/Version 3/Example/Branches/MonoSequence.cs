using System.Collections.Generic;

namespace ScoredProductions.ScoredsBT.Version3 {
	public sealed class MonoSequence : MonoBranch {

		public override IEnumerator<ExecuteState> Execute() {
			bool returningValue = true;
			foreach (MonoNodeBase node in NodeList) {
				StartCoroutine(CurrentRunningBranch = node.Execute());

				while (CurrentRunningBranch.Current.Running) {
					yield return new ExecuteState(true);
				}
				if (!CurrentRunningBranch.Current.ReturnValue) { // Once the first node fails, we dont need to continue so return the result
					returningValue = false;
					break;
				}
			}

			yield return new ExecuteState(value: returningValue);
		}
	}
}
