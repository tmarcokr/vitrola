using MPEGCast.Core;
using MPEGHeaderInfo.ICES;
using MPEGInfo;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlayList
{
    public class RadioControls
    {
        private Action FinishedTransmition { get; set; }

        private IEnumerator<string> PlayListFiles { get; set; }

        private MediaPlayer MediaPlayer { get; set; }

        public RadioControls(MediaPlayer mediaPlayer, Action finishTransmition)
        {
            MediaPlayer = mediaPlayer;
            FinishedTransmition = finishTransmition;
        }

        public void SetPlayList(IEnumerable<string> playListFiles)
        {
            if (MediaPlayer.Status == MediaPlayerStatus.Playing)
            {
                throw new Exception("Stop the radio befoure change the play list");
            }

            PlayListFiles = playListFiles.GetEnumerator();
            PlayListFiles?.MoveNext();
        }

        public void Play()
        {
            if (PlayListFiles == null)
            {
                throw new ArgumentNullException("The playlist is not set");
            }

            if (MediaPlayer.Status == MediaPlayerStatus.Playing)
            {
                return;
            }

            var currentFile = PlayListFiles.Current;
            var songToPlay = File.OpenRead(currentFile);
            MediaPlayer?.Play(songToPlay, Next);
        }

        public void Stop()
        {
            MediaPlayer?.Stop();
        }

        public void Next()
        {
            if (PlayListFiles == null)
            {
                throw new ArgumentNullException("The playlist is not set");
            }

            if (!PlayListFiles.MoveNext())
            {
                FinishedTransmition?.Invoke();
                return;
            }

            Stop();
            Play();
        }
    }
}
