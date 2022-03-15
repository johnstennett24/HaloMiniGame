using (filename)

/*borrowed from unit 6*/
namespace MiniHaloGame
{

    public interface AudioService
    {
        void Initialize();

        void LoadSounds (string directory);

        void PlaySound (Sound sound);

        void Release();

        void UploadSounds();

    }
}