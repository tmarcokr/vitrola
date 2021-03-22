namespace MPEGInfo.Extension
{
    public static class ID3V1Extension
    {
        private const int Id3v1Length = 128;

        private const int Id3v1HeaderLength = 3;

        public static (bool hasId3v1Tag, int endId3v1Position) HasId3v1Tag(this MPEGStream source)
        {
            var result = (hasId3v1Tag: false, endId3v1Position: -1);

            var tag3v1Position = (source.GetLength() - Id3v1Length); //ID3v1Tag ARE ALWAYES ON END OF THE FILE
            var id3v1Header = source.Read(tag3v1Position, Id3v1HeaderLength);
            if (HasId3v1Tag(id3v1Header))
            {
                result.hasId3v1Tag = true;
                result.endId3v1Position = (int)tag3v1Position;
            }

            return result;
        }

        private static bool HasId3v1Tag(byte[] id3v1Header)
        {
            return (id3v1Header[0] == 'T')
                && (id3v1Header[1] == 'A')
                && (id3v1Header[2] == 'G');
        }
    }
}
