using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class EffectSettings : MonoBehaviour
{
    [SerializeField]
    private Button _firstPostProcessingButton;

    [SerializeField]
    private Button _secondPostProcessingButton;

    [SerializeField]
    private PostProcessProfile _firstPostProcessingProfile;

    [SerializeField]
    private PostProcessProfile _secondPostProcessingProfile;

    [SerializeField]
    private PostProcessVolume _postProcessVolume;

    private void Start()
    {
        _firstPostProcessingButton.onClick.AddListener(() => ChangeSettings(true));
        _secondPostProcessingButton.onClick.AddListener(() => ChangeSettings(false));
    }
    private void OnDestroy()
    {
        _firstPostProcessingButton.onClick.RemoveAllListeners();

        _secondPostProcessingButton.onClick.RemoveAllListeners();
    }
    private void ChangeSettings(bool isFirstPostProcess)
    {
        _postProcessVolume.profile = isFirstPostProcess ? _firstPostProcessingProfile : _secondPostProcessingProfile;
    }
}
