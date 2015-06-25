namespace FileByteArray
{
    using System;
    using System.IO;

    public class FileByteArray
    {
        private Stream stream;
        public FileByteArray(string f)
        {
            stream = new FileStream(f, FileMode.Open);
        }

        public byte this[long index]
        {
            get
            {
                byte[] buffer = new byte[1];
                stream.Seek(index, SeekOrigin.Begin);
                stream.Read(buffer, 0, 1);
                return buffer[0];
            }
            set
            {
                byte[] buffer = new byte[1] { value };
                stream.Seek(index, SeekOrigin.Begin);
                stream.Write(buffer, 0, 1);
            }
        }

        public long Length
        {
            get { return stream.Seek(0, SeekOrigin.End); }
        }

        public void Close()
        {
            stream.Close();
            stream = null;
        }
    }

    public class Reverse
    {
        public static void Main(String[] args)
        {
            if (args.Length == 1)
            {
                string fileName = args[0];
                FileByteArray fileByteArray = new FileByteArray(fileName);
                long LEN = fileByteArray.Length;
                for (long i = 0; i < LEN/2; ++i)
                {
                    byte tmp = fileByteArray[i];
                    fileByteArray[i] = fileByteArray[LEN - 1 - i];
                    fileByteArray[LEN - 1 - i] = tmp;
                }

                fileByteArray.Close();
            }
        }
    }
}
