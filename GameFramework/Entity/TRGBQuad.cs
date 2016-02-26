namespace GameFramework
{
    public struct TRGBQuad
    {
        public TRGBQuad(byte r, byte g, byte b, byte res)
        {
            this.rgbRed = r;
            this.rgbGreen = g;
            this.rgbBlue = b;
            this.rgbReserved = res;
        }

        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    }
}