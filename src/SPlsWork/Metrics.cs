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

namespace UserModule_METRICS
{
    public class UserModuleClass_METRICS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput STARTUP_PRESS;
        Crestron.Logos.SplusObjects.DigitalInput CONFIRM_SYSTEM_OFF;
        Crestron.Logos.SplusObjects.DigitalInput PROGRAM_VOLUME_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput PROGRAM_VOLUME_UP;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_AV_JACK;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_BLANK;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_BLURAY;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_DEVICE_CONTROL_BLURAY;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_DEVICE_CONTROL_IPTV;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_HDMI_CABLE;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_HDMI_JACK;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_IPTV;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_LOCAL_INPUT;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_PA_CONTROL;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_REMOTE_INPUT1;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_REMOTE_INPUT2;
        Crestron.Logos.SplusObjects.DigitalInput SELECT_VGA_CABLE;
        Crestron.Logos.SplusObjects.DigitalInput HELP_MENU_PRESS;
        Crestron.Logos.SplusObjects.DigitalInput HOME_BUTTON;
        Crestron.Logos.SplusObjects.DigitalInput PROGRAM_VOLUME_SLIDER_PRESS;
        Crestron.Logos.SplusObjects.DigitalInput AUDIO_ONLY_PRESS;
        Crestron.Logos.SplusObjects.DigitalInput CLIENTCONNECTED;
        Crestron.Logos.SplusObjects.DigitalInput SYSTEMREADY;
        Crestron.Logos.SplusObjects.StringInput CPHOSTNAME;
        Crestron.Logos.SplusObjects.StringInput CPIP;
        Crestron.Logos.SplusObjects.StringInput CPMACADDR;
        Crestron.Logos.SplusObjects.StringInput DEVBUILDING;
        Crestron.Logos.SplusObjects.StringInput DEVROOM;
        Crestron.Logos.SplusObjects.StringInput DEVFLOOR;
        Crestron.Logos.SplusObjects.StringInput DEVLATITUDE;
        Crestron.Logos.SplusObjects.StringInput DEVLONGITUDE;
        Crestron.Logos.SplusObjects.StringInput VOLUMELEVEL;
        Crestron.Logos.SplusObjects.StringInput SESSIONID;
        Crestron.Logos.SplusObjects.StringInput INPUTLABEL1;
        Crestron.Logos.SplusObjects.StringInput INPUTLABEL2;
        Crestron.Logos.SplusObjects.StringInput INPUTLABEL3;
        Crestron.Logos.SplusObjects.StringInput INPUTLABEL4;
        Crestron.Logos.SplusObjects.StringInput INPUTLABEL5;
        Crestron.Logos.SplusObjects.StringInput INPUTLABEL6;
        Crestron.Logos.SplusObjects.StringInput INPUTLABEL7;
        Crestron.Logos.SplusObjects.BufferInput CLIENTBUFFER;
        Crestron.Logos.SplusObjects.DigitalOutput _CLIENTCONNECTED;
        Crestron.Logos.SplusObjects.StringOutput TODEVBUILDING;
        Crestron.Logos.SplusObjects.StringOutput TODEVROOM;
        Crestron.Logos.SplusObjects.StringOutput TODEVFLOOR;
        Crestron.Logos.SplusObjects.StringOutput TODEVLAT;
        Crestron.Logos.SplusObjects.StringOutput TODEVLON;
        Crestron.Logos.SplusObjects.StringOutput TOCLIENTBUFFER__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput STORESESSIONID;
        SplusTcpClient CLIENT;
        short CONFIGFILEHANDLE = 0;
        CrestronString REPORTINGHOST;
        CrestronString HOSTNAME;
        CrestronString HOSTIP;
        CrestronString HOSTMAC;
        CrestronString HOSTBLDG;
        CrestronString HOSTROOM;
        CrestronString HOSTFLOOR;
        CrestronString HOSTLAT;
        CrestronString HOSTLON;
        CrestronString SESSION;
        CrestronString INPUT1;
        CrestronString INPUT2;
        CrestronString INPUT3;
        CrestronString INPUT4;
        CrestronString INPUT5;
        CrestronString INPUT6;
        CrestronString INPUT7;
        CrestronString MESSAGE;
        ushort REPORTINGHOSTPORT = 0;
        ushort RECONNECTTIME = 0;
        private CrestronString SANITIZE (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            CrestronString STRIPPEDMESSAGE;
            CrestronString CHAR;
            STRIPPEDMESSAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            CHAR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 89;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( MSG ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 91;
                CHAR  .UpdateValue ( Functions.Mid ( MSG ,  (int) ( I ) ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 93;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (CHAR != "_") ) && Functions.TestForTrue ( Functions.BoolToInt (CHAR != "/") )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 95;
                    STRIPPEDMESSAGE  .UpdateValue ( STRIPPEDMESSAGE + CHAR  ) ; 
                    } 
                
                __context__.SourceCodeLine = 89;
                } 
            
            __context__.SourceCodeLine = 99;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( STRIPPEDMESSAGE , (int)( 1 ) , (int)( 1 ) ) == " "))  ) ) 
                { 
                __context__.SourceCodeLine = 101;
                STRIPPEDMESSAGE  .UpdateValue ( Functions.Right ( STRIPPEDMESSAGE ,  (int) ( (Functions.Length( STRIPPEDMESSAGE ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 99;
                } 
            
            __context__.SourceCodeLine = 104;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( STRIPPEDMESSAGE , (int)( Functions.Length( STRIPPEDMESSAGE ) ) , (int)( 1 ) ) == " "))  ) ) 
                { 
                __context__.SourceCodeLine = 106;
                STRIPPEDMESSAGE  .UpdateValue ( Functions.Left ( STRIPPEDMESSAGE ,  (int) ( (Functions.Length( STRIPPEDMESSAGE ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 104;
                } 
            
            __context__.SourceCodeLine = 109;
            return ( STRIPPEDMESSAGE ) ; 
            
            }
            
        private void LOG (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 114;
            Print( "\r\n{0}", MSG ) ; 
            
            }
            
        private void ERROR (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 119;
            LOG (  __context__ , MSG) ; 
            
            }
            
        private void SEND (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 125;
            Functions.SocketSend ( CLIENT , MSG ) ; 
            
            }
            
        private void STOREGLOBALVARS (  SplusExecutionContext __context__, CrestronString INPUTSTRING ) 
            { 
            CrestronString TRASH;
            CrestronString PARSETHISSTRING;
            CrestronString TEMP;
            TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            PARSETHISSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            
            __context__.SourceCodeLine = 133;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "building" , INPUTSTRING ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "roomNumber" , INPUTSTRING ) > 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "floor" , INPUTSTRING ) > 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "building" , INPUTSTRING ) > 0 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 135;
                TRASH  .UpdateValue ( Functions.Remove ( ":[" , INPUTSTRING )  ) ; 
                __context__.SourceCodeLine = 136;
                PARSETHISSTRING  .UpdateValue ( INPUTSTRING  ) ; 
                __context__.SourceCodeLine = 139;
                HOSTLON  .UpdateValue ( Functions.Remove ( "," , PARSETHISSTRING )  ) ; 
                __context__.SourceCodeLine = 142;
                HOSTLAT  .UpdateValue ( Functions.Remove ( "]," , PARSETHISSTRING )  ) ; 
                __context__.SourceCodeLine = 145;
                TRASH  .UpdateValue ( Functions.Remove ( ":\"" , PARSETHISSTRING )  ) ; 
                __context__.SourceCodeLine = 146;
                HOSTROOM  .UpdateValue ( Functions.Remove ( "\"" , PARSETHISSTRING )  ) ; 
                __context__.SourceCodeLine = 149;
                TRASH  .UpdateValue ( Functions.Remove ( ":\"" , PARSETHISSTRING )  ) ; 
                __context__.SourceCodeLine = 150;
                HOSTFLOOR  .UpdateValue ( Functions.Remove ( "," , PARSETHISSTRING )  ) ; 
                __context__.SourceCodeLine = 154;
                TRASH  .UpdateValue ( Functions.Remove ( ":\"" , PARSETHISSTRING )  ) ; 
                __context__.SourceCodeLine = 155;
                TEMP  .UpdateValue ( PARSETHISSTRING  ) ; 
                __context__.SourceCodeLine = 156;
                HOSTBLDG  .UpdateValue ( Functions.Remove ( "\"" , TEMP )  ) ; 
                } 
            
            
            }
            
        private void BUILDHTTPMESSAGE (  SplusExecutionContext __context__, CrestronString EVENTACTOR , CrestronString EVENTACTION , CrestronString USERORSYSTEM , CrestronString SESSN ) 
            { 
            short DST = 0;
            short MNUM = 0;
            short YNUM = 0;
            short DNUM = 0;
            short CONTENTLENGTH = 0;
            
            int PORTNUMBER = 0;
            
            CrestronString TIMESTAMP;
            TIMESTAMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
            
            CrestronString DATESTR;
            DATESTR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
            
            CrestronString TIMESTR;
            TIMESTR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
            
            CrestronString DESCRIPTION;
            DESCRIPTION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            CrestronString IPADDRESS;
            IPADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
            
            CrestronString MAC;
            MAC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 17, this );
            
            CrestronString BUILDING;
            BUILDING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            CrestronString ROOMNUMBER;
            ROOMNUMBER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            CrestronString LAT;
            LAT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 11, this );
            
            CrestronString LON;
            LON  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 11, this );
            
            CrestronString FLR;
            FLR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            CrestronString ACTOR;
            ACTOR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
            
            CrestronString DESC;
            DESC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            CrestronString TYPE;
            TYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
            
            CrestronString HEADER1;
            CrestronString HEADER2;
            CrestronString HEADER3;
            CrestronString HEADER4;
            CrestronString HEADER5;
            CrestronString HEADER6;
            HEADER1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER5  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER6  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            CrestronString INNERMSG1;
            CrestronString INNERMSG2;
            CrestronString INNERMSG3;
            CrestronString INNERMSG4;
            INNERMSG1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            INNERMSG2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            INNERMSG3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            INNERMSG4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            CrestronString CLSTRING;
            CLSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            ushort SPACEPOSITION = 0;
            
            
            __context__.SourceCodeLine = 183;
            HOSTNAME  .UpdateValue ( HOSTNAME  ) ; 
            __context__.SourceCodeLine = 184;
            DESCRIPTION  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 185;
            IPADDRESS  .UpdateValue ( HOSTIP  ) ; 
            __context__.SourceCodeLine = 186;
            MAC  .UpdateValue ( HOSTMAC  ) ; 
            __context__.SourceCodeLine = 187;
            BUILDING  .UpdateValue ( HOSTBLDG  ) ; 
            __context__.SourceCodeLine = 188;
            ROOMNUMBER  .UpdateValue ( HOSTROOM  ) ; 
            __context__.SourceCodeLine = 189;
            LAT  .UpdateValue ( HOSTLAT  ) ; 
            __context__.SourceCodeLine = 190;
            LON  .UpdateValue ( HOSTLON  ) ; 
            __context__.SourceCodeLine = 191;
            FLR  .UpdateValue ( HOSTFLOOR  ) ; 
            __context__.SourceCodeLine = 192;
            ACTOR  .UpdateValue ( EVENTACTOR  ) ; 
            __context__.SourceCodeLine = 193;
            DESC  .UpdateValue ( EVENTACTION  ) ; 
            __context__.SourceCodeLine = 194;
            TYPE  .UpdateValue ( USERORSYSTEM  ) ; 
            __context__.SourceCodeLine = 196;
            SPACEPOSITION = (ushort) ( Functions.Find( " " , HOSTNAME ) ) ; 
            __context__.SourceCodeLine = 197;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SPACEPOSITION == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 198;
                HOSTNAME  .UpdateValue ( Functions.Right ( HOSTNAME ,  (int) ( (Functions.Length( HOSTNAME ) - 1) ) )  ) ; 
                } 
            
            __context__.SourceCodeLine = 201;
            MNUM = (short) ( Functions.GetMonthNum() ) ; 
            __context__.SourceCodeLine = 202;
            YNUM = (short) ( Functions.GetYearNum() ) ; 
            __context__.SourceCodeLine = 203;
            DNUM = (short) ( Functions.GetDateNum() ) ; 
            __context__.SourceCodeLine = 205;
            DATESTR  .UpdateValue ( Functions.ItoA (  (int) ( YNUM ) ) + "-" + Functions.ItoA (  (int) ( MNUM ) ) + "-" + Functions.ItoA (  (int) ( DNUM ) )  ) ; 
            __context__.SourceCodeLine = 206;
            TIMESTR  .UpdateValue ( Functions.Time ( )  ) ; 
            __context__.SourceCodeLine = 207;
            DST = (short) ( Functions.GetDst() ) ; 
            __context__.SourceCodeLine = 210;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DST == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 211;
                TIMESTAMP  .UpdateValue ( DATESTR + "T" + TIMESTR + "-0600"  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 212;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DST == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 213;
                    TIMESTAMP  .UpdateValue ( DATESTR + "T" + TIMESTR + "-0700"  ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 216;
            INNERMSG1  .UpdateValue ( "{\"type\": \"" + TYPE + "\",\"timestamp\": \"" + TIMESTAMP + "\",\"eventTime\": \"" + TIMESTR + "\",\"eventDate\": \"" + DATESTR + "\",\"device\": {\"hostname\": \"" + HOSTNAME + "\", \"description\": \""  ) ; 
            __context__.SourceCodeLine = 217;
            INNERMSG2  .UpdateValue ( "" + DESCRIPTION + "\", \"ipAddress\": \"" + IPADDRESS + "\", \"macAddress\": \"" + MAC + "\"}, \"room\": { \"building\": \"" + BUILDING  ) ; 
            __context__.SourceCodeLine = 218;
            INNERMSG3  .UpdateValue ( "\", \"roomNumber\": \"" + ROOMNUMBER + "\",\"coordinates\": \"" + LAT + "," + LON + "\", \"floor\": \"" + FLR + "\""  ) ; 
            __context__.SourceCodeLine = 219;
            INNERMSG4  .UpdateValue ( "},\"action\": {\"actor\": \"" + ACTOR + "\", \"description\": \"" + DESC + "\"}, \"session\": \"" + SESSION + "\"}"  ) ; 
            __context__.SourceCodeLine = 220;
            CONTENTLENGTH = (short) ( (((Functions.Length( INNERMSG1 ) + Functions.Length( INNERMSG2 )) + Functions.Length( INNERMSG3 )) + Functions.Length( INNERMSG4 )) ) ; 
            __context__.SourceCodeLine = 221;
            CLSTRING  .UpdateValue ( Functions.ItoA (  (int) ( CONTENTLENGTH ) )  ) ; 
            __context__.SourceCodeLine = 223;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EVENTACTION == "System active"))  ) ) 
                { 
                __context__.SourceCodeLine = 224;
                HEADER1  .UpdateValue ( "POST /events/" + USERORSYSTEM + "/" + HOSTNAME + "_SystemActive HTTP/1.1" + "\r\n"  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 227;
                HEADER1  .UpdateValue ( "POST /events/" + USERORSYSTEM + "/ HTTP/1.1" + "\r\n"  ) ; 
                } 
            
            __context__.SourceCodeLine = 229;
            HEADER2  .UpdateValue ( "Host: " + "awsElasticSearchUrl" + ":" + Functions.ItoA (  (int) ( REPORTINGHOSTPORT ) ) + "\r\n"  ) ; 
            __context__.SourceCodeLine = 230;
            HEADER3  .UpdateValue ( "Connection: keep-alive" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 231;
            HEADER4  .UpdateValue ( "Content-Length: " + CLSTRING + "\r\n"  ) ; 
            __context__.SourceCodeLine = 232;
            HEADER5  .UpdateValue ( "Content-type: text/plain;charset=UTF-8" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 233;
            HEADER6  .UpdateValue ( "Accept: */*" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 234;
            Print( "{0}", HEADER1 ) ; 
            __context__.SourceCodeLine = 235;
            Print( "{0}", HEADER1 ) ; 
            __context__.SourceCodeLine = 236;
            Print( "{0}", HEADER2 ) ; 
            __context__.SourceCodeLine = 237;
            Print( "{0}", HEADER3 ) ; 
            __context__.SourceCodeLine = 238;
            Print( "{0}", HEADER4 ) ; 
            __context__.SourceCodeLine = 239;
            Print( "{0}", HEADER5 ) ; 
            __context__.SourceCodeLine = 240;
            Print( "{0}", HEADER6 ) ; 
            __context__.SourceCodeLine = 241;
            Print( "{0}", "\r\n" ) ; 
            __context__.SourceCodeLine = 242;
            Print( "{0}", INNERMSG1 ) ; 
            __context__.SourceCodeLine = 243;
            Print( "{0}", INNERMSG2 ) ; 
            __context__.SourceCodeLine = 244;
            Print( "{0}", INNERMSG3 ) ; 
            __context__.SourceCodeLine = 245;
            Print( "{0}", INNERMSG4 ) ; 
            __context__.SourceCodeLine = 247;
            SEND (  __context__ , HEADER1) ; 
            __context__.SourceCodeLine = 248;
            SEND (  __context__ , HEADER2) ; 
            __context__.SourceCodeLine = 249;
            SEND (  __context__ , HEADER3) ; 
            __context__.SourceCodeLine = 250;
            SEND (  __context__ , HEADER4) ; 
            __context__.SourceCodeLine = 251;
            SEND (  __context__ , HEADER5) ; 
            __context__.SourceCodeLine = 252;
            SEND (  __context__ , HEADER6) ; 
            __context__.SourceCodeLine = 253;
            SEND (  __context__ , "\r\n") ; 
            __context__.SourceCodeLine = 254;
            SEND (  __context__ , INNERMSG1) ; 
            __context__.SourceCodeLine = 255;
            SEND (  __context__ , INNERMSG2) ; 
            __context__.SourceCodeLine = 256;
            SEND (  __context__ , INNERMSG3) ; 
            __context__.SourceCodeLine = 257;
            SEND (  __context__ , INNERMSG4) ; 
            
            }
            
        private void STARTSESSION (  SplusExecutionContext __context__ ) 
            { 
            short MNUM = 0;
            short YNUM = 0;
            short DNUM = 0;
            
            ushort TICKS = 0;
            ushort CH = 0;
            ushort COUNTER = 0;
            ushort PERIOD = 0;
            
            CrestronString GENSESSION;
            CrestronString MSG;
            CrestronString TMPMAC;
            CrestronString LEFTOVER;
            CrestronString TMP;
            GENSESSION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            TMPMAC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
            LEFTOVER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
            TMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
            
            
            __context__.SourceCodeLine = 266;
            TMP  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 267;
            LEFTOVER  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 268;
            TICKS = (ushort) ( Functions.GetTicks() ) ; 
            __context__.SourceCodeLine = 270;
            GENSESSION  .UpdateValue ( Functions.ItoA (  (int) ( TICKS ) )  ) ; 
            __context__.SourceCodeLine = 271;
            TMPMAC  .UpdateValue ( HOSTMAC  ) ; 
            __context__.SourceCodeLine = 272;
            MNUM = (short) ( Functions.GetMonthNum() ) ; 
            __context__.SourceCodeLine = 273;
            YNUM = (short) ( Functions.GetYearNum() ) ; 
            __context__.SourceCodeLine = 274;
            DNUM = (short) ( Functions.GetDateNum() ) ; 
            __context__.SourceCodeLine = 276;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TMPMAC ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( "." , TMPMAC ) > 0 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 278;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 279;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 280;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 281;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 282;
                PERIOD = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 284;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 285;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 286;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 287;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 288;
                PERIOD = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 290;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 291;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 292;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 293;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 294;
                PERIOD = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 296;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 297;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 298;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 299;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 300;
                PERIOD = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 302;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 303;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 304;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 305;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 306;
                PERIOD = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 308;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 309;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                __context__.SourceCodeLine = 310;
                CH = (ushort) ( Functions.GetC( TMPMAC ) ) ; 
                __context__.SourceCodeLine = 311;
                LEFTOVER  .UpdateValue ( LEFTOVER + Functions.Chr (  (int) ( CH ) )  ) ; 
                } 
            
            __context__.SourceCodeLine = 313;
            TMPMAC  .UpdateValue ( LEFTOVER  ) ; 
            __context__.SourceCodeLine = 314;
            HOSTMAC  .UpdateValue ( TMPMAC  ) ; 
            __context__.SourceCodeLine = 315;
            STORESESSIONID  .UpdateValue ( TMPMAC + "-" + GENSESSION + "-" + Functions.ItoA (  (int) ( YNUM ) ) + Functions.ItoA (  (int) ( MNUM ) ) + Functions.ItoA (  (int) ( DNUM ) )  ) ; 
            __context__.SourceCodeLine = 316;
            MSG  .UpdateValue ( "Session START: " + GENSESSION  ) ; 
            __context__.SourceCodeLine = 318;
            BUILDHTTPMESSAGE (  __context__ , "session", MSG, "user", SESSION) ; 
            
            }
            
        private void ENDSESSION (  SplusExecutionContext __context__ ) 
            { 
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            
            __context__.SourceCodeLine = 325;
            MSG  .UpdateValue ( "Session STOP: " + SESSION  ) ; 
            __context__.SourceCodeLine = 327;
            STORESESSIONID  .UpdateValue ( " "  ) ; 
            __context__.SourceCodeLine = 330;
            BUILDHTTPMESSAGE (  __context__ , "session", MSG, "user", SESSION) ; 
            
            }
            
        private void GETCONFIGURATIONVALUE (  SplusExecutionContext __context__, CrestronString FIELD ) 
            { 
            short OFFSET = 0;
            short MNUM = 0;
            short YNUM = 0;
            short DNUM = 0;
            short CONTENTLENGTH = 0;
            
            int PORTNUMBER = 0;
            
            CrestronString HEADER1;
            CrestronString HEADER2;
            CrestronString HEADER3;
            CrestronString HEADER4;
            CrestronString HEADER5;
            CrestronString HEADER6;
            HEADER1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER5  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            HEADER6  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            CrestronString CLSTRING;
            CLSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            
            
            __context__.SourceCodeLine = 340;
            CONTENTLENGTH = (short) ( 0 ) ; 
            __context__.SourceCodeLine = 341;
            CLSTRING  .UpdateValue ( Functions.ItoA (  (int) ( CONTENTLENGTH ) )  ) ; 
            __context__.SourceCodeLine = 343;
            HEADER1  .UpdateValue ( "GET /configuration/device/" + HOSTNAME + "?_source_include=" + FIELD + " HTTP/1.1" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 344;
            HEADER2  .UpdateValue ( "Host: " + "awsElasticSearchUrl" + ":" + Functions.ItoA (  (int) ( REPORTINGHOSTPORT ) ) + "\r\n"  ) ; 
            __context__.SourceCodeLine = 345;
            HEADER3  .UpdateValue ( "Connection: keep-alive" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 346;
            HEADER4  .UpdateValue ( "Content-Length: " + CLSTRING + "\r\n"  ) ; 
            __context__.SourceCodeLine = 347;
            HEADER5  .UpdateValue ( "Content-type: text/plain;charset=UTF-8" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 348;
            HEADER6  .UpdateValue ( "Accept: */*" + "\r\n"  ) ; 
            __context__.SourceCodeLine = 350;
            SEND (  __context__ , HEADER1) ; 
            __context__.SourceCodeLine = 351;
            SEND (  __context__ , HEADER2) ; 
            __context__.SourceCodeLine = 352;
            SEND (  __context__ , HEADER3) ; 
            __context__.SourceCodeLine = 353;
            SEND (  __context__ , HEADER4) ; 
            __context__.SourceCodeLine = 354;
            SEND (  __context__ , HEADER5) ; 
            __context__.SourceCodeLine = 355;
            SEND (  __context__ , HEADER6) ; 
            __context__.SourceCodeLine = 356;
            SEND (  __context__ , "\r\n") ; 
            
            }
            
        object STARTUP_PRESS_OnRelease_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 376;
                STARTSESSION (  __context__  ) ; 
                __context__.SourceCodeLine = 379;
                BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Startup", "user", SESSION) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CONFIRM_SYSTEM_OFF_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 386;
            BUILDHTTPMESSAGE (  __context__ , "touchpanel", "System Off", "user", SESSION) ; 
            __context__.SourceCodeLine = 390;
            ENDSESSION (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object PROGRAM_VOLUME_DOWN_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 396;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Volume Down", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PROGRAM_VOLUME_UP_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 403;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Volume Up", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_BLANK_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 410;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Blank", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_DEVICE_CONTROL_IPTV_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 417;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Device Control - IPTV", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_HDMI_CABLE_OnRelease_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 424;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "HDMI Cable", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_HDMI_JACK_OnRelease_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 431;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "HDMI Jack", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_IPTV_OnRelease_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 438;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "IPTV", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_LOCAL_INPUT_OnRelease_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 445;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Local Input", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_REMOTE_INPUT1_OnRelease_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 452;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", INPUT6, "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_REMOTE_INPUT2_OnRelease_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 458;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", INPUT7, "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_VGA_CABLE_OnRelease_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 464;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "VGA Cable", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HELP_MENU_PRESS_OnRelease_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 471;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Help Menu", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOME_BUTTON_OnRelease_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 478;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Home Button", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_AV_JACK_OnRelease_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 485;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "AV Jack", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_BLURAY_OnRelease_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 492;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Blu-ray", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_DEVICE_CONTROL_BLURAY_OnRelease_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 499;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Device Control - Blu-ray", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SELECT_PA_CONTROL_OnRelease_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 506;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "PA Control", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PROGRAM_VOLUME_SLIDER_PRESS_OnRelease_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 513;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Volume Slider", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUDIO_ONLY_PRESS_OnRelease_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 520;
        STARTSESSION (  __context__  ) ; 
        __context__.SourceCodeLine = 524;
        BUILDHTTPMESSAGE (  __context__ , "touchpanel", "Audio Only", "user", SESSION) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CPHOSTNAME_OnChange_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMP;
        CrestronString BLDG;
        CrestronString ROOM;
        CrestronString FLR;
        TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        BLDG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        ROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        FLR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
        
        ushort C = 0;
        
        
        __context__.SourceCodeLine = 540;
        BLDG  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 541;
        ROOM  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 542;
        FLR  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 544;
        HOSTNAME  .UpdateValue ( CPHOSTNAME  ) ; 
        __context__.SourceCodeLine = 545;
        TEMP  .UpdateValue ( CPHOSTNAME  ) ; 
        __context__.SourceCodeLine = 547;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( " " , CPHOSTNAME ) >= 1 ))  ) ) 
            { 
            __context__.SourceCodeLine = 550;
            BLDG  .UpdateValue ( Functions.Remove ( " " , TEMP )  ) ; 
            __context__.SourceCodeLine = 551;
            ROOM  .UpdateValue ( Functions.Remove ( " " , TEMP )  ) ; 
            __context__.SourceCodeLine = 552;
            C = (ushort) ( Functions.GetC( ROOM ) ) ; 
            __context__.SourceCodeLine = 553;
            FLR  .UpdateValue ( Functions.ItoA (  (int) ( C ) )  ) ; 
            } 
        
        __context__.SourceCodeLine = 556;
        HOSTBLDG  .UpdateValue ( BLDG  ) ; 
        __context__.SourceCodeLine = 557;
        HOSTROOM  .UpdateValue ( ROOM  ) ; 
        __context__.SourceCodeLine = 558;
        HOSTFLOOR  .UpdateValue ( FLR  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CPIP_OnChange_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TRASH;
        TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
        
        
        __context__.SourceCodeLine = 565;
        TRASH  .UpdateValue ( Functions.Remove ( " " , CPIP )  ) ; 
        __context__.SourceCodeLine = 566;
        HOSTIP  .UpdateValue ( CPIP  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CPMACADDR_OnChange_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TRASH;
        CrestronString TEMP;
        TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        
        __context__.SourceCodeLine = 573;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( " " , CPMACADDR ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 575;
            TEMP  .UpdateValue ( Functions.Left ( CPMACADDR ,  (int) ( (Functions.Length( CPMACADDR ) - 1) ) )  ) ; 
            __context__.SourceCodeLine = 576;
            HOSTMAC  .UpdateValue ( TEMP  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 580;
            HOSTMAC  .UpdateValue ( CPMACADDR  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SESSIONID_OnChange_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 586;
        SESSION  .UpdateValue ( SESSIONID  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTLABEL1_OnChange_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 591;
        INPUT1  .UpdateValue ( INPUTLABEL1  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTLABEL2_OnChange_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 596;
        INPUT2  .UpdateValue ( INPUTLABEL2  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTLABEL3_OnChange_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 601;
        INPUT3  .UpdateValue ( INPUTLABEL3  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTLABEL4_OnChange_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 606;
        INPUT4  .UpdateValue ( INPUTLABEL4  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTLABEL5_OnChange_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 611;
        INPUT5  .UpdateValue ( INPUTLABEL5  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTLABEL6_OnChange_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 616;
        INPUT6  .UpdateValue ( INPUTLABEL6  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTLABEL7_OnChange_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 621;
        INPUT7  .UpdateValue ( INPUTLABEL7  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLIENTCONNECTED_OnPush_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short STATUS = 0;
        
        
        __context__.SourceCodeLine = 628;
        STATUS = (short) ( Functions.SocketConnectClient( CLIENT , REPORTINGHOST , (ushort)( REPORTINGHOSTPORT ) , (ushort)( 0 ) ) ) ; 
        __context__.SourceCodeLine = 631;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 632;
            Print( "Error connecting socket to address {0} on port  {1:d}", REPORTINGHOST , (short)REPORTINGHOSTPORT) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLIENTCONNECTED_OnRelease_33 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        short STATUS = 0;
        
        
        __context__.SourceCodeLine = 640;
        STATUS = (short) ( Functions.SocketDisconnectClient( CLIENT ) ) ; 
        __context__.SourceCodeLine = 642;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 643;
            Print( "Error disconnecting socket to address {0} on port {1:d}", REPORTINGHOST , (short)REPORTINGHOSTPORT) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SYSTEMREADY_OnPush_34 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 648;
        _CLIENTCONNECTED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 649;
        BUILDHTTPMESSAGE (  __context__ , "controlProcessor", "System rebooted", "system", "") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLIENT_OnSocketConnect_35 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        short LOCALSTATUS = 0;
        short PORTNUMBER = 0;
        
        
        __context__.SourceCodeLine = 663;
        Print( "OnConnect: input buffer size is: {0:d}\r\n", (short)Functions.Length( CLIENT.SocketRxBuf )) ; 
        __context__.SourceCodeLine = 665;
        LOCALSTATUS = (short) ( Functions.SocketGetRemoteIPAddress( CLIENT , ref REPORTINGHOST ) ) ; 
        __context__.SourceCodeLine = 666;
        PORTNUMBER = (short) ( Functions.SocketGetPortNumber( CLIENT ) ) ; 
        __context__.SourceCodeLine = 668;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LOCALSTATUS < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 669;
            Print( "Error getting remote ip address. {0:d}\r\n", (short)LOCALSTATUS) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 670;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( PORTNUMBER < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 671;
                Print( "Error getting client port number. {0:d}\r\n", (int)REPORTINGHOSTPORT) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 673;
                Print( "OnConnect: Connected to port {0:d} on address {1}\r\n", (int)REPORTINGHOSTPORT, REPORTINGHOST ) ; 
                }
            
            }
        
        __context__.SourceCodeLine = 676;
        BUILDHTTPMESSAGE (  __context__ , "controlProcessor", "System active", "system", "") ; 
        __context__.SourceCodeLine = 680;
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object CLIENT_OnSocketDisconnect_36 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 693;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CLIENTCONNECTED  .Value == 0))  ) ) 
            {
            __context__.SourceCodeLine = 694;
            Print( "Socket disconnected remotely") ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 696;
            Print( "Local socket disconnect complete.") ; 
            }
        
        __context__.SourceCodeLine = 697;
        _CLIENTCONNECTED  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 698;
        _CLIENTCONNECTED  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 701;
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object CLIENT_OnSocketReceive_37 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 710;
        
        __context__.SourceCodeLine = 716;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( CLIENT.SocketRxBuf ) < 256 ))  ) ) 
            {
            __context__.SourceCodeLine = 717;
            Print( "Rx: {0}", CLIENT .  SocketRxBuf ) ; 
            }
        
        __context__.SourceCodeLine = 723;
        Functions.ClearBuffer ( CLIENT .  SocketRxBuf ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object CLIENT_OnSocketStatus_38 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        short STATUS = 0;
        
        
        __context__.SourceCodeLine = 730;
        STATUS = (short) ( __SocketInfo__.SocketStatus ) ; 
        __context__.SourceCodeLine = 731;
        
            {
            int __SPLS_TMPVAR__SWTCH_1__ = ((int)STATUS);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 736;
                    LOG (  __context__ , "SOCKET STATUS: Not Connected") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 742;
                    LOG (  __context__ , "SOCKET STATUS: Waiting for Connection") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 747;
                    LOG (  __context__ , "SOCKET STATUS: Connected") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 751;
                    LOG (  __context__ , "SOCKET STATUS: Connection Failed") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 757;
                    LOG (  __context__ , "SOCKET STATUS: Connection Broken Remotely") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 763;
                    LOG (  __context__ , "SOCKET STATUS: Connection Broken Locally") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 769;
                    LOG (  __context__ , "SOCKET STATUS: Performing DNS Lookup") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 773;
                    LOG (  __context__ , "SOCKET STATUS: DNS Lookup Failed") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 779;
                    LOG (  __context__ , "SOCKET STATUS: DNS Name Resolved") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 1 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 783;
                    LOG (  __context__ , "SOCKET STATUS: Client, Server or UDP variable not a TCP/IP or UDP variable.") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 2 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 788;
                    LOG (  __context__ , "SOCKET STATUS: Could not create the connection task") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 3 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 793;
                    LOG (  __context__ , "SOCKET STATUS: Could not resolve address") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 4 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 798;
                    LOG (  __context__ , "SOCKET STATUS: Port not in range of 0-65535.") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 5 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 804;
                    LOG (  __context__ , "SOCKET STATUS: No connection has been established") ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.ToLongInteger( -( 6 ) )) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 808;
                    LOG (  __context__ , "SOCKET STATUS: Not enough room in string parameter to hold IP address.") ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 814;
                    LOG (  __context__ , "Socket Status Undefined") ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 816;
        ; 
        
        
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
        
        __context__.SourceCodeLine = 834;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 836;
        REPORTINGHOST  .UpdateValue ( "awsElasticSearchUrl"  ) ; 
        __context__.SourceCodeLine = 837;
        REPORTINGHOSTPORT = (ushort) ( 80 ) ; 
        __context__.SourceCodeLine = 838;
        RECONNECTTIME = (ushort) ( 9000 ) ; 
        __context__.SourceCodeLine = 839;
        HOSTNAME  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 840;
        HOSTIP  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 841;
        HOSTMAC  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 842;
        HOSTBLDG  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 843;
        HOSTROOM  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 844;
        HOSTFLOOR  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 845;
        HOSTLAT  .UpdateValue ( "40.249719"  ) ; 
        __context__.SourceCodeLine = 846;
        HOSTLON  .UpdateValue ( "-111.649265"  ) ; 
        __context__.SourceCodeLine = 847;
        SESSION  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 848;
        INPUT1  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 849;
        INPUT2  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 850;
        INPUT3  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 851;
        INPUT4  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 852;
        INPUT5  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 853;
        INPUT6  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 854;
        INPUT7  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    REPORTINGHOST  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    HOSTNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    HOSTIP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
    HOSTMAC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    HOSTBLDG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    HOSTROOM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    HOSTFLOOR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    HOSTLAT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 11, this );
    HOSTLON  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 11, this );
    SESSION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
    INPUT1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT5  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT6  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    INPUT7  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    MESSAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
    CLIENT  = new SplusTcpClient ( 1024, this );
    
    STARTUP_PRESS = new Crestron.Logos.SplusObjects.DigitalInput( STARTUP_PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( STARTUP_PRESS__DigitalInput__, STARTUP_PRESS );
    
    CONFIRM_SYSTEM_OFF = new Crestron.Logos.SplusObjects.DigitalInput( CONFIRM_SYSTEM_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( CONFIRM_SYSTEM_OFF__DigitalInput__, CONFIRM_SYSTEM_OFF );
    
    PROGRAM_VOLUME_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( PROGRAM_VOLUME_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( PROGRAM_VOLUME_DOWN__DigitalInput__, PROGRAM_VOLUME_DOWN );
    
    PROGRAM_VOLUME_UP = new Crestron.Logos.SplusObjects.DigitalInput( PROGRAM_VOLUME_UP__DigitalInput__, this );
    m_DigitalInputList.Add( PROGRAM_VOLUME_UP__DigitalInput__, PROGRAM_VOLUME_UP );
    
    SELECT_AV_JACK = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_AV_JACK__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_AV_JACK__DigitalInput__, SELECT_AV_JACK );
    
    SELECT_BLANK = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_BLANK__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_BLANK__DigitalInput__, SELECT_BLANK );
    
    SELECT_BLURAY = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_BLURAY__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_BLURAY__DigitalInput__, SELECT_BLURAY );
    
    SELECT_DEVICE_CONTROL_BLURAY = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_DEVICE_CONTROL_BLURAY__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_DEVICE_CONTROL_BLURAY__DigitalInput__, SELECT_DEVICE_CONTROL_BLURAY );
    
    SELECT_DEVICE_CONTROL_IPTV = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_DEVICE_CONTROL_IPTV__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_DEVICE_CONTROL_IPTV__DigitalInput__, SELECT_DEVICE_CONTROL_IPTV );
    
    SELECT_HDMI_CABLE = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_HDMI_CABLE__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_HDMI_CABLE__DigitalInput__, SELECT_HDMI_CABLE );
    
    SELECT_HDMI_JACK = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_HDMI_JACK__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_HDMI_JACK__DigitalInput__, SELECT_HDMI_JACK );
    
    SELECT_IPTV = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_IPTV__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_IPTV__DigitalInput__, SELECT_IPTV );
    
    SELECT_LOCAL_INPUT = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_LOCAL_INPUT__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_LOCAL_INPUT__DigitalInput__, SELECT_LOCAL_INPUT );
    
    SELECT_PA_CONTROL = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_PA_CONTROL__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_PA_CONTROL__DigitalInput__, SELECT_PA_CONTROL );
    
    SELECT_REMOTE_INPUT1 = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_REMOTE_INPUT1__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_REMOTE_INPUT1__DigitalInput__, SELECT_REMOTE_INPUT1 );
    
    SELECT_REMOTE_INPUT2 = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_REMOTE_INPUT2__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_REMOTE_INPUT2__DigitalInput__, SELECT_REMOTE_INPUT2 );
    
    SELECT_VGA_CABLE = new Crestron.Logos.SplusObjects.DigitalInput( SELECT_VGA_CABLE__DigitalInput__, this );
    m_DigitalInputList.Add( SELECT_VGA_CABLE__DigitalInput__, SELECT_VGA_CABLE );
    
    HELP_MENU_PRESS = new Crestron.Logos.SplusObjects.DigitalInput( HELP_MENU_PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( HELP_MENU_PRESS__DigitalInput__, HELP_MENU_PRESS );
    
    HOME_BUTTON = new Crestron.Logos.SplusObjects.DigitalInput( HOME_BUTTON__DigitalInput__, this );
    m_DigitalInputList.Add( HOME_BUTTON__DigitalInput__, HOME_BUTTON );
    
    PROGRAM_VOLUME_SLIDER_PRESS = new Crestron.Logos.SplusObjects.DigitalInput( PROGRAM_VOLUME_SLIDER_PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( PROGRAM_VOLUME_SLIDER_PRESS__DigitalInput__, PROGRAM_VOLUME_SLIDER_PRESS );
    
    AUDIO_ONLY_PRESS = new Crestron.Logos.SplusObjects.DigitalInput( AUDIO_ONLY_PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( AUDIO_ONLY_PRESS__DigitalInput__, AUDIO_ONLY_PRESS );
    
    CLIENTCONNECTED = new Crestron.Logos.SplusObjects.DigitalInput( CLIENTCONNECTED__DigitalInput__, this );
    m_DigitalInputList.Add( CLIENTCONNECTED__DigitalInput__, CLIENTCONNECTED );
    
    SYSTEMREADY = new Crestron.Logos.SplusObjects.DigitalInput( SYSTEMREADY__DigitalInput__, this );
    m_DigitalInputList.Add( SYSTEMREADY__DigitalInput__, SYSTEMREADY );
    
    _CLIENTCONNECTED = new Crestron.Logos.SplusObjects.DigitalOutput( _CLIENTCONNECTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( _CLIENTCONNECTED__DigitalOutput__, _CLIENTCONNECTED );
    
    CPHOSTNAME = new Crestron.Logos.SplusObjects.StringInput( CPHOSTNAME__AnalogSerialInput__, 32, this );
    m_StringInputList.Add( CPHOSTNAME__AnalogSerialInput__, CPHOSTNAME );
    
    CPIP = new Crestron.Logos.SplusObjects.StringInput( CPIP__AnalogSerialInput__, 15, this );
    m_StringInputList.Add( CPIP__AnalogSerialInput__, CPIP );
    
    CPMACADDR = new Crestron.Logos.SplusObjects.StringInput( CPMACADDR__AnalogSerialInput__, 18, this );
    m_StringInputList.Add( CPMACADDR__AnalogSerialInput__, CPMACADDR );
    
    DEVBUILDING = new Crestron.Logos.SplusObjects.StringInput( DEVBUILDING__AnalogSerialInput__, 8, this );
    m_StringInputList.Add( DEVBUILDING__AnalogSerialInput__, DEVBUILDING );
    
    DEVROOM = new Crestron.Logos.SplusObjects.StringInput( DEVROOM__AnalogSerialInput__, 16, this );
    m_StringInputList.Add( DEVROOM__AnalogSerialInput__, DEVROOM );
    
    DEVFLOOR = new Crestron.Logos.SplusObjects.StringInput( DEVFLOOR__AnalogSerialInput__, 2, this );
    m_StringInputList.Add( DEVFLOOR__AnalogSerialInput__, DEVFLOOR );
    
    DEVLATITUDE = new Crestron.Logos.SplusObjects.StringInput( DEVLATITUDE__AnalogSerialInput__, 11, this );
    m_StringInputList.Add( DEVLATITUDE__AnalogSerialInput__, DEVLATITUDE );
    
    DEVLONGITUDE = new Crestron.Logos.SplusObjects.StringInput( DEVLONGITUDE__AnalogSerialInput__, 11, this );
    m_StringInputList.Add( DEVLONGITUDE__AnalogSerialInput__, DEVLONGITUDE );
    
    VOLUMELEVEL = new Crestron.Logos.SplusObjects.StringInput( VOLUMELEVEL__AnalogSerialInput__, 4, this );
    m_StringInputList.Add( VOLUMELEVEL__AnalogSerialInput__, VOLUMELEVEL );
    
    SESSIONID = new Crestron.Logos.SplusObjects.StringInput( SESSIONID__AnalogSerialInput__, 256, this );
    m_StringInputList.Add( SESSIONID__AnalogSerialInput__, SESSIONID );
    
    INPUTLABEL1 = new Crestron.Logos.SplusObjects.StringInput( INPUTLABEL1__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( INPUTLABEL1__AnalogSerialInput__, INPUTLABEL1 );
    
    INPUTLABEL2 = new Crestron.Logos.SplusObjects.StringInput( INPUTLABEL2__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( INPUTLABEL2__AnalogSerialInput__, INPUTLABEL2 );
    
    INPUTLABEL3 = new Crestron.Logos.SplusObjects.StringInput( INPUTLABEL3__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( INPUTLABEL3__AnalogSerialInput__, INPUTLABEL3 );
    
    INPUTLABEL4 = new Crestron.Logos.SplusObjects.StringInput( INPUTLABEL4__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( INPUTLABEL4__AnalogSerialInput__, INPUTLABEL4 );
    
    INPUTLABEL5 = new Crestron.Logos.SplusObjects.StringInput( INPUTLABEL5__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( INPUTLABEL5__AnalogSerialInput__, INPUTLABEL5 );
    
    INPUTLABEL6 = new Crestron.Logos.SplusObjects.StringInput( INPUTLABEL6__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( INPUTLABEL6__AnalogSerialInput__, INPUTLABEL6 );
    
    INPUTLABEL7 = new Crestron.Logos.SplusObjects.StringInput( INPUTLABEL7__AnalogSerialInput__, 30, this );
    m_StringInputList.Add( INPUTLABEL7__AnalogSerialInput__, INPUTLABEL7 );
    
    TODEVBUILDING = new Crestron.Logos.SplusObjects.StringOutput( TODEVBUILDING__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODEVBUILDING__AnalogSerialOutput__, TODEVBUILDING );
    
    TODEVROOM = new Crestron.Logos.SplusObjects.StringOutput( TODEVROOM__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODEVROOM__AnalogSerialOutput__, TODEVROOM );
    
    TODEVFLOOR = new Crestron.Logos.SplusObjects.StringOutput( TODEVFLOOR__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODEVFLOOR__AnalogSerialOutput__, TODEVFLOOR );
    
    TODEVLAT = new Crestron.Logos.SplusObjects.StringOutput( TODEVLAT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODEVLAT__AnalogSerialOutput__, TODEVLAT );
    
    TODEVLON = new Crestron.Logos.SplusObjects.StringOutput( TODEVLON__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODEVLON__AnalogSerialOutput__, TODEVLON );
    
    TOCLIENTBUFFER__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TOCLIENTBUFFER__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TOCLIENTBUFFER__DOLLAR____AnalogSerialOutput__, TOCLIENTBUFFER__DOLLAR__ );
    
    STORESESSIONID = new Crestron.Logos.SplusObjects.StringOutput( STORESESSIONID__AnalogSerialOutput__, this );
    m_StringOutputList.Add( STORESESSIONID__AnalogSerialOutput__, STORESESSIONID );
    
    CLIENTBUFFER = new Crestron.Logos.SplusObjects.BufferInput( CLIENTBUFFER__AnalogSerialInput__, 100, this );
    m_StringInputList.Add( CLIENTBUFFER__AnalogSerialInput__, CLIENTBUFFER );
    
    
    STARTUP_PRESS.OnDigitalRelease.Add( new InputChangeHandlerWrapper( STARTUP_PRESS_OnRelease_0, false ) );
    CONFIRM_SYSTEM_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CONFIRM_SYSTEM_OFF_OnRelease_1, false ) );
    PROGRAM_VOLUME_DOWN.OnDigitalRelease.Add( new InputChangeHandlerWrapper( PROGRAM_VOLUME_DOWN_OnRelease_2, false ) );
    PROGRAM_VOLUME_UP.OnDigitalRelease.Add( new InputChangeHandlerWrapper( PROGRAM_VOLUME_UP_OnRelease_3, false ) );
    SELECT_BLANK.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_BLANK_OnRelease_4, false ) );
    SELECT_DEVICE_CONTROL_IPTV.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_DEVICE_CONTROL_IPTV_OnRelease_5, false ) );
    SELECT_HDMI_CABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_HDMI_CABLE_OnRelease_6, false ) );
    SELECT_HDMI_JACK.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_HDMI_JACK_OnRelease_7, false ) );
    SELECT_IPTV.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_IPTV_OnRelease_8, false ) );
    SELECT_LOCAL_INPUT.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_LOCAL_INPUT_OnRelease_9, false ) );
    SELECT_REMOTE_INPUT1.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_REMOTE_INPUT1_OnRelease_10, false ) );
    SELECT_REMOTE_INPUT2.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_REMOTE_INPUT2_OnRelease_11, false ) );
    SELECT_VGA_CABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_VGA_CABLE_OnRelease_12, false ) );
    HELP_MENU_PRESS.OnDigitalRelease.Add( new InputChangeHandlerWrapper( HELP_MENU_PRESS_OnRelease_13, false ) );
    HOME_BUTTON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( HOME_BUTTON_OnRelease_14, false ) );
    SELECT_AV_JACK.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_AV_JACK_OnRelease_15, false ) );
    SELECT_BLURAY.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_BLURAY_OnRelease_16, false ) );
    SELECT_DEVICE_CONTROL_BLURAY.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_DEVICE_CONTROL_BLURAY_OnRelease_17, false ) );
    SELECT_PA_CONTROL.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SELECT_PA_CONTROL_OnRelease_18, false ) );
    PROGRAM_VOLUME_SLIDER_PRESS.OnDigitalRelease.Add( new InputChangeHandlerWrapper( PROGRAM_VOLUME_SLIDER_PRESS_OnRelease_19, false ) );
    AUDIO_ONLY_PRESS.OnDigitalRelease.Add( new InputChangeHandlerWrapper( AUDIO_ONLY_PRESS_OnRelease_20, false ) );
    CPHOSTNAME.OnSerialChange.Add( new InputChangeHandlerWrapper( CPHOSTNAME_OnChange_21, false ) );
    CPIP.OnSerialChange.Add( new InputChangeHandlerWrapper( CPIP_OnChange_22, false ) );
    CPMACADDR.OnSerialChange.Add( new InputChangeHandlerWrapper( CPMACADDR_OnChange_23, false ) );
    SESSIONID.OnSerialChange.Add( new InputChangeHandlerWrapper( SESSIONID_OnChange_24, false ) );
    INPUTLABEL1.OnSerialChange.Add( new InputChangeHandlerWrapper( INPUTLABEL1_OnChange_25, false ) );
    INPUTLABEL2.OnSerialChange.Add( new InputChangeHandlerWrapper( INPUTLABEL2_OnChange_26, false ) );
    INPUTLABEL3.OnSerialChange.Add( new InputChangeHandlerWrapper( INPUTLABEL3_OnChange_27, false ) );
    INPUTLABEL4.OnSerialChange.Add( new InputChangeHandlerWrapper( INPUTLABEL4_OnChange_28, false ) );
    INPUTLABEL5.OnSerialChange.Add( new InputChangeHandlerWrapper( INPUTLABEL5_OnChange_29, false ) );
    INPUTLABEL6.OnSerialChange.Add( new InputChangeHandlerWrapper( INPUTLABEL6_OnChange_30, false ) );
    INPUTLABEL7.OnSerialChange.Add( new InputChangeHandlerWrapper( INPUTLABEL7_OnChange_31, false ) );
    CLIENTCONNECTED.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLIENTCONNECTED_OnPush_32, false ) );
    CLIENTCONNECTED.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CLIENTCONNECTED_OnRelease_33, false ) );
    SYSTEMREADY.OnDigitalPush.Add( new InputChangeHandlerWrapper( SYSTEMREADY_OnPush_34, false ) );
    CLIENT.OnSocketConnect.Add( new SocketHandlerWrapper( CLIENT_OnSocketConnect_35, true ) );
    CLIENT.OnSocketDisconnect.Add( new SocketHandlerWrapper( CLIENT_OnSocketDisconnect_36, false ) );
    CLIENT.OnSocketReceive.Add( new SocketHandlerWrapper( CLIENT_OnSocketReceive_37, false ) );
    CLIENT.OnSocketStatus.Add( new SocketHandlerWrapper( CLIENT_OnSocketStatus_38, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_METRICS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint STARTUP_PRESS__DigitalInput__ = 0;
const uint CONFIRM_SYSTEM_OFF__DigitalInput__ = 1;
const uint PROGRAM_VOLUME_DOWN__DigitalInput__ = 2;
const uint PROGRAM_VOLUME_UP__DigitalInput__ = 3;
const uint SELECT_AV_JACK__DigitalInput__ = 4;
const uint SELECT_BLANK__DigitalInput__ = 5;
const uint SELECT_BLURAY__DigitalInput__ = 6;
const uint SELECT_DEVICE_CONTROL_BLURAY__DigitalInput__ = 7;
const uint SELECT_DEVICE_CONTROL_IPTV__DigitalInput__ = 8;
const uint SELECT_HDMI_CABLE__DigitalInput__ = 9;
const uint SELECT_HDMI_JACK__DigitalInput__ = 10;
const uint SELECT_IPTV__DigitalInput__ = 11;
const uint SELECT_LOCAL_INPUT__DigitalInput__ = 12;
const uint SELECT_PA_CONTROL__DigitalInput__ = 13;
const uint SELECT_REMOTE_INPUT1__DigitalInput__ = 14;
const uint SELECT_REMOTE_INPUT2__DigitalInput__ = 15;
const uint SELECT_VGA_CABLE__DigitalInput__ = 16;
const uint HELP_MENU_PRESS__DigitalInput__ = 17;
const uint HOME_BUTTON__DigitalInput__ = 18;
const uint PROGRAM_VOLUME_SLIDER_PRESS__DigitalInput__ = 19;
const uint AUDIO_ONLY_PRESS__DigitalInput__ = 20;
const uint CLIENTCONNECTED__DigitalInput__ = 21;
const uint SYSTEMREADY__DigitalInput__ = 22;
const uint CPHOSTNAME__AnalogSerialInput__ = 0;
const uint CPIP__AnalogSerialInput__ = 1;
const uint CPMACADDR__AnalogSerialInput__ = 2;
const uint DEVBUILDING__AnalogSerialInput__ = 3;
const uint DEVROOM__AnalogSerialInput__ = 4;
const uint DEVFLOOR__AnalogSerialInput__ = 5;
const uint DEVLATITUDE__AnalogSerialInput__ = 6;
const uint DEVLONGITUDE__AnalogSerialInput__ = 7;
const uint VOLUMELEVEL__AnalogSerialInput__ = 8;
const uint SESSIONID__AnalogSerialInput__ = 9;
const uint INPUTLABEL1__AnalogSerialInput__ = 10;
const uint INPUTLABEL2__AnalogSerialInput__ = 11;
const uint INPUTLABEL3__AnalogSerialInput__ = 12;
const uint INPUTLABEL4__AnalogSerialInput__ = 13;
const uint INPUTLABEL5__AnalogSerialInput__ = 14;
const uint INPUTLABEL6__AnalogSerialInput__ = 15;
const uint INPUTLABEL7__AnalogSerialInput__ = 16;
const uint CLIENTBUFFER__AnalogSerialInput__ = 17;
const uint _CLIENTCONNECTED__DigitalOutput__ = 0;
const uint TODEVBUILDING__AnalogSerialOutput__ = 0;
const uint TODEVROOM__AnalogSerialOutput__ = 1;
const uint TODEVFLOOR__AnalogSerialOutput__ = 2;
const uint TODEVLAT__AnalogSerialOutput__ = 3;
const uint TODEVLON__AnalogSerialOutput__ = 4;
const uint TOCLIENTBUFFER__DOLLAR____AnalogSerialOutput__ = 5;
const uint STORESESSIONID__AnalogSerialOutput__ = 6;

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

[SplusStructAttribute(-1, true, false)]
public class QUEUEDEVENT : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  USERORSYSTEM;
    
    [SplusStructAttribute(1, false, false)]
    public CrestronString  HEADER1;
    
    [SplusStructAttribute(2, false, false)]
    public CrestronString  HEADER2;
    
    [SplusStructAttribute(3, false, false)]
    public CrestronString  HEADER3;
    
    [SplusStructAttribute(4, false, false)]
    public CrestronString  HEADER4;
    
    [SplusStructAttribute(5, false, false)]
    public CrestronString  HEADER5;
    
    [SplusStructAttribute(6, false, false)]
    public CrestronString  HEADER6;
    
    [SplusStructAttribute(7, false, false)]
    public CrestronString  INNERMSG1;
    
    [SplusStructAttribute(8, false, false)]
    public CrestronString  INNERMSG2;
    
    [SplusStructAttribute(9, false, false)]
    public CrestronString  INNERMSG3;
    
    [SplusStructAttribute(10, false, false)]
    public CrestronString  INNERMSG4;
    
    
    public QUEUEDEVENT( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        USERORSYSTEM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, Owner );
        HEADER1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        HEADER2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        HEADER3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        HEADER4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        HEADER5  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        HEADER6  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        INNERMSG1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        INNERMSG2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        INNERMSG3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        INNERMSG4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, Owner );
        
        
    }
    
}

}
