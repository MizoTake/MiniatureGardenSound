namespace MiniatureGardenSound.Extensions
{
    public static class SceneObjectExtensions
    {
        public static bool IsEmpty(this SceneObject sceneObject)
        {
            return sceneObject.ToString() == "SceneObject";
        }
    }
}
