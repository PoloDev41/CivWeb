using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCiv.Engine
{
    /// <summary>
    /// class about the civilization technology tree
    /// </summary>
    public class CivTechTree
    {
        /// <summary>
        /// id of the civ tech
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// list of technology in progress
        /// </summary>
        public List<CivTech> TechnologyProgression { get; set; } = new List<CivTech>();
    }
}
