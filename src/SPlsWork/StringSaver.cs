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

namespace UserModule_STRINGSAVER
{
    public class UserModuleClass_STRINGSAVER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput RECALLSETTINGS;
        Crestron.Logos.SplusObjects.DigitalOutput INITIALIZE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> STRINGIN;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> STRINGOUT;
        private void SENDTOOUTPUT (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 18;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 20;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)50; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 22;
                STRINGOUT [ I]  .UpdateValue ( _SplusNVRAM.STRINGINSTORE [ I ]  ) ; 
                __context__.SourceCodeLine = 20;
                } 
            
            
            }
            
        object RECALLSETTINGS_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 29;
                SENDTOOUTPUT (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object STRINGIN_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort INDEX = 0;
            
            
            __context__.SourceCodeLine = 36;
            INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 38;
            _SplusNVRAM.STRINGINSTORE [ INDEX ]  .UpdateValue ( STRINGIN [ INDEX ]  ) ; 
            
            
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
        
        __context__.SourceCodeLine = 47;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 49;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.INITIALIZED == "initialized"))  ) ) 
            { 
            __context__.SourceCodeLine = 51;
            SENDTOOUTPUT (  __context__  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 55;
            Functions.Pulse ( 1, INITIALIZE ) ; 
            __context__.SourceCodeLine = 56;
            _SplusNVRAM.INITIALIZED  .UpdateValue ( "initialized"  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.INITIALIZED  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 11, this );
    _SplusNVRAM.STRINGINSTORE  = new CrestronString[ 51 ];
    for( uint i = 0; i < 51; i++ )
        _SplusNVRAM.STRINGINSTORE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    
    RECALLSETTINGS = new Crestron.Logos.SplusObjects.DigitalInput( RECALLSETTINGS__DigitalInput__, this );
    m_DigitalInputList.Add( RECALLSETTINGS__DigitalInput__, RECALLSETTINGS );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalOutput( INITIALIZE__DigitalOutput__, this );
    m_DigitalOutputList.Add( INITIALIZE__DigitalOutput__, INITIALIZE );
    
    STRINGIN = new InOutArray<StringInput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        STRINGIN[i+1] = new Crestron.Logos.SplusObjects.StringInput( STRINGIN__AnalogSerialInput__ + i, STRINGIN__AnalogSerialInput__, 50, this );
        m_StringInputList.Add( STRINGIN__AnalogSerialInput__ + i, STRINGIN[i+1] );
    }
    
    STRINGOUT = new InOutArray<StringOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        STRINGOUT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( STRINGOUT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( STRINGOUT__AnalogSerialOutput__ + i, STRINGOUT[i+1] );
    }
    
    
    RECALLSETTINGS.OnDigitalPush.Add( new InputChangeHandlerWrapper( RECALLSETTINGS_OnPush_0, false ) );
    for( uint i = 0; i < 50; i++ )
        STRINGIN[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( STRINGIN_OnChange_1, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_STRINGSAVER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RECALLSETTINGS__DigitalInput__ = 0;
const uint INITIALIZE__DigitalOutput__ = 0;
const uint STRINGIN__AnalogSerialInput__ = 0;
const uint STRINGOUT__AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public CrestronString [] STRINGINSTORE;
            [SplusStructAttribute(1, false, true)]
            public CrestronString INITIALIZED;
            
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
