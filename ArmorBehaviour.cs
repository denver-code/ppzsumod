using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Armor
{
    public class ArmorBehaviour : MonoBehaviour
    {
        // note i have no idea how to code

        private bool equipped;
        [SerializeField]
        public ArmorProperties prop;
        public string armorPiece;
        public int armorTier;
        public float stabResistance;
        private bool blockingStab;

        [SerializeField]
        // tarkov!
        public float armorPoints;
        public float initialPoints;
        [SerializeField]
        public bool durabilityDisabled = false;
        [SerializeField]
        public int modifiedTier = -1;
        [SerializeField]
        public float modifiedDurability = -1;

        public bool damaged;
        public float shrapnelChance;
        public bool destroyed;
        [SerializeField]
        public float initialAbsorb = -1;

        public Vector3 offset;
        public Vector3 scaleOffset = new Vector3(1, 1, 1);

        public ArmorBehaviour[] SetPieces = new ArmorBehaviour[0];
        public int pieceCount;

        // not functional.
        public bool prosthetic;

        [SerializeField]
        public LimbBehaviour attachedLimb;

        [SerializeField]
        public bool spawn = true;
        [SerializeField]
        public Color color;
        [SerializeField]
        public bool changedColor;
        [SerializeField]
        public bool decorative;
        [SerializeField]
        public bool grayScale;

        // broken do not use
        [SerializeField]
        public bool visual;
        
        [SerializeField]
        public bool visor;
        public GameObject visorObject;
        public bool visorDown;
        [SerializeField]
        public int visorPoints;
        public bool canInteract = true;

        public bool debug;

        // armor areas!
        public bool head, nape, face, eyes;
        [SerializeField]
        public List<Attachment> attachments;
        int modify;

        void Start()
        {
            if (!damaged)
                armorPoints = initialPoints;
            SetProperties();
            ContextMenu();
            GetComponent<PhysicalBehaviour>().RefreshOutline();
            if (attachedLimb)
            {
                Attach(attachedLimb);
            }
            if (changedColor)
                ApplyColor(color);
            GetComponent<PhysicalBehaviour>().HoldingPositions = new Vector3[0];
            if (prop.debug)
            {
                foreach (Vector2 point in GetComponent<PolygonCollider2D>().points)
                    ModAPI.Notify(prop.sprite + point.ToString());
            }
        }
        void OnWillRenderObject()
        {
            if (!debug)
                return;
            foreach (Collider2D component in GetComponents<Collider2D>())
                ModAPI.Draw.Collider(component);
        }
        void Update()
        {
            if (equipped && GetComponent<FixedJoint2D>().connectedBody.gameObject.GetComponent<GripBehaviour>() && GetComponent<FixedJoint2D>().connectedBody.gameObject.GetComponent<GripBehaviour>().CurrentlyHolding)
            {
                GripBehaviour grip = GetComponent<FixedJoint2D>().connectedBody.gameObject.GetComponent<GripBehaviour>();
                Nocollide(grip.CurrentlyHolding.gameObject);
            }
            armorPoints = Mathf.Clamp(armorPoints, 0, Mathf.Infinity);
        }
        public void ApplyColor(Color color)
        {
            GetComponent<SpriteRenderer>().color = color;
        }
        public void ApplyTier()
        {
            Debug.Log("Tier of " + gameObject.name + " applied.");
            PhysicalBehaviour phys = GetComponent<PhysicalBehaviour>();
            //PhysicalProperties prop = phys.Properties;
            PhysicalProperties prop = ScriptableObject.CreateInstance<PhysicalProperties>();
            PhysicalProperties metal = ModAPI.FindPhysicalProperties("Metal");
            PhysicalProperties bowling = ModAPI.FindPhysicalProperties("Bowling pin");
            switch (armorTier)
            {
                case 0:
                    prop.Softness = 1;
                    prop.Brittleness = 1;
                    shrapnelChance = .15f;
                    if (initialAbsorb == -1)
                        initialAbsorb = prop.BulletSpeedAbsorptionPower;
                    UpdateDamage();
                    break;
                case 1:
                    prop.Softness = 0f;
                    prop.Brittleness = 0f;
                    prop.BulletSpeedAbsorptionPower = 0.5f;
                    SetPhysicalProperties(prop, bowling, phys);
                    shrapnelChance = .005f;
                    if (initialAbsorb == -1)
                        initialAbsorb = prop.BulletSpeedAbsorptionPower;
                    UpdateDamage();
                    break;
                case 2:
                    prop.Softness = 0f;
                    prop.Brittleness = 0f;
                    prop.BulletSpeedAbsorptionPower = 2f;
                    SetPhysicalProperties(prop, bowling, phys);
                    shrapnelChance = .02f;
                    if (initialAbsorb == -1)
                        initialAbsorb = prop.BulletSpeedAbsorptionPower;
                    UpdateDamage();
                    break;
                case 31:
                    // alternate tier 3 not 31
                    prop.Softness = 0f;
                    prop.Brittleness = 0f;
                    prop.BulletSpeedAbsorptionPower = 2.5f;
                    SetPhysicalProperties(prop, bowling, phys);
                    shrapnelChance = .075f;
                    if (initialAbsorb == -1)
                        initialAbsorb = prop.BulletSpeedAbsorptionPower;
                    UpdateDamage();
                    break;
                case 3:
                    prop.Softness = 0f;
                    prop.Brittleness = 0f;
                    prop.BulletSpeedAbsorptionPower = 3f;
                    SetPhysicalProperties(prop, metal, phys);
                    shrapnelChance = .1f;
                    if (initialAbsorb == -1)
                        initialAbsorb = prop.BulletSpeedAbsorptionPower;
                    UpdateDamage();
                    break;
                case 4:
                    //prop = ModAPI.FindPhysicalProperties("Bowling pin");
                    prop.Softness = 0f;
                    prop.Brittleness = 0f;
                    prop.BulletSpeedAbsorptionPower = 3.5f;
                    SetPhysicalProperties(prop, bowling, phys);
                    shrapnelChance = .1f;
                    if (initialAbsorb == -1)
                        initialAbsorb = prop.BulletSpeedAbsorptionPower;
                    UpdateDamage();
                    break;
                default:
                    ModAPI.Notify("Armor tier " + armorTier.ToString() + " does not exist.");
                    break;
            }
        }
        void SetPhysicalProperties(PhysicalProperties prop, PhysicalProperties p, PhysicalBehaviour phys)
        {
            prop.SoftImpact = p.SoftImpact;
            prop.HardImpact = p.HardImpact;
            prop.PhysicMaterial = p.PhysicMaterial;
            prop.SharpForceThresholdMultiplier = p.SharpForceThresholdMultiplier;
            prop.ImpactIntensityMutliplier = p.ImpactIntensityMutliplier;
            prop.HitVolumeMultiplier = p.HitVolumeMultiplier;
            prop.ShotImpact = p.ShotImpact;

            phys.Properties = prop;
        }
        public void SpawnAttachments()
        {
            if (!visorObject)
            {
                GameObject other = new GameObject("visor");
                GameObject pivot = new GameObject("visorPivot");
                other.AddComponent<SpriteRenderer>().sprite = prop.visorSprite;
                other.transform.parent = pivot.transform;
                other.transform.localRotation = Quaternion.Euler(0, 0, 0);
                other.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
                pivot.transform.parent = transform;
                pivot.transform.localScale = Vector3.one;
                pivot.transform.localRotation = Quaternion.Euler(0, 0, 0);
                pivot.transform.localPosition = prop.visorPosition;
                other.transform.position = transform.position;
                other.transform.localScale = Vector3.one;
                visorObject = pivot;
                if (!visorDown)
                    pivot.transform.localRotation = Quaternion.Euler(0, 0, 90);
                else
                    pivot.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        public void UpdateAttachments()
        {
            foreach (Attachment at in attachments)
            {
                if (!at.attachmentObject)
                {
                    GameObject att = new GameObject("attachment");
                    GameObject pivot = new GameObject("pivot");
                    //att.AddComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite(at.sprite);
                    att.transform.parent = pivot.transform;
                    att.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    att.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
                    pivot.transform.parent = transform;
                    pivot.transform.localPosition = at.position;
                    att.transform.position = transform.position;
                    at.attachmentObject = pivot;
                }
            }
        }
        public void UpdateColliders()
        {
            if (!GetComponent<CompositeCollider2D>())
                gameObject.AddComponent<CompositeCollider2D>();
            if (head)
            {
            }
        }
        public void SetProperties()
        {
            GetComponent<SpriteRenderer>().sprite = prop.sprite;
            armorPiece = prop.armorPiece;
            if (modifiedTier == -1)
                armorTier = prop.armorTier;
            else
                armorTier = modifiedTier;
            offset = prop.offset;
            visual = prop.visual;
            //shrapnelChance = prop.fragChance;
            if (modifiedDurability == -1)
                initialPoints = prop.armorPoints;
            else
                initialPoints = modifiedDurability;

            scaleOffset += prop.scaleOffset;

            if (GetComponent<Optout>())
                Destroy(GetComponent<Optout>());

            if (prop.mass != 0)
            {
                GetComponent<PhysicalBehaviour>().InitialMass = prop.mass;
                GetComponent<PhysicalBehaviour>().TrueInitialMass = prop.mass;
                GetComponent<PhysicalBehaviour>().rigidbody.mass = prop.mass;
            }
            ApplyTier();
            if (!prop.customCollider)
                gameObject.FixColliders();
            else
            {
                Destroy(GetComponent<BoxCollider2D>());
                gameObject.AddComponent<PolygonCollider2D>().points = prop.points;
            }
            if (prop.hasVisor)
                SpawnAttachments();
        }
        public void CloneSelf()
        {
            GameObject other = ModAPI.CreatePhysicalObject(gameObject.name, prop.sprite);

            other.AddComponent<SerialiseInstructions>().OriginalSpawnableAsset = ModAPI.FindSpawnable("Rod");
            other.transform.position = transform.position;

            PhysicalBehaviour phys = GetComponent<PhysicalBehaviour>();

            other.GetComponent<PhysicalBehaviour>().InitialMass = phys.InitialMass;
            other.GetComponent<PhysicalBehaviour>().TrueInitialMass = phys.TrueInitialMass;
            other.GetComponent<PhysicalBehaviour>().InitialGravityScale = phys.InitialGravityScale;
            other.GetComponent<PhysicalBehaviour>().rigidbody.mass = phys.rigidbody.mass;

            ArmorBehaviour otherArmor = other.AddComponent<ArmorBehaviour>();
            otherArmor.prop = prop;
            otherArmor.prop.armorPiece = prop.armorPiece + "Front";

            otherArmor.offset = offset;
            otherArmor.scaleOffset = scaleOffset;
            otherArmor.prosthetic = prosthetic;
            otherArmor.SetProperties();
        }
        public void SpawnOtherParts(ArmorProperties[] properties)
        {
            for (int I = 0; I <= SetPieces.Length - 1; I++)
            {
                GameObject other = ModAPI.CreatePhysicalObject(gameObject.name, GetComponent<SpriteRenderer>().sprite);
                other.transform.position = transform.position;
                other.AddComponent<SerialiseInstructions>().OriginalSpawnableAsset = ModAPI.FindSpawnable("Rod");

                PhysicalBehaviour phys = GetComponent<PhysicalBehaviour>();

                other.GetComponent<PhysicalBehaviour>().InitialMass = phys.InitialMass;
                other.GetComponent<PhysicalBehaviour>().TrueInitialMass = phys.TrueInitialMass;
                other.GetComponent<PhysicalBehaviour>().InitialGravityScale = phys.InitialGravityScale;
                other.GetComponent<PhysicalBehaviour>().rigidbody.mass = phys.rigidbody.mass;

                ArmorBehaviour otherArmor = other.AddComponent<ArmorBehaviour>();
                otherArmor.spawn = false;

                otherArmor.prop = prop;

                otherArmor.offset = offset;
                otherArmor.scaleOffset = scaleOffset;
                otherArmor.prosthetic = prosthetic;
                SetPieces[I] = otherArmor;
            }
            SetPartProperties(properties);
        }
        public void SetPartProperties(ArmorProperties[] properties)
        {
            spawn = false;
            int I = 0;
            foreach (ArmorBehaviour armor in SetPieces)
            {
                armor.prop = properties[I];
                I++;
                armor.SetProperties();
                if (armor.prop.clone)
                    armor.CloneSelf();
            }
        }
        public void UpdateDamage()
        {
            if (durabilityDisabled == true)
                return;
            PhysicalProperties prop = GetComponent<PhysicalBehaviour>().Properties;
            if (armorPoints == 0)
            {
                gameObject.layer = 10;
                destroyed = true;
            }
            else
            {
                gameObject.layer = 9;
                destroyed = false;
            }
            if (damaged && !destroyed)
            {
                prop.BulletSpeedAbsorptionPower = initialAbsorb * (armorPoints / initialPoints);
                prop.Softness = 1 * ((initialPoints / armorPoints) / initialPoints);
                prop.Brittleness = 1 * ((initialPoints / armorPoints) / initialPoints);
            }
            if (armorPoints == initialPoints)
                damaged = false;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!decorative && !prop.isVisor)
            {
                LimbBehaviour limb = collision.gameObject.GetComponent<LimbBehaviour>();
                ArmorBehaviour arm = collision.gameObject.GetComponent<ArmorBehaviour>();
                if (arm)
                {
                    Nocollide(arm.gameObject);
                }
                if (limb)
                {
                    Nocollide(limb.gameObject);
                    // Bodypart sections are Torso, Head, Arms, and Legs
                    // Bodyparts are UpperBody, MiddleBody, LowerBody etc.
                    if (!equipped && limb.gameObject.name == armorPiece)
                    {
                        if (prosthetic)
                        {
                            Debug.Log("attachpros");
                            AttachProsthetic(limb);
                        }
                        else
                        {
                            Debug.Log("attach");
                            Attach(limb);
                        }
                    }
                }
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                //ModAPI.Notify(collision.gameObject.layer.ToString());
            }
        }
        public void Nocollide(GameObject col)
        {
            NoCollide noCol = gameObject.AddComponent<NoCollide>();
            noCol.NoCollideSetA = GetComponents<Collider2D>();
            noCol.NoCollideSetB = col.GetComponents<Collider2D>();
        }
        public void Attach(LimbBehaviour limb)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sortingOrder = limb.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
            sr.sortingLayerName = limb.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            equipped = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
            transform.parent = limb.transform;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.localPosition = offset;
            transform.localScale = scaleOffset;
            transform.parent = null;
            if (visorObject)
            {
                SpriteRenderer objsr = visorObject.GetComponentInChildren<SpriteRenderer>();
                objsr.sortingOrder = sr.sortingOrder + 1;
                objsr.sortingLayerName = sr.sortingLayerName;
            }
            if (!prop.visual)
            {
                FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
                joint.dampingRatio = 1;
                joint.frequency = 0;
                joint.connectedBody = limb.GetComponent<Rigidbody2D>();
            }
            if (prop.additional != "")
            {
                //int b = -1;
                //if (prop.a)
                //    b = 1;
                //GameObject ad = new GameObject("extra");
                //ad.transform.parent = transform;
                //ad.transform.localPosition = Vector3.zero;
                //ad.transform.localEulerAngles = Vector3.zero;
                //ad.AddComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite(prop.additional);
                //ad.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + b;
                //ad.GetComponent<SpriteRenderer>().sortingLayerName = limb.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            }
            GetComponent<Rigidbody2D>().isKinematic = false;
            attachedLimb = limb;
            if (visual)
                foreach (Component component in GetComponents(typeof(Component)))
                {
                    if (component != GetComponent<SpriteRenderer>() && component != GetComponent<Transform>())
                        Destroy(component);
                }
        }
        public void Detach(LimbBehaviour limb)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            equipped = false;
            foreach (FixedJoint2D joint in GetComponents<FixedJoint2D>())
            {
                if (joint.connectedBody = limb.gameObject.GetComponent<Rigidbody2D>())
                    Destroy(joint);
            }
            attachedLimb = null;
        }
        public void AttachProsthetic(LimbBehaviour limb)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sortingOrder = limb.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
            sr.sortingLayerName = limb.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            equipped = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
            transform.parent = limb.transform;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.localPosition = offset;
            transform.localScale = scaleOffset;
            transform.parent = null;
            GetComponent<Rigidbody2D>().isKinematic = false;

            HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedBody = limb.GetComponent<Rigidbody2D>();
            joint.connectedAnchor = new Vector3(0, -.2f, 0);
            joint.anchor = new Vector3(0, .2f, 0);

            joint.useLimits = true;
            JointAngleLimits2D limits = joint.limits;
            limits.min = -120;
            limits.max = 0;
            joint.limits = limits;

            limb = attachedLimb;
        }
        void Shot(global::Shot shot)
        {
            armorPoints -= shot.damage / 10;
            if (attachedLimb)
            {
                attachedLimb.Damage(shot.damage / 80);
                attachedLimb.SkinMaterialHandler.ImpactDamage(shot.damage / 15, shot.point, false);
            }
            damaged = true;
            armorPoints = Mathf.Clamp(armorPoints, 0, Mathf.Infinity);
            UpdateDamage();
        }
        void ExitShot(global::Shot shot)
        {
            armorPoints -= shot.damage / 10f;
            damaged = true;
            armorPoints = Mathf.Clamp(armorPoints, 0, Mathf.Infinity);
            UpdateDamage();
        }
        void Use()
        {
            if (!prop.hasVisor || !canInteract)
                return;
            ToggleVisor();
        }
        void ToggleVisor()
        {
            if (!GetComponent<BoxCollider2D>())
                gameObject.AddComponent<BoxCollider2D>().enabled = false;
            BoxCollider2D box = GetComponent<BoxCollider2D>();
            if (!visorDown)
            {
                box.enabled = true;
                foreach(PolygonCollider2D poly in GetComponents<PolygonCollider2D>())
                    poly.enabled = false;
                StartCoroutine(FlipVisor(Quaternion.Euler(0, 0, 0)));
                visorDown = true;
            }
            else
            {
                box.enabled = false;
                foreach(PolygonCollider2D poly in GetComponents<PolygonCollider2D>())
                    poly.enabled = true;
                StartCoroutine(FlipVisor(Quaternion.Euler(0, 0, 90)));
                visorDown = false;
            }
        }
        public IEnumerator FlipVisor(Quaternion rot)
        {
            canInteract = false;
            float t = 0;
            while (visorObject.transform.localRotation != rot)
            {
                visorObject.transform.localRotation = Quaternion.RotateTowards(visorObject.transform.localRotation, rot, Time.deltaTime * 90);
                t += Time.deltaTime;
                if (t >= 1)
                    visorObject.transform.localRotation = rot;
                yield return null;
            }
            canInteract = true;
        }
        void ContextMenu()
        {
            this.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("selectbutt", "Change color", "Change the color of the armor.", new UnityAction[1]
            {
            (UnityAction) (() =>
        {
            DialogBox dialog = (DialogBox) null;
            dialog = DialogBoxManager.TextEntry("Change the color of the object. Values reach to 256.", "R, G, B", new DialogButton("Apply", true, new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    if (dialog.EnteredText != "")
                    {;
                        var text = dialog.EnteredText.Split(", "[0]);
                        ModAPI.Notify("Color set to " + dialog.EnteredText);
                        Color col = new Color();
                        color.r = float.Parse(text[0]) / 256;
                        color.g = float.Parse(text[1]) / 256;
                        color.b = float.Parse(text[2]) / 256;
                        color.a = 1;
                        //color = col;
                        changedColor = true;
                        ApplyColor(color);
                    }
                    else
                        ModAPI.Notify("You didn't input anything.");
                })
            }),
            new DialogButton("Cancel", true, new UnityAction[1]
            {
                    (UnityAction) (() => dialog.Close())
            }));
                })
                }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("moddurabbut", "Modify durability", "Modify or disable the durability of the armor.", new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    DialogBox dialog = (DialogBox) null;
                    dialog = DialogBoxManager.TextEntry("Change the durability. Durability cannot be less than 0. This will automatically repair the armor to match the inputted durability.", "Input durability", new DialogButton("Apply", true, new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    if (dialog.EnteredText != "")
                    {;
                        float num = float.Parse(dialog.EnteredText);
                        if (num > 0)
                        {
                            modifiedDurability = num;
                            initialPoints = num;
                            armorPoints = initialPoints;
                            UpdateDamage();
                        }
                        else
                            ModAPI.Notify("That is not a valid value!");
                    }
                    else
                        ModAPI.Notify("You didn't input anything.");
                })
            }),
            new DialogButton("Disable durability.", true, new UnityAction[1]
            {
                    (UnityAction) (() =>
                    {
                        durabilityDisabled = true;
                    })
            }),
            new DialogButton("Cancel", true, new UnityAction[1]
            {
                    (UnityAction) (() => dialog.Close())
            }));
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("modtierbut", "Modify tier", "Modify the tier of the armor.", new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    DialogBox dialog = (DialogBox) null;
            dialog = DialogBoxManager.TextEntry("Change the armor tier. 0 is the lowest and 4 is the highest. 31 is alternate 3. Current tier is " + armorTier, "0 - 4 or 31", new DialogButton("Apply", true, new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    if (dialog.EnteredText != "")
                    {;
                        int num = int.Parse(dialog.EnteredText);
                        if (num >= 0 && num <= 4 || num == 31)
                        {
                            armorTier = num;
                            modifiedTier = num;
                            ApplyTier();
                        }
                        else
                            ModAPI.Notify("That is not a valid tier!");
                    }
                    else
                        ModAPI.Notify("You didn't input anything.");
                })
            }),
            new DialogButton("Cancel", true, new UnityAction[1]
            {
                    (UnityAction) (() => dialog.Close())
            }));
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("decoratebut", (Func<string>)(() => !this.decorative ? "Switch to decorative" : "Switch to functional"), "Switch between decorative and functional.", new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    if (!decorative)
                    {
                        decorative = true;
                        Detach(attachedLimb);
                        foreach(NoCollide nocol in GetComponents<NoCollide>())
                        {
                            Destroy(nocol);
                        }
                    }
                    else
                        decorative = false;
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("detachbut", "Detach armor", "Detach the armor from whatever it is equipped on.", new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    if (attachedLimb)
                        Detach(attachedLimb);
                    else
                        ModAPI.Notify("The armor is not attached to anything");
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("sortplusbut", "Bring forward", "Bring the sprite of the armor forward.", new UnityAction[1]
            {
                (UnityAction) (() => GetComponent<SpriteRenderer>().sortingOrder++)
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("sortminusbut", "Bring back", "Bring the sprite of the armor back.", new UnityAction[1]
            {
                (UnityAction) (() => GetComponent<SpriteRenderer>().sortingOrder--)
            }));
            //GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("graybut", "Set to grayscale", "Change ths sprite to the grayscale varient (if it has one)", new UnityAction[1]
            //{
            //    (UnityAction) (() =>
            //    {
            //        grayScale = true;
            //        GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite(prop.graySprite);
            //    })
            //}));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("chekbut", "Check armor quality", "Check how damaged the armor is.", new UnityAction[1]
            {
                (UnityAction) (() => 
                {
                    if (armorPoints != 0)
                        ModAPI.Notify("Armor points " + Mathf.Round(armorPoints * 10) / 10 + " / " + initialPoints);
                    else
                        ModAPI.Notify("<color=red>Armor points 0 / " + initialPoints + "</color>");
                })
            }));
            GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("repbut", "Repair armor", "Repair the armor.", new UnityAction[1]
            {
                (UnityAction) (() =>
                {
                    armorPoints = initialPoints;
                    UpdateDamage();
                    ModAPI.Notify("Armor repaired!");
                })
            }));
        }
    }
    
    // ik about scrippable objects now btu im too lazy to fix this
    public struct ArmorProperties
    {
        public Sprite sprite;
        public string armorPiece;
        public int armorTier;
        public float mass;
        public bool clone;
        public Vector3 offset;
        public Vector3 scaleOffset;
        public string graySprite;

        // do not use these three
        public bool visual;
        public string additional;
        public bool a;

        public float fragChance;
        public float armorPoints;

        public Sprite visorSprite;
        public Vector2 visorPosition;
        public bool hasVisor;
        public bool isVisor;
        public int visorTier;
        public int visorPoints;

        public bool customCollider;
        public Vector2[] points;

        public bool debug;
    }
    public class Attachment : ScriptableObject
    {
        public string sprite;
        public Vector2 position;
        public float points;
        public bool head, nape, face, eyes;
        public bool toggleable;
        public GameObject attachmentObject;
    }
}