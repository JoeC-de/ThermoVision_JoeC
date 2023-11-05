//License: ThermoVision_JoeC\Properties\Lizenz.txt
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using ZedGraph;
using JoeC;
using CommonTVisionJoeC;
using ThermoVision_JoeC.Komponenten;
using System.Collections.Generic;
using System.Diagnostics;

namespace ThermoVision_JoeC
{
    /// <summary>
    /// Global (static) Values
    /// </summary>
	public static class V 
	{
        #region EnumText

        public enum Told
        {
            Temperatur = 0,
            Messpunkt = 1,
            NotFound = 2,
            ErrReadLastSet = 3,
            Seconds = 4,
            Temp = 5,
            //6-10
            Maus = 6,
            FunktionBestätigen = 7,
            SollenAlleMeasGelöschtWerden = 8,
            Fusionsfenster = 9,
            IstUnbekannt = 10,
            //11-15
            Gespeichert = 11,
            BildDatein = 12,
            AlleDatein = 13,
            AuflösungNichtErkannt = 14,
            Radiometrische = 15,
            //16-20
            Open = 16,
            SelectCodecFirst = 17,
            KeinDatensatzGefunden = 18,
            RadioLoadAbgebrochen = 19,
            Entferne = 20,
            //21-25
            Empfange = 21,
            Vorschau = 22,
            SpeichernAls = 23,
            JaUnterDiesemPfad = 24,
            NeinNeueDateiErstellen = 25,
            //26-30
            RadiometrischSpeichern = 26,
            Wärmebild = 27,
            BildIstImZwischenspeicher = 28,
            Only = 29,
            Thermal = 30,
            //31-35
            Visual,
            Isotherm,
            M8KonnteNichtGeladenWerden,
            OpenFail,
            Download = 35,
            //36-40
            Transfer,
            NichtGefunden,
            TelnetVerbindungsFehler,
            ZuWenigDatenInDerSEQ,
            KeineKamera = 40,
            //41-45
            KeineKameraGefunden,
            Start,
            Stop,
            Restart,
            RestartFail = 45,
            //46-50
            Offline,
            StartStream,
            StopStream,
            FlirImgTableHead,
            VorkommenImBild = 50,
            //51-55
            Auflösung,
            Dateigröße,
            NeuesBildAufnehmen,
            BildÜberschreiben,
            WärmeSequenzDatensatz = 55,
            //56-60
            Abbruch,
            DateiExistiertSchon,
            OverwriteAsk,
            CalDataToCameraAsk,
            CalStart = 60,
            //61-65
            CalGetLow,
            CalGetHi,
            Done,
            TempSwitch_Bed,
            TempSwitch_Controls = 65,
            //66-70
            NoSubfolder,
            ZuVieleZeichenFuerMeas,
            DurchsucheLaufwerke,
            GrabAllMeasData,
            ReportOverwriteAsk = 70,
            //71-75
            ErrorOnDelete,
            Measure,
            DeleteTree,
            DeleteAllAsk,
            TryRunSelectedFile,
            //76-80
            FlirPwInClipboard,
            ToManyUsersRestartCamera,
            Timeout,
            WarteAufAntwort,
            Warte
        }

        public static string[] TXT = new string[]{
    		//0
    		"Temperatur",
            "Messpunkt",
            "Nicht gefunden",
            "Fehler beim Lesen der letzten Einstellungen.",
            "Sekunden",
            "Temp",
    		//6-10
    		"Maus",
            "Funktion Bestätigen",
            "Sollen wirklich alle Messungen gelöscht werden?",
            "Fusionsfenster",
            "ist Unbekannt",
    		//11-15
    		"gespeichert",
            "Bilddatein",
            "alle Datein",
            "Auflösung nicht erkannt",
            "Radiometrische",
    		//16-20
    		"Öffnen",
            "Es wurde noch kein Codec für das Video ausgewählt",
            "Keinen Datensatz gefunden in",
            "Radiometrisches Laden abgebrochen",
            "Entferne",
    		//21-25
    		"Empfange",
            "Vorschau...",
            "Speichern als",
            "Ja: Unter diesem Pfad speichern",
            "Nein: neue Datei erstellen",
    		//26-30
    		"Radiometrisch Speichern",
            "Wärmebild",
            "Bild ist im Zwischenspeicher",
            "only",
            "Thermal",
    		//31-35
    		"Visual",
            "Isotherm",
            "M8 JPG konnte nicht geladen werden...",
            "Open Image Fail",
            "Download",
    		//36-40
    		"Übertrage...",
            "nicht gefunden",
            "Telnet Verbindungs Fehler",
            "zu wenig Daten in der *.seq Datei.",
            "Keine Kamera",
    		//41-45
    		"Keine Kamera gefunden",
            "Start",
            "Stop",
            "Restart",
            "Restart FAIL!",
    		//46-50
    		"Offline",
            "Start Streaming",
            "Stop Streaming",
            "Seek Thermal Kamera nicht erkannt",
            "Vorkommen im Bild (Pixel)",
    		//51-55
    		"Auflösung",
            "Dateigröße",
            "neues Bild einfügen",
            "überschreibe Bild (",
            "Wärmesequenz Datensatz",
    		//56-60
    		"Abbruch",
            "Datei existiert schon:",
            "Überschreiben?",
            "Cal Data in Kamera schreiben?",
            "Starte Kalibrierung...",
    		//61-65
    		"Übernehme Daten für Low Temp...",
            "Übernehme Daten für Hi Temp...",
            "Fertig.",
            "Größer als&Kleiner als&Gleich (gerundet auf 1 Digit)&Zwischen&Nicht zwischen",
            "Aktiv&Überwachte Messung:&Bedingung:&Aktionen:&Abschalten (Aktiv->Off)&Timeout bis nächste Aktion in Sekunden&Datei öffnen / Anwendung starten&nur 1x ausführen (schaltet sich selbst ab)&Bild aufnehmen (Radiometrisch Speichern)&Unterordner:&SerialPort->Send Text:&SerialPort->Send Bytes:&SerialPort->Send Messwert als Text&Einstellungen speichern/laden&Setup Laden&Setup Speichern&",
    		//66-70
    		"<kein unterordner>",
            "Es sind > 50 Zeichen eingegeben,\r\n gespeichert wird nur bis 50.",
            "Durchsuche Laufwerke",
            "Grab all Measurement Data",
            "Zum Report hinzufügen?\r\n\r\nJa = fügt hinzu\r\nNein = ersetzt was schon da ist\r\nAbbruch = nichts machen",
            //71-75
            "Fehler beim löschen",
            "Messe...",
            "Baum löschen",
            "Soll wirklich alles gelöscht werden?",
            "Ausgeählte Datei starten um die Funktion zu testen?",
            //76-80
            "Zum einloggen: Passwort ist in der Zwischenablage, Username: flir",
            "Zu viele registrierte Telnetnutzer. Kamera neu starten...",
            "Timeout",
            "Warte auf Antwort",
            "Warte..."
            //81-85
      	};
        public static string Txt(Told Tenum)
		{
			return TXT[(int)Tenum];
		}
      	
        #endregion
        #region <<<GlobalVars>>>
        public static bool lock_ctrl = false;
        public static TempMathTv TempMathBase; //from MF.fSettings.uC_PlanckCalBase.tempMathLocal
        public static TempMathTv TempMathGlobal; //from MF.fCal.uC_PlanckCalGlobal.tempMathLocal
        public static TempMathTv TempMathSelected; //from MF.fCal
        #endregion

        #region CurveLinePlot

        public static PointPairList[] Mess_Line = new PointPairList[5];
      	public static LineItem[] Curve = new LineItem[5];
        public static void CurveVisible(int index, bool isVisible, bool isShowLegend) {
            if (Curve == null) { return; }
            index -= 1; //curve 1-5 is index 0-4
            if (Curve.Length < index) { return; }
            if (Curve[index] == null) { return; }
            Curve[index].IsVisible = isVisible; Curve[index].Label.IsVisible = isShowLegend;
        }
        #endregion
      	
      	#region GlobalFuncts

        public static bool isConfig_ONE(AppConfigs cfg) {
            return isConfig_ONE(Enum.GetName(typeof(AppConfigs), cfg));
        }
        public static bool isConfig_ONE(string NameOf_AppConfig_Entry) 
        {
            try {
                string entry = System.Configuration.ConfigurationManager.AppSettings[NameOf_AppConfig_Entry];
                if (entry == "1") {
                    return true;
                }
            }
            catch (Exception) { ; }
            return false;
        }
        #endregion

        #region Measurements
        public static double TempApplyEmisivity(double emisivity, double reflectedTemp, double source) {
            if (emisivity < 0 || 1 > emisivity) {
                return source;
            }
            double newVal = (emisivity * source) + ((1 - emisivity) * reflectedTemp);
            return newVal;
        }
        #endregion

        #region Enums
        
        public static EnumThermalCameraType Get_ThermalCameraType_FromString(string name) {
            foreach (var item in Enum.GetValues(typeof(EnumThermalCameraType))) {
                if (item.ToString() == name) {
                    return (EnumThermalCameraType)item;
                }
            }
            return EnumThermalCameraType.None;
        }
        public enum AppConfigs {
            Extension_SEEK,
            Extension_FLIR
        }
        #endregion
    }
}