using NAudio.Wave;

namespace EcoCalc_Plus.UtilityClass
{
    public class SoundManager : IDisposable
    {
        private WaveOutEvent _backgroundMusicPlayer;
        private WaveOutEvent _soundEffectPlayer;
        private AudioFileReader _backgroundMusicFile;
        private AudioFileReader _soundEffectFile;
        private float _volume = 1.0f;

        public SoundManager()
        {
            _backgroundMusicPlayer = new WaveOutEvent();
            _soundEffectPlayer = new WaveOutEvent();
        }

        public void PlayBackgroundMusic(string filePath, bool loop = true)
        {
            StopBackgroundMusic();

            _backgroundMusicFile = new AudioFileReader(filePath);
            _backgroundMusicFile.Volume = _volume;
            _backgroundMusicPlayer.Init(_backgroundMusicFile);
            _backgroundMusicPlayer.Play();

            if (loop)
            {
                _backgroundMusicPlayer.PlaybackStopped += (s, e) =>
                {
                    _backgroundMusicFile.Position = 0;
                    _backgroundMusicPlayer.Play();
                };
            }
        }

        public void StopBackgroundMusic()
        {
            _backgroundMusicPlayer?.Stop();
            _backgroundMusicFile?.Dispose();
        }

        public void PlaySoundEffect(string filePath)
        {
            _soundEffectPlayer?.Stop();
            _soundEffectFile?.Dispose();

            _soundEffectFile = new AudioFileReader(filePath);
            _soundEffectPlayer.Init(_soundEffectFile);
            _soundEffectPlayer.Play();
        }

        public void Dispose()
        {
            _backgroundMusicPlayer?.Dispose();
            _soundEffectPlayer?.Dispose();
            _backgroundMusicFile?.Dispose();
            _soundEffectFile?.Dispose();
        }

        public void SetVolume(float volume)
        {
            _volume = Math.Clamp(volume, 0f, 1f);
            if (_backgroundMusicFile != null)
            {
                _backgroundMusicFile.Volume = _volume;
            }
        }
    }
}
