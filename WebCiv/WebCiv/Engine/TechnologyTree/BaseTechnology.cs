using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCiv.Engine.TechnologyTree
{
    /// <summary>
    /// abstract class of technology
    /// </summary>
    public abstract class BaseTechnology
    {
        /// <summary>
        /// linked technologies of this tech
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "EF doesn't handle const field")]
        public List<BaseTechnology> LinkedTechnology { get; set; }

        /// <summary>
        /// name of the technology
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// apply a progression on this technology
        /// </summary>
        /// <param name="civTree">tree of the civilization</param>
        public abstract void ApplyProgression(CivTechTree civTree);
    }
}
