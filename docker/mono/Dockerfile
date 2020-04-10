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
#&& sudo wget https://chromedriver.storage.googleapis.com/80.0.3987.106/chromedriver_linux64.zip \
#&& sudo unzip chromedriver_linux64.zip \
#&& sudo rm chromedriver_linux64.zip \
#
# Get sample project and build it
&& apt-get -y install git \
&& git clone https://github.com/NaZaRKIN123/TestFrame.git \
&& mono nuget.exe restore TestFrame/TestFrame/TestFrame.sln \
&& msbuild TestFrame/TestFrame/TestFrame.sln /t:Build /p:Configuration=Release
#
# Install Chrome
#&& sudo wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb \
#&& sudo apt-get -y install ./google-chrome-stable_current_amd64.deb \
#&& sudo rm google-chrome-stable_current_amd64.deb
# Run tests
CMD mono home/NUnit.ConsoleRunner.${nUnitTestRunnerVersion}/tools/nunit3-console.exe home/TestFrame/TestFrame/TestFrame.TestsNet/bin/Release/TestFrame.TestsNet.dll -noresult
# end