using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCiv.Engine.TechnologyTree
{
    /// <summary>
    /// represent the techno tree
    /// </summary>
    public static class TechnoTree
    {
        /// <summary>
        /// tree of the technologies
        /// </summary>
        public static List<BaseTechnology> Tree { get; } = new List<BaseTechnology>()
        {
            new TechnoDiscovering()
        };


        /// <summary>
        /// apply the progression on a technology to a civilization
        /// </summary>
        /// <param name="technoName">name of the techno to progress on</param>
        /// <param name="tree">civilization techo tree</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "string not display")]
        public static void ApplyProgression(string technoName, CivTechTree tree)
        {
            var tech = Tree.Find(x => x.Name == technoName);
            if(tech == null)
            {
                throw new ArgumentException("Unkonwn techno name in the technology tree");
            }

            tech.ApplyProgression(tree);
        }
    }
}
