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

namespace UserModule_VOLUME_PRESS_AND_HOLD
{
    public class UserModuleClass_VOLUME_PRESS_AND_HOLD : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput UP_PRESS;
        Crestron.Logos.SplusObjects.DigitalInput DOWN_PRESS;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_UP;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_DOWN;
        object UP_PRESS_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 31;
                VOLUME_UP  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 32;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 33;
                VOLUME_UP  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 35;
                while ( Functions.TestForTrue  ( ( UP_PRESS  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 36;
                    VOLUME_UP  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 37;
                    Functions.Delay (  (int) ( 10 ) ) ; 
                    __context__.SourceCodeLine = 38;
                    VOLUME_UP  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 39;
                    Functions.Delay (  (int) ( 10 ) ) ; 
                    __context__.SourceCodeLine = 35;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DOWN_PRESS_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 44;
            VOLUME_DOWN  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 45;
            Functions.Delay (  (int) ( 10 ) ) ; 
            __context__.SourceCodeLine = 46;
            VOLUME_DOWN  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 48;
            while ( Functions.TestForTrue  ( ( DOWN_PRESS  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 49;
                VOLUME_DOWN  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 50;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 51;
                VOLUME_DOWN  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 52;
                Functions.Delay (  (int) ( 10 ) ) ; 
                __context__.SourceCodeLine = 48;
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
        
        __context__.SourceCodeLine = 60;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    UP_PRESS = new Crestron.Logos.SplusObjects.DigitalInput( UP_PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( UP_PRESS__DigitalInput__, UP_PRESS );
    
    DOWN_PRESS = new Crestron.Logos.SplusObjects.DigitalInput( DOWN_PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( DOWN_PRESS__DigitalInput__, DOWN_PRESS );
    
    VOLUME_UP = new Crestron.Logos.SplusObjects.DigitalOutput( VOLUME_UP__DigitalOutput__, this );
    m_DigitalOutputList.Add( VOLUME_UP__DigitalOutput__, VOLUME_UP );
    
    VOLUME_DOWN = new Crestron.Logos.SplusObjects.DigitalOutput( VOLUME_DOWN__DigitalOutput__, this );
    m_DigitalOutputList.Add( VOLUME_DOWN__DigitalOutput__, VOLUME_DOWN );
    
    
    UP_PRESS.OnDigitalPush.Add( new InputChangeHandlerWrapper( UP_PRESS_OnPush_0, false ) );
    DOWN_PRESS.OnDigitalPush.Add( new InputChangeHandlerWrapper( DOWN_PRESS_OnPush_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_VOLUME_PRESS_AND_HOLD ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint UP_PRESS__DigitalInput__ = 0;
const uint DOWN_PRESS__DigitalInput__ = 1;
const uint VOLUME_UP__DigitalOutput__ = 0;
const uint VOLUME_DOWN__DigitalOutput__ = 1;

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
