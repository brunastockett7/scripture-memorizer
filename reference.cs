namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verseStart;
        private int _verseEnd;

        public Reference(string book, int chapter, int verseStart)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseStart;
        }

        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd;
        }

        public override string ToString()
        {
            if (_verseStart == _verseEnd)
            {
                return $"{_book} {_chapter}:{_verseStart}";
            }
            else
            {
                return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
            }
        }
    }
}
