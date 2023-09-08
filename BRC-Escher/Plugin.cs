using BepInEx;
using CharacterAPI;
using Reptile;
using System.Linq;
using UnityEngine;

namespace BRC_Escher
{
	[BepInPlugin("com.MandM.BRC-Escher", "BRC-Escher", "1.0.0")]
	[BepInDependency("com.Viliger.CharacterAPI", "0.6.0")]

	public class Plugin : BaseUnityPlugin
	{
		public void Awake()
		{
			AssetBundle bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Info.Location), "snipercaptainplayer"));

			ModdedCharacterConstructor chara = new ModdedCharacterConstructor();
			chara.characterName = "Escher";
			chara.characterPrefab = bundle.LoadAsset<GameObject>("sniperCaptainPlayer");
			chara.defaultOutfit = 0;
			chara.defaultMoveStyle = MoveStyle.INLINE;
			chara.audioClips = bundle.LoadAllAssets<AudioClip>().ToList();
			chara.freestyleType = ModdedCharacterConstructor.FreestyleType.freestyle4;
			chara.bounceType = ModdedCharacterConstructor.BounceType.softbounce6;

			chara.AddOutfit(bundle.LoadAsset<Material>("sniperCaptainPlayerMat0.mat"));
			chara.AddOutfit(bundle.LoadAsset<Material>("sniperCaptainPlayerMat1.mat"));
			chara.AddOutfit(bundle.LoadAsset<Material>("sniperCaptainPlayerMat2.mat"));
			chara.AddOutfit(bundle.LoadAsset<Material>("sniperCaptainPlayerMat3.mat"));

			chara.personalGraffitiBase = Characters.jetpackBossPlayer;
			chara.CreateModdedCharacter();
		}
	}
}
