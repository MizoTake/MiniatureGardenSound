using System.Linq;
using UnityEngine;
using UnityEditor;

namespace MiniatureGardenSound.Editor
{
    public class Builder
    {
        public static void Build()
        {
            var scenes = EditorBuildSettings.scenes.Where(x => x.enabled).Select(x => x.path);
            var buildPath = Application.dataPath.Replace("Assets", "Build/");
            BuildPipeline.BuildPlayer(scenes.ToArray(), buildPath, BuildTarget.WebGL, BuildOptions.None);
        }
    }
}