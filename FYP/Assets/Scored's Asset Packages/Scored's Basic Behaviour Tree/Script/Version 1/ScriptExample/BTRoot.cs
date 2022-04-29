using System.Collections.Generic;
using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version1 {
	[ExecuteInEditMode]
	public class BTRoot : MonoBehaviour {

		public bool Running = false; // To be triggered in the inspector

		private Sequence abc, abcdef;
		private Selector def;

		private LeafChildA A, B, C;
		private LeafChildB D, E;
		private LeafChildC F;

		private bool initialised = false;

		// Use this for initialization
		void Start() {
			TestInitialise();
		}

		// Update is called once per frame
		void Update() {
			if (Running) {
				if (!initialised) {
					TestInitialise();
				}
				abcdef.Execute(); // Execute the top node to start the tree
			}
		}

		void TestInitialise() {
			// An example of a 3 row tree

			// Testing the leafs (bottom row)
			A = new LeafChildA(); // This works but provides a warning, updated in version 2 -> // A = ScriptableObject.CreateInstance<LeafChildA>();
			B = new LeafChildA();
			C = new LeafChildA();
			D = new LeafChildB();
			E = new LeafChildB();
			F = new LeafChildC();

			// Testing the sequence/selector (middle row) + adding leafs to a group
			abc = new Sequence(new List<NodeBase>(new NodeBase[] { A, B, C }));
			def = new Selector(new List<NodeBase>(new NodeBase[] { D, E, F }));

			// Testing adding 2 different branches to 1 (Top row) / (Top row is 1 branch [Root -> Tree] any more is multiple trees requiring seperate Roots) 
			abcdef = new Sequence(new List<NodeBase>(new NodeBase[] { abc, def }));

			initialised = true;
		}

		// Node Build order : Leaf first -> incorperate needed leafs into first branch (Sequence/Selector) -> Incorperate leafs and branches into future branches until your back at root
		// Overall : bottom of the tree first and work your way up and back to the start
	}
}