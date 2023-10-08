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
using StorybrewCommon.Storyboarding.CommandValues;
using StorybrewScripts.scriptslibrary;

namespace StorybrewScripts
{
    public class Musicbox : StoryboardObjectGenerator
    {
        public float xPos = 510;
        public float yPos = 400;
        public float scale = 0.3f;

        public override void Generate()
        {
            var layer = GetLayer("musicbox");

            DrawCard(layer);
        }

        private void DrawCard(StoryboardLayer layer)
        {
            var pos = GlobalPos(0, 0);
            var start = 81;
            var end = 1402969;
            var duration = 1000f;

            var card = layer.CreateSprite("SB/musicbox/metadata_card.png", OsbOrigin.CentreLeft, pos);
            card.ScaleVec(OsbEasing.OutSine, start, start + 1000, new Vector2(0f, scale), new Vector2(scale, scale));
            FadeInOut(card, start, end, duration);

            start += 1000;
            end -= 1000;

            var disk = layer.CreateSprite("SB/musicbox/record_disk.png", OsbOrigin.Centre, GlobalPos(23, -1));
            disk.Scale(start, scale);
            FadeInOut(disk, start, end, duration);

            start += 1000;
            end -= 1000;

            var arm = layer.CreateSprite("SB/musicbox/record_arm.png", OsbOrigin.TopRight, GlobalPos(43, -14));
            arm.Scale(start + 2000, scale);
            FadeInOut(arm, start, end, duration);
            arm.Rotate(OsbEasing.InOutSine, start, start+duration, -0.4f, 0.05f);

            var trackStart = Sections.SectionList.First().TrackTime.Start;
            var trackEnd = Sections.SectionList.Last().TrackTime.End;

            var rpm = 33f + 1 / 3f; // vinyls rotate at 33 1/3 rpm
            var minutes = (trackEnd - trackStart) / 1000f / 60f;
            var totalRotations = minutes * rpm * Math.PI;

            disk.Rotate(trackStart,trackEnd+duration, 0f, totalRotations);
            arm.Rotate(trackStart,trackEnd, 0.05f, 0.3f);

            foreach (var section in Sections.SectionList)
            {
                var label = layer.CreateSprite(section.MusicBoxLabelPath, OsbOrigin.CentreRight, GlobalPos(164, -1));
                label.Scale(section.TrackTime.Start, scale);
                var nextSectionTime = section.NextSection()?.TrackTime.Start ?? 1403796;
                FadeInOut(label, section.TrackTime.Start, nextSectionTime - 1000f, 1000f);
            }
        }

        private void FadeInOut(OsbSprite sprite, double start, double end, double duration)
        {
            sprite.Fade(start, start + duration, 0f, 1f);
            sprite.Fade(end - duration, end, 1f, 0f);
        }

        private CommandPosition GlobalPos(CommandPosition localPos) => localPos + new CommandPosition(xPos, yPos);
        private CommandPosition GlobalPos(int x, int y) => GlobalPos(new CommandPosition(x, y));
    }


}
