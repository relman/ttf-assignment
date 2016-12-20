# ttf-assignment
C# implementation of TTF Assignment [more here](docs/assignment.pdf)

# used libraries
- Newtonsoft.Json.8.0.3 - popular high-performance JSON framework for .NET
- Moq.4.5.29 - most popular and friendly mocking framework for .NET
- Autofac.3.5.0 - addictive Inversion of Control container for .NET
- Microsoft.WebApi.5.2.3 - ideal platform for building RESTful applications on the .NET Framework
- Microsoft.Owin.3.0.1 - Open Web Interface for .NET

# how to launch project
To start Web service open [TTF.sln](TTF.sln) using Microsoft Visual Studio 2012 (or higher) and .NET Framework 4.5 (or higher). Set 'TTF.Web' as StartUp project. Build, Run and Enjoy

# how to test endpoint
default endpoint url is
http://localhost:8000

you can ping it with your favorite web debugger (in my case Fiddler):
``` Request
POST http://localhost:8000/ HTTP/1.1
User-Agent: Fiddler
Content-Type: application/json
Host: localhost:8000
Content-Length: 49

{"A":true,"B":true,"C":true,"D":24, "E":15,"F":7}
```

``` Response
HTTP/1.1 200 OK
Content-Length: 125
Content-Type: application/json
Server: Microsoft-HTTPAPI/2.0
Date: Tue, 20 Dec 2016 10:59:28 GMT

{"Items":[{"X":"R","Y":25.92,"MappingName":"Base Mapping B"},{"X":"R","Y":51.6,"MappingName":"Special Mapping 1"}],"OK":true}
```

![Fiddler Screenshot](/docs/screen_00.png?raw=true "Fiddler Screenshot")
