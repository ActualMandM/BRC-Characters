using BepInEx;
using CharacterAPI;
using Reptile;
using System.Linq;
using UnityEngine;

namespace BRC_Escher
{
	[BepInPlugin("com.MandM.BRC-NEOTWEWY_Beat", "BRC-NEOTWEWY_Beat", "1.1.0")]
	[BepInDependency("com.Viliger.CharacterAPI", "0.6.0")]

	public class Plugin : BaseUnityPlugin
	{
		public void Awake()
		{
			AssetBundle bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Info.Location), "daisukenojobitoneo"));

			ModdedCharacterConstructor chara = new ModdedCharacterConstructor();
			chara.characterName = "Beat";
			chara.characterPrefab = bundle.LoadAsset<GameObject>("beatneo");
			chara.defaultOutfit = 0;
			chara.defaultMoveStyle = MoveStyle.SKATEBOARD;
			chara.audioClips = bundle.LoadAllAssets<AudioClip>().ToList();
			chara.freestyleType = ModdedCharacterConstructor.FreestyleType.freestyle7;
			chara.bounceType = ModdedCharacterConstructor.BounceType.softbounce4;

			chara.AddOutfit(bundle.LoadAsset<Material>("beatneoMat0.mat"));
			chara.AddOutfit(bundle.LoadAsset<Material>("beatneoMat1.mat"));
			chara.AddOutfit(bundle.LoadAsset<Material>("beatneoMat0.mat"), "U_SKIN_SPRING");
			chara.AddOutfit(bundle.LoadAsset<Material>("beatneoMat0.mat"), "U_SKIN_SPRING");

			chara.personalGraffitiBase = Characters.metalHead;
			chara.CreateModdedCharacter();
		}
	}
}
