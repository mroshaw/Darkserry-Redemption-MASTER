using UnityEngine;

namespace DaftAppleGames.Common.Characters
{
    public class Character : MonoBehaviour
    {

        [Header("Character Settings")]
        public string characterName;

        [Header("Debug")]
        public bool enableDebug = false;

        // Start is called before the first frame update
        public virtual void Start()
        {

        }

        // Update is called once per frame
        public virtual void Update()
        {

        }
    }
}