namespace WebCiv.Engine
{
    /// <summary>
    /// class to store civilization technology progression
    /// </summary>
    public class CivTech
    {
        /// <summary>
        /// id of the tech
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// name of the technology
        /// </summary>
        public string TechnologyName { get; set; }

        /// <summary>
        /// current progression on the tech
        /// </summary>
        public int CurrentProgression { get; set; } = 0;

        /// <summary>
        /// next objective of the tech to increase the level
        /// </summary>
        public int NextObjective { get; set; } = 100;
    }
}