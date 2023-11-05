//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.Drawing;

namespace ThermoVision_JoeC 
{
    public interface iCamera 
    {
        /// <summary>
        /// Connect to a TIC (Thermal Imaging Camera) with a
        /// info string. The info string can be used for ID
        /// or Port Settings.
        /// </summary>
        CamResponse Connect(string info);
        CamResponse Disconnect(string info);
        /// <summary>
        /// Get the resolution of a thermal Frame as Point
        /// X = Width
        /// Y = Height
        /// </summary>
        Point Get_Resolution();
        /// <summary>
        /// return all PixelTemperatures from left to right
        /// and then from up to down.
        /// have to Match with Get_Resolution() -> X*Y	
        /// </summary>
        float[] Get_ThermalFrame();
        /// <summary>
        /// return all Pixel ADC Values (Radiation RAW) from left to right
        /// and then from up to down.
        /// have to Match with Get_Resolution() -> X*Y		
        /// </summary>
        ushort[] Get_RawFrame();
        /// <summary>
        /// return true(valid) or false(defect) for each Pisel from left to right
        /// and then from up to down.
        /// have to Match with Get_Resolution() -> X*Y		
        /// </summary>
        bool[] Get_DeathPixels();
        /// <summary>
        /// Optional: Send a Command to the Camera.
        /// </summary>
        CamResponse SendCommand(string CMD);
        /// <summary>
		/// Optional: ask Camera for something.
		/// </summary>
		string SendQuery(string CMD);
    }
    public enum CamResponse {
        Fail = 0,
        Pass = 1,
        NotFound = 2
    }
}
