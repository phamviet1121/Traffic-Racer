using UnityEditor;
using UnityEngine;

public class RemoveAllMissingScriptsInProject
{
    [MenuItem("Tools/Cleanup/Remove All Missing Scripts In Project (Deep Fix)")]
    static void RemoveMissingScripts()
    {
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab");
        int totalRemoved = 0;
        int totalPrefabs = 0;

        foreach (string guid in prefabGUIDs)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null) continue;

            GameObject instance = PrefabUtility.LoadPrefabContents(path);
            bool hasChanges = false;
            int removedFromThis = 0;

            Transform[] allTransforms = instance.GetComponentsInChildren<Transform>(true);
            foreach (Transform t in allTransforms)
            {
                GameObject go = t.gameObject;
                int missingCount = GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(go);
                if (missingCount > 0)
                {
                    Undo.RegisterCompleteObjectUndo(go, "Remove Missing Scripts");
                    GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
                    removedFromThis += missingCount;
                    hasChanges = true;
                }
            }

            if (hasChanges)
            {
                PrefabUtility.SaveAsPrefabAsset(instance, path);
                Debug.Log($"✅ Removed {removedFromThis} missing scripts from prefab: {path}");
                totalRemoved += removedFromThis;
            }

            PrefabUtility.UnloadPrefabContents(instance);
            totalPrefabs++;
        }

        AssetDatabase.SaveAssets();
        Debug.Log($"🎉 Scanned {totalPrefabs} prefabs. Total missing scripts removed: {totalRemoved}");
    }
}
