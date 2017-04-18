namespace OrderWordsByNumberOfApparitionsInText
{
    public class Word
    {
        private string theWord;
        private int numberOfApparitions;

        public Word(string word)
        {
            this.theWord = word.ToLower();
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
            return this.theWord.Equals(other.theWord.ToLower());
        }

        public bool IsMoreCommon(Word other)
        {
            return this.numberOfApparitions > other.numberOfApparitions;
        }
    }
}
