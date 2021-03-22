namespace MPEGInfo.Extension
{
    public static class ID3V2Extension
    {
        private const int Id3v2HeaderLength = 10;

        private const int Id3v2FooterLength = 10;

        public static (bool hasId3v2Tag, int endId3V2Position) HasId3v2Tag(this MPEGStream source)
        {
            var result = (hasId3v2Tag: false, endId3v2Position: -1);
            var id3v2Header = source.Read(0, Id3v2HeaderLength); //ID3v2Tag ARE ALWAYES ON BEGIN OF THE FILE

            if (HasId3v2Tag(id3v2Header))
            {
                var endId3V2Position = id3v2Header[6] * (1 << 21);
                endId3V2Position += id3v2Header[7] * (1 << 14);
                endId3V2Position += id3v2Header[8] * (1 << 7);
                endId3V2Position += id3v2Header[9];
                endId3V2Position += Id3v2HeaderLength;

                if (Id3v2HasFooter(id3v2Header))
                {
                    endId3V2Position += Id3v2FooterLength;
                }

                result.hasId3v2Tag = true;
                result.endId3v2Position = endId3V2Position;
            }

            return result;
        }

        private static bool HasId3v2Tag(byte[] id3v2Header)
        {
            return (id3v2Header.Length >= 3)
                && (id3v2Header[0] == 'I')
                && (id3v2Header[1] == 'D')
                && (id3v2Header[2] == '3');
        }

        private static bool Id3v2HasFooter(byte[] id3v2Header)
        {
            return (id3v2Header[5] & 0x10) == 0x10;
        }
    }
}
