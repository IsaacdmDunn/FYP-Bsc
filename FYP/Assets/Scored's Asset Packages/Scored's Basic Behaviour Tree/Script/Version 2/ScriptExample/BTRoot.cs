using System.Collections.Generic;
using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version2 {
	[ExecuteInEditMode]
	public class BTRoot : MonoBehaviour {

		public bool Running = false; // To be triggered in the inspector
		private bool LoadedOperation = false; 

		public List<NodeBase> Trees = new List<NodeBase>();

		private Sequence abc, abcdef;
		private Selector def;

		private LeafChildA A, B, C;
		private LeafChildB D, E;
		private LeafChildC F;

		// Update is called once per frame
		void Update() {
			if (!LoadedOperation) { // Load Scripts into the tree list
				TestInitialise();
				LoadedOperation = true;
			}

			if (Running) {
				RunTrees();
			}
		}

		private void RunTrees() {
			foreach (NodeBase Tree in Trees) {
				Tree.Execute();
			}
		}

		void TestInitialise() { // A constructor basicaly, replace with whats required
								// An example of a 3 row tree

			// Testing the leafs (bottom row)
			Trees.Clear();

			A = ScriptableObject.CreateInstance<LeafChildA>();
			B = ScriptableObject.CreateInstance<LeafChildA>();
			C = ScriptableObject.CreateInstance<LeafChildA>();
			D = ScriptableObject.CreateInstance<LeafChildB>();
			E = ScriptableObject.CreateInstance<LeafChildB>();
			F = ScriptableObject.CreateInstance<LeafChildC>();

			// Testing the sequence/selector (middle row) + adding leafs to a group
			abc = ScriptableObject.CreateInstance<Sequence>();
			abc.LoadNodes(new List<NodeBase>(new NodeBase[] { A, B, C }));

			def = ScriptableObject.CreateInstance<Selector>();
			def.LoadNodes(new List<NodeBase>(new NodeBase[] { D, E, F }));

			// Testing adding 2 different branches to 1 (Top row) / (Top row is 1 branch [Root -> Tree] any more is multiple trees requiring seperate Roots)
			abcdef = ScriptableObject.CreateInstance<Sequence>();
			abcdef.LoadNodes(new List<NodeBase>(new NodeBase[] { abc, def }));

			Trees.Add(abcdef);
		}

		// Node Build order : Leaf first -> incorperate needed leafs into first branch (Sequence/Selector) -> Incorperate leafs and branches into future branches until your back at root
		// Overall : bottom of the tree first and work your way up and back to the start
		
		public void Reset() { // Inspector button function // Script is persistant so resets are required
			Running = false;
			LoadedOperation = false;
			Trees.Clear();
		}
	}
}