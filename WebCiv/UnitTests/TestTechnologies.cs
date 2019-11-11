using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebCiv.DAL;
using WebCiv.Engine.TechnologyTree;

namespace UnitTests
{
    class TestTechnologies
    {
        [Test]
        public void TestTechnoTree()
        {
            Assert.IsNotNull(TechnoTree.Tree);
            Assert.Greater(TechnoTree.Tree.Count, 0);

            for (int i = TechnoTree.Tree.Count - 1; i >= 0; i--)//check doublon
            {
                var currentTech = TechnoTree.Tree[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    Assert.AreNotEqual(currentTech.Name, TechnoTree.Tree[j].Name);
                }
            }
        }
    }
}
