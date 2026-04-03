using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundManager : MonoBehaviour
{

    [Header("Clips")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] private AudioClip fallClip;
    [SerializeField] private AudioClip gameOverClip;

    private AudioSource audioSource;
    private Player player;



    [Inject]
    public void Construct(Player player, AudioSource audioSource)
    {
        this.audioSource = audioSource;
        this.player = player;
    }


    private void OnEnable()
    {
        player.onJump += PlayJump;
        player.onLand += PlayLand;
        player.onFall += PlayFall;
        player.onGameOver += PlayGameOver;
    }


    private void OnDisable()
    {
        player.onJump -= PlayJump;
        player.onLand -= PlayLand;
        player.onFall -= PlayFall;
        player.onGameOver -= PlayGameOver;
    }


    private void PlayJump()
    {
        Play(jumpClip);
    }


    private void PlayLand()
    {
        Play(landClip);
    }


    private void PlayFall()
    {
        Play(fallClip);
    }


    private void PlayGameOver()
    {
        Play(gameOverClip);
    }


    private void Play(AudioClip clip)
    {
        if (clip == null) return;

        audioSource.PlayOneShot(clip);
    }
}