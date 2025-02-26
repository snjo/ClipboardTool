namespace ClipboardTool.Classes
{
    internal static class ColorHelpers
    {

        public static Color MixColor(Color color1, Color color2, float mix = 0.5f)
        {
            int R = (int)Lerp(color1.R, color2.R, mix);
            int G = (int)Lerp(color1.G, color2.G, mix);
            int B = (int)Lerp(color1.B, color2.B, mix);
            return Color.FromArgb(R, G, B);
        }

        public static Color TextColorFromBackColor(Color backColor, float threshold = 0.6f)
        {
            Color result = Color.Black;
            if (ColorValue(backColor) < threshold)
                result = Color.White;
            return result;
        }

        public static float ColorValue(Color color)
        {
            // returns a value of 0-1f based on the total brightness of the input color
            //https://stackoverflow.com/questions/596216/formula-to-determine-perceived-brightness-of-rgb-color
            //https://en.wikipedia.org/wiki/Relative_luminance
            //perceived value (0.2126 * R + 0.7152 * G + 0.0722 * B)
            float pR = 0.2126f;
            float pG = 0.7152f;
            float pB = 0.0722f;
            float result = (color.R * pR + color.G * pG + color.B * pB) / 256f;
            return result;
        }

        public static Color ParseColor(string text)
        {
            string[] rgbText = text.Split(',');
            int[] rgbValues = [255, 255, 255];
            rgbValues[0] = int.Parse(rgbText[0]);
            rgbValues[1] = int.Parse(rgbText[1]);
            rgbValues[2] = int.Parse(rgbText[2]);
            Color color = Color.FromArgb(rgbValues[0], rgbValues[1], rgbValues[2]);
            return color;
        }

        public static float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }
    }
}