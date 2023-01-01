#if INVECTOR_SHOOTER
using System.Collections.Generic;
using DaftAppleGames.Character;
using DaftAppleGames.Editor.Characters;
using Invector;
using Invector.vCharacterController;
using Invector.vCharacterController.vActions;
using Invector.vItemManager;
using Invector.vShooter;

using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Editor tool to configure a GameObject as a Player Character
/// </summary>
public class PlayerCharacterEditor : OdinEditorWindow
{
    [MenuItem("Window/Characters/Player Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(PlayerCharacterEditor));
    }

    [Header("Character Settings")]
    public PlayerCharacterSettings characterSettings;
    public GameObject playerGameObject;

    [Button("Configure Player")]
    private void ConfigurePlayer()
    {
        if (characterSettings != null && playerGameObject != null)
        {
            PlayerCharacter playerCharacter = playerGameObject.GetComponent<PlayerCharacter>();
            if (!playerCharacter)
            {
                playerCharacter = playerGameObject.AddComponent<PlayerCharacter>();
            }
            // Set up the character as required.
            playerCharacter.characterName = characterSettings.characterName;

            // Set up Audio
            AudioSource audioSource = playerGameObject.GetComponent<AudioSource>();
            if (!audioSource)
            {
                audioSource = playerGameObject.AddComponent<AudioSource>();
            }
            audioSource.outputAudioMixerGroup = characterSettings.audioMixerGroup;

            // Set up movement properties
            vThirdPersonController controller = playerGameObject.GetComponent<vThirdPersonController>();
            if (!controller)
            {
                controller = playerGameObject.GetComponent<vThirdPersonController>();
            }

            controller.freeSpeed.walkSpeed = characterSettings.walkSpeed;
            controller.freeSpeed.runningSpeed = characterSettings.runSpeed;
            controller.freeSpeed.sprintSpeed = characterSettings.sprintSpeed;
            controller.freeSpeed.crouchSpeed = characterSettings.crouchSpeed;

            controller.freeSpeed.rotationSpeed = characterSettings.rotationSpeed;
            controller.freeSpeed.movementSmooth = characterSettings.movementSmooth;

            controller.strafeSpeed.walkSpeed = characterSettings.strafeWalkSpeed;
            controller.strafeSpeed.runningSpeed = characterSettings.strafeRunSpeed;
            controller.strafeSpeed.sprintSpeed = characterSettings.strafeSprintSpeed;
            controller.strafeSpeed.crouchSpeed = characterSettings.strafeCrouchSpeed;

            controller.leanSmooth = characterSettings.leanSmooth;

            // Set up stamina and health
            controller.maxHealth = (int)characterSettings.maxHealth;
            controller.maxStamina = (int)characterSettings.maxStamina;
            controller.healthRecovery = characterSettings.healthRecovery;
            controller.healthRecoveryDelay = characterSettings.healthRecoveryDelay;
            controller.staminaRecovery = characterSettings.staminaRecovery;
            controller.jumpStamina = characterSettings.jumpStamina;
            controller.rollStamina = characterSettings.rollStamina;

            // Set up grounded
            controller.groundLayer = characterSettings.groundedLayer;
            controller.useSnapGround = characterSettings.useSnapGround;
            controller.useSlopeLimit = characterSettings.useSlopeLimit;
            controller.slopeLimit = 45.0f;

            // Set up swimming properties
            vSwimming swimming = playerGameObject.GetComponent<vSwimming>();
            if (!swimming)
            {
                swimming = playerGameObject.AddComponent<vSwimming>();
            }
            swimming.swimForwardSpeed = characterSettings.swimForwardSpeed;
            swimming.swimUpSpeed = characterSettings.swimUpSpeed;
            swimming.swimDownSpeed = characterSettings.swimDownSpeed;
            swimming.swimRotationSpeed = characterSettings.swimRotationSpeed;

            swimming.swimUpDownSmooth = characterSettings.swimUpAndDownSmooth;
            swimming.stamina = characterSettings.swimStamina;
            swimming.healthConsumption = (int)characterSettings.swimHealthConsumption;

            // Set up Melle and Shooter config
            vShooterManager shooterManager = playerGameObject.GetComponent<vShooterManager>();
            if (!shooterManager)
            {
                shooterManager = playerGameObject.AddComponent<vShooterManager>();
            }

            shooterManager.damageLayer = characterSettings.damageLayer;
            shooterManager.ignoreTags = characterSettings.ignoreTags;
            shooterManager.blockAimLayer = characterSettings.blockAimLayer;
            shooterManager.AllAmmoInfinity = characterSettings.infiniteAmmo;
            shooterManager.useAmmoDisplay = characterSettings.useAmmoDisplay;

            vAmmoManager ammoManager = playerGameObject.GetComponent<vAmmoManager>();
            if (!ammoManager)
            {
                ammoManager = playerGameObject.AddComponent<vAmmoManager>();
            }
            ammoManager.ammoListData = characterSettings.ammoListData;

            // Set up headtrack
            vHeadTrack headTrack = playerGameObject.GetComponent<vHeadTrack>();
            if (!headTrack)
            {
                headTrack = playerGameObject.AddComponent<vHeadTrack>();
            }

            headTrack.obstacleLayer = characterSettings.headTrackObstacleLayer;
            headTrack.distanceToDetect = characterSettings.headTrackDistanceToDetect;

            vFootStep footStep = playerGameObject.GetComponent<vFootStep>();
            if (!footStep)
            {
                footStep = playerGameObject.AddComponent<vFootStep>();
            }

            footStep.defaultSurface = characterSettings.defaultAudioSurface;
            footStep.customSurfaces = new List<vAudioSurface>(characterSettings.customAudioSurfaces);

            footStep.enabled = characterSettings.useFootsteps;

            // Set up Inventory
            vItemManager itemManager = playerGameObject.GetComponent<vItemManager>();
            if (!itemManager)
            {
                itemManager = playerGameObject.AddComponent<vItemManager>();
            }
            itemManager.itemListData = characterSettings.inventoryItemListData;

            // Set up damage effects
            vHitDamageParticle hitDamage = playerGameObject.GetComponent<vHitDamageParticle>();
            if (!hitDamage)
            {
                hitDamage = playerGameObject.AddComponent<vHitDamageParticle>();
            }
            hitDamage.defaultDamageEffects.Clear();
            hitDamage.defaultDamageEffects = new List<GameObject>(characterSettings.defaultDamageEffects);
        }
    }
}
#endif