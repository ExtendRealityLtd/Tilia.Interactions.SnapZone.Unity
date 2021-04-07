namespace Tilia.Interactions.SnapZone.Utility
{
    using System.IO;
    using UnityEditor;
    using Zinnia.Utility;

    public class PrefabCreator : BasePrefabCreator
    {
        private const string group = "Tilia/";
        private const string project = "Interactions/SnapZone/";
        private const string menuItemRoot = topLevelMenuLocation + group + subLevelMenuLocation + project;

        private const string package = "io.extendreality.tilia.interactions.snapzone.unity";
        private const string baseDirectory = "Runtime";
        private const string prefabDirectory = "Prefabs";
        private const string prefabSuffix = ".prefab";

        private const string prefabInteractionsSnapZone = "Interactions.SnapZone";

        [MenuItem(menuItemRoot + prefabInteractionsSnapZone, false, priority)]
        private static void AddInteractionsSnapZone()
        {
            string prefab = prefabInteractionsSnapZone + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }
    }
}