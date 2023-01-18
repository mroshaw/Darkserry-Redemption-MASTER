using DaftAppleGames.Common.Buildings;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Editor.AutoEditor.Buildings
{
    public class DoorAutoEditor : BaseAutoEditor
    {
        [Header("Door Settings")]
        public DoorPivotSide pivotSide = DoorPivotSide.Left;
        public bool swapTriggers = false;

        [Header("Door Trigger Settings")]
        public float colliderHeight = 1.0f; // y
        public float colliderWidth = 2.0f; // z
        public float colliderDepth = 1.0f; // x

        public float colliderxOffset = 1.0f;
        public float collideryOffset = 0.0f;
        public float colliderzOffset = 1.0f;

        [Header("Door Audio Settings")]
        public AudioMixerGroup audioMixerGroup;
        public AudioClip doorOpenClip;
        public AudioClip doorClosingClip;
        public AudioClip doorClosedClip;
        public bool autoOpen = true;

        [Header("Door Anim Settings")]
        public float openDuration = 1.5f;
        public float stayOpenDuration = 2.0f;
        public float closeDuration = 1.5f;
        public float openAngle = 100.0f;

        [MenuItem("Window/Buildings/Door Auto Editor")]
        public static void ShowWindow()
        {
            GetWindow(typeof(DoorAutoEditor));
        }

        /// <summary>
        /// Override base class to load specific Editor settings
        /// </summary>    
        public override void LoadSettings()
        {
            base.LoadSettings();
            DoorAutoEditorSettings doorAutoEditorSettings = autoEditorSettings as DoorAutoEditorSettings;
            audioMixerGroup = doorAutoEditorSettings.audioMixerGroup;
            doorOpenClip = doorAutoEditorSettings.doorOpenClip;
            doorClosingClip = doorAutoEditorSettings.doorClosingClip;
            doorClosedClip = doorAutoEditorSettings.doorClosedClip;
            autoOpen = doorAutoEditorSettings.autoOpen;
            openDuration = doorAutoEditorSettings.openDuration;
            stayOpenDuration = doorAutoEditorSettings.stayOpenDuration;
            closeDuration = doorAutoEditorSettings.closeDuration;
            openAngle = doorAutoEditorSettings.openAngle;

            pivotSide = doorAutoEditorSettings.pivotSide;
            swapTriggers = doorAutoEditorSettings.swapTriggers;

            colliderHeight = doorAutoEditorSettings.colliderHeight; // y
            colliderWidth = doorAutoEditorSettings.colliderWidth; // z
            colliderDepth = doorAutoEditorSettings.colliderDepth; // x

            colliderxOffset = doorAutoEditorSettings.colliderxOffset;
            collideryOffset = doorAutoEditorSettings.collideryOffset;
            colliderzOffset = doorAutoEditorSettings.colliderzOffset;
    }

        /// <summary>
        /// Override base class to apply Editor specific Configuration
        /// </summary>
        /// <param name="gameObject"></param>
        public override void ConfigureGameObject(GameObject gameObject)
        {
            outputArea += $"Processing: {gameObject.name}";

            // Configure the Door component
            ConfigureDoor(gameObject);

            // Configure the Audio Source
            ConfigureAudio(gameObject);

            // Configure the Triggers
            ConfigureTriggers(gameObject);

            outputArea += $"Done processing: {gameObject.name}";
        }

        /// <summary>
        /// Configure the base Door component
        /// </summary>
        /// <param name="gameObject"></param>
        private void ConfigureDoor(GameObject gameObject)
        {
            Door theDoor = gameObject.GetComponent<Door>();
            if (!theDoor)
            {
                theDoor = gameObject.AddComponent<Door>();
            }

            // Update audio
            if (doorOpenClip)
            {
                theDoor.openAudioClip = doorOpenClip;
            }

            if (doorClosingClip)
            {
                theDoor.closingAudioClip = doorClosingClip;
            }

            if (doorClosedClip)
            {
                theDoor.closedAudioClip = doorClosedClip;
            }

            // Update config
            theDoor.openDuration = openDuration;
            theDoor.stayOpenDuration = stayOpenDuration;
            theDoor.closeDuration = closeDuration;
            theDoor.openAngle = openAngle;
            theDoor.autoOpen = autoOpen;

            // Set the opening type
            if (gameObject.name.Contains("left"))
            {
                theDoor.pivotSide = DoorPivotSide.Left;
            }
            else
            {
                theDoor.pivotSide = DoorPivotSide.Right;
            }
        }

        /// <summary>
        /// Configure the AudioSource
        /// </summary>
        /// <param name="doorGameObject"></param>
        private void ConfigureAudio(GameObject doorGameObject)
        {
            AudioSource theAudioSource = doorGameObject.GetComponent<AudioSource>();
            if (!theAudioSource)
            {
                theAudioSource = doorGameObject.AddComponent<AudioSource>();
            }

            // Configure Mixer Group
            theAudioSource.outputAudioMixerGroup = audioMixerGroup;
            theAudioSource.spatialBlend = 1.0f;
            theAudioSource.playOnAwake = false;
            theAudioSource.loop = false;
        }

        /// <summary>
        /// Configure the open Triggers
        /// </summary>
        /// <param name="doorGameObject"></param>
        private void ConfigureTriggers(GameObject doorGameObject)
        {
            Transform[] allChildTransforms= doorGameObject.GetComponentsInChildren<Transform>();
            // Inside Trigger
            // Look for inside trigger. Create it, if it's not there
            bool foundInside = false;
            GameObject insideTriggerGameObject = null;
            bool foundOutside = false;
            GameObject outsideTriggerGameObject = null;

            foreach(Transform childTransform in allChildTransforms)
            {
                GameObject childGameObject = childTransform.gameObject;

                if(childGameObject.name.Contains("Inside Trigger"))
                {
                    insideTriggerGameObject = childGameObject;
                    foundInside = true;
                }

                if (childGameObject.name.Contains("Outside Trigger"))
                {
                    outsideTriggerGameObject = childGameObject;
                    foundOutside = true;
                }
            }

            if(!foundInside)
            {
                insideTriggerGameObject = new GameObject();
                insideTriggerGameObject.name = "Inside Trigger";
                insideTriggerGameObject.transform.SetParent(doorGameObject.transform);
                insideTriggerGameObject.transform.localPosition = Vector3.zero;
                insideTriggerGameObject.transform.localRotation = Quaternion.identity;
            }

            if (!foundOutside)
            {
                outsideTriggerGameObject = new GameObject();
                outsideTriggerGameObject.name = "Outside Trigger";
                outsideTriggerGameObject.transform.SetParent(doorGameObject.transform);
                outsideTriggerGameObject.transform.localPosition = Vector3.zero;
                outsideTriggerGameObject.transform.localRotation = Quaternion.identity;
            }
            
            if(swapTriggers)
            {
                ConfigureTrigger(insideTriggerGameObject, colliderxOffset, DoorTriggerLocation.Inside);
                ConfigureTrigger(outsideTriggerGameObject, -colliderxOffset, DoorTriggerLocation.Outside);
            }
            else
            {
                ConfigureTrigger(insideTriggerGameObject, -colliderxOffset, DoorTriggerLocation.Inside);
                ConfigureTrigger(outsideTriggerGameObject, colliderxOffset, DoorTriggerLocation.Outside);
            }

        }

        /// <summary>
        /// Configure instance of open trigger
        /// </summary>
        /// <param name="triggerGameObject"></param>
        /// <param name="xOffset"></param>
        /// <param name="zOffset"></param>
        /// <param name="doorTriggerLocation"></param>
        private void ConfigureTrigger(GameObject triggerGameObject, float xOffset, DoorTriggerLocation doorTriggerLocation)
        {
            triggerGameObject.layer = LayerMask.NameToLayer("Triggers");

            BoxCollider triggerCollider = triggerGameObject.GetComponent<BoxCollider>();
            if(!triggerCollider)
            {
                triggerCollider = triggerGameObject.AddComponent<BoxCollider>();
            }

            triggerCollider.size = new Vector3(colliderDepth, colliderHeight, colliderWidth);
            triggerCollider.center = new Vector3(xOffset, collideryOffset, colliderzOffset);
            triggerCollider.isTrigger = true;

            DoorTrigger theDoorTrigger = triggerGameObject.GetComponent<DoorTrigger>();
            if (!theDoorTrigger)
            {
                theDoorTrigger = triggerGameObject.AddComponent<DoorTrigger>();
            }

            theDoorTrigger.doorTriggerLocation = doorTriggerLocation;
        }

    }
}
