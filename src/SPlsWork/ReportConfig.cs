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

namespace UserModule_REPORTCONFIG
{
    public class UserModuleClass_REPORTCONFIG : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.AnalogInput CURRENT_TZ;
        Crestron.Logos.SplusObjects.DigitalInput CLIENTCONNECTED;
        Crestron.Logos.SplusObjects.DigitalInput SYSTEMREADY;
        Crestron.Logos.SplusObjects.DigitalOutput _CLIENTCONNECTED;
        private CrestronString SANITIZE (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            CrestronString STRIPPEDMESSAGE;
            CrestronString CHAR;
            STRIPPEDMESSAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1024, this );
            CHAR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 47;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( MSG ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 49;
                CHAR  .UpdateValue ( Functions.Mid ( MSG ,  (int) ( I ) ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 51;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (CHAR != "_") ) && Functions.TestForTrue ( Functions.BoolToInt (CHAR != "/") )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 53;
                    STRIPPEDMESSAGE  .UpdateValue ( STRIPPEDMESSAGE + CHAR  ) ; 
                    } 
                
                __context__.SourceCodeLine = 47;
                } 
            
            __context__.SourceCodeLine = 57;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( STRIPPEDMESSAGE , (int)( 1 ) , (int)( 1 ) ) == " "))  ) ) 
                { 
                __context__.SourceCodeLine = 59;
                STRIPPEDMESSAGE  .UpdateValue ( Functions.Right ( STRIPPEDMESSAGE ,  (int) ( (Functions.Length( STRIPPEDMESSAGE ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 57;
                } 
            
            __context__.SourceCodeLine = 62;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( STRIPPEDMESSAGE , (int)( Functions.Length( STRIPPEDMESSAGE ) ) , (int)( 1 ) ) == " "))  ) ) 
                { 
                __context__.SourceCodeLine = 64;
                STRIPPEDMESSAGE  .UpdateValue ( Functions.Left ( STRIPPEDMESSAGE ,  (int) ( (Functions.Length( STRIPPEDMESSAGE ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 62;
                } 
            
            __context__.SourceCodeLine = 67;
            return ( STRIPPEDMESSAGE ) ; 
            
            }
            
        private void LOG (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 72;
            Print( "\r\n{0}", MSG ) ; 
            
            }
            
        private void ERROR (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 77;
            LOG (  __context__ , MSG) ; 
            
            }
            
        object CURRENT_TZ_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString STR;
                STR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
                
                
                __context__.SourceCodeLine = 97;
                MakeString ( STR , "Current TZ is {0:d}", (short)CURRENT_TZ  .UshortValue) ; 
                __context__.SourceCodeLine = 98;
                LOG (  __context__ , STR) ; 
                
                
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
            
            __context__.SourceCodeLine = 124;
            WaitForInitializationComplete ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        CLIENTCONNECTED = new Crestron.Logos.SplusObjects.DigitalInput( CLIENTCONNECTED__DigitalInput__, this );
        m_DigitalInputList.Add( CLIENTCONNECTED__DigitalInput__, CLIENTCONNECTED );
        
        SYSTEMREADY = new Crestron.Logos.SplusObjects.DigitalInput( SYSTEMREADY__DigitalInput__, this );
        m_DigitalInputList.Add( SYSTEMREADY__DigitalInput__, SYSTEMREADY );
        
        _CLIENTCONNECTED = new Crestron.Logos.SplusObjects.DigitalOutput( _CLIENTCONNECTED__DigitalOutput__, this );
        m_DigitalOutputList.Add( _CLIENTCONNECTED__DigitalOutput__, _CLIENTCONNECTED );
        
        CURRENT_TZ = new Crestron.Logos.SplusObjects.AnalogInput( CURRENT_TZ__AnalogSerialInput__, this );
        m_AnalogInputList.Add( CURRENT_TZ__AnalogSerialInput__, CURRENT_TZ );
        
        
        CURRENT_TZ.OnAnalogChange.Add( new InputChangeHandlerWrapper( CURRENT_TZ_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_REPORTCONFIG ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CURRENT_TZ__AnalogSerialInput__ = 0;
    const uint CLIENTCONNECTED__DigitalInput__ = 0;
    const uint SYSTEMREADY__DigitalInput__ = 1;
    const uint _CLIENTCONNECTED__DigitalOutput__ = 0;
    
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
