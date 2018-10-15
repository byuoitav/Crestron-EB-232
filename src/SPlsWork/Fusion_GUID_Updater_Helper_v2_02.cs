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

namespace CrestronModule_FUSION_GUID_UPDATER_HELPER_V2_02
{
    public class CrestronModuleClass_FUSION_GUID_UPDATER_HELPER_V2_02 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput UPDATE_GUIDS_B;
        Crestron.Logos.SplusObjects.StringInput MASTER_OVERRIDE_GUID_PREFIX__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput CONSOLE_RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.BufferInput> OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput UPDATE_GUIDS_BUSY_FB;
        Crestron.Logos.SplusObjects.StringOutput UPDATE_GUID_STATUS_TXT__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput MASTER_GUID_PREFIX_TXT__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput RVI_FILE_NAME_TXT__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput RVI_FILE_FULL_PATH_TXT__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput CONSOLE_TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput CONSOLE_STATUS_TXT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> SYMBOL_GUID_COUNT_FB;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SYMBOL_GUID_COUNT_TXT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SYMBOL_ROOM_NAME_TXT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SYMBOL_GUID_TXT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SYMBOL_IPID_TXT__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> SYMBOL_SLOT_GUIDS_TX__DOLLAR__;
        UShortParameter PROCESSORMODE;
        UShortParameter PREFIXGUIDS;
        UShortParameter THREESERIESAPPENDSLOTNUMBER;
        StringParameter FILESTORAGELOCATION__DOLLAR__;
        SplusTcpClient TCPCONSOLE;
        ushort G_NCOUNT = 0;
        ushort G_NDEBUG = 0;
        ushort G_NCONSOLESTEP = 0;
        ushort G_NFUSIONDATASTARTED = 0;
        ushort G_NFUSIONSYMBOLDATASTARTED = 0;
        ushort G_NFUSIONSYMBOLCOUNT = 0;
        ushort G_NSEMAPHORE = 0;
        ushort G_NSLOTNUMBER = 0;
        ushort G_NINSTANCEIDFOUND = 0;
        ushort G_NTSIDRETRYCOUNT = 0;
        ushort G_NTSIDUPDATEBUSY = 0;
        ushort G_NINITIALRUN = 0;
        ushort G_NRVIFILECHANGED = 0;
        ushort G_NROOMNAMEOVERRIDEALLOWED = 0;
        ushort G_NMASTERGUIDOVERRIDE = 0;
        ushort [] G_NGUIDOVERRIDE;
        ushort [] G_NROOMNAMEUPDATED;
        ushort [] G_NGUIDCOUNT;
        short G_SNCONSOLECONNECTIONOK = 0;
        short G_SNCONSOLECONNECTIONSTATUS = 0;
        CrestronString G_SMASTERGUIDPREFIX__DOLLAR__;
        CrestronString [] G_SGUIDPREFIX__DOLLAR__;
        CrestronString G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__;
        CrestronString G_SRVITEMP__DOLLAR__;
        CrestronString G_SRVINEWFILETEMP__DOLLAR__;
        CrestronString G_SRVIFULLFILEPATH__DOLLAR__;
        CrestronString G_SRVINEWFULLFILEPATH__DOLLAR__;
        CrestronString G_SRVIFILENAME__DOLLAR__;
        CrestronString G_SRVIFILELOCATION__DOLLAR__;
        CrestronString [] G_SOVERRIDEROOMNAME__DOLLAR__;
        private CrestronString UPDATEGUIDPREFIX (  SplusExecutionContext __context__, CrestronString SCURRENTGUIDPREFIX__DOLLAR__ , ushort NGUIDSYMBOLNUMBER ) 
            { 
            ushort NPROGSLOT2 = 0;
            
            CrestronString SNEWGUIDPREFIX__DOLLAR__;
            SNEWGUIDPREFIX__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 12, this );
            
            
            __context__.SourceCodeLine = 244;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 244;
                Trace( "***** Start UpdateGUIDPrefix *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 245;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 245;
                Trace( "sCurrentGUIDPrefix$ = {0}\r\n", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 246;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 246;
                Trace( "nGUIDSymbolNumber = {0:d}\r\n", (short)NGUIDSYMBOLNUMBER) ; 
                }
            
            __context__.SourceCodeLine = 248;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NGUIDSYMBOLNUMBER == 1000))  ) ) 
                { 
                __context__.SourceCodeLine = 250;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 250;
                    Trace( "Inside if(nGUIDSymbolNumber = cnGUIDMasterOverride)\r\n") ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 252;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NGUIDSYMBOLNUMBER == 1001))  ) ) 
                    { 
                    __context__.SourceCodeLine = 254;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 254;
                        Trace( "Inside else if(nGUIDSymbolNumber = cnGUIDConsoleOverride)\r\n") ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 256;
                    if ( Functions.TestForTrue  ( ( G_NGUIDOVERRIDE[ NGUIDSYMBOLNUMBER ])  ) ) 
                        { 
                        __context__.SourceCodeLine = 258;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 258;
                            Trace( "g_nGUIDOverride[nGUIDSymbolNumber] = {0:d}\r\n", (short)G_NGUIDOVERRIDE[ NGUIDSYMBOLNUMBER ]) ; 
                            }
                        
                        __context__.SourceCodeLine = 259;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 259;
                            Trace( "Inside if(g_nGUIDOverride[nGUIDSymbolNumber]), g_sGUIDPrefix$ = {0}\r\n", G_SGUIDPREFIX__DOLLAR__ [ NGUIDSYMBOLNUMBER ] ) ; 
                            }
                        
                        __context__.SourceCodeLine = 260;
                        MakeString ( SCURRENTGUIDPREFIX__DOLLAR__ , "{0}", G_SGUIDPREFIX__DOLLAR__ [ NGUIDSYMBOLNUMBER ] ) ; 
                        } 
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 263;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)Functions.GetSeries());
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 267;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 267;
                            Trace( "2 Series Processor\r\n") ; 
                            }
                        
                        __context__.SourceCodeLine = 268;
                        MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 272;
                        NPROGSLOT2 = (ushort) ( GetProgramNumber() ) ; 
                        __context__.SourceCodeLine = 274;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 274;
                            Trace( "3 Series Processor\r\n") ; 
                            }
                        
                        __context__.SourceCodeLine = 275;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 275;
                            Trace( "nProgSlot2 = {0:d}\r\n", (ushort)NPROGSLOT2) ; 
                            }
                        
                        __context__.SourceCodeLine = 277;
                        if ( Functions.TestForTrue  ( ( THREESERIESAPPENDSLOTNUMBER  .Value)  ) ) 
                            { 
                            __context__.SourceCodeLine = 279;
                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                {
                                __context__.SourceCodeLine = 279;
                                Trace( "Inside if(ThreeSeriesAppendSlotNumber)\r\n") ; 
                                }
                            
                            __context__.SourceCodeLine = 280;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 282;
                                MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-01", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 284;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 2))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 286;
                                    MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-02", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 288;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 3))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 290;
                                        MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-03", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 292;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 4))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 294;
                                            MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-04", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 296;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 5))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 298;
                                                MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-05", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 300;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 6))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 302;
                                                    MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-06", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 304;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 7))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 306;
                                                        MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-07", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 308;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 8))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 310;
                                                            MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-08", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 312;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 9))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 314;
                                                                MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-09", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                                                } 
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 316;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT2 == 10))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 318;
                                                                    MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}-10", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                                                                    } 
                                                                
                                                                }
                                                            
                                                            }
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 323;
                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                {
                                __context__.SourceCodeLine = 323;
                                Trace( "Inside ELSE FOR if(ThreeSeriesAppendSlotNumber)\r\n") ; 
                                }
                            
                            __context__.SourceCodeLine = 324;
                            MakeString ( SNEWGUIDPREFIX__DOLLAR__ , "{0}", SCURRENTGUIDPREFIX__DOLLAR__ ) ; 
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 329;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 329;
                Trace( "sNewGUIDPrefix$ = {0}\r\n", SNEWGUIDPREFIX__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 330;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 330;
                Trace( "***** End UpdateGUIDPrefix *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 332;
            return ( SNEWGUIDPREFIX__DOLLAR__ ) ; 
            
            }
            
        private CrestronString GETRVISEARCHLOCATION (  SplusExecutionContext __context__ ) 
            { 
            ushort NPROGSLOT = 0;
            
            
            __context__.SourceCodeLine = 339;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 339;
                Trace( "***** Start GetRVISearchLocation *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 341;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Determining Processor Type...") ; 
            __context__.SourceCodeLine = 343;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)Functions.GetSeries());
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 347;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 347;
                            Trace( "2 Series Processor\r\n") ; 
                            }
                        
                        __context__.SourceCodeLine = 348;
                        MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}", "\\SIMPL\\" ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 352;
                        NPROGSLOT = (ushort) ( GetProgramNumber() ) ; 
                        __context__.SourceCodeLine = 354;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 354;
                            Trace( "3 Series Processor\r\n") ; 
                            }
                        
                        __context__.SourceCodeLine = 355;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 355;
                            Trace( "nProgSlot = {0:d}\r\n", (ushort)NPROGSLOT) ; 
                            }
                        
                        __context__.SourceCodeLine = 357;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 359;
                            MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App01\\", "\\SIMPL\\" ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 361;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 2))  ) ) 
                                { 
                                __context__.SourceCodeLine = 363;
                                MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App02\\", "\\SIMPL\\" ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 365;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 3))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 367;
                                    MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App03\\", "\\SIMPL\\" ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 369;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 4))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 371;
                                        MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App04\\", "\\SIMPL\\" ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 373;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 5))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 375;
                                            MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App05\\", "\\SIMPL\\" ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 377;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 6))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 379;
                                                MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App06\\", "\\SIMPL\\" ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 381;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 7))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 383;
                                                    MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App07\\", "\\SIMPL\\" ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 385;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 8))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 387;
                                                        MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App08\\", "\\SIMPL\\" ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 389;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 9))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 391;
                                                            MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App09\\", "\\SIMPL\\" ) ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 393;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NPROGSLOT == 10))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 395;
                                                                MakeString ( G_SRVIFILELOCATION__DOLLAR__ , "{0}App10\\", "\\SIMPL\\" ) ; 
                                                                } 
                                                            
                                                            }
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 400;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 400;
                Trace( "g_sRVIFileLocation$ = {0}\r\n", G_SRVIFILELOCATION__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 401;
            return ( G_SRVIFILELOCATION__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 403;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 403;
                Trace( "***** End GetRVISearchLocation *****\r\n") ; 
                }
            
            
            }
            
        private CrestronString FINDRVIFILE (  SplusExecutionContext __context__ ) 
            { 
            FILE_INFO FIFILEINFO;
            FIFILEINFO  = new FILE_INFO();
            FIFILEINFO .PopulateDefaults();
            
            CrestronString SRVIFILENAME__DOLLAR__;
            CrestronString SRVISEARCHPATH__DOLLAR__;
            SRVIFILENAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            SRVISEARCHPATH__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            short SNRVIFILEFOUND = 0;
            short SNSTARTFILEIOERROR = 0;
            short SNENDFILEIOERROR = 0;
            
            
            __context__.SourceCodeLine = 412;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 412;
                Trace( "***** Start FindRVIFile *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 414;
            GETRVISEARCHLOCATION (  __context__  ) ; 
            __context__.SourceCodeLine = 416;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Finding RVI File...") ; 
            __context__.SourceCodeLine = 418;
            MakeString ( SRVISEARCHPATH__DOLLAR__ , "{0}{1}", G_SRVIFILELOCATION__DOLLAR__ , "*.rvi" ) ; 
            __context__.SourceCodeLine = 420;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 420;
                Trace( "sRVISearchPath$ = {0}\r\n", SRVISEARCHPATH__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 422;
            SNSTARTFILEIOERROR = (short) ( StartFileOperations() ) ; 
            __context__.SourceCodeLine = 423;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNSTARTFILEIOERROR != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 425;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 425;
                    Trace( "Start File Operations Error Retrying\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 426;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 427;
                SNSTARTFILEIOERROR = (short) ( StartFileOperations() ) ; 
                __context__.SourceCodeLine = 423;
                } 
            
            __context__.SourceCodeLine = 429;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)Functions.GetSeries());
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 433;
                        SNRVIFILEFOUND = (short) ( FindFirst( SRVISEARCHPATH__DOLLAR__ , ref FIFILEINFO ) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 437;
                        SNRVIFILEFOUND = (short) ( FindFirstShared( SRVISEARCHPATH__DOLLAR__ , ref FIFILEINFO ) ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 441;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 441;
                Trace( "snRVIFileFound = {0:d}\r\n", (short)SNRVIFILEFOUND) ; 
                }
            
            __context__.SourceCodeLine = 442;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNRVIFILEFOUND == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 444;
                MakeString ( SRVIFILENAME__DOLLAR__ , "{0}", FIFILEINFO .  Name ) ; 
                __context__.SourceCodeLine = 445;
                MakeString ( G_SRVIFILENAME__DOLLAR__ , "{0}", FIFILEINFO .  Name ) ; 
                __context__.SourceCodeLine = 446;
                MakeString ( RVI_FILE_NAME_TXT__DOLLAR__ , "{0}", G_SRVIFILENAME__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 447;
                MakeString ( RVI_FILE_FULL_PATH_TXT__DOLLAR__ , "{0}{1}", G_SRVIFILELOCATION__DOLLAR__ , G_SRVIFILENAME__DOLLAR__ ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 451;
                MakeString ( SRVIFILENAME__DOLLAR__ , "{0}", "FileFoundError" ) ; 
                __context__.SourceCodeLine = 452;
                MakeString ( G_SRVIFILENAME__DOLLAR__ , "{0}", "FileFoundError" ) ; 
                __context__.SourceCodeLine = 453;
                MakeString ( RVI_FILE_NAME_TXT__DOLLAR__ , "{0}", "FileFoundError" ) ; 
                __context__.SourceCodeLine = 454;
                MakeString ( RVI_FILE_FULL_PATH_TXT__DOLLAR__ , "{0}", "FileFoundError" ) ; 
                } 
            
            __context__.SourceCodeLine = 456;
            SNENDFILEIOERROR = (short) ( EndFileOperations() ) ; 
            __context__.SourceCodeLine = 457;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNENDFILEIOERROR != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 459;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 459;
                    Trace( "End File Operations Error Retrying\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 460;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 461;
                SNENDFILEIOERROR = (short) ( EndFileOperations() ) ; 
                __context__.SourceCodeLine = 457;
                } 
            
            __context__.SourceCodeLine = 464;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 464;
                Trace( "sRVIFileName$ = {0}\r\n", SRVIFILENAME__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 465;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 465;
                Trace( "g_sRVIFileName$ = {0}\r\n", G_SRVIFILENAME__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 466;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 466;
                Trace( "g_sRVIFileLocation$ = {0}\r\n", G_SRVIFILELOCATION__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 468;
            return ( SRVIFILENAME__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 470;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 470;
                Trace( "***** End FindRVIFile *****\r\n") ; 
                }
            
            
            }
            
        private void WRITETEMPFILE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SFILEWRITEPATH__DOLLAR__;
            SFILEWRITEPATH__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            ushort NFILELEN = 0;
            
            short SNFILEHANDLE = 0;
            short SNNUMWRITE = 0;
            short SNSTARTFILEIOERROR = 0;
            short SNENDFILEIOERROR = 0;
            short SNFILECLOSEERROR = 0;
            
            
            __context__.SourceCodeLine = 479;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 479;
                Trace( "***** Start WriteTempFile *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 481;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Writing Data To File...") ; 
            __context__.SourceCodeLine = 483;
            MakeString ( SFILEWRITEPATH__DOLLAR__ , "{0}{1}", FILESTORAGELOCATION__DOLLAR__ , G_SRVIFILENAME__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 484;
            MakeString ( G_SRVINEWFULLFILEPATH__DOLLAR__ , "{0}{1}", FILESTORAGELOCATION__DOLLAR__ , G_SRVIFILENAME__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 486;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 486;
                Trace( "sFileWritePath$ = {0}\r\n", SFILEWRITEPATH__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 487;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 487;
                Trace( "cs2SeriesDebugTempRVIFile = {0}\r\n", "\\NVRAM\\Fusion GUID Updater Simple Test Pro2 10-21-2013 rev3.rvi" ) ; 
                }
            
            __context__.SourceCodeLine = 489;
            SNSTARTFILEIOERROR = (short) ( StartFileOperations() ) ; 
            __context__.SourceCodeLine = 490;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNSTARTFILEIOERROR != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 492;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 492;
                    Trace( "Start File Operations Error Retrying\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 493;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 494;
                SNSTARTFILEIOERROR = (short) ( StartFileOperations() ) ; 
                __context__.SourceCodeLine = 490;
                } 
            
            __context__.SourceCodeLine = 496;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                { 
                __context__.SourceCodeLine = 498;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_4__ = ((int)Functions.GetSeries());
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 502;
                            SNFILEHANDLE = (short) ( FileOpen( "\\NVRAM\\Fusion GUID Updater Simple Test Pro2 10-21-2013 rev3.rvi" ,(ushort) (((1 | 256) | 8) | 16384) ) ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 506;
                            SNFILEHANDLE = (short) ( FileOpenShared( "\\NVRAM\\ADG-PV-Room_230-140310.rvi" ,(ushort) (((1 | 256) | 8) | 16384) ) ) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 512;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_5__ = ((int)Functions.GetSeries());
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 516;
                            SNFILEHANDLE = (short) ( FileOpen( SFILEWRITEPATH__DOLLAR__ ,(ushort) (((1 | 256) | 8) | 16384) ) ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 520;
                            SNFILEHANDLE = (short) ( FileOpenShared( SFILEWRITEPATH__DOLLAR__ ,(ushort) (((1 | 256) | 8) | 16384) ) ) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            __context__.SourceCodeLine = 525;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                { 
                __context__.SourceCodeLine = 527;
                Trace( "FileOpen Complete\r\n") ; 
                __context__.SourceCodeLine = 528;
                Trace( "snFileHandle = {0:d}\r\n", (short)SNFILEHANDLE) ; 
                } 
            
            __context__.SourceCodeLine = 531;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SNFILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 533;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 533;
                    Trace( "***** Inside if(snFileHandle >= 0) *****\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 534;
                NFILELEN = (ushort) ( Functions.Length( G_SRVINEWFILETEMP__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 535;
                SNNUMWRITE = (short) ( FileWrite( (short)( SNFILEHANDLE ) , G_SRVINEWFILETEMP__DOLLAR__ , (ushort)( NFILELEN ) ) ) ; 
                __context__.SourceCodeLine = 536;
                SNFILECLOSEERROR = (short) ( FileClose( (short)( SNFILEHANDLE ) ) ) ; 
                __context__.SourceCodeLine = 537;
                while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNFILECLOSEERROR != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 539;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 539;
                        Trace( "File Close Error Retrying\r\n") ; 
                        }
                    
                    __context__.SourceCodeLine = 540;
                    Functions.Delay (  (int) ( 100 ) ) ; 
                    __context__.SourceCodeLine = 541;
                    SNFILECLOSEERROR = (short) ( FileClose( (short)( SNFILEHANDLE ) ) ) ; 
                    __context__.SourceCodeLine = 537;
                    } 
                
                __context__.SourceCodeLine = 544;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 544;
                    Trace( "g_sRVINewFileTemp$ = {0}\r\n", G_SRVINEWFILETEMP__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 545;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 545;
                    Trace( "nFileLen = {0:d}\r\n", (short)NFILELEN) ; 
                    }
                
                __context__.SourceCodeLine = 546;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 546;
                    Trace( "snNumWrite = {0:d}\r\n", (short)SNNUMWRITE) ; 
                    }
                
                __context__.SourceCodeLine = 548;
                Functions.ClearBuffer ( G_SRVINEWFILETEMP__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 550;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( G_NDEBUG ) && Functions.TestForTrue ( Functions.BoolToInt ( SNNUMWRITE < 0 ) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 550;
                    Trace( "Error Writing to File\r\n") ; 
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 554;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 554;
                    Trace( "***** Error Entering if(snFileHandle >= 0) *****\r\n") ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 556;
            SNENDFILEIOERROR = (short) ( EndFileOperations() ) ; 
            __context__.SourceCodeLine = 557;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNENDFILEIOERROR != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 559;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 559;
                    Trace( "End File Operations Error Retrying\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 560;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 561;
                SNENDFILEIOERROR = (short) ( EndFileOperations() ) ; 
                __context__.SourceCodeLine = 557;
                } 
            
            __context__.SourceCodeLine = 564;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 564;
                Trace( "***** End WriteTempFile *****\r\n") ; 
                }
            
            
            }
            
        private CrestronString ADDNEWFILEDATA (  SplusExecutionContext __context__, CrestronString SCURRENTDATA__DOLLAR__ ) 
            { 
            
            __context__.SourceCodeLine = 569;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SRVINEWFILETEMP__DOLLAR__ != ""))  ) ) 
                { 
                __context__.SourceCodeLine = 571;
                MakeString ( G_SRVINEWFILETEMP__DOLLAR__ , "{0}{1}", G_SRVINEWFILETEMP__DOLLAR__ , SCURRENTDATA__DOLLAR__ ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 575;
                MakeString ( G_SRVINEWFILETEMP__DOLLAR__ , "{0}", SCURRENTDATA__DOLLAR__ ) ; 
                } 
            
            
            return ""; // default return value (none specified in module)
            }
            
        private CrestronString GETROOMNAME (  SplusExecutionContext __context__, ushort NCURRENTSYMBOLCOUNT , CrestronString SCURRENTDATA__DOLLAR__ ) 
            { 
            ushort NSTARTPOSITION = 0;
            ushort NENDPOSITION = 0;
            ushort NCOUNT = 0;
            
            CrestronString SROOMNAMERETURN__DOLLAR__;
            SROOMNAMERETURN__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            
            __context__.SourceCodeLine = 584;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCURRENTSYMBOLCOUNT <= 60 ))  ) ) 
                { 
                __context__.SourceCodeLine = 586;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SOVERRIDEROOMNAME__DOLLAR__[ NCURRENTSYMBOLCOUNT ] != ""))  ) ) 
                    { 
                    __context__.SourceCodeLine = 588;
                    MakeString ( SROOMNAMERETURN__DOLLAR__ , "{0}", G_SOVERRIDEROOMNAME__DOLLAR__ [ NCURRENTSYMBOLCOUNT ] ) ; 
                    __context__.SourceCodeLine = 589;
                    G_NRVIFILECHANGED = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 590;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 590;
                        Trace( "Line 451 g_nRVIFileChanged = {0:d}\r\n", (short)G_NRVIFILECHANGED) ; 
                        }
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 594;
                    NSTARTPOSITION = (ushort) ( (Functions.Find( "<RoomName>" , SCURRENTDATA__DOLLAR__ ) + Functions.Length( "<RoomName>" )) ) ; 
                    __context__.SourceCodeLine = 595;
                    NENDPOSITION = (ushort) ( Functions.Find( "</RoomName>" , SCURRENTDATA__DOLLAR__ , NSTARTPOSITION ) ) ; 
                    __context__.SourceCodeLine = 596;
                    NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOSITION) ) ; 
                    __context__.SourceCodeLine = 597;
                    MakeString ( SROOMNAMERETURN__DOLLAR__ , "{0}", Functions.Mid ( SCURRENTDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 602;
                NSTARTPOSITION = (ushort) ( (Functions.Find( "<RoomName>" , SCURRENTDATA__DOLLAR__ ) + Functions.Length( "<RoomName>" )) ) ; 
                __context__.SourceCodeLine = 603;
                NENDPOSITION = (ushort) ( Functions.Find( "</RoomName>" , SCURRENTDATA__DOLLAR__ , NSTARTPOSITION ) ) ; 
                __context__.SourceCodeLine = 604;
                NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOSITION) ) ; 
                __context__.SourceCodeLine = 605;
                MakeString ( SROOMNAMERETURN__DOLLAR__ , "{0}", Functions.Mid ( SCURRENTDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                } 
            
            __context__.SourceCodeLine = 608;
            return ( SROOMNAMERETURN__DOLLAR__ ) ; 
            
            }
            
        private CrestronString GETNODENAME (  SplusExecutionContext __context__, ushort NCURRENTSYMBOLCOUNT , CrestronString SCURRENTDATA__DOLLAR__ ) 
            { 
            ushort NSTARTPOSITION = 0;
            ushort NENDPOSITION = 0;
            ushort NCOUNT = 0;
            
            CrestronString SNODENAMERETURN__DOLLAR__;
            SNODENAMERETURN__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            
            __context__.SourceCodeLine = 616;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NCURRENTSYMBOLCOUNT <= 60 ))  ) ) 
                { 
                __context__.SourceCodeLine = 618;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SOVERRIDEROOMNAME__DOLLAR__[ NCURRENTSYMBOLCOUNT ] != ""))  ) ) 
                    { 
                    __context__.SourceCodeLine = 620;
                    MakeString ( SNODENAMERETURN__DOLLAR__ , "{0}", G_SOVERRIDEROOMNAME__DOLLAR__ [ NCURRENTSYMBOLCOUNT ] ) ; 
                    __context__.SourceCodeLine = 621;
                    G_NRVIFILECHANGED = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 622;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 622;
                        Trace( "Line 473 g_nRVIFileChanged = {0:d}\r\n", (short)G_NRVIFILECHANGED) ; 
                        }
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 626;
                    NSTARTPOSITION = (ushort) ( (Functions.Find( "<NodeName>" , SCURRENTDATA__DOLLAR__ ) + Functions.Length( "<NodeName>" )) ) ; 
                    __context__.SourceCodeLine = 627;
                    NENDPOSITION = (ushort) ( Functions.Find( "</NodeName>" , SCURRENTDATA__DOLLAR__ , NSTARTPOSITION ) ) ; 
                    __context__.SourceCodeLine = 628;
                    NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOSITION) ) ; 
                    __context__.SourceCodeLine = 629;
                    MakeString ( SNODENAMERETURN__DOLLAR__ , "{0}", Functions.Mid ( SCURRENTDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 634;
                NSTARTPOSITION = (ushort) ( (Functions.Find( "<NodeName>" , SCURRENTDATA__DOLLAR__ ) + Functions.Length( "<NodeName>" )) ) ; 
                __context__.SourceCodeLine = 635;
                NENDPOSITION = (ushort) ( Functions.Find( "</NodeName>" , SCURRENTDATA__DOLLAR__ , NSTARTPOSITION ) ) ; 
                __context__.SourceCodeLine = 636;
                NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOSITION) ) ; 
                __context__.SourceCodeLine = 637;
                MakeString ( SNODENAMERETURN__DOLLAR__ , "{0}", Functions.Mid ( SCURRENTDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                } 
            
            __context__.SourceCodeLine = 640;
            return ( SNODENAMERETURN__DOLLAR__ ) ; 
            
            }
            
        private CrestronString PARSERVIFILEDATA (  SplusExecutionContext __context__, CrestronString SRVITEMPFILEDATA__DOLLAR__ ) 
            { 
            ushort NSTARTPOSITION = 0;
            ushort NENDPOSITION = 0;
            ushort NCOUNT = 0;
            
            CrestronString STEMPDATA__DOLLAR__;
            CrestronString SRVITEMPNEWFILEDATA__DOLLAR__;
            CrestronString STEMPROOMNAME__DOLLAR__;
            CrestronString STEMPROOMNAMEDATA__DOLLAR__;
            CrestronString STEMPROOMGUID__DOLLAR__;
            CrestronString STEMPINSTANCEGUID__DOLLAR__;
            STEMPDATA__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            SRVITEMPNEWFILEDATA__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5500, this );
            STEMPROOMNAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            STEMPROOMNAMEDATA__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            STEMPROOMGUID__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            STEMPINSTANCEGUID__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
            
            
            __context__.SourceCodeLine = 650;
            NSTARTPOSITION = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 651;
            NENDPOSITION = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 652;
            NCOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 654;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Processing Data...") ; 
            __context__.SourceCodeLine = 656;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 656;
                Trace( "***** Start ParseRVIFile *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 658;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SRVITEMP__DOLLAR__ != ""))  ) ) 
                { 
                __context__.SourceCodeLine = 660;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 660;
                    Trace( "g_sRVITemp$ <> \u0022\u0022 = True\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 661;
                MakeString ( G_SRVITEMP__DOLLAR__ , "{0}{1}", G_SRVITEMP__DOLLAR__ , SRVITEMPFILEDATA__DOLLAR__ ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 665;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 665;
                    Trace( "g_sRVITemp$ <> \u0022\u0022 = False\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 666;
                MakeString ( G_SRVITEMP__DOLLAR__ , "{0}", SRVITEMPFILEDATA__DOLLAR__ ) ; 
                } 
            
            __context__.SourceCodeLine = 668;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 668;
                Trace( "len(g_sRVITemp$) = {0:d}\r\nlen(sRVITempFileData$) = {1:d}\r\n", (ushort)Functions.Length( G_SRVITEMP__DOLLAR__ ), (ushort)Functions.Length( SRVITEMPFILEDATA__DOLLAR__ )) ; 
                }
            
            __context__.SourceCodeLine = 670;
            while ( Functions.TestForTrue  ( ( Functions.Find( "\r\n" , G_SRVITEMP__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 672;
                STEMPDATA__DOLLAR__  .UpdateValue ( Functions.Remove ( "\r\n" , G_SRVITEMP__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 673;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "<SymbolInfo>" , STEMPDATA__DOLLAR__ ) ) || Functions.TestForTrue ( G_NFUSIONSYMBOLDATASTARTED )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 675;
                    G_NFUSIONSYMBOLDATASTARTED = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 676;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 676;
                        Trace( "sTempData$ = {0}\r\n", STEMPDATA__DOLLAR__ ) ; 
                        }
                    
                    __context__.SourceCodeLine = 677;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( Functions.Find( "</SymbolInfo>" , STEMPDATA__DOLLAR__ ) ) ) && Functions.TestForTrue ( Functions.Find( "\r\n" , STEMPDATA__DOLLAR__ ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 679;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "<RoomName>" , STEMPDATA__DOLLAR__ ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 681;
                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                {
                                __context__.SourceCodeLine = 681;
                                Trace( "**Room Name Segment***\r\n sTempData$ = {0}\r\n", STEMPDATA__DOLLAR__ ) ; 
                                }
                            
                            __context__.SourceCodeLine = 682;
                            MakeString ( STEMPROOMNAME__DOLLAR__ , "{0}", GETROOMNAME (  __context__ , (ushort)( G_NFUSIONSYMBOLCOUNT ), STEMPDATA__DOLLAR__) ) ; 
                            __context__.SourceCodeLine = 683;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_NFUSIONSYMBOLCOUNT <= 60 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 685;
                                MakeString ( SYMBOL_ROOM_NAME_TXT__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT] , "{0}", STEMPROOMNAME__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 687;
                            MakeString ( STEMPROOMNAMEDATA__DOLLAR__ , "          {0}{1}{2}\r\n", "<RoomName>" , STEMPROOMNAME__DOLLAR__ , "</RoomName>" ) ; 
                            __context__.SourceCodeLine = 688;
                            ADDNEWFILEDATA (  __context__ , STEMPROOMNAMEDATA__DOLLAR__) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 690;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "<NodeName>" , STEMPDATA__DOLLAR__ ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 692;
                                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                    {
                                    __context__.SourceCodeLine = 692;
                                    Trace( "**Node Name Segment***\r\n sTempData$ = {0}\r\n", STEMPDATA__DOLLAR__ ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 693;
                                MakeString ( STEMPROOMNAME__DOLLAR__ , "{0}", GETNODENAME (  __context__ , (ushort)( G_NFUSIONSYMBOLCOUNT ), STEMPDATA__DOLLAR__) ) ; 
                                __context__.SourceCodeLine = 694;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_NFUSIONSYMBOLCOUNT <= 60 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 696;
                                    MakeString ( SYMBOL_ROOM_NAME_TXT__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT] , "{0}", STEMPROOMNAME__DOLLAR__ ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 698;
                                MakeString ( STEMPROOMNAMEDATA__DOLLAR__ , "          {0}{1}{2}\r\n", "<NodeName>" , STEMPROOMNAME__DOLLAR__ , "</NodeName>" ) ; 
                                __context__.SourceCodeLine = 699;
                                ADDNEWFILEDATA (  __context__ , STEMPROOMNAMEDATA__DOLLAR__) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 701;
                                if ( Functions.TestForTrue  ( ( Functions.Find( "<InstanceID>" , STEMPDATA__DOLLAR__ ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 703;
                                    NSTARTPOSITION = (ushort) ( (Functions.Find( "<InstanceID>" , STEMPDATA__DOLLAR__ ) + Functions.Length( "<InstanceID>" )) ) ; 
                                    __context__.SourceCodeLine = 704;
                                    NENDPOSITION = (ushort) ( Functions.Find( "</InstanceID>" , STEMPDATA__DOLLAR__ , NSTARTPOSITION ) ) ; 
                                    __context__.SourceCodeLine = 705;
                                    NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOSITION) ) ; 
                                    __context__.SourceCodeLine = 706;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_NFUSIONSYMBOLCOUNT > 60 ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 708;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( G_SMASTERGUIDPREFIX__DOLLAR__ , STEMPDATA__DOLLAR__ ) ) || Functions.TestForTrue ( Functions.BoolToInt (PREFIXGUIDS  .Value == 0) )) ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 710;
                                            ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                                            } 
                                        
                                        else 
                                            { 
                                            __context__.SourceCodeLine = 714;
                                            G_NRVIFILECHANGED = (ushort) ( 1 ) ; 
                                            __context__.SourceCodeLine = 715;
                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                {
                                                __context__.SourceCodeLine = 715;
                                                Trace( "Line 715 g_nRVIFileChanged = {0:d}\r\n", (short)G_NRVIFILECHANGED) ; 
                                                }
                                            
                                            __context__.SourceCodeLine = 716;
                                            MakeString ( STEMPROOMGUID__DOLLAR__ , "          {0}{1}-{2}{3}\r\n", "<InstanceID>" , G_SMASTERGUIDPREFIX__DOLLAR__ , Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) , "</InstanceID>" ) ; 
                                            __context__.SourceCodeLine = 717;
                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                {
                                                __context__.SourceCodeLine = 717;
                                                Trace( "sTempRoomGUID$ = {0}\r\n", STEMPROOMGUID__DOLLAR__ ) ; 
                                                }
                                            
                                            __context__.SourceCodeLine = 718;
                                            ADDNEWFILEDATA (  __context__ , STEMPROOMGUID__DOLLAR__) ; 
                                            } 
                                        
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 721;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( G_SGUIDPREFIX__DOLLAR__[ G_NFUSIONSYMBOLCOUNT ] , STEMPDATA__DOLLAR__ ) ) || Functions.TestForTrue ( Functions.BoolToInt (PREFIXGUIDS  .Value == 0) )) ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 723;
                                            MakeString ( SYMBOL_GUID_TXT__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT] , "{0}", Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                                            __context__.SourceCodeLine = 724;
                                            ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                                            } 
                                        
                                        else 
                                            { 
                                            __context__.SourceCodeLine = 728;
                                            G_NRVIFILECHANGED = (ushort) ( 1 ) ; 
                                            __context__.SourceCodeLine = 729;
                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                {
                                                __context__.SourceCodeLine = 729;
                                                Trace( "Line 551 g_nRVIFileChanged = {0:d}\r\n", (short)G_NRVIFILECHANGED) ; 
                                                }
                                            
                                            __context__.SourceCodeLine = 730;
                                            MakeString ( STEMPROOMGUID__DOLLAR__ , "          {0}{1}-{2}{3}\r\n", "<InstanceID>" , G_SGUIDPREFIX__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT ] , Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) , "</InstanceID>" ) ; 
                                            __context__.SourceCodeLine = 731;
                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                {
                                                __context__.SourceCodeLine = 731;
                                                Trace( "sTempRoomGUID$ = {0}\r\n", STEMPROOMGUID__DOLLAR__ ) ; 
                                                }
                                            
                                            __context__.SourceCodeLine = 732;
                                            MakeString ( SYMBOL_GUID_TXT__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT] , "{0}-{1}", G_SGUIDPREFIX__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT ] , Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                                            __context__.SourceCodeLine = 733;
                                            ADDNEWFILEDATA (  __context__ , STEMPROOMGUID__DOLLAR__) ; 
                                            } 
                                        
                                        }
                                    
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 736;
                                    if ( Functions.TestForTrue  ( ( Functions.Find( "<IPID>" , STEMPDATA__DOLLAR__ ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 738;
                                        NSTARTPOSITION = (ushort) ( (Functions.Find( "<IPID>" , STEMPDATA__DOLLAR__ ) + Functions.Length( "<IPID>" )) ) ; 
                                        __context__.SourceCodeLine = 739;
                                        NENDPOSITION = (ushort) ( Functions.Find( "</IPID>" , STEMPDATA__DOLLAR__ , NSTARTPOSITION ) ) ; 
                                        __context__.SourceCodeLine = 740;
                                        NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOSITION) ) ; 
                                        __context__.SourceCodeLine = 741;
                                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                            {
                                            __context__.SourceCodeLine = 741;
                                            Trace( "**IP ID Segment***\r\n sTempData$ = {0}\r\n nStartPosition = {1:d}\r\n nEndPosition = {2:d}\r\n nCount = {3:d}\r\n", STEMPDATA__DOLLAR__ , (ushort)NSTARTPOSITION, (ushort)NENDPOSITION, (ushort)NCOUNT) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 742;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_NFUSIONSYMBOLCOUNT <= 60 ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 744;
                                            MakeString ( SYMBOL_IPID_TXT__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT] , "{0}", Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                                            } 
                                        
                                        __context__.SourceCodeLine = 746;
                                        ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 748;
                                        if ( Functions.TestForTrue  ( ( Functions.Find( "<SlotNum>" , STEMPDATA__DOLLAR__ ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 750;
                                            NSTARTPOSITION = (ushort) ( (Functions.Find( "<SlotNum>" , STEMPDATA__DOLLAR__ ) + Functions.Length( "<SlotNum>" )) ) ; 
                                            __context__.SourceCodeLine = 751;
                                            NENDPOSITION = (ushort) ( Functions.Find( "</SlotNum>" , STEMPDATA__DOLLAR__ , NSTARTPOSITION ) ) ; 
                                            __context__.SourceCodeLine = 752;
                                            NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOSITION) ) ; 
                                            __context__.SourceCodeLine = 753;
                                            G_NSLOTNUMBER = (ushort) ( Functions.Atoi( Functions.Mid( STEMPDATA__DOLLAR__ , (int)( NSTARTPOSITION ) , (int)( NCOUNT ) ) ) ) ; 
                                            __context__.SourceCodeLine = 754;
                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                {
                                                __context__.SourceCodeLine = 754;
                                                Trace( "**Slot Number Segment***\r\n sTempData$ = {0}\r\n nStartPosition = {1:d}\r\n nEndPosition = {2:d}\r\n nCount = {3:d}\r\n g_nSlotNumber = {4:d}\r\n", STEMPDATA__DOLLAR__ , (ushort)NSTARTPOSITION, (ushort)NENDPOSITION, (ushort)NCOUNT, (ushort)G_NSLOTNUMBER) ; 
                                                }
                                            
                                            __context__.SourceCodeLine = 755;
                                            ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 757;
                                            if ( Functions.TestForTrue  ( ( Functions.Find( "<Name>InstanceID</Name>" , STEMPDATA__DOLLAR__ ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 759;
                                                G_NINSTANCEIDFOUND = (ushort) ( 1 ) ; 
                                                __context__.SourceCodeLine = 760;
                                                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 760;
                                                    Trace( "***csParamSeachType Found***\r\n") ; 
                                                    }
                                                
                                                __context__.SourceCodeLine = 761;
                                                ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 763;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( G_NINSTANCEIDFOUND ) && Functions.TestForTrue ( Functions.Find( "<Value>" , STEMPDATA__DOLLAR__ ) )) ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 765;
                                                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 765;
                                                        Trace( "***else if(g_nInstanceIDFound && find(csParamGUIDStartofData, sTempData$)) Found***\r\n") ; 
                                                        }
                                                    
                                                    __context__.SourceCodeLine = 766;
                                                    NSTARTPOSITION = (ushort) ( (Functions.Find( "<Value>" , STEMPDATA__DOLLAR__ ) + Functions.Length( "<Value>" )) ) ; 
                                                    __context__.SourceCodeLine = 767;
                                                    NENDPOSITION = (ushort) ( Functions.Find( "</Value>" , STEMPDATA__DOLLAR__ , NSTARTPOSITION ) ) ; 
                                                    __context__.SourceCodeLine = 768;
                                                    NCOUNT = (ushort) ( (NENDPOSITION - NSTARTPOSITION) ) ; 
                                                    __context__.SourceCodeLine = 770;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_NFUSIONSYMBOLCOUNT <= 60 ))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 772;
                                                        G_NGUIDCOUNT [ G_NFUSIONSYMBOLCOUNT] = (ushort) ( (G_NGUIDCOUNT[ G_NFUSIONSYMBOLCOUNT ] + 1) ) ; 
                                                        } 
                                                    
                                                    __context__.SourceCodeLine = 775;
                                                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 775;
                                                        Trace( "g_nFusionSymbolCount = {0:d}\r\n", (ushort)G_NFUSIONSYMBOLCOUNT) ; 
                                                        }
                                                    
                                                    __context__.SourceCodeLine = 776;
                                                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 776;
                                                        Trace( "nSlotNumber = {0:d}\r\n", (ushort)G_NSLOTNUMBER) ; 
                                                        }
                                                    
                                                    __context__.SourceCodeLine = 778;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_NFUSIONSYMBOLCOUNT > 60 ))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 780;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( G_SMASTERGUIDPREFIX__DOLLAR__ , STEMPDATA__DOLLAR__ ) ) || Functions.TestForTrue ( Functions.BoolToInt (PREFIXGUIDS  .Value == 0) )) ))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 782;
                                                            ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                                                            } 
                                                        
                                                        else 
                                                            { 
                                                            __context__.SourceCodeLine = 786;
                                                            G_NRVIFILECHANGED = (ushort) ( 1 ) ; 
                                                            __context__.SourceCodeLine = 787;
                                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 787;
                                                                Trace( "Line 787 g_nRVIFileChanged = {0:d}\r\n", (short)G_NRVIFILECHANGED) ; 
                                                                }
                                                            
                                                            __context__.SourceCodeLine = 788;
                                                            MakeString ( STEMPINSTANCEGUID__DOLLAR__ , "                    {0}{1}-{2}{3}\r\n", "<Value>" , G_SMASTERGUIDPREFIX__DOLLAR__ , Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) , "</Value>" ) ; 
                                                            __context__.SourceCodeLine = 789;
                                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 789;
                                                                Trace( "sTempInstanceGUID$ = {0}\r\n", STEMPINSTANCEGUID__DOLLAR__ ) ; 
                                                                }
                                                            
                                                            __context__.SourceCodeLine = 790;
                                                            ADDNEWFILEDATA (  __context__ , STEMPROOMGUID__DOLLAR__) ; 
                                                            } 
                                                        
                                                        __context__.SourceCodeLine = 792;
                                                        G_NINSTANCEIDFOUND = (ushort) ( 0 ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 794;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( G_SGUIDPREFIX__DOLLAR__[ G_NFUSIONSYMBOLCOUNT ] , STEMPDATA__DOLLAR__ ) ) || Functions.TestForTrue ( Functions.BoolToInt (PREFIXGUIDS  .Value == 0) )) ))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 796;
                                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 796;
                                                                Trace( "***if(find(g_sGUIDPrefix$[g_nFusionSymbolCount], sTempData$)) Found***\r\n") ; 
                                                                }
                                                            
                                                            __context__.SourceCodeLine = 797;
                                                            MakeString ( SYMBOL_SLOT_GUIDS_TX__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT] , "{0:d},{1}\r\n", (ushort)G_NSLOTNUMBER, Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                                                            __context__.SourceCodeLine = 798;
                                                            ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                                                            } 
                                                        
                                                        else 
                                                            { 
                                                            __context__.SourceCodeLine = 802;
                                                            G_NRVIFILECHANGED = (ushort) ( 1 ) ; 
                                                            __context__.SourceCodeLine = 803;
                                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 803;
                                                                Trace( "Line 803 g_nRVIFileChanged = {0:d}\r\n", (short)G_NRVIFILECHANGED) ; 
                                                                }
                                                            
                                                            __context__.SourceCodeLine = 804;
                                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 804;
                                                                Trace( "***if(find(g_sGUIDPrefix$[g_nFusionSymbolCount], sTempData$)) ELSE Found***\r\n") ; 
                                                                }
                                                            
                                                            __context__.SourceCodeLine = 805;
                                                            MakeString ( STEMPINSTANCEGUID__DOLLAR__ , "                    {0}{1}-{2}{3}\r\n", "<Value>" , G_SGUIDPREFIX__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT ] , Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) , "</Value>" ) ; 
                                                            __context__.SourceCodeLine = 806;
                                                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 806;
                                                                Trace( "sTempInstanceGUID$ = {0}\r\n", STEMPINSTANCEGUID__DOLLAR__ ) ; 
                                                                }
                                                            
                                                            __context__.SourceCodeLine = 807;
                                                            MakeString ( SYMBOL_SLOT_GUIDS_TX__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT] , "{0:d},{1}-{2}\r\n", (ushort)G_NSLOTNUMBER, G_SGUIDPREFIX__DOLLAR__ [ G_NFUSIONSYMBOLCOUNT ] , Functions.Mid ( STEMPDATA__DOLLAR__ ,  (int) ( NSTARTPOSITION ) ,  (int) ( NCOUNT ) ) ) ; 
                                                            } 
                                                        
                                                        }
                                                    
                                                    __context__.SourceCodeLine = 809;
                                                    G_NINSTANCEIDFOUND = (ushort) ( 0 ) ; 
                                                    __context__.SourceCodeLine = 810;
                                                    ADDNEWFILEDATA (  __context__ , STEMPINSTANCEGUID__DOLLAR__) ; 
                                                    } 
                                                
                                                else 
                                                    { 
                                                    __context__.SourceCodeLine = 814;
                                                    ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                                                    } 
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 817;
                        STEMPDATA__DOLLAR__  .UpdateValue ( Functions.Remove ( "\r\n" , G_SRVITEMP__DOLLAR__ )  ) ; 
                        __context__.SourceCodeLine = 818;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 818;
                            Trace( "sTempData$ = {0}\r\n", STEMPDATA__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 677;
                        } 
                    
                    __context__.SourceCodeLine = 820;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "</SymbolInfo>" , STEMPDATA__DOLLAR__ ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 822;
                        ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                        __context__.SourceCodeLine = 823;
                        G_NFUSIONSYMBOLDATASTARTED = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 824;
                        G_NFUSIONSYMBOLCOUNT = (ushort) ( (G_NFUSIONSYMBOLCOUNT + 1) ) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 829;
                    ADDNEWFILEDATA (  __context__ , STEMPDATA__DOLLAR__) ; 
                    } 
                
                __context__.SourceCodeLine = 670;
                } 
            
            __context__.SourceCodeLine = 833;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PREFIXGUIDS  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 835;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 835;
                    Trace( "Inside if(PrefixGUIDs = cnTrue)\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 836;
                WRITETEMPFILE (  __context__  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 840;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 840;
                    Trace( "Inside ELSE if(PrefixGUIDs = cnTrue)\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 841;
                Functions.ClearBuffer ( G_SRVINEWFILETEMP__DOLLAR__ ) ; 
                } 
            
            __context__.SourceCodeLine = 843;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 843;
                Trace( "***** End ParseRVIFile *****\r\n") ; 
                }
            
            
            return ""; // default return value (none specified in module)
            }
            
        private void PROCESSRVIFILE (  SplusExecutionContext __context__, CrestronString SRVIFILE__DOLLAR__ ) 
            { 
            short SNFILEHANDLE = 0;
            short SNSTARTFILEIOERROR = 0;
            short SNREADERROR = 0;
            short SNFILECLOSEERROR = 0;
            short SNENDFILEIOERROR = 0;
            
            CrestronString SRVITEMPREADDATA__DOLLAR__;
            SRVITEMPREADDATA__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5500, this );
            
            
            __context__.SourceCodeLine = 851;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 851;
                Trace( "***** Start ProcessRVIFile *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 852;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Processing RVI File...") ; 
            __context__.SourceCodeLine = 854;
            SNSTARTFILEIOERROR = (short) ( StartFileOperations() ) ; 
            __context__.SourceCodeLine = 855;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNSTARTFILEIOERROR != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 857;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 857;
                    Trace( "Start File Operations Error Retrying\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 858;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 859;
                SNSTARTFILEIOERROR = (short) ( StartFileOperations() ) ; 
                __context__.SourceCodeLine = 855;
                } 
            
            __context__.SourceCodeLine = 861;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SRVIFILE__DOLLAR__ != ""))  ) ) 
                { 
                __context__.SourceCodeLine = 863;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 863;
                    Trace( "sRVIFile$ = {0}\r\n", SRVIFILE__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 865;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_6__ = ((int)Functions.GetSeries());
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 869;
                            SNFILEHANDLE = (short) ( FileOpen( SRVIFILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 873;
                            SNFILEHANDLE = (short) ( FileOpenShared( SRVIFILE__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                __context__.SourceCodeLine = 877;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    { 
                    __context__.SourceCodeLine = 879;
                    Trace( "FileOpen Complete\r\n") ; 
                    __context__.SourceCodeLine = 880;
                    Trace( "snFileHandle = {0:d}\r\n", (short)SNFILEHANDLE) ; 
                    } 
                
                __context__.SourceCodeLine = 883;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SNFILEHANDLE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 885;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FileRead( (short)( SNFILEHANDLE ) , SRVITEMPREADDATA__DOLLAR__ , (ushort)( 5000 ) ) > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 887;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 887;
                            Trace( "File Read Ok\r\n") ; 
                            }
                        
                        __context__.SourceCodeLine = 888;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 888;
                            Trace( "len(sRVITempReadData$) = {0:d}\r\n", (ushort)Functions.Length( SRVITEMPREADDATA__DOLLAR__ )) ; 
                            }
                        
                        __context__.SourceCodeLine = 889;
                        PARSERVIFILEDATA (  __context__ , SRVITEMPREADDATA__DOLLAR__) ; 
                        __context__.SourceCodeLine = 885;
                        } 
                    
                    __context__.SourceCodeLine = 891;
                    SNFILECLOSEERROR = (short) ( FileClose( (short)( SNFILEHANDLE ) ) ) ; 
                    __context__.SourceCodeLine = 892;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNFILECLOSEERROR != 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 894;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 894;
                            Trace( "File Close Error Retrying\r\n") ; 
                            }
                        
                        __context__.SourceCodeLine = 895;
                        Functions.Delay (  (int) ( 100 ) ) ; 
                        __context__.SourceCodeLine = 896;
                        SNFILECLOSEERROR = (short) ( FileClose( (short)( SNFILEHANDLE ) ) ) ; 
                        __context__.SourceCodeLine = 892;
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 901;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 901;
                        Trace( "snFileHandle Error\r\n") ; 
                        }
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 904;
            SNENDFILEIOERROR = (short) ( EndFileOperations() ) ; 
            __context__.SourceCodeLine = 905;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNENDFILEIOERROR != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 907;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 907;
                    Trace( "End File Operations Error Retrying\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 908;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 909;
                SNENDFILEIOERROR = (short) ( EndFileOperations() ) ; 
                __context__.SourceCodeLine = 905;
                } 
            
            __context__.SourceCodeLine = 912;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 912;
                Trace( "***** End ProcessRVIFile *****\r\n") ; 
                }
            
            
            }
            
        private void COPYANDDELETEFILES (  SplusExecutionContext __context__, ushort NDELETEMODE ) 
            { 
            CrestronString SCONSOLECOMMAND__DOLLAR__;
            CrestronString STEMPFILENAME__DOLLAR__;
            SCONSOLECOMMAND__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 300, this );
            STEMPFILENAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            short SNSTARTFILEIOERROR = 0;
            short SNENDFILEIOERROR = 0;
            
            
            __context__.SourceCodeLine = 921;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Connecting To Console...") ; 
            __context__.SourceCodeLine = 923;
            G_SNCONSOLECONNECTIONOK = (short) ( Functions.SocketConnectClient( TCPCONSOLE , "127.0.0.1" , (ushort)( 41795 ) , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 924;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 924;
                Trace( "g_snConsoleConnectionOk = {0:d}\r\n", (short)G_SNCONSOLECONNECTIONOK) ; 
                }
            
            __context__.SourceCodeLine = 926;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SNCONSOLECONNECTIONSTATUS != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 928;
                Functions.ProcessLogic ( ) ; 
                __context__.SourceCodeLine = 929;
                Functions.Delay (  (int) ( 200 ) ) ; 
                __context__.SourceCodeLine = 926;
                } 
            
            __context__.SourceCodeLine = 931;
            Functions.Delay (  (int) ( 1000 ) ) ; 
            __context__.SourceCodeLine = 933;
            MakeString ( SCONSOLECOMMAND__DOLLAR__ , "\r\n") ; 
            __context__.SourceCodeLine = 934;
            Functions.SocketSend ( TCPCONSOLE , SCONSOLECOMMAND__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 935;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 935;
                Trace( "Console Command 1 Sent\r\n") ; 
                }
            
            __context__.SourceCodeLine = 936;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 936;
                Trace( "sConsoleCommand$ = {0}\r\n", SCONSOLECOMMAND__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 937;
            Functions.Delay (  (int) ( 1000 ) ) ; 
            __context__.SourceCodeLine = 939;
            if ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 941;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 941;
                    Trace( "*** Full Delete Mode ***\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 942;
                MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Deleting Old RVI File...") ; 
                __context__.SourceCodeLine = 944;
                MakeString ( SCONSOLECOMMAND__DOLLAR__ , "del {0}{1}\r\n", G_SRVIFILELOCATION__DOLLAR__ , G_SRVIFILENAME__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 945;
                Functions.SocketSend ( TCPCONSOLE , SCONSOLECOMMAND__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 946;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 946;
                    Trace( "Console Command 2 Sent\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 947;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 947;
                    Trace( "sConsoleCommand$ = {0}\r\n", SCONSOLECOMMAND__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 948;
                Functions.Delay (  (int) ( 1000 ) ) ; 
                __context__.SourceCodeLine = 950;
                MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Copying New RVI File...") ; 
                __context__.SourceCodeLine = 952;
                MakeString ( SCONSOLECOMMAND__DOLLAR__ , "copy \u0022{0}{1}\u0022 \u0022{2}{3}\u0022\r\n", FILESTORAGELOCATION__DOLLAR__ , G_SRVIFILENAME__DOLLAR__ , G_SRVIFILELOCATION__DOLLAR__ , G_SRVIFILENAME__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 953;
                Functions.SocketSend ( TCPCONSOLE , SCONSOLECOMMAND__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 954;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 954;
                    Trace( "Console Command 3 Sent\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 955;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 955;
                    Trace( "sConsoleCommand$ = {0}\r\n", SCONSOLECOMMAND__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 956;
                Functions.Delay (  (int) ( 1000 ) ) ; 
                } 
            
            __context__.SourceCodeLine = 959;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Deleting Temp RVI File...") ; 
            __context__.SourceCodeLine = 961;
            SNSTARTFILEIOERROR = (short) ( StartFileOperations() ) ; 
            __context__.SourceCodeLine = 962;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNSTARTFILEIOERROR != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 964;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 964;
                    Trace( "Start File Operations Error Retrying\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 965;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 966;
                SNSTARTFILEIOERROR = (short) ( StartFileOperations() ) ; 
                __context__.SourceCodeLine = 962;
                } 
            
            __context__.SourceCodeLine = 969;
            MakeString ( STEMPFILENAME__DOLLAR__ , "{0}{1}", FILESTORAGELOCATION__DOLLAR__ , G_SRVIFILENAME__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 970;
            FileDelete ( STEMPFILENAME__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 972;
            SNENDFILEIOERROR = (short) ( EndFileOperations() ) ; 
            __context__.SourceCodeLine = 973;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (SNENDFILEIOERROR != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 975;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 975;
                    Trace( "End File Operations Error Retrying\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 976;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 977;
                SNENDFILEIOERROR = (short) ( EndFileOperations() ) ; 
                __context__.SourceCodeLine = 973;
                } 
            
            __context__.SourceCodeLine = 980;
            MakeString ( SCONSOLECOMMAND__DOLLAR__ , "del {0}{1}\r\n", FILESTORAGELOCATION__DOLLAR__ , G_SRVIFILENAME__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 981;
            Functions.SocketSend ( TCPCONSOLE , SCONSOLECOMMAND__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 982;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 982;
                Trace( "Console Command 4 Sent\r\n") ; 
                }
            
            __context__.SourceCodeLine = 983;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 983;
                Trace( "sConsoleCommand$ = {0}\r\n", SCONSOLECOMMAND__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 984;
            Functions.Delay (  (int) ( 1000 ) ) ; 
            __context__.SourceCodeLine = 986;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Disconnecting Console...") ; 
            __context__.SourceCodeLine = 988;
            MakeString ( SCONSOLECOMMAND__DOLLAR__ , "bye\r\n") ; 
            __context__.SourceCodeLine = 989;
            Functions.SocketSend ( TCPCONSOLE , SCONSOLECOMMAND__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 990;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 990;
                Trace( "Console Command 5 Sent\r\n") ; 
                }
            
            __context__.SourceCodeLine = 991;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 991;
                Trace( "sConsoleCommand$ = {0}\r\n", SCONSOLECOMMAND__DOLLAR__ ) ; 
                }
            
            
            }
            
        private void CLEAR_OUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            ushort NLOOPI = 0;
            
            
            __context__.SourceCodeLine = 998;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Clearing Current Data...") ; 
            __context__.SourceCodeLine = 1000;
            if ( Functions.TestForTrue  ( ( Functions.Not( G_NMASTERGUIDOVERRIDE ))  ) ) 
                { 
                __context__.SourceCodeLine = 1002;
                MakeString ( MASTER_GUID_PREFIX_TXT__DOLLAR__ , "") ; 
                } 
            
            __context__.SourceCodeLine = 1004;
            MakeString ( RVI_FILE_NAME_TXT__DOLLAR__ , "") ; 
            __context__.SourceCodeLine = 1005;
            MakeString ( RVI_FILE_FULL_PATH_TXT__DOLLAR__ , "") ; 
            __context__.SourceCodeLine = 1007;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)60; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( NLOOPI  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NLOOPI  >= __FN_FORSTART_VAL__1) && (NLOOPI  <= __FN_FOREND_VAL__1) ) : ( (NLOOPI  <= __FN_FORSTART_VAL__1) && (NLOOPI  >= __FN_FOREND_VAL__1) ) ; NLOOPI  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1009;
                MakeString ( SYMBOL_ROOM_NAME_TXT__DOLLAR__ [ NLOOPI] , "") ; 
                __context__.SourceCodeLine = 1010;
                MakeString ( SYMBOL_GUID_TXT__DOLLAR__ [ NLOOPI] , "") ; 
                __context__.SourceCodeLine = 1011;
                MakeString ( SYMBOL_IPID_TXT__DOLLAR__ [ NLOOPI] , "") ; 
                __context__.SourceCodeLine = 1012;
                MakeString ( SYMBOL_GUID_COUNT_TXT__DOLLAR__ [ NLOOPI] , "") ; 
                __context__.SourceCodeLine = 1013;
                SYMBOL_GUID_COUNT_FB [ NLOOPI]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1014;
                G_NGUIDCOUNT [ NLOOPI] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1007;
                } 
            
            
            }
            
        private void UPDATEGUIDCOUNTS (  SplusExecutionContext __context__ ) 
            { 
            ushort NLOOPJ = 0;
            
            
            __context__.SourceCodeLine = 1022;
            MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Updating GUID Counts...") ; 
            __context__.SourceCodeLine = 1024;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)60; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( NLOOPJ  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NLOOPJ  >= __FN_FORSTART_VAL__1) && (NLOOPJ  <= __FN_FOREND_VAL__1) ) : ( (NLOOPJ  <= __FN_FORSTART_VAL__1) && (NLOOPJ  >= __FN_FOREND_VAL__1) ) ; NLOOPJ  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1026;
                MakeString ( SYMBOL_GUID_COUNT_TXT__DOLLAR__ [ NLOOPJ] , "{0:d}", (ushort)G_NGUIDCOUNT[ NLOOPJ ]) ; 
                __context__.SourceCodeLine = 1027;
                SYMBOL_GUID_COUNT_FB [ NLOOPJ]  .Value = (ushort) ( G_NGUIDCOUNT[ NLOOPJ ] ) ; 
                __context__.SourceCodeLine = 1024;
                } 
            
            
            }
            
        private void UPDATE_GUIDS (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SRVIFILENAME__DOLLAR__;
            SRVIFILENAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
            
            
            __context__.SourceCodeLine = 1035;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( UPDATE_GUIDS_BUSY_FB  .Value ) ) || Functions.TestForTrue ( G_NINITIALRUN )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1037;
                UPDATE_GUIDS_BUSY_FB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1038;
                G_NINITIALRUN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1039;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1039;
                    Trace( "Inside if(!Update_GUIDs_Busy_fb || g_nInitialRun)\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 1040;
                MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "GUID Update Started...") ; 
                __context__.SourceCodeLine = 1041;
                CLEAR_OUTPUTS (  __context__  ) ; 
                __context__.SourceCodeLine = 1042;
                G_NCONSOLESTEP = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1043;
                G_NTSIDUPDATEBUSY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1044;
                MakeString ( CONSOLE_TX__DOLLAR__ , "{0}", "ver\r\n" ) ; 
                __context__.SourceCodeLine = 1045;
                while ( Functions.TestForTrue  ( ( G_NTSIDUPDATEBUSY)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1047;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 1047;
                        Trace( "Inside while(g_nTSIDUpdateBusy)\r\n") ; 
                        }
                    
                    __context__.SourceCodeLine = 1048;
                    Functions.ProcessLogic ( ) ; 
                    __context__.SourceCodeLine = 1049;
                    Functions.Delay (  (int) ( 200 ) ) ; 
                    __context__.SourceCodeLine = 1045;
                    } 
                
                __context__.SourceCodeLine = 1051;
                G_NFUSIONDATASTARTED = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1052;
                G_NFUSIONSYMBOLDATASTARTED = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1053;
                G_NFUSIONSYMBOLCOUNT = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1054;
                Functions.ClearBuffer ( G_SRVITEMP__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 1055;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1055;
                    Trace( "g_sRVITemp$ = {0}\r\n", G_SRVITEMP__DOLLAR__ ) ; 
                    }
                
                __context__.SourceCodeLine = 1056;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1056;
                    Trace( "len(g_sRVITemp$) = {0:d}\r\n", (short)Functions.Length( G_SRVITEMP__DOLLAR__ )) ; 
                    }
                
                __context__.SourceCodeLine = 1058;
                MakeString ( SRVIFILENAME__DOLLAR__ , "{0}", FINDRVIFILE (  __context__  ) ) ; 
                __context__.SourceCodeLine = 1060;
                if ( Functions.TestForTrue  ( ( Functions.Find( "XXXXXXXX" , G_SGUIDPREFIX__DOLLAR__[ G_NFUSIONSYMBOLCOUNT ] ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1062;
                    MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "TSID Error...") ; 
                    __context__.SourceCodeLine = 1063;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 1063;
                        Trace( "TSID Error\r\n") ; 
                        }
                    
                    __context__.SourceCodeLine = 1064;
                    Functions.Delay (  (int) ( 500 ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1068;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SRVIFILENAME__DOLLAR__ != "FileFoundError"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1070;
                        MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "RVI File Found Processing File...") ; 
                        __context__.SourceCodeLine = 1071;
                        MakeString ( G_SRVIFULLFILEPATH__DOLLAR__ , "{0}{1}", G_SRVIFILELOCATION__DOLLAR__ , SRVIFILENAME__DOLLAR__ ) ; 
                        __context__.SourceCodeLine = 1072;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 1072;
                            Trace( "Inside if(sRVIFileName$ != csRVIFileSearchError)\r\ng_sRVIFullFilePath$ = {0}\r\n", G_SRVIFULLFILEPATH__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 1073;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_NDEBUG == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1075;
                            
                                {
                                int __SPLS_TMPVAR__SWTCH_7__ = ((int)Functions.GetSeries());
                                
                                    { 
                                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 2) ) ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1079;
                                        PROCESSRVIFILE (  __context__ , "\\SIMPL\\Fusion GUID Updater Simple Test Pro2 10-21-2013 rev3.rvi") ; 
                                        } 
                                    
                                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_7__ == ( 3) ) ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1083;
                                        PROCESSRVIFILE (  __context__ , "\\SIMPL\\App01\\ADG-PV-Room_230-140310.rvi") ; 
                                        } 
                                    
                                    } 
                                    
                                }
                                
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 1089;
                            PROCESSRVIFILE (  __context__ , G_SRVIFULLFILEPATH__DOLLAR__) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1092;
                        UPDATEGUIDCOUNTS (  __context__  ) ; 
                        __context__.SourceCodeLine = 1093;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( G_NRVIFILECHANGED ) && Functions.TestForTrue ( Functions.BoolToInt (PREFIXGUIDS  .Value == 1) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1095;
                            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                {
                                __context__.SourceCodeLine = 1095;
                                Trace( "Inside if(g_nRVIFileChanged && PrefixGUIDs = cnTrue)\r\n") ; 
                                }
                            
                            __context__.SourceCodeLine = 1096;
                            COPYANDDELETEFILES (  __context__ , (ushort)( 1 )) ; 
                            __context__.SourceCodeLine = 1097;
                            G_NRVIFILECHANGED = (ushort) ( 0 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1099;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PREFIXGUIDS  .Value == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1101;
                                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1101;
                                    Trace( "Inside ELSE if(PrefixGUIDs = cnTrue)\r\n") ; 
                                    }
                                
                                __context__.SourceCodeLine = 1102;
                                COPYANDDELETEFILES (  __context__ , (ushort)( 2 )) ; 
                                __context__.SourceCodeLine = 1103;
                                G_NRVIFILECHANGED = (ushort) ( 0 ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 1107;
                                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                                    {
                                    __context__.SourceCodeLine = 1107;
                                    Trace( "Inside ELSE if(g_nRVIFileChanged && PrefixGUIDs = cnTrue)\r\n") ; 
                                    }
                                
                                __context__.SourceCodeLine = 1108;
                                G_NRVIFILECHANGED = (ushort) ( 0 ) ; 
                                } 
                            
                            }
                        
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 1113;
                        MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "RVI File Error...") ; 
                        __context__.SourceCodeLine = 1114;
                        Functions.Delay (  (int) ( 500 ) ) ; 
                        __context__.SourceCodeLine = 1115;
                        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                            {
                            __context__.SourceCodeLine = 1115;
                            Trace( "FindRVIFile Error\r\n") ; 
                            }
                        
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 1118;
                MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "GUID Update Complete!") ; 
                __context__.SourceCodeLine = 1119;
                GenerateUserNotice ( "Fusion GUID Updater Completed on {0} at {1}\r\n", Functions.Date (  (int) ( 1 ) ) , Functions.Time ( ) ) ; 
                __context__.SourceCodeLine = 1120;
                UPDATE_GUIDS_BUSY_FB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1121;
                Functions.Delay (  (int) ( 500 ) ) ; 
                __context__.SourceCodeLine = 1122;
                MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "") ; 
                } 
            
            
            }
            
        private void CHECK_ROOMNAMES (  SplusExecutionContext __context__ ) 
            { 
            ushort NINDEX = 0;
            
            
            __context__.SourceCodeLine = 1130;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 1130;
                Trace( "***** Function Check_Roomnames *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 1132;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)60; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( NINDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NINDEX  >= __FN_FORSTART_VAL__1) && (NINDEX  <= __FN_FOREND_VAL__1) ) : ( (NINDEX  <= __FN_FORSTART_VAL__1) && (NINDEX  >= __FN_FOREND_VAL__1) ) ; NINDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 1134;
                if ( Functions.TestForTrue  ( ( G_NROOMNAMEUPDATED[ NINDEX ])  ) ) 
                    { 
                    __context__.SourceCodeLine = 1136;
                    MakeString ( G_SOVERRIDEROOMNAME__DOLLAR__ [ NINDEX ] , "{0}", OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__ [ NINDEX ] ) ; 
                    __context__.SourceCodeLine = 1137;
                    G_NROOMNAMEUPDATED [ NINDEX] = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 1132;
                } 
            
            
            }
            
        object UPDATE_GUIDS_B_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 1147;
                UPDATE_GUIDS (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object MASTER_OVERRIDE_GUID_PREFIX__DOLLAR___OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort NLOOP = 0;
            
            CrestronString STEMPNEWGUID__DOLLAR__;
            STEMPNEWGUID__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            
            __context__.SourceCodeLine = 1173;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 1173;
                Trace( "***** Change Master_Override_GUID_Prefix$ *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 1174;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MASTER_OVERRIDE_GUID_PREFIX__DOLLAR__ != ""))  ) ) 
                { 
                __context__.SourceCodeLine = 1176;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1176;
                    Trace( "***** Inside if(Master_Override_GUID_Prefix$ <> \u0022\u0022) *****\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 1177;
                G_NMASTERGUIDOVERRIDE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1178;
                Functions.SetArray (  ref G_NGUIDOVERRIDE , (ushort)1) ; 
                __context__.SourceCodeLine = 1179;
                MakeString ( G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__ , "{0}", MASTER_OVERRIDE_GUID_PREFIX__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 1180;
                MakeString ( STEMPNEWGUID__DOLLAR__ , "{0}", UPDATEGUIDPREFIX (  __context__ , G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__, (ushort)( 1000 )) ) ; 
                __context__.SourceCodeLine = 1181;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)60; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( NLOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NLOOP  >= __FN_FORSTART_VAL__1) && (NLOOP  <= __FN_FOREND_VAL__1) ) : ( (NLOOP  <= __FN_FORSTART_VAL__1) && (NLOOP  >= __FN_FOREND_VAL__1) ) ; NLOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 1183;
                    MakeString ( G_SGUIDPREFIX__DOLLAR__ [ NLOOP ] , "{0}", STEMPNEWGUID__DOLLAR__ ) ; 
                    __context__.SourceCodeLine = 1181;
                    } 
                
                __context__.SourceCodeLine = 1186;
                MakeString ( G_SMASTERGUIDPREFIX__DOLLAR__ , "{0}", STEMPNEWGUID__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 1187;
                MakeString ( MASTER_GUID_PREFIX_TXT__DOLLAR__ , "{0}", STEMPNEWGUID__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 1188;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1188;
                    Trace( "sTempNewGUID$ = {0}\r\n", STEMPNEWGUID__DOLLAR__ ) ; 
                    }
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 1192;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1192;
                    Trace( "***** Inside ELSE for if(Master_Override_GUID_Prefix$ <> \u0022\u0022) *****\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 1193;
                G_NMASTERGUIDOVERRIDE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1194;
                Functions.SetArray (  ref G_NGUIDOVERRIDE , (ushort)0) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR___OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort NLASTCHANGED = 0;
        
        
        __context__.SourceCodeLine = 1203;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1203;
            Trace( "***** Change Override_Symbol_GUID_Prefix$ *****\r\n") ; 
            }
        
        __context__.SourceCodeLine = 1205;
        NLASTCHANGED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1206;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1206;
            Trace( "nLastChanged = {0:d}\r\n", (ushort)NLASTCHANGED) ; 
            }
        
        __context__.SourceCodeLine = 1208;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR__[ NLASTCHANGED ] != "") ) && Functions.TestForTrue ( Functions.Not( G_NMASTERGUIDOVERRIDE ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1210;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 1210;
                Trace( "***** Inside if(Override_Symbol_GUID_Prefix$[nLastChanged] <> \u0022\u0022 && !g_nMasterGUIDOverride) *****\r\n") ; 
                }
            
            __context__.SourceCodeLine = 1211;
            G_NGUIDOVERRIDE [ NLASTCHANGED] = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1212;
            MakeString ( G_SGUIDPREFIX__DOLLAR__ [ NLASTCHANGED ] , "{0}", OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR__ [ NLASTCHANGED ] ) ; 
            __context__.SourceCodeLine = 1213;
            MakeString ( G_SGUIDPREFIX__DOLLAR__ [ NLASTCHANGED ] , "{0}", UPDATEGUIDPREFIX (  __context__ , G_SGUIDPREFIX__DOLLAR__[ NLASTCHANGED ], (ushort)( NLASTCHANGED )) ) ; 
            __context__.SourceCodeLine = 1214;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 1214;
                Trace( "g_sGUIDPrefix$[nLastChanged] = {0}\r\n", G_SGUIDPREFIX__DOLLAR__ [ NLASTCHANGED ] ) ; 
                }
            
            } 
        
        __context__.SourceCodeLine = 1216;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1216;
            Trace( "g_sGUIDPrefix$[nLastChanged] = {0}\r\ng_nGUIDOverride[nLastChanged] = {1:d}\r\n", G_SGUIDPREFIX__DOLLAR__ [ NLASTCHANGED ] , (short)G_NGUIDOVERRIDE[ NLASTCHANGED ]) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONSOLE_RX__DOLLAR___OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort NTSIDSTARTPOS = 0;
        ushort NTSIDENDPOS = 0;
        ushort NTSIDCOUNT = 0;
        ushort NLOOP = 0;
        
        CrestronString SCONSOLESEARCHTEMP__DOLLAR__;
        CrestronString STEMPTSID__DOLLAR__;
        SCONSOLESEARCHTEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        STEMPTSID__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
        
        
        __context__.SourceCodeLine = 1224;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1224;
            Trace( "***** Start Console_rx$ *****\r\n") ; 
            }
        
        __context__.SourceCodeLine = 1226;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( G_NCONSOLESTEP > 0 ) ) && Functions.TestForTrue ( Functions.Find( ">" , CONSOLE_RX__DOLLAR__ ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( G_NTSIDRETRYCOUNT <= 5 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1228;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "#" , CONSOLE_RX__DOLLAR__ ) ) && Functions.TestForTrue ( Functions.Find( "]" , CONSOLE_RX__DOLLAR__ ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (G_NCONSOLESTEP == 1) )) ) ) && Functions.TestForTrue ( Functions.Not( G_NMASTERGUIDOVERRIDE ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1230;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1230;
                    Trace( "***** Inside Console If for TSID *****\r\n") ; 
                    }
                
                __context__.SourceCodeLine = 1231;
                NTSIDSTARTPOS = (ushort) ( (Functions.Find( "#" , CONSOLE_RX__DOLLAR__ ) + 1) ) ; 
                __context__.SourceCodeLine = 1232;
                NTSIDENDPOS = (ushort) ( Functions.Find( "]" , CONSOLE_RX__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 1233;
                NTSIDCOUNT = (ushort) ( (NTSIDENDPOS - NTSIDSTARTPOS) ) ; 
                __context__.SourceCodeLine = 1234;
                MakeString ( STEMPTSID__DOLLAR__ , "{0}", Functions.Lower ( Functions.Mid ( CONSOLE_RX__DOLLAR__ ,  (int) ( NTSIDSTARTPOS ) ,  (int) ( NTSIDCOUNT ) ) ) ) ; 
                __context__.SourceCodeLine = 1235;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1237;
                    Trace( "nTSIDStartPOS = {0:d}\r\n", (short)NTSIDSTARTPOS) ; 
                    __context__.SourceCodeLine = 1238;
                    Trace( "nTSIDEndPOS = {0:d}\r\n", (short)NTSIDENDPOS) ; 
                    __context__.SourceCodeLine = 1239;
                    Trace( "nTSIDCount = {0:d}\r\n", (short)NTSIDCOUNT) ; 
                    __context__.SourceCodeLine = 1240;
                    Trace( "sTempTSID$ = {0}\r\n", STEMPTSID__DOLLAR__ ) ; 
                    } 
                
                __context__.SourceCodeLine = 1242;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMPTSID__DOLLAR__ ) < 8 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1244;
                    Functions.ClearBuffer ( CONSOLE_RX__DOLLAR__ ) ; 
                    __context__.SourceCodeLine = 1245;
                    G_NTSIDRETRYCOUNT = (ushort) ( (G_NTSIDRETRYCOUNT + 1) ) ; 
                    __context__.SourceCodeLine = 1246;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 1246;
                        Trace( "TSID Error, Retrying TSID, Retry Count: {0:d}\r\n", (short)G_NTSIDRETRYCOUNT) ; 
                        }
                    
                    __context__.SourceCodeLine = 1247;
                    MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "Invalid TSID Received, Retrying... Retry Count: {0:d}", (short)G_NTSIDRETRYCOUNT) ; 
                    __context__.SourceCodeLine = 1248;
                    G_NCONSOLESTEP = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1249;
                    MakeString ( CONSOLE_TX__DOLLAR__ , "{0}", "ver\r\n" ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1254;
                    G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__  .UpdateValue ( UPDATEGUIDPREFIX (  __context__ , STEMPTSID__DOLLAR__, (ushort)( 1001 ))  ) ; 
                    __context__.SourceCodeLine = 1255;
                    MakeString ( MASTER_GUID_PREFIX_TXT__DOLLAR__ , "{0}", G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__ ) ; 
                    __context__.SourceCodeLine = 1256;
                    MakeString ( G_SMASTERGUIDPREFIX__DOLLAR__ , "{0}", G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__ ) ; 
                    __context__.SourceCodeLine = 1257;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 1257;
                        Trace( "g_sGUIDMasterOverridePrefix$ = {0}\r\n", G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__ ) ; 
                        }
                    
                    __context__.SourceCodeLine = 1258;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)60; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( NLOOP  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NLOOP  >= __FN_FORSTART_VAL__1) && (NLOOP  <= __FN_FOREND_VAL__1) ) : ( (NLOOP  <= __FN_FORSTART_VAL__1) && (NLOOP  >= __FN_FOREND_VAL__1) ) ; NLOOP  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1260;
                        if ( Functions.TestForTrue  ( ( Functions.Not( G_NGUIDOVERRIDE[ NLOOP ] ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1262;
                            MakeString ( G_SGUIDPREFIX__DOLLAR__ [ NLOOP ] , "{0}", G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__ ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 1258;
                        } 
                    
                    __context__.SourceCodeLine = 1265;
                    Functions.ClearBuffer ( CONSOLE_RX__DOLLAR__ ) ; 
                    __context__.SourceCodeLine = 1266;
                    G_NCONSOLESTEP = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1267;
                    G_NTSIDRETRYCOUNT = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1268;
                    G_NTSIDUPDATEBUSY = (ushort) ( 0 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1271;
                if ( Functions.TestForTrue  ( ( G_NMASTERGUIDOVERRIDE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1273;
                    if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                        {
                        __context__.SourceCodeLine = 1273;
                        Trace( "Inside else if(g_nGUIDOverride)\r\n") ; 
                        }
                    
                    __context__.SourceCodeLine = 1274;
                    Functions.ClearBuffer ( CONSOLE_RX__DOLLAR__ ) ; 
                    __context__.SourceCodeLine = 1275;
                    G_NCONSOLESTEP = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1276;
                    G_NTSIDRETRYCOUNT = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 1277;
                    G_NTSIDUPDATEBUSY = (ushort) ( 0 ) ; 
                    } 
                
                }
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1280;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_NTSIDRETRYCOUNT > 5 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1282;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1282;
                    Trace( "TSID Error, Max Retries Reached, Stopping Process") ; 
                    }
                
                __context__.SourceCodeLine = 1283;
                MakeString ( UPDATE_GUID_STATUS_TXT__DOLLAR__ , "TSID Error, Max Retries Reached, Stopping Process") ; 
                __context__.SourceCodeLine = 1284;
                MakeString ( G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__ , "{0}", UPDATEGUIDPREFIX (  __context__ , "XXXXXXXX", (ushort)( 1001 )) ) ; 
                __context__.SourceCodeLine = 1285;
                MakeString ( MASTER_GUID_PREFIX_TXT__DOLLAR__ , "{0}", G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 1286;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)60; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( NLOOP  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (NLOOP  >= __FN_FORSTART_VAL__2) && (NLOOP  <= __FN_FOREND_VAL__2) ) : ( (NLOOP  <= __FN_FORSTART_VAL__2) && (NLOOP  >= __FN_FOREND_VAL__2) ) ; NLOOP  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 1288;
                    if ( Functions.TestForTrue  ( ( Functions.Not( G_NGUIDOVERRIDE[ NLOOP ] ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1290;
                        MakeString ( G_SGUIDPREFIX__DOLLAR__ [ NLOOP ] , "{0}", G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__ ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1286;
                    } 
                
                __context__.SourceCodeLine = 1293;
                G_NTSIDUPDATEBUSY = (ushort) ( 0 ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1295;
                if ( Functions.TestForTrue  ( ( Functions.Find( ">" , CONSOLE_RX__DOLLAR__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1297;
                    Functions.ClearBuffer ( CONSOLE_RX__DOLLAR__ ) ; 
                    } 
                
                }
            
            }
        
        __context__.SourceCodeLine = 1300;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1300;
            Trace( "***** End Console_rx$ *****\r\n") ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort NLASTROOMNAMECHANGED = 0;
        
        
        __context__.SourceCodeLine = 1307;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1307;
            Trace( "***** Change Override_Symbol_Room_Name$ *****\r\n") ; 
            }
        
        __context__.SourceCodeLine = 1309;
        NLASTROOMNAMECHANGED = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1311;
        G_NROOMNAMEUPDATED [ NLASTROOMNAMECHANGED] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1313;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1313;
            Trace( "nLastRoomNameChanged = {0:d}\r\n", (ushort)NLASTROOMNAMECHANGED) ; 
            }
        
        __context__.SourceCodeLine = 1314;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1314;
            Trace( "Override_Symbol_Room_Name$[nLastRoomNameChanged] = {0}\r\n", OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__ [ NLASTROOMNAMECHANGED ] ) ; 
            }
        
        __context__.SourceCodeLine = 1317;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__[ NLASTROOMNAMECHANGED ] != "") ) && Functions.TestForTrue ( G_NROOMNAMEOVERRIDEALLOWED )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1319;
            MakeString ( G_SOVERRIDEROOMNAME__DOLLAR__ [ NLASTROOMNAMECHANGED ] , "{0}", OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__ [ NLASTROOMNAMECHANGED ] ) ; 
            __context__.SourceCodeLine = 1320;
            G_NROOMNAMEUPDATED [ NLASTROOMNAMECHANGED] = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1321;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 1321;
                Trace( "g_sOverrideRoomName$[nLastRoomNameChanged] = {0}\r\n", G_SOVERRIDEROOMNAME__DOLLAR__ [ NLASTROOMNAMECHANGED ] ) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TCPCONSOLE_OnSocketConnect_5 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        short SNERR = 0;
        
        
        __context__.SourceCodeLine = 1329;
        Functions.Delay (  (int) ( 200 ) ) ; 
        __context__.SourceCodeLine = 1331;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SNCONSOLECONNECTIONOK == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 1333;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                {
                __context__.SourceCodeLine = 1333;
                Trace( "Console Socket Connection Ok\r\n") ; 
                }
            
            __context__.SourceCodeLine = 1334;
            SNERR = (short) ( Functions.SocketSend( TCPCONSOLE , "\r\n" ) ) ; 
            __context__.SourceCodeLine = 1335;
            Functions.Delay (  (int) ( 1000 ) ) ; 
            __context__.SourceCodeLine = 1336;
            SNERR = (short) ( Functions.SocketSend( TCPCONSOLE , "\r\n" ) ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 1338;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_SNCONSOLECONNECTIONOK != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 1340;
                if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                    {
                    __context__.SourceCodeLine = 1340;
                    Trace( "Console Socket Connection Error\r\n") ; 
                    }
                
                } 
            
            }
        
        __context__.SourceCodeLine = 1343;
        Functions.Delay (  (int) ( 200 ) ) ; 
        __context__.SourceCodeLine = 1345;
        G_SNCONSOLECONNECTIONSTATUS = (short) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object TCPCONSOLE_OnSocketDisconnect_6 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        
        __context__.SourceCodeLine = 1350;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1350;
            Trace( "***** Start socketdisconnect tcpConsole *****\r\n") ; 
            }
        
        __context__.SourceCodeLine = 1351;
        Functions.ClearBuffer ( TCPCONSOLE .  SocketRxBuf ) ; 
        __context__.SourceCodeLine = 1352;
        G_SNCONSOLECONNECTIONSTATUS = (short) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

object TCPCONSOLE_OnSocketReceive_7 ( Object __Info__ )

    { 
    SocketEventInfo __SocketInfo__ = (SocketEventInfo)__Info__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SocketInfo__);
        ushort I = 0;
        
        CrestronString SGARBAGE__DOLLAR__;
        CrestronString STEMP__DOLLAR__;
        SGARBAGE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
        STEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1000, this );
        
        
        __context__.SourceCodeLine = 1360;
        if ( Functions.TestForTrue  ( ( Functions.Not( G_NSEMAPHORE ))  ) ) 
            { 
            __context__.SourceCodeLine = 1362;
            G_NSEMAPHORE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1364;
            STEMP__DOLLAR__  .UpdateValue ( TCPCONSOLE .  SocketRxBuf  ) ; 
            __context__.SourceCodeLine = 1366;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP__DOLLAR__ ) < 200 ))  ) ) 
                { 
                __context__.SourceCodeLine = 1368;
                MakeString ( CONSOLE_STATUS_TXT__DOLLAR__ , "{0}", STEMP__DOLLAR__ ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 1370;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP__DOLLAR__ ) >= 200 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1372;
                    MakeString ( CONSOLE_STATUS_TXT__DOLLAR__ , "{0}", Functions.Left ( STEMP__DOLLAR__ ,  (int) ( 200 ) ) ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 1374;
            Functions.ClearBuffer ( TCPCONSOLE .  SocketRxBuf ) ; 
            __context__.SourceCodeLine = 1376;
            if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
                { 
                __context__.SourceCodeLine = 1378;
                Trace( "***** Start Console Socket Receive *****\r\n") ; 
                __context__.SourceCodeLine = 1379;
                Trace( "tcpConsole.SocketRxBuf = {0}\r\n", TCPCONSOLE .  SocketRxBuf ) ; 
                __context__.SourceCodeLine = 1380;
                Trace( "sTemp$ = {0}\r\n", STEMP__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 1381;
                Trace( "Length tcpConsole.SocketRxBuf = {0:d}\r\n", (short)Functions.Length( TCPCONSOLE.SocketRxBuf )) ; 
                __context__.SourceCodeLine = 1382;
                Trace( "Length sTemp$ = {0:d}\r\n", (short)Functions.Length( STEMP__DOLLAR__ )) ; 
                __context__.SourceCodeLine = 1387;
                Trace( "*** End Console Socket Receive ***\r\n") ; 
                } 
            
            __context__.SourceCodeLine = 1389;
            G_NSEMAPHORE = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SocketInfo__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort NCOUNT = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 1400;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1402;
        G_NDEBUG = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1403;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1403;
            Trace( "***** Start Function Main *****\r\n") ; 
            }
        
        __context__.SourceCodeLine = 1406;
        G_NINITIALRUN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1407;
        G_SNCONSOLECONNECTIONSTATUS = (short) ( 0 ) ; 
        __context__.SourceCodeLine = 1408;
        G_NSEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1409;
        G_NCONSOLESTEP = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1410;
        G_NMASTERGUIDOVERRIDE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1411;
        Functions.SetArray (  ref G_NGUIDOVERRIDE , (ushort)0) ; 
        __context__.SourceCodeLine = 1412;
        G_NINSTANCEIDFOUND = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1413;
        G_NTSIDRETRYCOUNT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1414;
        G_NTSIDUPDATEBUSY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1415;
        G_NRVIFILECHANGED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1416;
        G_NROOMNAMEOVERRIDEALLOWED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1418;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)60; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( NCOUNT  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NCOUNT  >= __FN_FORSTART_VAL__1) && (NCOUNT  <= __FN_FOREND_VAL__1) ) : ( (NCOUNT  <= __FN_FORSTART_VAL__1) && (NCOUNT  >= __FN_FOREND_VAL__1) ) ; NCOUNT  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1420;
            Functions.ClearBuffer ( G_SOVERRIDEROOMNAME__DOLLAR__ [ NCOUNT ] ) ; 
            __context__.SourceCodeLine = 1418;
            } 
        
        __context__.SourceCodeLine = 1422;
        G_NROOMNAMEOVERRIDEALLOWED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1423;
        CHECK_ROOMNAMES (  __context__  ) ; 
        __context__.SourceCodeLine = 1425;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1425;
            Trace( "***** Function Main Complete Variable Init *****\r\n") ; 
            }
        
        __context__.SourceCodeLine = 1427;
        UPDATE_GUIDS_BUSY_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1429;
        if ( Functions.TestForTrue  ( ( PROCESSORMODE  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 1431;
            Functions.Delay (  (int) ( 12000 ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1435;
            Functions.Delay (  (int) ( 2000 ) ) ; 
            } 
        
        __context__.SourceCodeLine = 1438;
        Functions.ClearBuffer ( G_SRVINEWFILETEMP__DOLLAR__ ) ; 
        __context__.SourceCodeLine = 1440;
        UPDATE_GUIDS (  __context__  ) ; 
        __context__.SourceCodeLine = 1442;
        if ( Functions.TestForTrue  ( ( G_NDEBUG)  ) ) 
            {
            __context__.SourceCodeLine = 1442;
            Trace( "***** End Function Main *****\r\n") ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    G_NGUIDOVERRIDE  = new ushort[ 61 ];
    G_NROOMNAMEUPDATED  = new ushort[ 61 ];
    G_NGUIDCOUNT  = new ushort[ 61 ];
    G_SMASTERGUIDPREFIX__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 12, this );
    G_SGUIDMASTEROVERRIDEPREFIX__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 12, this );
    G_SRVITEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5500, this );
    G_SRVINEWFILETEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5500, this );
    G_SRVIFULLFILEPATH__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    G_SRVINEWFULLFILEPATH__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    G_SRVIFILENAME__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    G_SRVIFILELOCATION__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 200, this );
    G_SGUIDPREFIX__DOLLAR__  = new CrestronString[ 61 ];
    for( uint i = 0; i < 61; i++ )
        G_SGUIDPREFIX__DOLLAR__ [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 12, this );
    G_SOVERRIDEROOMNAME__DOLLAR__  = new CrestronString[ 61 ];
    for( uint i = 0; i < 61; i++ )
        G_SOVERRIDEROOMNAME__DOLLAR__ [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    TCPCONSOLE  = new SplusTcpClient ( 1000, this );
    
    UPDATE_GUIDS_B = new Crestron.Logos.SplusObjects.DigitalInput( UPDATE_GUIDS_B__DigitalInput__, this );
    m_DigitalInputList.Add( UPDATE_GUIDS_B__DigitalInput__, UPDATE_GUIDS_B );
    
    UPDATE_GUIDS_BUSY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( UPDATE_GUIDS_BUSY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( UPDATE_GUIDS_BUSY_FB__DigitalOutput__, UPDATE_GUIDS_BUSY_FB );
    
    SYMBOL_GUID_COUNT_FB = new InOutArray<AnalogOutput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        SYMBOL_GUID_COUNT_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( SYMBOL_GUID_COUNT_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( SYMBOL_GUID_COUNT_FB__AnalogSerialOutput__ + i, SYMBOL_GUID_COUNT_FB[i+1] );
    }
    
    MASTER_OVERRIDE_GUID_PREFIX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( MASTER_OVERRIDE_GUID_PREFIX__DOLLAR____AnalogSerialInput__, 8, this );
    m_StringInputList.Add( MASTER_OVERRIDE_GUID_PREFIX__DOLLAR____AnalogSerialInput__, MASTER_OVERRIDE_GUID_PREFIX__DOLLAR__ );
    
    UPDATE_GUID_STATUS_TXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( UPDATE_GUID_STATUS_TXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( UPDATE_GUID_STATUS_TXT__DOLLAR____AnalogSerialOutput__, UPDATE_GUID_STATUS_TXT__DOLLAR__ );
    
    MASTER_GUID_PREFIX_TXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( MASTER_GUID_PREFIX_TXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( MASTER_GUID_PREFIX_TXT__DOLLAR____AnalogSerialOutput__, MASTER_GUID_PREFIX_TXT__DOLLAR__ );
    
    RVI_FILE_NAME_TXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( RVI_FILE_NAME_TXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( RVI_FILE_NAME_TXT__DOLLAR____AnalogSerialOutput__, RVI_FILE_NAME_TXT__DOLLAR__ );
    
    RVI_FILE_FULL_PATH_TXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( RVI_FILE_FULL_PATH_TXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( RVI_FILE_FULL_PATH_TXT__DOLLAR____AnalogSerialOutput__, RVI_FILE_FULL_PATH_TXT__DOLLAR__ );
    
    CONSOLE_TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( CONSOLE_TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( CONSOLE_TX__DOLLAR____AnalogSerialOutput__, CONSOLE_TX__DOLLAR__ );
    
    CONSOLE_STATUS_TXT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( CONSOLE_STATUS_TXT__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( CONSOLE_STATUS_TXT__DOLLAR____AnalogSerialOutput__, CONSOLE_STATUS_TXT__DOLLAR__ );
    
    SYMBOL_GUID_COUNT_TXT__DOLLAR__ = new InOutArray<StringOutput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        SYMBOL_GUID_COUNT_TXT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SYMBOL_GUID_COUNT_TXT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SYMBOL_GUID_COUNT_TXT__DOLLAR____AnalogSerialOutput__ + i, SYMBOL_GUID_COUNT_TXT__DOLLAR__[i+1] );
    }
    
    SYMBOL_ROOM_NAME_TXT__DOLLAR__ = new InOutArray<StringOutput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        SYMBOL_ROOM_NAME_TXT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SYMBOL_ROOM_NAME_TXT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SYMBOL_ROOM_NAME_TXT__DOLLAR____AnalogSerialOutput__ + i, SYMBOL_ROOM_NAME_TXT__DOLLAR__[i+1] );
    }
    
    SYMBOL_GUID_TXT__DOLLAR__ = new InOutArray<StringOutput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        SYMBOL_GUID_TXT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SYMBOL_GUID_TXT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SYMBOL_GUID_TXT__DOLLAR____AnalogSerialOutput__ + i, SYMBOL_GUID_TXT__DOLLAR__[i+1] );
    }
    
    SYMBOL_IPID_TXT__DOLLAR__ = new InOutArray<StringOutput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        SYMBOL_IPID_TXT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SYMBOL_IPID_TXT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SYMBOL_IPID_TXT__DOLLAR____AnalogSerialOutput__ + i, SYMBOL_IPID_TXT__DOLLAR__[i+1] );
    }
    
    SYMBOL_SLOT_GUIDS_TX__DOLLAR__ = new InOutArray<StringOutput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        SYMBOL_SLOT_GUIDS_TX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( SYMBOL_SLOT_GUIDS_TX__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( SYMBOL_SLOT_GUIDS_TX__DOLLAR____AnalogSerialOutput__ + i, SYMBOL_SLOT_GUIDS_TX__DOLLAR__[i+1] );
    }
    
    CONSOLE_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( CONSOLE_RX__DOLLAR____AnalogSerialInput__, 1000, this );
    m_StringInputList.Add( CONSOLE_RX__DOLLAR____AnalogSerialInput__, CONSOLE_RX__DOLLAR__ );
    
    OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__ = new InOutArray<BufferInput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.BufferInput( OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR____AnalogSerialInput__ + i, OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR____AnalogSerialInput__ + i, OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__[i+1] );
    }
    
    OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR__ = new InOutArray<BufferInput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.BufferInput( OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR____AnalogSerialInput__ + i, OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR____AnalogSerialInput__, 8, this );
        m_StringInputList.Add( OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR____AnalogSerialInput__ + i, OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR__[i+1] );
    }
    
    PROCESSORMODE = new UShortParameter( PROCESSORMODE__Parameter__, this );
    m_ParameterList.Add( PROCESSORMODE__Parameter__, PROCESSORMODE );
    
    PREFIXGUIDS = new UShortParameter( PREFIXGUIDS__Parameter__, this );
    m_ParameterList.Add( PREFIXGUIDS__Parameter__, PREFIXGUIDS );
    
    THREESERIESAPPENDSLOTNUMBER = new UShortParameter( THREESERIESAPPENDSLOTNUMBER__Parameter__, this );
    m_ParameterList.Add( THREESERIESAPPENDSLOTNUMBER__Parameter__, THREESERIESAPPENDSLOTNUMBER );
    
    FILESTORAGELOCATION__DOLLAR__ = new StringParameter( FILESTORAGELOCATION__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILESTORAGELOCATION__DOLLAR____Parameter__, FILESTORAGELOCATION__DOLLAR__ );
    
    
    UPDATE_GUIDS_B.OnDigitalPush.Add( new InputChangeHandlerWrapper( UPDATE_GUIDS_B_OnPush_0, false ) );
    MASTER_OVERRIDE_GUID_PREFIX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( MASTER_OVERRIDE_GUID_PREFIX__DOLLAR___OnChange_1, false ) );
    for( uint i = 0; i < 60; i++ )
        OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR___OnChange_2, false ) );
        
    CONSOLE_RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( CONSOLE_RX__DOLLAR___OnChange_3, false ) );
    for( uint i = 0; i < 60; i++ )
        OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR__[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR___OnChange_4, false ) );
        
    TCPCONSOLE.OnSocketConnect.Add( new SocketHandlerWrapper( TCPCONSOLE_OnSocketConnect_5, false ) );
    TCPCONSOLE.OnSocketDisconnect.Add( new SocketHandlerWrapper( TCPCONSOLE_OnSocketDisconnect_6, false ) );
    TCPCONSOLE.OnSocketReceive.Add( new SocketHandlerWrapper( TCPCONSOLE_OnSocketReceive_7, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_FUSION_GUID_UPDATER_HELPER_V2_02 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint UPDATE_GUIDS_B__DigitalInput__ = 0;
const uint MASTER_OVERRIDE_GUID_PREFIX__DOLLAR____AnalogSerialInput__ = 0;
const uint CONSOLE_RX__DOLLAR____AnalogSerialInput__ = 1;
const uint OVERRIDE_SYMBOL_ROOM_NAME__DOLLAR____AnalogSerialInput__ = 2;
const uint OVERRIDE_SYMBOL_GUID_PREFIX__DOLLAR____AnalogSerialInput__ = 62;
const uint UPDATE_GUIDS_BUSY_FB__DigitalOutput__ = 0;
const uint UPDATE_GUID_STATUS_TXT__DOLLAR____AnalogSerialOutput__ = 0;
const uint MASTER_GUID_PREFIX_TXT__DOLLAR____AnalogSerialOutput__ = 1;
const uint RVI_FILE_NAME_TXT__DOLLAR____AnalogSerialOutput__ = 2;
const uint RVI_FILE_FULL_PATH_TXT__DOLLAR____AnalogSerialOutput__ = 3;
const uint CONSOLE_TX__DOLLAR____AnalogSerialOutput__ = 4;
const uint CONSOLE_STATUS_TXT__DOLLAR____AnalogSerialOutput__ = 5;
const uint SYMBOL_GUID_COUNT_FB__AnalogSerialOutput__ = 6;
const uint SYMBOL_GUID_COUNT_TXT__DOLLAR____AnalogSerialOutput__ = 66;
const uint SYMBOL_ROOM_NAME_TXT__DOLLAR____AnalogSerialOutput__ = 126;
const uint SYMBOL_GUID_TXT__DOLLAR____AnalogSerialOutput__ = 186;
const uint SYMBOL_IPID_TXT__DOLLAR____AnalogSerialOutput__ = 246;
const uint SYMBOL_SLOT_GUIDS_TX__DOLLAR____AnalogSerialOutput__ = 306;
const uint PROCESSORMODE__Parameter__ = 10;
const uint PREFIXGUIDS__Parameter__ = 11;
const uint THREESERIESAPPENDSLOTNUMBER__Parameter__ = 12;
const uint FILESTORAGELOCATION__DOLLAR____Parameter__ = 13;

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
