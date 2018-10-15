using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_NTP_TIME_SYNC_V1_0
{
    public class CrestronModuleClass_NTP_TIME_SYNC_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput DEBUG;
        Crestron.Logos.SplusObjects.DigitalInput LOGGING;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SYNCTIME;
        Crestron.Logos.SplusObjects.AnalogInput GMT_OFFSET_MINUTES;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SERVER_IP__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SYNCSUCCESSFUL;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SYNCFAILED;
        SplusUdpSocket NTPSERVER;
        ushort CURRSERVER = 0;
        CrestronString TEMPRXIP__DOLLAR__;
        CrestronString TEMPSTAMP__DOLLAR__;
        private ushort ISLEAPYEAR (  SplusExecutionContext __context__, ushort YEAR ) 
            { 
            
            __context__.SourceCodeLine = 145;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( YEAR , 400 ) == 0))  ) ) 
                {
                __context__.SourceCodeLine = 146;
                return (ushort)( 1) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 148;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( YEAR , 100 ) == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 149;
                    return (ushort)( 0) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 151;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( YEAR , 4 ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 152;
                        return (ushort)( 1) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 155;
                        return (ushort)( 0) ; 
                        }
                    
                    }
                
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort DAYSINMONTH (  SplusExecutionContext __context__, ushort MON , ushort YEAR ) 
            { 
            
            __context__.SourceCodeLine = 164;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (MON == 4) ) || Functions.TestForTrue ( Functions.BoolToInt (MON == 6) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (MON == 9) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (MON == 11) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 165;
                return (ushort)( 30) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 168;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MON == 2))  ) ) 
                    {
                    __context__.SourceCodeLine = 169;
                    if ( Functions.TestForTrue  ( ( ISLEAPYEAR( __context__ , (ushort)( YEAR ) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 170;
                        return (ushort)( 29) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 172;
                        return (ushort)( 28) ; 
                        }
                    
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 176;
                    return (ushort)( 31) ; 
                    }
                
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private CrestronString LONGTOSTR (  SplusExecutionContext __context__, uint VAL ) 
            { 
            ushort HWORD = 0;
            ushort LWORD = 0;
            
            CrestronString DATA__DOLLAR__;
            DATA__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            
            __context__.SourceCodeLine = 186;
            Functions.ClearBuffer ( DATA__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 188;
            HWORD = (ushort) ( Functions.HighWord( (uint)( VAL ) ) ) ; 
            __context__.SourceCodeLine = 189;
            LWORD = (ushort) ( Functions.LowWord( (uint)( VAL ) ) ) ; 
            __context__.SourceCodeLine = 191;
            DATA__DOLLAR__  .UpdateValue ( Functions.Chr (  (int) ( Functions.High( (ushort) HWORD ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) HWORD ) ) ) + Functions.Chr (  (int) ( Functions.High( (ushort) LWORD ) ) ) + Functions.Chr (  (int) ( Functions.Low( (ushort) LWORD ) ) )  ) ; 
            __context__.SourceCodeLine = 196;
            return ( DATA__DOLLAR__ ) ; 
            
            }
            
        private uint STRTOLONG (  SplusExecutionContext __context__, CrestronString STR__DOLLAR__ ) 
            { 
            uint VAL = 0;
            
            
            __context__.SourceCodeLine = 204;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STR__DOLLAR__ ) < 4 ))  ) ) 
                {
                __context__.SourceCodeLine = 205;
                return (uint)( 0) ; 
                }
            
            __context__.SourceCodeLine = 207;
            VAL = (uint) ( Byte( STR__DOLLAR__ , (int)( 4 ) ) ) ; 
            __context__.SourceCodeLine = 208;
            VAL = (uint) ( (VAL + (Byte( STR__DOLLAR__ , (int)( 3 ) ) << 8)) ) ; 
            __context__.SourceCodeLine = 209;
            VAL = (uint) ( (VAL + (Byte( STR__DOLLAR__ , (int)( 2 ) ) << 16)) ) ; 
            __context__.SourceCodeLine = 210;
            VAL = (uint) ( (VAL + (Byte( STR__DOLLAR__ , (int)( 1 ) ) << 24)) ) ; 
            __context__.SourceCodeLine = 212;
            return (uint)( VAL) ; 
            
            }
            
        private CrestronString PRINTSTAMP (  SplusExecutionContext __context__, CrestronString STAMP64__DOLLAR__ ) 
            { 
            CrestronString TEMPSTAMP__DOLLAR__;
            TEMPSTAMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
            
            uint HI32 = 0;
            uint LO32 = 0;
            
            
            __context__.SourceCodeLine = 222;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( STAMP64__DOLLAR__ ) != 8))  ) ) 
                {
                __context__.SourceCodeLine = 223;
                return ( "INVALID" ) ; 
                }
            
            __context__.SourceCodeLine = 225;
            HI32 = (uint) ( STRTOLONG( __context__ , Functions.Left( STAMP64__DOLLAR__ , (int)( 4 ) ) ) ) ; 
            __context__.SourceCodeLine = 226;
            LO32 = (uint) ( STRTOLONG( __context__ , Functions.Right( STAMP64__DOLLAR__ , (int)( 4 ) ) ) ) ; 
            __context__.SourceCodeLine = 228;
            MakeString ( TEMPSTAMP__DOLLAR__ , "{0:d}.{1:d10}", (uint)HI32, (uint)LO32) ; 
            __context__.SourceCodeLine = 230;
            return ( TEMPSTAMP__DOLLAR__ ) ; 
            
            }
            
        private short CALCGMTOFFSET (  SplusExecutionContext __context__ ) 
            { 
            short OFFSETMINS = 0;
            
            
            __context__.SourceCodeLine = 242;
            OFFSETMINS = (short) ( GMT_OFFSET_MINUTES  .ShortValue ) ; 
            __context__.SourceCodeLine = 245;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( OFFSETMINS >= Functions.ToSignedInteger( -( 720 ) ) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( OFFSETMINS <= 780 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 246;
                return (short)( OFFSETMINS) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 248;
                return (short)( Functions.GetGmtOffset()) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private uint GETTIMEINSECS (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            ushort CYEAR = 0;
            ushort CMON = 0;
            ushort CDAY = 0;
            ushort CHOUR = 0;
            ushort CMIN = 0;
            ushort CSEC = 0;
            
            uint SECS = 0;
            
            
            __context__.SourceCodeLine = 259;
            CYEAR = (ushort) ( Functions.GetYearNum() ) ; 
            __context__.SourceCodeLine = 260;
            CMON = (ushort) ( Functions.GetMonthNum() ) ; 
            __context__.SourceCodeLine = 261;
            CDAY = (ushort) ( Functions.GetDateNum() ) ; 
            __context__.SourceCodeLine = 263;
            CHOUR = (ushort) ( Functions.GetHourNum() ) ; 
            __context__.SourceCodeLine = 264;
            CMIN = (ushort) ( Functions.GetMinutesNum() ) ; 
            __context__.SourceCodeLine = 265;
            CSEC = (ushort) ( Functions.GetSecondsNum() ) ; 
            __context__.SourceCodeLine = 267;
            SECS = (uint) ( 0 ) ; 
            __context__.SourceCodeLine = 271;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1900 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(CYEAR - 1); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 272;
                SECS = (uint) ( (SECS + (86400 * (365 + ISLEAPYEAR( __context__ , (ushort)( I ) )))) ) ; 
                __context__.SourceCodeLine = 271;
                }
            
            __context__.SourceCodeLine = 275;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)(CMON - 1); 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                {
                __context__.SourceCodeLine = 276;
                SECS = (uint) ( (SECS + (86400 * DAYSINMONTH( __context__ , (ushort)( I ) , (ushort)( CYEAR ) ))) ) ; 
                __context__.SourceCodeLine = 275;
                }
            
            __context__.SourceCodeLine = 279;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)(CDAY - 1); 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                {
                __context__.SourceCodeLine = 280;
                SECS = (uint) ( (SECS + 86400) ) ; 
                __context__.SourceCodeLine = 279;
                }
            
            __context__.SourceCodeLine = 283;
            ushort __FN_FORSTART_VAL__4 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__4 = (ushort)(CHOUR - 1); 
            int __FN_FORSTEP_VAL__4 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                {
                __context__.SourceCodeLine = 284;
                SECS = (uint) ( (SECS + 3600) ) ; 
                __context__.SourceCodeLine = 283;
                }
            
            __context__.SourceCodeLine = 287;
            ushort __FN_FORSTART_VAL__5 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__5 = (ushort)(CMIN - 1); 
            int __FN_FORSTEP_VAL__5 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                {
                __context__.SourceCodeLine = 288;
                SECS = (uint) ( (SECS + 60) ) ; 
                __context__.SourceCodeLine = 287;
                }
            
            __context__.SourceCodeLine = 291;
            SECS = (uint) ( (SECS + CSEC) ) ; 
            __context__.SourceCodeLine = 294;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.GetDst() == 1))  ) ) 
                {
                __context__.SourceCodeLine = 295;
                SECS = (uint) ( (SECS - 3600) ) ; 
                }
            
            __context__.SourceCodeLine = 298;
            SECS = (uint) ( (SECS - (CALCGMTOFFSET( __context__ ) * 60)) ) ; 
            __context__.SourceCodeLine = 300;
            if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 301;
                Print( "[NTP.getTimeInSecs()][SECS={0:d}]\r\n", (uint)SECS) ; 
                }
            
            __context__.SourceCodeLine = 304;
            return (uint)( SECS) ; 
            
            }
            
        private void SETDATETIME (  SplusExecutionContext __context__, CrestronString TSTAMP64__DOLLAR__ ) 
            { 
            CrestronString ROUND__DOLLAR__;
            ROUND__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            uint TSTAMP = 0;
            uint TFRACT = 0;
            
            ushort TYEAR = 0;
            ushort TMON = 0;
            ushort TDAY = 0;
            ushort THOUR = 0;
            ushort TMIN = 0;
            ushort TSEC = 0;
            
            
            __context__.SourceCodeLine = 316;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( TSTAMP64__DOLLAR__ ) != 8))  ) ) 
                { 
                __context__.SourceCodeLine = 318;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 319;
                    Print( "[NTP.setDateTime()] Invalid Timestamp ({0})\r\n", PRINTSTAMP (  __context__ , TSTAMP64__DOLLAR__) ) ; 
                    }
                
                __context__.SourceCodeLine = 321;
                return ; 
                } 
            
            __context__.SourceCodeLine = 324;
            Functions.ClearBuffer ( ROUND__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 326;
            TSTAMP = (uint) ( STRTOLONG( __context__ , Functions.Left( TSTAMP64__DOLLAR__ , (int)( 4 ) ) ) ) ; 
            __context__.SourceCodeLine = 327;
            TFRACT = (uint) ( STRTOLONG( __context__ , Functions.Right( TSTAMP64__DOLLAR__ , (int)( 4 ) ) ) ) ; 
            __context__.SourceCodeLine = 332;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((TFRACT >> 31) == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 334;
                TSTAMP = (uint) ( (TSTAMP + 1) ) ; 
                __context__.SourceCodeLine = 335;
                ROUND__DOLLAR__  .UpdateValue ( "+"  ) ; 
                } 
            
            __context__.SourceCodeLine = 338;
            if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 339;
                Print( "[NTP.setDateTime()][TIMESTAMP={0:d}]\r\n", (uint)TSTAMP) ; 
                }
            
            __context__.SourceCodeLine = 342;
            TSTAMP = (uint) ( (TSTAMP + (CALCGMTOFFSET( __context__ ) * 60)) ) ; 
            __context__.SourceCodeLine = 345;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.GetDst() == 1))  ) ) 
                {
                __context__.SourceCodeLine = 346;
                TSTAMP = (uint) ( (TSTAMP + 3600) ) ; 
                }
            
            __context__.SourceCodeLine = 350;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((TSTAMP >> 31) == 1))  ) ) 
                {
                __context__.SourceCodeLine = 351;
                TYEAR = (ushort) ( 1900 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 353;
                TYEAR = (ushort) ( 2036 ) ; 
                }
            
            __context__.SourceCodeLine = 355;
            TMON = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 356;
            TDAY = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 358;
            THOUR = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 359;
            TMIN = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 360;
            TSEC = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 364;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TSTAMP > (86400 * (365 + ISLEAPYEAR( __context__ , (ushort)( TYEAR ) ))) ))  ) ) 
                { 
                __context__.SourceCodeLine = 366;
                TSTAMP = (uint) ( (TSTAMP - (86400 * (365 + ISLEAPYEAR( __context__ , (ushort)( TYEAR ) )))) ) ; 
                __context__.SourceCodeLine = 367;
                TYEAR = (ushort) ( (TYEAR + 1) ) ; 
                __context__.SourceCodeLine = 364;
                } 
            
            __context__.SourceCodeLine = 371;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TSTAMP > (86400 * DAYSINMONTH( __context__ , (ushort)( TMON ) , (ushort)( TYEAR ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 373;
                TSTAMP = (uint) ( (TSTAMP - (86400 * DAYSINMONTH( __context__ , (ushort)( TMON ) , (ushort)( TYEAR ) ))) ) ; 
                __context__.SourceCodeLine = 374;
                TMON = (ushort) ( (TMON + 1) ) ; 
                __context__.SourceCodeLine = 371;
                } 
            
            __context__.SourceCodeLine = 378;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TSTAMP >= 86400 ))  ) ) 
                { 
                __context__.SourceCodeLine = 380;
                TSTAMP = (uint) ( (TSTAMP - 86400) ) ; 
                __context__.SourceCodeLine = 381;
                TDAY = (ushort) ( (TDAY + 1) ) ; 
                __context__.SourceCodeLine = 378;
                } 
            
            __context__.SourceCodeLine = 385;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TSTAMP >= 3600 ))  ) ) 
                { 
                __context__.SourceCodeLine = 387;
                TSTAMP = (uint) ( (TSTAMP - 3600) ) ; 
                __context__.SourceCodeLine = 388;
                THOUR = (ushort) ( (THOUR + 1) ) ; 
                __context__.SourceCodeLine = 385;
                } 
            
            __context__.SourceCodeLine = 392;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TSTAMP >= 60 ))  ) ) 
                { 
                __context__.SourceCodeLine = 394;
                TSTAMP = (uint) ( (TSTAMP - 60) ) ; 
                __context__.SourceCodeLine = 395;
                TMIN = (ushort) ( (TMIN + 1) ) ; 
                __context__.SourceCodeLine = 392;
                } 
            
            __context__.SourceCodeLine = 399;
            TSEC = (ushort) ( Functions.LowWord( (uint)( TSTAMP ) ) ) ; 
            __context__.SourceCodeLine = 401;
            if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 402;
                Print( "[NTP.setDateTime()][{0:d2}/{1:d2}/{2:d}][{3:d2}:{4:d2}:{5:d2}{6}](from: {7})\r\n", (short)TMON, (short)TDAY, (short)TYEAR, (short)THOUR, (short)TMIN, (short)TSEC, ROUND__DOLLAR__ , TEMPRXIP__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 404;
            if ( Functions.TestForTrue  ( ( LOGGING  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 405;
                GenerateUserNotice ( "[NTP] Setting date and time to {0:d2}/{1:d2}/{2:d2} - {3:d2}:{4:d2}:{5:d2}{6} (from: {7})\r\n", (short)TMON, (short)TDAY, (short)TYEAR, (short)THOUR, (short)TMIN, (short)TSEC, ROUND__DOLLAR__ , TEMPRXIP__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 409;
            Functions.SetClock (  (int) ( THOUR ) ,  (int) ( TMIN ) ,  (int) ( TSEC ) ) ; 
            __context__.SourceCodeLine = 410;
            Functions.SetDate (  (int) ( TMON ) ,  (int) ( TDAY ) ,  (int) ( TYEAR ) ) ; 
            
            }
            
        private ushort PROCESSDATA (  SplusExecutionContext __context__, CrestronString DATA__DOLLAR__ ) 
            { 
            ushort LEAP = 0;
            ushort VNUM = 0;
            ushort MODE = 0;
            
            CrestronString ORIGSTAMP__DOLLAR__;
            CrestronString TXSTAMP__DOLLAR__;
            ORIGSTAMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            TXSTAMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            
            __context__.SourceCodeLine = 425;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( DATA__DOLLAR__ ) < 48 ))  ) ) 
                { 
                __context__.SourceCodeLine = 427;
                if ( Functions.TestForTrue  ( ( LOGGING  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 428;
                    GenerateUserWarning ( "[NTP] NTP Packet smaller than expected (Size: {0:d} bytes)\r\n", (short)Functions.Length( DATA__DOLLAR__ )) ; 
                    }
                
                __context__.SourceCodeLine = 429;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 430;
                    Print( "[NTP.processData()] NTP Packet smaller than expected (Size: {0:d} bytes)\r\n", (short)Functions.Length( DATA__DOLLAR__ )) ; 
                    }
                
                __context__.SourceCodeLine = 432;
                return (ushort)( 0) ; 
                } 
            
            __context__.SourceCodeLine = 436;
            LEAP = (ushort) ( (Byte( DATA__DOLLAR__ , (int)( 1 ) ) & 192) ) ; 
            __context__.SourceCodeLine = 437;
            LEAP = (ushort) ( (LEAP >> 6) ) ; 
            __context__.SourceCodeLine = 439;
            VNUM = (ushort) ( (Byte( DATA__DOLLAR__ , (int)( 1 ) ) & 56) ) ; 
            __context__.SourceCodeLine = 440;
            VNUM = (ushort) ( (VNUM >> 3) ) ; 
            __context__.SourceCodeLine = 442;
            MODE = (ushort) ( (Byte( DATA__DOLLAR__ , (int)( 1 ) ) & 7) ) ; 
            __context__.SourceCodeLine = 445;
            ORIGSTAMP__DOLLAR__  .UpdateValue ( Functions.Mid ( DATA__DOLLAR__ ,  (int) ( 25 ) ,  (int) ( 8 ) )  ) ; 
            __context__.SourceCodeLine = 446;
            TXSTAMP__DOLLAR__  .UpdateValue ( Functions.Mid ( DATA__DOLLAR__ ,  (int) ( 41 ) ,  (int) ( 8 ) )  ) ; 
            __context__.SourceCodeLine = 452;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (LEAP != 3) ) && Functions.TestForTrue ( Functions.BoolToInt (MODE == 4) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (TEMPSTAMP__DOLLAR__ == ORIGSTAMP__DOLLAR__) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 454;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 455;
                    Print( "[NTP.processData()] Valid Data Received. [Mode: {0:d}][Vers: {1:d}][Leap: {2:d}][OrigStamp: {3}][TxStamp: {4}]\r\n", (short)MODE, (short)VNUM, (short)LEAP, PRINTSTAMP (  __context__ , ORIGSTAMP__DOLLAR__) , PRINTSTAMP (  __context__ , TEMPSTAMP__DOLLAR__) ) ; 
                    }
                
                __context__.SourceCodeLine = 458;
                SETDATETIME (  __context__ , TXSTAMP__DOLLAR__) ; 
                __context__.SourceCodeLine = 459;
                return (ushort)( 1) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 463;
                if ( Functions.TestForTrue  ( ( LOGGING  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 464;
                    GenerateUserWarning ( "[NTP] Invalid Data Received. [Mode: {0:d}][Vers: {1:d}][Leap: {2:d}][OrigStamp: {3}][TxStamp: {4}]\r\n", (short)MODE, (short)VNUM, (short)LEAP, PRINTSTAMP (  __context__ , ORIGSTAMP__DOLLAR__) , PRINTSTAMP (  __context__ , TEMPSTAMP__DOLLAR__) ) ; 
                    }
                
                __context__.SourceCodeLine = 466;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 467;
                    Print( "[NTP.processData()] Invalid Data Received. [Mode: {0:d}][Vers: {1:d}][Leap: {2:d}][OrigStamp: {3}][TxStamp: {4}]\r\n", (short)MODE, (short)VNUM, (short)LEAP, PRINTSTAMP (  __context__ , ORIGSTAMP__DOLLAR__) , PRINTSTAMP (  __context__ , TEMPSTAMP__DOLLAR__) ) ; 
                    }
                
                __context__.SourceCodeLine = 470;
                return (ushort)( 0) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort SENDQUERY (  SplusExecutionContext __context__, CrestronString IP_ADDRESS__DOLLAR__ ) 
            { 
            ushort TEMP = 0;
            
            ushort LEAP = 0;
            ushort MODE = 0;
            ushort VNUM = 0;
            
            CrestronString TXPACKET__DOLLAR__;
            TXPACKET__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 48, this );
            
            short STATUS = 0;
            
            
            __context__.SourceCodeLine = 485;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( IP_ADDRESS__DOLLAR__ ) <= 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 486;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 490;
            LEAP = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 491;
            VNUM = (ushort) ( 3 ) ; 
            __context__.SourceCodeLine = 492;
            MODE = (ushort) ( 3 ) ; 
            __context__.SourceCodeLine = 495;
            TEMP = (ushort) ( Functions.Low( (ushort) (((LEAP << 6) | (VNUM << 3)) | MODE) ) ) ; 
            __context__.SourceCodeLine = 496;
            SetString ( Functions.Chr (  (int) ( TEMP ) ) , (int)1, TXPACKET__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 501;
            MakeString ( TEMPSTAMP__DOLLAR__ , "{0}{1}", LONGTOSTR (  __context__ , (uint)( GETTIMEINSECS( __context__ ) )) , LONGTOSTR (  __context__ , (uint)( 0 )) ) ; 
            __context__.SourceCodeLine = 504;
            SetString ( TEMPSTAMP__DOLLAR__ , (int)41, TXPACKET__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 507;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 2 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)40; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( TEMP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (TEMP  >= __FN_FORSTART_VAL__1) && (TEMP  <= __FN_FOREND_VAL__1) ) : ( (TEMP  <= __FN_FORSTART_VAL__1) && (TEMP  >= __FN_FOREND_VAL__1) ) ; TEMP  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 508;
                SetByte ( TXPACKET__DOLLAR__ ,  (ushort) ( TEMP ) ,  (ushort) ( 0 ) ) ; 
                __context__.SourceCodeLine = 507;
                }
            
            __context__.SourceCodeLine = 511;
            STATUS = (short) ( Functions.SocketUDP_Enable( NTPSERVER , IP_ADDRESS__DOLLAR__ , (ushort)( 123 ) ) ) ; 
            __context__.SourceCodeLine = 513;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STATUS == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 516;
                Functions.SocketSend ( NTPSERVER , TXPACKET__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 518;
                return (ushort)( 1) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 522;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 523;
                    Print( "[NTP.sendQuery()] Unable to open UDP socket to {0} (Error: {1:d})\r\n", IP_ADDRESS__DOLLAR__ , (short)STATUS) ; 
                    }
                
                __context__.SourceCodeLine = 525;
                return (ushort)( 0) ; 
                } 
            
            
            return 0; // default return value (none specified in module)
            }
            
        object SYNCTIME_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 538;
                if ( Functions.TestForTrue  ( ( Functions.Not( BUSY  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 540;
                    BUSY  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 542;
                    CURRSERVER = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 546;
                    if ( Functions.TestForTrue  ( ( SENDQUERY( __context__ , SERVER_IP__DOLLAR__[ CURRSERVER ] ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 548;
                        CreateWait ( "SERVERWAIT" , 500 , SERVERWAIT_Callback ) ;
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 581;
                        if ( Functions.TestForTrue  ( ( LOGGING  .Value)  ) ) 
                            {
                            __context__.SourceCodeLine = 582;
                            GenerateUserWarning ( "[NTP] Could not open socket to NTP Server #{0:d}. (IP={1})\r\n", (short)CURRSERVER, SERVER_IP__DOLLAR__ [ CURRSERVER ] ) ; 
                            }
                        
                        __context__.SourceCodeLine = 583;
                        if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                            {
                            __context__.SourceCodeLine = 584;
                            Print( "[NTP.UpdateTime] Could not open socket to NTP Server #{0:d}. (IP={1})\r\n", (short)CURRSERVER, SERVER_IP__DOLLAR__ [ CURRSERVER ] ) ; 
                            }
                        
                        __context__.SourceCodeLine = 587;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( CURRSERVER >= 4 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 590;
                            GenerateUserError ( "[NTP] Could not reach any NTP servers. Attempted {0:d} servers.\r\n", (short)CURRSERVER) ; 
                            __context__.SourceCodeLine = 592;
                            if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                                {
                                __context__.SourceCodeLine = 593;
                                Print( "[NTP.UpdateTime] Could not reach any NTP servers. Attempted {0:d} servers.\r\n", (short)CURRSERVER) ; 
                                }
                            
                            } 
                        
                        __context__.SourceCodeLine = 596;
                        SYNCFAILED [ CURRSERVER]  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 597;
                        Functions.ProcessLogic ( ) ; 
                        __context__.SourceCodeLine = 598;
                        SYNCFAILED [ CURRSERVER]  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 600;
                        CURRSERVER = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 601;
                        BUSY  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void SERVERWAIT_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 551;
            Functions.ClearBuffer ( NTPSERVER .  SocketRxBuf ) ; 
            __context__.SourceCodeLine = 552;
            Functions.SocketUDP_Disable ( NTPSERVER ) ; 
            __context__.SourceCodeLine = 554;
            if ( Functions.TestForTrue  ( ( LOGGING  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 555;
                GenerateUserWarning ( "[NTP] NTP server #{0:d} (Address: {1}) timed out after {2:d} seconds.\r\n", (short)CURRSERVER, SERVER_IP__DOLLAR__ [ CURRSERVER ] , (short)(500 / 100)) ; 
                }
            
            __context__.SourceCodeLine = 557;
            if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 558;
                Print( "[NTP.UpdateTime] NTP server #{0:d} (Address: {1}) timed out after {2:d} seconds.\r\n", (short)CURRSERVER, SERVER_IP__DOLLAR__ [ CURRSERVER ] , (short)(500 / 100)) ; 
                }
            
            __context__.SourceCodeLine = 562;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( CURRSERVER >= 4 ))  ) ) 
                { 
                __context__.SourceCodeLine = 565;
                GenerateUserError ( "[NTP] Could not reach any NTP servers. Attempted {0:d} servers.\r\n", (short)CURRSERVER) ; 
                __context__.SourceCodeLine = 567;
                if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 568;
                    Print( "[NTP.UpdateTime] Could not reach any NTP servers. Attempted {0:d} servers.\r\n", (short)CURRSERVER) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 571;
            SYNCFAILED [ CURRSERVER]  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 572;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 573;
            SYNCFAILED [ CURRSERVER]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 575;
            CURRSERVER = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 576;
            BUSY  .Value = (ushort) ( 0 ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
object NTPSERVER_OnSocketReceive_1 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 609;
        Functions.SocketGetSenderIPAddress ( NTPSERVER ,  ref TEMPRXIP__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 612;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( NTPSERVER.SocketRxBuf ) >= 48 ))  ) ) 
            { 
            __context__.SourceCodeLine = 614;
            if ( Functions.TestForTrue  ( ( PROCESSDATA( __context__ , Functions.Left( NTPSERVER.SocketRxBuf , (int)( 48 ) ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 616;
                CancelWait ( "SERVERWAIT" ) ; 
                __context__.SourceCodeLine = 618;
                Functions.ClearBuffer ( NTPSERVER .  SocketRxBuf ) ; 
                __context__.SourceCodeLine = 619;
                Functions.SocketUDP_Disable ( NTPSERVER ) ; 
                __context__.SourceCodeLine = 621;
                SYNCSUCCESSFUL [ CURRSERVER]  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 622;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 623;
                SYNCSUCCESSFUL [ CURRSERVER]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 625;
                CURRSERVER = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 626;
                BUSY  .Value = (ushort) ( 0 ) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 630;
        if ( Functions.TestForTrue  ( ( DEBUG  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 631;
            Print( "[NTP.SOCKETRECEIVE] Received data from: {0}\r\n", TEMPRXIP__DOLLAR__ ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 644;
        CURRSERVER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 646;
        Functions.ClearBuffer ( TEMPRXIP__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 647;
        Functions.ClearBuffer ( TEMPSTAMP__DOLLAR__ ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    TEMPRXIP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    TEMPSTAMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    NTPSERVER  = new SplusUdpSocket ( 256, this );
    
    DEBUG = new Crestron.Logos.SplusObjects.DigitalInput( DEBUG__DigitalInput__, this );
    m_DigitalInputList.Add( DEBUG__DigitalInput__, DEBUG );
    
    LOGGING = new Crestron.Logos.SplusObjects.DigitalInput( LOGGING__DigitalInput__, this );
    m_DigitalInputList.Add( LOGGING__DigitalInput__, LOGGING );
    
    SYNCTIME = new InOutArray<DigitalInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        SYNCTIME[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SYNCTIME__DigitalInput__ + i, SYNCTIME__DigitalInput__, this );
        m_DigitalInputList.Add( SYNCTIME__DigitalInput__ + i, SYNCTIME[i+1] );
    }
    
    BUSY = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY__DigitalOutput__, BUSY );
    
    SYNCSUCCESSFUL = new InOutArray<DigitalOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        SYNCSUCCESSFUL[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SYNCSUCCESSFUL__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SYNCSUCCESSFUL__DigitalOutput__ + i, SYNCSUCCESSFUL[i+1] );
    }
    
    SYNCFAILED = new InOutArray<DigitalOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        SYNCFAILED[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SYNCFAILED__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SYNCFAILED__DigitalOutput__ + i, SYNCFAILED[i+1] );
    }
    
    GMT_OFFSET_MINUTES = new Crestron.Logos.SplusObjects.AnalogInput( GMT_OFFSET_MINUTES__AnalogSerialInput__, this );
    m_AnalogInputList.Add( GMT_OFFSET_MINUTES__AnalogSerialInput__, GMT_OFFSET_MINUTES );
    
    SERVER_IP__DOLLAR__ = new InOutArray<StringInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        SERVER_IP__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( SERVER_IP__DOLLAR____AnalogSerialInput__ + i, SERVER_IP__DOLLAR____AnalogSerialInput__, 64, this );
        m_StringInputList.Add( SERVER_IP__DOLLAR____AnalogSerialInput__ + i, SERVER_IP__DOLLAR__[i+1] );
    }
    
    SERVERWAIT_Callback = new WaitFunction( SERVERWAIT_CallbackFn );
    
    for( uint i = 0; i < 4; i++ )
        SYNCTIME[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SYNCTIME_OnPush_0, false ) );
        
    NTPSERVER.OnSocketReceive.Add( new SocketHandlerWrapper( NTPSERVER_OnSocketReceive_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_NTP_TIME_SYNC_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction SERVERWAIT_Callback;


const uint DEBUG__DigitalInput__ = 0;
const uint LOGGING__DigitalInput__ = 1;
const uint SYNCTIME__DigitalInput__ = 2;
const uint GMT_OFFSET_MINUTES__AnalogSerialInput__ = 0;
const uint SERVER_IP__DOLLAR____AnalogSerialInput__ = 1;
const uint BUSY__DigitalOutput__ = 0;
const uint SYNCSUCCESSFUL__DigitalOutput__ = 1;
const uint SYNCFAILED__DigitalOutput__ = 5;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
