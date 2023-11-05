//License: CommonTVisionJoeC\Properties\Lizenz.txt
namespace CommonTVisionJoeC
{
    public enum MeasSelTyp
    {
        Null = 0,
        Spot = 1,
        Box = 2,
        Line = 3,
        SeekRaw = 4,
        DIYSpot = 5,
        DeltaLine = 6,
        TExpertRaw = 7,
        SerSens = 8
    }

    public enum EnumThermalCameraType
    {
        None,
        Simulation,
        TE_WinUsb,
        TE_i3_Dll_Temp,
        TE_i3_Dll_Raw,
        Seek_Thermal_WinUsb,
        TcamDll1,
        TcamDll2,
        FlirOneUltimateApp,
        DIYThermocam,
        Optris_IrDirect
    }
    public enum ScaleModeState
    {
        Range_MaxA_MinA,
        Range_MaxA_MinM,
        Range_MaxA_MinF,
        Range_MaxM_MinA,
        Range_MaxM_MinM,
        Range_MaxM_MinF,
        Range_MaxF_MinA,
        Range_MaxF_MinM,
        Range_MaxF_MinF
    }
    public enum TempConvType { 
        Device,
        TwoPoint,
        Planck,
        Base
    }
    public enum CamDir
    {
        Rot0 = 0,
        Rot90 = 1,
        Rot180 = 2,
        Rot270 = 3
    }
    public enum HistogramType
    {
        Fixed_1,
        Fixed_0p1,
        Fixed_0p01,
        Dynamic_0p1,
        Dynamic_0p01,
        Dynamic_0p001,
        Dynamic_0p0001,
    }
    public enum RadioImageFrameType 
    { 
        //initial FrameVersion, store Temperature frame. 2 bytes per pixl
        Frame0 = 0,
        //same as Frame0
        Frame1 = 1,
        //second FrameVersion, store raw frame and Planck values.
        Frame2 = 2
    }
    public enum RadioImageMeasureType 
    { 
        //fixed length of 500 bytes
        Meas500 = 0,
        //dynamic length, additional with Note and some labels
        MeasV1 = 1,
        //dynamic length, additional with ranged box
        MeasV2 = 2,
    }
    public enum RadioSequenceFrameType {
        //store Temperature frame. 2 bytes per pixl
        FrameTemp = 0,
        //second FrameVersion, store raw frame and Planck values.
        FrameRawPlanck = 1,
        FrameFlirSeqA = 2,
        FrameFlirSeqB = 3,
        FrameFlirSeqC = 4
    }
}
