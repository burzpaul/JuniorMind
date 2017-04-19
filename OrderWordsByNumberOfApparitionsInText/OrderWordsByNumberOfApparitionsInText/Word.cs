namespace OrderWordsByNumberOfApparitionsInText
{
    public class Word
    {
        private string theWord;
        private int numberOfApparitions;

        public Word(string word) : this(word, 0)
        {
            
        }

        public Word(string words, int numberOfApparitions)
        {
            this.theWord = words.ToLower();
            this.numberOfApparitions = numberOfApparitions;
        }

        public void IncreaseApparition()
        {
            numberOfApparitions++;
        }

        public bool EqualWords(string word)
        {
            return this.theWord.Equals(word.ToLower());
        }

        public bool EqualWords(Word other)
        {
            return this.theWord.Equals(other.theWord);
        }

        public bool EqualApparitions(int numberOfApparitions)
        {
            return this.numberOfApparitions.Equals(numberOfApparitions);
        }

        public bool EqualApparitions(Word other)
        {
            return this.numberOfApparitions.Equals(other.numberOfApparitions);
        }

        public bool IsMoreCommon(Word other)
        {
            return this.numberOfApparitions > other.numberOfApparitions;
        }
    }
}
