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

#if FOOTIK
using HoaxGames;
#endif

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
            // Add "Player Character" component
            LogStartComponent("PlayerCharacter");
            PlayerCharacter playerCharacter = playerGameObject.GetComponent<PlayerCharacter>();
            if (!playerCharacter)
            {
                playerCharacter = playerGameObject.AddComponent<PlayerCharacter>();
                LogAddComponent("PlayerCharacter");
            }
            LogDoneComponent("Player Character");

            // Set up the character as required.
            playerCharacter.characterName = characterSettings.characterName;

            // Set up Audio
            LogStartComponent("AudioSource");
            AudioSource audioSource = playerGameObject.GetComponent<AudioSource>();
            if (!audioSource)
            {
                audioSource = playerGameObject.AddComponent<AudioSource>();
                LogAddComponent("AudioSource");
            }
            audioSource.outputAudioMixerGroup = characterSettings.audioMixerGroup;
            LogDoneComponent("AudioSource");

            // Set up movement properties
            LogStartComponent("vThirdPersonController");
            vThirdPersonController controller = playerGameObject.GetComponent<vThirdPersonController>();
            if (!controller)
            {
                controller = playerGameObject.GetComponent<vThirdPersonController>();
                LogAddComponent("vThirdPersonController");
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

            controller.useLeanMovementAnim = characterSettings.useLeanAnim;
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

            // Stop layer
            controller.stopMoveLayer = characterSettings.stopMoveLayer;

            // Step
            controller.stepOffsetLayer = characterSettings.stepOffsetLayer;
            controller.stepOffsetMaxHeight = characterSettings.stepOffsetMaxHeight;
            controller.stepOffsetMinHeight = characterSettings.stepOffsetMinHeight;
            controller.stepOffsetDistance = characterSettings.stepOffsetDistance;

            // Slope
            controller.useSlopeLimit = characterSettings.useSlopeLimit;
            controller.slopeLimit = 45.0f;
            LogDoneComponent("vThirdPersonController");

            // Set up swimming properties
            LogStartComponent("vSwimming");
            vSwimming swimming = playerGameObject.GetComponent<vSwimming>();
            if (!swimming)
            {
                swimming = playerGameObject.AddComponent<vSwimming>();
                LogAddComponent("vSwimming");
            }
            swimming.swimForwardSpeed = characterSettings.swimForwardSpeed;
            swimming.swimUpSpeed = characterSettings.swimUpSpeed;
            swimming.swimDownSpeed = characterSettings.swimDownSpeed;
            swimming.swimRotationSpeed = characterSettings.swimRotationSpeed;

            swimming.swimUpDownSmooth = characterSettings.swimUpAndDownSmooth;
            swimming.stamina = characterSettings.swimStamina;
            swimming.healthConsumption = (int)characterSettings.swimHealthConsumption;
            LogDoneComponent("vSwimming");

            // Set up Melle and Shooter config
            LogStartComponent("vShooterManager");
            vShooterManager shooterManager = playerGameObject.GetComponent<vShooterManager>();
            if (!shooterManager)
            {
                shooterManager = playerGameObject.AddComponent<vShooterManager>();
                LogAddComponent("vShooterManager");
            }

            shooterManager.damageLayer = characterSettings.damageLayer;
            shooterManager.ignoreTags = characterSettings.ignoreTags;
            shooterManager.blockAimLayer = characterSettings.blockAimLayer;
            shooterManager.AllAmmoInfinity = characterSettings.infiniteAmmo;
            shooterManager.useAmmoDisplay = characterSettings.useAmmoDisplay;
            LogDoneComponent("vShooterManager");

            vAmmoManager ammoManager = playerGameObject.GetComponent<vAmmoManager>();
            if (!ammoManager)
            {
                ammoManager = playerGameObject.AddComponent<vAmmoManager>();
                LogAddComponent("vAmmoManager");
            }
            ammoManager.ammoListData = characterSettings.ammoListData;

            // Set up headtrack
            LogStartComponent("vHeadTrack");
            vHeadTrack headTrack = playerGameObject.GetComponent<vHeadTrack>();
            if (!headTrack)
            {
                headTrack = playerGameObject.AddComponent<vHeadTrack>();
                LogAddComponent("vHeadTrack");
            }

            headTrack.obstacleLayer = characterSettings.headTrackObstacleLayer;
            headTrack.distanceToDetect = characterSettings.headTrackDistanceToDetect;
            LogDoneComponent("vHeadTrack");

            // Set up footsteps
            LogStartComponent("vFootStep");
            vFootStep footStep = playerGameObject.GetComponent<vFootStep>();
            if (!footStep)
            {
                footStep = playerGameObject.AddComponent<vFootStep>();
                LogAddComponent("vFootStep");
            }

            footStep.defaultSurface = characterSettings.defaultAudioSurface;
            footStep.customSurfaces = new List<vAudioSurface>(characterSettings.customAudioSurfaces);
            footStep.enabled = characterSettings.useFootsteps;
            LogDoneComponent("vFootStep");

            // Set up Inventory
            LogStartComponent("vItemManager");
            vItemManager itemManager = playerGameObject.GetComponent<vItemManager>();
            if (!itemManager)
            {
                itemManager = playerGameObject.AddComponent<vItemManager>();
                LogAddComponent("vItemManager");
            }
            itemManager.itemListData = characterSettings.inventoryItemListData;
            LogDoneComponent("vItemManager");

            // Set up damage effects
            LogStartComponent("vHitDamageParticles");
            vHitDamageParticle hitDamage = playerGameObject.GetComponent<vHitDamageParticle>();
            if (!hitDamage)
            {
                hitDamage = playerGameObject.AddComponent<vHitDamageParticle>();
                LogAddComponent("vHitDamageParticle");
            }
            hitDamage.defaultDamageEffects.Clear();
            hitDamage.defaultDamageEffects = new List<GameObject>(characterSettings.defaultDamageEffects);
            LogDoneComponent("vHitDamageParticles");
#if FOOTIK
            // Set up Footstep
            LogStartComponent("FootIK");
            FootIK footIK = playerGameObject.GetComponent<FootIK>();
            if (!footIK)
            {
                footIK = playerGameObject.AddComponent<FootIK>();
                LogAddComponent("FootIK");
            }
            float test;
            string test2;

            test2 = characterSettings.forceActivateCrouchState;
            test = characterSettings.crouchCorrectionTollerance;
            test2 = characterSettings.invalidAnimationState1;
            test2 = characterSettings.invalidAnimationState2;
            test = characterSettings.ikMaxCorrection;
            test = characterSettings.increaseMaxCorrectionDistance;
            test = characterSettings.checkGroundRadius;
#endif
        }
    }

    /// <summary>
    /// Private logger - Start Component config
    /// </summary>
    /// <param name="componentName"></param>
    private void LogStartComponent(string componentName)
    {
        Debug.Log($"Configuring: {componentName}...");
    }

    /// <summary>
    /// Private logger - Done Component config
    /// </summary>
    /// <param name="componentName"></param>
    private void LogDoneComponent(string componentName)
    {
        Debug.Log($"Done configuring: {componentName}.");
    }

    /// <summary>
    /// Private logger - Add Component config
    /// </summary>
    /// <param name="componentName"></param>
    private void LogAddComponent(string componentName)
    {
        Debug.Log($"Addinmg missing component: {componentName}.");
    }

}
#endif