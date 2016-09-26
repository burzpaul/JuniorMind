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
            string str = "aaabb";
            Assert.AreEqual(9, AnagramCalculator(str));
        }
        int AnagramCalculator(string word)
        {
            int n = 1;
            for (char letter = 'a'; letter <= 'z'; letter++)
                n *=CalculateFactorial(LetterCounter(letter, word, 0));
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
        public int LetterCounter(char theLetter, string givenWord, int m)
        {
                for (int i = 0; i <= givenWord.Length - 1; i++)
                    if (theLetter == givenWord[i])
                        m++;
            return m;
        }
    }  
}
