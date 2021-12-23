using HarmonyLib;

namespace UsefulPaths
{
	[HarmonyPatch(typeof(Player), "GetJogSpeedFactor")]
	public class PlayerGetJogSpeedFactor_Patch
    {
		private static void Postfix(ref float __result)
		{
			if (global::UsefulPaths.UsefulPaths.currentGroundTerrain != 0)
			{
				__result *= global::UsefulPaths.UsefulPaths.pathMultiplierConfigs[global::UsefulPaths.UsefulPaths.currentGroundTerrain]["movement"].Value;
			}
		}
	}
}
