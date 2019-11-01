using System;
using System.Collections.Generic;
using System.Text;

namespace WebCiv.Engine
{
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
    }
}