using System.Collections.Generic;
using System.Numerics;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Shared.Random;
using Robust.Shared.Timing;
using Robust.Shared.ViewVariables;

namespace Content.Client.Parallax;

/// <summary>
///     Renders animated video-frame backgrounds, cycling between Brotherhood and Vetranger themes.
/// </summary>
public sealed class ParallaxControl : Control
{
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly IResourceCache _resCache = default!;
    [Dependency] private readonly IRobustRandom _random = default!;

    [ViewVariables(VVAccess.ReadWrite)] public Vector2 Offset { get; set; }

    private const float FramesPerSecond = 6f;
    private const float CycleDuration = 25f; // seconds per theme

    private readonly List<Texture>[] _themeFrames = new List<Texture>[2];
    private int _currentTheme;
    private float _cycleStartTime;

    public ParallaxControl()
    {
        IoCManager.InjectDependencies(this);

        Offset = new Vector2(_random.Next(0, 1000), _random.Next(0, 1000));
        RectClipContent = true;

        LoadFrames(0, "/Textures/Parallaxes/brotherhood/", 156);
        LoadFrames(1, "/Textures/Parallaxes/vetranger/", 163);

        _currentTheme = _random.Next(0, 2);
        _cycleStartTime = (float)_timing.RealTime.TotalSeconds;
    }

    private void LoadFrames(int themeIdx, string dir, int count)
    {
        _themeFrames[themeIdx] = new List<Texture>();
        for (var i = 0; i < count; i++)
        {
            var path = $"{dir}{i:D4}.png";
            if (_resCache.TryGetResource<TextureResource>(path, out var texRes))
                _themeFrames[themeIdx].Add(texRes.Texture);
            else
                break; // stop on first missing frame
        }
    }

    protected override void Draw(DrawingHandleScreen handle)
    {
        var frames = _themeFrames[_currentTheme];
        if (frames.Count == 0) return;

        var elapsed = (float)_timing.RealTime.TotalSeconds - _cycleStartTime;

        // Switch theme every CycleDuration
        if (elapsed >= CycleDuration)
        {
            _currentTheme = (_currentTheme + 1) % 2;
            _cycleStartTime = (float)_timing.RealTime.TotalSeconds;
            elapsed = 0f;

            // Reload if empty
            if (_themeFrames[_currentTheme].Count == 0)
                _currentTheme = (_currentTheme + 1) % 2;
        }

        // Calculate current frame
        var frameIndex = (int)(elapsed * FramesPerSecond) % frames.Count;
        var tex = frames[frameIndex];

        // Fill entire control area
        var ourSize = PixelSize;
        var texSize = tex.Size;

        // Scale to fill (maintain aspect, crop overflow)
        var scale = MathF.Max((float)ourSize.X / texSize.X, (float)ourSize.Y / texSize.Y);
        var drawSize = new Vector2(texSize.X * scale, texSize.Y * scale);
        var origin = (ourSize - drawSize) / 2f;

        // Slow parallax drift
        var currentTime = (float)_timing.RealTime.TotalSeconds;
        var drift = Offset + new Vector2(currentTime * 10f, 0f);
        origin.X += drift.X % 10f;

        handle.DrawTextureRect(tex, UIBox2.FromDimensions(origin, drawSize));
    }
}


