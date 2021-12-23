namespace UsefulPaths
{
    public class CharacterUpdateWalking_Patch
    {
        private static void Prefix(Character __instance)
        {
            __instance.m_walkSpeed = 1.6f * ((global::UsefulPaths.UsefulPaths.currentGroundTerrain == PathTypes.None) ? 1f : global::UsefulPaths.UsefulPaths.pathMultiplierConfigs[global::UsefulPaths.UsefulPaths.currentGroundTerrain]["movement"].Value);
        }
    }
}
