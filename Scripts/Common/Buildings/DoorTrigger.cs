using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DaftAppleGames.Core.Buildings
{
    public enum DoorTriggerLocation { Inside, Outside };

    public class DoorTrigger : MonoBehaviour
    {
        [Header("Door Configuration ")]
        public DoorTriggerLocation doorTriggerLocation;
        private Door door;

        /// <summary>
        /// Initialise the Door Trigger
        /// </summary>
        private void Start()
        {
            door = GetComponentInParent<Door>();
        }

        /// <summary>
        /// Open the Door when the Player enters the Tigger area
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player") && door.autoOpen)
            {
                    door.Open(doorTriggerLocation);
            }
        }
    }
}