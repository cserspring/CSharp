// https://msdn.microsoft.com/en-us/library/aa288464(v=vs.71).aspx
namespace IndexedProperties
{
    using System;

    public class Document
    {
        public readonly WordCollection Words;
        public readonly CharacterCollection Characters;
        private char[] TextArray;

        public Document(string text)
        {
            this.TextArray = text.ToCharArray();
            this.Words = new WordCollection(this);
            this.Characters = new CharacterCollection(this);
        }
        public class WordCollection
        {
            private readonly Document d;

            public WordCollection(Document d)
            {
                this.d = d;
            }

            // Helper function -- search character array "text", starting at
            // character "begin", for word number "wordCount." Returns false
            // if there are less than wordCount words. Sets "start" and
            // length" to the position and length of the word within text:
            private bool GetWord(char[] text, int begin, int wordCount, out int start, out int length)
            {
                int end = text.Length;
                bool first = false;
                int count = -1;
                start = length = 0;

                for (int i = begin; i <= end; i++)
                {
                    if (i < end && Char.IsLetterOrDigit(text[i]))
                    {
                        if (!first)
                        {
                            start = i;
                            first = true;
                            ++count;
                        }
                    }
                    else
                    {
                        if (first)
                        {
                            if (count == wordCount)
                            {
                                length = i - start;
                                return true;
                            }
                            first = false;
                        }
                    }
                }
                
                return false;
            }

            public string this[int index]
            {
                get
                {
                    int start;
                    int length;
                    if (GetWord(this.d.TextArray, 0, index, out start, out length))
                    {
                        return new string(this.d.TextArray, start, length);
                    }
                    throw new IndexOutOfRangeException();
                }
                set
                {
                    int start;
                    int length;
                    if (GetWord(this.d.TextArray, 0, index, out start, out length))
                    {
                        if (length == value.Length)
                        {
                            Array.Copy(value.ToCharArray(), 0, this.d.TextArray, start, length);
                        }
                        else
                        {
                            char[] newText = new char[this.d.TextArray.Length + value.Length - length];
                            Array.Copy(this.d.TextArray, 0, newText, 0, start);
                            Array.Copy(value.ToCharArray(), 0, newText, start, value.Length);
                            Array.Copy(this.d.TextArray, start + length, newText, start + value.Length, this.d.TextArray.Length-start-length);
                            this.d.TextArray = newText;
                        }
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }

            public int Count
            {
                get
                {
                    int count = 0;
                    int start = 0;
                    int length = 0;
                    while ((GetWord(this.d.TextArray, start + length, 0, out start, out length)))
                    {
                        ++count;
                    }
                    return count;
                }
            }
        }

        public class CharacterCollection
        {
            private readonly Document d;

            internal CharacterCollection(Document d)
            {
                this.d = d;
            }

            public char this[int index]
            {
                get { return d.TextArray[index]; }
                set { d.TextArray[index] = value; }
            }

            public int Count
            {
                get { return d.TextArray.Length; }
            }
        }

        public string Text
        {
            get
            {
                return new string(TextArray);
            }
        }
    }

    class Test
    {
        static void Main()
        {
            Document d = new Document(
               "peter piper picked a peck of pickled peppers. How many pickled peppers did peter piper pick?"
            );
            
            // Change word "peter" to "penelope":
            for (int i = 0; i < d.Words.Count; ++i)
            {
                if (d.Words[i] == "peter")
                    d.Words[i] = "penelope";
            }

            // Change character "p" to "P"
            for (int i = 0; i < d.Characters.Count; ++i)
            {
                if (d.Characters[i] == 'p')
                    d.Characters[i] = 'P';
            }

            Console.WriteLine(d.Text);

            Console.ReadLine();
        }
    }
}
