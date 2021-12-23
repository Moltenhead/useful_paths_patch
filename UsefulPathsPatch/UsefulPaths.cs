using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace UsefulPaths
{
	public enum PathTypes
	{
		None,
		LevelGround,
		Path,
		PavedRoad,
		Wood,
		Stone,
		Iron,
		HardWood
	}

	[BepInPlugin("Moltenhead.bepinex.plugins.UsefulPaths", "UsefulPaths", "0.1.0")]
	public class UsefulPaths : BaseUnityPlugin
	{
		private const float groundCheckRate = 0.4f;
		public static SortedDictionary<PathTypes, Dictionary<string, ConfigEntry<float>>> pathMultiplierConfigs { get; private set; } = new SortedDictionary<PathTypes, Dictionary<string, ConfigEntry<float>>>();
		public static PathTypes currentGroundTerrain { get; private set; } = PathTypes.None;

		private void Awake()
		{
			InitializePathMultiplierConfig();
			InvokeRepeating("UpdateSpeedBasedOnGround", 0f, 0.4f);
			Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
		}

		private void InitializePathMultiplierConfig()
		{
			foreach (KeyValuePair<PathTypes, Dictionary<string, float>> pathMultiplierDefault in PathMultiplierDefaults.pathMultiplierDefaults)
			{
				if (pathMultiplierDefault.Key != 0)
				{
					pathMultiplierConfigs.Add(pathMultiplierDefault.Key, new Dictionary<string, ConfigEntry<float>>
					{
						{
							"movement",
							base.Config.Bind(pathMultiplierDefault.Key.ToString(), "movement", pathMultiplierDefault.Value["movement"])
						},
						{
							"staminadrain",
							base.Config.Bind(pathMultiplierDefault.Key.ToString(), "staminadrain", pathMultiplierDefault.Value["staminadrain"])
						}
					});
				}
			}
		}

		private void UpdateSpeedBasedOnGround()
		{
			if (Player.m_localPlayer != null)
			{
				//string text = TerrainModifier.FindClosestModifierPieceInRange(Player.m_localPlayer.transform.position, 6f)?.m_name?.Replace("$piece_", string.Empty);
				Collider lastGroundCollider = Player.m_localPlayer.GetLastGroundCollider();
				WearNTear wearNTear = null;
				if ((UnityEngine.Object)(object)lastGroundCollider != null)
				{
					wearNTear = ((Component)(object)lastGroundCollider).GetComponentInParent<WearNTear>();
				}
				if (wearNTear != null && Enum.TryParse<PathTypes>(wearNTear.m_materialType.ToString(), ignoreCase: true, out var result))
				{
					currentGroundTerrain = result;
					return;
				}

				Heightmap actualHeightMap = Heightmap.FindHeightmap(Player.m_localPlayer.transform.position);
				actualHeightMap.WorldToVertex(Player.m_localPlayer.transform.position, out var x, out var y);
				Color paintMaskColor = actualHeightMap.GetPaintMask(x, y);
				if (paintMaskColor.r > 0.5)
				{
					currentGroundTerrain = PathTypes.Path;
					return;
				}
				if (paintMaskColor.b > 0.5)
				{
					currentGroundTerrain = PathTypes.PavedRoad;
					return;
				}
				
				currentGroundTerrain = PathTypes.None;
			}
		}
	}
}
