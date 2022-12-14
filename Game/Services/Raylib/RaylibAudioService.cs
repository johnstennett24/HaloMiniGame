using System.Collections.Generic;
using System.IO;
using Raylib_cs;

namespace HaloMiniGame.Game.Services
{
    
    public class RaylibAudioService : AudioService
    {
        private Dictionary<string, Raylib_cs.Sound> sounds 
            = new Dictionary<string, Raylib_cs.Sound>();
        

        public RaylibAudioService()
        {
        }

        
        public void Initialize()
        {
            Raylib.InitAudioDevice();
        }

    
        public void LoadSounds(string directory)
        {
            List<string> filters = new List<string>() { "*.wav", "*.mp3", "*.acc", "*.wma" };
            List<string> filepaths = GetFilepaths(directory, filters);
            foreach (string filepath in filepaths)
            {
                Raylib_cs.Sound sound = Raylib.LoadSound(filepath);
                sounds[filepath] = sound;
            }
        }
 
       
        public void PlaySound(Casting.Sound sound)
        {
            string filename = sound.GetFilename();
            if (sounds.ContainsKey(filename))
            {
                Raylib_cs.Sound raylibSound = sounds[filename];
                Raylib.PlaySound(raylibSound);
            }
        }

      
        public void Release()
        {
            Raylib.CloseAudioDevice();
        }

      
        public void UnloadSounds()
        {
            foreach (string filepath in sounds.Keys)
            {
                Raylib_cs.Sound raylibSound = sounds[filepath];
                Raylib.UnloadSound(raylibSound);
            }
        }

        private List<string> GetFilepaths(string directory, List<string> filters)
        {
            List<string> results = new List<string>();
            foreach (string filter in filters)
            {
                string[] filepaths = Directory.GetFiles(directory, filter);
                results.AddRange(filepaths);
            }
            return results;
        }
    }
}