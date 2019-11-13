using System;
using System.Collections.Generic;
using System.Text;
using WebCiv.Engine.PopAction;
using WebCiv.Engine.TechnologyTree;

namespace WebCiv.Engine
{
    /// <summary>
    /// class to store civilization information
    /// </summary>
    public class Civilization
    {
        /// <summary>
        /// Id of the civilization
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Population of the civilization
        /// </summary>
        public Population Population { get; set; } = new Population();

        /// <summary>
        /// technology tree of the civilization
        /// </summary>
        public CivTechTree TechTree { get; set; }

        /// <summary>
        /// list of population action that the civilization can do
        /// </summary>
        public List<CivAllowedPopAction> AllowedPopActions { get; private set; }

        /// <summary>
        /// current population action that the civilization does
        /// </summary>
        public CivCurrentPopAction CurrentPopAction { get; set; }

        /// <summary>
        /// create a new civilization
        /// </summary>
        /// <returns>new civilization</returns>
        public static Civilization CreateRawCivilization()
        {
            return new Civilization()
            {
                Population = new Population()
                {
                    TotalPop = 10
                },
                TechTree = new CivTechTree()
                {
                    TechnologyProgression = new List<CivTech>()
                    {
                        new CivTech() { TechnologyName = TechnoDiscovering.DiscoveringName }
                    }
                },
                AllowedPopActions = new List<CivAllowedPopAction>()
                {
                    new CivAllowedPopAction(){PopActionName= PopActionReproduce.Name }
                },
                CurrentPopAction = null,
            };
        }


    }
}