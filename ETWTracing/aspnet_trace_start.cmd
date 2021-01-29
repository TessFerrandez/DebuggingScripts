if "%1" == "" set _output_log=%CD%\aspnet_trace_output.etl
if not "%1" == "" set _output_log="%1"
logman start aspnet_trace -pf aspnet_trace.txt -ct perf -o "%_output_log%" -bs 64 -nb 200 400 -ets
