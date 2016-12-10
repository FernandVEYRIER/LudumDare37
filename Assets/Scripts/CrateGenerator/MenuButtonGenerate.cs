using UnityEngine;
using UnityEditor;

public class MenuButtonGenerate : MonoBehaviour {
	private static GameObject createObjectGenerator(Transform prt)
	{
		GameObject obj = new GameObject ();
		obj.name = "Generator";
		obj.transform.SetParent (prt);
		obj.AddComponent<CrateGenerator> ();
		return (obj);
	}

	private static GameObject checkGenerators()
	{
		GameObject generators = GameObject.Find ("Generators");
		if (generators == null) {
			generators = new GameObject ();
			generators.name = "Generators";
		}
		return (generators);
	}

	[MenuItem("Generator/Add/Add barrel generator %&gb", false, 1)]
	private static void addBarrelGenerator()
	{
		GameObject generators = checkGenerators ();
		GameObject gen = createObjectGenerator(generators.transform);
		gen.GetComponent<CrateGenerator> ().crate = (GameObject)Resources.Load ("Prefabs/Barrel", typeof(GameObject));
		gen.name = "Barrel generator";
	}

	[MenuItem("Generator/Add/Add crate generator %&gc", false, 2)]
	private static void addCrateGenerator()
	{
		GameObject generators = checkGenerators ();
		GameObject gen = createObjectGenerator (generators.transform);
		gen.GetComponent<CrateGenerator> ().crate = (GameObject)Resources.Load ("Prefabs/Crate", typeof(GameObject));
		gen.name = "Crate generator";
	}

	[MenuItem("Generator/Add/Add selected object generator %&gs", false, 3)]
	private static void addSelectedObjectGenerator()
	{
		GameObject generators = checkGenerators ();
		GameObject gen = createObjectGenerator (generators.transform);
		gen.GetComponent<CrateGenerator> ().crate = (GameObject)Resources.Load ("Prefabs/" + Selection.activeGameObject.name, typeof(GameObject));
		gen.name = Selection.activeGameObject.name + " generator";
	}

	[MenuItem("Generator/Clear/Reset generators %&#r", false, 4)]
	private static void resetGenerators()
	{
		GameObject generators = GameObject.Find ("Generators");
		if (generators != null) {
			while (generators.transform.childCount > 0)
				GameObject.DestroyImmediate (generators.transform.GetChild (0).gameObject);
		}
	}
}
