using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWordsByNumberOfApparitionsInText
{
    public class WordClass
    {
        private string theWord;
        private int numberOfApparitions;
            
        public void Details(string word, int apparitionsInText)
        {
            theWord = word;
            numberOfApparitions = apparitionsInText;
        }
        public string GetWord()
        {
            return theWord;
        }
        public int GetNumberOfApparitions()
        {
            return numberOfApparitions;
        }
        public void IncreaseNumberOfApparitions()
        {
            numberOfApparitions++;
        }
        
    }
}
