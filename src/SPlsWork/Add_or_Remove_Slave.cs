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

namespace UserModule_ADD_OR_REMOVE_SLAVE
{
    public class UserModuleClass_ADD_OR_REMOVE_SLAVE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput ADD_SLAVE;
        Crestron.Logos.SplusObjects.DigitalInput REMOVE_SLAVE;
        Crestron.Logos.SplusObjects.DigitalInput RESET_PROGRAM;
        Crestron.Logos.SplusObjects.DigitalInput TEST;
        Crestron.Logos.SplusObjects.DigitalInput GET_PROGRAM_INFO;
        Crestron.Logos.SplusObjects.BufferInput IP_ADDRESS__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput FROM_CONSOLE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PROGRAM_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput COMPILE_DATE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TO_CONSOLE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput IPTABLE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput DMPSVER__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput DMPSHOSTNAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput DMPSIP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput DMPSMAC__DOLLAR__;
        CrestronString IP_ID__DOLLAR__;
        CrestronString PORT__DOLLAR__;
        private CrestronString SANITIZE (  SplusExecutionContext __context__, CrestronString MSG , ushort REMOVESPECIALCHARS ) 
            { 
            CrestronString STRIPPEDMESSAGE;
            CrestronString CHAR;
            STRIPPEDMESSAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            CHAR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 36;
            STRIPPEDMESSAGE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 38;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (REMOVESPECIALCHARS == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 40;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( MSG ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 42;
                    CHAR  .UpdateValue ( Functions.Mid ( MSG ,  (int) ( I ) ,  (int) ( 1 ) )  ) ; 
                    __context__.SourceCodeLine = 44;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (CHAR != "_") ) && Functions.TestForTrue ( Functions.BoolToInt (CHAR != "/") )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (CHAR != " ") )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 46;
                        STRIPPEDMESSAGE  .UpdateValue ( STRIPPEDMESSAGE + CHAR  ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 40;
                    } 
                
                } 
            
            __context__.SourceCodeLine = 51;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( STRIPPEDMESSAGE , (int)( 1 ) , (int)( 1 ) ) == " "))  ) ) 
                { 
                __context__.SourceCodeLine = 53;
                STRIPPEDMESSAGE  .UpdateValue ( Functions.Right ( STRIPPEDMESSAGE ,  (int) ( (Functions.Length( STRIPPEDMESSAGE ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 51;
                } 
            
            __context__.SourceCodeLine = 56;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( STRIPPEDMESSAGE , (int)( Functions.Length( STRIPPEDMESSAGE ) ) , (int)( 1 ) ) == " "))  ) ) 
                { 
                __context__.SourceCodeLine = 58;
                STRIPPEDMESSAGE  .UpdateValue ( Functions.Left ( STRIPPEDMESSAGE ,  (int) ( (Functions.Length( STRIPPEDMESSAGE ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 56;
                } 
            
            __context__.SourceCodeLine = 61;
            return ( STRIPPEDMESSAGE ) ; 
            
            }
            
        object ADD_SLAVE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 69;
                TO_CONSOLE__DOLLAR__  .UpdateValue ( "ADDSlave " + IP_ID__DOLLAR__ + " " + IP_ADDRESS__DOLLAR__ + "\u000D"  ) ; 
                __context__.SourceCodeLine = 70;
                IP_ADDRESS__DOLLAR__  .UpdateValue ( ""  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object REMOVE_SLAVE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 75;
            TO_CONSOLE__DOLLAR__  .UpdateValue ( "REMSlave " + IP_ID__DOLLAR__ + " " + IP_ADDRESS__DOLLAR__ + "\u000D"  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object RESET_PROGRAM_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 80;
        TO_CONSOLE__DOLLAR__  .UpdateValue ( "ProgReset" + "\u000D"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TEST_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 85;
        TO_CONSOLE__DOLLAR__  .UpdateValue ( "IPTable -I:" + IP_ID__DOLLAR__ + "\u000D"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_PROGRAM_INFO_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 90;
        TO_CONSOLE__DOLLAR__  .UpdateValue ( "ProgComments\u000D"  ) ; 
        __context__.SourceCodeLine = 91;
        TO_CONSOLE__DOLLAR__  .UpdateValue ( "ver\u000D"  ) ; 
        __context__.SourceCodeLine = 92;
        TO_CONSOLE__DOLLAR__  .UpdateValue ( "host\u000D"  ) ; 
        __context__.SourceCodeLine = 93;
        TO_CONSOLE__DOLLAR__  .UpdateValue ( "ipaddress\u000D"  ) ; 
        __context__.SourceCodeLine = 94;
        TO_CONSOLE__DOLLAR__  .UpdateValue ( "estatus\u000D"  ) ; 
        __context__.SourceCodeLine = 95;
        TO_CONSOLE__DOLLAR__  .UpdateValue ( "ipconfig\u000D"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_CONSOLE__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort STARTPOSITION = 0;
        
        CrestronString IN__DOLLAR__;
        CrestronString TEMPSTRING;
        CrestronString TRASH;
        IN__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3000, this );
        TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 250, this );
        
        
        __context__.SourceCodeLine = 103;
        IN__DOLLAR__  .UpdateValue ( Functions.Gather ( "DMPS-300-C>" , FROM_CONSOLE__DOLLAR__ )  ) ; 
        __context__.SourceCodeLine = 106;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Find( "IP Table:" , IN__DOLLAR__ ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( IN__DOLLAR__ ) < 150 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 109;
            IPTABLE__DOLLAR__  .UpdateValue ( Functions.Left ( IN__DOLLAR__ ,  (int) ( (Functions.Find( "DMPS-300-C>" , IN__DOLLAR__ ) - 5) ) )  ) ; 
            __context__.SourceCodeLine = 110;
            IN__DOLLAR__  .UpdateValue ( ""  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 112;
            if ( Functions.TestForTrue  ( ( Functions.Find( "DMPS-300-C Cntrl Eng" , IN__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 114;
                DMPSVER__DOLLAR__  .UpdateValue ( Functions.Left ( IN__DOLLAR__ ,  (int) ( (Functions.Find( "DMPS-300-C>" , IN__DOLLAR__ ) - 5) ) )  ) ; 
                __context__.SourceCodeLine = 115;
                IN__DOLLAR__  .UpdateValue ( ""  ) ; 
                } 
            
            }
        
        __context__.SourceCodeLine = 118;
        while ( Functions.TestForTrue  ( ( Functions.Find( "\u000A" , IN__DOLLAR__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 120;
            TEMPSTRING  .UpdateValue ( Functions.Remove ( "\u000A" , IN__DOLLAR__ )  ) ; 
            __context__.SourceCodeLine = 121;
            if ( Functions.TestForTrue  ( ( Functions.Find( "Program File:" , TEMPSTRING ))  ) ) 
                { 
                __context__.SourceCodeLine = 123;
                TRASH  .UpdateValue ( Functions.Remove ( "Program File: " , TEMPSTRING )  ) ; 
                __context__.SourceCodeLine = 124;
                PROGRAM_NAME__DOLLAR__  .UpdateValue ( Functions.Left ( TEMPSTRING ,  (int) ( (Functions.Find( "\u000A" , TEMPSTRING ) - 2) ) )  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 127;
                if ( Functions.TestForTrue  ( ( Functions.Find( "Compiled On:" , TEMPSTRING ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 129;
                    TRASH  .UpdateValue ( Functions.Remove ( "Compiled On:  " , TEMPSTRING )  ) ; 
                    __context__.SourceCodeLine = 130;
                    COMPILE_DATE__DOLLAR__  .UpdateValue ( Functions.Left ( TEMPSTRING ,  (int) ( (Functions.Find( "\u000A" , TEMPSTRING ) - 2) ) )  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 132;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "Host Name:" , TEMPSTRING ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 134;
                        TRASH  .UpdateValue ( Functions.Remove ( "Host Name: " , TEMPSTRING )  ) ; 
                        __context__.SourceCodeLine = 139;
                        TRASH  .UpdateValue ( Functions.Left ( TEMPSTRING ,  (int) ( (Functions.Find( "\u000D" , TEMPSTRING ) - 1) ) )  ) ; 
                        __context__.SourceCodeLine = 140;
                        TRASH  .UpdateValue ( SANITIZE (  __context__ , TRASH, (ushort)( 1 ))  ) ; 
                        __context__.SourceCodeLine = 142;
                        DMPSHOSTNAME__DOLLAR__  .UpdateValue ( TRASH  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 144;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "Device 0 IP address:" , TEMPSTRING ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 147;
                            TRASH  .UpdateValue ( Functions.Remove ( "IP address:" , TEMPSTRING )  ) ; 
                            __context__.SourceCodeLine = 150;
                            DMPSIP__DOLLAR__  .UpdateValue ( Functions.Left ( TEMPSTRING ,  (int) ( (Functions.Find( "\u000D" , TEMPSTRING ) - 1) ) )  ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 153;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "MAC Address(es):" , TEMPSTRING ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 155;
                                TRASH  .UpdateValue ( Functions.Remove ( "MAC Address(es): " , TEMPSTRING )  ) ; 
                                __context__.SourceCodeLine = 159;
                                DMPSMAC__DOLLAR__  .UpdateValue ( Functions.Left ( TEMPSTRING ,  (int) ( 17 ) )  ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 161;
                                if ( Functions.TestForTrue  ( ( Functions.Find( "MAC Address(es).... : " , TEMPSTRING ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 163;
                                    TRASH  .UpdateValue ( Functions.Remove ( "MAC Address(es).... : " , TEMPSTRING )  ) ; 
                                    __context__.SourceCodeLine = 167;
                                    DMPSMAC__DOLLAR__  .UpdateValue ( Functions.Left ( TEMPSTRING ,  (int) ( 17 ) )  ) ; 
                                    } 
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 118;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 178;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 179;
        IP_ID__DOLLAR__  .UpdateValue ( "07"  ) ; 
        __context__.SourceCodeLine = 180;
        PORT__DOLLAR__  .UpdateValue ( "2202"  ) ; 
        __context__.SourceCodeLine = 181;
        PROGRAM_NAME__DOLLAR__  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 182;
        COMPILE_DATE__DOLLAR__  .UpdateValue ( ""  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    IP_ID__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    PORT__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    
    ADD_SLAVE = new Crestron.Logos.SplusObjects.DigitalInput( ADD_SLAVE__DigitalInput__, this );
    m_DigitalInputList.Add( ADD_SLAVE__DigitalInput__, ADD_SLAVE );
    
    REMOVE_SLAVE = new Crestron.Logos.SplusObjects.DigitalInput( REMOVE_SLAVE__DigitalInput__, this );
    m_DigitalInputList.Add( REMOVE_SLAVE__DigitalInput__, REMOVE_SLAVE );
    
    RESET_PROGRAM = new Crestron.Logos.SplusObjects.DigitalInput( RESET_PROGRAM__DigitalInput__, this );
    m_DigitalInputList.Add( RESET_PROGRAM__DigitalInput__, RESET_PROGRAM );
    
    TEST = new Crestron.Logos.SplusObjects.DigitalInput( TEST__DigitalInput__, this );
    m_DigitalInputList.Add( TEST__DigitalInput__, TEST );
    
    GET_PROGRAM_INFO = new Crestron.Logos.SplusObjects.DigitalInput( GET_PROGRAM_INFO__DigitalInput__, this );
    m_DigitalInputList.Add( GET_PROGRAM_INFO__DigitalInput__, GET_PROGRAM_INFO );
    
    PROGRAM_NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PROGRAM_NAME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( PROGRAM_NAME__DOLLAR____AnalogSerialOutput__, PROGRAM_NAME__DOLLAR__ );
    
    COMPILE_DATE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( COMPILE_DATE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( COMPILE_DATE__DOLLAR____AnalogSerialOutput__, COMPILE_DATE__DOLLAR__ );
    
    TO_CONSOLE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TO_CONSOLE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_CONSOLE__DOLLAR____AnalogSerialOutput__, TO_CONSOLE__DOLLAR__ );
    
    IPTABLE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( IPTABLE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( IPTABLE__DOLLAR____AnalogSerialOutput__, IPTABLE__DOLLAR__ );
    
    DMPSVER__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( DMPSVER__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( DMPSVER__DOLLAR____AnalogSerialOutput__, DMPSVER__DOLLAR__ );
    
    DMPSHOSTNAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( DMPSHOSTNAME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( DMPSHOSTNAME__DOLLAR____AnalogSerialOutput__, DMPSHOSTNAME__DOLLAR__ );
    
    DMPSIP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( DMPSIP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( DMPSIP__DOLLAR____AnalogSerialOutput__, DMPSIP__DOLLAR__ );
    
    DMPSMAC__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( DMPSMAC__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( DMPSMAC__DOLLAR____AnalogSerialOutput__, DMPSMAC__DOLLAR__ );
    
    IP_ADDRESS__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( IP_ADDRESS__DOLLAR____AnalogSerialInput__, 15, this );
    m_StringInputList.Add( IP_ADDRESS__DOLLAR____AnalogSerialInput__, IP_ADDRESS__DOLLAR__ );
    
    FROM_CONSOLE__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( FROM_CONSOLE__DOLLAR____AnalogSerialInput__, 3000, this );
    m_StringInputList.Add( FROM_CONSOLE__DOLLAR____AnalogSerialInput__, FROM_CONSOLE__DOLLAR__ );
    
    
    ADD_SLAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ADD_SLAVE_OnPush_0, false ) );
    REMOVE_SLAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( REMOVE_SLAVE_OnPush_1, false ) );
    RESET_PROGRAM.OnDigitalPush.Add( new InputChangeHandlerWrapper( RESET_PROGRAM_OnPush_2, false ) );
    TEST.OnDigitalPush.Add( new InputChangeHandlerWrapper( TEST_OnPush_3, false ) );
    GET_PROGRAM_INFO.OnDigitalPush.Add( new InputChangeHandlerWrapper( GET_PROGRAM_INFO_OnPush_4, false ) );
    FROM_CONSOLE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_CONSOLE__DOLLAR___OnChange_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_ADD_OR_REMOVE_SLAVE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ADD_SLAVE__DigitalInput__ = 0;
const uint REMOVE_SLAVE__DigitalInput__ = 1;
const uint RESET_PROGRAM__DigitalInput__ = 2;
const uint TEST__DigitalInput__ = 3;
const uint GET_PROGRAM_INFO__DigitalInput__ = 4;
const uint IP_ADDRESS__DOLLAR____AnalogSerialInput__ = 0;
const uint FROM_CONSOLE__DOLLAR____AnalogSerialInput__ = 1;
const uint PROGRAM_NAME__DOLLAR____AnalogSerialOutput__ = 0;
const uint COMPILE_DATE__DOLLAR____AnalogSerialOutput__ = 1;
const uint TO_CONSOLE__DOLLAR____AnalogSerialOutput__ = 2;
const uint IPTABLE__DOLLAR____AnalogSerialOutput__ = 3;
const uint DMPSVER__DOLLAR____AnalogSerialOutput__ = 4;
const uint DMPSHOSTNAME__DOLLAR____AnalogSerialOutput__ = 5;
const uint DMPSIP__DOLLAR____AnalogSerialOutput__ = 6;
const uint DMPSMAC__DOLLAR____AnalogSerialOutput__ = 7;

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
