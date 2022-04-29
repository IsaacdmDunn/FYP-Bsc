Hi, thanks for downloading this project.
Jan 2020;
I made the first version for fun in Aug 2018 and found this code late 2019, I made version 2 to see how I would do it differently,
I decided to include them both anyway because I thought why not, its two different ways of looking at it and doing it.

Sep 2020;
By now its been released a week or so. Over the year working with Unity for my job I got into Coroutines so I welcome version 3 to
bring a more specialised version to the table. its main purpose is to have trees running over a longer duration across multiple frames
instead of everything in a single frame, version 1/2 are good for trees for an immediate result, version 3 is for continuous use.

#HowTo:
- The code is commented with instructions but a quick guide to the types is here.

- The scenes are preloaded with basic stuctures of both types.

- The structure of the scripts is:
	-	Sequence
	--	Sequence		-			Selector
	--- LeafA - LeafA - LeafA	|	LeafB - LeafB - LeafC

- The output will be produced in the console and should show:
	- 3 => "Child A Successfully triggered"
	- Followed by a 0-100 count.

- To run the trees, toggle the Running bool to on, even in Editor mode. They will work continuously until turned off.

- The Monobehaviour version works by including the scripts onto GameObjects and placing the GameObjects under respective GameOjects
  of the tree.

- The ScriptableObject version requires the tree to be programaticly created.

#Notes:

- The Unity Engine (in 2018 I dont know for other versions) will NOT distinguish code of the same name in the inspector by
  its 'namespace' so please be carefull when looking between versions. It will still run them seperatly or by mixing them but it wont say which version
  its using.

- Best practice for if you wish to copy a version to make a amendments is to copy the entire version folder and to go into
  each CS file and change the namespace name of each file.

- The namespace of the project is 'ScoredProductions.ScoredsBT.' and is currently using Version1, Version2 and Version3 so please avoid using the same
  namespace style such as  Version4 for example as I may make other versions and updates.