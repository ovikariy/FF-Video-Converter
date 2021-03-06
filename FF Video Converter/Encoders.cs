﻿namespace FFVideoConverter
{
    public enum Quality { Best, VeryGood, Good, Medium, Low, VeryLow }
    public enum Preset { VerySlow, Slower, Slow, Medium, Fast, Faster, VeryFast }

    public abstract class Encoder
    {
        public Quality Quality { get; set; }
        public Preset Preset { get; set; }
        public abstract int Crf { get; }

        public abstract string GetFFMpegCommand();

        public static Encoder FromName(string name)
        {
            if (name.Contains("H264")) return new H264Encoder();
            if (name.Contains("H265")) return new H265Encoder();
            return new NativeEncoder();
        }
    }

    public class NativeEncoder : Encoder
    {
        public override int Crf { get { return 0; } }

        public NativeEncoder()
        {
        }

        public override string ToString()
        {
            return "Native";
        }

        public override string GetFFMpegCommand()
        {
            return " copy";
        }
    }

    public class H264Encoder : Encoder
    {
        public override int Crf
        {
            get
            {
                return 18 + (int)Quality * 4;
            }
        }

        public H264Encoder()
        {
        }

        public override string ToString()
        {
            return "H264";
        }

        public override string GetFFMpegCommand()
        {
            return $"libx264 -movflags faststart -preset {(int)Preset} -crf {Crf}";
        }
    }

    public class H265Encoder : Encoder
    {
        public override int Crf
        {
            get
            {
                return 23 + (int)Quality * 4;
            }
        }

        public H265Encoder()
        {
        }

        public override string ToString()
        {
            return "H265";
        }

        public override string GetFFMpegCommand()
        {
            return $"libx265 -movflags faststart -preset {(int)Preset} -crf {Crf}";
        }
    }
}