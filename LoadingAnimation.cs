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
using System.Linq;
using StorybrewCommon.Animations;
using StorybrewCommon.Storyboarding.CommandValues;
using StorybrewScripts.scriptslibrary;

namespace StorybrewScripts
{
    public class LoadingAnimation : StoryboardObjectGenerator
    {
        private StoryboardLayer Layer;
        private CommandPosition Center = new Vector2(640 / 2f, 480 / 2f);

        public override void Generate()
        {
            Layer = GetLayer("Loading");

            Sections.ComputeMapStates().ForEachPair((current, next) =>
            {
                if (current.Value != MapState.Pause) return;
                if (next.Time - current.Time < 2000) return;

                var start = current.Time + 1500;
                var end = next.Time - 2000;

                var nextSection = Sections.SectionList.Find(s => next.Time == s.TrackTime.Start);

                CreateElements(start, end, nextSection.Element);
                CreateLoadingBars(start, end);
            });
        }

        private void CreateLoadingBars(CommandDecimal start, CommandDecimal end)
        {
            float width = 640 * 0.8f;

            var pos = new CommandPosition(-width / 2f, 150) + Center;

            var loading = Layer.CreateSprite("SB/pixel.jpg", OsbOrigin.BottomLeft, pos);
            loading.ScaleVec(OsbEasing.InOutSine, start, end, new Vector2(0, 3), new Vector2(width, 3));
            loading.Fade(start, start + 500, 0, 0.5);
            loading.Fade(end, end + 1000, 0.5, 0);

            var loadingShadow = Layer.CreateSprite("SB/pixel.jpg", OsbOrigin.BottomLeft, pos);
            loadingShadow.ScaleVec( start, end, new Vector2(width, 3), new Vector2(width, 3));
            loadingShadow.Fade(start, end + 1000, 0.05, 0.05);
        }

        private void CreateElements(CommandDecimal start, CommandDecimal end, string flashElement)
        {
            var elements = new []
            {
                "anemo",
                "cryo",
                "dendro",
                "electro",
                "geo",
                "hydro",
                "pyro"
            };

            var width = 25f;

            var spacing = 30f;
            var totalWidth = spacing * elements.Length;
            var basePos = Center + new CommandPosition(-totalWidth/2f, 115);

            var duration = Math.Min(end - start, 2500);

            var bounceStart = ((end - start) - duration) / 2f + start;
            var bounceOverlap = 2f;
            var timePerElement = duration / (elements.Length + bounceOverlap);

            for (var i = 0; i < elements.Length; i++)
            {
                var element = elements[i];

                var path = $"SB/elements/{element}.png";
                var bitmap = GetMapsetBitmap(path);
                var scale = width / bitmap.Width;
                var newPos = basePos + new CommandPosition(i * spacing, 0);

                var sprite = Layer.CreateSprite(path, OsbOrigin.Centre, newPos);
                sprite.Scale(start, end, scale, scale);

                var opacity = 0.1;
                if (element == flashElement) opacity = 0.4;

                sprite.Fade(start, start + 500, 0, opacity);
                sprite.Fade(end, end + 1000, opacity, 0);

                var startMoveTime = bounceStart + timePerElement * i;
                var endMoveTime = bounceStart + timePerElement * (i+1+bounceOverlap);
                var midMoveTime = (endMoveTime - startMoveTime) / 2f + startMoveTime;

                var upOffset = -5;

                var upPos = newPos + new CommandPosition(0, upOffset);
                sprite.Move(OsbEasing.InOutSine, startMoveTime, midMoveTime, newPos, upPos);
                sprite.Move(OsbEasing.InOutSine, midMoveTime, endMoveTime, upPos, newPos);
            }
        }
    }
}
