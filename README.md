# PublisherAndSubcriber To run this code, install the http-repl 
run this command: dotnet tool install -g Microsoft.dotnet-httprepl
to post, run this command: httprepl https://localhost:44314/publish/topic1
then: post -h Content-Type=application/json -c "{"msg":"hello"}"
to get: connect https://localhost:44314/publish/topic1
then: get
If the port is different at your end, replace 44314 with your port
