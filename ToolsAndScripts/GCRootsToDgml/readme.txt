This tool takes the output of the SOS debugger extension GCRoots command which dumps 
all references to a given object and converts the output to DGML for graphing using Progression.
Load the .dgml output in Visual Studio 2010.

To use it, do the following:

1.  Start your mixed mode debugging session using VS 2010.
2.  "Break" into the debugger at a place where you can get the memory location of an object of interest
3.  (the easiest way to do this is find some code in the disassembly windo that assigns a field value
     the first instruction will put 'this' into the EAX register, and that will be the address of your object)
4.  From debugger Immediate window type ".load sos.dll"
    (This should report "extension C:\Windows\Microsoft.NET\Framework\v4.0.30319\sos.dll loaded")
5.  Type "!gcroot 21fd7384" where the number is the address of your object.  The command name is case sensitive.
6.  Let this finish - it may take a while.  When you see the blinking cursor again in the immediate window
    copy all the text to a text file.
7.  Run "GCRootsToDgml log.txt out.dgml"
8   Load the graph to see the results.

If the output scrolls off the top of the output window use WinDBG which has a .logopen/.logclose command which will capture all the output.