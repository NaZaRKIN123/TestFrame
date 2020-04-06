FROM mono:6.8.0
RUN apt-get update \
&& apt-get -y install unzip \
&& cd home \
# Get Nuget and Microsoft.Build to make it work
&& curl -o nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe \
&& curl -o Microsoft.Build.zip https://headsigned.com/posts/running-nuget-command-line-on-linux/Microsoft.Build.zip \
&& unzip Microsoft.Build.zip \
&& rm Microsoft.Build.zip \
# Get NUnit and chromedriver
&& mono nuget.exe install NUnit -Version 3.12.0 \
&& mono nuget.exe install NUnit.Runners -Version 3.11.1 \
&& curl -o chromedriver_linux64.zip https://chromedriver.storage.googleapis.com/80.0.3987.106/chromedriver_linux64.zip \
&& apt-get -y install libnss3 \
&& unzip chromedriver_linux64.zip \
&& rm chromedriver_linux64.zip \
# Get sample project and build it
&& apt-get -y install git \
&& git clone https://github.com/NaZaRKIN123/TestFrame.git \
&& mono nuget.exe restore TestFrame/TestFrame/TestFrame.sln \
&& msbuild TestFrame/TestFrame/TestFrame.sln /t:Build /p:Configuration=Release
# Run tests
RUN mono NUnit.ConsoleRunner.3.11.1/tools/nunit3-console.exe TestFrame/TestFrame/TestFrame.TestsNet/bin/Release/TestFrame.TestsNet.dll -noresult
# end