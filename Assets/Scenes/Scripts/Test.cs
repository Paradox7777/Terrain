using UnityEngine.Rendering.PostProcessing;
using UnityEngine;
using System;

public class Test : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;

    private ChromaticAberration _chromaticAberration;
    private Vignette _vignette;

    void Start()
    {
        SettingsChromaticAberration();
        SettingVignette();

        var settings = new PostProcessEffectSettings[] { _chromaticAberration, _vignette };
        _postProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 2, settings);

    }

    private void SettingsChromaticAberration()
    {
        _chromaticAberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        _chromaticAberration.enabled.Override(true);
        _chromaticAberration.intensity.Override(1);

    }

    private void SettingVignette()
    {
        _chromaticAberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        _chromaticAberration.enabled.Override(true);
        _chromaticAberration.intensity.Override(1);

    }

    private void Update()
    {
        _chromaticAberration.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
        _vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    }

    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(_postProcessVolume, true, true);
    }
}
