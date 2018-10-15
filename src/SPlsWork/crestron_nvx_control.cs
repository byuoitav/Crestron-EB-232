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

namespace UserModule_CRESTRON_NVX_CONTROL
{
    public class UserModuleClass_CRESTRON_NVX_CONTROL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SWITCHOUTPUTS;
        Crestron.Logos.SplusObjects.DigitalInput DISPLAYINPUT1;
        Crestron.Logos.SplusObjects.DigitalInput DISPLAYINPUT2;
        Crestron.Logos.SplusObjects.DigitalInput DISPLAYINPUT3;
        Crestron.Logos.SplusObjects.DigitalInput DISPLAYBLANK;
        Crestron.Logos.SplusObjects.AnalogInput DESIRED_VIDEO_SOURCE;
        Crestron.Logos.SplusObjects.AnalogInput DEFAULT_VIDEO_SOURCE;
        Crestron.Logos.SplusObjects.AnalogInput CURRENT_SOURCE_FB;
        Crestron.Logos.SplusObjects.AnalogOutput VIDEOOUT;
        Crestron.Logos.SplusObjects.DigitalOutput DISPLAYINGINPUT1_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DISPLAYINGINPUT2_FB;
        Crestron.Logos.SplusObjects.DigitalOutput DISPLAYINGINPUT3_FB;
        Crestron.Logos.SplusObjects.DigitalOutput BLANK_FB;
        ushort DESIREDVIDEO = 0;
        ushort DEFAULTVIDEO = 0;
        private void RESETOUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 60;
            DISPLAYINGINPUT1_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 61;
            DISPLAYINGINPUT2_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 62;
            DISPLAYINGINPUT3_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 63;
            BLANK_FB  .Value = (ushort) ( 0 ) ; 
            
            }
            
        object DESIRED_VIDEO_SOURCE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 71;
                DESIREDVIDEO = (ushort) ( DESIRED_VIDEO_SOURCE  .UshortValue ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DEFAULT_VIDEO_SOURCE_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 75;
            DEFAULTVIDEO = (ushort) ( DEFAULT_VIDEO_SOURCE  .UshortValue ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object CURRENT_SOURCE_FB_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 80;
        
            {
            int __SPLS_TMPVAR__SWTCH_1__ = ((int)CURRENT_SOURCE_FB  .UshortValue);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 83;
                    RESETOUTS (  __context__  ) ; 
                    __context__.SourceCodeLine = 84;
                    DISPLAYINGINPUT1_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 88;
                    RESETOUTS (  __context__  ) ; 
                    __context__.SourceCodeLine = 89;
                    DISPLAYINGINPUT2_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 93;
                    RESETOUTS (  __context__  ) ; 
                    __context__.SourceCodeLine = 94;
                    DISPLAYINGINPUT3_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 98;
                    RESETOUTS (  __context__  ) ; 
                    __context__.SourceCodeLine = 99;
                    BLANK_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                } 
                
            }
            
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SWITCHOUTPUTS_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 105;
        VIDEOOUT  .Value = (ushort) ( DESIRED_VIDEO_SOURCE  .UshortValue ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISPLAYINPUT1_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 110;
        VIDEOOUT  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISPLAYINPUT2_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 115;
        VIDEOOUT  .Value = (ushort) ( 2 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISPLAYINPUT3_OnRelease_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 120;
        VIDEOOUT  .Value = (ushort) ( 3 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISPLAYBLANK_OnRelease_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 125;
        VIDEOOUT  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void INIT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 134;
    DESIREDVIDEO = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 135;
    DEFAULTVIDEO = (ushort) ( 0 ) ; 
    
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 140;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 141;
        INIT (  __context__  ) ; 
        __context__.SourceCodeLine = 144;
        VIDEOOUT  .Value = (ushort) ( DEFAULTVIDEO ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    SWITCHOUTPUTS = new Crestron.Logos.SplusObjects.DigitalInput( SWITCHOUTPUTS__DigitalInput__, this );
    m_DigitalInputList.Add( SWITCHOUTPUTS__DigitalInput__, SWITCHOUTPUTS );
    
    DISPLAYINPUT1 = new Crestron.Logos.SplusObjects.DigitalInput( DISPLAYINPUT1__DigitalInput__, this );
    m_DigitalInputList.Add( DISPLAYINPUT1__DigitalInput__, DISPLAYINPUT1 );
    
    DISPLAYINPUT2 = new Crestron.Logos.SplusObjects.DigitalInput( DISPLAYINPUT2__DigitalInput__, this );
    m_DigitalInputList.Add( DISPLAYINPUT2__DigitalInput__, DISPLAYINPUT2 );
    
    DISPLAYINPUT3 = new Crestron.Logos.SplusObjects.DigitalInput( DISPLAYINPUT3__DigitalInput__, this );
    m_DigitalInputList.Add( DISPLAYINPUT3__DigitalInput__, DISPLAYINPUT3 );
    
    DISPLAYBLANK = new Crestron.Logos.SplusObjects.DigitalInput( DISPLAYBLANK__DigitalInput__, this );
    m_DigitalInputList.Add( DISPLAYBLANK__DigitalInput__, DISPLAYBLANK );
    
    DISPLAYINGINPUT1_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DISPLAYINGINPUT1_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DISPLAYINGINPUT1_FB__DigitalOutput__, DISPLAYINGINPUT1_FB );
    
    DISPLAYINGINPUT2_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DISPLAYINGINPUT2_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DISPLAYINGINPUT2_FB__DigitalOutput__, DISPLAYINGINPUT2_FB );
    
    DISPLAYINGINPUT3_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DISPLAYINGINPUT3_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DISPLAYINGINPUT3_FB__DigitalOutput__, DISPLAYINGINPUT3_FB );
    
    BLANK_FB = new Crestron.Logos.SplusObjects.DigitalOutput( BLANK_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( BLANK_FB__DigitalOutput__, BLANK_FB );
    
    DESIRED_VIDEO_SOURCE = new Crestron.Logos.SplusObjects.AnalogInput( DESIRED_VIDEO_SOURCE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DESIRED_VIDEO_SOURCE__AnalogSerialInput__, DESIRED_VIDEO_SOURCE );
    
    DEFAULT_VIDEO_SOURCE = new Crestron.Logos.SplusObjects.AnalogInput( DEFAULT_VIDEO_SOURCE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DEFAULT_VIDEO_SOURCE__AnalogSerialInput__, DEFAULT_VIDEO_SOURCE );
    
    CURRENT_SOURCE_FB = new Crestron.Logos.SplusObjects.AnalogInput( CURRENT_SOURCE_FB__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CURRENT_SOURCE_FB__AnalogSerialInput__, CURRENT_SOURCE_FB );
    
    VIDEOOUT = new Crestron.Logos.SplusObjects.AnalogOutput( VIDEOOUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VIDEOOUT__AnalogSerialOutput__, VIDEOOUT );
    
    
    DESIRED_VIDEO_SOURCE.OnAnalogChange.Add( new InputChangeHandlerWrapper( DESIRED_VIDEO_SOURCE_OnChange_0, false ) );
    DEFAULT_VIDEO_SOURCE.OnAnalogChange.Add( new InputChangeHandlerWrapper( DEFAULT_VIDEO_SOURCE_OnChange_1, false ) );
    CURRENT_SOURCE_FB.OnAnalogChange.Add( new InputChangeHandlerWrapper( CURRENT_SOURCE_FB_OnChange_2, false ) );
    SWITCHOUTPUTS.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SWITCHOUTPUTS_OnRelease_3, false ) );
    DISPLAYINPUT1.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DISPLAYINPUT1_OnRelease_4, false ) );
    DISPLAYINPUT2.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DISPLAYINPUT2_OnRelease_5, false ) );
    DISPLAYINPUT3.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DISPLAYINPUT3_OnRelease_6, false ) );
    DISPLAYBLANK.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DISPLAYBLANK_OnRelease_7, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_CRESTRON_NVX_CONTROL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SWITCHOUTPUTS__DigitalInput__ = 0;
const uint DISPLAYINPUT1__DigitalInput__ = 1;
const uint DISPLAYINPUT2__DigitalInput__ = 2;
const uint DISPLAYINPUT3__DigitalInput__ = 3;
const uint DISPLAYBLANK__DigitalInput__ = 4;
const uint DESIRED_VIDEO_SOURCE__AnalogSerialInput__ = 0;
const uint DEFAULT_VIDEO_SOURCE__AnalogSerialInput__ = 1;
const uint CURRENT_SOURCE_FB__AnalogSerialInput__ = 2;
const uint VIDEOOUT__AnalogSerialOutput__ = 0;
const uint DISPLAYINGINPUT1_FB__DigitalOutput__ = 0;
const uint DISPLAYINGINPUT2_FB__DigitalOutput__ = 1;
const uint DISPLAYINGINPUT3_FB__DigitalOutput__ = 2;
const uint BLANK_FB__DigitalOutput__ = 3;

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
