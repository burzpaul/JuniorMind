namespace OrderWordsByNumberOfApparitionsInText
{
    public class Word
    {
        private string theWord;
        private int numberOfApparitions;

        public Word(string word) : this(word, 0)
        {

        }

        public Word(string word, int numberOfApparitions)
        {
            this.theWord = word.ToLower();
            this.numberOfApparitions = numberOfApparitions;
        }

        public void IncreaseApparition()
        {
           this.numberOfApparitions++;
        }

        public bool EqualWords(string word, bool compareApparitions)
        {
            if (compareApparitions)
                return this.numberOfApparitions.Equals(numberOfApparitions);
            return this.theWord.Equals(word.ToLower());
            
        }

        public bool EqualWords(Word other, bool compareApparitions)
        {
            if (compareApparitions)
                return this.numberOfApparitions.Equals(other.numberOfApparitions);
            return this.theWord.Equals(other.theWord);
            
        }

        public bool IsMoreCommon(Word other)
        {
            return this.numberOfApparitions > other.numberOfApparitions;
        }
    }
}
