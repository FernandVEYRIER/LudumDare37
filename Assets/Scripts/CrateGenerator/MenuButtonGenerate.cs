using UnityEngine;
using UnityEditor;

public class MenuButtonGenerate : MonoBehaviour {
	private static GameObject createObjectGenerator(Transform prt, string path = "Prefabs/Barrel")
	{
		GameObject obj = new GameObject ();
		obj.name = "Generator";
		obj.transform.SetParent (prt);
		obj.AddComponent<CrateGenerator> ();
//		obj.GetComponent<CrateGenerator> ().crate = (GameObject)AssetDatabase.LoadAssetAtPath (path, typeof(GameObject));//(GameObject)Resources.Load (path, typeof(GameObject));
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
		GameObject gen = createObjectGenerator(generators.transform, "Prefabs/Barrel");
		gen.name = "Barrel generator";
	}

	[MenuItem("Generator/Add/Add crate generator %&gc", false, 2)]
	private static void addCrateGenerator()
	{
		GameObject generators = checkGenerators ();
		GameObject gen = createObjectGenerator (generators.transform, "Prefabs/Crate");
		gen.name = "Crate generator";
	}

	[MenuItem("Debug/Log selected object name")]
	private static void debugSelectedObjectName()
	{
		Object obj = Selection.activeObject;
		if (obj != null) {
			Debug.Log ("---" + obj.name + "---");
		} else
			Debug.Log ("Nothing selected");
	}

	[MenuItem("Debug/Log selected prefab path")]
	private static void debugSelectedObjectPath()
	{
		Object obj = Selection.activeObject;
		if (obj != null) {
			if (AssetDatabase.GetAssetPath (PrefabUtility.GetPrefabObject (obj)) != null)
				Debug.Log (AssetDatabase.GetAssetPath (PrefabUtility.GetPrefabObject (obj)));
			else
				Debug.Log ("No path found");
		} else {
			Debug.Log ("Nothing selected");
		}
	}

	[MenuItem("Generator/Add/Add selected object generator %&gs", false, 3)]
	private static void addSelectedObjectGenerator()
	{
		GameObject generators = checkGenerators ();
		string path = (AssetDatabase.GetAssetPath (PrefabUtility.GetPrefabObject (Selection.activeObject))).Remove (0, 7);
		path = path.Remove(path.LastIndexOf('.'), path.Length - path.LastIndexOf('.'));
		GameObject gen = createObjectGenerator (generators.transform, path);
		gen.name = path.Remove(0, path.LastIndexOf('/') + 1) + " generator";
	}

	[MenuItem("Generator/Add/Add selected object generator %&gs", true, 3)]
	private static bool addSelectedObjectGeneratorValidation()
	{
		Object obj;
		if ((obj = Selection.activeObject) != null && (obj = PrefabUtility.GetPrefabObject(obj)) != null && AssetDatabase.GetAssetPath(obj) != null)
			return (true);
		return (false);
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
