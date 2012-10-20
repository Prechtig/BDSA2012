using Assignment37;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace Test
{
    
    
    /// <summary>
    ///This is a test class for TextFileSearcherTest and is intended
    ///to contain all TextFileSearcherTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TextFileSearcherTest
    {
        /// <summary>
        ///A test for ProcessInput
        ///</summary>
        [TestMethod()]
        public void ProcessInputTest()
        {
            string text = "asdflkj asdæfljasdfælk " + 
                          "Fri, 24 Dec 0 00:00:00 " + 
                          "fawfk jfoj oafjoiej fj jasefio" +
                          "http://tinyurl.com/y8ufsnp" + 
                          "jesfio efj +2304 i23+ wejfsd f0å9w34 r¨w feælk";
            TextFileSearcher tfs = new TextFileSearcher(text);
            string keyword = "*ælk"; // TODO: Initialize to an appropriate value
            MatchCollection matches = tfs.ProcessInput(keyword, text);
            Assert.AreEqual(8, matches[0].Index);
            Assert.AreEqual(14, matches[0].Length);
            Assert.AreEqual(23, matches[1].Index);
            Assert.AreEqual(22, matches[1].Length);
            Assert.AreEqual(76, matches[2].Index);
            Assert.AreEqual(32, matches[2].Length);
            Assert.AreEqual(143, matches[3].Index);
            Assert.AreEqual(5, matches[3].Length);
        }
    }
}
