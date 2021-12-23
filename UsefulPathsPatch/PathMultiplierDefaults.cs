using System.Collections.Generic;

namespace UsefulPaths
{
    public static class PathMultiplierDefaults
    {
		public static readonly SortedDictionary<PathTypes, Dictionary<string, float>> pathMultiplierDefaults = new SortedDictionary<PathTypes, Dictionary<string, float>>
		{
			{
				PathTypes.None,
				new Dictionary<string, float>
				{
					{ "movement", 1f },
					{ "staminadrain", 1f }
				}
			},
			{
				PathTypes.LevelGround,
				new Dictionary<string, float>
				{
					{ "movement", 1.1f },
					{ "staminadrain", 0.9f }
				}
			},
			{
				PathTypes.Path,
				new Dictionary<string, float>
				{
					{ "movement", 1.25f },
					{ "staminadrain", 0.83f }
				}
			},
			{
				PathTypes.PavedRoad,
				new Dictionary<string, float>
				{
					{ "movement", 1.35f },
					{ "staminadrain", 0.7f }
				}
			},
			{
				PathTypes.Wood,
				new Dictionary<string, float>
				{
					{ "movement", 1.35f },
					{ "staminadrain", 0.7f }
				}
			},
			{
				PathTypes.Stone,
				new Dictionary<string, float>
				{
					{ "movement", 1.35f },
					{ "staminadrain", 0.7f }
				}
			},
			{
				PathTypes.Iron,
				new Dictionary<string, float>
				{
					{ "movement", 1.35f },
					{ "staminadrain", 0.7f }
				}
			},
			{
				PathTypes.HardWood,
				new Dictionary<string, float>
				{
					{ "movement", 1.35f },
					{ "staminadrain", 0.7f }
				}
			}
		};
	}
}
