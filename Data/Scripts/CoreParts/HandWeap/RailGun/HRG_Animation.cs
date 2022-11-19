using System.Collections.Generic;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.AnimationDef;
using static Scripts.Structure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove;
namespace Scripts
{ // Don't edit above this line
    partial class Parts
    {
        private AnimationDef HRG_Animation => new AnimationDef
        {
            Emissives = new[]
            {

                Emissive(
                    EmissiveName: "PrefireEmissive",
                    Colors: new []
                    {
                        Color(red:0, green: 0, blue:0, alpha: 0),//will transitions form one color to the next if more than one
                        Color(red:0f, green: 0.53f, blue:1f, alpha: 0.1F),
                    },
                    IntensityFrom:2f, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:2f,
                    CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: false,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "Emissive0",
                        "Emissive1",
                        "Emissive2",
                        "Emissive3",
                        "Emissive4",
                        "Emissive5",
                        "Emissive6"

                    }),



                Emissive(
                    EmissiveName: "FiringEmissive",
                    Colors: new []
                    {
                        Color(red:0, green: 0, blue:0, alpha: 0),//will transitions form one color to the next if more than one
                        Color(red:0f, green: 0f, blue:0f, alpha: 1),
                    },
                    IntensityFrom:0.2f, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:3f,
                    CycleEmissiveParts: true,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: false,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "Emissive0",
                        "Emissive1",
                        "Emissive2",
                        "Emissive3",
                        "Emissive4",
                        "Emissive5",
                        "Emissive6"

                    }),

               
            },
            AnimationSets = new[]
            {
				#region Barrels Animations
                new PartAnimationSetDef()
                {
                    SubpartId = Names("pg"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 10,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {

                        
                        [Firing] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 5, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    EmissiveName = "FiringEmissive",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0.1), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 3, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 18, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                   
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -0.1), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
  
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    EmissiveName = "PrefireEmissive",//name of defined emissive 
                                    
                                },

                            },
                        [Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                    EmissiveName = "FiringEmissive",//name of defined emissive 
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 8, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0.1), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 83, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -0.1), //linear movement
                                    },
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 35, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    EmissiveName = "PrefireEmissive",//name of defined emissive 
                                    
                                },

                            },

                    }
                },

                new PartAnimationSetDef()
                {
                    SubpartId = Names("RLP"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 10,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {

                        [Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 5, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                    
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 8, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0.15), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                    EmissiveName = "FiringEmissive",//name of defined emissive 
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 143, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                    EmissiveName = "PrefireEmissive",//name of defined emissive 
                                },

                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoGrowth, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                   
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -0.15), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                    EmissiveName = "FiringEmissive",//name of defined emissive 
                                },

                            },
                        

                    }
                },

                new PartAnimationSetDef()
                {
                    SubpartId = Names("RLP2"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 10,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {

                        [Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 15, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                               new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 8, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -0.2), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 143, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear, //Linear,ExpoDecay,ExpoGrowth,Delay,Show, //instant or fade Hide, //instant or fade
                                   
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 0.2), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },

                            },


                    }
                },
               
               
               
				#endregion


            }
        };
    }
}
