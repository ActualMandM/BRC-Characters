using BepInEx;
using CharacterAPI;
using Reptile;
using System.Linq;
using UnityEngine;

namespace BRC_Candyman
{
	[BepInPlugin("com.MandM.BRC-Candyman", "BRC-Candyman", "1.1.3")]
	[BepInDependency("com.Viliger.CharacterAPI", "0.6.0")]

	public class Plugin : BaseUnityPlugin
	{
		public void Awake()
		{
			AssetBundle bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Info.Location), "candy"));

			ModdedCharacterConstructor chara = new ModdedCharacterConstructor();
			chara.characterName = "Candyman";
			chara.characterPrefab = bundle.LoadAsset<GameObject>("candy");
			chara.defaultOutfit = 0;
			chara.defaultMoveStyle = MoveStyle.SKATEBOARD;
			chara.audioClips = bundle.LoadAllAssets<AudioClip>().ToList();
			chara.freestyleType = ModdedCharacterConstructor.FreestyleType.freestyle12;
			chara.bounceType = ModdedCharacterConstructor.BounceType.softbounce1;

			chara.AddOutfit(bundle.LoadAsset<Material>("candyMat1.mat"), "Standard");
			chara.AddOutfit(bundle.LoadAsset<Material>("candyMat2.mat"), "Casino");
			chara.AddOutfit(bundle.LoadAsset<Material>("candyMat3.mat"), "Pastel");
			chara.AddOutfit(bundle.LoadAsset<Material>("candyMat4.mat"), "Saturate");

			chara.AddPersonalGraffiti("Candyman", "Team Reptile", bundle.LoadAsset<Material>("candyGraffiti.mat"), bundle.LoadAsset<Texture>("graffitiTexture.png"));
			chara.CreateModdedCharacter();
		}
	}
}
