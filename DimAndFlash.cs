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
    public class DimAndFlash : StoryboardObjectGenerator
    {
        private static Vector2 Center = new Vector2(640 / 2f, 480 / 2f);
        private HashSet<CommandDecimal> Flashes = new HashSet<CommandDecimal>();

        public override void Generate()
        {
            Sections.SectionList.ForEach(s => s.Flashes.ForEach(t => Flashes.Add(t)));

            GenerateDarken();
            GenerateFlashes();
        }

        private void GenerateFlashes() => Flashes.ToList().ForEach(t => Flash(t));

        private void Flash(CommandDecimal time)
        {
            var flash = GetLayer("Flash").CreateSprite("SB/pixel.jpg", OsbOrigin.Centre, Center);
            flash.Scale(time, 1000);
            flash.Fade(OsbEasing.InOutSine, time, time + 1500, 0.5f, 0f);
        }

        private void GenerateDarken()
        {
            var layer = GetLayer("Darken");

            var darken = layer.CreateSprite("SB/pixel.jpg", OsbOrigin.Centre, new Vector2(640 / 2f, 480 / 2f));
            darken.Scale(0, 1402969, 1000, 1000);
            darken.Color(0, CommandColor.FromRgb(0, 0, 0));

            var vignette = layer.CreateSprite("SB/vignette.png", OsbOrigin.Centre, Center);
            vignette.Scale(0, 1402969, 480f / 540, 480f / 540);

            var previousState = MapState.Pause;

            var mapStates = Sections.ComputeMapStates();
            mapStates.ForEachPair((previous, next) =>
            {
                var duration = 1000;

                if (next.Value == MapState.Active)
                {
                    if (Flashes.Contains(next.Time))
                        duration = 10;
                    else
                        duration = 500;
                }
                else if (next.Value == MapState.Pause)
                {
                    duration = 1500;
                }

                var time = next.Time;
                if (previous.Value == MapState.Pause)
                    time -= duration;

                darken.Fade(OsbEasing.InOutSine,
                    time, time + duration,
                    StateToDimOpacity(previousState), StateToDimOpacity(next.Value));

                vignette.Fade(OsbEasing.InOutSine,
                    time, time + duration,
                    StateToVignetteOpacity(previousState), StateToVignetteOpacity(next.Value));

                previousState = next.Value;
            });
        }

        private CommandDecimal StateToDimOpacity(MapState state)
        {
            switch (state)
            {
                case MapState.Active: return 0;
                case MapState.Dimmed: return 0.5;
                default: return 1;
            }
        }

        private CommandDecimal StateToVignetteOpacity(MapState state)
        {
            switch (state)
            {
                case MapState.Active: return 0.85;
                default: return 1;
            }
        }
    }
}
