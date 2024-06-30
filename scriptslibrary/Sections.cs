using System.Collections.Generic;
using System.Linq;
using StorybrewCommon.Animations;
using StorybrewCommon.Storyboarding.CommandValues;
using TimeRange = StorybrewScripts.scriptslibrary.Range<StorybrewCommon.Storyboarding.CommandValues.CommandDecimal>;

namespace StorybrewScripts.scriptslibrary
{
    public class Sections
    {
        public static List<CharacterSection> SectionList = new List<CharacterSection>()
        {
            new CharacterSection()
            {
                TrackTime = new TimeRange(3581, 105748),
                Background = "venti",
                MusicBoxLabel = "track01",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(3581, 41748),
                    new TimeRange(63081, 70192)
                },
                Flashes = new List<CommandDecimal>() {41748},
                Element = "anemo"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(110526, 195007),
                Background = "klee1",
                MusicBoxLabel = "track02",
                DimTimes = new List<Range<CommandDecimal>>()
                {
                    new TimeRange(121688, 130724),
                    new TimeRange(152050, 164123)
                },
                Flashes = new List<CommandDecimal>() {110526, 137828, 165838},
                Element = "pyro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(201895, 269235),
                Background = "klee2",
                MusicBoxLabel = "track03",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(201895, 219979),
                    new TimeRange(250429, 269235)
                },
                Flashes = new List<CommandDecimal>() {219979},
                Element = "pyro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(274268, 327722),
                Background = "xiangling",
                MusicBoxLabel = "track04",
                DimTimes = new List<TimeRange>() {new TimeRange(274268, 280813)},
                Flashes = new List<CommandDecimal>() {290085},
                Element = "pyro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(333936, 406257),
                Background = "fischl1",
                MusicBoxLabel = "track05",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(333936, 360395),
                    new TimeRange(401381, 406257)
                },
                Flashes = new List<CommandDecimal>() {360395},
                Element = "electro"

            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(411687, 481875),
                Background = "fischl2",
                MusicBoxLabel = "track06",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(411687, 433231),
                    new TimeRange(457412, 481875)
                },
                Flashes = new List<CommandDecimal>() {433231, 446459},
                Element = "electro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(486795, 540450),
                Background = "qiqi",
                MusicBoxLabel = "track07",
                DimTimes = new List<TimeRange>() {new TimeRange(486795, 502949)},
                Flashes = new List<CommandDecimal>() {502950, 517950, 527180},
                Element = "cryo"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(548299, 603663),
                Background = "mona",
                MusicBoxLabel = "track08",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(548299, 579390)
                },
                Flashes = new List<CommandDecimal>() {579390},
                Element = "hydro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(608710, 697391),
                Background = "childe1",
                MusicBoxLabel = "track09",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(608710, 635503),
                    new TimeRange(677631, 697391)
                },
                Flashes = new List<CommandDecimal>() {635503, 658482},
                Element = "hydro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(702525, 786664),
                Background = "childe2",
                MusicBoxLabel = "track10",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(702525, 737364),
                    new TimeRange(767328, 786664)
                },
                Flashes = new List<CommandDecimal>() {753580},
                Element = "hydro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(790732, 847613),
                Background = "diona",
                MusicBoxLabel = "track11",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(790732, 807547),
                    new TimeRange(844457, 847613)
                },
                Flashes = new List<CommandDecimal>() {822127, 830622},
                Element = "cryo"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(852489, 908289),
                Background = "xinyan",
                MusicBoxLabel = "track12",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(852489, 869289)
                },
                Flashes = new List<CommandDecimal>() {883690},
                Element = "pyro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(913732, 967132),
                Background = "keqing",
                MusicBoxLabel = "track13",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(913732, 937732)
                },
                Flashes = new List<CommandDecimal>() {944932, 947333},
                Element = "electro"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(975476, 1090014),
                Background = "albedo1",
                MusicBoxLabel = "track14",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(975476, 994930),
                    new TimeRange(1041042, 1055275)
                },
                Flashes = new List<CommandDecimal>() {1026810, 1070364},
                Element = "geo"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(1096213, 1179929),
                Background = "albedo2",
                MusicBoxLabel = "track15",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(1096213, 1105213),
                    new TimeRange(1153502, 1179929)
                },
                Element = "geo"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(1180472, 1190772),
                Background = "",
                MusicBoxLabel = "track15-1"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(1196865, 1288046),
                Background = "ganyu",
                MusicBoxLabel = "track16",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(1196865, 1221796),
                    new TimeRange(1246730, 1265448),
                    new TimeRange(1281033, 1288046)
                },
                Flashes = new List<CommandDecimal>() {1228029, 1268565},
                Element = "cryo"
            },
            new CharacterSection()
            {
                TrackTime = new TimeRange(1297865, 1398003),
                Background = "zhongli",
                MusicBoxLabel = "track17",
                DimTimes = new List<TimeRange>()
                {
                    new TimeRange(1297865, 1317728),
                    new TimeRange(1344210, 1357452),
                    new TimeRange(1387245, 1398003)
                },
                Flashes = new List<CommandDecimal>() {1317728, 1370693},
                Element = "geo"
            },
        };

        public static KeyframedValue<MapState> ComputeMapStates()
        {
            var mapStates = new KeyframedValue<MapState>(null);
            mapStates.Add(-2000, MapState.Pause);

            for (var i = 0; i < SectionList.Count; i++)
            {
                var section = SectionList[i];
                if (!section.HasDimmedStart)
                    mapStates.Add(section.TrackTime.Start, MapState.Active);

                foreach (var dimTime in section.DimTimes)
                {
                    mapStates.Add(dimTime.Start, MapState.Dimmed);

                    if (dimTime.End != section.TrackTime.End)
                        mapStates.Add(dimTime.End, MapState.Active);
                }

                if (i < SectionList.Count - 1)
                {
                    var nextSection = SectionList[i + 1];
                    if (nextSection.TrackTime.Start - section.TrackTime.End < 2000)
                    {
                        continue;
                    }

                    mapStates.Add(section.TrackTime.End, MapState.Pause);
                }
            }

            mapStates.Add(1398003, MapState.Pause);

            return mapStates;
        }
    }

    public class CharacterSection
    {
        public TimeRange TrackTime;
        public string Background;
        public string MusicBoxLabel;

        public List<TimeRange> DimTimes = new List<TimeRange>();
        public List<CommandDecimal> Flashes = new List<CommandDecimal>();

        public string BackgroundPath => $"SB/bg/{Background}_bg.jpg";
        public string ForegroundPath => $"SB/bg/{Background}_fg.png";
        public string MusicBoxLabelPath => $"SB/musicbox/{MusicBoxLabel}.png";

        public CharacterSection NextSection()
        {
            var thisIndex = Sections.SectionList.IndexOf(this);
            if (thisIndex == Sections.SectionList.Count - 1) return null;
            return Sections.SectionList[thisIndex + 1];
        }

        public CommandDecimal NextSectionTime() => NextSection()?.TrackTime.Start ?? 1403796;

        public bool HasDimmedStart => DimTimes.Count > 0 && DimTimes.First().Start == TrackTime.Start;
        public string Element { get ; set ; }
    }

    public struct Range<T>
    {
        public T Start;
        public T End;

        public Range(T start, T end)
        {
            Start = start;
            End = end;
        }
    }

    public enum MapState
    {
        Active = 2,
        Dimmed = 1,
        Pause = 0
    }
}
