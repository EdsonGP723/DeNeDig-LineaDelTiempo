using UnityEngine;
using System.Collections;
public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	public enum AudioChannel { Master, Music, Ambient, fx };

	[Range(0, 1)]
	public float masterVolume = 1; // Volumen de todo
	[Range(0, 1)]
	public float musicVolume = 1f; // volumen de musica
	[Range(0, 1)]
	public float fxVolume = 1; // volumen de efectos de sonido

	public bool MusicIsLooping = true;
	

	
	AudioSource musicSource;
	
	AudioSource fxSource;

	AudioSource narracionSource;

	
	// Aqui van todos los sonidos y musica en las librerias
	SoundLibrary soundLibrary;
	MusicLibrary musicLibrary;
	NarracionLibrary narracionLibrary;
	

	
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		
		soundLibrary = GetComponent<SoundLibrary>();
		musicLibrary = GetComponent<MusicLibrary>();
		
		// Creando los audio sources
		
		GameObject newfxSource = new GameObject("2D fx source");
		fxSource = newfxSource.AddComponent<AudioSource>();
		newfxSource.transform.parent = transform;
		fxSource.playOnAwake = false;

		GameObject newMusicSource = new GameObject("Music source");
		musicSource = newMusicSource.AddComponent<AudioSource>();
		newMusicSource.transform.parent = transform;
		musicSource.loop = MusicIsLooping; // Musica se esta loopeando
		musicSource.playOnAwake = false;

		///////////////////////////////////

		
		/*SetVolume(masterVolume, AudioChannel.Master);
		SetVolume(fxVolume, AudioChannel.fx);
		SetVolume(musicVolume, AudioChannel.Music);*/

	}

	//volumen de todos los elementos
	public void SetVolume(float volumePercent, AudioChannel channel)
	{
		switch (channel)
		{
			case AudioChannel.Master:
				masterVolume = volumePercent;
				break;
			case AudioChannel.fx:
				fxVolume = volumePercent;
				break;
			case AudioChannel.Music:
				musicVolume = volumePercent;
				break;
			
		}

		// volumen del audio source
		fxSource.volume = fxVolume * masterVolume;
		musicSource.volume = musicVolume * masterVolume;
	}
	public void PlayMusic(string musicName, float delay)
	{
		musicSource.clip = musicLibrary.GetClipFromName(musicName);
		musicSource.PlayDelayed(delay);
		SetVolume(musicVolume, AudioChannel.Music);
	}

	//Parar musica
	public void StopMusic()
	{
		musicSource.Stop();
	}


	public void PlaySound2D(string soundName)
	{
		fxSource.PlayOneShot(soundLibrary.GetClipFromName(soundName), fxVolume * masterVolume);
	}

	public void PlayNarracion(int name)
    {
		narracionSource.PlayOneShot(narracionLibrary.GetNarracionFromName(name));
		
    }


	
}
