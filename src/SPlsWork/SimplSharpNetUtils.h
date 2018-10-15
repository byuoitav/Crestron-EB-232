namespace SimplSharpNetUtils;
        // class declarations
         class HttpGetter;
         class HTTPRequest;
         class TCPSocket;
     class HttpGetter 
    {
        // class delegates

        // class events

        // class functions
        LONG_INTEGER_FUNCTION Fetch ( STRING url , STRING filename );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING ErrorMsg[];
    };

     class HTTPRequest 
    {
        // class delegates
        delegate FUNCTION errorHandler ( SIMPLSHARPSTRING errMsg );
        delegate FUNCTION responseHandler ( SIMPLSHARPSTRING errMsg );

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION Post ( STRING body , STRING headers );
        SIGNED_LONG_INTEGER_FUNCTION Get ( STRING body , STRING headers );
        SIGNED_LONG_INTEGER_FUNCTION SendCommand ( STRING baseURL , STRING resource , STRING cmd , STRING psk );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING URL[];
        SIGNED_LONG_INTEGER Port;
        SIGNED_LONG_INTEGER numResponseAttributes;
        SIGNED_LONG_INTEGER errorExists;
        STRING errorMessage[];

        // class properties
        DelegateProperty errorHandler OnError;
        DelegateProperty responseHandler OnResponse;
    };

     class TCPSocket 
    {
        // class delegates
        delegate FUNCTION ConnectedHandler ( );
        delegate FUNCTION DisconnectedHandler ( );
        delegate FUNCTION RxHandler ( SIMPLSHARPSTRING data );

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION Connect ( STRING IPAddress , SIGNED_LONG_INTEGER port , SIGNED_LONG_INTEGER buffersz );
        FUNCTION Disconnect ();
        SIGNED_LONG_INTEGER_FUNCTION Send ( SIMPLSHARPSTRING data );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty ConnectedHandler OnConnect;
        DelegateProperty DisconnectedHandler OnDisconnect;
        DelegateProperty RxHandler OnRx;
        SIGNED_LONG_INTEGER FilterVtCmds;
        SIGNED_LONG_INTEGER Debug;
    };

