General Information for NGenerics
---------------------------------

Contents
---------
1. Introduction
2. License
3. Solution Folders
4. Mono Notes
5. Support


1. Introduction
---------------

If you're reading this, welcome to the most complete data structures and algorithms library developed on .NET., for .NET.

2. License
----------

NGenerics is provided under a very liberal license - you can read all about it in the License.txt file, under the SolutionFiles directory.

3. Solution Folders
-------------------

	- The following can project files can be found in the root of the solution :
		- NGenerics : The main assembly.
		- NGenericsTests : An assembly containing unit tests for NGenerics.	
		
	- Project Dependencies : Can be found under the Dependencies folder.
	
	- Examples : Examples can be found under the Examples folder.  Two example projects are included and used to build the examples in the build file - one written in C# (ExampleLibraryCSharp), and another in Visual Basic .NET (ExampleLibraryVB).
	
	- Documentation :  The SandCastle Help File Builder (SHFB) project and associated artifacts (like images) is located under \SolutionFiles\Documentation.
	
	- Code Analysis Artifacts : For those who don't have Visual Studio Team Edition, an FxCop project has been created to manually perform a code analysis on the assembly.  The project can be found in the \SolutionFiles\FxCop folder.
	
	- Additional Info : Where you found this file.  Included is the Version History and the License for NGenerics.
	
	- Build Artifacts : If you choose not to compile the assembly the traditional way, an NAnt build file is provided for compilation in several environments (under Mono, for example).


4. Mono Notes
-------------

Mono has a couple of incompatibilities with the Microsoft .NET framework.   

The following changes have been made to allow NGenerics to run on Mono  : 

	- [Serializable] removed on all data structures which contain a reference to an IComparer<T> instance.  The default comparers in Mono is not currently marked as Serializable which breaks serialization for the following data structures : 
		- Heap
		- SkipList
		- SortedList
		- BinarySearchTree
		- RedBlackTree
		- SplayTree
		- PriorityQueue
		
	- The resources file isn't linked properly in the assembly when compiling the source with MonoDevelop.  An Nant build file has been provided (in the SolutionFiles\Build folder) if you wish to compile from source.
	
If you do try and compile from MonoDevelop, be sure to include the "MONO" conditional compilation symbol to avoid any runtime issues.

	
5. Support
----------

NGenerics is developed entirely out of spare time, most of which includes late hours into the night, so the idea of providing commercial support is unrealistic.  However, we take pride in this project, and will try to fix all and any issues as soon as possible.

Please report any feature requests / bugs / issues to the CodePlex project site discussion form (www.codeplex.com/NGenerics).

As an alternative, you can also email the NGenerics team at NGenerics@gmail.com.
	




