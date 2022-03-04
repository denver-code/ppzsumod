using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using UnityEngine.UI;

namespace Armor
{
    public class Mod
    {
        public static void Main()
        {
CategoryBuilder.Create("YKA", "This mod adds Russian military loadouts (some of them are from COD)", ModAPI.LoadSprite("category icon.png"));       


 // ModAPI.Register(
 //                new Modification()
 //                {
 //                    OriginalItem = ModAPI.FindSpawnable("Human"), 
 //                    NameOverride = "Soldat YK", 
 //                    DescriptionOverride = "Hello", 
 //                    CategoryOverride = ModAPI.FindCategory("YKA"), 
 //                    ThumbnailOverride = ModAPI.LoadSprite("icn/f.png"),
 //                    AfterSpawn = (Instance) => 
 //                    {
 //                        var person = Instance.GetComponent<PersonBehaviour>();

 //                        var Head = Instance.transform.Find("Head").gameObject;

 //                        Head.GetOrAddComponent<MultipleSpriteHumanBehaviour>().person = person;
 //                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Scale = 30;
 //                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Textures = new Texture2D[]
 //                        {
 //                            ModAPI.LoadTexture("Outfit/5.png"),
 //                        };
 //                    }
 //                }
 //            );

  ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "UA Forces solider",
                    DescriptionOverride = "You know things have gotten serious when these guys show up...",
                    CategoryOverride = ModAPI.FindCategory("YKA"),
                    ThumbnailOverride = ModAPI.LoadSprite("icon/solider.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Outfit/solider.png");
                        Instance.GetComponent<PersonBehaviour>().SetBodyTextures(skin);
                    }
                }
            );

  ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "UA TrO Solider",
                    DescriptionOverride = "You know things have gotten serious when these guys show up...",
                    CategoryOverride = ModAPI.FindCategory("YKA"),
                    ThumbnailOverride = ModAPI.LoadSprite("icon/tro.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Outfit/tro.png");
                        Instance.GetComponent<PersonBehaviour>().SetBodyTextures(skin);
                    }
                }
            );


  ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"),
                    NameOverride = "Kyiv Ghost",
                    DescriptionOverride = "You know things have gotten serious when these guys show up...",
                    CategoryOverride = ModAPI.FindCategory("YKA"),
                    ThumbnailOverride = ModAPI.LoadSprite("icon/kghost.png"),
                    AfterSpawn = (Instance) =>
                    {
                        var skin = ModAPI.LoadTexture("Outfit/kghost.png");
                        Instance.GetComponent<PersonBehaviour>().SetBodyTextures(skin);
                    }
                }
            );

ModAPI.Register(
				new Modification()
				{
                    OriginalItem = ModAPI.FindSpawnable("Pistol"),
                    NameOverride = "Makarov Pistolet",
                    DescriptionOverride = " ",
                    CategoryOverride = ModAPI.FindCategory("YKA"),
                    ThumbnailOverride = ModAPI.LoadSprite("icn/MP.png"),
                    AfterSpawn = (Instance) =>
                    {                      
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("weapon/MP.png", 5f);
                        Instance.GetComponent<FirearmBehaviour>().barrelPosition = new Vector2(0.2f, 0.086f);
                        foreach (var c in Instance.GetComponents<Collider2D>())
                        {
                            GameObject.Destroy(c);
						}
                        Instance.FixColliders();
                        Instance.GetComponent<FirearmBehaviour>().BulletsPerShot = 1;

                        var firearm = Instance.GetComponent<FirearmBehaviour>();

                        firearm.ShotSounds = new AudioClip[]
                        {
                ModAPI.LoadSound("sfx/MP.wav"),
                        };

                        Cartridge customCartridge = ModAPI.FindCartridge("9.9x19mm");
                        customCartridge.name = "MP";
                        customCartridge.Damage = 3f;
                        customCartridge.Recoil = 0.1f;
                        customCartridge.ImpactForce = 0.2f;
                        firearm.Cartridge = customCartridge;
		    }
                }
            );
 ModAPI.Register(
				new Modification()
				{
                    OriginalItem = ModAPI.FindSpawnable("M1 Garand"),
                    NameOverride = "AK 74",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("YKA"),
                    ThumbnailOverride = ModAPI.LoadSprite("icn/AK74M.png"),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("weapon/AK74M.png", 4f);
                        Instance.GetComponent<FirearmBehaviour>().barrelPosition = new Vector2(0.67f, 0.17f);
                        foreach (var c in Instance.GetComponents<Collider2D>())
                        {
                            GameObject.Destroy(c);
						}
                        Instance.FixColliders();
                        Instance.GetComponent<FirearmBehaviour>().BulletsPerShot = 1;

                        var firearm = Instance.GetComponent<FirearmBehaviour>();
                        Instance.GetComponent<FirearmBehaviour>().Automatic = true;
                        Instance.GetComponent<FirearmBehaviour>().AutomaticFireInterval = 0.1f;

                        firearm.ShotSounds = new AudioClip[]
                        {
                ModAPI.LoadSound("sfx/AK74M.wav"),
                        };

                        Cartridge customCartridge = ModAPI.FindCartridge("9.9x19mm");
                        customCartridge.name = "AS VAL";
                        customCartridge.Damage = 7f;
                        customCartridge.Recoil = 0.1f;
                        customCartridge.ImpactForce = 0.2f;
                        firearm.Cartridge = customCartridge;
		    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Bowling Pin"), 
                    NameOverride = "Basic Helmet", 
                    DescriptionOverride = "", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/6b47.png"), 
                    AfterSpawn = (Instance) => 
                    {   
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Helmet/6b47.png", 3f); 
                        int PartCount = 1;
                        Instance.GetOrAddComponent<ArmorBehaviour>();
                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        prop.armorPiece = "Head";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Helmet/6b47.png", 3f);
                        prop.armorPoints = 300;
                        prop.offset = new Vector2(0f, 2f) * ModAPI.PixelSize;
                        armor.prop = prop;
                        armor.SetProperties();

                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                        }
                        Instance.FixColliders();
                    }
                }
            );


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Bowling Pin"), 
                    NameOverride = "ZSU Helem", 
                    DescriptionOverride = "", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/zsuhelem.png"), 
                    AfterSpawn = (Instance) => 
                    {   
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Helmet/zsuhelem.png", 3f); 
                        int PartCount = 1;
                        Instance.GetOrAddComponent<ArmorBehaviour>();
                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        prop.armorPiece = "Head";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Helmet/zsuhelem.png", 3f);
                        prop.armorPoints = 300;
                        prop.offset = new Vector2(0f, 2f) * ModAPI.PixelSize;
                        armor.prop = prop;
                        armor.SetProperties();

                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                        }
                        Instance.FixColliders();
                    }
                }
            );

    ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "Bronijelet", 
                    DescriptionOverride = " ", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/12.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/6b45 with 6sh117 3.png", 3); 

                        int PartCount = 3;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);                  
                        prop.armorPiece = "UpperBody";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/6b45 with 6sh117 3.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();
                        
                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/6b45 with 6sh117 2.png", 3);
                        armProp[0].armorPiece = "MiddleBody";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;

                        armProp[1].sprite = ModAPI.LoadSprite("Armor/6b45 with 6sh117 1.png", 3);
                        armProp[1].armorPiece = "LowerBody";
                        armProp[1].offset = offset;
                        armProp[1].armorTier = 2;
                        armProp[1].scaleOffset = scaleOffset;
                        armProp[1].armorPoints = 250;

                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 1", 
                    DescriptionOverride = "Soldat", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/Sol.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/Sol.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/Sol.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );


 ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 2", 
                    DescriptionOverride = "St.Soldat", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/H.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/H.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/H.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

 ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 3", 
                    DescriptionOverride = "Kapral", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/Kapral.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/Kapral.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/Kapral.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

 ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 4", 
                    DescriptionOverride = "Serjant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/S.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/S.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/S.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

 ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 5", 
                    DescriptionOverride = "St.Serjant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/StSer.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/StSer.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/StSer.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 6", 
                    DescriptionOverride = "Gl.Serjant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/GS.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/GS.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/GS.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 7", 
                    DescriptionOverride = "Shtab.Serjant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/SS.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/SS.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/SS.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 8", 
                    DescriptionOverride = "GlShtab.Serjant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/GSS.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/GSS.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/GSS.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 9", 
                    DescriptionOverride = "Master.Serjant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/MS.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/MS.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/MS.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 10", 
                    DescriptionOverride = "Gl.Master.Serjant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/GMS.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/GMS.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/GMS.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 11", 
                    DescriptionOverride = "Khorunzhyi", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/H.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/H.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/H.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 12", 
                    DescriptionOverride = "Leitenant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/L.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/L.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/L.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 13", 
                    DescriptionOverride = "St.Leitenant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/StL.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/StL.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/StL.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 14", 
                    DescriptionOverride = "Kapitan", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/Kap.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/Kap.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/Kap.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );
 


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 15", 
                    DescriptionOverride = "Maior", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/M.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/M.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/M.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 16", 
                    DescriptionOverride = "Pod.Polkovnik", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/PP.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/PP.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/PP.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 17", 
                    DescriptionOverride = "Polkovnil", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/P.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/P.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/P.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 18", 
                    DescriptionOverride = "General Brigadier", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/BG.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/BG.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/BG.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 19", 
                    DescriptionOverride = "General Maior", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/GM.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/GM.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/GM.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 20", 
                    DescriptionOverride = "General Leitenant", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/GL.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/GL.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/GL.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 21", 
                    DescriptionOverride = "General Polkovnik", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/GP.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/GP.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/GP.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );


ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"), 
                    NameOverride = "PogonYK 22", 
                    DescriptionOverride = "General Armii YK", 
                    CategoryOverride = ModAPI.FindCategory("YKA"), 
                    ThumbnailOverride = ModAPI.LoadSprite("icon/1.png"), 
                    AfterSpawn = (Instance) => 
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Armor/GAY.png", 15);
int PartCount = 2;

                        if (!Instance.GetComponent<ArmorBehaviour>())
                            Instance.AddComponent<ArmorBehaviour>();

                        ArmorBehaviour armor = Instance.GetComponent<ArmorBehaviour>();
                        ArmorProperties prop = new ArmorProperties();
                        Vector3 offset = new Vector3(0f, 0f);
                        Vector3 scaleOffset = new Vector3(0f, 0f);
                        prop.armorPiece = "UpperArm";
                        prop.armorTier = 3;
                        prop.sprite = ModAPI.LoadSprite("Armor/GAY.png", 3);
                        prop.offset = offset;
                        prop.scaleOffset = scaleOffset;
                        prop.armorPoints = 350;
                        armor.prop = prop;
                        armor.SetProperties();

                        ArmorProperties[] armProp = new ArmorProperties[PartCount - 1];

                        armProp[0].sprite = ModAPI.LoadSprite("Armor/GAY.png", 3);
                        armProp[0].armorPiece = "UpperArmFront";
                        armProp[0].offset = offset;
                        armProp[0].armorTier = 2;
                        armProp[0].scaleOffset = scaleOffset;
                        armProp[0].armorPoints = 350;


                        if (armor.spawn)
                        {
                            armor.SetPieces = new ArmorBehaviour[PartCount - 1];
                            armor.SpawnOtherParts(armProp);
                        }

                        Instance.FixColliders();
                    }
                }
            );

           }












public class MultipleSpriteHumanBehaviour : MonoBehaviour
    {
        public Texture2D[] Textures = new Texture2D[0];
        public PersonBehaviour person;
        public int CurrentTexture = -2;
        public int Scale = 3;

        void Start()
        {
            SetTexture();
        }

        public void SetTexture()
        {
            if (Textures.Length == 0)
                return;

            if(CurrentTexture == -2)
            {
                CurrentTexture = UnityEngine.Random.Range(0, Textures.Length);
            }
            person.SetBodyTextures(Textures[CurrentTexture], null, null, Scale);
            for (int i = 0; i < person.Limbs.Length; i++)
            {
                person.Limbs[i].gameObject.GetComponent<PhysicalBehaviour>().RefreshOutline();
            }
        }
}    }
}
