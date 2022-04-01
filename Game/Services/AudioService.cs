using HaloMiniGame.Game.Casting;

/*borrowed from unit 6*/
namespace HaloMiniGame.Game.Services
{

    public interface AudioService
    {
        void Initialize();

        void LoadSounds (string directory);

        void PlaySound (Sound sound);

        void Release();

        void UnloadSounds();

    }
}