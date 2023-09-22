using System;
using System.Media;


namespace MarketX.Framework {
    internal class Audio {
        public static void Play(string fileName) {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + $"\\Assets\\{fileName}.wav";
            player.Play();
        }
    }
}
