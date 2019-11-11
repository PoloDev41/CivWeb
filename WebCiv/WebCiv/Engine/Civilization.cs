using System;
using System.Collections.Generic;
using System.Text;

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
            };
        }
    }
}