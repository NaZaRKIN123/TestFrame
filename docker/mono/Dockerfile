FROM mono:6.8.0.96
ENV nUnitTestRunnerVersion 3.11.1
RUN apt-get update \ 
#
# Get unzip, wget and set current folder to home
&& apt-get -y install wget \
&& apt-get -y install unzip \
&& cd home \
#
# Get Nuget and Microsoft.Build to make it work
&& wget https://dist.nuget.org/win-x86-commandline/latest/nuget.exe \
&& wget https://headsigned.com/posts/running-nuget-command-line-on-linux/Microsoft.Build.zip \
&& unzip Microsoft.Build.zip \
&& rm Microsoft.Build.zip \
#
# Get NUnit and chromedriver
&& mono nuget.exe install NUnit -Version 3.12.0 \
&& mono nuget.exe install NUnit.Runners -Version ${nUnitTestRunnerVersion} \
#
# Get sample project and build it
&& apt-get -y install git

CMD cd home \
&& git clone https://github.com/NaZaRKIN123/TestFrame.git \
&& mono nuget.exe restore TestFrame/TestFrame/TestFrame.sln \
&& msbuild TestFrame/TestFrame/TestFrame.sln /t:Build /p:Configuration=Release \
#
# Run tests
&& mono NUnit.ConsoleRunner.${nUnitTestRunnerVersion}/tools/nunit3-console.exe TestFrame/TestFrame/TestFrame.TestsNet/bin/Release/TestFrame.TestsNet.dll -noresult
# end