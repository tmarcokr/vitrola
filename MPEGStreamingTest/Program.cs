using MPEGHeaderInfo.ICES;
using MPEGInfo;
using PlayList;
using System;
using System.Collections.Generic;
using System.IO;

namespace MPEGStreamingTest
{
    class Program
    {
        private static readonly IoC IOC = new IoC();

        private static RadioControls _radioControls;

        static void Main(string[] args)
        {
            var allFilesFound = Directory.GetFiles(@"[PUT_YOUR_MP3_FOLDER]", "*.mp3", SearchOption.AllDirectories);
            InitializeRadio(allFilesFound);
            Console.WriteLine("Radio Station Initialized");
            Console.WriteLine("Commands: P -> To Play current music");
            Console.WriteLine("Commands: N -> To Move to next music");
            Console.WriteLine("Commands: S -> To Stop music");
            Console.WriteLine("Commands: E -> To exit");
            ConsoleReading();
        }

        private static void ConsoleReading()
        {
            while (true)
            {
                Console.WriteLine("Awaiting command...");
                var input = Console.ReadLine();
                if (input.ToUpper() == "E")
                {
                    break;
                }

                switch (input.ToUpper())
                {
                    case "P":
                        Console.WriteLine("Play Music...");
                        _radioControls.Play();
                        break;
                    case "S":
                        Console.WriteLine("Stop Music...");
                        _radioControls.Stop();
                        break;
                    case "N":
                        Console.WriteLine("Next Music...");
                        _radioControls.Next();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void InitializeRadio(IEnumerable<string> filesToPlay)
        {
            var mediaPlayer = new MediaPlayer(IOC.IceCastTcpClient);
            _radioControls = new RadioControls(mediaPlayer, FinishTransmission);
            _radioControls.SetPlayList(filesToPlay);
        }

        private static void FinishTransmission()
        {
            IOC.IceCastTcpClient.Close();
            IOC.IceCastTcpClient.Dispose();
            Console.WriteLine("...Transmission end...");
        }
    }
}
