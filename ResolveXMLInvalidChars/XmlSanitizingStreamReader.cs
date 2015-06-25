namespace ResolveXMLInvalidChars
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    /// <summary>
    /// A StreamReader that excludes XML-illegal characters while reading.
    /// </summary>
    public class XmlSanitizingStreamReader : StreamReader
    {
        /// <summary>
        /// The charactet that denotes the end of a file has been reached.
        /// </summary>
        private const int EOF = -1;

        /// <summary>Create an instance of XmlSanitizingStream.</summary>
        /// <param name="streamToSanitize">
        /// The stream to sanitize of illegal XML characters.
        /// </param>
        public XmlSanitizingStreamReader(Stream streamToSanitize)
            : base(streamToSanitize, true)
        { }

        public override int Read()
        {
            // Read each character, skipping over characters that XML has prohibited

            int nextCharacter;

            do
            {
                // Read a character
                if ((nextCharacter = base.Read()) == EOF)
                {
                    // If the character denotes the end of the file, stop reading
                    break;
                }
            }

            while (!XmlConvert.IsXmlChar((char)nextCharacter));

            return nextCharacter;
        }

        public override int Peek()
        {
            int nextCharacter;

            do
            {
                nextCharacter = base.Peek();
            }
            while
            (
                // If it's prohibited XML, skip over the character in the stream
                // and try the next.

                !XmlConvert.IsXmlChar((char)nextCharacter) &&
                (nextCharacter = base.Read()) != EOF
            );

            return nextCharacter;

        } // method

        #region Read*() method overrides

        // The following methods are exact copies of the methods in TextReader, 
        // extracting by disassembling it in Refelctor

        public override int Read(char[] buffer, int index, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if ((buffer.Length - index) < count)
            {
                throw new ArgumentException();
            }
            int num = 0;
            do
            {
                int num2 = this.Read();
                if (num2 == -1)
                {
                    return num;
                }
                buffer[index + num++] = (char)num2;
            }
            while (num < count);
            return num;
        }

        public override int ReadBlock(char[] buffer, int index, int count)
        {
            int num;
            int num2 = 0;
            do
            {
                num2 += num = this.Read(buffer, index + num2, count - num2);
            }
            while ((num > 0) && (num2 < count));
            return num2;
        }

        public override string ReadLine()
        {
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                int num = this.Read();
                switch (num)
                {
                    case -1:
                        if (builder.Length > 0)
                        {
                            return builder.ToString();
                        }
                        return null;

                    case 13:
                    case 10:
                        if ((num == 13) && (this.Peek() == 10))
                        {
                            this.Read();
                        }
                        return builder.ToString();
                }
                builder.Append((char)num);
            }
        }

        public override string ReadToEnd()
        {
            int num;
            char[] buffer = new char[0x1000];
            StringBuilder builder = new StringBuilder(0x1000);
            while ((num = this.Read(buffer, 0, buffer.Length)) != 0)
            {
                builder.Append(buffer, 0, num);
            }
            return builder.ToString();
        }

        #endregion

    } // class

}
