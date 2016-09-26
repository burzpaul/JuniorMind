using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GiveWords()
        {
            char[] word = { 'a', 'a', 'b', 'b' };
            Assert.AreEqual(5, AnagramCalculator(word));
        }
        int AnagramCalculator(char[] word)
        {
            int m=0,n=1;
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                n *= CalculateFactorial(m);
                m = 0;
                for (int i = 0; i <= word.Length - 1; i++)
                    if (letter == word[i])
                        m++;
            }
                return (CalculateFactorial(word.Length)-1)/n;
        }
        static int CalculateFactorial(int number)
        {
            if (number < 1)
                return 1;
            var factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial *= i;
            return factorial;
        }
    }  
}
