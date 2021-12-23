using HarmonyLib;

namespace UsefulPaths
{
	[HarmonyPatch(typeof(Player), "UseStamina")]
	public class PlayerUseStamina_Patch
	{
		private static void Prefix(ref float v)
		{
			if (global::UsefulPaths.UsefulPaths.currentGroundTerrain != 0)
			{
				v *= global::UsefulPaths.UsefulPaths.pathMultiplierConfigs[global::UsefulPaths.UsefulPaths.currentGroundTerrain]["staminadrain"].Value;
			}
		}
	}
}
