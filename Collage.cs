using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StorybrewCommon.Animations;
using StorybrewCommon.Storyboarding.CommandValues;
using StorybrewScripts.scriptslibrary;

namespace StorybrewScripts
{
    public class Collage : StoryboardObjectGenerator
    {
        private StoryboardLayer BackgroundLayer;
        private StoryboardLayer ForegroundLayer;

        private static Vector2 Center = new Vector2(640 / 2f, 480 / 2f);

        public override void Generate()
        {
            BackgroundLayer = GetLayer("Background");
            ForegroundLayer = GetLayer("Foreground");

            foreach (var section in Sections.SectionList)
            {
                if (section.Background == "") continue;
                GenerateSection(section);
            }
        }

        private void GenerateSection(CharacterSection section)
        {
            var bg = GenerateSectionSprite(BackgroundLayer, section.BackgroundPath, section);
            var fg = GenerateSectionSprite(ForegroundLayer, section.ForegroundPath, section);

            var shake = GenerateParallaxShake(section, 20);
            shake.ForEachPair((start, end) =>
            {
                bg.Move(
                    OsbEasing.InOutSine,
                    start.Time, end.Time,
                    Center + start.Value, Center + end.Value);
                fg.Move(
                    OsbEasing.InOutSine,
                    start.Time, end.Time,
                    Center + start.Value / 2f, Center + end.Value / 2f);
            });
        }

        private OsbSprite GenerateSectionSprite(StoryboardLayer layer, String path, CharacterSection section)
        {
            var bitmap = GetMapsetBitmap(path);
            var scale = Math.Max(640f / bitmap.Width, 480f / bitmap.Height) * 1.25f;

            var sprite = layer.CreateSprite(path, OsbOrigin.Centre, Center);
            sprite.Scale(section.TrackTime.Start - 1000, scale);
            sprite.Rotate(section.TrackTime.Start, section.TrackTime.End + 2000, -0.05f, 0.05f);

            foreach (var flash in section.Flashes)
                Bounce(sprite, scale, flash);

            return sprite;
        }

        private void Bounce(OsbSprite sprite, float scale, CommandDecimal time)
        {
            sprite.Scale(OsbEasing.InSine, time - 10f, time, scale, scale * 1.05f);
            sprite.Scale(OsbEasing.OutSine, time, time + 1500f, scale * 1.05f, scale);
        }

        KeyframedValue<Vector2> GenerateParallaxShake(CharacterSection section, CommandDecimal radius)
        {
            var pos = new KeyframedValue<Vector2>(InterpolatingFunctions.Vector2);

            var currentTime = section.TrackTime.Start;
            var currentAngle = 0.0;
            var currentRadius = 0.0;

            pos.Add(currentTime, Vector2.Zero);

            while (currentTime < section.TrackTime.End - 10000f)
            {
                currentTime += Random(2500, 5000);
                currentRadius = Random(radius / 2f, radius);

                if (section.DimTimes.Any(d => currentTime >= d.Start && currentTime <= d.End))
                    currentRadius /= 4;

                // make sure the next angle is on the opposite side
                currentAngle += (Math.PI + Random(-Math.PI, Math.PI) / 2f) % (2 * Math.PI);

                pos.Add(currentTime, new CommandPosition(Math.Sin(currentAngle) * currentRadius, Math.Cos(currentAngle) * currentRadius));
            }

            pos.Add(section.TrackTime.End, Vector2.Zero);

            return pos;
        }
    }
}
