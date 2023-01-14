using UnityEngine;
namespace DaftAppleGames.Core.Buildings
{
    public enum DoorTriggerLocation { Inside, Outside };

    public class DoorTrigger : MonoBehaviour
    {
        [Header("Door Configuration ")]
        public DoorTriggerLocation doorTriggerLocation;
        public LayerMask triggerLayerMask;
        public string triggerTag = "Player";

        private Door door;

        /// <summary>
        /// Initialise the Door Trigger
        /// </summary>
        private void Start()
        {
            door = GetComponentInParent<Door>();
            triggerLayerMask = LayerMask.GetMask("Player");
            triggerTag = "Player";
        }

        /// <summary>
        /// Open the Door when the Player enters the Tigger area
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(triggerTag) && door.autoOpen)
            {
                bool inLayer = ((triggerLayerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer);
                if(inLayer)
                {
                    door.Open(doorTriggerLocation);
                }
            }
        }
    }
}