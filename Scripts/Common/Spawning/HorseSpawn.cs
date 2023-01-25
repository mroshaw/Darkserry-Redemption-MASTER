namespace DaftAppleGames.Common.Spawning
{

    public class HorseSpawn :SpawnObject, ISpawnObject
    {
        /// <summary>
        /// Initialise the component
        /// </summary>
        public void Start()
        {
            if(spawnAtStart)
            {
                base.Spawn();
            }
        }
    }
}