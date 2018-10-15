namespace SimplSharpStringUtils;
        // class declarations
         class StringUtils;
     class StringUtils 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ip ( STRING iptmp );
        STRING_FUNCTION HexToAscii ( STRING hexString );
        STRING_FUNCTION JSONAttributes ( STRING body , STRING desiredAttribute );
        STRING_FUNCTION getSonyResponseValue ( STRING body , STRING desiredAttribute );
        STRING_FUNCTION GetMemberOfStringArray ( STRING arrayToSearch , STRING delimiter , SIGNED_LONG_INTEGER member );
        SIGNED_LONG_INTEGER_FUNCTION NumberOfMembers ( STRING str , STRING delim );
        STRING_FUNCTION Replace ( STRING str , STRING replaceStr , STRING replaceWith );
        STRING_FUNCTION Trim ( STRING str );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

