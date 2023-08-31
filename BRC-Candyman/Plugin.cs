﻿using BepInEx;
using MonoMod.Cil;
using UnityEngine.TextCore.Text;
using UnityEngine;
using Reptile;
using CharacterAPI;

namespace BRC_Candyman
{
	[BepInPlugin(ModGuid, ModName, ModVer)]
	[BepInDependency("com.Viliger.CharacterAPI")]

	public class Plugin : BaseUnityPlugin
	{
		public const string ModGuid = "com.MandM.BRC-Candyman";
		public const string ModName = "BRC-Candyman";
		public const string ModVer = "1.1.0";

		public void Awake()
		{
			AssetBundle bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Info.Location), "candy"));

			ModdedCharacterConstructor candy = new ModdedCharacterConstructor();
			candy.characterName = "Candyman";
			candy.characterPrefab = bundle.LoadAsset<GameObject>("candy");
			candy.defaultOutfit = 0;
			candy.defaultMoveStyle = MoveStyle.SKATEBOARD;
			candy.tempAudioBase = Characters.eightBallBoss;
			candy.freestyleType = ModdedCharacterConstructor.FreestyleType.freestyle12;
			candy.bounceType = ModdedCharacterConstructor.BounceType.softbounce1;

			candy.AddOutfit(bundle.LoadAsset<Material>("candyMat1.mat"), "Standard");
			candy.AddOutfit(bundle.LoadAsset<Material>("candyMat2.mat"), "Casino");
			candy.AddOutfit(bundle.LoadAsset<Material>("candyMat3.mat"), "Pastel");
			candy.AddOutfit(bundle.LoadAsset<Material>("candyMat4.mat"), "Saturate");

			//candy.AddPersonalGraffiti("Candyman", "N/A", bundle.LoadAsset<Material>("candyGraffiti.mat"), bundle.LoadAsset<Texture>("graffitiTexture.png"));
			candy.personalGraffitiBase = Characters.eightBall;

			candy.CreateModdedCharacter();
		}
	}
}
