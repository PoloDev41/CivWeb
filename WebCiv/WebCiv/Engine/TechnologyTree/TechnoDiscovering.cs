using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCiv.Engine.TechnologyTree
{
    /// <summary>
    /// technology of discovering
    /// </summary>
    public class TechnoDiscovering : BaseTechnology
    {
        /// <summary>
        /// const name of the techno
        /// </summary>
        public const string  DiscoveringName = "Discovering";

        /// <summary>
        /// create the technology discovering
        /// </summary>
        public TechnoDiscovering()
        {
            this.Name = DiscoveringName;
        }

        /// <summary>
        /// apply a progression on this technology
        /// </summary>
        /// <param name="civTree">tree of the civilization</param>
        public override void ApplyProgression(CivTechTree civTree)
        {
            throw new NotImplementedException();
        }
    }
}
